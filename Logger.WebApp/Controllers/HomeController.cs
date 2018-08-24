using AutoMapper;
using Logger.Entity;
using Logger.Model;
using Logger.Util;
using Logger.WebApp.Models.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Logger.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string dd = DateTime.Now.ToString("yyyyMMdd");
            string wald = "sd" + dd;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(JobLoggerModel model)
        {
            var dict = new Dictionary<string, object> { { "tipo", 0 }, { "msg", "" } };

            try
            {
                //Maps.register();
                JobLogger oJobLogger = new JobLogger {
                    Configuration = model.Configuration,
                    Message = model.Message,
                    TypeMessage = model.TypeMessage
                };

                //Operation oOperation = new HomeRepository().SaveLogger(Mapper.Map<JobLogger>(model));
                Operation oOperation = new HomeRepository().SaveLogger(oJobLogger);

                dict["msg"] = string.Format("{0}: {1}", DateTime.Now.ToShortDateString(), oOperation.Message);

                bool success = oOperation.Success;
                TempData["Success"] = success;

            } catch(Exception ex)
            {
                dict["msg"] = ex.Message;
            }
            
            return Content(JsonConvert.SerializeObject(dict), "application/json");
        }
    }
}