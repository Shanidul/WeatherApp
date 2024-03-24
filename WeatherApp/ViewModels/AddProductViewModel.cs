using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.ViewModels
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "Product is mandatory")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Description is mandatory")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is mandatory")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Manufacturar is mandatory")]
        public string ManufacturedBy { get; set; }
    }
}
