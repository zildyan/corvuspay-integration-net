using System.Collections.Generic;
using corvuspay_integration.hr.corvuspay.types;
using corvuspay_integration.hr.corvuspay.utils;

namespace corvuspay_integration.hr.corvuspay.dto
{
    public class CorvusPayRequestData
    {
        private Dictionary<CorvusPayRequestFieldType, string> requestFields;

        public CorvusPayRequestData()
        {
            this.requestFields = new Dictionary<CorvusPayRequestFieldType, string>();
        }
    
        public void SetRequestFields(Dictionary<CorvusPayRequestFieldType, string> requestFields)
        {
            this.requestFields = requestFields;
        }

        public Dictionary<string, string> GetRequestFields()
        {
            var formattedRequestFields = new Dictionary<string, string>();
            foreach(var entry in this.requestFields)
            {
                formattedRequestFields.Add(entry.Key.ToString(), entry.Value);         
            }

            return formattedRequestFields;
        }
      
        public void PutRequestField(CorvusPayRequestFieldType fieldType, string value)
        {
            this.requestFields.Add(fieldType, value);
        }

        public void SetRequireCompleteOff()
        {
            PutRequestField(CorvusPayRequestFieldType.REQUIRE_COMPLETE, "false");
        }

        public void SetAllCardsAllDynamicInstallments(CorvusPayRequestData requestData)
        {
            PutRequestField(CorvusPayRequestFieldType.PAYMENT_ALL, CorvusPayFormatUtil.FormatAllDynamicInstallments());
        }

        public void SetAllCardsDynamicInstallments(int from, int to)
        {
            PutRequestField(CorvusPayRequestFieldType.PAYMENT_ALL, CorvusPayFormatUtil.FormatDynamicInstallments(from, to));
        }

        public void SetAllCardsOnlyOneInstallments(int installment)
        {
            PutRequestField(CorvusPayRequestFieldType.PAYMENT_ALL, CorvusPayFormatUtil.FormatOnlyOneInstallment(installment));
        }

        public void SetAllCardsOneWithFirstInstallments(int installment)
        {
            PutRequestField(CorvusPayRequestFieldType.PAYMENT_ALL, CorvusPayFormatUtil.FormatOneWithFirstInstallment(installment));
        }

        public void SetAllCardsOnlyFirstInstallments(CorvusPayRequestData requestData)
        {
            PutRequestField(CorvusPayRequestFieldType.PAYMENT_ALL, CorvusPayFormatUtil.FormatOnlyFirstInstallment());
        }
    }
}