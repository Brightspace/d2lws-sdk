using System;

namespace D2L.WS.Client.Proxy {
	public interface IUserManagementServicev1_4 : IHeaderService {
		IAsyncResult BeginCreateAuditorRelationship( CreateAuditorRelationshipRequest CreateAuditorRelationshipRequest, AsyncCallback callback, object asyncState );
		IAsyncResult BeginGetAuditees( GetAuditeesRequest GetAuditeesRequest, AsyncCallback callback, object asyncState );
		IAsyncResult BeginGetAuditors( GetAuditorsRequest GetAuditorsRequest, AsyncCallback callback, object asyncState );
		IAsyncResult BeginRemoveAuditorRelationship( RemoveAuditorRelationshipRequest RemoveAuditorRelationshipRequest, AsyncCallback callback, object asyncState );
		void CancelAsync( object userState );
		CreateAuditorRelationshipResponse CreateAuditorRelationship( CreateAuditorRelationshipRequest CreateAuditorRelationshipRequest );
		void CreateAuditorRelationshipAsync( CreateAuditorRelationshipRequest CreateAuditorRelationshipRequest, object userState );
		void CreateAuditorRelationshipAsync( CreateAuditorRelationshipRequest CreateAuditorRelationshipRequest );
		event CreateAuditorRelationshipCompletedEventHandler CreateAuditorRelationshipCompleted;
		CreateAuditorRelationshipResponse EndCreateAuditorRelationship( IAsyncResult asyncResult );
		GetAuditeesResponse EndGetAuditees( IAsyncResult asyncResult );
		GetAuditorsResponse EndGetAuditors( IAsyncResult asyncResult );
		RemoveAuditorRelationshipResponse EndRemoveAuditorRelationship( IAsyncResult asyncResult );
		GetAuditeesResponse GetAuditees( GetAuditeesRequest GetAuditeesRequest );
		void GetAuditeesAsync( GetAuditeesRequest GetAuditeesRequest );
		void GetAuditeesAsync( GetAuditeesRequest GetAuditeesRequest, object userState );
		event GetAuditeesCompletedEventHandler GetAuditeesCompleted;
		GetAuditorsResponse GetAuditors( GetAuditorsRequest GetAuditorsRequest );
		void GetAuditorsAsync( GetAuditorsRequest GetAuditorsRequest, object userState );
		void GetAuditorsAsync( GetAuditorsRequest GetAuditorsRequest );
		event GetAuditorsCompletedEventHandler GetAuditorsCompleted;
		RemoveAuditorRelationshipResponse RemoveAuditorRelationship( RemoveAuditorRelationshipRequest RemoveAuditorRelationshipRequest );
		void RemoveAuditorRelationshipAsync( RemoveAuditorRelationshipRequest RemoveAuditorRelationshipRequest );
		void RemoveAuditorRelationshipAsync( RemoveAuditorRelationshipRequest RemoveAuditorRelationshipRequest, object userState );
		event RemoveAuditorRelationshipCompletedEventHandler RemoveAuditorRelationshipCompleted;
	}
}
