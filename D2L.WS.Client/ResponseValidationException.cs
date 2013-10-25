using System;
using System.Runtime.Serialization;

namespace D2L.WS.Client {
	public class ResponseValidationException : SystemException {
		public ResponseValidationException() : base() { }
		public ResponseValidationException( string msg ) : base( msg ) { }
		public ResponseValidationException( string msg, Exception ex ) : base( msg, ex ) { }
		protected ResponseValidationException( SerializationInfo info, StreamingContext context )
			: base( info, context ) { }
	}
}
