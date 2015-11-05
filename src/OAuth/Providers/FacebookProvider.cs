using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework.OAuth.Providers
{
    class FacebookProvider : GenericLoginFramework.OAuth.Providers.OAuthProvider
    {
        private static FacebookProvider instance;

        private FacebookProvider(){}

        public static FacebookProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new FacebookProvider();

                return instance;
            }
        }
    }
}
