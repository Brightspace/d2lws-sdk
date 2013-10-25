namespace D2L.WS.Client.Stubs.Connection {
	public class UserCredentialHolder : IUserCredentialSource {
		public string Username {
			get { return m_username; }
		}

		public string Password {
			get { return m_password; }
		}

		private string m_username;
		private string m_password;

		public UserCredentialHolder( string username, string password ) {
			m_username = username;
			m_password = password;
		}
	}
}
