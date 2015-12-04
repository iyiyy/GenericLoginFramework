namespace GenericLoginFramework.OpenID.Resources
{
    public class GoogleResource : OpenIDResource
    {
        public override string ID { get; set; }
        public override User User { get; set; }
    }
}
