using System.Net.Http;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient httpClient;
        public HomeController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri("http://xeno-api.azurewebsites.net/api/");
        }

        [HttpGet]
        public ActionResult Index()
        {
            var result = httpClient.GetAsync(httpClient.BaseAddress + "films/1").Result;
            if (result.IsSuccessStatusCode)
            {
                string data = result.Content.ReadAsStringAsync().Result;
                ViewBag.ApiResult = data;
                ViewBag.Url = "films/1";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(string searchInput)
        {
            var result = httpClient.GetAsync(httpClient.BaseAddress + searchInput).Result;
            if (result.IsSuccessStatusCode)
            {
                var data2 = result.Content.ReadAsStringAsync().Result;
                ViewBag.ApiResult = data2;
            }
            else
            {
                var error = new { 
                    Status = result.StatusCode,
                    Message = result.ReasonPhrase
                };
                ViewBag.ApiResult = error;
            }
            ViewBag.Url = searchInput;
            return View();
        }
    }
}
