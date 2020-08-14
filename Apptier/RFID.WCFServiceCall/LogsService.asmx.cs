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
    /// Summary description for LogsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LogsService : System.Web.Services.WebService
    {
        public AuthHeader Authentication;

        [SoapHeader("Authentication")]
        [WebMethod]
        public RFIDLogEntityDC InsertRFIDLogs(RFIDLogEntityDC RFIDlog)
        {


                LogServiceManager memberManager = new LogServiceManager();
                memberManager.InsertRFIDlog(RFIDlog);
            
                SMSRFIDLog list = new SMSRFIDLog();
                List<SMSRFIDLog> listOfRFID = new List<SMSRFIDLog>();
                listOfRFID = memberManager.GetAllRFIDLog();
                int count = listOfRFID.Count();
                string smsurl = ConfigurationManager.AppSettings["SMSUrl"];
                int i = 0;

                if (count != 0)
                {

                    //do
                    //{
                    foreach (SMSRFIDLog logs in listOfRFID)
                    {
                        if (logs.LogType.ToInt() == 2)
                        {
                            try
                            {
                                if(logs.MobileNumber.Length == 12) { 
                                Console.WriteLine("Successfully Send:{0} ", listOfRFID[i].RFID);
                                string uri = smsurl + listOfRFID[i].MobileNumber + " &message-type=sms.automatic&message="
                               + "Reedley International School Log Out of " + listOfRFID[i].LastName + ", " + listOfRFID[i].FirstName + ", " + listOfRFID[i].MiddleName + ".  " + listOfRFID[i].DateTimeStamp +
                               " .System Generated SMS do not reply";


                                // Send the HTTP request to Diafaan SMS Server
                                WebRequest request = WebRequest.Create(uri);
                                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                                {
                                    // Get the HTTP response from Diafaan SMS Server
                                    Stream dataStream = response.GetResponseStream();
                                    using (StreamReader reader = new StreamReader(dataStream))
                                    {
                                        reader.ReadToEnd();
                                    }
                                }
                                }
                                SMSRFIDLog rfidLog = new SMSRFIDLog();
                                rfidLog.Status = logs.Status;
                                rfidLog.RFIDLogID = logs.RFIDLogID;
                                var updateMemb = memberManager.UpdateRFIDlog(rfidLog);
                                //var insertLogs = member.InsertRFIDlog(RFIDlog);

                            }
                            catch
                            {
                                throw;
                            }



                        }
                        else
                        {
                            try
                            {
                                    if (logs.MobileNumber.Length == 12)
                                    {
                                        Console.WriteLine("Successfully Send:{0} ", listOfRFID[i].RFID);
                                        string uri = smsurl + listOfRFID[i].MobileNumber + " &message-type=sms.automatic&message="
                                       + "Reedley International School Log In of " + listOfRFID[i].LastName + ", " + listOfRFID[i].FirstName + ", " + listOfRFID[i].MiddleName + ".  " + listOfRFID[i].DateTimeStamp +
                                       " .System Generated SMS do not reply";


                                        // Send the HTTP request to Diafaan SMS Server
                                        WebRequest request = WebRequest.Create(uri);
                                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                                        {
                                            // Get the HTTP response from Diafaan SMS Server
                                            Stream dataStream = response.GetResponseStream();
                                            using (StreamReader reader = new StreamReader(dataStream))
                                            {
                                                reader.ReadToEnd();
                                            }
                                        }
                                    }
                                SMSRFIDLog rfidLog = new SMSRFIDLog();
                                rfidLog.Status = logs.Status;
                                rfidLog.RFIDLogID = logs.RFIDLogID;
                                var updateMemb = memberManager.UpdateRFIDlog(rfidLog);

                            }
                            catch
                            {
                                throw;
                            }

                        }
                        //    i++;
                        //} while (i < count);
                    }
                }


         



            return RFIDlog;
        }


        //[SoapHeader("Authentication")]
        [WebMethod]
        public RFIDLogEntityDC GetLogsByRFID(string RFID)
        {
            RFIDLogEntityDC listOfRFID = new RFIDLogEntityDC();
            LogServiceManager member = new LogServiceManager();
            listOfRFID = member.GetLogsByRFID(RFID);
            return listOfRFID;
        }

        [WebMethod]
        public List<StudentLogEntityDC> GetAllStudentLogs(string Search, string AccountID, string StartDate, string EndDate, int PageIndex, int PageSize, out int Count)
        {
          
            List<StudentLogEntityDC> listOfRFID = new List<StudentLogEntityDC>();
            LogServiceManager member = new LogServiceManager();
            listOfRFID = member.GetAllStudentLogs(Search,AccountID,StartDate,EndDate,PageIndex,PageSize, out Count);
            return listOfRFID;
        }
    }
    public class AuthHeader : SoapHeader
    {
        public string Username;
        public string Password;
    }
}
