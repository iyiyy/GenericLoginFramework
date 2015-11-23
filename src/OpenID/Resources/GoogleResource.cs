using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericLoginFramework.OpenID.Resources
{
    public class GoogleResource : OpenIDResource
    {
        public override string ID { get; set; }

        //public string UserID { get; set; }
        [Key, ForeignKey("User")]
        public virtual User User { get; set; }
    }
}
