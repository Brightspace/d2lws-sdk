using System;

using D2L.WS.Client.Proxy;

namespace D2L.WS.Client.Stubs {
	public class ServiceStubFactory {
		private const string DESCRIPTOR_SERVICE_NAME = "DescriptorService-v1";
		private const string ORG_UNITS_SERVICE_NAME = "OrgUnitManagementService-v1";
		private const string USERS_SERVICE_NAME = "UserManagementService-v1";
		private const string GRADES_SERVICE_NAME = "GradesManagementService-v1";
		private static string WEB_SERVICE_FILE_EXTENSION = ".asmx";
		private static string NULL_BASE_URL_MESSAGE =
"Base URL for the D2L Web services cannot be null or empty. " +
"Please check your application configuration settings.";
		
		public ServiceStubFactorySettings Settings { get; set; }

		public ServiceStubFactory() {
			Settings = ServiceStubFactorySettings.Default;
		}

		public AuthenticationServiceStub CreateAuthenticationServiceStub() {
			AuthenticationTokenService service = new AuthenticationTokenService() {
				Url = Settings.AuthenticationServiceUrl,
				Timeout = Settings.Timeout
			};
			return new AuthenticationServiceStub( service );
		}

		public DescriptorServiceStub CreateDescriptorServiceStub() {
			string serviceUrl = GetServiceUrl( DESCRIPTOR_SERVICE_NAME );
			IDescriptorServicev1_0 service1_0 = new DescriptorServicev1_0() {
				Url = serviceUrl,
				Timeout = Settings.Timeout
			};
			IDescriptorServicev1_1 service1_1 = new DescriptorServicev1_1() {
				Url = serviceUrl,
				Timeout = Settings.Timeout
			};
			return new DescriptorServiceStub( service1_0, service1_1 );
		}

		public OrgUnitsServiceStub CreateOrgUnitsServiceStub() {
			string url = GetServiceUrl( ORG_UNITS_SERVICE_NAME );
			IOrgUnitManagementServicev1_0 service1_0 = new OrgUnitManagementServicev1_0() {
				Url = url,
				Timeout = Settings.Timeout
			};
			IOrgUnitManagementServicev1_1 service1_1 = new OrgUnitManagementServicev1_1() {
				Url = url,
				Timeout = Settings.Timeout
			};
			OrgUnitsServiceStub stub = new OrgUnitsServiceStub( service1_0, service1_1 );
			return stub;
		}

		public GradesServiceStub CreateGradesServiceStub() {
			string url = GetServiceUrl( GRADES_SERVICE_NAME );
			IGradesManagementServicev1_0 service1_0 = new GradesManagementServicev1_0() {
				Url = url,
				Timeout = Settings.Timeout
			};
			IGradesManagementServicev1_1 service1_1 = new GradesManagementServicev1_1() {
				Url = url,
				Timeout = Settings.Timeout
			};
			IGradesManagementServicev1_2 service1_2 = new GradesManagementServicev1_2() {
				Url = url,
				Timeout = Settings.Timeout
			};
			IGradesManagementServicev1_3 service1_3 = new GradesManagementServicev1_3() {
				Url = url,
				Timeout = Settings.Timeout
			};
			GradesServiceStub stub = new GradesServiceStub( service1_0, service1_1, service1_2, service1_3 );
			return stub;
		}

		public UsersServiceStub CreateUsersServiceStub() {
			string url = GetServiceUrl( USERS_SERVICE_NAME );
			IUserManagementServicev1_0 service1_0 = new UserManagementServicev1_0() {
				Url = url,
				Timeout = Settings.Timeout
			};
			IUserManagementServicev1_1 service1_1 = new UserManagementServicev1_1() {
				Url = url,
				Timeout = Settings.Timeout
			};
			IUserManagementServicev1_2 service1_2 = new UserManagementServicev1_2() {
				Url = url,
				Timeout = Settings.Timeout
			};
			IUserManagementServicev1_3 service1_3 = new UserManagementServicev1_3() {
				Url = url,
				Timeout = Settings.Timeout
			};
			IUserManagementServicev1_4 service1_4 = new UserManagementServicev1_4() {
				Url = url,
				Timeout = Settings.Timeout
			};
			IUserManagementServicev1_5 service1_5 = new UserManagementServicev1_5() {
				Url = url,
				Timeout = Settings.Timeout
			};
			IUserManagementServicev1_6 service1_6 = new UserManagementServicev1_6() {
				Url = url,
				Timeout = Settings.Timeout
			};
			return new UsersServiceStub(
				service1_0, service1_1, service1_2, service1_3, service1_4, service1_5, service1_6 );
		}

		private string GetServiceUrl( string serviceName ) {
			string baseUrl = Settings.BaseFunctionalServiceUrl;
			if( String.IsNullOrEmpty( baseUrl ) ) {
				throw new ArgumentNullException( NULL_BASE_URL_MESSAGE );
			}
			if( !baseUrl.EndsWith( "/" ) ) {
				baseUrl += "/";
			}
			return baseUrl + serviceName + WEB_SERVICE_FILE_EXTENSION;
		}
	}
}
