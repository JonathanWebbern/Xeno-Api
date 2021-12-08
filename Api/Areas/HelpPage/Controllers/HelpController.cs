using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Api.Areas.HelpPage.ModelDescriptions;
using Api.Areas.HelpPage.Models;
using Api.Filters;
using DataAccess.Helpers;
using DataAccess.Models;
using DataAccess.Responses;
using DataAccess.Services;

namespace Api.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        private const string ErrorViewName = "Error";

        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            var sample = new Sample() { Id = 1, Name = "Jane Doe" };
            ViewBag.ResponseStructureSuccess = new Response<Sample>(sample);
            ViewBag.ResponseStructureFailed = new Response<Sample>(null)
            {
                Succeeded = false,
                Message = "404: Resource not found",
                StatusCode = HttpStatusCode.NotFound
            };
            var samples = new List<Sample>();
            samples.Add(sample);
            sample = new Sample() { Id = 2, Name = "Joe Bloggs" };
            samples.Add(sample);
            ViewBag.PagedResponseSuccess = PaginationHelper.CreatePagedResponse(samples, 8, new PaginationFilter() { PageNumber = 1, PageSize = 2 }, new UriService(), "api/people");
            ViewBag.PagedResponseFailed = new PagedResponse<Sample>(null, 0, 0) 
            {
                Succeeded = false,
                Message = "404: Resource not found",
                StatusCode = HttpStatusCode.NotFound
            };
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View(ErrorViewName);
        }

        public ActionResult ResourceModel(string modelName)
        {
            if (!String.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                ViewBag.ReturnUrl = Request.UrlReferrer;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }
    }
}