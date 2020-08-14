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
    public class GateTerminalDAL
    {
        DatabaseProviderFactory factory = new DatabaseProviderFactory();

        ConfigurationHelper configHelper = new ConfigurationHelper();
        Database DeLorean;

        const string GET_ALL_GATETERMINAL_BY_ACCOUNT_ID = "sp_GetAllGateTerminalByAccountID";
        const string GET_ALL_GATETERMINAL_BY_ALL_GATETERMINAL_ID = "sp_GetAllGateTerminalByGateTerminalID";
        const string SAVE_GATETERMINAL = "sp_SaveGateTerminal";
        const string GET_ALL_GATETYPE = "sp_GetAllGateType";

        public GateTerminalDAL()
        {
            DeLorean = new SqlDatabase(configHelper.RFIDConnString);
        }


        public GateTerminalListEntityDC GetAllGateTerminal(Guid AcctID, string Search, int PageIndex, int PageSize, out int Count)
        {
            GateTerminalListEntityDC Accounts = new GateTerminalListEntityDC();
            List<GateTerminalEntityDC> AccountList = new List<GateTerminalEntityDC>();

            using (DbConnection conn = DeLorean.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = GET_ALL_GATETERMINAL_BY_ACCOUNT_ID;
                        sprocCmd.Parameters.Add(new SqlParameter("@AccountID", AcctID.ToGuid()) { SqlDbType = SqlDbType.UniqueIdentifier });
                        sprocCmd.Parameters.Add(new SqlParameter("@Search", Search.ToStringDefault()) { SqlDbType = SqlDbType.NVarChar });
                        sprocCmd.Parameters.Add(new SqlParameter("@PageIndex", PageIndex.ToInt()) { SqlDbType = SqlDbType.Int });
                        sprocCmd.Parameters.Add(new SqlParameter("@PageSize", PageSize.ToInt()) { SqlDbType = SqlDbType.Int });


                        var CountResult = sprocCmd.CreateParameter();
                        CountResult.ParameterName = "@Count";
                        CountResult.Direction = ParameterDirection.Output;
                        CountResult.DbType = DbType.Int32;
                        sprocCmd.Parameters.Add(CountResult);



                        using (IDataReader sprocReader = DeLorean.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                GateTerminalEntityDC Account = new GateTerminalEntityDC();
                                Account.GateTerminalID = sprocReader["GateTerminalID"].ToGuid();
                                Account.GateTerminalName = sprocReader["GateTerminalName"].ToStringDefault();
                                Account.AccountID = sprocReader["AccountID"].ToGuid();
                                Account.AccountName = sprocReader["AccountName"].ToStringDefault();
                                Account.GateTypeID = sprocReader["GateTypeID"].ToInt();
                                Account.GateTypeName = sprocReader["GateTypeName"].ToStringDefault();
                                Account.IsActive = sprocReader["IsActive"].ToBooleanDefault();
                                Account.CreatedBy = sprocReader["CreatedBy"].ToStringDefault();
                                Account.CreatedDate = sprocReader["CreatedDate"].ToStringDefault();
                                Account.UpdatedBy = sprocReader["UpdatedBy"].ToStringDefault();
                                Account.UpdatedDate = sprocReader["UpdatedDate"].ToStringDefault();
                                AccountList.Add(Account);
                            }

                        }
                        Accounts.GateTerminalList = AccountList;
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
        public GateTerminalEntityDC GetAllGateTerminalByGateTerminalID(Guid GateTerminalID)
        {
            GateTerminalEntityDC Account = new GateTerminalEntityDC();
            List<GateTerminalEntityDC> AccountList = new List<GateTerminalEntityDC>();

            using (DbConnection conn = DeLorean.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = GET_ALL_GATETERMINAL_BY_ALL_GATETERMINAL_ID;
                        sprocCmd.Parameters.Add(new SqlParameter("@GateTerminalID", GateTerminalID.ToGuid()) { SqlDbType = SqlDbType.UniqueIdentifier });





                        using (IDataReader sprocReader = DeLorean.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                Account.GateTerminalID = sprocReader["GateTerminalID"].ToGuid();
                                Account.GateTerminalName = sprocReader["GateTerminalName"].ToStringDefault();
                                Account.AccountID = sprocReader["AccountID"].ToGuid();
                                Account.GateTypeID = sprocReader["GateTypeID"].ToInt();
                                
                                Account.AccountName = sprocReader["AccountName"].ToStringDefault();
                                Account.GateTypeName = sprocReader["GateTypeName"].ToStringDefault();
                                
                                Account.IsActive = sprocReader["IsActive"].ToBooleanDefault();
                                Account.CreatedBy = sprocReader["CreatedBy"].ToStringDefault();
                                Account.CreatedDate = sprocReader["CreatedDate"].ToStringDefault();
                                Account.UpdatedBy = sprocReader["UpdatedBy"].ToStringDefault();
                                Account.UpdatedDate = sprocReader["UpdatedDate"].ToStringDefault();
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

            return Account;
        }

        public GateTypeListEntityDC GetAllGateType()
        {
            GateTypeListEntityDC Accounts = new GateTypeListEntityDC();
            List<GateTypeEntityDC> AccountList = new List<GateTypeEntityDC>();

            using (DbConnection conn = DeLorean.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = GET_ALL_GATETYPE;





                        using (IDataReader sprocReader = DeLorean.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {

                                GateTypeEntityDC Account = new GateTypeEntityDC();
                                Account.GateTypeID = sprocReader["GateTypeID"].ToInt();
                                Account.GateTypeName = sprocReader["GateTypeName"].ToStringDefault();
                            //    Accounts.GateTypeList.Add(Account);
                          AccountList.Add(Account);
                                Accounts.GateTypeList= AccountList;


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

            return Accounts;
        }


        public GateTerminalEntityDC SaveGateTerminal(GateTerminalEntityDC parent)
        {
            Guid GateTerminalID = Guid.Empty;

            using (DbConnection conn = DeLorean.CreateConnection())
            {
                conn.Open();
                try
                {
                    using (DbCommand sprocCmd = conn.CreateCommand())
                    {
                        sprocCmd.CommandType = CommandType.StoredProcedure;
                        sprocCmd.CommandText = SAVE_GATETERMINAL;
                        sprocCmd.Parameters.Add(new SqlParameter("@GateTerminalID", parent.GateTerminalID.ToDatabaseObj()) { SqlDbType = SqlDbType.UniqueIdentifier });
                        sprocCmd.Parameters.Add(new SqlParameter("@GateTerminalName", parent.GateTerminalName.ToDatabaseObj()) { SqlDbType = SqlDbType.NVarChar });
                        sprocCmd.Parameters.Add(new SqlParameter("@IsActive", parent.IsActive.ToDatabaseObj()) { SqlDbType = SqlDbType.Bit });
                        sprocCmd.Parameters.Add(new SqlParameter("@GateTypeID", parent.GateTypeID.ToDatabaseObj()) { SqlDbType = SqlDbType.Int });
                        sprocCmd.Parameters.Add(new SqlParameter("@AccountID", parent.AccountID.ToDatabaseObj()) { SqlDbType = SqlDbType.UniqueIdentifier });
                        sprocCmd.Parameters.Add(new SqlParameter("@CreatedBy", parent.CreatedBy.ToDatabaseObj()) { SqlDbType = SqlDbType.NVarChar });
                        using (IDataReader sprocReader = DeLorean.ExecuteReader(sprocCmd))
                        {
                            while (sprocReader.Read())
                            {
                                GateTerminalID = sprocReader["GateTerminalID"].ToGuid();
                                parent.GateTerminalID = GateTerminalID;
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

    }

}
