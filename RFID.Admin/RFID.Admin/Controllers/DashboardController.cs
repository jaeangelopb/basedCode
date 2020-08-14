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
    public class DashboardController : Controller
    {
        GlobalModel global = new GlobalModel();
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.user = global;
            return View();
        }
        public ActionResult GetAllStudentLogs(string Search, string AccountID, string StartDate, string EndDate, int PageIndex, int PageSize)
        {
            int Count = 0;
            Dictionary<string, object> data = new Dictionary<string, object>();
            // Dictionary<string, object> data = new Dictionary<string, object>();
            LogsBLL MemberBLL = new LogsBLL();


         var datas= MemberBLL.GetAllStudentLogs(Search, AccountID, StartDate, EndDate, PageIndex, PageSize, out Count);
            //s  var recentLogs = GetAllStudentLogs(Search, AccountID, StartDate, EndDate, PageIndex, PageSize);
            Dictionary<string, object> retData = new Dictionary<string, object>();

            data.Add("data", datas);
          //  retData.Add("total", count);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}