using System;

namespace D2L.WS.SampleApp {
	[Serializable]
	public class User {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string OrgDefinedId { get; set; }
	}
}
