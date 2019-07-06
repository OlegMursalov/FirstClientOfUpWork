using System.Collections.Generic;

namespace CetbixCVD.Language
{
    public interface ILanguageSetting
    {
        Dictionary<string, string> Setting { get; }
    }
}