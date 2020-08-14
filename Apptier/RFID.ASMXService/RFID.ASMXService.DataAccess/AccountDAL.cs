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
    public class AccountDAL
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        ConfigurationHelper configHelper = new ConfigurationHelper();
        Database Jaqen;

        const string GET_ALL_ACCOUNT = "sp_GetAllAcccount";
        const string GET_ALL_ACCOUNT_AND_MEMBER_COUNT = "sp_GetAccountAndMemberCount";
        const string SAVE_ACCOUNT = "sp_SaveAccount";
        const string GET_ACCOUNT_BY_ID = "sp_GetAccountByID";
        const string SAVE_DEPARTMENT = "sp_SaveDepartment";
        const string SAVE_AFFILATION = "sp_SaveAffiliation";
        const string GET_ALL_DEPARTMENT = "sp_GetAllDepartment";
        const string GET_ALL_AFFILATION = "sp_GetAllAffiliation";
        
        public AccountDAL()
        {
            Jaqen = new SqlDatabase(configHelper.RFIDConnString);
        }


        public AccountListEntityDC GetAllAccount(string Search, int PageIndex, int PageSize, out int Count)
        {
            AccountListEntityDC Accounts = new AccountListEntityDC();
            List<AccountEntityDC> AccountList = new List<AccountEntityDC>();

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = GET_ALL_ACCOUNT;
                        sprocCmd.Parameters.Add(new SqlParameter("@Search", Search.ToStringDefault()) { SqlDbType = SqlDbType.NVarChar });
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

                                AccountEntityDC Account = new AccountEntityDC();
                                Account.AccountID = sprocReader["AccountID"].ToGuid();
                                Account.AccountName = sprocReader["AccountName"].ToStringDefault();
                                Account.Branch = sprocReader["Branch"].ToStringDefault();
                                Account.EmailAddress = sprocReader["EmailAddress"].ToStringDefault();
                                Account.TelephoneNumber = sprocReader["TelephoneNumber"].ToStringDefault();
                                Account.Address = sprocReader["Address"].ToStringDefault();
                                Account.Counts = sprocReader["Counts"].ToStringDefault();
                                Account.MobileNumber = sprocReader["MobileNumber"].ToString();
                                Account.CreatedBy = sprocReader["CreatedBy"].ToStringDefault();
                                Account.CreatedDate = sprocReader["CreatedDate"].ToStringDefault();
                                Account.UpdatedBy = sprocReader["UpdatedBy"].ToStringDefault();
                                Account.UpdatedDate = sprocReader["UpdatedDate"].ToStringDefault();
                                AccountList.Add(Account);

                            }

                        }
                        Accounts.AccountList = AccountList;
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

            return Accounts;
        }

        public AccountListEntityDC GetAllAccountMemberCount(string Search, int PageIndex, int PageSize, out int Count)
        {
            AccountListEntityDC Accounts = new AccountListEntityDC();
            List<AccountEntityDC> AccountList = new List<AccountEntityDC>();

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = GET_ALL_ACCOUNT_AND_MEMBER_COUNT;
                        sprocCmd.Parameters.Add(new SqlParameter("@Search", Search.ToStringDefault()) { SqlDbType = SqlDbType.NVarChar });
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

                                AccountEntityDC Account = new AccountEntityDC();
                                Account.AccountID = sprocReader["AccountID"].ToGuid();
                                Account.AccountName = sprocReader["AccountName"].ToStringDefault();
                                Account.Counts = sprocReader["Counts"].ToStringDefault();
                                AccountList.Add(Account);

                            }

                        }
                        Accounts.AccountList = AccountList;
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

            return Accounts;
        }

        public AccountListEntityDC GetAccountByID(Guid AccountID)
        {
            AccountListEntityDC Accounts = new AccountListEntityDC();
            List<AccountEntityDC> AccountList = new List<AccountEntityDC>();

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = GET_ACCOUNT_BY_ID;
                        sprocCmd.Parameters.Add(new SqlParameter("@AccountID", AccountID.ToGuid()) { SqlDbType = SqlDbType.UniqueIdentifier });



                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                AccountEntityDC Account = new AccountEntityDC();
                                Account.AccountID = sprocReader["AccountID"].ToGuid();
                                Account.AccountName = sprocReader["AccountName"].ToStringDefault();
                                Account.Branch = sprocReader["Branch"].ToStringDefault();
                                Account.EmailAddress = sprocReader["EmailAddress"].ToStringDefault();
                                Account.TelephoneNumber = sprocReader["TelephoneNumber"].ToStringDefault();
                                Account.Address = sprocReader["Address"].ToStringDefault();
                                Account.MobileNumber = sprocReader["MobileNumber"].ToString();
                                Account.CreatedBy = sprocReader["CreatedBy"].ToStringDefault();
                                Account.CreatedDate = sprocReader["CreatedDate"].ToStringDefault();
                                Account.UpdatedBy = sprocReader["UpdatedBy"].ToStringDefault();
                                Account.UpdatedDate = sprocReader["UpdatedDate"].ToStringDefault();
                                AccountList.Add(Account);

                            }

                        }
                        Accounts.AccountList = AccountList;

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
        public AccountEntityDC SaveAccount(AccountEntityDC parent)
        {
            Guid AccountID = Guid.Empty;

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = SAVE_ACCOUNT;
                        sprocCmd.Parameters.Add(new SqlParameter("@AccountID", parent.AccountID.ToGuid()) { SqlDbType = SqlDbType.UniqueIdentifier });
                        sprocCmd.Parameters.Add(new SqlParameter("@AccountName", parent.AccountName.ToDatabaseObj()) { SqlDbType = SqlDbType.NVarChar });
                        sprocCmd.Parameters.Add(new SqlParameter("@Branch", parent.Branch.ToDatabaseObj()) { SqlDbType = SqlDbType.NVarChar });
                        sprocCmd.Parameters.Add(new SqlParameter("@Address", parent.Address.ToDatabaseObj()) { SqlDbType = SqlDbType.NVarChar });
                        sprocCmd.Parameters.Add(new SqlParameter("@EmailAddress", parent.EmailAddress.ToDatabaseObj()) { SqlDbType = SqlDbType.NVarChar });
                        sprocCmd.Parameters.Add(new SqlParameter("@TelephoneNumber", parent.TelephoneNumber.ToDatabaseObj()) { SqlDbType = SqlDbType.NVarChar });
                        sprocCmd.Parameters.Add(new SqlParameter("@MobileNumber", parent.MobileNumber.ToDatabaseObj()) { SqlDbType = SqlDbType.NVarChar });
                        sprocCmd.Parameters.Add(new SqlParameter("@CreatedBy", parent.CreatedBy.ToDatabaseObj()) { SqlDbType = SqlDbType.NVarChar });
                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                AccountID = sprocReader["AccountID"].ToGuid();
                                parent.AccountID = AccountID;
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

            return parent;
        }

        public DepartmentEntityDC SaveDepertment(DepartmentEntityDC parent)
        {
           int AffiliationID = 0;

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = SAVE_DEPARTMENT;
                        sprocCmd.Parameters.Add(new SqlParameter("@DepartmentName", parent.DepartmentName.ToDatabaseObj()) { SqlDbType = SqlDbType.NVarChar });
                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                AffiliationID = sprocReader["DepartmentID"].ToInt();
                            //    parent.AccountID = AccountID;
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

            return parent;
        }

        public AffiliationEntityDC SaveAffilation(AffiliationEntityDC parent)
        {
            int AffiliationID = 0;

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = SAVE_AFFILATION;
                        sprocCmd.Parameters.Add(new SqlParameter("@AffiliationName", parent.AffiliationName.ToDatabaseObj()) { SqlDbType = SqlDbType.NVarChar });
                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                AffiliationID = sprocReader["AffiliationID"].ToInt();
                                //    parent.AccountID = AccountID;
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

            return parent;
        }

        public DepartmentListEntityDC GetAllDepartment()
        {
            DepartmentListEntityDC Accounts = new DepartmentListEntityDC();
            List<DepartmentEntityDC> AccountList = new List<DepartmentEntityDC>();

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = GET_ALL_DEPARTMENT;


                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {

                                DepartmentEntityDC Account = new DepartmentEntityDC();
                                Account.DepartmentID = sprocReader["DepartmentID"].ToInt();
                                Account.DepartmentName = sprocReader["DepartmentName"].ToStringDefault();
                                AccountList.Add(Account);

                            }

                        }

                        Accounts.DepartmentList = AccountList;
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
        public AffiliationListEntityDC GetAllAffiliation()
        {
            AffiliationListEntityDC Accounts = new AffiliationListEntityDC();
            List<AffiliationEntityDC> AccountList = new List<AffiliationEntityDC>();

            using (DbConnection conn = Jaqen.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = GET_ALL_AFFILATION;


                        using (IDataReader sprocReader = Jaqen.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {

                                AffiliationEntityDC Account = new AffiliationEntityDC();
                                Account.AffiliationID = sprocReader["AffiliationID"].ToInt();
                                Account.AffiliationName = sprocReader["AffiliationName"].ToStringDefault();
                                AccountList.Add(Account);

                            }

                        }

                        Accounts.AffiliationList = AccountList;
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
