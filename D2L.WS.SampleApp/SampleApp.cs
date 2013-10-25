using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

using D2L.WS.Client;
using D2L.WS.Client.Proxy;
using D2L.WS.Client.Stubs;
using D2L.WS.Client.Stubs.Connection;

/*
 * Command-line parameters:
 * - command ("create" and "delete" supported)
 * - course data input file (XML)
 * - student data input file (XML)
 * - student role name in the Learning Environment
 * - teacher data input file (XML)
 * - teacher role name in the Learning Environment
 * - student enrollments data (XML)
 * - teacher assignments data (XML)
 */
namespace D2L.WS.SampleApp {
	public class SampleApp {
		private static string m_command;
		private static string m_courseDataFileName;
		private static string m_studentDataFileName;
		private static string m_studentRoleName;
		private static string m_teacherDataFileName;
		private static string m_teacherRoleName;
		private static string m_studentEnrollmentDataFileName;
		private static string m_teacherAssignmentDataFileName;
		private static RoleInfo m_studentRole;
		private static RoleInfo m_teacherRole;
		private static OrgUnitsServiceStub m_ouStub;
		private static UsersServiceStub m_userStub;

		public static void Main( string[] args ) {
			if( !CheckCommandLineParameters( args ) ) {
				DisplayUsage();
				return;
			}
			GetCommandLineParameters( args );
			SetUpWebServiceStubs();
			try {
				if( m_command == "create" ) {
					ImportCoursesUsersAndEnrollments();
				} else if( m_command == "delete" ) {
					DeleteUsersAndCourses();
				} else {
					Console.Out.WriteLine( "This command is not supported!" );
				}
			} finally {
				DisposeOfWebServiceStubs();
			}
		}

		private static void ImportCoursesUsersAndEnrollments() {
			Dictionary<string, CourseOfferingInfo> courseDictionary =
				new Dictionary<string, CourseOfferingInfo>();
			Dictionary<string, UserInfo> userDictionary = new Dictionary<string, UserInfo>();

			IdentifyRoles();
			CreateCourses( courseDictionary );
			CreateStudents( userDictionary );
			EnrollStudentsInCourses( courseDictionary, userDictionary );
			CreateTeachers( userDictionary );
			AssignTeachersToCourses( courseDictionary, userDictionary );
		}

		private static void CreateCourses( Dictionary<string, CourseOfferingInfo> courseDictionary ) {
			List<Course> allCourses = ReadListFromInputFile<Course>( m_courseDataFileName );
			CreateCourses( allCourses, courseDictionary );
		}
		
		private static void CreateStudents( Dictionary<string, UserInfo> userDictionary ) {
			List<User> allStudents = ReadListFromInputFile<User>( m_studentDataFileName );
			CreateUsers( allStudents, m_studentRole, userDictionary );
		}
		
		private static void EnrollStudentsInCourses( Dictionary<string, CourseOfferingInfo> courseDictionary, Dictionary<string, UserInfo> userDictionary ) {
			List<Enrollment> studentEnrollments = ReadListFromInputFile<Enrollment>( m_studentEnrollmentDataFileName );
			EnrollUsers( studentEnrollments, userDictionary, courseDictionary, m_studentRole );
		}
		
		private static void CreateTeachers( Dictionary<string, UserInfo> userDictionary ) {
			List<User> allTeachers = ReadListFromInputFile<User>( m_teacherDataFileName );
			CreateUsers( allTeachers, m_teacherRole, userDictionary );
		}

		private static void AssignTeachersToCourses( Dictionary<string, CourseOfferingInfo> courseDictionary, Dictionary<string, UserInfo> userDictionary ) {
			List<Enrollment> teacherAssignments = ReadListFromInputFile<Enrollment>( m_teacherAssignmentDataFileName );
			EnrollUsers( teacherAssignments, userDictionary, courseDictionary, m_teacherRole );
		}

