using System;

using D2L.WS.Client.Proxy;

namespace D2L.WS.Client.Stubs.Connection {
	internal class ConservativeStrategy : AuthenticationStrategy {
		public ConservativeStrategy(
			IAuthenticationTokenService authService,
			IUserCredentialSource credentialSource,
			string authTokenType )
			: base( authService, credentialSource, authTokenType ) {
		}

		public override R Invoke<S, Q, R>( S service, Q request, Func<S, Q, R> invokeWebMethod ) {
			service.RequestHeader.AuthenticationToken = Authenticate();
			return invokeWebMethod( service, request );
		}
	}
}
