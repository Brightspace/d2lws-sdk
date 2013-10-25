using System;
using System.Configuration;

using D2L.WS.Client.Proxy;

namespace D2L.WS.Client.Stubs.Connection {
	public enum AuthenticationStrategyType {
		Optimistic,
		Conservative,
		Reauthenticating,
		SettingsBased
	}

	public class WebServiceConnectionBuilder {
		private string m_authServiceUrl;
		private string m_authTokenType = "Web Service";
		private IUserCredentialSource m_credSource;
		private AuthenticationStrategyType m_authStrategyType = AuthenticationStrategyType.Reauthenticating;

		public WebServiceConnectionBuilder WithAuthenticationServiceUrl( string url ) {
			m_authServiceUrl = url;
			return this;
		}

		public WebServiceConnectionBuilder WithUserCredentials( IUserCredentialSource source ) {
			m_credSource = source;
			return this;
		}

		public WebServiceConnectionBuilder WithUserCredentials( string username, string password ) {
			m_credSource = new UserCredentialHolder( username, password );
			return this;
		}

		public WebServiceConnectionBuilder WithAuthenticationStrategy( AuthenticationStrategyType type ) {
			m_authStrategyType = type;
			return this;
		}

		public WebServiceConnectionBuilder WithAuthenticationTokenType( string tokenType ) {
			m_authTokenType = tokenType;
			return this;
		}

		public IWebServiceConnection Build() {
			IAuthenticationTokenService authService = new AuthenticationTokenService() {
				Url = AuthenticationServiceUrl
			};
			AuthenticationStrategy strategy;
			switch( m_authStrategyType ) {
				case AuthenticationStrategyType.Conservative:
					strategy = new ConservativeStrategy( authService, CredentialSource, m_authTokenType );
					break;
				case AuthenticationStrategyType.SettingsBased:
					strategy = new SettingsBasedStrategy( authService, CredentialSource, m_authTokenType );
					break;
				case AuthenticationStrategyType.Optimistic:
					strategy = new OptimisticStrategy( authService, CredentialSource, m_authTokenType );
					break;
				case AuthenticationStrategyType.Reauthenticating:
					strategy = new ReauthenticatingStrategy( authService, CredentialSource, m_authTokenType );
					break;
				default:
					strategy = new ReauthenticatingStrategy( authService, CredentialSource, m_authTokenType );
					break;
			}
			return strategy;
		}

		private string AuthenticationServiceUrl {
			get {
				if( String.IsNullOrEmpty( m_authServiceUrl ) ) {
					return ConfigurationManager.AppSettings[ "AuthenticationServiceUrl" ];
				} else {
					return m_authServiceUrl;
				}
			}
		}

		private IUserCredentialSource CredentialSource {
			get {
				if( m_credSource == null ) {
					return new ConfigurationFileUserCredentialSource();
				} else {
					return m_credSource;
				}
			}
		}
	}
}
