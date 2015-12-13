using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericLoginFramework;
using GenericLoginFramework.Providers;
using System.Data.Entity;

namespace GLFTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GLF glf = GLF.Instance;

            glf.InitializeDB("WPFTest");
            FacebookProvider.Instance.Enable("624408054367639", "3ee73a2a0c243edff171618669a7b1a3");
            Console.WriteLine(FacebookProvider.Instance.AppID);
            Console.WriteLine(FacebookProvider.Instance.AppSecret);
            Console.WriteLine(FacebookProvider.Instance.Enabled);
            Console.WriteLine(FacebookProvider.Instance.FullyQualifiedLoginEndpoint());
            Console.WriteLine(FacebookProvider.Instance.LoginEndpoint);
            Console.WriteLine(FacebookProvider.Instance.RedirectURI);
            Console.WriteLine(FacebookProvider.Instance.ResourceEndpoint);
            Console.WriteLine(FacebookProvider.Instance.ResponseType);
            Console.WriteLine(FacebookProvider.Instance.Scope);
            Console.WriteLine(FacebookProvider.Instance.State);
            Console.WriteLine(FacebookProvider.Instance.UsedFlow);
            Console.WriteLine("DB was initialized.\n");
            Console.WriteLine("---------------------------------------------------------------------------");

            User user;
            using (GLFDbContext db = new GLFDbContext(glf.DBName, glf.DBIsConnName))
            {
                Resource res = db.Resources.Where(r => r.Name == "Kalle").Include(r => r.User).FirstOrDefault();
                user = res.User;
            }

            Resource newRes = new Resource
            {
                Age = "24",
                ID = Guid.NewGuid().ToString(),
                Email = "test@email.com",
                Name = "Kalle",
                LastName = "Pedersen",
                Type = "TEST",
                User = user
            };

            glf.AddResourceToExistingUser(user, newRes);
            Console.WriteLine("Resource was added to user.\n");
            Console.WriteLine("---------------------------------------------------------------------------");


            using (GLFDbContext db = new GLFDbContext(glf.DBName, glf.DBIsConnName))
            {
                Resource res = db.Resources.Where(r => r.Name == "Kalle").Include(r => r.User).FirstOrDefault();
                user = res.User;
                
                user.Username = "testbruger";
                user.SetPassword("password1234");

                db.Users.Attach(user);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                Console.WriteLine(BitConverter.ToString(user.Password));
                Console.WriteLine(BitConverter.ToString(GLF.Hash("password1234", user.ID.ToByteArray())));
            }

            User genuser;
            genuser = glf.LoginWithGeneric("bruger", "password");
            Console.WriteLine(String.Format("User with username: {0} and password: {1} exists? {2}", "bruger", "password", genuser != null));
            genuser = glf.LoginWithGeneric("testbruger", "password");
            Console.WriteLine(String.Format("User with username: {0} and password: {1} exists? {2}", "testbruger", "password", genuser != null));
            genuser = glf.LoginWithGeneric("bruger", "password1234");
            Console.WriteLine(String.Format("User with username: {0} and password: {1} exists? {2}", "bruger", "password1234", genuser != null));
            genuser = glf.LoginWithGeneric("testbruger", "password1234");
            Console.WriteLine(String.Format("User with username: {0} and password: {1} exists? {2}", "testbruger", "password1234", genuser != null));
            Console.WriteLine("Generic login was tested.\n");
            Console.WriteLine("---------------------------------------------------------------------------");



            string username = "tempusercontext";
            using (GLFDbContext db = new GLFDbContext(glf.DBName, glf.DBIsConnName))
            {
                User deluser = db.Users.Where(u => u.Username == username).FirstOrDefault();

                if (deluser != null)
                    db.Users.Remove(deluser);

                db.SaveChanges();
            }

            User tempuser = new User();
            tempuser.Username = username;
            glf.AddUserToContext(tempuser);

            Resource newcontextres = new Resource
            {
                Age = "24",
                ID = Guid.NewGuid().ToString(),
                Email = "test@email.com",
                Name = "Kalle",
                LastName = "Pedersen",
                Type = "TEST",
                User = user
            };

            glf.AddResourceToExistingUser(tempuser, newcontextres);

            string usernamewithres = "tempusercontextwithress";
            using (GLFDbContext db = new GLFDbContext(glf.DBName, glf.DBIsConnName))
            {
                User deluser = db.Users.Where(u => u.Username == usernamewithres).FirstOrDefault();

                if (deluser != null)
                    db.Users.Remove(deluser);

                db.SaveChanges();
            }

            User tempuserwithres = new User();
            tempuserwithres.Username = usernamewithres;

            Resource newcontextreswithres = new Resource
            {
                Age = "24",
                ID = Guid.NewGuid().ToString(),
                Email = "test@email.com",
                Name = "newusertest",
                LastName = "Pedersen",
                Type = "TEST"
            };
            tempuserwithres.Resources.Add(newcontextreswithres);
            glf.AddUserToContext(tempuserwithres);


            Console.ReadKey();
        }
    }
}

