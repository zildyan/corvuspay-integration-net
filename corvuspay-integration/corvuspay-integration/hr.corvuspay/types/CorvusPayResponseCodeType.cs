using System;
using System.ComponentModel;
using System.Reflection;

namespace corvuspay_integration.hr.corvuspay.types
{
    public enum CorvusPayResponseCodeType
    {
        [Description("Approved/Accepted")]
        CODE_0 = 0,
        [Description("Buyer needs to call his bank, the telephone number on the back of his payment card")]
        CODE_2 = 2,
        [Description("Declined")]
        CODE_100 = 100,
        [Description("Invalid Service Establishment")]
        CODE_199 = 199,
        [Description("Refund Accepted")]
        CODE_400 = 400,
        [Description("Technical Error / Unable to Process Request")]
        CODE_909 = 909,
        [Description("Host Link Down")]
        CODE_912 = 912,
        [Description("Transaction Not Found")]
        CODE_930 = 930,
        [Description("Card Expired")]
        CODE_931 = 931,
        [Description("Card Expired")]
        CODE_1001 = 1001,
        [Description("Card Suspicious")]
        CODE_1002 = 1002,
        [Description("Card Suspended")]
        CODE_1003 = 1003,
        [Description("Card Stolen")]
        CODE_1004 = 1004,
        [Description("Card Lost")]
        CODE_1005 = 1005,
        [Description("Card Not Found")]
        CODE_1011 = 1011,
        [Description("Cardholder Not Found")]
        CODE_1012 = 1012,
        [Description("Account Not Found")]
        CODE_1014 = 1014,
        [Description("Invalid Request")]
        CODE_1015 = 1015,
        [Description("Insufficient Funds")]
        CODE_1016 = 1016,
        [Description("Previously ReverseD")]
        CODE_1017 = 1017,
        [Description("Previously Reversed")]
        CODE_1018 = 1018,
        [Description("Further Activity Prevents Reversal")]
        CODE_1019 = 1019,
        [Description("Further Activity Prevents Void")]
        CODE_1020 = 1020,
        [Description("Original Transaction Has Been Voided")]
        CODE_1021 = 1021,
        [Description("Card Does Not Support Preauthorizations")]
        CODE_1022 = 1022,
        [Description("Only the Fully Authenticated 3D-Secure Transactions Are Allowed With Empty CVV")]
        CODE_1023 = 1023,
        [Description("Installments Are Not Allowed For This Card")]
        CODE_1024 = 1024,
        [Description("Transaction With Installments Cannot Be Sent As Preauthorization")]
        CODE_1025 = 1025,
        [Description("Installments Are Not Allowed For Non ZABA Cards")]
        CODE_1026 = 1026,
        [Description("Transaction Declined")]
        CODE_1050 = 1050,
        [Description("Payment number is out of sequence")]
        CODE_1051 = 1051,
        [Description("Missing Fields")]
        CODE_1802 = 1802,
        [Description("Extra Fields Exist")]
        CODE_1803 = 1803,
        [Description("Invalid Card Number")]
        CODE_1804 = 1804,
        [Description("Card Not Active")]
        CODE_1806 = 1806,
        [Description("Card Not Configured")]
        CODE_1808 = 1808,
        [Description("Invalid Amount")]
        CODE_1810 = 1810,
        [Description("System Error - Database")]
        CODE_1811 = 1811,
        [Description("System Error - Transaction")]
        CODE_1812 = 1810,
        [Description("Cardholder Not Active")]
        CODE_1813 = 1813,
        [Description("Cardholder Not Configured")]
        CODE_1814 = 1814,
        [Description("Cardholder Expired")]
        CODE_1815 = 1815,
        [Description("Original Not Found")]
        CODE_1816 = 1816,
        [Description("Usage Limit Reached")]
        CODE_1817 = 1817,
        [Description("Configuration Error")]
        CODE_1818 = 1818,
        [Description("Invalid Terminal")]
        CODE_1819 = 1819,
        [Description("Inactive Terminal")]
        CODE_1820 = 1820,
        [Description("Invalid Merchant")]
        CODE_1821 = 1821,
        [Description("Duplicate Entity")]
        CODE_1822 = 1822,
        [Description("Invalid Acquirer")]
        CODE_1823 = 1823,
        [Description("Invalid Expiration Date")]
        CODE_2000 = 2000,
        [Description("Failed 3D secure authentication")]
        CODE_2010 = 2010,
        [Description("RISK : Number of Repeats per PAN")]
        CODE_5001 = 5001,
        [Description("RISK : Number of Repeats per BIN")]
        CODE_5003 = 5003,
        [Description("RISK : Percentage of Declined Transactions")]
        CODE_5005 = 5005,
        [Description("RISK : Number of Refunded Transactions")]
        CODE_5006 = 5006,
        [Description("RISK : Percentage Increment of Sum on Amount of Refunded Transactions")]
        CODE_5007 = 5007,
        [Description("RISK : Number of Chargebacks")]
        CODE_5009 = 5009,
        [Description("RISK : Sum on Amount of Chargebacks")]
        CODE_5010 = 5010,
        [Description("RISK : Number of Retrieval Requests")]
        CODE_5011 = 5011,
        [Description("RISK : Sum on Amount of Retrieval Requests")]
        CODE_5012 = 5012,
        [Description("RISK : Average Amount per Transaction")]
        CODE_5013 = 5013,
        [Description("RISK : Percentage Increment of Average Amount per Transaction")]
        CODE_5014 = 5014,
        [Description("RISK : Percentage Increment of Number of Transactions")]
        CODE_5015 = 5015,
        [Description("RISK : Total Sum on Amount")]
        CODE_5016 = 5016,
        [Description("RISK : Percentage Increment of Total Sum on Amount")]
        CODE_5017 = 5017,
        [Description("RISK : Minimum Amount per Transaction")]
        CODE_5018 = 5018,
        [Description("RISK : Maximum Amount per Transaction")]
        CODE_5019 = 5019,
        [Description("RISK : Number of Approved Transactions per PAN")]
        CODE_5020 = 5020,
        [Description("RISK : Sum on Amount of Approved Transactions per PAN")]
        CODE_5021 = 5021,
        [Description("RISK : Sum on Amount of Approved Transactions per BIN")]
        CODE_5022 = 5022,
        [Description("RISK : Number of Approved Transactions per PAN and MCC on Amount")]
        CODE_5023 = 5023,
        [Description("RISK : Number of Repeats per IP")]
        CODE_5050 = 5050,
        [Description("RISK : Number of Repeats per Cardholder name")]
        CODE_5051 = 5051,
        [Description("RISK : Number of Repeats per Cardholder e-mail")]
        CODE_5052 = 5052      
    }
}