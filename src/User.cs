namespace GenericLoginFramework
{
    public class User
    {
        public string ID { get; set; }
        public GenericLoginFramework.OAuth.Resources.FacebookResource FacebookResource { get; set; }
        public GenericLoginFramework.OpenID.Resources.GoogleResource GoogleResource { get; set; }
    }
}
