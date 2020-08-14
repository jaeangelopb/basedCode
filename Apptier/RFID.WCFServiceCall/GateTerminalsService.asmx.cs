using RFID.ASMXService.BusinessEntities;
using RFID.ASMXService.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using RFID.Helper;

namespace RFID.WCFServiceCall
{
    /// <summary>
    /// Summary description for GateTerminalsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GateTerminalsService : System.Web.Services.WebService
    {

        [WebMethod]
        public GateTerminalEntityDC SaveGateTerminal(GateTerminalEntityDC member)
        {
            GateTerminalManager Manager = new GateTerminalManager();
            member = Manager.SaveGateTerminal(member);
            return member;
        }
        [WebMethod]
        public GateTerminalListEntityDC GetAllGateTerminalByID(string AccountID, string Search,int PageIndex, int PageSize , out int count)
        {
           


            Guid AcctID = AccountID.ToGuid();
            GateTerminalManager member = new GateTerminalManager();
            GateTerminalListEntityDC ListAccount = new GateTerminalListEntityDC();
            ListAccount = member.GetAllGateTerminal(AcctID, Search, PageIndex, PageSize, out count);
            return ListAccount;
        }
        [WebMethod]
        public GateTypeListEntityDC GetAllGateType()
        {

            GateTerminalManager member = new GateTerminalManager();
            GateTypeListEntityDC ListAccount = new GateTypeListEntityDC();
            ListAccount = member.GetAllGateType();
            return ListAccount;
        }
    }
}
