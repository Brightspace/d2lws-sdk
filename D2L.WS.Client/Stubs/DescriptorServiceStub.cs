using System;

using D2L.WS.Client.Proxy;

namespace D2L.WS.Client.Stubs {
	public class DescriptorServiceStub : ServiceStubBase {
		private IDescriptorServicev1_0 m_service1_0;
		private IDescriptorServicev1_1 m_service1_1;
		
		internal DescriptorServiceStub(
			IDescriptorServicev1_0 service1_0, IDescriptorServicev1_1 service1_1 ) {

			m_service1_0 = service1_0;
			m_service1_1 = service1_1;
		}

        public ServiceDescriptorInfo GetServiceDescriptor() {
			GetServiceDescriptorResponse response = CallWebService(
				m_service1_0, new GetServiceDescriptorRequest(), ( s, q ) => s.GetServiceDescriptor( q ) );
			return response.ServiceDescriptor;
        }

		public long GetOrganizationId() {
			GetOrganizationIdResponse response = CallWebService(
				m_service1_1, new GetOrganizationIdRequest(), ( s, q ) => s.GetOrganizationId( q ) );
			return MapToNumericIdentifier( response.OrganizationId );
		}
		
		private long MapToNumericIdentifier( Identifier identifier ) {
			return Int64.Parse( identifier.Id );
		}

        protected override void Dispose( bool disposing ) {
			if (!m_disposed) {
				if (disposing) {
					m_service1_0.Dispose();
					m_service1_1.Dispose();
				}
				m_disposed = true;
			}
		}
	}
}