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
    public class MemberDAL
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        ConfigurationHelper configHelper = new ConfigurationHelper();
        Database Jaqen;

        const string spGetAllMember = "sp_GetAllMember";
        const string spInsertRFIDlog = "sp_InsertRFIDlog";
        const string spGetAllMemberByRFID = "sp_GetAllMemberByRFID";
        const string spGetTop5Rfidlog = "sp_GetTop5Rfidlog";
        const string spInsertMember = "sp_InsertMember";
        const string spGetAllRFIDByGateTerminal = "sp_GetAllRFIDByGateTerminal";
        const string spUpdateRFIDLog = "sp_UpdateRFIDLog";
        const string spGetLogByRFID = "sp_GetLogByRFID";
        const string spUpdateMember = "sp_UpdateMember";
        const string spVerifyUser = "sp_VerifyUser";
        const string spInserShadowMember = "sp_Insert_ShadowMember";
        const string spGetAllMemberByAccountId = "sp_GetAllMemberByAccountId";
        const string spDeleteMemberByAccountID = "sp_DeleteMemberByAccountID";
        const string spGetAllAdministrator = "sp_GetAllAdmin";
        const string spSaveAdministrator = "sp_SaveAdministrator";
        const string spGetAdministratorByAdminID = "sp_GetAdministratorByAdminID";
        const string spGetAllRole = "sp_GetAllRole";
        const string spGetAllGenderType = "sp_GetAllGenderType";
        const string spSaveAdminProperty = "sp_SaveAdminProperty";
        const string spGetAllAdminPropertyByAdminID = "sp_GetAllAdminPropertyByAdminID";


        public MemberDAL()
        {
            Jaqen = new SqlDatabase(configHelper.RFIDConnString);
        }


        public MemberEntityDC InsertMember(MemberEntityDC Members)
        {
            Guid MemberID = Guid.Empty;
            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spInsertMember;

                        sprocCmd.CommandText = spInsertMember;
                        


                        sprocCmd.Parameters.Add(new SqlParameter("@MemberID", Members.MemberID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.UniqueIdentifier
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@LastName", Members.LastName.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@FirstName", Members.FirstName.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@MiddleName", Members.MiddleName.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@EmailAddress", Members.EmailAddress.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@Affiliation", Members.Affiliation.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@Department", Members.Department.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@IDNumber", Members.IDNumber.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@MobileNumber", Members.MobileNumber.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@RFID", Members.RFID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@ProfilePhoto", Members.ProfilePhoto.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@SchoolYear", Members.SchoolYear.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@CreatedBy", Members.CreatedBy.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                MemberID = sprocReader["MemberID"].ToGuid();
                                Members.MemberID = MemberID;
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
            return Members;
        }
        public MemberEntityDC InserShadowMember(MemberEntityDC Members)
        {
            Guid MemberID = Members.MemberID;
            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spInserShadowMember;
                        sprocCmd.Parameters.Add(new SqlParameter("@MemberID", Members.MemberID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.UniqueIdentifier
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@LastName", Members.LastName.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@FirstName", Members.FirstName.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@MiddleName", Members.MiddleName.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@EmailAddress", Members.EmailAddress.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@Affiliation", Members.Affiliation.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@Department", Members.Department.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@IDNumber", Members.IDNumber.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@MobileNumber", Members.MobileNumber.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@RFID", Members.RFID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@ProfilePhoto", Members.ProfilePhoto.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@SchoolYear", Members.SchoolYear.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@CreatedBy", Members.CreatedBy.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                MemberID = sprocReader["MemberID"].ToGuid();
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
            return Members;
        }
        public MemberListEntityDC GetAllMember(string Search, string AccountID, int PageIndex, int PageSize, out int Count)
        {
            MemberListEntityDC Members = new MemberListEntityDC();
            List<MemberEntityDC> MemberList = new List<MemberEntityDC>();

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spGetAllMember;
                        sprocCmd.Parameters.Add(new SqlParameter("@Search", Search.ToStringDefault()) { SqlDbType = SqlDbType.NVarChar });
                        if (AccountID != "" && AccountID != null)
                        {
                            sprocCmd.Parameters.Add(new SqlParameter("@AccountID", AccountID.ToGuid()) { SqlDbType = SqlDbType.UniqueIdentifier });
                        }
                        sprocCmd.Parameters.Add(new SqlParameter("@PageIndex", PageIndex.ToInt()) { SqlDbType = SqlDbType.Int });
                        sprocCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize.ToInt()) { SqlDbType = SqlDbType.Int });

                        var CountResult = sprocCmd.CreateParameter();
                        CountResult.ParameterName = "@Count";
                        CountResult.Direction = ParameterDirection.Output;
                        CountResult.DbType = DbType.Int32;
                        sprocCmd.Parameters.Add(CountResult);

                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {

                                MemberEntityDC Member = new MemberEntityDC();
                                Member.MemberID = sprocReader["MemberID"].ToGuid();
                                Member.FirstName = sprocReader["FirstName"].ToStringDefault();
                                Member.MiddleName = sprocReader["MiddleName"].ToStringDefault();
                                Member.LastName = sprocReader["LastName"].ToStringDefault();
                          //      Member.AccountName = sprocReader["AccountName"].ToStringDefault();
                                Member.EmailAddress = sprocReader["EmailAddress"].ToStringDefault();
                                Member.Affiliation = sprocReader["Affiliation"].ToStringDefault();
                                Member.Department = sprocReader["Department"].ToStringDefault();
                                Member.IDNumber = sprocReader["IDNumber"].ToStringDefault();
                                Member.MobileNumber = sprocReader["MobileNumber"].ToStringDefault();
                                Member.RFID = sprocReader["RFID"].ToStringDefault();
                                Member.IsActive = sprocReader["IsActive"].ToBooleanDefault();
                                Member.SchoolYear = sprocReader["SchoolYear"].ToStringDefault();
                                Member.CreatedBy = sprocReader["CreatedBy"].ToStringDefault();
                                Member.CreatedDate = sprocReader["CreatedDate"].ToStringDefault();
                                Member.UpdatedBy = sprocReader["UpdatedBy"].ToStringDefault();
                                Member.UpdateDate = sprocReader["UpdateDate"].ToStringDefault();
                                MemberList.Add(Member);


                            }

                        }
                        Members.MemberList = MemberList;
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

            return Members;
        }
        public Guid UpdateRFIDlog(SMSRFIDLog RFIDlog)
        {
            Guid RFIDLogID = RFIDlog.RFIDLogID;
            using (DbConnection conn = Jaqen.CreateConnection())
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

                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
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
        public MemberEntityDC UpdateMember(MemberEntityDC Members)
        {
            Guid MemberID = Guid.Empty;
            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spUpdateMember;
                        sprocCmd.Parameters.Add(new SqlParameter("@MemberID", Members.MemberID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.UniqueIdentifier
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@LastName", Members.LastName.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@FirstName", Members.FirstName.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@MiddleName", Members.MiddleName.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@EmailAddress", Members.EmailAddress.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@Affiliation", Members.Affiliation.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@Department", Members.Department.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@IDNumber", Members.IDNumber.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@MobileNumber", Members.MobileNumber.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@RFID", Members.RFID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@ProfilePhoto", Members.ProfilePhoto.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@SchoolYear", Members.SchoolYear.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@CreatedBy", Members.CreatedBy.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                MemberID = sprocReader["MemberID"].ToGuid();
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
            return Members;
        }
        public MemberListEntityDC GetAllMemberByAccountId(string AccountID)
        {
            MemberListEntityDC Members = new MemberListEntityDC();
            List<MemberEntityDC> MemberList = new List<MemberEntityDC>();

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spGetAllMemberByAccountId;
                        if (AccountID != "")
                        {
                            sprocCmd.Parameters.Add(new SqlParameter("@AccountID", AccountID.ToGuid()) { SqlDbType = SqlDbType.UniqueIdentifier });
                        }

                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {

                                MemberEntityDC Member = new MemberEntityDC();
                                Member.MemberID = sprocReader["MemberID"].ToGuid();
                                Member.FirstName = sprocReader["FirstName"].ToStringDefault();
                                Member.MiddleName = sprocReader["MiddleName"].ToStringDefault();
                                Member.LastName = sprocReader["LastName"].ToStringDefault();
                                Member.EmailAddress = sprocReader["EmailAddress"].ToStringDefault();
                                Member.Affiliation = sprocReader["Affiliation"].ToStringDefault();
                                Member.Department = sprocReader["Department"].ToStringDefault();
                                Member.IDNumber = sprocReader["IDNumber"].ToStringDefault();
                                Member.MobileNumber = sprocReader["MobileNumber"].ToStringDefault();
                                Member.RFID = sprocReader["RFID"].ToStringDefault();
                                Member.IsActive = sprocReader["IsActive"].ToBooleanDefault();
                                Member.SchoolYear = sprocReader["SchoolYear"].ToStringDefault();
                                Member.CreatedBy = sprocReader["CreatedBy"].ToStringDefault();
                                Member.CreatedDate = sprocReader["CreatedDate"].ToStringDefault();
                                Member.UpdatedBy = sprocReader["UpdatedBy"].ToStringDefault();
                                Member.UpdateDate = sprocReader["UpdateDate"].ToStringDefault();
                                MemberList.Add(Member);


                            }

                        }
                        Members.MemberList = MemberList;

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

            return Members;
        }
        public MemberEntityDC DeleteMemberByAccountID(string AccountID)
        {
            MemberEntityDC Member = new MemberEntityDC();

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spDeleteMemberByAccountID;
                        if (AccountID != "")
                        {
                            sprocCmd.Parameters.Add(new SqlParameter("@AccountID", AccountID.ToGuid()) { SqlDbType = SqlDbType.UniqueIdentifier });
                        }

                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {

                                Member.MemberID = sprocReader["MemberID"].ToGuid();
                                Member.FirstName = sprocReader["FirstName"].ToStringDefault();
                                Member.MiddleName = sprocReader["MiddleName"].ToStringDefault();
                                Member.LastName = sprocReader["LastName"].ToStringDefault();
                                Member.EmailAddress = sprocReader["EmailAddress"].ToStringDefault();
                                Member.Affiliation = sprocReader["Affiliation"].ToStringDefault();
                                Member.Affiliation = sprocReader["Department"].ToStringDefault();
                                Member.IDNumber = sprocReader["IDNumber"].ToStringDefault();
                                Member.MobileNumber = sprocReader["MobileNumber"].ToStringDefault();
                                Member.RFID = sprocReader["RFID"].ToStringDefault();
                                Member.IsActive = sprocReader["IsActive"].ToBooleanDefault();
                                Member.SchoolYear = sprocReader["SchoolYear"].ToStringDefault();
                                Member.CreatedBy = sprocReader["CreatedBy"].ToStringDefault();
                                Member.CreatedDate = sprocReader["CreatedDate"].ToStringDefault();
                                Member.UpdatedBy = sprocReader["UpdatedBy"].ToStringDefault();
                                Member.UpdateDate = sprocReader["UpdateDate"].ToStringDefault();



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

            return Member;
        }
        public AdminEntityDC VerifyUser(string Username, string Password)
        {
            AdminEntityDC admin = new AdminEntityDC();

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spVerifyUser;
                        sprocCmd.Parameters.Add(new SqlParameter("@Username", Username.ToStringDefault()) { SqlDbType = SqlDbType.NVarChar });
                        sprocCmd.Parameters.Add(new SqlParameter("@Password", Password.ToStringDefault()) { SqlDbType = SqlDbType.NVarChar });



                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {

                                admin.adminID = sprocReader["adminID"].ToGuid();
                                admin.firstName = sprocReader["firstName"].ToStringDefault();
                                admin.middleName = sprocReader["middleName"].ToStringDefault();
                                admin.status = sprocReader["status"].ToStringDefault();
                                admin.emailAddress = sprocReader["emailAddress"].ToStringDefault();
                                admin.mobileNumber = sprocReader["mobileNumber"].ToStringDefault();
                                admin.genderID = sprocReader["genderID"].ToString();
                                admin.birthdate = sprocReader["birthdate"].ToStringDefault();
                                admin.address1 = sprocReader["address1"].ToStringDefault();
                                admin.address2 = sprocReader["address2"].ToStringDefault();
                                admin.zIP = sprocReader["zIP"].ToStringDefault();
                                admin.roleID = sprocReader["RoleID"].ToStringDefault();
                                admin.profilePhoto = sprocReader["profilePhoto"].ToStringDefault();
                                admin.createdBy = sprocReader["createdBy"].ToStringDefault();
                                admin.createdDate = sprocReader["createdDate"].ToStringDefault();
                                admin.updatedBy = sprocReader["updatedBy"].ToStringDefault();
                                admin.updatedDate = sprocReader["updatedDate"].ToStringDefault();
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

            return admin;
        }
        public AdminEntityDC SaveAdministrator(AdminEntityDC Members)
        {
            Guid AdminID = Guid.Empty;
            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spSaveAdministrator;
                        sprocCmd.Parameters.Add(new SqlParameter("@AdminID", Members.adminID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.UniqueIdentifier
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@FirstName", Members.firstName.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@MiddleName", Members.middleName.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@LastName", Members.lastName.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@EmailAddress", Members.emailAddress.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@RoleID", Members.roleID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.Int
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@MobileNumber", Members.mobileNumber.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@TelephoneNumber", Members.telephoneNumber.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@GenderID", Members.genderID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.Int
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@Password", Members.password.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@Birthdate", Members.birthdate.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@Address1", Members.address1.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@Address2", Members.address2.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@isActive", Members.isActive.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.Bit
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@Status", Members.status.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.Int
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@ZIP", Members.zIP.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.Int
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@ProfilePhoto", Members.profilePhoto.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@CreatedBy", Members.createdBy.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });
                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                AdminID = sprocReader["AdminID"].ToGuid();
                                Members.adminID = AdminID;
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
            return Members;
        }
        public AdminListEntityDC GetAllAdministrator(string Search, string AccountID, int PageIndex, int PageSize, out int Count)
        {
            AdminListEntityDC Members = new AdminListEntityDC();
            List<AdminEntityDC> MemberList = new List<AdminEntityDC>();

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spGetAllAdministrator;
                        sprocCmd.Parameters.Add(new SqlParameter("@Search", Search.ToStringDefault()) { SqlDbType = SqlDbType.NVarChar });
                        if (AccountID != "")
                        {
                            sprocCmd.Parameters.Add(new SqlParameter("@AccountID", AccountID.ToGuid()) { SqlDbType = SqlDbType.UniqueIdentifier });
                        }
                        sprocCmd.Parameters.Add(new SqlParameter("@PageIndex", PageIndex.ToInt()) { SqlDbType = SqlDbType.Int });
                        sprocCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize.ToInt()) { SqlDbType = SqlDbType.Int });

                        var CountResult = sprocCmd.CreateParameter();
                        CountResult.ParameterName = "@Count";
                        CountResult.Direction = ParameterDirection.Output;
                        CountResult.DbType = DbType.Int32;
                        sprocCmd.Parameters.Add(CountResult);

                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {

                                AdminEntityDC Member = new AdminEntityDC();
                                Member.adminID = sprocReader["adminID"].ToGuid();
                                Member.firstName = sprocReader["FirstName"].ToStringDefault();
                                Member.middleName = sprocReader["MiddleName"].ToStringDefault();
                                Member.lastName = sprocReader["LastName"].ToStringDefault();
                                Member.status = sprocReader["status"].ToStringDefault();
                                Member.emailAddress = sprocReader["emailAddress"].ToStringDefault();
                                Member.mobileNumber = sprocReader["mobileNumber"].ToStringDefault();
                                Member.telephoneNumber = sprocReader["telephoneNumber"].ToStringDefault();
                                Member.genderName = sprocReader["genderName"].ToStringDefault();
                                Member.birthdate = sprocReader["birthdate"].ToStringDefault();
                                Member.address1 = sprocReader["address1"].ToStringDefault();
                                Member.address2 = sprocReader["address2"].ToStringDefault();
                                Member.roleName = sprocReader["roleName"].ToString();
                                Member.profilePhoto = sprocReader["profilePhoto"].ToStringDefault();
                                Member.createdDate = sprocReader["createdDate"].ToStringDefault();
                                Member.createdBy = sprocReader["createdBy"].ToStringDefault();
                                Member.updatedDate = sprocReader["updatedDate"].ToStringDefault();
                                Member.updatedBy = sprocReader["updatedBy"].ToStringDefault();
                                MemberList.Add(Member);


                            }

                        }
                        Members.AdminList = MemberList;
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

            return Members;
        }
        public AdminEntityDC GetAdministratorByAdminID(string AdminID)
        {
            AdminEntityDC Member = new AdminEntityDC();
            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spGetAdministratorByAdminID;

                        if (AdminID != "")
                        {
                            sprocCmd.Parameters.Add(new SqlParameter("@AdminID", AdminID.ToGuid()) { SqlDbType = SqlDbType.UniqueIdentifier });
                        }
                        else
                        {
                            Guid NewAdminID = Guid.Empty;
                            sprocCmd.Parameters.Add(new SqlParameter("@AdminID", NewAdminID.ToGuid()) { SqlDbType = SqlDbType.UniqueIdentifier });
                        }



                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {


                                Member.adminID = sprocReader["adminID"].ToGuid();
                                Member.firstName = sprocReader["FirstName"].ToStringDefault();
                                Member.middleName = sprocReader["MiddleName"].ToStringDefault();
                                Member.lastName = sprocReader["LastName"].ToStringDefault();
                                Member.status = sprocReader["status"].ToStringDefault();
                                Member.roleID = sprocReader["roleID"].ToStringDefault();
                                Member.emailAddress = sprocReader["emailAddress"].ToStringDefault();
                                Member.mobileNumber = sprocReader["mobileNumber"].ToStringDefault();
                                Member.telephoneNumber = sprocReader["telephoneNumber"].ToStringDefault();
                                Member.genderID = sprocReader["genderID"].ToStringDefault();
                                Member.password = sprocReader["password"].ToStringDefault();
                                Member.birthdate = sprocReader["birthdate"].ToStringDefault();
                                Member.address1 = sprocReader["address1"].ToStringDefault();
                                Member.address2 = sprocReader["address2"].ToStringDefault();
                                Member.isActive = sprocReader["isActive"].ToStringDefault();
                                Member.roleID = sprocReader["roleID"].ToStringDefault();
                                Member.profilePhoto = sprocReader["profilePhoto"].ToStringDefault();



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

            return Member;
        }
        public RoleListEntityDC GetAllRole()
        {
            RoleListEntityDC Accounts = new RoleListEntityDC();
            List<RoleEntityDC> AccountList = new List<RoleEntityDC>();

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spGetAllRole;


                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {

                                RoleEntityDC Account = new RoleEntityDC();
                                Account.RoleID = sprocReader["RoleID"].ToInt();
                                Account.RoleName = sprocReader["RoleName"].ToStringDefault();
                                AccountList.Add(Account);

                            }

                        }

                        Accounts.RoleList = AccountList;
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

            return Accounts;
        }
        public GenderListEntityDC GetAllGenderType()
        {
            GenderListEntityDC Accounts = new GenderListEntityDC();
            List<GenderEntityDC> AccountList = new List<GenderEntityDC>();

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spGetAllGenderType;


                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {

                                GenderEntityDC Account = new GenderEntityDC();
                                Account.GenderID = sprocReader["GenderID"].ToInt();
                                Account.GenderName = sprocReader["GenderName"].ToStringDefault();
                                AccountList.Add(Account);

                            }

                        }

                        Accounts.GenderList = AccountList;
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

            return Accounts;
        }
        public AdminPropertyEntityDC SaveAdminProperty(AdminPropertyEntityDC RFIDlog)
        {

            Guid AdminPropertyID = Guid.Empty;
            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spSaveAdminProperty;

                        sprocCmd.Parameters.Add(new SqlParameter("@AdminPropertyID", RFIDlog.AdminPropertyID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.UniqueIdentifier
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@AdministratorID", RFIDlog.AdministratorID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.UniqueIdentifier
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@AccountID", RFIDlog.AccountID.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.UniqueIdentifier
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@IsActive", RFIDlog.IsActive.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.Bit
                        });
                        sprocCmd.Parameters.Add(new SqlParameter("@CreatedBy", RFIDlog.CreatedBy.ToDatabaseObj())
                        {
                            SqlDbType = SqlDbType.NVarChar
                        });

                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                AdminPropertyID = sprocReader["AdminPropertyID"].ToGuid();
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
        public AdminPropertyListEntityDC GetAllAdminPropertyByAdminID(Guid AdminID)
        {
            AdminPropertyListEntityDC Accounts = new AdminPropertyListEntityDC();
            List<AdminPropertyEntityDC> AccountList = new List<AdminPropertyEntityDC>();

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = spGetAllAdminPropertyByAdminID;

                        sprocCmd.Parameters.Add(new SqlParameter("@AdminID", AdminID.ToGuid()) { SqlDbType = SqlDbType.UniqueIdentifier });


                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {

                                AdminPropertyEntityDC Account = new AdminPropertyEntityDC();
                                Account.AdminPropertyID = sprocReader["AdminPropertyID"].ToGuid();
                                Account.AdministratorID = sprocReader["AdministratorID"].ToGuid();
                                Account.AccountID = sprocReader["AccountID"].ToGuid();
                                Account.AccountName = sprocReader["AccountName"].ToStringDefault();

                                Account.IsActive = sprocReader["IsActive"].ToBooleanDefault();
                                Account.CreatedDate = sprocReader["CreatedDate"].ToStringDefault();
                                Account.CreatedBy = sprocReader["CreatedBy"].ToStringDefault();
                                Account.UpdatedDate = sprocReader["UpdatedDate"].ToStringDefault();
                                Account.UpdatedBy = sprocReader["UpdatedBy"].ToStringDefault();
                                AccountList.Add(Account);

                            }

                        }

                        Accounts.AdminProperty = AccountList;
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

            return Accounts;
        }

    }

}
