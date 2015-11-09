using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework.OAuth.Providers
{
    class FacebookProvider : GenericLoginFramework.OAuth.Providers.OAuthProvider
    {
        private static GenericLoginFramework.OAuth.Providers.FacebookProvider instance;
        private string appID;
        private string appSecret;
        private GenericLoginFramework.OAuth.Providers.OAuthProvider.Flow flow;

        private FacebookProvider(){}

        public static GenericLoginFramework.OAuth.Providers.FacebookProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new FacebookProvider();

                return instance;
            }
        }

        public string AppID
        {
            get
            {
                return appID;
            }
            set
            {
                if (appID == null)
                    appID = value;
            }
        }

        public string AppSecret
        {
            get
            {
                return appSecret;
            }
            set
            {
                if (appSecret == null)
                    appSecret = value;
            }
        }

        public GenericLoginFramework.OAuth.Providers.OAuthProvider.Flow UsedFlow
        {
            get
            {
                return flow;
            }
            set
            {
                flow = value;
            }
        }

        public override void SetKeys(string[] keys)
        {
            if (keys.Length == 1)
            {
                this.AppID = keys[0];
                this.UsedFlow = GenericLoginFramework.OAuth.Providers.OAuthProvider.Flow.Implicit;
            }
            else if (keys.Length > 1)
            {
                this.AppID = keys[0];
                this.AppSecret = keys[1];
                this.UsedFlow = GenericLoginFramework.OAuth.Providers.OAuthProvider.Flow.AuthorizationCode;
            }
        }


    }
}
