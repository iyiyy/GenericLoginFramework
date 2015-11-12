namespace GenericLoginFramework.OAuth.Resources
{
    class FacebookResource : OAuthResource
    {
        public override string ID { get; set; }

        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AgeRange { get; set; }
        public string Link { get; set; }
        public string Locale { get; set; }
        public string Timezone { get; set; }
        public string UpdatedTime { get; set; }
        public string Verified { get; set; }

        public string UserID { get; set; }
        public virtual User User { get; set; }
    }
}
