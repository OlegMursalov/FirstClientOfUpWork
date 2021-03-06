﻿using CetbixCVD.Language;
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
        private MainLanguage mainLanguage;
        private Control[] unnecessaryControls;

        private string labelName = "TitleForTrial";
        private string textBoxName = "EnteredLicenseKey";
        private string button1Name = "CheckLicenseKey";
        private string button2Name = "LinkToBuyApp";

        private Label TitleForTrial;
        private TextBox EnteredLicenseKey;
        private Button CheckLicenseKey;
        private Button LinkToBuyApp;

        public CreaterTrialWindow(Window window, Grid grid, Dispatcher dispatcher, MainLanguage mainLanguage, params Control[] unnecessaryControls)
        {
            this.window = window;
            this.grid = grid;
            this.dispatcher = dispatcher;
            this.mainLanguage = mainLanguage;
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
                TitleForTrial.Name = this.labelName;
                mainLanguage.SetContentForControlByDefault(TitleForTrial);
                grid.Children.Add(TitleForTrial);
                EnteredLicenseKey = new TextBox();
                EnteredLicenseKey.HorizontalAlignment = HorizontalAlignment.Left;
                EnteredLicenseKey.VerticalAlignment = VerticalAlignment.Top;
                EnteredLicenseKey.Width = 374;
                EnteredLicenseKey.Height = 28;
                EnteredLicenseKey.Margin = new Thickness(10, 89, 0, 0);
                EnteredLicenseKey.Name = this.textBoxName;
                grid.Children.Add(EnteredLicenseKey);
                CheckLicenseKey = new Button();
                CheckLicenseKey.HorizontalAlignment = HorizontalAlignment.Left;
                CheckLicenseKey.VerticalAlignment = VerticalAlignment.Top;
                CheckLicenseKey.Width = 374;
                CheckLicenseKey.Height = 28;
                CheckLicenseKey.Margin = new Thickness(10, 129, 0, 0);
                CheckLicenseKey.Name = this.button1Name;
                mainLanguage.SetContentForControlByDefault(CheckLicenseKey);
                CheckLicenseKey.Click += CheckLicenseKey_Click;
                grid.Children.Add(CheckLicenseKey);
                LinkToBuyApp = new Button();
                LinkToBuyApp.HorizontalAlignment = HorizontalAlignment.Left;
                LinkToBuyApp.VerticalAlignment = VerticalAlignment.Top;
                LinkToBuyApp.Width = 374;
                LinkToBuyApp.Height = 28;
                LinkToBuyApp.Margin = new Thickness(10, 169, 0, 0);
                LinkToBuyApp.Name = this.button2Name;
                mainLanguage.SetContentForControlByDefault(LinkToBuyApp);
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
                var cetbixActivationFilePath = AppDomain.CurrentDomain.BaseDirectory + Common.ActivationFileName;
                var checker = new Checker(cetbixActivationFilePath, mainLanguage);
                var checkFlag = checker.CheckLicenseKeyBeforeInstall(enteredLicenseKey, $"{Common.ApiCetbixUri}/{Common.LicenseChecker}", out exMessage);
                if (checkFlag)
                {
                    RemoveControlsForTrial();
                    BlockAndHideInterface(false);
                }
                else if (!checkFlag && !string.IsNullOrEmpty(exMessage))
                {
                    var message = mainLanguage.GetMessageByKey(exMessage);
                    if (!string.IsNullOrEmpty(message))
                    {
                        MessageBox.Show(message);
                    }
                    else
                    {
                        MessageBox.Show($"Error in MSI [{exMessage}].");
                    }
                }
            }
            else
            {
                MessageBox.Show(mainLanguage.GetMessageByKey("NotEnteredLicenseKey"));
            }
        }
    }
}