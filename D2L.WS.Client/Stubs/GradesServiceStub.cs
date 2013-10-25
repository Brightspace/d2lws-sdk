using System;

using D2L.WS.Client.Proxy;

namespace D2L.WS.Client.Stubs {
	public class GradesServiceStub : ServiceStubBase {
		private IGradesManagementServicev1_0 m_service1_0;
		private IGradesManagementServicev1_1 m_service1_1;
		private IGradesManagementServicev1_2 m_service1_2;
		private IGradesManagementServicev1_3 m_service1_3;

		internal GradesServiceStub(
			IGradesManagementServicev1_0 service1_0,
			IGradesManagementServicev1_1 service1_1,
			IGradesManagementServicev1_2 service1_2,
			IGradesManagementServicev1_3 service1_3 ) {

			m_service1_0 = service1_0;
			m_service1_1 = service1_1;
			m_service1_2 = service1_2;
			m_service1_3 = service1_3;
		}

		protected override void Dispose( bool disposing ) {
			if( !m_disposed ) {
				if( disposing ) {
					m_service1_0.Dispose();
					m_service1_1.Dispose();
					m_service1_2.Dispose();
					m_service1_3.Dispose();
				}
				m_disposed = true;
			}
		}

		public void RecalculateFinalCalculatedGrade( Identifier orgUnitId ) {
			RecalculateCalculatedFinalGradeRequest request = new RecalculateCalculatedFinalGradeRequest() {
				OrgUnitId = orgUnitId
			};
			CallWebService<IGradesManagementServicev1_0,
				RecalculateCalculatedFinalGradeRequest, RecalculateCalculatedFinalGradeResponse>(
				m_service1_0, request, ( s, q ) => s.RecalculateCalculatedFinalGrade( q ) );
		}

		public TextGradeItemInfo CreateTextGradeItem( Identifier orgUnitId, string name ) {
			CreateTextGradeItemRequest request = new CreateTextGradeItemRequest() {
				OrgUnitId = orgUnitId,
				Name = name
			};
			CreateTextGradeItemResponse response = CallWebService<
				IGradesManagementServicev1_0, CreateTextGradeItemRequest, CreateTextGradeItemResponse>(
				m_service1_0, request, ( s, q ) => s.CreateTextGradeItem( q ) );
			return response.TextGradeItem;
		}

		public NumericGradeItemInfo CreateNumericGradeItem(
			Identifier orgUnitId, string name, decimal maxPoints, bool canExceedMaxPoints, bool isBonus ) {

			CreateNumericGradeItemRequest request = new CreateNumericGradeItemRequest() {
				OrgUnitId = orgUnitId,
				Name = name,
				MaxPoints = maxPoints,
				CanExceedMaxPoints = canExceedMaxPoints,
				IsBonus = isBonus
			};
			CreateNumericGradeItemResponse response = CallWebService<IGradesManagementServicev1_0,
				CreateNumericGradeItemRequest, CreateNumericGradeItemResponse>(
				m_service1_0, request, ( s, q ) => s.CreateNumericGradeItem( q ) );
			return response.NumericItem;
		}

		public PassFailGradeItemInfo CreatePassFailGradeItem(
			Identifier orgUnitId, string name, decimal maxPoints, bool isBonus ) {

			CreatePassFailGradeItemRequest request = new CreatePassFailGradeItemRequest() {
				OrgUnitId = orgUnitId,
				Name = name,
				MaxPoints = maxPoints,
				IsBonus = isBonus
			};
			CreatePassFailGradeItemResponse response = CallWebService<IGradesManagementServicev1_0,
				CreatePassFailGradeItemRequest, CreatePassFailGradeItemResponse>(
				m_service1_0, request, ( s, q ) => s.CreatePassFailGradeItem( q ) );
			return response.PassFailGradeItem;
		}

		public NumericGradeItemInfo GetNumericGradeItem( Identifier orgUnitId, Identifier gradeObjectId ) {
			GetNumericGradeItemRequest request = new GetNumericGradeItemRequest() {
				OrgUnitId = orgUnitId,
				GradeObjectId = gradeObjectId
			};
			GetNumericGradeItemResponse response = CallWebService<
				IGradesManagementServicev1_0, GetNumericGradeItemRequest, GetNumericGradeItemResponse>(
				m_service1_0, request, ( s, q ) => s.GetNumericGradeItem( request ) );
			return response.NumericGradeItem;
		}

