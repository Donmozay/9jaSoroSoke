using _9jasorosoke.Interface;
using _9jaSoroSoke.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _9jaSoroSoke.Domain.Factories
{
    public class GeneralFactories: IGeneralFactories
    {
        public ICarOwnerViewModel CreateCarownerView(string processingMessage)
        {
            var view = new CarOwnerViewModel
            {
                ProcessingMessage = processingMessage ?? "",
            };
            return view;
        }

        
    }
}
