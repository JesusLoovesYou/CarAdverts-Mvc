using System.Web.Mvc;

namespace CarAdverts.Web.Areas.Administrator
{
    public class AdministratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Administrator";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrator_default",
                "Administrator/{controller}/{action}/{id}",
                new { controller = "Test", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}