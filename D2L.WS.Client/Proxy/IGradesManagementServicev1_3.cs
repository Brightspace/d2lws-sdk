using System;

namespace D2L.WS.Client.Proxy {
	public interface IGradesManagementServicev1_3 : IHeaderService {
		IAsyncResult BeginSetMultipleNumericGradeValues( SetMultipleNumericGradeValuesRequest SetMultipleNumericGradeValuesRequest, AsyncCallback callback, object asyncState );
		void CancelAsync( object userState );
		SetGradeValueResponse EndSetMultipleNumericGradeValues( IAsyncResult asyncResult );
		SetGradeValueResponse SetMultipleNumericGradeValues( SetMultipleNumericGradeValuesRequest SetMultipleNumericGradeValuesRequest );
		void SetMultipleNumericGradeValuesAsync( SetMultipleNumericGradeValuesRequest SetMultipleNumericGradeValuesRequest, object userState );
		void SetMultipleNumericGradeValuesAsync( SetMultipleNumericGradeValuesRequest SetMultipleNumericGradeValuesRequest );
		event SetMultipleNumericGradeValuesCompletedEventHandler SetMultipleNumericGradeValuesCompleted;
	}
}
