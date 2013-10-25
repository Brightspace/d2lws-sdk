using System;

using D2L.WS.Client.Proxy;

namespace D2L.WS.Client.Stubs {
	public class OrgUnitsServiceStub : ServiceStubBase {
		private IOrgUnitManagementServicev1_0 m_service1_0;
		private IOrgUnitManagementServicev1_1 m_service1_1;

		internal OrgUnitsServiceStub(
			IOrgUnitManagementServicev1_0 service1_0,
			IOrgUnitManagementServicev1_1 service1_1 ) {

			m_service1_0 = service1_0;
			m_service1_1 = service1_1;
		}

		public SystemOrgUnitTypeInfo[] GetSystemOrgUnitTypes() {
			GetSystemOrgUnitTypesResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetSystemOrgUnitTypesRequest, GetSystemOrgUnitTypesResponse>(
				m_service1_0, new GetSystemOrgUnitTypesRequest(), ( s, q ) => s.GetSystemOrgUnitTypes( q ) );
			return response.OrgUnitTypes;
		}

		public OrgUnitTypeInfo GetSemesterOrgUnitType() {
			GetSemesterOrgUnitTypeResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetSemesterOrgUnitTypeRequest, GetSemesterOrgUnitTypeResponse>(
				m_service1_0, new GetSemesterOrgUnitTypeRequest(),
				( s, q ) => s.GetSemesterOrgUnitType( q ) );
			return response.OrgUnitType;
		}

		public OrgUnitTypeInfo GetDepartmentOrgUnitType() {
			GetDepartmentOrgUnitTypeResponse response = CallWebService<IOrgUnitManagementServicev1_0,
				GetDepartmentOrgUnitTypeRequest, GetDepartmentOrgUnitTypeResponse>(
				m_service1_0, new GetDepartmentOrgUnitTypeRequest(),
				( s, q ) => s.GetDepartmentOrgUnitType( q ) );
			return response.OrgUnitType;
		}

		public CustomOrgUnitTypeInfo CreateCustomOrgUnitType(
			string name, string description, CustomSemanticType customSemantic ) {

			CreateCustomOrgUnitTypeRequest request = new CreateCustomOrgUnitTypeRequest() {
				Name = name,
				Description = description,
				CustomSemantic = customSemantic
			};
			CreateCustomOrgUnitTypeResponse response = CallWebService<IOrgUnitManagementServicev1_0,
				CreateCustomOrgUnitTypeRequest, CreateCustomOrgUnitTypeResponse>(
				m_service1_0, request, ( s, q ) => s.CreateCustomOrgUnitType( q ) );
			return response.OrgUnitTypeInfo;
		}

		public CustomOrgUnitTypeInfo[] GetCustomOrgUnitTypes() {
			GetCustomOrgUnitTypesRequest request = new GetCustomOrgUnitTypesRequest();

			GetCustomOrgUnitTypesResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetCustomOrgUnitTypesRequest, GetCustomOrgUnitTypesResponse>(
				m_service1_0, new GetCustomOrgUnitTypesRequest(), ( s, q ) => s.GetCustomOrgUnitTypes( q ) );
			return response.OrgUnitTypes;
		}

		public CustomOrgUnitTypeInfo GetCustomOrgUnitType( Identifier orgUnitTypeId ) {
			GetCustomOrgUnitTypeRequest request = new GetCustomOrgUnitTypeRequest() {
				OrgUnitTypeId = orgUnitTypeId
			};
			GetCustomOrgUnitTypeResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetCustomOrgUnitTypeRequest, GetCustomOrgUnitTypeResponse>(
				m_service1_0, request, ( s, q ) => s.GetCustomOrgUnitType( q ) );
			return response.OrgUnitType;
		}

		public void DeleteCustomOrgUnitType( Identifier orgUnitTypeId ) {
			DeleteCustomOrgUnitTypeRequest request = new DeleteCustomOrgUnitTypeRequest() {
				OrgUnitTypeId = orgUnitTypeId
			};
			CallWebService<IOrgUnitManagementServicev1_0,
				DeleteCustomOrgUnitTypeRequest, DeleteCustomOrgUnitTypeResponse>(
				m_service1_0, request, ( s, q ) => s.DeleteCustomOrgUnitType( q ) );
		}

