using _9jasorosoke.Interface;
using _9jasorosoke.Repositories.DataAccess;
using _9jasorosoke.Repositories.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace _9jasorosoke.Repositories.Repository
{
    public class ReportRepository: IReportRepository
    {
        private readonly DatabaseManager _databaseManager;

        public ReportRepository(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;

        }
        #region ------------------ Car Owner Report ----------------------------
        public async Task<IEnumerable<ICarOwner>> GetCarOwnerReports()
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                var record = await conn.QueryMultipleAsync("[dbo].[usp_Get_CarOnwers_Reports]", parameters, commandType: CommandType.StoredProcedure);
                var result = await record.ReadAsync<CarOwnerModel>();
                var value = result.AsList();
                return value;
            }
        }


        public  string SaveReport(ICarOwnerViewModel carOwnerReport)
        {
            var result = string.Empty;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.MyConnectionString))
                using (SqlCommand cmd = new SqlCommand("dbo.usp_Insert_CarOwner", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // set up the parameters
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar);
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar);
                    cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar);
                    cmd.Parameters.Add("@PurchaseLocation", SqlDbType.VarChar);
                    cmd.Parameters.Add("@DatePurchased", SqlDbType.Date);
                    cmd.Parameters.Add("@NameOfFuelingStation", SqlDbType.VarChar);
                    cmd.Parameters.Add("@ProofOfVehicleOwnerShip", SqlDbType.VarChar);
                    cmd.Parameters.Add("@PurchaseReciept", SqlDbType.VarChar);
                    cmd.Parameters.Add("@DateReported", SqlDbType.DateTime);

                   
                    // set parameter values
                    cmd.Parameters["@FirstName"].Value = carOwnerReport.FirstName;
                    cmd.Parameters["@LastName"].Value = carOwnerReport.LastName;
                    cmd.Parameters["@PhoneNumber"].Value = carOwnerReport.PhoneNumber;
                    cmd.Parameters["@NameOfFuelingStation"].Value = carOwnerReport.NameOfFuelingStation;
                    cmd.Parameters["@PurchaseLocation"].Value = carOwnerReport.PurchaseLocation;
                    cmd.Parameters["@PurchaseReciept"].Value = carOwnerReport.PurchaseReciept;
                    cmd.Parameters["@ProofOfVehicleOwnerShip"].Value = carOwnerReport.ProofOfVehicleOwnerShip;
                    cmd.Parameters["@DatePurchased"].Value = carOwnerReport.DatePurchased;
                    cmd.Parameters["@DateReported"].Value = DateTime.Now;

                    // open connection and execute stored procedure
                    conn.Open();
                    cmd.ExecuteNonQuery();

                   
                    return result;
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Report - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }
            return result;
        }

        public async Task<ICarOwner> GetCarOwnerReportById(int id)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var record = await conn.QueryFirstOrDefaultAsync<CarOwnerModel>("[dbo].[usp_Get_CarOnwer_Reports_By_Id]", parameters, commandType: CommandType.StoredProcedure);

                return record;
            }
        }
        #endregion


        #region ------------------ Company Owner Report ----------------------------
        public async Task<IEnumerable<ICompanyOwner>> GetCompanyOwnerReports()
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                var record = await conn.QueryMultipleAsync("[dbo].[usp_Get_CompanyOnwers_Reports]", parameters, commandType: CommandType.StoredProcedure);
                var result = await record.ReadAsync<CompanyOwnerModel>();
                var value = result.AsList();
                return value;
            }
        }


        public string SaveCompanyOwnerReport(ICompanyOwnerViewModel companyOwner)
        {
            var result = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString.MyConnectionString))
                using (SqlCommand cmd = new SqlCommand("dbo.usp_Insert_CompanyOwner_Report", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // set up the parameters
                    cmd.Parameters.Add("@CompanyAddress", SqlDbType.VarChar);
                    cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar);
                    cmd.Parameters.Add("@CompanyPhoneNumber", SqlDbType.VarChar);
                    cmd.Parameters.Add("@FuelDepotAddress", SqlDbType.VarChar);
                    cmd.Parameters.Add("@DatePurchased", SqlDbType.Date);
                    cmd.Parameters.Add("@PurchaseReciept", SqlDbType.VarChar);
                    cmd.Parameters.Add("@FuelDepotName", SqlDbType.VarChar);
                    cmd.Parameters.Add("@DateReported", SqlDbType.DateTime);

                   

                    // set parameter values
                    cmd.Parameters["@CompanyAddress"].Value = companyOwner.CompanyAddress;
                    cmd.Parameters["@CompanyName"].Value = companyOwner.CompanyName;
                    cmd.Parameters["@CompanyPhoneNumber"].Value = companyOwner.CompanyPhoneNumber;
                    cmd.Parameters["@FuelDepotAddress"].Value = companyOwner.FuelDepotAddress;
                    cmd.Parameters["@FuelDepotName"].Value = companyOwner.FuelDepotName;
                    cmd.Parameters["@PurchaseReciept"].Value = companyOwner.PurchaseReciept;
                    cmd.Parameters["@DatePurchased"].Value = companyOwner.DatePurchased;
                    cmd.Parameters["@DateReported"].Value = DateTime.Now;

                    // open connection and execute stored procedure
                    conn.Open();
                    cmd.ExecuteNonQuery();


                    return result;
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Report - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            return result;
        }

        public async Task<ICompanyOwner> GetCompanyOwnerReportById(int id)
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var record = await conn.QueryFirstOrDefaultAsync<CompanyOwnerModel>("[dbo].[usp_Get_CompanyOnwer_Reports_By_Id]", parameters, commandType: CommandType.StoredProcedure);

                return record;
            }
        }
        #endregion
    }
}
