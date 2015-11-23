using System.ComponentModel.DataAnnotations;

namespace GenericLoginFramework
{
    public partial class User
    {
        [Key]
        public string ID { get; set; }
        public virtual GenericLoginFramework.OAuth.Resources.FacebookResource FacebookResource { get; set; }
        public virtual GenericLoginFramework.OpenID.Resources.GoogleResource GoogleResource { get; set; }
    }
}
