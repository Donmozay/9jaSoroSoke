using _9jasorosoke.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _9jaSoroSoke.Domain.Models
{
    public class CarOwnerViewModel: ICarOwnerViewModel
    {
        public string ProcessingMessage { get; set; }
        public string ProofOfVehicleOwnerShip { get; set; }
        public string PurchaseReciept { get; set; }
        [Required]
        public IFormFile File { get; set; }
    }
}
