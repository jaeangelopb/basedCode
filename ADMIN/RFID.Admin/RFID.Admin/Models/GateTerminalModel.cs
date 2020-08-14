using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RFID.Admin.Models
{
    public class GateTerminal
    {
        public Guid GateTerminalID
        {
            get; set;
        }
        public string GateTerminalName
        {
            get; set;
        }
        public Guid AccountID
        {
            get; set;
        }
        public string AccountName
        {
            get; set;
        }

        public bool IsActive
        {
            get; set;
        }
        public int GateTypeID
        {
            get; set;
        }

        public string CreatedBy
        {
            get; set;
        }
        public string CreatedDate
        {
            get; set;
        }
        public string UpdatedBy
        {
            get; set;
        }
        public string UpdatedDate
        {
            get; set;
        }
    }
    public class GateTerminalModel
    {
        public GateTerminal GateTerminal { get; set; }
    }
}