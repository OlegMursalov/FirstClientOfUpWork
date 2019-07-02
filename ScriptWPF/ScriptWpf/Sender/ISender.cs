using Script.Info;

namespace CetbixCVD.Sender
{
    public interface ISender
    {
        bool SendData(DataOfComputer data, out string exMessage);
    }
}