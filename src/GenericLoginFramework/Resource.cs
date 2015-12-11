using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GenericLoginFramework
{
	public class Resource
	{
		#region Properties
        [Key]
		public string ID { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Age { get; set; }
		public string Email { get; set; }
		public string Type { get; set; }
        public User User { get; set; }
        #endregion
    }
}
