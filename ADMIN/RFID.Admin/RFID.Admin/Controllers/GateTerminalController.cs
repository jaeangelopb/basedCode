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
using System.Text.RegularExpressions;

namespace RFID.Admin.Controllers
{
    public class GateTerminalController : Controller
    {
        // GET: GateTerminal
        GlobalModel global = new GlobalModel();
        public ActionResult Index(Guid AccountID)
        {
            ViewBag.AccountID = AccountID;
            ViewBag.user = global;
            return View();
        }
        public ActionResult List(Guid AccountID,string Search,int PageIndex, int PageSize)
        {
            int Count = 0;
            GateTerminalBLL AccountBLL = new GateTerminalBLL();
            GateTerminalListEntityDC data = new GateTerminalListEntityDC();
            GlobalModel global = new GlobalModel();
            string companyid = null;

            if (global.SelectUserRoleID != "1")
            {
                companyid = global.Company;
            }

            data = AccountBLL.GetAllGateTerminalByAccountID(AccountID, Search, PageIndex, PageSize, out Count);
            Dictionary<string, object> retData = new Dictionary<string, object>();


            // FOR RESPONSE
            retData.Add("data", data);
            retData.Add("total", Count);

            return Json(retData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveGateTerminal(GateTerminalModel model)
        {
            ViewBag.user = global;
            //    try
            //   {

            string id = model.GateTerminal.GateTerminalID.ToString();
            var result = Regex.Replace(id, @"{}", string.Empty);
            //    Guid AcctID = result.ToString();
            GateTerminalBLL GateTerminalBLL = new GateTerminalBLL();
            GateTerminalEntityDC data = new GateTerminalEntityDC();



            data.GateTerminalID = result.ToGuid();
            data.GateTerminalName = model.GateTerminal.GateTerminalName;
            data.AccountID = model.GateTerminal.AccountID;
            data.GateTypeID = model.GateTerminal.GateTypeID;
            data.IsActive = model.GateTerminal.IsActive;
            data.CreatedBy = global.GlobalUserName;

            return Json(GateTerminalBLL.SaveGateTerminal(data), JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetAllGateType()
        {
            string Count = "";
            string roleid = null;

            GateTerminalBLL EmployeeBLL = new GateTerminalBLL();
            GateTypeListEntityDC data = new GateTypeListEntityDC();
            data = EmployeeBLL.GetAllGateType();
            Dictionary<string, object> retData = new Dictionary<string, object>();

            retData.Add("data", data);
            retData.Add("total", Count);

            return Json(retData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveEmployee(GateTerminalModel model)
        {
            GateTerminalBLL EmployeeBLL = new GateTerminalBLL();
            GateTerminalEntityDC data = new GateTerminalEntityDC()
            {
                GateTerminalID = model.GateTerminal.GateTerminalID,
                GateTerminalName = model.GateTerminal.GateTerminalName,
                IsActive = model.GateTerminal.IsActive,
                CreatedBy = model.GateTerminal.CreatedBy,
            };
            return Json(EmployeeBLL.SaveGateTerminal(data), JsonRequestBehavior.AllowGet);
        }
    }
}