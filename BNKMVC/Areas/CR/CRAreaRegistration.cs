using System.Web.Mvc;

namespace BNKMVC.Areas.CR
{
    public class CRAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CR";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CR_default",
                "CR/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}