using System;
using System.Collections.Generic;
using corvuspay_integration.hr.corvuspay.dto;
using corvuspay_integration.hr.corvuspay.types;
using corvuspay_integration.hr.corvuspay.exceptions;
using corvuspay_integration.hr.corvuspay.configuration;
using corvuspay_integration.hr.corvuspay.utils;

namespace corvuspay_integration.hr.corvuspay.services.impl
{
    public abstract class AbstractCorvusPayIntegrationService : CorvusPayIntegrationService
    {
        CorvusPayHttpsPostService GetCorvusPayHttpsPostService()
        {
            return new CorvusPayHttpsPostServiceImpl();
        }

        public void CancelApiCall(string orderNumber)
        {
            throw new CorvusPayRuntimeExceptions.MethodNotImplementedException();
        }

        public void ChargeNextSubscriptionPaymentApiCall(string orderNumber)
        {
            throw new CorvusPayRuntimeExceptions.MethodNotImplementedException();
        }

        public void CheckTransactionStatusApiCall(string orderNumber, string timestamp)
        {
            throw new CorvusPayRuntimeExceptions.MethodNotImplementedException();
        }

        public void CompleteApiCall(string orderNumber)
        {
            throw new CorvusPayRuntimeExceptions.MethodNotImplementedException();
        }

        public void CompleteForSubscriptionApiCall(string orderNumber)
        {
            throw new CorvusPayRuntimeExceptions.MethodNotImplementedException();
        }

        public string GetCorvusPaySubmitForm()
        {
            return "CorvusPayPostPage.aspx";
        }

        public string GetCorvusPayUrl()
        {
            if (GetEnvironment().Equals(CorvusPayEnvironmentType.PRODUCTION))
                return CorvusPayConfiguration.PRODUCTION_ENVIRONMENT_URL;
            else if (GetEnvironment().Equals(CorvusPayEnvironmentType.TEST))
                return CorvusPayConfiguration.TEST_ENVIRONMENT_URL;
            else throw new CorvusPayRuntimeExceptions.CorvusPayEnvironmentUndefinedException();
        }

        public string GetCurrencyCode()
        {
            throw new NotImplementedException();
        }

        public CorvusPayEnvironmentType GetEnvironment()
        {
            throw new NotImplementedException();
        }

        public string GetLanguage()
        {
            throw new NotImplementedException();
        }

        public string GetSecretKey()
        {
            throw new NotImplementedException();
        }

        public string GetStoreId()
        {
            throw new NotImplementedException();
        }

        public string GetAbsoluteCertificatePath()
        {
            throw new NotImplementedException();
        }

        public string GetCertificatePassword()
        {
            throw new NotImplementedException();
        }
       
        public void PartialCompleteApiCall(string orderNumber)
        {
            throw new CorvusPayRuntimeExceptions.MethodNotImplementedException();
        }

        public void PartialRefundApiCall(string orderNumber)
        {
            throw new CorvusPayRuntimeExceptions.MethodNotImplementedException();
        }

        public void PopulateRequestData(CorvusPayRequestData requestData, string orderNumber, string[] parameters)
        {
            throw new NotImplementedException();
        }

        public void ProcessSubscription(string accountId, string subscriptionExpDate)
        {
            throw new CorvusPayRuntimeExceptions.MethodNotImplementedException();
        }

        public void RefundApiCall(string orderNumber)
        {
            throw new CorvusPayRuntimeExceptions.MethodNotImplementedException();
        }

        public void ValidateTransaction(string orderNumber, string hashCode)
        {
            if (!hashCode.Equals(CorvusPayHashUtil.CalculateSha1(new string[]{ GetSecretKey(), orderNumber})))
                throw new CorvusPayRuntimeExceptions.Sha1HashCodeInvalidException();
        }

        protected void PopulateNecessaryFieldsInternal(CorvusPayRequestData requestData, string orderNumber)
        {
            ValidateNecessaryFields(new string[] { orderNumber, GetStoreId(), GetLanguage(), GetCurrencyCode() });
            requestData.PutRequestField(CorvusPayRequestFieldType.TARGET, "_top");
            requestData.PutRequestField(CorvusPayRequestFieldType.MODE, "form");
            requestData.PutRequestField(CorvusPayRequestFieldType.STORE_ID, GetStoreId());
            requestData.PutRequestField(CorvusPayRequestFieldType.ORDER_NUMBER, orderNumber);
            requestData.PutRequestField(CorvusPayRequestFieldType.LANGUAGE, GetLanguage());
            requestData.PutRequestField(CorvusPayRequestFieldType.CURRENCY, GetCurrencyCode());
        }

        protected Dictionary<string, string> CompleteApiCallInternal(string orderNumber)
        {
            return ExecuteHttpsPost(CorvusPayConfiguration.COMPLETE_MAPPING, GetBasicRequestFields(orderNumber));
        }

        protected Dictionary<string, string> CancelApiCallInternal(string orderNumber)
        {
            return ExecuteHttpsPost(CorvusPayConfiguration.CANCEL_MAPPING, GetBasicRequestFields(orderNumber));
        }

        protected Dictionary<string, string> RefundApiCallInternal(string orderNumber)
        {
            return ExecuteHttpsPost(CorvusPayConfiguration.REFUND_MAPPING, GetBasicRequestFields(orderNumber));
        }

