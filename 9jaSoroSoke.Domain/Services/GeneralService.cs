using _9jasorosoke.Interface;
using _9jaSoroSoke.Domain.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _9jaSoroSoke.Domain.Services
{
    public class GeneralService: IGeneralService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IGeneralFactories _generalFactories;
        private readonly IOptions<CloudinarySettings> cloudinaryCofig;
        private Cloudinary cloudinary;
        public GeneralService(IReportRepository reportRepository, IGeneralFactories generalFactories, IOptions<CloudinarySettings> cloudinaryCofig)
        {
            this.cloudinaryCofig = cloudinaryCofig;

            Account acc = new Account(

              cloudinaryCofig.Value.CloudName,
              cloudinaryCofig.Value.ApiKey,
              cloudinaryCofig.Value.APiSecret

            );
            cloudinary = new Cloudinary(acc);
            _reportRepository = reportRepository;
            _generalFactories = generalFactories;
        }

        public Task<IEnumerable<ICarOwner>> GetCarOwnerReports()
        {
            var reports =  _reportRepository.GetCarOwnerReports();

            return  reports;
        }


        public ICarOwnerViewModel CreateCarownerView(string processingMessage)
        {
            return _generalFactories.CreateCarownerView(processingMessage);
        }
        public ICarOwnerViewModel CreateCarownerView(ICarOwnerViewModel viewModel, string message)
        {
            return viewModel;
        }
        public Task<string> SaveReport(ICarOwnerViewModel carOwnerReport)
        {
            var file = carOwnerReport.File;

            var uploadResult = new ImageUploadResult();

            if (file != null)
            {
                if (file.Length !> 10)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file.Name, stream),
                            Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                        };
                        uploadResult = cloudinary.Upload(uploadParams);
                    }
                }
            }
            carOwnerReport.ProofOfVehicleOwnerShip = uploadResult?.Url?.ToString();
            carOwnerReport.PurchaseReciept = uploadResult?.Url?.ToString();

            return  _reportRepository.SaveReport(carOwnerReport);
        }
    }
}
