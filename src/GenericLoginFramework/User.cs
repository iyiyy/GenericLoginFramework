using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        public string Username { get; set; }
		public byte[] Password
        {
            get;
            private set;
        }
		#endregion

		#region Methods       
		public User()
		{
			this.ID = Guid.NewGuid();
			this.Resources = new List<Resource>();
        }

        public void SetPassword(string password)
        {
            Password = GLF.Hash(password, ID.ToByteArray());
        }
        #endregion
    }
}
