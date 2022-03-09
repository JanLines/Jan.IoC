using Jan.IoC;
using System;
using System.Threading.Tasks;

namespace SmsSenderApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // IoC Register
            var container = new Container();
#if USE_TWILIO
            container.Register<ISmsSender, TwilioSmsSender>();
#endif
#if USE_AWS
            container.Register<ISmsSender, AwsSmsSender>(LifecycleType.Singleton);
#endif
            
            // IoC Resolve
            var smsSender = container.Resolve<ISmsSender>();
            await smsSender.SendSms("+15017122661", "Hi there!");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        

    }
}
