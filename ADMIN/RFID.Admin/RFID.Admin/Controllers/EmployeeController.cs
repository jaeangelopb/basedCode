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
using RFIDAdmin.BLL.MembersService;

using RFIDAdmin.BLL.AccountsService;
namespace RFID.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        GlobalModel global = new GlobalModel();
        public ActionResult Index()
        {
            ViewBag.user = global;
            return View();
        }
        public ActionResult List( string Search, string AccountID, int PageIndex, int PageSize)
        {
            int Count = 0;
            string roleid = null;

            //if (global.SelectUserRoleID == "1")
            //    CompanyID = CompanyID == "-" ? "" : CompanyID;
            //else
            //{
            //    CompanyID = global.Company;
            //    roleid = global.SelectUserRoleID;
            //}

            MemberBLL EmployeeBLL = new MemberBLL();
            MemberListEntityDC data = new MemberListEntityDC();
            data = EmployeeBLL.GetAllMember(Search, AccountID, PageIndex, PageSize, out Count);
            Dictionary<string, object> retData = new Dictionary<string, object>();

            retData.Add("data", data);
            retData.Add("total", Count);

            return Json(retData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveEmployee(EmployeeModel model)
        {
            MemberBLL EmployeeBLL = new MemberBLL();
            MemberEntityDC data = new MemberEntityDC()
            {
                MemberID = model.Employee.MemberID,
                FirstName = model.Employee.FirstName,
                MiddleName = model.Employee.MiddleName,
                LastName = model.Employee.LastName,
                EmailAddress = model.Employee.EmailAddress,
                Affiliation = model.Employee.Affiliation,
                IDNumber = model.Employee.IDNumber,
                Department = model.Employee.Department,
                MobileNumber = model.Employee.MobileNumber,
                RFID = model.Employee.RFID,
                ProfilePhoto =model.Employee.IDNumber,
                IsActive = model.Employee.IsActive,
                SchoolYear = model.Employee.SchoolYear,
                CreatedBy = global.GlobalEmail
            };
            return Json(EmployeeBLL.InsertMember(data), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SetEmployeeStatus(string id, string status)
        {
            return View();
            //MemberBLL EmployeeBLL = new MemberBLL();
            //return Json(EmployeeBLL.SetEmployeeStatus(id, global.GlobalUserName, status), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllAffiliation()
        {
            int Count = 0;
            string roleid = null;

            AccountBLL EmployeeBLL = new AccountBLL();
            AffiliationListEntityDC data = new AffiliationListEntityDC();
            data = EmployeeBLL.GetAllAffiliation();
            Dictionary<string, object> retData = new Dictionary<string, object>();

            retData.Add("data", data);
            retData.Add("total", Count);

            return Json(retData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllDepartment()
        {
            int Count = 0;
            string roleid = null;

            AccountBLL EmployeeBLL = new AccountBLL();
            DepartmentListEntityDC data = new DepartmentListEntityDC();
            data = EmployeeBLL.GetAllDepartment();
            Dictionary<string, object> retData = new Dictionary<string, object>();

            retData.Add("data", data);
            retData.Add("total", Count);

            return Json(retData, JsonRequestBehavior.AllowGet);
        }
    }
}