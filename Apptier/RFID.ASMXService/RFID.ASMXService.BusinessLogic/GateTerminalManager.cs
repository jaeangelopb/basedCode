using RFID.ASMXService.BusinessEntities;
using RFID.ASMXService.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.ASMXService.BusinessLogic
{
    public class GateTerminalManager
    {

        public GateTerminalListEntityDC GetAllGateTerminal(Guid AcctID, string Search, int PageIndex, int PageSize, out int Count)
        {
            GateTerminalListEntityDC productResponse = new GateTerminalListEntityDC();
            GateTerminalEntityDC member = new GateTerminalEntityDC();
            GateTerminalDAL memberDAL = new GateTerminalDAL();
            productResponse = memberDAL.GetAllGateTerminal(AcctID, Search, PageIndex, PageSize, out Count);
            return productResponse;
        }
        public GateTerminalEntityDC GetAllGateTerminalByGateTerminalID(Guid GateTerminalID)
        {
            GateTerminalEntityDC member = new GateTerminalEntityDC();
            GateTerminalDAL memberDAL = new GateTerminalDAL();
            member = memberDAL.GetAllGateTerminalByGateTerminalID(GateTerminalID);
            return member;
        }
        public GateTypeListEntityDC GetAllGateType()
        {
            GateTypeListEntityDC productResponse = new GateTypeListEntityDC();
            GateTypeEntityDC member = new GateTypeEntityDC();
            GateTerminalDAL memberDAL = new GateTerminalDAL();
            productResponse = memberDAL.GetAllGateType();
            return productResponse;
        }

        public GateTerminalEntityDC SaveGateTerminal(GateTerminalEntityDC member)
        {
            GateTerminalDAL memberDAL = new GateTerminalDAL();

            member = memberDAL.SaveGateTerminal(member);

            return member;
        }

    }
}
