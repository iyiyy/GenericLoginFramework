using GenericLoginFramework.OAuth.Resources;
using GenericLoginFramework.OpenID.Resources;
using System;

namespace GenericLoginFramework
{
    public partial class User
    {
        public Guid ID { get; set; }

        public FacebookResource FacebookResource { get; set; }
        public GoogleResource GoogleResource { get; set; }
    }
}
