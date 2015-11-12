namespace GenericLoginFramework.OpenID.Resources
{
    class GoogleResource : OpenIDResource
    {
        public override string ID { get; set; }

        public string UserID { get; set; }
        public virtual User User { get; set; }
    }
}
