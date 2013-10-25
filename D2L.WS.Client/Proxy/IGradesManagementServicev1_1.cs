using System;

namespace D2L.WS.Client.Proxy {
	public interface IGradesManagementServicev1_1 : IHeaderService {
		IAsyncResult BeginGetFinalGradeValuesByUser( GetFinalGradeValuesByUserRequest GetFinalGradeValuesByUserRequest, AsyncCallback callback, object asyncState );
		void CancelAsync( object userState );
		GetFinalGradeValuesByUserResponse EndGetFinalGradeValuesByUser( IAsyncResult asyncResult );
		GetFinalGradeValuesByUserResponse GetFinalGradeValuesByUser( GetFinalGradeValuesByUserRequest GetFinalGradeValuesByUserRequest );
		void GetFinalGradeValuesByUserAsync( GetFinalGradeValuesByUserRequest GetFinalGradeValuesByUserRequest );
		void GetFinalGradeValuesByUserAsync( GetFinalGradeValuesByUserRequest GetFinalGradeValuesByUserRequest, object userState );
		event GetFinalGradeValuesByUserCompletedEventHandler GetFinalGradeValuesByUserCompleted;
	}
}
