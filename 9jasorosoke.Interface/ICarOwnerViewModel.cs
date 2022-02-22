using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _9jasorosoke.Interface
{
    public interface ICarOwnerViewModel
    {
        string ProcessingMessage { get; set; }
        string ProofOfVehicleOwnerShip { get; set; }
         string PurchaseReciept { get; set; }
        [Required]
        public IFormFile File { get; set; }
    }
}
