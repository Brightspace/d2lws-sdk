
namespace D2L.Lms.WS.ServiceStub.Proxy {
	public interface IAppTokenService {
		string GetAppToken( string devKey );
		bool VerifyAppToken( string appToken, string instanceCode, long orgId );
	}
}
