using LicenseCheckerCustomAction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
                try
                {
                    var uuid = Common.GetUUID();
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.TestApi}/license-checker.php");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write($"LicenseKeyValue={enteredLicenseKey};UUID={uuid}");
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        if (!string.IsNullOrEmpty(result))
                        {
                            var parts = result.Split(';');
                            if (parts.Length >= 2)
                            {
                                if (parts[0].IndexOf("ActivationId", 0, StringComparison.CurrentCultureIgnoreCase) != -1 && parts[1].IndexOf("AmountOfMinutes", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                                {
                                    var fragmentsOfActivationId = parts[0].Split('=');
                                    var fragmentsOfAmountOfMinutes = parts[1].Split('=');
                                    if (fragmentsOfActivationId.Length >= 2 && fragmentsOfAmountOfMinutes.Length >= 2)
                                    {
                                        var activationId = fragmentsOfActivationId[1];
                                        var amountOfMinutes = int.Parse(fragmentsOfAmountOfMinutes[1]);
                                        var lastDate = DateTime.Now.AddMinutes(amountOfMinutes);
                                        var mainPath = AppDomain.CurrentDomain.BaseDirectory;
                                        using (var fstream = new FileStream($"{mainPath}\\Cetbix.Activation.dll", FileMode.OpenOrCreate))
                                        {
                                            var encryptor = new Encryptor(Common.GuidForEncryptor);
                                            var text = $"ActivationId={activationId};LastDate={lastDate}";
                                            var encryptText = encryptor.Encrypt(text);
                                            var array = Encoding.UTF8.GetBytes(encryptText);
                                            fstream.Write(array, 0, array.Length);
                                            RemoveControlsForTrial();
                                            BlockAndHideInterface(false);
                                        }
                                    }
                                }
                                else
                                {
                                    // throw new Exception("Error in MSI [6703]");
                                    MessageBox.Show("Error in MSI [6703]");
                                }
                            }
                            else
                            {
                                // throw new Exception(result);
                                MessageBox.Show(result);
                            }
                        }
                        else
                        {
                            // throw new Exception("Error in MSI [9958]");
                            MessageBox.Show("Error in MSI [9958]");
                        }
                    }
                }
                catch (WebException ex)
                {
                    // throw new Exception("Check your internet connection.");
                    MessageBox.Show("Check your internet connection.");
                }
            }
            else
            {
                // throw new Exception("You have not entered a license key.");
                MessageBox.Show("You have not entered a license key.");
            }
        }
    }
}