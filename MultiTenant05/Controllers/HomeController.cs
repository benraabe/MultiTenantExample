using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultiTenant05.Models;
using MultiTenant05.DataAccess;

namespace MultiTenant05.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            // Get the client host name from the incoming request.
            string host = this.Request.Headers["Host"].ToLower();

            // Retrieve the client-specific data from the data provider.
            IDataConnection provider = new TenantDataProvider();
            Tenant tenant = provider.GetTenant(host);

            // Create the PageModel.
            PageModel result = new PageModel()
            {
                Name = "Default",
                Title = "This is the default site.",
                Theme = string.Empty
            };

            // If client-specific data was returned, put it
            // in the PageModel.
            if (tenant != null)
            {
                result.Name = tenant.Name;
                result.Title = tenant.Title;
                result.Theme = tenant.Theme;
            }

            // Return the Index view with the PageModel data.
            return View(result);
        }
    }
}