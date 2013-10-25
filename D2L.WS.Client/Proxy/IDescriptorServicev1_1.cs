using System;

namespace D2L.WS.Client.Proxy {
	public interface IDescriptorServicev1_1 : IHeaderService {
		IAsyncResult BeginGetOrganizationId( GetOrganizationIdRequest GetOrganizationIdRequest, AsyncCallback callback, object asyncState );
		void CancelAsync( object userState );
		GetOrganizationIdResponse EndGetOrganizationId( IAsyncResult asyncResult );
		GetOrganizationIdResponse GetOrganizationId( GetOrganizationIdRequest GetOrganizationIdRequest );
		void GetOrganizationIdAsync( GetOrganizationIdRequest GetOrganizationIdRequest );
		void GetOrganizationIdAsync( GetOrganizationIdRequest GetOrganizationIdRequest, object userState );
		event GetOrganizationIdCompletedEventHandler GetOrganizationIdCompleted;
	}
}
