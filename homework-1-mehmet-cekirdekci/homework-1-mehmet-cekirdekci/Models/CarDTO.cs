using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_1_mehmet_cekirdekci.Models
{
    public class CarDTO
    {
        [Required]
        public int CarId { get; set; }

        [Required]
        [StringLength(1, ErrorMessage = "Car's Name of Model must be greater than 1 letters!")]
        public string CarModelName { get; set; }

        [Required]
        [StringLength(3, ErrorMessage = "Car's Name of Brand must be greater than 3 letters!")]
        public string Brand { get; set; }

        [Required]
        [PriceValidation(minPrice: 0)]
        public int Price { get; set; }

        [Required]
        [StringLength(4, ErrorMessage = "Cars Name of Color must be greater than 4 letters!")]
        public string Color { get; set; }
    }
}
