using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace LicenseCheckerCustomAction.Trial
{
    public class CreaterTrialWindow
    {
        private Window window;
        private Grid grid;
        private Dispatcher dispatcher;
        private Control[] unnecessaryControls;

        private string labelName = "TitleForTrial";
        private string labelContent = "Your trial is expired. \nYou can buy and enter new key. \nNeed internet connection that checking new key.";
        private string textBoxName = "EnteredLicenseKey";
        private string button1Name = "CheckLicenseKey";
        private string button1Content = "Check license key.";
        private string button2Name = "LinkToBuyApp";
        private string button2Content = "Link to buy app.";

        private Label TitleForTrial;
        private TextBox EnteredLicenseKey;
        private Button CheckLicenseKey;
        private Button LinkToBuyApp;

        public CreaterTrialWindow(Window window, Grid grid, Dispatcher dispatcher, params Control[] unnecessaryControls)
        {
            this.window = window;
            this.grid = grid;
            this.dispatcher = dispatcher;
            this.unnecessaryControls = unnecessaryControls;
        }

        public void Create()
        {
            BlockAndHideInterface(true);
            AddControlsForTrial();
        }

        private void BlockAndHideInterface(bool isBlock)
        {
            dispatcher.Invoke(new Action(() =>
            {
                for (var i = 0; i < unnecessaryControls.Length; i++)
                {
                    unnecessaryControls[i].IsEnabled = !isBlock;
                    unnecessaryControls[i].Visibility = isBlock ? Visibility.Collapsed : Visibility.Visible;
                }
                window.Background = isBlock ? new SolidColorBrush(Color.FromRgb(255, 176, 176)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }));
        }
        
        private void AddControlsForTrial()
        {
            dispatcher.Invoke(new Action(() =>
            {
                TitleForTrial = new Label();
                TitleForTrial.HorizontalAlignment = HorizontalAlignment.Left;
                TitleForTrial.VerticalAlignment = VerticalAlignment.Top;
                TitleForTrial.Margin = new Thickness(10, 29, 0, 0);
                TitleForTrial.Content = this.labelContent;
                TitleForTrial.Name = this.labelName;
                grid.Children.Add(TitleForTrial);
                EnteredLicenseKey = new TextBox();
                EnteredLicenseKey.HorizontalAlignment = HorizontalAlignment.Left;
                EnteredLicenseKey.VerticalAlignment = VerticalAlignment.Top;
                EnteredLicenseKey.Width = 263;
                EnteredLicenseKey.Height = 28;
                EnteredLicenseKey.Margin = new Thickness(10, 89, 0, 0);
                EnteredLicenseKey.Name = this.textBoxName;
                grid.Children.Add(EnteredLicenseKey);
                CheckLicenseKey = new Button();
                CheckLicenseKey.HorizontalAlignment = HorizontalAlignment.Left;
                CheckLicenseKey.VerticalAlignment = VerticalAlignment.Top;
                CheckLicenseKey.Width = 263;
                CheckLicenseKey.Height = 28;
                CheckLicenseKey.Margin = new Thickness(10, 129, 0, 0);
                CheckLicenseKey.Name = this.button1Name;
                CheckLicenseKey.Content = this.button1Content;
                CheckLicenseKey.Click += CheckLicenseKey_Click;
                grid.Children.Add(CheckLicenseKey);
                LinkToBuyApp = new Button();
                LinkToBuyApp.HorizontalAlignment = HorizontalAlignment.Left;
                LinkToBuyApp.VerticalAlignment = VerticalAlignment.Top;
                LinkToBuyApp.Width = 263;
                LinkToBuyApp.Height = 28;
                LinkToBuyApp.Margin = new Thickness(10, 169, 0, 0);
                LinkToBuyApp.Name = this.button2Name;
                LinkToBuyApp.Content = this.button2Content;
                LinkToBuyApp.Click += LinkToBuyApp_Click;
                grid.Children.Add(LinkToBuyApp);
            }));
        }

        private void RemoveControlsForTrial()
        {
            dispatcher.Invoke(new Action(() =>
            {
                grid.Children.Remove(TitleForTrial);
                grid.Children.Remove(EnteredLicenseKey);
                grid.Children.Remove(CheckLicenseKey);
                grid.Children.Remove(LinkToBuyApp);
            }));
        }

        private void LinkToBuyApp_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Common.URIForBuyApp);
        }

        private void CheckLicenseKey_Click(object sender, RoutedEventArgs e)
        {
            var enteredLicenseKey = EnteredLicenseKey.Text;
            if (!string.IsNullOrEmpty(enteredLicenseKey))
            {
                var exMessage = string.Empty;
                var cetbixActivationFilePath = AppDomain.CurrentDomain.BaseDirectory + "Cetbix.Activation.dll";
                var checker = new Checker(cetbixActivationFilePath);
                var checkFlag = checker.CheckLicenseKeyBeforeInstall(enteredLicenseKey, $"{Common.TestApi}/license-checker.php", out exMessage);
                if (checkFlag)
                {
                    RemoveControlsForTrial();
                    BlockAndHideInterface(false);
                }
                else if (!string.IsNullOrEmpty(exMessage))
                {
                    MessageBox.Show(exMessage);
                }
            }
            else
            {
                MessageBox.Show("You have not entered a license key.");
            }
        }
    }
}