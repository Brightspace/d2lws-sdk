using System;

namespace D2L.WS.Client.Proxy {
	public interface IHeaderService : IDisposable {
		RequestHeaderInfo RequestHeader { get; set; }
		ResponseHeaderInfo ResponseHeader { get; set; }
	}
}
