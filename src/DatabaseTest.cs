using GenericLoginFramework.Database;

namespace GenericLoginFramework
{
    class DatabaseTest
    {
        static void Main(string[] args)
        {
            testGenericLoginFrameworkDbContext();

            System.Console.WriteLine("testing done, press any key to exit...");
            System.Console.ReadKey();
        }

        private static void testGenericLoginFrameworkDbContext()
        {
            System.Console.WriteLine("Testing database creation");

            using (GLFDbContext db = new GLFDbContext("shit", false))
            {
                //db.Users.Add(new User { ID = "glfUser" });
                //db.FacebookResources.Add(new OAuth.Resources.FacebookResource { ID = "GlfFbUser", UserID = "glfUser" });
                //db.GoogleResources.Add(new OpenID.Resources.GoogleResource { ID = "GlfGUser", UserID = "glfUser" });
                //db.SaveChanges();
            }
        }
    }
}
