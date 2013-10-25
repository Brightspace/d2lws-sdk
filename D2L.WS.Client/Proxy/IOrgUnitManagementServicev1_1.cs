using System;

namespace D2L.WS.Client.Proxy {
	public interface IOrgUnitManagementServicev1_1 : IHeaderService {
		IAsyncResult BeginGetChildOrgUnits( GetChildOrgUnitsRequest GetChildOrgUnitsRequest, AsyncCallback callback, object asyncState );
		void CancelAsync( object userState );
		GetChildOrgUnitsResponse EndGetChildOrgUnits( IAsyncResult asyncResult );
		GetChildOrgUnitsResponse GetChildOrgUnits( GetChildOrgUnitsRequest GetChildOrgUnitsRequest );
		void GetChildOrgUnitsAsync( GetChildOrgUnitsRequest GetChildOrgUnitsRequest );
		void GetChildOrgUnitsAsync( GetChildOrgUnitsRequest GetChildOrgUnitsRequest, object userState );
		event GetChildOrgUnitsCompletedEventHandler GetChildOrgUnitsCompleted;
	}
}
