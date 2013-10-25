using D2L.WS.Client.Proxy;

namespace D2L.WS.Client.Stubs {
	public class UsersServiceStub : ServiceStubBase {
		private IUserManagementServicev1_0 m_service1_0;
		private IUserManagementServicev1_1 m_service1_1;
		private IUserManagementServicev1_2 m_service1_2;
		private IUserManagementServicev1_3 m_service1_3;
		private IUserManagementServicev1_4 m_service1_4;
		private IUserManagementServicev1_5 m_service1_5;
		private IUserManagementServicev1_6 m_service1_6;

		internal UsersServiceStub(
			IUserManagementServicev1_0 service1_0, IUserManagementServicev1_1 service1_1,
			IUserManagementServicev1_2 service1_2, IUserManagementServicev1_3 service1_3,
			IUserManagementServicev1_4 service1_4, IUserManagementServicev1_5 service1_5,
			IUserManagementServicev1_6 service1_6 ) {

			m_service1_0 = service1_0;
			m_service1_1 = service1_1;
			m_service1_2 = service1_2;
			m_service1_3 = service1_3;
			m_service1_4 = service1_4;
			m_service1_5 = service1_5;
			m_service1_6 = service1_6;
		}

        public UserInfo CreateUser( UserInfo user, string password, Identifier initialRoleId ) {
			CreateUserRequest request = MapUserInfoToCreateUserRequest( user );
			request.Password = password;
			request.RoleId = initialRoleId;
			CreateUserResponse response = CallWebService<
				IUserManagementServicev1_0, CreateUserRequest, CreateUserResponse>(
				m_service1_0, request, ( s, q ) => s.CreateUser( q ) );
			return response.User; 
		}

		public UserInfo GetUser( Identifier userId ) {
			GetUserRequest request = new GetUserRequest() { UserId = userId };
			GetUserResponse response = CallWebService<
				IUserManagementServicev1_0, GetUserRequest, GetUserResponse>(
				m_service1_0, request, ( s, q ) => s.GetUser( q ) );
			return response.User; 
		}

		public UserInfo GetUserByOrgDefinedId( string orgDefinedId ) {
			GetUserByOrgDefinedIdRequest request = new GetUserByOrgDefinedIdRequest() {
				OrgDefinedId = orgDefinedId
			};
			GetUserResponse response = CallWebService<
				IUserManagementServicev1_0, GetUserByOrgDefinedIdRequest, GetUserResponse>(
				m_service1_0, request, ( s, q ) => s.GetUserByOrgDefinedId( q ) );
			return response.User; 
		}

		public UserInfo GetUserByUserName( string userName ) {
			GetUserByUserNameRequest request = new GetUserByUserNameRequest() { UserName = userName };
			GetUserResponse response = CallWebService<
				IUserManagementServicev1_0, GetUserByUserNameRequest, GetUserResponse>(
				m_service1_0, request, ( s, q ) => s.GetUserByUserName( q ) );
			return response.User; 
		}
		
		public void DeleteUser( Identifier userId ) {
			DeleteUserRequest request = new DeleteUserRequest() { UserId = userId };
			CallWebService<IUserManagementServicev1_0, DeleteUserRequest, DeleteUserResponse>(
				m_service1_0, request, ( s, q ) => s.DeleteUser( q ) );
		}

		public void DeleteUserByOrgDefinedId( string orgDefinedId ) {
			DeleteUserByOrgDefinedIdRequest request = new DeleteUserByOrgDefinedIdRequest() {
				OrgDefinedId = orgDefinedId
			};
			CallWebService<IUserManagementServicev1_0, DeleteUserByOrgDefinedIdRequest, DeleteUserResponse>(
				m_service1_0, request, ( s, q ) => s.DeleteUserByOrgDefinedId( q ) );
		}

		public void DeleteUserByUsername( string userName ) {
			DeleteUserByUserNameRequest request = new DeleteUserByUserNameRequest() { UserName = userName };
			CallWebService<IUserManagementServicev1_0, DeleteUserByUserNameRequest, DeleteUserResponse>(
				m_service1_0, request, ( s, q ) => s.DeleteUserByUserName( q ) );
		}

		public void UpdateUser( UserInfo user ) {
			UpdateUserRequest request = new UpdateUserRequest() { User = user };
			CallWebService<IUserManagementServicev1_0, UpdateUserRequest, UpdateUserResponse>(
				m_service1_0, request, ( s, q ) => s.UpdateUser( q ) );
		}

