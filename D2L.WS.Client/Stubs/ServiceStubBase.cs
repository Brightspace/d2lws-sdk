using System;
using System.Linq;
using System.Text;

using D2L.WS.Client.Proxy;
using D2L.WS.Client.Stubs.Connection;

namespace D2L.WS.Client.Stubs {
	public abstract class ServiceStubBase : IDisposable {
		protected bool m_disposed = false;

		public string AuthenticationToken { get; set; }
		public IWebServiceConnection WebServiceConnection { get; set; }
		public ResponseBase LastResponse { get; protected set; }

		protected ServiceStubBase() {
			WebServiceConnection = new WebServiceConnection();
		}

		protected abstract void Dispose( bool disposing );

		public void Dispose() {
			Dispose( true );
			GC.SuppressFinalize( this );
		}

		protected R CallWebService<S, Q, R>( S service, Q request, Func<S, Q, R> invokeWebMethod )
			where S : IHeaderService
			where Q : class
			where R : ResponseBase {

			service.RequestHeader = CreateRequestHeader();
			R response = WebServiceConnection.Invoke<S, Q, R>( service, request, invokeWebMethod );
			LastResponse = response;
			ValidateResponse( service.RequestHeader, service.ResponseHeader, response );
			return response;
		}

		private RequestHeaderInfo CreateRequestHeader() {
			RequestHeaderInfo requestHeader = new RequestHeaderInfo();
			requestHeader.Version = "1.0";
			requestHeader.CorellationId = Guid.NewGuid().ToString();
			requestHeader.AuthenticationToken = AuthenticationToken;
			return requestHeader;
		}

		private void ValidateResponse(
			RequestHeaderInfo requestHeader, ResponseHeaderInfo responseHeader, ResponseBase response ) {

			if( null == responseHeader ) {
				throw new ResponseValidationException( "response header is null" );
			}
			if( responseHeader.CorellationId != requestHeader.CorellationId ) {
				throw new ResponseValidationException( "request and response correlation IDs doesn't match!" );
			}
			ValidateResponseHeaderStatus( responseHeader, response );
		}

		private void ValidateResponseHeaderStatus( ResponseHeaderInfo header, ResponseBase response) {
			StatusInfo status = header.Status;
			if( StatusCode.Success == status.Code ) {
				return;
			}
			switch( header.Status.Code ) {
				case StatusCode.Unsupported:
					throw new ResponseValidationException(
						String.Format( "{0} is not supported", header.OperationName ) );
				case StatusCode.SystemFailure:
					HandleSystemFailureResponse( header );
					break;
				case StatusCode.BusinessRuleFailure:
					HandleBusinessErrorResponse( response );
					break;
			}
		}

		private void HandleSystemFailureResponse( ResponseHeaderInfo header ) {
			SystemErrorInfo[] systemErrors = header.Status.SystemErrors;
			if( null == systemErrors ) {
				throw new ArgumentNullException(
					"invalid response: status is system failure, but SystemErrors property is not set" );
			}
			string errorDetails = systemErrors.Aggregate<SystemErrorInfo, StringBuilder, string>(
				 new StringBuilder(),
				 ( b, e ) => b.AppendLine( e.Message + " - " + e.Description ),
				 b => b.ToString() );
			throw new ResponseValidationException(
				String.Format( "response failed for operation: {0} with {1} error(s). {2}!",
				header.OperationName, header.Status.SystemErrors.Length,
				errorDetails ) );
		}

		private void HandleBusinessErrorResponse( ResponseBase response ) {
			if( null == response ) {
				throw new ResponseValidationException(
					"invalid response: status is business-rule failure, but response is null" );
			}
			if( null == response.BusinessErrors ) {
				throw new ArgumentNullException(
					"invalid response: status is business-rule failure, " +
					"but BusinessErrors property is not set" );
			}
			throw new BusinessErrorException( response.BusinessErrors );
		}
	}
}