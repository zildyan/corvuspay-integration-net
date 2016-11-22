using corvuspay_integration.hr.corvuspay.types;
using corvuspay_integration.hr.corvuspay.dto;


namespace corvuspay_integration.hr.corvuspay.services
{
    interface CorvusPayIntegrationService
    {
        CorvusPayEnvironmentType GetEnvironment();

        string GetCorvusPayUrl();

        string GetSecretKey();

        string GetStoreId();

        string GetCurrencyCode();

        string GetLanguage();

        string GetCorvusPaySubmitForm();

        string GetAbsoluteCertificatePath();

        string GetCertificatePassword();

        void ValidateTransaction(string orderNumber, string hashCode);

        void PopulateRequestData(CorvusPayRequestData requestData, string orderNumber, string[] parameters);

        void ProcessSubscription(string accountId, string subscriptionExpDate);

        void CompleteApiCall(string orderNumber);

        void CancelApiCall(string orderNumber);

        void RefundApiCall(string orderNumber);

        void CompleteForSubscriptionApiCall(string orderNumber);

        void ChargeNextSubscriptionPaymentApiCall(string orderNumber);

        void PartialCompleteApiCall(string orderNumber);

        void PartialRefundApiCall(string orderNumber);

        void CheckTransactionStatusApiCall(string orderNumber, string timestamp);
    }
}
