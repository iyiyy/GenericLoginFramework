namespace GenericLoginFramework.OAuth.Resources
{
    public abstract class OAuthResource : IResource
    {
        public abstract string ID { get; set; }
        public abstract User User { get; set; }
    }
}
