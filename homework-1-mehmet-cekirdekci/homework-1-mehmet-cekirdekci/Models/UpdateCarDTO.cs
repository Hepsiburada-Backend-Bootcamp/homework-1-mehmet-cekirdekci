using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_1_mehmet_cekirdekci.Models
{
    public class UpdateCarDTO
    {
        [Required]
        [MinLength(2, ErrorMessage = "Car's Name of Model must be greater than 2 letters!")]
        public string CarModelName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Car's Name of Brand must be greater than 3 letters!")]
        public string Brand { get; set; }

        [Required]
        [PriceValidation(minPrice: 0)]
        public int Price { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Cars Name of Color must be greater than 4 letters!")]
        public string Color { get; set; }
    }
}
