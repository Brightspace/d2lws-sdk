using System;

using D2L.WS.Client.Proxy;

namespace D2L.WS.Client.Stubs {
	public class AuthenticationServiceStub : IDisposable {
		private IAuthenticationTokenService m_service;

		internal AuthenticationServiceStub( IAuthenticationTokenService service ) {
			m_service = service;
		}

		public string GetAuthenticationToken( string username, string password, string purpose ) {
			AuthenticateRequest request = new AuthenticateRequest() {
				username = username,
				password = password,
				purpose = purpose
			};
			AuthenticateResponse response = m_service.Authenticate( request );
			if( null == response ) {
				throw new ResponseValidationException( "token authentication request failed" );
			}
			return response.token;
		}
		
		public void Dispose() {
			m_service.Dispose();
		}
	}
}
