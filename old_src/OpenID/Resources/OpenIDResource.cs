namespace GenericLoginFramework.OpenID.Resources
{
    public abstract class OpenIDResource : IResource
    {
        public abstract string ID { get; set; }
        public abstract User User { get; set; }
    }
}
