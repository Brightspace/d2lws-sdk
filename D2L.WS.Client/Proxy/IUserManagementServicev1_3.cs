using System;

namespace D2L.WS.Client.Proxy {
	public interface IUserManagementServicev1_3 : IHeaderService {
		IAsyncResult BeginGetActiveCourseOfferingsEx( GetActiveCourseOfferingsExRequest GetActiveCourseOfferingsExRequest, AsyncCallback callback, object asyncState );
		void CancelAsync( object userState );
		GetActiveCourseOfferingsExResponse EndGetActiveCourseOfferingsEx( IAsyncResult asyncResult );
		GetActiveCourseOfferingsExResponse GetActiveCourseOfferingsEx( GetActiveCourseOfferingsExRequest GetActiveCourseOfferingsExRequest );
		void GetActiveCourseOfferingsExAsync( GetActiveCourseOfferingsExRequest GetActiveCourseOfferingsExRequest );
		void GetActiveCourseOfferingsExAsync( GetActiveCourseOfferingsExRequest GetActiveCourseOfferingsExRequest, object userState );
		event GetActiveCourseOfferingsExCompletedEventHandler GetActiveCourseOfferingsExCompleted;
	}
}
