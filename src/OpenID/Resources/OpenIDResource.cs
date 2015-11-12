namespace GenericLoginFramework.OpenID.Resources
{
    abstract class OpenIDResource : IResource
    {
        public abstract string ID { get; set; }
    }
}
