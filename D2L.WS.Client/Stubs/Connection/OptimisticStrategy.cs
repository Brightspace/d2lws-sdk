using System;

using D2L.WS.Client.Proxy;

namespace D2L.WS.Client.Stubs.Connection {
	internal class OptimisticStrategy : AuthenticationStrategy {
		public OptimisticStrategy(
			IAuthenticationTokenService authService,
			IUserCredentialSource credentialSource,
			string authTokenType )
			: base( authService, credentialSource, authTokenType ) {
		}

		public override R Invoke<S, Q, R>( S service, Q request, Func<S, Q, R> invokeWebMethod ) {
			EnsureAuthenticationToken<S>( service );
			return invokeWebMethod( service, request );
		}
	}
}