		private static void CreateUsers(
			List<User> allUsers, RoleInfo role, Dictionary<string, UserInfo> userDictionary ) {

			if( null == role ) {
				return;
			}
			foreach( User user in allUsers ) {
				UserInfo createdUser = CreateUser( user, role );
				if( null != createdUser ) {
					AddUserToDictionary( userDictionary, createdUser );
				}
			}
		}

		private static void AddUserToDictionary(
			Dictionary<string, UserInfo> userDictionary, UserInfo createdUser ) {

			string orgDefinedId = createdUser.OrgDefinedId.Value;
			if( userDictionary.ContainsKey( orgDefinedId ) ) {
				userDictionary[ orgDefinedId ] = createdUser;
			} else {
				userDictionary.Add( orgDefinedId, createdUser );
			}
		}

		private static void CreateCourses(
			List<Course> allCourses, Dictionary<string, CourseOfferingInfo> courseDictionary ) {

			foreach( Course course in allCourses ) {
				CourseOfferingInfo createdCourse = CreateCourseOfferingBasedOnTemplate( course );
				AddCourseOfferingToDictionary( courseDictionary, createdCourse );
			}
		}

		private static void AddCourseOfferingToDictionary(
			Dictionary<string, CourseOfferingInfo> courseDictionary, CourseOfferingInfo createdCourse ) {

			if( courseDictionary.ContainsKey( createdCourse.Code ) ) {
				courseDictionary[ createdCourse.Code ] = createdCourse;
			} else {
				courseDictionary.Add( createdCourse.Code, createdCourse );
			}
		}

		private static CourseOfferingInfo CreateCourseOfferingBasedOnTemplate( Course courseData ) {
			CourseTemplateInfo createdTemplate = CreateCourseTemplate( courseData.Template );
			return CreateCourseOffering( createdTemplate, courseData.Offering );
		}

		private static CourseTemplateInfo CreateCourseTemplate( CourseTemplate templateInputData ) {
			return m_ouStub.CreateCourseTemplate(
				templateInputData.Name, templateInputData.Code, templateInputData.Path, true, null, null );
		}

		private static CourseOfferingInfo CreateCourseOffering(
			CourseTemplateInfo template, CourseOffering offeringInputData ) {

			return m_ouStub.CreateCourseOffering(
				offeringInputData.Name, offeringInputData.Code, offeringInputData.Path,
				template.OrgUnitId, true, null, null, true, true );
		}

		private static UserInfo CreateUser( User userData, RoleInfo role ) {
			UserInfo user = new UserInfo() {
				UserName = new UserInfoPrivacyUsernameType() { Value = userData.UserName },
				FirstName = new UserInfoPrivacy20Type() { Value = userData.FirstName },
				LastName = new UserInfoPrivacy20Type() { Value = userData.LastName },
				OrgDefinedId = new UserInfoPrivacy50Type() { Value = userData.OrgDefinedId }
			};
			try {
				return m_userStub.CreateUser( user, userData.Password, role.RoleId );
			} catch( BusinessErrorException e ) {
				Console.Out.WriteLine( String.Format(
					"Unable to create user with username {0}, it probably exists already",
					user.UserName ) );
				return null;
			}
		}

		private static void EnrollUsers(
			List<Enrollment> enrollments,
			Dictionary<string, UserInfo> userDictionary,
			Dictionary<string, CourseOfferingInfo> courseDictionary,
			RoleInfo role ) {

			if( null == role ) {
				return;
			}
			foreach( Enrollment enrollment in enrollments ) {
				EnrollUser( userDictionary, courseDictionary, role, enrollment );
			}
		}

