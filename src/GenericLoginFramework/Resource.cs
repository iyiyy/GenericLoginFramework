using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework
{
	public class Resource
	{
		#region Properties
		public string ID { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Age { get; set; }
		public string Email { get; set; }
		public string Type { get; set; }
        public User User { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return String.Format("ID: {0}\nName: {1}\nLastname: {2}\nAge: {3}\nEmail: {4}\nType: {5}", ID, Name, LastName, Age, Email, Type);
        }
        #endregion
    }
}
