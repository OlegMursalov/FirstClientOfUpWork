using CetbixCVD.Language;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LicenseCheckerCustomAction
{
    public class MainCancelation
    {
        private bool isCancel;
        public bool IsCancel {
            get
            {
                return isCancel;
            }
        }

        public MainCancelation()
        {
            isCancel = false;
        }

        public void Cancel()
        {
            isCancel = true;
        }
    }

    public class Checker
    {
        private string cetbixActivationFilePath;
        private MainLanguage mainLanguage;

        public Checker(string cetbixActivationFilePath, MainLanguage mainLanguage)
        {
            this.cetbixActivationFilePath = cetbixActivationFilePath;
            this.mainLanguage = mainLanguage;
        }

        #region [Checking license key before installation]
        /// <summary>
        /// Make a request for an API, checks the license key, if the license key exists and is not activated,
        /// then receives the key information (ActivationId, LastDate) and writes it to the file "Cetbix.Activation.dll".
        /// </summary>
        /// <param name="enteredLicenseKey">License key</param>
        /// <param name="apiUri">Main API uri</param>
        /// <param name="assemblyPath">Path to the main program folder</param>
        /// <param name="exMessage">Exception message (if any)</param>
        /// <param name="actionBeforeInstall">Pre-install action</param>
        /// <returns>Returns true if the key was successfully activated and the key data is written to a file "Cetbix.Activation.dll". Otherwise, it returns false.</returns>
        public bool CheckLicenseKeyBeforeInstall(string enteredLicenseKey, string apiUri, out string exMessage, Action actionBeforeInstall = null)
        {
            exMessage = string.Empty;
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                using (var fstream = new FileStream(cetbixActivationFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    var uuid = Common.GetUUID();
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUri);
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
                                        var lastDate = DateTime.MinValue;
                                        var activationId = fragmentsOfActivationId[1];
                                        var amountOfMinutes = long.Parse(fragmentsOfAmountOfMinutes[1]);
                                        try
                                        {
                                            lastDate = DateTime.Now.AddMinutes(amountOfMinutes);
                                        }
                                        catch (Exception ex)
                                        {
                                            lastDate = DateTime.MaxValue;
                                        }
                                        actionBeforeInstall?.Invoke();
                                        var encryptor = new Encryptor(Common.GuidForEncryptor);
                                        var text = $"ActivationId={activationId};LastDate={lastDate}";
                                        var encryptText = encryptor.Encrypt(text);
                                        var array = Encoding.UTF8.GetBytes(encryptText);
                                        fstream.Write(array, 0, array.Length);
                                        fstream.Close();
                                        return true;
                                    }
                                }
                                else
                                {
                                    throw new Exception("6703");
                                }
                            }
                            else
                            {
                                throw new Exception(result);
                            }
                        }
                        else
                        {
                            throw new Exception("9958");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }
            return false;
        }
        #endregion

        #region [Checking license key during working app (after installation)]
        /// <summary>
        /// Makes a request to the Cetbix server and checks the availability of the key every /milliseconds/.
        /// If key is not available run /action/.
        /// </summary>
        public void StartCheckingAfterInstall(int milliseconds, Action action)
        {
            var mainCancelation = new MainCancelation();
            var checkerTask = Task.Run(() => { MainCheck(mainCancelation, milliseconds, action); });
        }

        private void MainCheck(MainCancelation mainCancelation, int milliseconds, Action action)
        {
            while (true)
            {
                if (!mainCancelation.IsCancel)
                {
                    if (CheckAfterInstall(mainCancelation))
                    {
                        Thread.Sleep(milliseconds);
                    }
                    else
                    {
                        action();
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private bool CheckAfterInstall(MainCancelation mainCancelation)
        {
            if (File.Exists(cetbixActivationFilePath))
            {
                var text = File.ReadAllText(cetbixActivationFilePath).Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    var encryptor = new Encryptor(Common.GuidForEncryptor);
                    var decryptText = encryptor.Decrypt(text);
                    if (!string.IsNullOrEmpty(decryptText))
                    {
                        var parts = decryptText.Split(';');
                        if (parts.Length >= 2)
                        {
                            if (parts[0].IndexOf("ActivationId", 0, StringComparison.CurrentCultureIgnoreCase) != -1 && parts[1].IndexOf("LastDate", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                            {
                                var fragmentsOfActivationId = parts[0].Split('=');
                                var fragmentsOfLastDate = parts[1].Split('=');
                                if (fragmentsOfActivationId.Length >= 2 && fragmentsOfLastDate.Length >= 2)
                                {
                                    var activationId = fragmentsOfActivationId[1];
                                    var lastDateStr = fragmentsOfLastDate[1];
                                    if (!string.IsNullOrEmpty(activationId) && !string.IsNullOrEmpty(lastDateStr))
                                    {
                                        var lastDate = DateTime.MinValue;
                                        if (DateTime.TryParse(lastDateStr, out lastDate))
                                        {
                                            if (lastDate.Year == DateTime.MaxValue.Year)
                                            {
                                                mainCancelation.Cancel();
                                                return true;
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.ApiCetbixUri}/{Common.ActivationChecker}");
                                                    httpWebRequest.ContentType = "application/json";
                                                    httpWebRequest.Method = "POST";
                                                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                                    {
                                                        streamWriter.Write($"ActivationId={activationId}");
                                                    }
                                                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                                                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                                    {
                                                        var result = streamReader.ReadToEnd().Trim();
                                                        var mainFlag = Convert.ToBoolean(int.Parse(result));
                                                        return mainFlag;
                                                    }
                                                }
                                                catch (WebException ex)
                                                {
                                                    return DateTime.Now <= lastDate;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}