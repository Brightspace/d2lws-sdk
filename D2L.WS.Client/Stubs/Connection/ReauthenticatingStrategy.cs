using System;
using System.Web.Services.Protocols;

using D2L.WS.Client.Proxy;

namespace D2L.WS.Client.Stubs.Connection {
	internal class ReauthenticatingStrategy : AuthenticationStrategy {
		public ReauthenticatingStrategy(
			IAuthenticationTokenService authService,
			IUserCredentialSource credentialSource,
			string authTokenType )
			: base( authService, credentialSource, authTokenType ) {
		}

		public override R Invoke<S, Q, R>( S service, Q request, Func<S, Q, R> invokeWebMethod ) {
			EnsureAuthenticationToken<S>( service );
			try {
				return invokeWebMethod( service, request );
			} catch( SoapException ex ) {
				if( ExceptionIsBecauseOfTokenExpiration( ex ) ) {
					service.RequestHeader.AuthenticationToken = Authenticate();
					return invokeWebMethod( service, request );
				}
				throw;
			}
		}
		
		private bool ExceptionIsBecauseOfTokenExpiration( SoapException ex ) {
			return ex.Message.Contains( ExpiredTokenMarker );
		}

		private const string ExpiredTokenMarker = "D2L.WS.Security.Authentication.AuthenticationException: Expired authentication token";
	}
}
