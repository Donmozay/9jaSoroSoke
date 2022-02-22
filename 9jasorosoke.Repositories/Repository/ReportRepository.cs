using _9jasorosoke.Interface;
using _9jasorosoke.Repositories.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace _9jasorosoke.Repositories.Repository
{
    public class ReportRepository: IReportRepository
    {
        private readonly DatabaseManager _databaseManager;

        public ReportRepository(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;

        }
    }
}
