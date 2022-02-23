using System;
using System.Collections.Generic;
using System.Text;

namespace _9jasorosoke.Interface
{
    public interface IGeneralFactories
    {
        #region ------------------ Car Owner Report ----------------------------
        ICarOwnerViewModel CreateCarownerView(string processingMessage);
        #endregion

        #region ------------------ Car Owner Report ----------------------------
        ICompanyOwnerViewModel CreateCompanyOwnerView(string processingMessage);

        #endregion
    }
}
