using System.Web;

namespace corvuspay_integration.hr.corvuspay.endpoints
{
    interface CorvusPaySuccessEndpoint
    {
        void CorvusPaySuccess(HttpContext context);
    }
}
