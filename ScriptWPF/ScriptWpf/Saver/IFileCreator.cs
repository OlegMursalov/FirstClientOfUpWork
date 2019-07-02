using Script.Info;

namespace CetbixCVD.Saver
{
    public interface IFileCreator
    {
        bool SaveInfoToFile(DataOfComputer dataOfComputer, out string exMessgae);
    }
}