		public void ChangePassword( Identifier userId, string password ) {
			ChangePasswordRequest request = new ChangePasswordRequest() {
				UserId = userId,
				Password = password
			};
			CallWebService<IUserManagementServicev1_0, ChangePasswordRequest, ChangePasswordResponse>(
				m_service1_0, request, ( s, q ) => s.ChangePassword( q ) );
		}

        public RoleInfo[] GetRoles() {
			return CallWebService<IUserManagementServicev1_0, GetRolesRequest, GetRolesResponse>(
				m_service1_0, new GetRolesRequest(), ( s, q ) => s.GetRoles( q ) ).Roles;
        }

        public RoleInfo GetRole(Identifier roleId)
        {
			return CallWebService<IUserManagementServicev1_0, GetRoleRequest, GetRoleResponse>(
				m_service1_0, new GetRoleRequest() { RoleId = roleId }, ( s, q ) => s.GetRole ( q ) ).Role;
        }

		public void EnrollUser( Identifier userId, Identifier orgUnitId, Identifier roleId ) {
			EnrollUserRequest request = new EnrollUserRequest() {
				UserId = userId,
				OrgUnitId = orgUnitId,
				RoleId = roleId
			};
			CallWebService<IUserManagementServicev1_0, EnrollUserRequest, EnrollUserResponse>(
				m_service1_0, request, ( s, q ) => s.EnrollUser( q ) );
		}

		public void UnenrollUser( Identifier userId, Identifier orgUnitId ) {
			UnenrollUserRequest request = new UnenrollUserRequest() {
				UserId = userId,
				OrgUnitId = orgUnitId
			};
			CallWebService<IUserManagementServicev1_0, UnenrollUserRequest, UnenrollUserResponse>(
				m_service1_0, request, ( s, q ) => s.UnenrollUser( q ) );
		}

		public OrgUnitEnrollmentInfo GetOrgUnitEnrollment( Identifier userId, Identifier orgUnitId ) {
			GetOrgUnitEnrollmentRequest request = new GetOrgUnitEnrollmentRequest() {
				UserId = userId,
				OrgUnitId = orgUnitId
			};
			GetOrgUnitEnrollmentResponse response = CallWebService<
				IUserManagementServicev1_0, GetOrgUnitEnrollmentRequest, GetOrgUnitEnrollmentResponse>(
				m_service1_0, request, ( s, q ) => s.GetOrgUnitEnrollment( q ) );
			return response.OrgUnitEnrollment;
		}

		public OrgUnitEnrollmentInfo[] GetEnrollmentsByOrgUnit( Identifier orgUnitId ) {
			GetEnrollmentsByOrgUnitRequest request = new GetEnrollmentsByOrgUnitRequest() {
				OrgUnitId = orgUnitId
			};
			GetEnrollmentsByOrgUnitResponse response = CallWebService<
				IUserManagementServicev1_0, GetEnrollmentsByOrgUnitRequest, GetEnrollmentsByOrgUnitResponse>(
				m_service1_0, request, ( s, q ) => s.GetEnrollmentsByOrgUnit( q ) );
			return response.OrgUnitEnrollments;
		}

		public UserBasicInfo[] GetUsersByOrgUnitRole( Identifier orgUnitId, Identifier roleId ) {
			GetUsersByOrgUnitRoleRequest request = new GetUsersByOrgUnitRoleRequest() {
				OrgUnitId = orgUnitId,
				RoleId = roleId
			};
			GetUsersByOrgUnitRoleResponse response = CallWebService<
				IUserManagementServicev1_1, GetUsersByOrgUnitRoleRequest, GetUsersByOrgUnitRoleResponse>(
				m_service1_1, request, ( s, q ) => s.GetUsersByOrgUnitRole( q ) );
			return response.Users;
		}

		public CourseOfferingInfo1_1[] GetActiveCourseOfferings( Identifier userid ) {
			GetActiveCourseOfferingsRequest request = new GetActiveCourseOfferingsRequest() {
				UserId = userid
			};
			GetActiveCourseOfferingsResponse response = CallWebService<IUserManagementServicev1_2,
				GetActiveCourseOfferingsRequest, GetActiveCourseOfferingsResponse>(
				m_service1_2, request, ( s, q ) => s.GetActiveCourseOfferings( q ) );
			return response.CourseOfferings;
		}

