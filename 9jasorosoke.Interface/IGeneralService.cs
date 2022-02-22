using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _9jasorosoke.Interface
{
    public interface IGeneralService
    {
        ICarOwnerViewModel CreateCarownerView(string processingMessage);
        ICarOwnerViewModel CreateCarownerView(ICarOwnerViewModel viewModel, string message);
        Task<IEnumerable<ICarOwner>> GetCarOwnerReports();
        Task<string> SaveReport(ICarOwnerViewModel carOwnerReport);
    }
}
