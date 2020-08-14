using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using RFID.ASMXService.BusinessEntities;
using RFID.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID.ASMXService.DataAccess
{
    public class LogDAL
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        ConfigurationHelper configHelper = new ConfigurationHelper();
        Database Reedley;

        const string spGetAllMember = "sp_GetAllMemberByID";
        const string spInsertRFIDlog = "sp_InsertRFIDlog";
        const string spGetAllMemberByRFID = "sp_GetAllMemberByRFID";
        const string spGetTop5Rfidlog = "sp_GetTop5Rfidlog";
        const string spInsertMember = "sp_InsertMember";
        const string spGetAllRFIDByGateTerminal = "sp_GetAllRFIDByGateTerminal";
        const string spUpdateRFIDLog = "sp_UpdateRFIDLog";
        const string spGetLogByRFID = "sp_GetLogByRFID";
        const string sp_GetAllStudentLogs = "sp_GetAllStudentLogs";
        public LogDAL()
        {
            Reedley = new SqlDatabase(configHelper.RFIDConnString);
        }
        
        public RFIDLogEntityDC InsertRFIDlog(RFIDLogEntityDC RFIDlog)
        {
            RFIDLogEntityDC logResult = new RFIDLogEntityDC();
            using (DbConnection conn = Reedley.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spInsertRFIDlog;

                        sprocCmd.Parameters.Add(new SqlParameter("@RFIDLogID", RFIDlog.RFIDLogID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.UniqueIdentifier
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@RFID", RFIDlog.RFID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@DateTimeStamp", RFIDlog.DateTimeStamp.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.DateTime
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@GateTerminalID", RFIDlog.GateTerminalID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.UniqueIdentifier
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@Status", RFIDlog.Status.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@LogType", RFIDlog.LogType.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });

                        using (IDataReader sprocReader = Reedley.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                logResult.RFIDLogID = sprocReader["RFIDLogID"].ToGuid();
                                logResult.DateTimeStamp = sprocReader["DateTimeStamp"].ToStringDefault();
                                logResult.LogType = sprocReader["LogType"].ToString();
                                logResult.GateTerminalID = sprocReader["GateTerminalID"].ToGuid();
                                logResult.Status = sprocReader["Status"].ToString();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
            }
            return RFIDlog;
        }

        public List<SMSRFIDLog> GetAllRFIDLog()
        {
            List<SMSRFIDLog> listOfRFID = new List<SMSRFIDLog>();
            using (DbConnection conn = Reedley.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spGetAllRFIDByGateTerminal;

                        using (IDataReader sprocReader = Reedley.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                SMSRFIDLog svc = new SMSRFIDLog();

                                svc.RFIDLogID = sprocReader["RFIDLogID"].ToGuid();
                                svc.RFID = sprocReader["RFID"].ToStringDefault();
                                svc.DateTimeStamp = sprocReader["DateTimeStamp"].ToStringDefault();
                                svc.LogType = sprocReader["LogType"].ToStringDefault();
                                svc.FirstName = sprocReader["FirstName"].ToStringDefault();
                                svc.LastName = sprocReader["LastName"].ToStringDefault();
                                svc.MiddleName = sprocReader["MiddleName"].ToStringDefault();
                                svc.MobileNumber = sprocReader["MobileNumber"].ToStringDefault();
                                svc.Status = sprocReader["Status"].ToStringDefault();
                                listOfRFID.Add(svc);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
            }

            return listOfRFID;
        }
        public RFIDLogEntityDC GetLogByRFID(string RFID)
        {
            RFIDLogEntityDC rfidLog = new RFIDLogEntityDC();

            using (DbConnection conn = Reedley.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spGetLogByRFID;
                        sprocCmd.Parameters.Add(new SqlParameter("@RFID", RFID)
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        using (IDataReader sprocReader = Reedley.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                rfidLog.RFIDLogID = sprocReader["RFIDLogID"].ToGuid();
                                rfidLog.RFID = sprocReader["RFID"].ToStringDefault();
                                rfidLog.DateTimeStamp = sprocReader["DateTimeStamp"].ToStringDefault();
                                rfidLog.LogType = sprocReader["LogType"].ToStringDefault();
                                rfidLog.Status = sprocReader["Status"].ToStringDefault();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
            }

            return rfidLog;
        }
        public Guid UpdateRFIDlog(SMSRFIDLog RFIDlog)
        {
            Guid RFIDLogID = RFIDlog.RFIDLogID;
            using (DbConnection conn = Reedley.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spUpdateRFIDLog;

                        sprocCmd.Parameters.Add(new SqlParameter("@RFIDLogID", RFIDlog.RFIDLogID.ToDatabaseObj()) { SqlDbType = SqlDbType.UniqueIdentifier });
                        sprocCmd.Parameters.Add(new SqlParameter("@Status", RFIDlog.Status.ToDatabaseObj()) { SqlDbType = SqlDbType.NVarChar });

                        using (IDataReader sprocReader = Reedley.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                RFIDLogID = sprocReader["RFIDLogID"].ToGuid();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
            }
            return RFIDLogID;
        }
        public List<StudentLogEntityDC> GetAllStudentLogs(string Search, string AccountID, string StartDate, string EndDate, int PageIndex, int PageSize, out int Count)
        {
            StudentLogListEntity Members = new StudentLogListEntity();
            List<StudentLogEntityDC> MemberList = new List<StudentLogEntityDC>();

            using (DbConnection conn = Reedley.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = sp_GetAllStudentLogs;
                        sprocCmd.Parameters.Add(new SqlParameter("@Search", Search.ToStringDefault()) { SqlDbType = SqlDbType.NVarChar });
                        if (AccountID != "")
                        {
                            sprocCmd.Parameters.Add(new SqlParameter("@AccountID", AccountID.ToGuid()) { SqlDbType = SqlDbType.UniqueIdentifier });
                        }
                        if (StartDate != "" && StartDate != null)
                        {
                            sprocCmd.Parameters.Add(new SqlParameter("@DateTimeStart", StartDate.ToDateTime()) { SqlDbType = SqlDbType.DateTime });
                        }
                        if (EndDate != "" && EndDate != null)
                        {
                            sprocCmd.Parameters.Add(new SqlParameter("@DateTimeEnd", EndDate.ToDateTime()) { SqlDbType = SqlDbType.DateTime });
                        }
                        sprocCmd.Parameters.Add(new SqlParameter("@PageIndex", PageIndex.ToInt()) { SqlDbType = SqlDbType.Int });
                        sprocCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize.ToInt()) { SqlDbType = SqlDbType.Int });


                        var CountResult = sprocCmd.CreateParameter();
                        CountResult.ParameterName = "@Count";
                        CountResult.Direction = ParameterDirection.Output;
                        CountResult.DbType = DbType.Int32;
                        sprocCmd.Parameters.Add(CountResult);

                        using (IDataReader sprocReader = Reedley.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {

                                StudentLogEntityDC Member = new StudentLogEntityDC();
                                Member.MemberID = sprocReader["MemberID"].ToGuid();
                                Member.FirstName = sprocReader["FirstName"].ToStringDefault();
                                Member.LastName = sprocReader["LastName"].ToStringDefault();
                                Member.IDNumber = sprocReader["IDNumber"].ToStringDefault();
                                Member.Affiliation = sprocReader["Affiliation"].ToStringDefault();
                                Member.Department = sprocReader["Department"].ToStringDefault();
                                Member.RFID = sprocReader["RFID"].ToStringDefault();
                                Member.DateTimeStamp = sprocReader["DateTimeStamp"].ToStringDefault();
                                Member.LogType = sprocReader["LogType"].ToStringDefault();
                                Member.GateTerminalName = sprocReader["GateTerminalName"].ToStringDefault();
                                MemberList.Add(Member);


                            }

                        }
                        Members.StudentLogList = MemberList;
                        Count = CountResult.Value.ToInt();

                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
            }

            return MemberList;
        }


    }

}
