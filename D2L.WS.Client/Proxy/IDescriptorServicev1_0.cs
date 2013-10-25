using System;

namespace D2L.WS.Client.Proxy {
	public interface IDescriptorServicev1_0 : IHeaderService {
		IAsyncResult BeginGetServiceDescriptor( GetServiceDescriptorRequest GetServiceDescriptorRequest, AsyncCallback callback, object asyncState );
		void CancelAsync( object userState );
		GetServiceDescriptorResponse EndGetServiceDescriptor( IAsyncResult asyncResult );
		GetServiceDescriptorResponse GetServiceDescriptor( GetServiceDescriptorRequest GetServiceDescriptorRequest );
		void GetServiceDescriptorAsync( GetServiceDescriptorRequest GetServiceDescriptorRequest );
		void GetServiceDescriptorAsync( GetServiceDescriptorRequest GetServiceDescriptorRequest, object userState );
		event GetServiceDescriptorCompletedEventHandler GetServiceDescriptorCompleted;
	}
}