		private static void EnrollUser(
			Dictionary<string, UserInfo> userDictionary,
			Dictionary<string, CourseOfferingInfo> courseDictionary,
			RoleInfo role, Enrollment enrollment) {

			if( !userDictionary.ContainsKey( enrollment.OrgDefinedId ) ) {
				Console.Out.WriteLine( String.Format(
					"Unexpected user org-defined ID {0} while processing enrollments",
					enrollment.OrgDefinedId ) );
				return;
			}
			if( !courseDictionary.ContainsKey( enrollment.CourseOfferingCode ) ) {
				Console.Out.WriteLine( String.Format(
					"Unexpected course offering code {0} while processing enrollments",
					enrollment.CourseOfferingCode ) );
				return;
			}
			UserInfo user = userDictionary[ enrollment.OrgDefinedId ];
			CourseOfferingInfo course = courseDictionary[ enrollment.CourseOfferingCode ];
			m_userStub.EnrollUser( user.UserId, course.OrgUnitId, role.RoleId );
		}

		private static void DeleteUsersAndCourses() {
			List<User> allStudents = ReadListFromInputFile<User>( m_studentDataFileName );
			DeleteUsers( allStudents );
			List<User> allTeachers = ReadListFromInputFile<User>( m_teacherDataFileName );
			DeleteUsers( allTeachers );
			List<Course> allCourses = ReadListFromInputFile<Course>( m_courseDataFileName );
			DeleteCourses( allCourses );
		}

		private static void DeleteUsers( List<User> allUsers ) {
			foreach( User user in allUsers ) {
				m_userStub.DeleteUserByOrgDefinedId( user.OrgDefinedId );
			}
		}

		private static void DeleteCourses( List<Course> allCourses ) {
			foreach( Course course in allCourses ) {
				DeleteCourseOffering( course.Offering );
				DeleteCourseTemplate( course.Template );
			}
		}

		private static void DeleteCourseOffering( CourseOffering offering ) {
			CourseOfferingInfo offeringBeingDeleted = m_ouStub.GetCourseOfferingByCode( offering.Code );

			if( offeringBeingDeleted != null ) {
				m_ouStub.DeleteCourseOffering( offeringBeingDeleted.OrgUnitId );
			} else {
				Console.Out.WriteLine( String.Format(
					"Unable to find course offering by code {0}!", offering.Code ) );
			}
		}

		private static void DeleteCourseTemplate( CourseTemplate template ) {
			CourseTemplateInfo templateBeingDeleted = m_ouStub.GetCourseTemplateByCode( template.Code );

			if( templateBeingDeleted != null ) {
				m_ouStub.DeleteCourseTemplate( templateBeingDeleted.OrgUnitId );
			} else {
				Console.Out.WriteLine( String.Format(
					"Unable to find course template by code {0}!", template.Code ) );
			}
		}

		private static List<T> ReadListFromInputFile<T>( string location ) where T : class, new() {
			try {
				return ReadListFromExistingInputFile<T>( location );
			} catch( FileNotFoundException ) {
				Console.Out.WriteLine( String.Format( "File not found: {0}", location ) );
			}
			return new List<T>();
		}

		private static List<T> ReadListFromExistingInputFile<T>( string fileName ) where T: class, new() {
			using( Stream fStream = File.OpenRead( fileName ) ) {
				return DeserializeInputFile<T>( fStream, fileName );
			}
		}

		private static List<T> DeserializeInputFile<T>( Stream fileStream, string fileName )
			where T : class, new() {

			XmlSerializer serializer = new XmlSerializer( typeof( List<T> ) );
			try {
				return serializer.Deserialize( fileStream ) as List<T>;
			} catch( InvalidOperationException ) {
				Console.Out.WriteLine( String.Format(
					"Unable to parse input file {0}, it has a syntax error", fileName ) );
			}
			return new List<T>();
		}

		private static void IdentifyRoles() {
			Dictionary<string, RoleInfo> roles = new Dictionary<string, RoleInfo>();
			foreach( RoleInfo r in m_userStub.GetRoles() ) {
				roles.Add( r.Name, r );
			}
			if( roles.ContainsKey( m_studentRoleName ) ) {
				m_studentRole = roles[ m_studentRoleName ];
			}
			if( roles.ContainsKey( m_teacherRoleName ) ) {
				m_teacherRole = roles[ m_teacherRoleName ];
			}
			CheckRoleIsFound( m_studentRoleName, m_studentRole );
			CheckRoleIsFound( m_teacherRoleName, m_teacherRole );
		}

