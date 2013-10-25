using System;

namespace D2L.WS.Client.Proxy {
	public interface IAuthenticationTokenService : IDisposable {
		AuthenticateResponse Authenticate( AuthenticateRequest AuthenticateRequest );
	}
}
