﻿using _9jasorosoke.Interface;
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

        public async Task<IEnumerable<ICarOwner>> GetCarOwnerReports()
        {
            using (IDbConnection conn = await _databaseManager.DatabaseConnection())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                var record = await conn.QueryMultipleAsync("[dbo].[usp_Get_CarOnwers_Reports]", parameters, commandType: CommandType.StoredProcedure);
                var result = await record.ReadAsync<CarOwner>();
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
                    parameters.Add("@PurchaseReciept", carOwnerReport.PurchaseReciept);
                    parameters.Add("@ProofOfVehicleOwnerShip", carOwnerReport.ProofOfVehicleOwnerShip);
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

    }
}
