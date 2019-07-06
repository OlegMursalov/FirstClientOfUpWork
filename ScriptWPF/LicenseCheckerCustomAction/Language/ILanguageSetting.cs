using System.Collections.Generic;

namespace CetbixCVD.Language
{
    public interface ILanguageSetting
    {
        /// <summary>
        /// Contents for controls
        /// </summary>
        Dictionary<string, string> Contents { get; }

        /// <summary>
        /// Messages for MessageBox
        /// </summary>
        Dictionary<string, string> Messages { get; }

        /// <summary>
        /// Titles for windows
        /// </summary>
        Dictionary<string, string> Titles { get; }

        /// <summary>
        /// Other strings
        /// </summary>
        Dictionary<string, string> Strings { get; }
    }
}