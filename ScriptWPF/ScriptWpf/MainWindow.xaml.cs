using Script.Info;
using Script.Sender;
using Script.Saver;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Windows.Media;
using Script.Common;

namespace ScriptWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            if (args != null)
            {
                var ex = args.ExceptionObject as Exception;
                if (ex != null)
                {
                    MessageBox.Show(ex.Message + " - " + ex.StackTrace);
                }
            }
        }

        private async void Run_Click(object sender, RoutedEventArgs e)
        {
            MainProgress.Visibility = Visibility.Visible;
            MainProgress.IsIndeterminate = true;
            Run.Content = "Please, wait...";
            Background = new SolidColorBrush(Color.FromRgb(255, 255, 230));
            Run.IsEnabled = false;
            var cetbixURI = CetbixURI.Text;
            if (!string.IsNullOrEmpty(cetbixURI))
            {
                var dataOfComputer = new DataOfComputer();
                
                await Task.Run(() =>
                {
                    dataOfComputer.Id = Guid.NewGuid().ToString();
                    dataOfComputer.CetbixVulnerabilityScannerVersion = "2.7.00.1";
                    dataOfComputer.DateScan = CommonF.GetDateScan();

                    dataOfComputer.SystemUptime = MainInfo.SystemUptime;
                    dataOfComputer.HostName = MainInfo.HostName;
                    dataOfComputer.Domain = MainInfo.Domain;
                    dataOfComputer.Type = MainInfo.Type;
                    dataOfComputer.IP = MainInfo.IP;

                    dataOfComputer.OSVersion = OSInfo.OSVersion;
                    dataOfComputer.OSOrganization = OSInfo.OSOrganization;
                    dataOfComputer.OSCaption = OSInfo.OSCaption;

                    dataOfComputer.Java = JavaInfo.JavaVersion;

                    dataOfComputer.LAPS = LapsInfo.LAPSInstalled;

                    dataOfComputer.AntivirusInstalled = AntivirusInfo.AntivirusInstalled;
                    dataOfComputer.AntivirusName = AntivirusInfo.AntivirusName;
                    dataOfComputer.AntivirusRunning = AntivirusInfo.AntivirusRunning;
                    dataOfComputer.AntivirusVersion = AntivirusInfo.AntivirusVersion;
                    dataOfComputer.AntivirusLatestUpdate = AntivirusInfo.AntivirusLatestUpdate;

                    dataOfComputer.MicrosoftKB = MicrosoftKBInfo.MicrosoftKB;

                    dataOfComputer.Shares = FoldersInfo.Shares;

                    dataOfComputer.FileExplorerExe = BrowserInfo.IEShortInfo;
                    dataOfComputer.IEVersion = BrowserInfo.IEVersion;
                    dataOfComputer.MDP5InternetExplorer = BrowserInfo.IE_MDP5;
                    dataOfComputer.FileChromeExe = BrowserInfo.ChromeShortInfo;
                    dataOfComputer.ChromeVersion = BrowserInfo.ChromeVersion;
                    dataOfComputer.MDP5Chrome = BrowserInfo.Chrome_MDP5;
                    dataOfComputer.FireFoxExe = BrowserInfo.FireFoxShortInfo;
                    dataOfComputer.FireFoxVersion = BrowserInfo.FireFoxVersion;
                    dataOfComputer.MDP5FireFox = BrowserInfo.FireFox_MDP5;

                    dataOfComputer.SMBv1 = SMBv1Info.SMBv1;

                    dataOfComputer.MinimumPasswordAge = NetAccountsInfo.MinimumPasswordAge;
                    dataOfComputer.MaximumPasswordAge = NetAccountsInfo.MaximumPasswordAge;
                    dataOfComputer.MinimumPasswordLength = NetAccountsInfo.MinimumPasswordLength;
                    dataOfComputer.ComputerRole = NetAccountsInfo.ComputerRole;
                    dataOfComputer.AccountLockoutDuration = NetAccountsInfo.AccountLockoutDuration;
                    dataOfComputer.LockoutObservationWindows = NetAccountsInfo.LockoutObservationWindows;
                    dataOfComputer.PasswordHistory = NetAccountsInfo.PasswordHistory;
                    dataOfComputer.LockoutThreshold = NetAccountsInfo.LockoutThreshold;

                    dataOfComputer.AdobeAcrobatReaderDC = AdobeInfo.AdobeAcrobatReaderDC;
                    dataOfComputer.AdobeRefrechManager = AdobeInfo.AdobeRefrechManager;

                    dataOfComputer.UACActivated = UACInfo.UACActivated;

                    dataOfComputer.Autorun = AutorunInfo.Autorun;

                    dataOfComputer.FireWallHome = FireWallInfo.FireWallHome;
                    dataOfComputer.FireWallLAN = FireWallInfo.FireWallLAN;
                    dataOfComputer.FireWallPublicNetwork = FireWallInfo.FireWallPublicNetwork;

                    dataOfComputer.ComplianceToolVersion = ComplianceToolInfo.ComplianceToolVersion;

                    dataOfComputer.MPPActivated = MPPInfo.MPPActivated;
                    dataOfComputer.MPPTempExe = MPPInfo.MPPTempExe;

                    dataOfComputer.MotherboardProduct = BaseBoardInfo.Product;
                    dataOfComputer.MotherboardVersion = BaseBoardInfo.Version;
                    dataOfComputer.MotherboardSerialNumber = BaseBoardInfo.SerialNumber;
                    dataOfComputer.MotherboardManufacturer = BaseBoardInfo.Manufacturer;

                    dataOfComputer.Rams = RamInfo.Rams;

                    dataOfComputer.GraphicsCards = GraphicsCardInfo.GraphicsCards;

                    dataOfComputer.CPUs = CPUInfo.CPUs;

                    dataOfComputer.SoundCards = SoundCardInfo.SoundCards;

                    dataOfComputer.HDDs = HDDInfo.HDDs;
                });

                if (SendToCetbixRadio.IsChecked != null && SendToCetbixRadio.IsChecked.Value)
                {
                    string exMessgae = string.Empty;
                    var mySender = new HttpJsonSender(cetbixURI);
                    var sendFlag = await Task.Run(() =>
                    {
                        return mySender.SendData(dataOfComputer, out exMessgae);
                    });
                    if (sendFlag)
                    {
                        MessageBox.Show("Data successfully sent to Cetbix.");
                    }
                    else
                    {
                        MessageBox.Show($"Exception: {exMessgae}");
                    }
                }
                if (SaveToLocalRadio.IsChecked != null && SaveToLocalRadio.IsChecked.Value)
                {
                    string exMessgae = string.Empty;
                    var myLog = new Log();
                    var saveFlag = await Task.Run(() =>
                    {
                        return myLog.SaveInfoToFile(dataOfComputer, out exMessgae);
                    });
                    if (saveFlag)
                    {
                        MessageBox.Show("Data successfully save to local.");
                    }
                    else
                    {
                        MessageBox.Show($"Exception: {exMessgae}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Fill Cetbix URI (add_assets.php)");
            }
            Run.Content = "Run";
            Run.IsEnabled = true;
            Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            MainProgress.IsIndeterminate = false;
            MainProgress.Visibility = Visibility.Hidden;
        }

        private void SaveToLocalRadio_Checked(object sender, RoutedEventArgs e)
        {
            LabelCetbix.Visibility = Visibility.Hidden;
            CetbixURI.Visibility = Visibility.Hidden;
            Run.Margin = new Thickness(10, 90, 0, 0);
            MainProgress.Margin = new Thickness(10, 134, 0, 0);
        }

        public void SaveToLocalRadio_Unchecked(object sender, RoutedEventArgs e)
        {
            LabelCetbix.Visibility = Visibility.Visible;
            CetbixURI.Visibility = Visibility.Visible;
            Run.Margin = new Thickness(10, 137, 0, 0);
            MainProgress.Margin = new Thickness(10, 181, 0, 0);
        }
    }
}