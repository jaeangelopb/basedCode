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

using RFIDAdmin.BLL.AccountsService;
using RFIDAdmin.BLL.GateTerminalsService;
using System.Text.RegularExpressions;

namespace RFID.Admin.Controllers
{
    public class CompanyController : Controller
    {
        GlobalModel global = new GlobalModel();
        // GET: Company
        public ActionResult Index()
        {
            ViewBag.user = global;
            return View();
        }
        public ActionResult List(string Search, int PageIndex, int PageSize)
        {
            int count =0;
            AccountBLL AccountBLL = new AccountBLL();
            AccountListEntityDC data = new AccountListEntityDC();
            GlobalModel global = new GlobalModel();
            string companyid = null;

            if (global.SelectUserRoleID != "1")
            {
                companyid = global.Company;
            }

            data = AccountBLL.GetAllAccount(Search, PageIndex, PageSize, out count);
            Dictionary<string, object> retData = new Dictionary<string, object>();


            // FOR RESPONSE
            retData.Add("data", data);
            retData.Add("total", count);

            return Json(retData, JsonRequestBehavior.AllowGet);
        }
      public ActionResult GateTerminalList(Guid AccountID, string Search, int PageIndex, int PageSize)
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
        public ActionResult SaveAccount(AccountModel model)
        {
            ViewBag.user = global;
            //    try
            //   {

            string id = model.Account.AccountID.ToString();
            var result = Regex.Replace(id, @"{}", string.Empty);
        //    Guid AcctID = result.ToString();
            AccountBLL AccountBLL = new AccountBLL();
            AccountEntityDC data = new AccountEntityDC();



            data.AccountID = result.ToGuid();
            data.AccountName = model.Account.AccountName;
            data.Branch = model.Account.Branch;
            data.Address = model.Account.Address;
            data.EmailAddress = model.Account.EmailAddress;
            data.TelephoneNumber = model.Account.TelephoneNumber;
            data.MobileNumber = model.Account.MobileNumber;
            data.CreatedBy = global.GlobalUserName;

            return Json(AccountBLL.SaveAccount(data), JsonRequestBehavior.AllowGet);
           // }
            //catch (Exception e)
            //{
            //  //////  resultmessageDC result = new ResultMessageDC()
            //  //// // {
            //  ////      Code = "400",
            //  ////      Description = e.Message
            //  //// // };
            //  //  return Json(result, JsonRequestBehavior.AllowGet);

            //}

        }

        //public ActionResult Delete(string id)
        //{
        //    //try
        //    //{          AccountBLL AccountBLL = new AccountBLL();
        //    return Json(CompanyBLL.Delete(id, global.GlobalUserName), JsonRequestBehavior.AllowGet);
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    ResultMessageDC result = new ResultMessageDC()
        //    //    {
        //    //        Code = "400",
        //    //        Description = e.Message
        //    //    };
        //    //    return Json(result, JsonRequestBehavior.AllowGet);

        //    //}
        //}
    }
}