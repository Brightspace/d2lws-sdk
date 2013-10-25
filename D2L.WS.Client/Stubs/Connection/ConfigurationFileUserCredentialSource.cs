using System.Configuration;

namespace D2L.WS.Client.Stubs.Connection {
	public class ConfigurationFileUserCredentialSource :IUserCredentialSource {
		public string Username {
			get { return ConfigurationManager.AppSettings[ "D2LUserName" ]; }
		}

		public string Password {
			get { return ConfigurationManager.AppSettings[ "D2LPassword" ]; }
		}
	}
}
