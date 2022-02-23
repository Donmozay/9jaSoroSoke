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

        #region ------------------ Car Owner Report ----------------------------

        public Task<IEnumerable<ICarOwner>> GetCarOwnerReports()
        {
            var reports =  _reportRepository.GetCarOwnerReports();

            return reports;
        }

        public Task<ICarOwner> GetCarOwnerReporByIds(int id)
        {
            var reports = _reportRepository.GetCarOwnerReportById(id);

            return reports;
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
                foreach (var item in file)
                {
                    if (item.Length! > 5120)
                    {
                        if (item == file[0])
                        {
                            using (var stream = item.OpenReadStream())
                            {
                                var uploadParams = new ImageUploadParams()
                                {
                                    File = new FileDescription(item.Name, stream),
                                    Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                                };
                                uploadResult = cloudinary.Upload(uploadParams);
                            }

                            carOwnerReport.ProofOfVehicleOwnerShip = uploadResult?.Url?.ToString();
                        }
                        else
                        {
                            using (var stream = item.OpenReadStream())
                            {
                                var uploadParams = new ImageUploadParams()
                                {
                                    File = new FileDescription(item.Name, stream),
                                    Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                                };
                                uploadResult = cloudinary.Upload(uploadParams);
                            }
                            carOwnerReport.PurchaseReciept = uploadResult?.Url?.ToString();
                        }
                    }
                }
            }
            return  _reportRepository.SaveReport(carOwnerReport);
        }
        #endregion

        #region ------------------ Company Owner Report ----------------------------

        public Task<IEnumerable<ICompanyOwner>> GetCompanyOwnerReports()
        {
            var reports = _reportRepository.GetCompanyOwnerReports();

            return reports;
        }

        public Task<ICompanyOwner> GetCompanyOwnerReporById(int id)
        {
            var reports = _reportRepository.GetCompanyOwnerReportById(id);

            return reports;
        }

        public ICompanyOwnerViewModel CreateCompanyOwnerView(string processingMessage)
        {
            return _generalFactories.CreateCompanyOwnerView(processingMessage);
        }
        public ICompanyOwnerViewModel CreateCompanyOwnerView(ICompanyOwnerViewModel viewModel, string message)
        {
            return viewModel;
        }

        public Task<string> SaveCompanyOwnerReport(ICompanyOwnerViewModel companyOwnerReport)
        {
            var file = companyOwnerReport.File;

            var uploadResult = new ImageUploadResult();

            if (file != null)
            {
                if (file.Length! > 5120)
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
                    companyOwnerReport.PurchaseReciept = uploadResult?.Url?.ToString();
                }
                }
            return _reportRepository.SaveCompanyOwnerReport(companyOwnerReport);
        }
        #endregion
    }
}
