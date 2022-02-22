using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _9jasorosoke.Interface
{
    public interface IReportRepository
    {
        Task<string> SaveReport(ICarOwnerViewModel carOwnerReport);

        Task<IEnumerable<ICarOwner>> GetCarOwnerReports();
    }
}