		public void GetActiveCourseOfferingsEx ( Identifier userid,
			out CourseOfferingInfo1_1[] courseOfferings, out RoleInfo[] roles ) {

			GetActiveCourseOfferingsExRequest request = new GetActiveCourseOfferingsExRequest() {
				UserId = userid
			};
			GetActiveCourseOfferingsExResponse response = CallWebService<IUserManagementServicev1_3,
				GetActiveCourseOfferingsExRequest, GetActiveCourseOfferingsExResponse>(
				m_service1_3, request, ( s, q ) => s.GetActiveCourseOfferingsEx( q ) );
			courseOfferings = response.CourseOfferings;
			roles = response.Roles;
		}

		public void CreateAuditorRelationship( Identifier auditorUserId, Identifier auditeeUserId ) {
			CreateAuditorRelationshipRequest request = new CreateAuditorRelationshipRequest() {
				AuditorUserId = auditorUserId,
				AuditeeUserId = auditeeUserId
			};
			CallWebService<IUserManagementServicev1_4,
				CreateAuditorRelationshipRequest, CreateAuditorRelationshipResponse>(
				m_service1_4, request, ( s, q ) => s.CreateAuditorRelationship( q ) );
		}

		public void RemoveAuditorRelationship( Identifier auditorUserId, Identifier auditeeUserId ) {
			RemoveAuditorRelationshipRequest request = new RemoveAuditorRelationshipRequest() {
				AuditorUserId = auditorUserId,
				AuditeeUserId = auditeeUserId
			};
			CallWebService<IUserManagementServicev1_4,
				RemoveAuditorRelationshipRequest, RemoveAuditorRelationshipResponse>(
				m_service1_4, request, ( s, q ) => s.RemoveAuditorRelationship( q ) );
		}

		public UserBasicInfo[] GetAuditors( Identifier userId ) {
			GetAuditorsRequest request = new GetAuditorsRequest() { UserId = userId };
			GetAuditorsResponse response =
				CallWebService<IUserManagementServicev1_4, GetAuditorsRequest, GetAuditorsResponse>(
					m_service1_4, request, ( s, q ) => s.GetAuditors( q ) );
			return response.Users;
		}

		public UserBasicInfo[] GetAuditees( Identifier userId ) {
			GetAuditeesRequest request = new GetAuditeesRequest() { UserId = userId };
			GetAuditeesResponse response =
				CallWebService<IUserManagementServicev1_4, GetAuditeesRequest, GetAuditeesResponse>(
					m_service1_4, request, ( s, q ) => s.GetAuditees( q ) );
			return response.Users;
		}

		public void ActivateUsers( Identifier[] identifiers ) {
			ActivateUsersRequest request = new ActivateUsersRequest() { Users = identifiers };
			CallWebService<
				IUserManagementServicev1_5, ActivateUsersRequest, SetUserActivationStatusResponse>(
				m_service1_5, request, ( s, q ) => s.ActivateUsers( q ) );
		}

		public void DeactivateUsers( Identifier[] identifiers ) {
			DeactivateUsersRequest request = new DeactivateUsersRequest() { Users = identifiers };
			CallWebService<
				IUserManagementServicev1_5, DeactivateUsersRequest, SetUserActivationStatusResponse>(
				m_service1_5, request, ( s, q ) => s.DeactivateUsers( q ) );
		}

		public bool[] GetUserActivationStatus( Identifier[] identifiers ) {
			GetUserActivationStatusRequest request = new GetUserActivationStatusRequest() {
				Users = identifiers
			};
			GetUserActivationStatusResponse response = CallWebService<
				IUserManagementServicev1_5, GetUserActivationStatusRequest, GetUserActivationStatusResponse>(
				m_service1_5, request, ( s, q ) => s.GetUserActivationStatus( q ) );
			return response.Status;
		}

		public byte[] GetProfilePicture( Identifier userId ) {
			GetProfilePictureRequest request = new GetProfilePictureRequest() { UserId = userId };
			GetProfilePictureResponse response = CallWebService<IUserManagementServicev1_6,
				GetProfilePictureRequest, GetProfilePictureResponse>(
				m_service1_6, request, ( s, q ) => s.GetProfilePicture( q ) );
			return response.Photo;
		}
		