		public void UpdateCustomOrgUnitType( CustomOrgUnitTypeInfo orgUnitType ) {
			UpdateCustomOrgUnitTypeRequest request = new UpdateCustomOrgUnitTypeRequest() {
				OrgUnitType = orgUnitType
			};
			CallWebService<IOrgUnitManagementServicev1_0,
				UpdateCustomOrgUnitTypeRequest, UpdateCustomOrgUnitTypeResponse>(
				m_service1_0, request, ( s, q ) => s.UpdateCustomOrgUnitType( request ) );
		}

		public OrganizationInfo GetOrganization( ) {
			GetOrganizationResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetOrganizationRequest, GetOrganizationResponse>(
				m_service1_0, new GetOrganizationRequest(), ( s, q ) => s.GetOrganization( q ) );
			return response.Org;
		}

		public DepartmentInfo CreateDepartment(
			string name, string code, string path,
			Nullable<bool> isActive, Nullable<DateTime> start, Nullable<DateTime> end ) {

			CreateDepartmentRequest request = new CreateDepartmentRequest() {
				Name = name,
				Code = code,
				Path = path,
				IsActive = isActive ?? true,
				StartDate = start ?? DateTime.MinValue,
				EndDate = end ?? DateTime.MinValue
			};
			CreateDepartmentResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, CreateDepartmentRequest, CreateDepartmentResponse>(
				m_service1_0, request, ( s, q ) => s.CreateDepartment( q ) );
			return response.Department;
		}

		public void DeleteDepartment( Identifier orgUnitId ) {
			DeleteDepartmentRequest request = new DeleteDepartmentRequest() { OrgUnitId = orgUnitId };
			CallWebService<IOrgUnitManagementServicev1_0, DeleteDepartmentRequest, DeleteOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.DeleteDepartment( q ) );
			DeleteOrgUnitResponse response = m_service1_0.DeleteDepartment( request );
		}

		public DepartmentInfo GetDepartment( Identifier orgUnitId ) {
			GetDepartmentRequest request = new GetDepartmentRequest() { OrgUnitId = orgUnitId };
			GetDepartmentResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetDepartmentRequest, GetDepartmentResponse>(
				m_service1_0, request, ( s, q ) => s.GetDepartment( q ) );
			return response.Department;
		}

		public DepartmentInfo GetDepartmentByCode( string code ) {
			GetDepartmentByCodeRequest request = new GetDepartmentByCodeRequest() { Code = code };
			GetDepartmentResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetDepartmentByCodeRequest, GetDepartmentResponse>(
				m_service1_0, request, ( s, q ) => s.GetDepartmentByCode( q ) );
			return response.Department;
		}

