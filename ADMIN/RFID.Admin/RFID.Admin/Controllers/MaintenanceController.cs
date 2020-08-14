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
using RFIDAdmin.BLL.GateTerminalsService;

namespace RFID.Admin.Controllers
{
    public class MaintenanceController : Controller
    {
        // GET: Maintenance
        GlobalModel global = new GlobalModel();
        public ActionResult Index()
        {
            ViewBag.user = global;
            return View();
        }
    }
}