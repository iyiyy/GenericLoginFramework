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
        private byte[] _password = new Byte[0];

		#region Properties
		public Guid ID { get; private set; }
        public List<Resource> Resources { get; private set; }
        public bool Verified { get; set; }
        public string Username { get; set; }
		public byte[] Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = GLF.Hash(value, ID.ToByteArray());
            }
        }
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
