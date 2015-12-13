using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework.Providers
{
    public class GoogleProvider : OpenIDProvider
    {
        private static GoogleProvider _instance;
        public override string RedirectURI { get; set; } = "https://www.facebook.com/connect/login_success.html";
        public override string LoginEndpoint { get; set; } = "www.googleapis.com/oauth2/v4/token";
        public override string ResourceEndpoint { get; set; } = "https://graph.facebook.com/me";
        public override string Scope { get; set; } = "email%20profile";

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

        public override async Task<string> GetTokenFromGrant(string grant)
        {
            string token = "";

            using (var client = new HttpClient())
            {
                Dictionary<string, string> postvalues = new Dictionary<string, string>
                {
                   { "code", grant },
                   { "client_id", AppID },
                   { "client_secret", AppSecret },
                   { "redirect_uri", RedirectURI },
                   { "grant_type", "authorization_code" }
                };

                var content = new FormUrlEncodedContent(postvalues);

                var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
            }

            return token;
        }

        public override Task<Resource> GetResourceFromToken(string token)
        {
            throw new NotImplementedException();
        }

        protected override Resource ConvertJSONToResource(string JSONString)
        {
            throw new NotImplementedException();
        }
    }
}
