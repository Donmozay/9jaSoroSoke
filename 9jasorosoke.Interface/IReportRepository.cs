using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _9jasorosoke.Interface
{
    public interface IReportRepository
    {
        #region ------------------ Car Owner Report ----------------------------

        string SaveReport(ICarOwnerViewModel carOwnerReport);
        Task<IEnumerable<ICarOwner>> GetCarOwnerReports();

        Task<ICarOwner> GetCarOwnerReportById(int id);
        #endregion

        #region ------------------ Company Owner Report ----------------------------

        Task<IEnumerable<ICompanyOwner>> GetCompanyOwnerReports();

        string SaveCompanyOwnerReport(ICompanyOwnerViewModel companyOwner);
        Task<ICompanyOwner> GetCompanyOwnerReportById(int id);
        #endregion
    }
}
