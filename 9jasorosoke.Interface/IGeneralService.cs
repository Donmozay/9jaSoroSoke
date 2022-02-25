using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _9jasorosoke.Interface
{
    public interface IGeneralService
    {
        #region ------------------ Car Owner Report ----------------------------

        ICarOwnerViewModel CreateCarownerView(string processingMessage);
        ICarOwnerViewModel CreateCarownerView(ICarOwnerViewModel viewModel, string message);
        Task<IEnumerable<ICarOwner>> GetCarOwnerReports();
        Task<ICarOwner> GetCarOwnerReporByIds(int id);
        string SaveReport(ICarOwnerViewModel carOwnerReport);

        #endregion

        #region ------------------ Company Owner Report ----------------------------

        Task<IEnumerable<ICompanyOwner>> GetCompanyOwnerReports();

        Task<ICompanyOwner> GetCompanyOwnerReporById(int id);

        ICompanyOwnerViewModel CreateCompanyOwnerView(string processingMessage);

        ICompanyOwnerViewModel CreateCompanyOwnerView(ICompanyOwnerViewModel viewModel, string message);

        string SaveCompanyOwnerReport(ICompanyOwnerViewModel companyOwnerReport);
        #endregion
    }
}