		private static void CheckRoleIsFound( string roleName, RoleInfo role ) {
			if( null == role ) {
				Console.Out.WriteLine( String.Format(
					"Role named {0} was not found. " +
					"Creation and enrollment of users having this role is skipped.",
					roleName ) );
			}
		}
		
		private static void SetUpWebServiceStubs() {
			ServiceStubFactory factory = new ServiceStubFactory();
			m_ouStub = factory.CreateOrgUnitsServiceStub();
			m_userStub = factory.CreateUsersServiceStub();
			IWebServiceConnection connection = SetUpWebServiceConnection();
			m_ouStub.WebServiceConnection = connection;
			m_userStub.WebServiceConnection = connection;
		}

		/// <remarks>
		/// Remarks about the chained WebServiceConnectionBuilder call:
		/// 1.	If the authentication token service URL is not specified,
		///		the builder gets its default value from App.config
		///	2.	There is an overload of WithUserCredentials() method,
		///		which accepts IUserCredentialSource - implement that interface anyway you want
		///	2a.	If user credentials are not specified,
		///		the builder uses ConfigurationFileUserCredentialSource,
		///		which gets them from App.config
		///	3.	Authentication token type (purpose): "Web Service" is the default
		///	4.	Authentication strategy: reauthenticating (upon token expiration) is the default.
		///		Conservative strategy authenticates before every call.
		///	4a.	Optimistic and settings-based strategies are included mostly for illustration purposes.
		///	4b.	Setting the AuthenticationToken property on the Web service stub object
		///		is roughly equal to the optimistic strategy.
		/// </remarks>
		private static IWebServiceConnection SetUpWebServiceConnection() {
			string username = ConfigurationManager.AppSettings[ "username" ];
			string password = ConfigurationManager.AppSettings[ "password" ];
			string authServiceUrl = ConfigurationManager.AppSettings[ "authenticationServiceUrl" ];

			IWebServiceConnection connection =
				new WebServiceConnectionBuilder()
					.WithAuthenticationServiceUrl( authServiceUrl )
					.WithUserCredentials( username, password )
					.WithAuthenticationTokenType( "Web Service" )
					.WithAuthenticationStrategy( AuthenticationStrategyType.Reauthenticating )
					.Build();
			return connection;
		}

		private static void DisposeOfWebServiceStubs() {
			if( m_ouStub != null ) {
				m_ouStub.Dispose();
			}
			if( m_ouStub != null ) {
				m_userStub.Dispose();
			}
		}

		private static void GetCommandLineParameters( string[] args ) {
			m_command = args[ 0 ];
			m_courseDataFileName = args[ 1 ];
			m_studentDataFileName = args[ 2 ];
			m_studentRoleName = args[ 3 ];
			m_teacherDataFileName = args[ 4 ];
			m_teacherRoleName = args[ 5 ];
			m_studentEnrollmentDataFileName = args[ 6 ];
			m_teacherAssignmentDataFileName = args[ 7 ];
		}

		private static bool CheckCommandLineParameters( string[] args ) {
			return 8 == args.Length;
		}

		private static void DisplayUsage() {
			System.Console.WriteLine( "Expected 8 parameters: \n" +
				"	- Command (\"create\" or \"delete\")\n" +
				"	- Course data input file (XML)\n" +
				"	- student data input file (XML)\n" +
				"	- student role name in the Learning Environment\n" +
				"	- teacher data input file (XML)\n" +
				"	- teacher role name in the Learning Environment\n" +
				"	- student enrollments data (XML)\n" +
				"	- teacher assignments data (XML)" );
		}
	}
}