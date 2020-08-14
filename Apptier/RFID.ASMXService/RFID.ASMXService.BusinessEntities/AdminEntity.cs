using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.ASMXService.BusinessEntities
{
    public partial class AdminEntityDC
    {
        public string accountName { get; set; }
        public string accountID { get; set; }
        public Guid adminID { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string status { get; set; }
        public string roleID { get; set; }
        public string roleName { get; set; }
        public string emailAddress { get; set; }
        public string mobileNumber { get; set; }
        public string telephoneNumber { get; set; }
        public string password { get; set; }
        public string genderID { get; set; }
        public string genderName { get; set; }
        public string birthdate { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string zIP { get; set; }
        public string isActive { get; set; }
        public string isForChangePassword { get; set; }
        public string profilePhoto { get; set; }
        public string createdDate { get; set; }
        public string createdBy { get; set; }
        public string updatedDate { get; set; }
        public string updatedBy { get; set; }

    }


}
