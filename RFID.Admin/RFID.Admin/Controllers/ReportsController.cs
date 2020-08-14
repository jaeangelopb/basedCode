using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using RFID.Admin.Models;
using RFID.Admin.Common;
using RFID.Admin.Security;
using System.Collections.Generic;
using RFID.Admin.BLL;

namespace RFID.Admin.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports

        GlobalModel global = new GlobalModel();
        public ActionResult Index()
        {
            ViewBag.user = global;
            return View();
        }
        public ActionResult List(string Search, string AccountID, string StartDate, string EndDate, int PageIndex, int PageSize)
        {
            int Count = 0;
            Dictionary<string, object> data = new Dictionary<string, object>();
            // Dictionary<string, object> data = new Dictionary<string, object>();
            LogsBLL MemberBLL = new LogsBLL();
            if (StartDate == null) { 

                StartDate = string.Empty;
        }
                 if (EndDate == null) {

                EndDate = string.Empty;
            }
            if (AccountID == null)
            {

                AccountID = string.Empty;
            }
            var datas = MemberBLL.GetAllStudentLogs(Search, AccountID, StartDate, EndDate, PageIndex, PageSize, out Count);
            Dictionary<string, object> retData = new Dictionary<string, object>();

            data.Add("total", Count);
            data.Add("data", datas);
            //  retData.Add("total", count);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}