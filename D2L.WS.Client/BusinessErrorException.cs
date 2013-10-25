using System;

using D2L.WS.Client.Proxy;

namespace D2L.WS.Client {
	public class BusinessErrorException : SystemException {
		BusinessErrorInfo[] m_businessErrors;

        public BusinessErrorException( BusinessErrorInfo[] businessErrors ) : base() {
			m_businessErrors = businessErrors; 
        }

		public BusinessErrorException( string msg, BusinessErrorInfo[] businesErrors ) : base( msg ) {
            m_businessErrors = businesErrors; 
        }

        public BusinessErrorInfo[] BusinessErrors {
            get { return m_businessErrors; }
        }
	}
}
