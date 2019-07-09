using LicenseCheckerCustomAction;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CetbixCVD.Language
{
    public class MainLanguage
    {
        private Dispatcher dispatcher;
        private ILanguageSetting languageSetting;

        public MainLanguage(LanguageEnum language, Dispatcher dispatcher)
        {
            this.languageSetting = LanguageSettingFactory.GetSettingByLanguage(language);
            this.dispatcher = dispatcher;
        }

        public MainLanguage(LanguageEnum language)
        {
            this.languageSetting = LanguageSettingFactory.GetSettingByLanguage(language);
            this.dispatcher = null;
        }

        /// <summary>
        /// Set language settings (initializer)
        /// </summary>
        public void SetContentsForControls(List<ContentControl> contentControls)
        {
            var dictionary = languageSetting.Contents;
            dispatcher.Invoke(new Action(() =>
            {
                foreach (var pair in dictionary)
                {
                    foreach (var control in contentControls)
                    {
                        if (control.Name == pair.Key)
                        {
                            control.Content = pair.Value;
                        }
                    }
                }
            }));
        }

        /// <summary>
        /// Set language setting by key
        /// </summary>
        public void SetContentForControlByKey(ContentControl contentControl, string key)
        {
            var dictionary = languageSetting.Contents;
            if (dictionary.ContainsKey(key))
            {
                dispatcher.Invoke(new Action(() =>
                {
                    contentControl.Content = dictionary[key];
                }));
            }
        }

        /// <summary>
        /// Set language setting by control name (default)
        /// </summary>
        public void SetContentForControlByDefault(ContentControl contentControl)
        {
            var dictionary = languageSetting.Contents;
            if (dictionary.ContainsKey(contentControl.Name))
            {
                dispatcher.Invoke(new Action(() =>
                {
                    contentControl.Content = dictionary[contentControl.Name];
                }));
            }
        }

        /// <summary>
        /// Get message by key (for MessageBox)
        /// </summary>
        public string GetMessageByKey(string key)
        {
            var dictionary = languageSetting.Messages;
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get title by key (for windows)
        /// </summary>
        public string GetTitleByKey(string key)
        {
            var dictionary = languageSetting.Titles;
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get string by key (other strings)
        /// </summary>
        public string GetStringByKey(string key)
        {
            var dictionary = languageSetting.Strings;
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            else
            {
                return string.Empty;
            }
        }
    }
}