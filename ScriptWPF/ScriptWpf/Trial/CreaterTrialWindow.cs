using LicenseCheckerCustomAction;
using ScriptWpf;
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

namespace CetbixCVD.Trial
{
    public class CreaterTrialWindow
    {
        private MainWindow mainWindow;

        private string labelName = "TitleForTrial";
        private string labelContent = "Your trial is expired. You can buy and enter new key. Need internet connection that checking new key.";
        private string textBoxName = "EnteredLicenseKey";
        private string button1Name = "CheckLicenseKey";
        private string button1Content = "Check license key.";
        private string button2Name = "LinkToBuyApp";
        private string button2Content = "Link to buy app.";

        private Label TitleForTrial;
        private TextBox EnteredLicenseKey;
        private Button CheckLicenseKey;
        private Button LinkToBuyApp;

        public CreaterTrialWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void Create()
        {
            BlockAndHideInterface(true);
            AddControlsForTrial();
        }

        private void BlockAndHideInterface(bool isBlock)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                mainWindow.SendToCetbixRadio.IsEnabled = isBlock;
                mainWindow.SendToCetbixRadio.Visibility = isBlock ? Visibility.Collapsed : Visibility.Visible;
                mainWindow.SaveToLocalRadio.IsEnabled = isBlock;
                mainWindow.SaveToLocalRadio.Visibility = isBlock ? Visibility.Collapsed : Visibility.Visible;
                mainWindow.Run.IsEnabled = isBlock;
                mainWindow.Run.Visibility = isBlock ? Visibility.Collapsed : Visibility.Visible;
                mainWindow.CetbixURI.IsEnabled = isBlock;
                mainWindow.CetbixURI.Visibility = isBlock ? Visibility.Collapsed : Visibility.Visible;
                mainWindow.LabelCetbix.IsEnabled = isBlock;
                mainWindow.LabelCetbix.Visibility = isBlock ? Visibility.Collapsed : Visibility.Visible;
                mainWindow.MainProgress.IsEnabled = isBlock;
                mainWindow.MainProgress.Visibility = isBlock ? Visibility.Collapsed : Visibility.Visible;
                mainWindow.Background = isBlock ? new SolidColorBrush(Color.FromRgb(255, 176, 176)) : new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }));
        }

        private void AddControlsForTrial()
        {
            TitleForTrial = new Label();
            TitleForTrial.Content = this.labelContent;
            TitleForTrial.Name = this.labelName;
            mainWindow.MainGrid.Children.Add(TitleForTrial);
            EnteredLicenseKey = new TextBox();
            EnteredLicenseKey.Name = this.textBoxName;
            mainWindow.MainGrid.Children.Add(EnteredLicenseKey);
            CheckLicenseKey = new Button();
            CheckLicenseKey.Name = this.button1Name;
            CheckLicenseKey.Content = this.button1Content;
            CheckLicenseKey.Click += CheckLicenseKey_Click;
            mainWindow.MainGrid.Children.Add(CheckLicenseKey);
            LinkToBuyApp = new Button();
            LinkToBuyApp.Name = this.button2Name;
            LinkToBuyApp.Content = this.button2Content;
            LinkToBuyApp.Click += LinkToBuyApp_Click;
            mainWindow.MainGrid.Children.Add(LinkToBuyApp);
        }

        private void RemoveControlsForTrial()
        {
            mainWindow.MainGrid.Children.Remove(TitleForTrial);
            mainWindow.MainGrid.Children.Remove(EnteredLicenseKey);
            mainWindow.MainGrid.Children.Remove(CheckLicenseKey);
            mainWindow.MainGrid.Children.Remove(LinkToBuyApp);
        }

        private void LinkToBuyApp_Click(object sender, RoutedEventArgs e)
        {
            
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