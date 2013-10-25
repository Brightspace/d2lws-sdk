using System;

namespace D2L.WS.Client.Proxy {
	public interface IUserManagementServicev1_5 : IHeaderService {
		SetUserActivationStatusResponse ActivateUsers( ActivateUsersRequest ActivateUsersRequest );
		void ActivateUsersAsync( ActivateUsersRequest ActivateUsersRequest, object userState );
		void ActivateUsersAsync( ActivateUsersRequest ActivateUsersRequest );
		event ActivateUsersCompletedEventHandler ActivateUsersCompleted;
		IAsyncResult BeginActivateUsers( ActivateUsersRequest ActivateUsersRequest, AsyncCallback callback, object asyncState );
		IAsyncResult BeginDeactivateUsers( DeactivateUsersRequest DeactivateUsersRequest, AsyncCallback callback, object asyncState );
		IAsyncResult BeginGetUserActivationStatus( GetUserActivationStatusRequest GetUserActivationStatusRequest, AsyncCallback callback, object asyncState );
		void CancelAsync( object userState );
		SetUserActivationStatusResponse DeactivateUsers( DeactivateUsersRequest DeactivateUsersRequest );
		void DeactivateUsersAsync( DeactivateUsersRequest DeactivateUsersRequest );
		void DeactivateUsersAsync( DeactivateUsersRequest DeactivateUsersRequest, object userState );
		event DeactivateUsersCompletedEventHandler DeactivateUsersCompleted;
		SetUserActivationStatusResponse EndActivateUsers( IAsyncResult asyncResult );
		SetUserActivationStatusResponse EndDeactivateUsers( IAsyncResult asyncResult );
		GetUserActivationStatusResponse EndGetUserActivationStatus( IAsyncResult asyncResult );
		GetUserActivationStatusResponse GetUserActivationStatus( GetUserActivationStatusRequest GetUserActivationStatusRequest );
		void GetUserActivationStatusAsync( GetUserActivationStatusRequest GetUserActivationStatusRequest );
		void GetUserActivationStatusAsync( GetUserActivationStatusRequest GetUserActivationStatusRequest, object userState );
		event GetUserActivationStatusCompletedEventHandler GetUserActivationStatusCompleted;
	}
}
