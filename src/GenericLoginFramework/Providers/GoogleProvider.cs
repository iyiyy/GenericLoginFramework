using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework.Providers
{
    public class GoogleProvider : OpenIDProvider
    {
        private static GoogleProvider _instance;

        public override string LoginEndpoint
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override string RedirectURI
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override string ResourceEndpoint
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override string Scope
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public static GoogleProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GoogleProvider();

                return _instance;
            }
        }

        private GoogleProvider() { }

        public override Task<Resource> GetResourceFromToken(string token)
        {
            throw new NotImplementedException();
        }

        public override Task<string> GetTokenFromGrant(string grant)
        {
            throw new NotImplementedException();
        }

        protected override Resource ConvertJSONToResource(string JSONString)
        {
            throw new NotImplementedException();
        }
    }
}
