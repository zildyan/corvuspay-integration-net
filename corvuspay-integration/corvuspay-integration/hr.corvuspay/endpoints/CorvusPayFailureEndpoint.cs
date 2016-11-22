using System.Web;

namespace corvuspay_integration.hr.corvuspay.endpoints
{
    interface CorvusPayFailureEndpoint
    {
        void CorvusPayFailure(HttpContext context);
    }
}