        protected Dictionary<string, string> CompleteForSubscriptionApiCallInternal(string orderNumber, string subscription, string paymentNumber, string accountId)
        {
            return ExecuteHttpsPost(CorvusPayConfiguration.COMPLETE_MAPPING, GetSubscriptionRequestFields(orderNumber, subscription, paymentNumber, accountId));
        }

        protected Dictionary<string, string> ChargeNextSubscriptionPaymentApiCallInternal(string orderNumber, string subscription, string paymentNumber, string accountId)
        {
            return ExecuteHttpsPost(CorvusPayConfiguration.NEXT_SUBSCRIPTION_PAYMENT_MAPPING, GetSubscriptionRequestFields(orderNumber, subscription, paymentNumber, accountId));
        }

        protected Dictionary<string, string> ChargeNextSubscriptionPaymentDifferentAmountApiCallInternal(string orderNumber, string subscription, string paymentNumber, string accountId, string newAmount)
        {
            ValidateNecessaryFields(new string[] { newAmount });
            var requestFields = GetSubscriptionRequestFields(orderNumber, subscription, paymentNumber, accountId);
            requestFields.Add(CorvusPayRequestFieldType.NEW_AMOUNT, newAmount);
            return ExecuteHttpsPost(CorvusPayConfiguration.NEXT_SUBSCRIPTION_PAYMENT_MAPPING, requestFields);
        }

        private Dictionary<CorvusPayRequestFieldType, string> GetSubscriptionRequestFields(string orderNumber, string subscription, string paymentNumber, string accountId)
        {
            ValidateNecessaryFields(new string[] { subscription, paymentNumber, accountId });
            var requestFields = GetBasicRequestFields(orderNumber);
            requestFields.Add(CorvusPayRequestFieldType.SUBSCRIPTION, subscription);
            requestFields.Add(CorvusPayRequestFieldType.PAYMENT_NUMBER, paymentNumber);
            requestFields.Add(CorvusPayRequestFieldType.ACCOUNT_ID, accountId);
            return requestFields;
        }

        protected Dictionary<string, string> PartialCompleteApiCallInternal(string orderNumber, string newAmount)
        {
            ValidateNecessaryFields(new string[] { newAmount });
            Dictionary<CorvusPayRequestFieldType, string> requestFields = GetBasicRequestFields(orderNumber);
            requestFields.Add(CorvusPayRequestFieldType.NEW_AMOUNT, newAmount);
            return ExecuteHttpsPost(CorvusPayConfiguration.PARTIAL_COMPLETE_MAPPING, requestFields);
        }

        protected Dictionary<string, string> PartialRefundApiCallInternal(string orderNumber, string newAmount)
        {
            ValidateNecessaryFields(new string[] { newAmount });
            Dictionary<CorvusPayRequestFieldType, string> requestFields = GetBasicRequestFields(orderNumber);
            requestFields.Add(CorvusPayRequestFieldType.NEW_AMOUNT, newAmount);
            return ExecuteHttpsPost(CorvusPayConfiguration.PARTIAL_REFUND_MAPPING, requestFields);
        }

        protected Dictionary<string, string> CheckTransactionStatusApiCallInternal(string orderNumber, string timestamp)
        {
            ValidateNecessaryFields(new string[] { GetStoreId(), orderNumber, GetStoreId(), GetCurrencyCode(), timestamp });
            var hash = CorvusPayHashUtil.CalculateSha1(new string[] { GetSecretKey(), orderNumber, GetStoreId(), GetCurrencyCode(), timestamp });
            var requestFields = new Dictionary<CorvusPayRequestFieldType, string>()
            {
                { CorvusPayRequestFieldType.STORE_ID, GetStoreId() },
                { CorvusPayRequestFieldType.ORDER_NUMBER, orderNumber },
                { CorvusPayRequestFieldType.HASH, hash},
                { CorvusPayRequestFieldType.CURRENCY, GetCurrencyCode() },
                { CorvusPayRequestFieldType.TIMESTAMP, timestamp }
            };

            return ExecuteHttpsPost(CorvusPayConfiguration.CHECK_STATUS_MAPPING, requestFields);
        }

        private Dictionary<CorvusPayRequestFieldType, string> GetBasicRequestFields(string orderNumber)
        {
            ValidateNecessaryFields(new string[] { GetStoreId(), orderNumber, GetStoreId() });
            var hash = CorvusPayHashUtil.CalculateSha1(new string[] { GetSecretKey(), orderNumber, GetStoreId() });
            return new Dictionary<CorvusPayRequestFieldType, string>()
            {
                { CorvusPayRequestFieldType.STORE_ID, GetStoreId() },
                { CorvusPayRequestFieldType.ORDER_NUMBER, orderNumber },
                { CorvusPayRequestFieldType.HASH, hash }
            };
        }

    
        private void ValidateNecessaryFields(string[] fields)
        {
            if (!CorvusPayMiscellaneousUtil.ValidateFields(fields))
                throw new CorvusPayRuntimeExceptions.NecessaryFieldsNotSetException();
        }

        private Dictionary<string, string> ExecuteHttpsPost(string requestMapping, Dictionary<CorvusPayRequestFieldType, string> requestFields)
        {
            return GetCorvusPayHttpsPostService().ExecuteHttpsPost(GetCorvusPayUrl() + requestMapping, GetAbsoluteCertificatePath(), GetCertificatePassword(), requestFields);
        }
    }
}