		public PassFailGradeItemInfo GetPassFailGradeItem( Identifier orgUnitId, Identifier gradeObjectId ) {
			GetPassFailGradeItemRequest request = new GetPassFailGradeItemRequest() {
				OrgUnitId = orgUnitId,
				GradeObjectId = gradeObjectId
			};
			GetPassFailGradeItemResponse response = CallWebService<
				IGradesManagementServicev1_0, GetPassFailGradeItemRequest, GetPassFailGradeItemResponse>(
				m_service1_0, request, ( s, q ) => s.GetPassFailGradeItem( q ) );
			return response.PassFailGradeItem;
		}

		public TextGradeItemInfo GetTextGradeItem( Identifier orgUnitId, Identifier gradeObjectId ) {
			GetTextGradeItemRequest request = new GetTextGradeItemRequest() {
				OrgUnitId = orgUnitId,
				GradeObjectId = gradeObjectId
			};
			GetTextGradeItemResponse response = CallWebService<
				IGradesManagementServicev1_0, GetTextGradeItemRequest, GetTextGradeItemResponse>(
				m_service1_0, request, ( s, q ) => s.GetTextGradeItem( q ) );
			return response.TextGradeItem;
		}

		public CalculatedFinalGradeItemInfo GetCalculatedFinalGradeItem( Identifier orgUnitId ) {
			GetCalculatedFinalGradeItemRequest request = new GetCalculatedFinalGradeItemRequest() {
				OrgUnitId = orgUnitId
			};
			GetCalculatedFinalGradeItemResponse response = CallWebService<IGradesManagementServicev1_0,
				GetCalculatedFinalGradeItemRequest, GetCalculatedFinalGradeItemResponse>(
				m_service1_0, request, ( s, q ) => s.GetCalculatedFinalGradeItem( q ) );
			return response.CalculatedFinalGradeItem;
		}

		public AdjustedFinalGradeItemInfo GetAdjustedFinalGradeItem( Identifier orgUnitId ) {
			GetAdjustedFinalGradeItemRequest request = new GetAdjustedFinalGradeItemRequest() {
				OrgUnitId = orgUnitId
			};
			GetAdjustedFinalGradeItemResponse response = CallWebService<IGradesManagementServicev1_0,
				GetAdjustedFinalGradeItemRequest, GetAdjustedFinalGradeItemResponse>(
				m_service1_0, request, ( s, q ) => s.GetAdjustedFinalGradeItem( q ) );
			return response.AdjustedFinalGradeItem;
		}

		public void DeleteGradeItem( Identifier orgUnitId, Identifier gradeItemId ) {
			DeleteGradeItemRequest request = new DeleteGradeItemRequest() {
				OrgUnitId = orgUnitId,
				GradeItemId = gradeItemId
			};
			CallWebService<IGradesManagementServicev1_0, DeleteGradeItemRequest, DeleteGradeItemResponse>(
				m_service1_0, request, ( s, q ) => s.DeleteGradeItem( q ) );
		}

		public void SetTextGradeValue(
			Identifier orgUnitId, Identifier gradeItemId, Identifier userId, string gradeText ) {

			SetTextGradeValueRequest request = new SetTextGradeValueRequest() {
				OrgUnitId = orgUnitId,
				GradeObjectId = gradeItemId,
				UserId = userId,
				GradeText = gradeText
			};
			CallWebService<IGradesManagementServicev1_0, SetTextGradeValueRequest, SetGradeValueResponse>(
				m_service1_0, request, ( s, q ) => s.SetTextGradeValue( q ) );
		}

		public void SetNumericGradeValue(
			Identifier orgUnitId, Identifier gradeItemId, Identifier userId,
			Nullable<decimal> pointsNumerator ) {

			SetNumericGradeValueRequest request = new SetNumericGradeValueRequest() {
				OrgUnitId = orgUnitId,
				GradeObjectId = gradeItemId,
				UserId = userId,
				PointsNumerator = pointsNumerator
			};
			CallWebService<
				IGradesManagementServicev1_0, SetNumericGradeValueRequest, SetGradeValueResponse>(
				m_service1_0, request, ( s, q ) => s.SetNumericGradeValue( q ) );
		}

