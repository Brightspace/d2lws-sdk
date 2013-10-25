using System;

using D2L.WS.Client.Proxy;

namespace D2L.WS.Client.Stubs.Connection {
	internal class WebServiceConnection : IWebServiceConnection {
		public virtual R Invoke<S, Q, R>( S service, Q request, Func<S, Q, R> invokeWebMethod )
			where S : IHeaderService
			where Q : class 
			where R : ResponseBase {

			return invokeWebMethod( service, request );
		}
	}
}
