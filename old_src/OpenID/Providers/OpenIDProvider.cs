using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework.OpenID.Providers
{
    abstract class OpenIDProvider
    {
        public enum Flow
        {
            AuthorizationCode,
            Implicit,
            Hybrid
        }
    }
}
