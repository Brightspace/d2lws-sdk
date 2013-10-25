using System;

using D2L.WS.Client.Proxy;

namespace D2L.WS.Client.Stubs.Connection {
	internal abstract class AuthenticationStrategy : WebServiceConnection {
		private IAuthenticationTokenService m_authService;
		private IUserCredentialSource m_credentialSource;
		private string m_authTokenType;
		private string m_token;

		protected AuthenticationStrategy(
			IAuthenticationTokenService authService,
			IUserCredentialSource credentialSource,
			string authTokenType ) {

			m_authService = authService;
			m_credentialSource = credentialSource;
			m_authTokenType = authTokenType;
		}
		
		protected IAuthenticationTokenService AuthenticatonService {
			get { return m_authService; }
		}

		protected virtual string Authenticate() {
			AuthenticateRequest request = CreateAuthenticationRequest();
			AuthenticateResponse response = m_authService.Authenticate( request );
			return response.token;
		}

		protected AuthenticateRequest CreateAuthenticationRequest() {
			return new AuthenticateRequest() {
				username = m_credentialSource.Username,
				password = m_credentialSource.Password,
				purpose = m_authTokenType
			};
		}

		protected void EnsureAuthenticationToken<S>( S service ) where S : IHeaderService {
			if( String.IsNullOrEmpty( m_token ) ) {
				m_token = Authenticate();
			}
			service.RequestHeader.AuthenticationToken = m_token;
		}
	}
}
