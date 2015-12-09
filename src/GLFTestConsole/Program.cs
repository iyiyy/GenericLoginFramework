using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericLoginFramework;
using GenericLoginFramework.Providers;

namespace GLFTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GLF glf = GLF.Instance;

            glf.InitializeDB();
            FacebookProvider.Instance.Enable("624408054367639", "3ee73a2a0c243edff171618669a7b1a3");
            Console.WriteLine(FacebookProvider.Instance.AppID);
            Console.WriteLine(FacebookProvider.Instance.AppSecret);
            Console.WriteLine(FacebookProvider.Instance.Enabled);
            Console.WriteLine(FacebookProvider.Instance.FullyQualifiedLoginEndpoint());
            Console.WriteLine(FacebookProvider.Instance.LoginEndpoint);
            Console.WriteLine(FacebookProvider.Instance.RedirectURI);
            Console.WriteLine(FacebookProvider.Instance.ResourceEndpoint);
            Console.WriteLine(FacebookProvider.Instance.ResponseType);
            Console.WriteLine(FacebookProvider.Instance.Scope);
            Console.WriteLine(FacebookProvider.Instance.State);
            Console.WriteLine(FacebookProvider.Instance.UsedFlow);


            Console.WriteLine("DB was initialized.");
            Console.ReadKey();
        }
    }
}

