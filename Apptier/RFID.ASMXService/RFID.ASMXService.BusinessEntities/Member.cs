using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.ASMXService.BusinessEntities
{
    public class Member
    {

        public Guid MemberID
        {
            get; set;
        }
        public Guid AccountID
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string AccountName
        {
            get; set;
        }
        public string MiddleName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string EmailAddress
        {
            get; set;
        }
        public string GenderID
        {
            get; set;
        }
        public string Birthday
        {
            get; set;
        }
        public int Affiliation
        {
            get; set;
        }
        public int Department
        {
            get; set;
        }
        public string IDNumber
        {
            get; set;
        }
        public string MobileNumber
        {
            get; set;
        }
        public string RFID
        {
            get; set;
        }
        public string ProfilePhoto
        {
            get; set;
        }
        public bool IsActive
        {
            get; set;
        }
        public string SchoolYear
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
        public string UpdateDate
        {
            get; set;
        }
    }

}
