using System;

namespace D2L.WS.Client.Proxy {
	public interface IUserManagementServicev1_6 : IHeaderService {
		IAsyncResult BeginGetPermittedTasksByUserOrgUnit( GetPermittedTasksByUserOrgUnitRequest GetPermittedTasksByUserOrgUnitRequest, AsyncCallback callback, object asyncState );
		IAsyncResult BeginGetProfileByUser( GetProfileByUserRequest GetProfileByUserRequest, AsyncCallback callback, object asyncState );
		IAsyncResult BeginGetProfilePicture( GetProfilePictureRequest GetProfilePictureRequest, AsyncCallback callback, object asyncState );
		IAsyncResult BeginGetUsersByCourseOfferingsIndex( GetUsersByCourseOfferingsIndexRequest GetUsersByCourseOfferingsIndexRequest, AsyncCallback callback, object asyncState );
		IAsyncResult BeginGetUsersByGroup( GetUsersByGroupRequest GetUsersByGroupRequest, AsyncCallback callback, object asyncState );
		IAsyncResult BeginGetUsersBySection( GetUsersBySectionRequest GetUsersBySectionRequest, AsyncCallback callback, object asyncState );
		IAsyncResult BeginUpdateProfile( UpdateProfileRequest UpdateProfileRequest, AsyncCallback callback, object asyncState );
		void CancelAsync( object userState );
		GetPermittedTasksByUserOrgUnitResponse EndGetPermittedTasksByUserOrgUnit( IAsyncResult asyncResult );
		GetProfileByUserResponse EndGetProfileByUser( IAsyncResult asyncResult );
		GetProfilePictureResponse EndGetProfilePicture( IAsyncResult asyncResult );
		GetUsersByCourseOfferingsIndexResponse EndGetUsersByCourseOfferingsIndex( IAsyncResult asyncResult );
		GetUsersByGroupResponse EndGetUsersByGroup( IAsyncResult asyncResult );
		GetUsersBySectionResponse EndGetUsersBySection( IAsyncResult asyncResult );
		UpdateProfileResponse EndUpdateProfile( IAsyncResult asyncResult );
		GetPermittedTasksByUserOrgUnitResponse GetPermittedTasksByUserOrgUnit( GetPermittedTasksByUserOrgUnitRequest GetPermittedTasksByUserOrgUnitRequest );
		void GetPermittedTasksByUserOrgUnitAsync( GetPermittedTasksByUserOrgUnitRequest GetPermittedTasksByUserOrgUnitRequest );
		void GetPermittedTasksByUserOrgUnitAsync( GetPermittedTasksByUserOrgUnitRequest GetPermittedTasksByUserOrgUnitRequest, object userState );
		event GetPermittedTasksByUserOrgUnitCompletedEventHandler GetPermittedTasksByUserOrgUnitCompleted;
		GetProfileByUserResponse GetProfileByUser( GetProfileByUserRequest GetProfileByUserRequest );
		void GetProfileByUserAsync( GetProfileByUserRequest GetProfileByUserRequest, object userState );
		void GetProfileByUserAsync( GetProfileByUserRequest GetProfileByUserRequest );
		event GetProfileByUserCompletedEventHandler GetProfileByUserCompleted;
		GetProfilePictureResponse GetProfilePicture( GetProfilePictureRequest GetProfilePictureRequest );
		void GetProfilePictureAsync( GetProfilePictureRequest GetProfilePictureRequest, object userState );
		void GetProfilePictureAsync( GetProfilePictureRequest GetProfilePictureRequest );
		event GetProfilePictureCompletedEventHandler GetProfilePictureCompleted;
		GetUsersByCourseOfferingsIndexResponse GetUsersByCourseOfferingsIndex( GetUsersByCourseOfferingsIndexRequest GetUsersByCourseOfferingsIndexRequest );
		void GetUsersByCourseOfferingsIndexAsync( GetUsersByCourseOfferingsIndexRequest GetUsersByCourseOfferingsIndexRequest );
		void GetUsersByCourseOfferingsIndexAsync( GetUsersByCourseOfferingsIndexRequest GetUsersByCourseOfferingsIndexRequest, object userState );
		event GetUsersByCourseOfferingsIndexCompletedEventHandler GetUsersByCourseOfferingsIndexCompleted;
		GetUsersByGroupResponse GetUsersByGroup( GetUsersByGroupRequest GetUsersByGroupRequest );
		void GetUsersByGroupAsync( GetUsersByGroupRequest GetUsersByGroupRequest, object userState );
		void GetUsersByGroupAsync( GetUsersByGroupRequest GetUsersByGroupRequest );
		event GetUsersByGroupCompletedEventHandler GetUsersByGroupCompleted;
		GetUsersBySectionResponse GetUsersBySection( GetUsersBySectionRequest GetUsersBySectionRequest );
		void GetUsersBySectionAsync( GetUsersBySectionRequest GetUsersBySectionRequest, object userState );
		void GetUsersBySectionAsync( GetUsersBySectionRequest GetUsersBySectionRequest );
		event GetUsersBySectionCompletedEventHandler GetUsersBySectionCompleted;
		UpdateProfileResponse UpdateProfile( UpdateProfileRequest UpdateProfileRequest );
		void UpdateProfileAsync( UpdateProfileRequest UpdateProfileRequest );
		void UpdateProfileAsync( UpdateProfileRequest UpdateProfileRequest, object userState );
		event UpdateProfileCompletedEventHandler UpdateProfileCompleted;
	}
}
