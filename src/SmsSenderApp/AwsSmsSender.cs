using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmsSenderApp
{
    class AwsSmsSender : ISmsSender
    {
        public async Task SendSms(string phoneNumber, string message)
        {
            Console.WriteLine($"Sending SMS message \"{message}\" to {phoneNumber}.");
            await Task.Delay(1000);
            Console.WriteLine("Sent successfully using AWS SNS.");
        }
    }
}