		public void SetPassFailGradeValue(
			Identifier orgUnitId, Identifier gradeItemId, Identifier userId,
			PassFailValueType passFailValue ) {

			SetPassFailGradeValueRequest request = new SetPassFailGradeValueRequest() {
				OrgUnitId = orgUnitId,
				GradeObjectId = gradeItemId,
				UserId = userId,
				PassFailValue = passFailValue
			};
			CallWebService<
				IGradesManagementServicev1_0, SetPassFailGradeValueRequest, SetGradeValueResponse>(
				m_service1_0, request, ( s, q ) => s.SetPassFailGradeValue( q ) );
		}

		public void SetAdjustedFinalGradeValue(
			Identifier orgUnitId, Identifier userId,
			Nullable<decimal> numerator, Nullable<decimal> denominator ) {

			SetAdjustedFinalGradeValueRequest request = new SetAdjustedFinalGradeValueRequest() {
				OrgUnitId = orgUnitId,
				UserId = userId,
				Numerator = numerator,
				Denominator = denominator
			};
			CallWebService<
				IGradesManagementServicev1_0, SetAdjustedFinalGradeValueRequest, SetGradeValueResponse>(
				m_service1_0, request, ( s, q ) => s.SetAdjustedFinalGradeValue( q ) );
		}
		
		public GradeObjectInfo[] GetGradeObjectsByOrgUnit( Identifier orgUnitId ) {
			GetGradeObjectsByOrgUnitRequest request = new GetGradeObjectsByOrgUnitRequest() {
				OrgUnitId = orgUnitId
			};
			GetGradeObjectsByOrgUnitResponse response = CallWebService<IGradesManagementServicev1_0,
				GetGradeObjectsByOrgUnitRequest, GetGradeObjectsByOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.GetGradeObjectsByOrgUnit( q ) );
			return response.GradeObjects;
		}

		public GradeValueInfo GetGradeValueByGradeObjectUser(
			Identifier orgUnitId, Identifier gradeObjectId, Identifier userId ) {

			GetGradeValueByGradeObjectUserRequest request = new GetGradeValueByGradeObjectUserRequest() {
				OrgUnitId = orgUnitId,
				GradeObjectId = gradeObjectId,
				UserId = userId
			};
			GetGradeValueByGradeObjectUserResponse response = CallWebService<IGradesManagementServicev1_0,
				GetGradeValueByGradeObjectUserRequest, GetGradeValueByGradeObjectUserResponse>(
				m_service1_0, request, ( s, q ) => s.GetGradeValueByGradeObjectUser( q ) );
			return response.GradeValue;
		}

		public GradeValueInfo[] GetGradeValuesByGradeObject(
			Identifier orgUnitId, Identifier gradeObjectId ) {

			GetGradeValuesByGradeObjectRequest request = new GetGradeValuesByGradeObjectRequest() {
				OrgUnitId = orgUnitId,
				GradeObjectId = gradeObjectId
			};
			GetGradeValuesByGradeObjectResponse response = CallWebService<IGradesManagementServicev1_0,
				GetGradeValuesByGradeObjectRequest, GetGradeValuesByGradeObjectResponse>(
				m_service1_0, request, ( s, q ) => s.GetGradeValuesByGradeObject( q ) );
			return response.GradeValues;
		}

		public GradeValueInfo[] GetGradeValuesByOrgUnitUser( Identifier orgUnitId, Identifier userId ) {
			GetGradeValuesByOrgUnitUserRequest request = new GetGradeValuesByOrgUnitUserRequest() {
				OrgUnitId = orgUnitId,
				UserId = userId
			};
			GetGradeValuesByOrgUnitUserResponse response = CallWebService<IGradesManagementServicev1_0,
				GetGradeValuesByOrgUnitUserRequest, GetGradeValuesByOrgUnitUserResponse>(
				m_service1_0, request, ( s, q ) => s.GetGradeValuesByOrgUnitUser( q ) );
			return response.GradeValues;
		}

