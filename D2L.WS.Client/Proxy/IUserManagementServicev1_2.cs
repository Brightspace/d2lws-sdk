using System;

namespace D2L.WS.Client.Proxy {
	public interface IUserManagementServicev1_2 : IHeaderService {
		IAsyncResult BeginGetActiveCourseOfferings( GetActiveCourseOfferingsRequest GetActiveCourseOfferingsRequest, AsyncCallback callback, object asyncState );
		void CancelAsync( object userState );
		GetActiveCourseOfferingsResponse EndGetActiveCourseOfferings( IAsyncResult asyncResult );
		GetActiveCourseOfferingsResponse GetActiveCourseOfferings( GetActiveCourseOfferingsRequest GetActiveCourseOfferingsRequest );
		void GetActiveCourseOfferingsAsync( GetActiveCourseOfferingsRequest GetActiveCourseOfferingsRequest );
		void GetActiveCourseOfferingsAsync( GetActiveCourseOfferingsRequest GetActiveCourseOfferingsRequest, object userState );
		event GetActiveCourseOfferingsCompletedEventHandler GetActiveCourseOfferingsCompleted;
	}
}
