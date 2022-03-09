using System.Threading.Tasks;

namespace SmsSenderApp
{
    interface ISmsSender
    {
        Task SendSms(string phoneNumber, string message);
    }
}
