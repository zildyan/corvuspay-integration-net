namespace corvuspay_integration.hr.corvuspay.configuration
{
    public static class CorvusPayConfiguration
    {
        public static readonly string PRODUCTION_ENVIRONMENT_URL = "https://cps.corvus.hr/redirect";

        public static readonly string TEST_ENVIRONMENT_URL = "http://cps.corvus.dev/redirect";
                  
        public static readonly string COMPLETE_MAPPING = "/complete";
                  
        public static readonly string PARTIAL_COMPLETE_MAPPING = "/partial_complete";
                      
        public static readonly string CANCEL_MAPPING = "/cancel";
                      
        public static readonly string REFUND_MAPPING = "/refund";
                      
        public static readonly string PARTIAL_REFUND_MAPPING = "/partial_refund";
                      
        public static readonly string NEXT_SUBSCRIPTION_PAYMENT_MAPPING = "/next_sub_payment";
                      
        public static readonly string CHECK_STATUS_MAPPING = "/status";
                      
        public static readonly string CORVUSPAY_CERTIFICATE = "CorvusCPS.p12";
    }
}