		public void UpdateDepartment( DepartmentInfo department ) {
			UpdateDepartmentRequest request = new UpdateDepartmentRequest() { Department = department };
			CallWebService<IOrgUnitManagementServicev1_0, UpdateDepartmentRequest, UpdateOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.UpdateDepartment( q ) );
		}

		public SemesterInfo CreateSemester(
			string name, string code, string path,
			Nullable<bool> isActive, Nullable<DateTime> start, Nullable<DateTime> end ) {

			CreateSemesterRequest request = new CreateSemesterRequest() {
				Name = name,
				Code = code,
				Path = path,
				IsActive = isActive ?? true,
				StartDate = start ?? DateTime.MinValue,
				EndDate = end ?? DateTime.MinValue
			};
			CreateSemesterResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, CreateSemesterRequest, CreateSemesterResponse>(
				m_service1_0, request, ( s, q ) => s.CreateSemester( q ) );
			return response.Semester;
		}

		public void DeleteSemester( Identifier orgUnitId ) {
			DeleteSemesterRequest request = new DeleteSemesterRequest() { OrgUnitId = orgUnitId };
			DeleteOrgUnitResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, DeleteSemesterRequest, DeleteOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.DeleteSemester( q ) );
		}

		public SemesterInfo GetSemester( Identifier orgUnitId ) {
			GetSemesterRequest request = new GetSemesterRequest() { OrgUnitId = orgUnitId };
			GetSemesterResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetSemesterRequest, GetSemesterResponse>(
				m_service1_0, request, ( s, q ) => s.GetSemester( q ) );
			return response.Semester;
		}

		public SemesterInfo GetSemesterByCode( string code ) {
			GetSemesterByCodeRequest request = new GetSemesterByCodeRequest() { Code = code };
			GetSemesterResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetSemesterByCodeRequest, GetSemesterResponse>(
				m_service1_0, request, ( s, q ) => s.GetSemesterByCode( q ) );
			return response.Semester;
		}

		public void UpdateSemester( SemesterInfo semester ) {
			UpdateSemesterRequest request = new UpdateSemesterRequest() { Semester = semester };
			CallWebService<IOrgUnitManagementServicev1_0, UpdateSemesterRequest, UpdateOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.UpdateSemester( q ) );
		}

		public CustomOrgUnitInfo CreateCustomOrgUnit(
			string name, string code, string path, Identifier ouTypeId,
			Nullable<bool> isActive, Nullable<DateTime> start, Nullable<DateTime> end ) {

			CreateCustomOrgUnitRequest request = new CreateCustomOrgUnitRequest() {
				Name = name,
				Code = code,
				Path = path,
				CustomOrgUnitTypeId = ouTypeId,
				IsActive = isActive ?? true,
				StartDate = start ?? DateTime.MinValue,
				EndDate = end ?? DateTime.MinValue
			};
			CreateCustomOrgUnitResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, CreateCustomOrgUnitRequest, CreateCustomOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.CreateCustomOrgUnit( q ) );
			return response.OrgUnit;
		}

		public void DeleteCustomOrgUnit( Identifier orgUnitId ) {
			DeleteCustomOrgUnitRequest request = new DeleteCustomOrgUnitRequest() { OrgUnitId = orgUnitId };
			CallWebService<IOrgUnitManagementServicev1_0, DeleteCustomOrgUnitRequest, DeleteOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.DeleteCustomOrgUnit( q ) );
		}

		public CustomOrgUnitInfo GetCustomOrgUnit( Identifier orgUnitId ) {
			GetCustomOrgUnitRequest request = new GetCustomOrgUnitRequest() { OrgUnitId = orgUnitId };
			GetCustomOrgUnitResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetCustomOrgUnitRequest, GetCustomOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.GetCustomOrgUnit( q ) );
			return response.OrgUnit;
		}

		public CustomOrgUnitInfo GetCustomOrgUnitByCode( string code ) {
			GetCustomOrgUnitByCodeRequest request = new GetCustomOrgUnitByCodeRequest() { Code = code };
			GetCustomOrgUnitResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetCustomOrgUnitByCodeRequest, GetCustomOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.GetCustomOrgUnitByCode( q ) );
			return response.OrgUnit;
		}

		public void UpdateCustomOrgUnit( CustomOrgUnitInfo orgUnit ) {
			UpdateCustomOrgUnitRequest request = new UpdateCustomOrgUnitRequest() { OrgUnit = orgUnit };
			CallWebService<IOrgUnitManagementServicev1_0, UpdateCustomOrgUnitRequest, UpdateOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.UpdateCustomOrgUnit( q ) );
		}

		public CourseTemplateInfo CreateCourseTemplate(
			string name, string code, string path,
			Nullable<bool> isActive, Nullable<DateTime> start, Nullable<DateTime> end ) {

			CreateCourseTemplateRequest request = new CreateCourseTemplateRequest() {
				Name = name,
				Code = code,
				Path = path,
				IsActive = isActive ?? true,
				StartDate = start ?? DateTime.MinValue,
				EndDate = end ?? DateTime.MinValue
			};
			CreateCourseTemplateResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, CreateCourseTemplateRequest, CreateCourseTemplateResponse>(
				m_service1_0, request, ( s, q ) => s.CreateCourseTemplate( q ) );
			return response.CourseTemplate;
		}

		public void DeleteCourseTemplate( Identifier orgUnitId ) {
			DeleteCourseTemplateRequest request = new DeleteCourseTemplateRequest() { OrgUnitId = orgUnitId };
			CallWebService<IOrgUnitManagementServicev1_0, DeleteCourseTemplateRequest, DeleteOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.DeleteCourseTemplate( q ) );
		}

		public CourseTemplateInfo GetCourseTemplate( Identifier orgUnitId ) {
			GetCourseTemplateRequest request = new GetCourseTemplateRequest() { OrgUnitId = orgUnitId };
			GetCourseTemplateResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetCourseTemplateRequest, GetCourseTemplateResponse>(
				m_service1_0, request, ( s, q ) => s.GetCourseTemplate( q ) );
			return response.CourseTemplate;
		}

		public CourseTemplateInfo GetCourseTemplateByCode( string code ) {
			GetCourseTemplateByCodeRequest request = new GetCourseTemplateByCodeRequest() { Code = code };
			GetCourseTemplateResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetCourseTemplateByCodeRequest, GetCourseTemplateResponse>(
				m_service1_0, request, ( s, q ) => s.GetCourseTemplateByCode( q ) );
			return response.CourseTemplate;
		}

		public void UpdateCourseTemplate( CourseTemplateInfo courseTemplate ) {
			UpdateCourseTemplateRequest request = new UpdateCourseTemplateRequest() {
				CourseTemplate = courseTemplate
			};
			CallWebService<IOrgUnitManagementServicev1_0, UpdateCourseTemplateRequest, UpdateOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.UpdateCourseTemplate( q ) );
		}

		public CourseOfferingInfo CreateCourseOffering(
			string name, string code, string path, Identifier templateId,
			Nullable<bool> isActive, Nullable<DateTime> start, Nullable<DateTime> end,
			Nullable<bool> canRegister, Nullable<bool> allowSections ) {

			CreateCourseOfferingRequest request = new CreateCourseOfferingRequest() {
				Name = name,
				Code = code,
				Path = path,
				TemplateId = templateId,
				IsActive = isActive ?? true,
				StartDate = start ?? DateTime.MinValue,
				EndDate = end ?? DateTime.MinValue,
				CanRegister = canRegister ?? false,
				AllowSections = allowSections ?? false
			};
			CreateCourseOfferingResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, CreateCourseOfferingRequest, CreateCourseOfferingResponse>(
				m_service1_0, request, ( s, q ) => s.CreateCourseOffering( q ) );
			return response.CourseOffering;
		}

		public void DeleteCourseOffering( Identifier orgUnitId ) {
			DeleteCourseOfferingRequest request = new DeleteCourseOfferingRequest() { OrgUnitId = orgUnitId };
			CallWebService<IOrgUnitManagementServicev1_0, DeleteCourseOfferingRequest, DeleteOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.DeleteCourseOffering( q ) );
		}

		public CourseOfferingInfo GetCourseOffering( Identifier orgUnitId ) {
			GetCourseOfferingRequest request = new GetCourseOfferingRequest() { OrgUnitId = orgUnitId };
			GetCourseOfferingResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetCourseOfferingRequest, GetCourseOfferingResponse>(
				m_service1_0, request, ( s, q ) => s.GetCourseOffering( q ) );
			return response.CourseOffering;
		}

		public CourseOfferingInfo GetCourseOfferingByCode( string code ) {
			GetCourseOfferingByCodeRequest request = new GetCourseOfferingByCodeRequest() { Code = code };
			GetCourseOfferingResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetCourseOfferingByCodeRequest, GetCourseOfferingResponse>(
					m_service1_0, request, ( s, q ) => s.GetCourseOfferingByCode( q ) );
			return response.CourseOffering;
		}

		public void UpdateCourseOffering( CourseOfferingInfo courseOffering ) {
			UpdateCourseOfferingRequest request = new UpdateCourseOfferingRequest() {
				CourseOffering = courseOffering
			};
			CallWebService<IOrgUnitManagementServicev1_0, UpdateCourseOfferingRequest, UpdateOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.UpdateCourseOffering( q ) );
		}

		public GroupTypeInfo CreateGroupType(
			string name, RichTextInfo desc, Identifier ownerId,
			bool autoEnroll, bool randomEnroll, int numEnroll, GroupEnrollmentStyle enrollStyle ) {

			CreateGroupTypeRequest request = new CreateGroupTypeRequest() {
				Name = name,
				Description = desc,
				OwnerOrgUnitId = ownerId,
				IsAutoEnroll = autoEnroll,
				RandomizeEnrollments = randomEnroll,
				EnrollmentQuantity = numEnroll,
				EnrollmentStyle = enrollStyle
			};
			CreateGroupTypeResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, CreateGroupTypeRequest, CreateGroupTypeResponse>(
				m_service1_0, request, ( s, q ) => s.CreateGroupType( q ) );
			return response.GroupType;
		}

		public GroupTypeInfo GetGroupType( Identifier ownId, Identifier grpTypeId ) {
			GetGroupTypeRequest request = new GetGroupTypeRequest() {
				OwnerOrgUnitId = ownId,
				GroupTypeId = grpTypeId
			};
			GetGroupTypeResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetGroupTypeRequest, GetGroupTypeResponse>(
				m_service1_0, request, ( s, q ) => s.GetGroupType( q ) );
			return response.GroupType;
		}

		public GroupTypeInfo[] GetGroupTypes( Identifier ownId ) {
			GetGroupTypesRequest request = new GetGroupTypesRequest() { OwnerOrgUnitId = ownId };
			GetGroupTypesResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetGroupTypesRequest, GetGroupTypesResponse>(
				m_service1_0, request, ( s, q ) => s.GetGroupTypes( q ) );
			return response.GroupTypes;
		}

		public void UpdateGroupType( GroupTypeInfo grpType ) {
			UpdateGroupTypeRequest request = new UpdateGroupTypeRequest() { GroupType = grpType };
			CallWebService<IOrgUnitManagementServicev1_0, UpdateGroupTypeRequest, UpdateGroupTypeResponse>(
				m_service1_0, request, ( s, q ) => s.UpdateGroupType( q ) );
		}

		public void DeleteGroupType( Identifier ownId, Identifier grpTypeId ) {
			DeleteGroupTypeRequest request = new DeleteGroupTypeRequest() {
				OwnerOrgUnitId = ownId,
				GroupTypeId = grpTypeId
			};
			CallWebService<IOrgUnitManagementServicev1_0, DeleteGroupTypeRequest, DeleteGroupTypeResponse>(
				m_service1_0, request, ( s, q ) => s.DeleteGroupType( q ) );
		}

		public GroupInfo CreateGroup(
			string name, string code, RichTextInfo desc, Identifier grpTypeId, Identifier ownerId ) {

			CreateGroupRequest request = new CreateGroupRequest() {
				Name = name,
				Code = code,
				Description = desc,
				GroupTypeId = grpTypeId,
				OwnerOrgUnitId = ownerId
			};
			CreateGroupResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, CreateGroupRequest, CreateGroupResponse>(
				m_service1_0, request, ( s, q ) => s.CreateGroup( q ) );
			return response.Group;
		}

		public GroupInfo GetGroup( Identifier ouId ) {
			GetGroupRequest request = new GetGroupRequest() { OrgUnitId = ouId };
			GetGroupResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetGroupRequest, GetGroupResponse>(
				m_service1_0, request, ( s, q ) => s.GetGroup( q ) );
			return response.Group;
		}

		public GroupInfo GetGroupByCode( string code ) {
			GetGroupByCodeRequest request = new GetGroupByCodeRequest() { Code = code };
			GetGroupResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetGroupByCodeRequest, GetGroupResponse>(
				m_service1_0, request, ( s, q ) => s.GetGroupByCode( q ) );
			return response.Group;
		}

		public void UpdateGroup( GroupInfo grp ) {
			UpdateGroupRequest request = new UpdateGroupRequest() { Group = grp };
			CallWebService<IOrgUnitManagementServicev1_0, UpdateGroupRequest, UpdateOrgUnitResponse>(
				m_service1_0, request, ( s, q )  => s.UpdateGroup( q ) );
		}

		public void DeleteGroup( Identifier ouId ) {
			DeleteGroupRequest request = new DeleteGroupRequest() { OrgUnitId = ouId };
			CallWebService<IOrgUnitManagementServicev1_0, DeleteGroupRequest, DeleteOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.DeleteGroup( q ) );
		}

		public SectionInfo CreateSection(
			string name, string code, RichTextInfo description, Identifier courseOfferingId ) {

			CreateSectionRequest request = new CreateSectionRequest() {
				Name = name,
				Code = code,
				Description = description,
				CourseOfferingId = courseOfferingId
			};
			CreateSectionResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, CreateSectionRequest, CreateSectionResponse>(
				m_service1_0, request, ( s, q ) => s.CreateSection( q ) );
			return response.Section;
		}

		public void DeleteSection( Identifier orgUnitId ) {
			DeleteSectionRequest request = new DeleteSectionRequest() { OrgUnitId = orgUnitId };
			CallWebService<IOrgUnitManagementServicev1_0, DeleteSectionRequest, DeleteOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.DeleteSection( q ) );
		}

		public SectionInfo GetSection( Identifier orgUnitId ) {
			GetSectionRequest request = new GetSectionRequest() { OrgUnitId = orgUnitId };
			GetSectionResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetSectionRequest, GetSectionResponse>(
				m_service1_0, request, ( s, q ) => s.GetSection( q ) );
			return response.Section;
		}

		public SectionInfo GetSectionByCode( string code ) {
			GetSectionByCodeRequest request = new GetSectionByCodeRequest() { Code = code };
			GetSectionResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetSectionByCodeRequest, GetSectionResponse>(
				m_service1_0, request, ( s, q ) => s.GetSectionByCode( q ) );
			return response.Section;
		}

		public void UpdateSection( SectionInfo section ) {
			UpdateSectionRequest request = new UpdateSectionRequest() { Section = section };
			CallWebService<IOrgUnitManagementServicev1_0, UpdateSectionRequest, UpdateOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.UpdateSection( q ) );
		}

		public void AddChildOrgUnit( Identifier orgUnitId, Identifier childOrgUnitId ) {
			AddChildOrgUnitRequest request = new AddChildOrgUnitRequest() {
				OrgUnitId = orgUnitId,
				ChildOrgUnitId = childOrgUnitId
			};
			CallWebService<IOrgUnitManagementServicev1_0, AddChildOrgUnitRequest, AddChildOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.AddChildOrgUnit( q ) );
		}

		public void RemoveChildOrgUnit( Identifier orgUnitId, Identifier childOrgUnitId ) {
			RemoveChildOrgUnitRequest request = new RemoveChildOrgUnitRequest() {
				OrgUnitId = orgUnitId,
				ChildOrgUnitId = childOrgUnitId
			};
			CallWebService<
				IOrgUnitManagementServicev1_0, RemoveChildOrgUnitRequest, RemoveChildOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.RemoveChildOrgUnit( q ) );
		}

		public Identifier[] GetChildOrgUnitTypeIds( Identifier orgUnitId ) {
			GetChildOrgUnitTypeIdsRequest request = new GetChildOrgUnitTypeIdsRequest() {
				OrgUnitId = orgUnitId
			};
			GetChildOrgUnitTypeIdsResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetChildOrgUnitTypeIdsRequest, GetChildOrgUnitTypeIdsResponse>(
				m_service1_0, request, ( s, q ) => s.GetChildOrgUnitTypeIds( q ) );
			return response.ChildOrgUnitTypeIds;
		}

		public OrgUnitIdentifier[] GetChildOrgUnitIds( Identifier orgUnitId ) {
			GetChildOrgUnitIdsRequest request = new GetChildOrgUnitIdsRequest() { OrgUnitId = orgUnitId };
			GetOrgUnitIdsResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetChildOrgUnitIdsRequest, GetOrgUnitIdsResponse>(
				m_service1_0, request, ( s, q ) => s.GetChildOrgUnitIds( q ) );
			return response.OrgUnitIds;
		}

		public OrgUnitIdentifier[] GetParentOrgUnitIds( Identifier orgUnitId ) {
			GetParentOrgUnitIdsRequest request = new GetParentOrgUnitIdsRequest() { OrgUnitId = orgUnitId };
			GetOrgUnitIdsResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetParentOrgUnitIdsRequest, GetOrgUnitIdsResponse>(
				m_service1_0, request, ( s, q ) => s.GetParentOrgUnitIds( q ) );
			return response.OrgUnitIds;
		}

		public GroupInfo[] GetChildGroups( Identifier orgUnitId ) {
			GetChildGroupsRequest request = new GetChildGroupsRequest() { OrgUnitId = orgUnitId };
			GetGroupsResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetChildGroupsRequest, GetGroupsResponse>(
				m_service1_0, request, ( s, q ) => s.GetChildGroups( q ) );
			return response.ChildOrgUnits;
		}

		public GroupInfo[] GetChildGroupsByType( Identifier orgUnitId, Identifier groupTypeId ) {
			GetChildGroupsByTypeRequest request = new GetChildGroupsByTypeRequest() {
				OrgUnitId = orgUnitId,
				GroupTypeId = groupTypeId
			};
			GetGroupsResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetChildGroupsByTypeRequest, GetGroupsResponse>(
				m_service1_0, request, ( s, q ) => s.GetChildGroupsByType( q ) );
			return response.ChildOrgUnits;
		}

		public SectionInfo[] GetChildSections( Identifier orgUnitId ) {
			GetChildSectionsRequest request = new GetChildSectionsRequest() { OrgUnitId = orgUnitId };
			GetSectionsResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetChildSectionsRequest, GetSectionsResponse>(
				m_service1_0, request, ( s, q ) => s.GetChildSections( q ) );
			return response.ChildOrgUnits;
		}

		public CourseOfferingInfo[] GetChildCourseOfferings( Identifier orgUnitId ) {
			GetChildCourseOfferingsRequest request = new GetChildCourseOfferingsRequest() {
				OrgUnitId = orgUnitId
			};
			GetCourseOfferingsResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetChildCourseOfferingsRequest, GetCourseOfferingsResponse>(
				m_service1_0, request, ( s, q ) => s.GetChildCourseOfferings( q ) );
			return response.ChildOrgUnits;
		}

		public CourseTemplateInfo[] GetChildCourseTemplates( Identifier orgUnitId ) {
			GetChildCourseTemplatesRequest request = new GetChildCourseTemplatesRequest() {
				OrgUnitId = orgUnitId
			};
			GetCourseTemplatesResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetChildCourseTemplatesRequest, GetCourseTemplatesResponse>(
				m_service1_0, request, ( s, q ) => s.GetChildCourseTemplates( q ) );
			return response.ChildOrgUnits;
		}

		public DepartmentInfo[] GetChildDepartments( Identifier orgUnitId ) {
			GetChildDepartmentsRequest request = new GetChildDepartmentsRequest() { OrgUnitId = orgUnitId };
			GetDepartmentsResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetChildDepartmentsRequest, GetDepartmentsResponse>(
				m_service1_0, request, ( s, q ) => s.GetChildDepartments( q ) );
			return response.ChildOrgUnits;
		}

		public SemesterInfo[] GetChildSemesters( Identifier orgUnitId ) {
			GetChildSemestersRequest request = new GetChildSemestersRequest() { OrgUnitId = orgUnitId };
			GetSemestersResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetChildSemestersRequest, GetSemestersResponse>(
				m_service1_0, request, ( s, q ) => s.GetChildSemesters( q ) );
			return response.ChildOrgUnits;
		}

		public CustomOrgUnitInfo[] GetChildCustomOrgUnits( Identifier orgUnitId ) {
			GetChildCustomOrgUnitsRequest request = new GetChildCustomOrgUnitsRequest() {
				OrgUnitId = orgUnitId
			};
			GetCustomOrgUnitsResponse response = CallWebService<
				IOrgUnitManagementServicev1_0, GetChildCustomOrgUnitsRequest, GetCustomOrgUnitsResponse>(
				m_service1_0, request, ( s, q ) => s.GetChildCustomOrgUnits( q ) );
			return response.ChildOrgUnits;
		}

		public CustomOrgUnitInfo[] GetChildCustomOrgUnitsByType(
			Identifier orgUnitId, Identifier customOUTypeId ) {

			GetChildCustomOrgUnitsByTypeRequest request = new GetChildCustomOrgUnitsByTypeRequest() {
				OrgUnitId = orgUnitId,
				CustomOrgUnitTypeId = customOUTypeId
			};
			GetCustomOrgUnitsResponse response = CallWebService<IOrgUnitManagementServicev1_0,
				GetChildCustomOrgUnitsByTypeRequest, GetCustomOrgUnitsResponse>(
				m_service1_0, request, ( s, q ) => s.GetChildCustomOrgUnitsByType( q ) );
			return response.ChildOrgUnits;
		}

		public OrgUnitInfo[] GetChildOrgUnits( Identifier orgUnitId ) {
			GetChildOrgUnitsRequest request = new GetChildOrgUnitsRequest() { OrgUnitId = orgUnitId };
			GetChildOrgUnitsResponse response = CallWebService<
				IOrgUnitManagementServicev1_1, GetChildOrgUnitsRequest, GetChildOrgUnitsResponse>(
				m_service1_1, request, ( s, q ) => s.GetChildOrgUnits( q ) );
			return response.ChildOrgUnits;
		}
		
		protected override void Dispose( bool disposing ) {
			if( !m_disposed ) {
				if( disposing ) {
					m_service1_0.Dispose();
					m_service1_1.Dispose();
				}
				m_disposed = true;
			}
		}
	}
}
