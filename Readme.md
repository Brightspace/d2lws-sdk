To use Desire2Learn Web Services Developer's Toolkit for .NET, add assembly D2L.WS.Client to your project's references.

Getting Started
===============

Since you've already downloaded the Kit, all you need is to include assembly D2L.WS.Client (found in the "bin" folder) to your project's references.  If you prefer, you can also compile the Kit yourself.  The Kit requires .NET Framework version 4.0 or later.  The .NET framework may already be installed on your computer or can be downloaded for free from Microsoft's MSDN Web site.  We recommend Visual Studio 2008 or later for application development using the Kit.

Configuration
=============

In order to successfully connect to an instance of Desire2Learn Web Services, the Kit needs to know the URL where your services are located.  There are two ways to accomplish this.

The first method uses an application configuration file (app.config).  The following two settings are important:
  - d2lwsBaseUrl - Base URL of Desire2Learn Web services.  For example, if the user management service is located at http://yourdomain.com/D2LWS/UserManagementService-v1.asmx and the grades management service at http://yourdomain.com/D2LWS/GradesManagementService-v1.asmx, then this configuration variable should be set to http://yourdomain.com/D2LWS/
  - AuthenticationServiceUrl - URL of the Authentication Token Service. This service is part of the Learning Platform installation.

When you have this configuration in place, you can use class ServiceStubFactory and its methods like CreateAuthenticationServiceStub() and CreateOrgUnitsServiceStub() to create Web service stubs and then use the stubs to call the Web services.

The second method is to create a ServiceStubFactorySettings object in your application and inject it into ServiceStubFactory.

Authentication
==============

All functional (such as org-unit management, grades, etc.) Web service calls must be authenticated. One way to accomplish this is to set the AuthenticationToken property of the functional stub before making any calls to Web services.

To obtain an authentication token, call AuthenticationServiceStub method GetAuthenticationToken().  It requires three parameters:
  1. username
  2. password
  3. purpose. This parameter controls what type of authentication token will be issued. Different services may require different token types and have different token expiration settings, configurable by your Desire2Learn Learning Environment system administrator. Contact the administrator to find out the value(s) you should assign to this parameter.

Another way to maintain authenticated Web service connections is to set the WebServiceConnection property of the same functional stub.  Then you don't need to obtain and set authentication tokens. You can simply invoke the functional methods on the stub object and the WebServiceConnection object will manage authentication for you.

The easiest way to construct a WebServiceConnection object is to use WebServiceConnectionBuilder as shown in the SampleApp.

	var connection = new WebServiceConnectionBuilder()
	    .WithAuthenticationServiceUrl( authServiceUrl )
	    .WithUserCredentials( username, password )
	    .WithAuthenticationTokenType( purpose )
	    .WithAuthenticationStrategy( AuthenticationStrategyType.Reauthenticating )
	    .Build();

(Note: all calls in this chain between the constructor and Build are optional.)

You can then assign this object to one or more functional Web service stubs (for example, org-unit, user, and grades management service stubs sharing the same user credentials and purpose) and simply start making functional calls.

Because the WebServiceConnectionBuilder can obtain all of its inputs by convention, the chain of calls to build the connection can be as long as the above or as short as the following, or something in between:

var connection = new WebServiceConnectionBuilder().Build();

There are several algorithms (or strategies) of mixing functional and authentication calls, supplied by the Kit.  You can keep the default or pass one of the following values when calling  WithAthenticationStrategy() on the WebServiceConnectionBuilder.
  * Reauthenticating (default). If a functional Web service call fails because of the token expiration, the stub will call the authentication service (using the same inputs), get a new token, retry the functional call and keep going.
  * Conservative. Calls authentication service to get a new token before each functional call. The functional calls should never result in an expired token exception.
  * Optimistic. Calls authentication service only once, before the first functional call. Propagates all exceptions occurred during functional calls to the caller. This strategy is roughly functionally equivalent to setting the stub's AuthenticationToken property once at the very start.
  * Settings-based. This strategy counts the functional calls made through it and get a new authentication token just before it expires due to the number of usages.

Calling Functional Web Services
===============================

Once the AuthenticationToken (or WebServiceConnection) property of your Web service stub object is set, you can start using the stub to make Web service calls.  Each stub method typically does the same thing as the Web method with the same name.  For example, in class OrgUnitsServiceStub, method GetCourseOfferingByCode() has one parameter (course offering code) and returns a course offering object.  Desire2Learn Web services Developer and API Guide has the detailed documentation of each Web method.

Special Notes
=============

Creating a Course Offering with an Enforced/Automatic Path
----------------------------------------------------------

If you're using Web Services version 1.4.0 or higher, when calling CreateCourseOffering, set the path parameter to null or an empty string. The service will assign the path automatically and return it in the response object. The assigned path may look like this: /content/enforced/12345-foo/.

If you're connecting to the Web Services directly, without this developer kit, the above is the same as setting Path in CreateCourseOfferingRequest to null (or an empty string).
This is a better practice than trying to "guess" the path.

User Contact Information
------------------------

If you use Addresses of FormsOfContact properties of UserInfo class, the service interface accepts multiple addresses and multiple forms of contact, thus allowing future expansion, but the back-end can currently store only one of each. Please use constants "ExternalEmail" and "Home", respectively, to identify them. Here are the code examples:

	var user = new UserInfo();
	user.FormsOfContact = new FormOfContactInfo[] {
		new FormOfContactInfo() {
			Type = FormOfContactInfoType.Email,
			Name = "ExternalEmail",
			Value = "fred@frog.com"
		}
	};
	var user = new UserInfo();
	user.Addresses = new AddressInfo[] {
		new AddressInfo {
			...
			Name = "Home"
			...
		}
	};

UpdateGroupType operation
-------------------------

UpdateGroupType operation in the OrgUnitsManagementService uses a special OrgUnitIdentifier data type to specify the org-unit that owns the group type.  Besides the usual OrgUnitId field, this datatype has a property named OrgUnitRole, of data type OrgUnitSemanticRole.  This property is reserved for future expansion.  Its value can be set to the semantic role that matches the org-unit type of the group type owner. For example, if the group type belongs to a course offering, this property should be set to OrgUnitSemanticRole.CourseOffering:

	var groupType = new GroupTypeInfo() {
	    ...
	    OwnerIdentifier = new OrgUnitIdentifier() {
	        OrgUnitId = new Identifier() {
	            ...
	        },
		OrgUnitRole = OrgUnitSemanticRole.CourseOffering
	    },
	    ...
	};



