using RFIDAdmin.BLL.GateTerminalsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.Admin.BLL
{
    public class GateTerminalBLL
    {
        public GateTerminalListEntityDC GetAllGateTerminalByAccountID(Guid AccountID, string Search, int PageIndex, int PageSize, out int Count)
        {
            GateTerminalListEntityDC MemberListEntityDC = new GateTerminalListEntityDC();
            GateTerminalsServiceSoapClient membersrv = new GateTerminalsServiceSoapClient();

            return membersrv.GetAllGateTerminalByID(AccountID.ToString(), Search, PageIndex, PageSize,out Count);
        }
        //public GateTerminalListEntityDC GetAllGateTerminalByID(Guid AccountID)
        //{
        //    GateTerminalListEntity productResponse = new GateTerminalListEntity();
        //    GateTerminalListEntityDC MemberListEntityDC = new GateTerminalListEntityDC();
        //    //     MemberEntityDC MemberEntityDC = new MemberEntityDC();

        //    //    MemberListEntityDC AdminDC = new MemberListEntityDC();
        //    //      MemberListEntityDC = GateTerminalTranslator.TranslateEntityToDCList(productResponse);
        //    GateTerminalsServiceSoapClient membersrv = new GateTerminalsServiceSoapClient();

        //    return membersrv.GetAllGateTerminalByID(AccountID.ToString());
        //}
        public GateTypeListEntityDC GetAllGateType()
        {
            GateTypeListEntityDC MemberListEntityDC = new GateTypeListEntityDC();
            GateTerminalsServiceSoapClient membersrv = new GateTerminalsServiceSoapClient();

            return membersrv.GetAllGateType();
        }



        public GateTerminalEntityDC SaveGateTerminal(GateTerminalEntityDC member)
        {
            GateTerminalEntityDC AdminDC = new GateTerminalEntityDC();
            GateTerminalsServiceSoapClient membersrv = new GateTerminalsServiceSoapClient();
            return membersrv.SaveGateTerminal(member);


        }
    }
}
