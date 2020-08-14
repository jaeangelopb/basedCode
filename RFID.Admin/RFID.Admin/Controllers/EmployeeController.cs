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
        public ActionResult SaveEmployee(MemberModel model)
        {
            MemberBLL EmployeeBLL = new MemberBLL();
            MemberEntityDC data = new MemberEntityDC()
            {
                MemberID = model.Member.MemberID,
                AccountID = model.Member.AccountID,
                FirstName = model.Member.FirstName,
                MiddleName = model.Member.MiddleName,
                LastName = model.Member.LastName,
                EmailAddress = model.Member.EmailAddress,
                GenderID = model.Member.GenderID,
                Birthday = model.Member.Birthday,
                AffiliationID = model.Member.AffiliationID,
                IDNumber = model.Member.IDNumber,
                DepartmentID = model.Member.DepartmentID,
                MobileNumber = model.Member.MobileNumber,
                RFID = model.Member.RFID,
                ProfilePhoto = model.Member.ProfilePhoto,
                IsActive = model.Member.IsActive,
                SchoolYear = model.Member.SchoolYear,
                CreatedBy = model.Member.CreatedBy
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