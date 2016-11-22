using System;
using corvuspay_integration.hr.corvuspay.exceptions;

namespace corvuspay_integration.hr.corvuspay.exceptions
{
    public static class CorvusPayRuntimeExceptions
    {
        public class CorvusPayEnvironmentUndefinedException : Exception { }
        public class Sha1HashCodeInvalidException : Exception { }
        public class Sha1CalculatingHashInvalidFieldException : Exception { }
        public class MethodNotImplementedException : Exception { }
        public class InvalidNumberOfInstallments : Exception { }
        public class NecessaryFieldsNotSetException : Exception { }
        public class FormattedRequestFieldsEmptyException : Exception { }

        public class CorvusPayResponseParseException : Exception
        {
            public CorvusPayResponseParseException(Exception e) : base(e.Message) { }
        }

        public class ClientCertificateCreationException : Exception
        {
            public ClientCertificateCreationException(Exception e) : base(e.Message) { }
        }

        public class KeyStoreCreationException : Exception
        {
            public KeyStoreCreationException(Exception e) : base(e.Message) { }
        }

        public class TrustManagerFactoryCreationException : Exception
        {
            public TrustManagerFactoryCreationException(Exception e) : base(e.Message) { }
        }

        public class SslContextCreationException : Exception
        {
            public SslContextCreationException(Exception e) : base(e.Message) { }
        }

        public class HttpUrlConnectionException : Exception
        {
            public HttpUrlConnectionException(Exception e) : base(e.Message) { }
        }

        public class Sha1NoAlgorithmException : Exception
        {
            public Sha1NoAlgorithmException(Exception e) : base(e.Message) { }
        }

        public class CorvusPayInvalidResponse : Exception
        {
            public CorvusPayInvalidResponse(string e) : base(e) { }
        }

        public class HttpRespondStatusCodeNotOkException : Exception
        {
            public HttpRespondStatusCodeNotOkException(string e) : base(e) { }
        }
    }
}