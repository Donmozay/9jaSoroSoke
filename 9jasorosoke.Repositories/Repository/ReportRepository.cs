using _9jasorosoke.Interface;
using _9jasorosoke.Repositories.DataAccess;
using _9jasorosoke.Repositories.Models;
using Dapper;
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


        public async Task<string> SaveReport(ICarOwnerViewModel carOwnerReport)
        {
            var result = string.Empty;
           
            try
            {
                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@FirstName", carOwnerReport.FirstName);
                    parameters.Add("@LastName", carOwnerReport.LastName);
                    parameters.Add("@PhoneNumber", carOwnerReport.PhoneNumber);
                    parameters.Add("@PurchaseLocation", carOwnerReport.PurchaseLocation);
                    parameters.Add("@NameOfFuelingStation", carOwnerReport.NameOfFuelingStation);
                    parameters.Add("@DatePurchased", carOwnerReport.DatePurchased);
                    parameters.Add("@ProofOfVehicleOwnerShip", carOwnerReport.ProofOfVehicleOwnerShip);
                    parameters.Add("@PurchaseReciept", carOwnerReport.PurchaseReciept);
                    parameters.Add("@DateReported",DateTime.Now);
                    var respone = conn.Execute("[dbo].[usp_Insert_CarOwner]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                    return null;
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


        public async Task<string> SaveCompanyOwnerReport(ICompanyOwnerViewModel companyOwner)
        {
            var result = string.Empty;

            try
            {
                using (IDbConnection conn = await _databaseManager.DatabaseConnection())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@CompanyAddress", companyOwner.CompanyAddress);
                    parameters.Add("@CompanyName", companyOwner.CompanyName);
                    parameters.Add("@CompanyPhoneNumber", companyOwner.CompanyPhoneNumber);
                    parameters.Add("@FuelDepotAddress", companyOwner.FuelDepotAddress);
                    parameters.Add("@FuelDepotName", companyOwner.FuelDepotName);
                    parameters.Add("@DatePurchased", companyOwner.DatePurchased);
                    parameters.Add("@PurchaseReciept", companyOwner.PurchaseReciept);
                    parameters.Add("@DateReported", DateTime.Now);
                    var respone = conn.Execute("[dbo].[usp_Insert_CompanyOwner_Report]", parameters, commandType: CommandType.StoredProcedure);
                    conn.Close();
                    return null;
                }
            }
            catch (Exception e)
            {
                result = string.Format("Save Compant Owner Report - {0} , {1}", e.Message,
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
