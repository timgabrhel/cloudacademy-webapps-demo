using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;

namespace ca_webapps.Controllers
{
    public class HomeController : Controller
    {
        public IConfigurationRoot Configuration { get; set; }

        public IActionResult Index()
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            ViewData["Environment"] = Configuration.Get<string>("Environment");
            ViewData["BuildVersion"] = Configuration.Get<string>("BuildVersion");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