		public GradeValueInfo[] GetGradeValuesByUser( Identifier userId ) {
			GetGradeValuesByUserRequest request = new GetGradeValuesByUserRequest() { UserId = userId };
			GetGradeValuesByUserResponse response = CallWebService<
				IGradesManagementServicev1_0, GetGradeValuesByUserRequest, GetGradeValuesByUserResponse>(
				m_service1_0, request, ( s, q ) => s.GetGradeValuesByUser( q ) );
			return response.GradeValues;
		}

		public GradeValueInfo[] GetGradeValuesByOrgUnit( Identifier orgUnitId ) {
			GetGradeValuesByOrgUnitRequest request = new GetGradeValuesByOrgUnitRequest() {
				OrgUnitId = orgUnitId
			};
			GetGradeValuesByOrgUnitResponse response = CallWebService<IGradesManagementServicev1_0,
				GetGradeValuesByOrgUnitRequest, GetGradeValuesByOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.GetGradeValuesByOrgUnit( q ) );
			return response.GradeValues;
		}

		public void GetFinalGradeValuesByUser(
			Identifier userId, out CourseOfferingInfo1_1[] courses, out GradeValueInfo[] gradeValues ) {

			GetFinalGradeValuesByUserRequest request = new GetFinalGradeValuesByUserRequest() {
				UserId = userId
			};
			GetFinalGradeValuesByUserResponse response = CallWebService<IGradesManagementServicev1_1,
				 GetFinalGradeValuesByUserRequest, GetFinalGradeValuesByUserResponse>(
				 m_service1_1, request, ( s, q ) => s.GetFinalGradeValuesByUser( q ) );
			courses = response.CourseOfferings;
			gradeValues = response.GradeValues;
		}

		public void GetFinalGradeSymbolsByUser(
			Identifier userId, out CourseOfferingInfo1_1[] courseOfferings, out string[] gradeSymbols ) {

			GetFinalGradeSymbolsByUserRequest request = new GetFinalGradeSymbolsByUserRequest() {
				UserId = userId
			};
			GetFinalGradeSymbolsByUserResponse response = CallWebService<IGradesManagementServicev1_2,
				GetFinalGradeSymbolsByUserRequest, GetFinalGradeSymbolsByUserResponse>(
				m_service1_2, request, ( s, q ) => s.GetFinalGradeSymbolsByUser( q ) );
			courseOfferings = response.CourseOfferings;
			gradeSymbols = response.GradeSymbols;
		}
		
		public void GetGradeSymbolsByUserOrgUnit(
			Identifier userId, Identifier orgUnitId,
			out GradeObjectInfo[] gradeObjects, out string[] gradeSymbols ) {

			GetGradeSymbolsByUserOrgUnitRequest request = new GetGradeSymbolsByUserOrgUnitRequest() {
				UserId = userId,
				OrgUnitId = orgUnitId
			};
			GetGradeSymbolsByUserOrgUnitResponse response = CallWebService<IGradesManagementServicev1_2,
				GetGradeSymbolsByUserOrgUnitRequest, GetGradeSymbolsByUserOrgUnitResponse>(
				m_service1_2, request, ( s, q ) => s.GetGradeSymbolsByUserOrgUnit( q ) );
			gradeObjects = response.GradeObjects;
			gradeSymbols = response.GradeSymbols;
		}

		public void GetGradeSymbolsByGradeObject(
			Identifier courseOfferingOrgUnitId, Identifier gradeObjectId,
			out UserBasicInfo[] users, out string[] gradeSymbols ) {

			GetGradeSymbolsByGradeObjectRequest request = new GetGradeSymbolsByGradeObjectRequest() {
				OrgUnitId = courseOfferingOrgUnitId,
				GradeObjectId = gradeObjectId
			};
			GetGradeSymbolsByGradeObjectResponse response = CallWebService<IGradesManagementServicev1_2,
				GetGradeSymbolsByGradeObjectRequest, GetGradeSymbolsByGradeObjectResponse>(
				m_service1_2, request, ( s, q ) => s.GetGradeSymbolsByGradeObject( q ) );
			users = response.Users;
			gradeSymbols = response.GradeSymbols;
		}

		public GradeStatsInfo GetStatisticsByGradeObject(
			Identifier courseOfferingId, Identifier gradeObjectId ) {

			GetStatisticsByGradeObjectRequest request = new GetStatisticsByGradeObjectRequest() {
				OrgUnitId = courseOfferingId,
				GradeObjectId = gradeObjectId
			};
			GetStatisticsByGradeObjectResponse response = CallWebService<IGradesManagementServicev1_2,
				GetStatisticsByGradeObjectRequest, GetStatisticsByGradeObjectResponse>(
				m_service1_2, request, ( s, q ) => s.GetStatisticsByGradeObject( q ) );
			return response.GradeStats;
		}

		public GradeValueInfo GetAdjustedFinalGrade( Identifier orgUnitId, Identifier userId ) {
			GetAdjustedFinalGradeRequest request = new GetAdjustedFinalGradeRequest() {
				OrgUnitId = orgUnitId,
				UserId = userId
			};
			var response = CallWebService<
				IGradesManagementServicev1_2, GetAdjustedFinalGradeRequest, GetAdjustedFinalGradeResponse>(
					m_service1_2, request, ( s, q ) => s.GetAdjustedFinalGrade( q ) );
			return response.GradeValueInfo;
		}

		public GradeValueInfo[] GetGradeValuesByUserGradeObject(
			Identifier userId, Identifier orgUnitId, Identifier gradeObjectId ) {

			GetGradeValuesByUserGradeObjectRequest request = new GetGradeValuesByUserGradeObjectRequest() {
				UserId = userId,
				OrgUnitId = orgUnitId,
				GradeObjectId = gradeObjectId
			};
			GetGradeValuesByUserGradeObjectResponse response = CallWebService<IGradesManagementServicev1_2,
				GetGradeValuesByUserGradeObjectRequest, GetGradeValuesByUserGradeObjectResponse>(
				m_service1_2, request, ( s, q ) => s.GetGradeValuesByUserGradeObject( q ) );
			return response.GradeValues;
		}

		public void GetGradeValuesWithUserInfoByGradeObject(
			Identifier orgUnitId, Identifier gradeObjectId,
			out UserBasicInfo[] users, out GradeValueInfo[] gradeValues ) {

			GetGradeValuesWithUserInfoByGradeObjectRequest request =
				new GetGradeValuesWithUserInfoByGradeObjectRequest() {

				OrgUnitId = orgUnitId,
				GradeObjectId = gradeObjectId
			};
			GetGradeValuesWithUserInfoByGradeObjectResponse response = CallWebService<
				IGradesManagementServicev1_2,
				GetGradeValuesWithUserInfoByGradeObjectRequest,
				GetGradeValuesWithUserInfoByGradeObjectResponse>(
				m_service1_2, request, ( s, q ) => s.GetGradeValuesWithUserInfoByGradeObject( q ) );
			users = response.Users;
			gradeValues = response.GradeValues;
		}

		public GradeSchemeInfo[] GetGradeSchemesByOrgUnit( Identifier orgUnitId ) {
			GetGradeSchemesByOrgUnitRequest request = new GetGradeSchemesByOrgUnitRequest() {
				OrgUnitId = orgUnitId
			};
			GetGradeSchemesByOrgUnitResponse response = CallWebService<IGradesManagementServicev1_2,
				GetGradeSchemesByOrgUnitRequest, GetGradeSchemesByOrgUnitResponse>(
				m_service1_2, request, ( s, q ) => s.GetGradeSchemesByOrgUnit( q ) );
			return response.GradeSchemes;
		}

		public SelectBoxGradeItemInfo CreateSelectBoxGradeItem(
			Identifier orgUnitId, string name, Identifier gradeSchemeId ) {

			CreateSelectBoxGradeItemRequest request = new CreateSelectBoxGradeItemRequest() {
				OrgUnitId = orgUnitId,
				Name = name,
				GradeSchemeId = gradeSchemeId
			};
			CreateSelectBoxGradeItemResponse response = CallWebService<IGradesManagementServicev1_2,
				CreateSelectBoxGradeItemRequest, CreateSelectBoxGradeItemResponse>(
				m_service1_2, request, ( s, q ) => s.CreateSelectBoxGradeItem( q ) );
			return response.GradeItem;
		}

		public SelectBoxGradeItemInfo GetSelectBoxGradeItem(
			Identifier orgUnitId, Identifier gradeObjectId ) {

			GetSelectBoxGradeItemRequest request = new GetSelectBoxGradeItemRequest() {
				OrgUnitId = orgUnitId,
				GradeObjectId = gradeObjectId
			};
			GetSelectBoxGradeItemResponse response = CallWebService<IGradesManagementServicev1_2,
				GetSelectBoxGradeItemRequest, GetSelectBoxGradeItemResponse>(
				m_service1_2, request, ( s, q ) => s.GetSelectBoxGradeItem( q ) );
			return response.GradeItem;
		}

		public void UpdateSelectBoxGradeItem( SelectBoxGradeItemInfo gradeItem ) {
			UpdateSelectBoxGradeItemRequest request = new UpdateSelectBoxGradeItemRequest() {
				GradeItem = gradeItem
			};
			CallWebService<IGradesManagementServicev1_2,
				UpdateSelectBoxGradeItemRequest, UpdateGradeItemResponse>(
				m_service1_2, request, ( s, q ) => s.UpdateSelectBoxGradeItem( q ) );
		}

		public GradeSchemeInfo GetGradeSchemeByGradeObject( Identifier orgUnitId, Identifier gradeObjectId ) {
			GetGradeSchemeByGradeObjectRequest request = new GetGradeSchemeByGradeObjectRequest() {
				OrgUnitId = orgUnitId,
				GradeObjectId = gradeObjectId
			};
			GetGradeSchemeByGradeObjectResponse response = CallWebService<IGradesManagementServicev1_2,
				GetGradeSchemeByGradeObjectRequest, GetGradeSchemeByGradeObjectResponse>(
				m_service1_2, request, ( s, q ) => s.GetGradeSchemeByGradeObject( q ) );
			return response.GradeScheme;
		}

		public void SetSelectBoxGradeValue(
			Identifier orgUnitId, Identifier gradeObjectId, Identifier userId, string gradeText ) {

			SetSelectBoxGradeValueRequest request = new SetSelectBoxGradeValueRequest() {
				OrgUnitId = orgUnitId,
				GradeObjectId = gradeObjectId,
				UserId = userId,
				GradeText = gradeText
			};
			CallWebService<IGradesManagementServicev1_2,
				SetSelectBoxGradeValueRequest, SetGradeValueResponse>(
				m_service1_2, request, ( s, q ) => s.SetSelectBoxGradeValue( q ) );
		}

		public void UpdateNumericGradeItem( NumericGradeItemInfo gradeItem ) {
			UpdateNumericGradeItemRequest request = new UpdateNumericGradeItemRequest() {
				GradeItem = gradeItem
			};
			CallWebService<IGradesManagementServicev1_2,
				UpdateNumericGradeItemRequest, UpdateGradeItemResponse>(
				m_service1_2, request, ( s, q ) => s.UpdateNumericGradeItem( q ) );
		}

		public void UpdatePassFailGradeItem( PassFailGradeItemInfo gradeItem ) {
			UpdatePassFailGradeItemRequest request = new UpdatePassFailGradeItemRequest() {
				GradeItem = gradeItem
			};
			CallWebService<IGradesManagementServicev1_2,
				UpdatePassFailGradeItemRequest, UpdateGradeItemResponse>(
				m_service1_2, request, ( s, q ) => s.UpdatePassFailGradeItem( q ) );
		}

		public void UpdateTextGradeItem( TextGradeItemInfo gradeItem ) {
			UpdateTextGradeItemRequest request = new UpdateTextGradeItemRequest() {
				GradeItem = gradeItem
			};
			CallWebService<IGradesManagementServicev1_2,
				UpdateTextGradeItemRequest, UpdateGradeItemResponse>(
				m_service1_2, request, ( s, q ) => s.UpdateTextGradeItem( q ) );
		}

		public void SetMultipleNumericGradeValues(
			Identifier orgUnitId, Identifier gradeObjectId, UserNumericGradeValueInfo[] grades ) {

			SetMultipleNumericGradeValuesRequest request = new SetMultipleNumericGradeValuesRequest() {
				OrgUnitId = orgUnitId,
				GradeObjectId = gradeObjectId,
				Grades = grades
			};
			CallWebService<IGradesManagementServicev1_3,
				SetMultipleNumericGradeValuesRequest, SetGradeValueResponse>(
					m_service1_3, request, ( s, q ) => s.SetMultipleNumericGradeValues( q ) );
		}
	}
}
