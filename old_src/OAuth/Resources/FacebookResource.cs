namespace GenericLoginFramework.OAuth.Resources
{
    public class FacebookResource : OAuthResource
    {
        public override string ID { get; set; }

        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AgeRange { get; set; }
        public string Link { get; set; }
        public string Gender { get; set; }
        public string Locale { get; set; }
        public string Timezone { get; set; }
        public string UpdatedTime { get; set; }
        public string Verified { get; set; }

        public override User User { get; set; }

        public override string ToString()
        {
            return string.Format("ID {10} \nName: {0} \nFirstName: {1} \nLastName {2} \nAgeRange: {3} \nLink: {4} \nGender: {5} \nLocale: {6} \nTimezone: {7} \nUpdatedTime: {8} \nVerified: {9}", Name, FirstName, LastName, AgeRange, Link, Gender, Locale, Timezone, UpdatedTime, Verified, ID);
        }
    }
}
