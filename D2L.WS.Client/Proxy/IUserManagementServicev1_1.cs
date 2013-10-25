using System;

namespace D2L.WS.Client.Proxy {
	public interface IUserManagementServicev1_1 : IHeaderService {
		IAsyncResult BeginGetUsersByOrgUnitRole( GetUsersByOrgUnitRoleRequest GetUsersByOrgUnitRoleRequest, AsyncCallback callback, object asyncState );
		void CancelAsync( object userState );
		GetUsersByOrgUnitRoleResponse EndGetUsersByOrgUnitRole( IAsyncResult asyncResult );
		GetUsersByOrgUnitRoleResponse GetUsersByOrgUnitRole( GetUsersByOrgUnitRoleRequest GetUsersByOrgUnitRoleRequest );
		void GetUsersByOrgUnitRoleAsync( GetUsersByOrgUnitRoleRequest GetUsersByOrgUnitRoleRequest );
		void GetUsersByOrgUnitRoleAsync( GetUsersByOrgUnitRoleRequest GetUsersByOrgUnitRoleRequest, object userState );
		event GetUsersByOrgUnitRoleCompletedEventHandler GetUsersByOrgUnitRoleCompleted;
	}
}
