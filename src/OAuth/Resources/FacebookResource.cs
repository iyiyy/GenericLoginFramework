namespace GenericLoginFramework.OAuth.Resources
{
    class FacebookResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AgeRange { get; set; }
        public string Link { get; set; }
        public string Locale { get; set; }
        public string Timezone { get; set; }
        public string UpdatedTime { get; set; }
        public string Verified { get; set; }

        public int UserId { get; set; }
        public virtual User user { get; set; }
    }
}