		public void UpdateProfile( Identifier userId, UserProfileType profile ) {
			UpdateProfileRequest request = new UpdateProfileRequest() {
				UserId = userId,
				UserProfile = profile
			};
			CallWebService<IUserManagementServicev1_6, UpdateProfileRequest, UpdateProfileResponse>(
				m_service1_6, request, ( s, q ) => s.UpdateProfile( q ) );
		}

		public void GetProfileByUser( Identifier userId,
			out UserProfileType profile, out UserPictureInfo profilePictureInfo ) {

			GetProfileByUserRequest request = new GetProfileByUserRequest() { UserId = userId };
			GetProfileByUserResponse response = CallWebService<
				IUserManagementServicev1_6, GetProfileByUserRequest, GetProfileByUserResponse>(
					m_service1_6, request, ( s, q ) => s.GetProfileByUser( q ) );
			profile = response.UserProfile;
			profilePictureInfo = response.UserPictureInfo;
		}

		public UserBasicInfo[] GetUsersByGroup( Identifier orgUnitId ) {
			GetUsersByGroupRequest request = new GetUsersByGroupRequest() { OrgUnitId = orgUnitId };
			GetUsersByGroupResponse response =
				CallWebService<IUserManagementServicev1_6, GetUsersByGroupRequest, GetUsersByGroupResponse>(
				m_service1_6, request, ( s, q ) => s.GetUsersByGroup( q ) );
			return response.Users;
		}

		public UserBasicInfo[] GetUsersBySection( Identifier orgUnitId ) {
			GetUsersBySectionRequest request = new GetUsersBySectionRequest() { OrgUnitId = orgUnitId };
			GetUsersBySectionResponse response = CallWebService<IUserManagementServicev1_6,
				GetUsersBySectionRequest, GetUsersBySectionResponse>(
				m_service1_6, request, ( s, q ) => s.GetUsersBySection( q ) );
			return response.Users;
		}

		public UserBasicInfo[] GetUsersByCourseOfferingsIndex(
			OrgUnitIdentifier[] courseOfferings, int minIndex, int maxIndex ) {

			GetUsersByCourseOfferingsIndexRequest request = new GetUsersByCourseOfferingsIndexRequest() {
				CourseOfferings = courseOfferings,
				MinIndex = minIndex,
				MaxIndex = maxIndex
			};
			GetUsersByCourseOfferingsIndexResponse response = CallWebService<IUserManagementServicev1_6,
				GetUsersByCourseOfferingsIndexRequest, GetUsersByCourseOfferingsIndexResponse>(
				m_service1_6, request, ( s, q ) => s.GetUsersByCourseOfferingsIndex( q ) );
			return response.Users;
		}

		public TaskInfo1_2[] GetPermittedTasksByUserOrgUnit( Identifier userId, Identifier orgUnitId ) {
			GetPermittedTasksByUserOrgUnitRequest request = new GetPermittedTasksByUserOrgUnitRequest() {
				UserId = userId,
				OrgUnitId = orgUnitId
			};
			GetPermittedTasksByUserOrgUnitResponse response = CallWebService<IUserManagementServicev1_6,
				GetPermittedTasksByUserOrgUnitRequest, GetPermittedTasksByUserOrgUnitResponse>(
				m_service1_6, request, ( s, q ) => s.GetPermittedTasksByUserOrgUnit( q ) );
			return response.Tasks;
		}

		protected override void Dispose( bool disposing ) {
			if (!m_disposed) {
				if (disposing) {
					m_service1_0.Dispose();
					m_service1_1.Dispose();
					m_service1_2.Dispose();
					m_service1_3.Dispose();
					m_service1_4.Dispose();
					m_service1_5.Dispose();
					m_service1_6.Dispose();
				}
				m_disposed = true;
			}
		}

		private static CreateUserRequest MapUserInfoToCreateUserRequest( UserInfo user ) {
			CreateUserRequest request = new CreateUserRequest();
			if( user.UserName != null ) {
				request.UserName = user.UserName.Value;
			}
			if( user.FirstName != null ) {
				request.FirstName = user.FirstName.Value;
			}
			if( user.LastName != null ) {
				request.LastName = user.LastName.Value;
			}
			if( user.OrgDefinedId != null ) {
				request.OrgDefinedId = user.OrgDefinedId.Value;
			}
			request.Addresses = user.Addresses;
			request.FormsOfContact = user.FormsOfContact;
			request.Demographics = user.Demographics;
			return request;
		}
	}
}