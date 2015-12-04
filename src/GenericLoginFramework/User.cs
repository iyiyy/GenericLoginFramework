using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLoginFramework
{
	public partial class User
	{
		#region Properties
		public Guid ID { get; private set; }
        public List<Resource> Resources { get; private set; }
        public bool Verified { get; set; }
        //public string Username { get; set; }
		//public string Password { get; set; }
		#endregion

		#region Methods       
		public User()
		{
			this.ID = Guid.NewGuid();
			this.Resources = new List<Resource>();
        }
		#endregion
	}
}
