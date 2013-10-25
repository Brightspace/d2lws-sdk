using System;

using D2L.WS.Client.Proxy;

namespace D2L.WS.Client.Stubs.Connection {
	internal class SettingsBasedStrategy : AuthenticationStrategy {
		public SettingsBasedStrategy(
			IAuthenticationTokenService authService,
			IUserCredentialSource credentialSource,
			string authTokenType )
			: base( authService, credentialSource, authTokenType ) {
		}

		public override R Invoke<S, Q, R>( S service, Q request, Func<S, Q, R> invokeWebMethod ) {
			EnsureAuthenticationToken<S>( service );
			if( m_usageCounter >= m_maxUsageCount ) {
				service.RequestHeader.AuthenticationToken = Authenticate();
			}
			m_usageCounter++;
			return invokeWebMethod( service, request );
		}

		protected override string Authenticate() {
			AuthenticateRequest request = CreateAuthenticationRequest();
			AuthenticateResponse response = AuthenticatonService.Authenticate( request );
			m_maxUsageCount = GetMaxUsageCount( response.tokenSettings );
			m_usageCounter = 0;
			return response.token;
		}

		private int GetMaxUsageCount( AuthenticationTokenSettings settings ) {
			if( settings != null ) {
				return settings.maxUsageCount;
			} else {
				return 1;
			}
		}

		private int m_maxUsageCount;
		private int m_usageCounter;
	}
}
