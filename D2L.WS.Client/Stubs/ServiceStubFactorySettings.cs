using System.Configuration;
using System;

namespace D2L.WS.Client.Stubs {
	public class ServiceStubFactorySettings {
		private static string AUTHENTICATION_SERVICE_URL_SETTING = "AuthenticationServiceUrl";
		private static string D2LWS_BASE_URL_SETTING = "d2lwsBaseUrl";
		private static string TIMEOUT_SETTING = "WebServiceTimeout";

		public string AuthenticationServiceUrl { get; set; }
		public string BaseFunctionalServiceUrl { get; set; }
		public int Timeout { get; set; }

		public static ServiceStubFactorySettings Default {
			get {
				return new ServiceStubFactorySettings() {
					AuthenticationServiceUrl =
						ConfigurationManager.AppSettings[ AUTHENTICATION_SERVICE_URL_SETTING ],
					BaseFunctionalServiceUrl = ConfigurationManager.AppSettings[ D2LWS_BASE_URL_SETTING ],
					Timeout = GetTimeout()
				};
			}
		}

		private static int GetTimeout() {
			string setting = ConfigurationManager.AppSettings[ TIMEOUT_SETTING ];
			if( !String.IsNullOrEmpty( setting ) ) {
				int result;
				if( Int32.TryParse( setting, out result ) ) {
					return result;
				}
			}
			return 60 * 1000;
		}
	}
}
