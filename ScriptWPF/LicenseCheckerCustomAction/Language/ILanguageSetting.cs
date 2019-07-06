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
    }
}