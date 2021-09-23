using homework_1_mehmet_cekirdekci.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_1_mehmet_cekirdekci.Controllers
{
    [Route("api/v1/cars")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        public static List<CarDTO> carDTOs = new List<CarDTO>()
        {
            new CarDTO{CarId = 1, Brand = "Mercedes", CarModelName = "A", Color = "Siyah", Price = 300000},
            new CarDTO{CarId = 2, Brand = "BMW", CarModelName = "X", Color = "Mavi", Price = 250000},
            new CarDTO{CarId = 3, Brand = "Volkswagen", CarModelName = "Passat", Color = "Beyaz", Price = 500000}
        };


        [HttpGet]
        public IActionResult GetList([FromQuery] string filter)
        {
            if (filter == "asc")
            {
                var _sortedList = carDTOs.OrderBy(c => c.Brand).ToList();
                return Ok(_sortedList);
            }

            else if (filter == "desc")
            {
                var _sortedList = carDTOs.OrderByDescending(c => c.Brand).ToList();
                return Ok(_sortedList);
            }

            return Ok(carDTOs);


        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var car = carDTOs.SingleOrDefault(c => c.CarId == id);

            if (car == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(car);
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddCarDTO addCarDTO)
        {
            int lastId = carDTOs.Max(c => c.CarId);

            CarDTO car = new CarDTO()
            {
                CarId = lastId + 1,
                Brand = addCarDTO.Brand,
                CarModelName = addCarDTO.CarModelName,
                Color = addCarDTO.Color,
                Price = addCarDTO.Price
            };
            carDTOs.Add(car);

            return Created("Araba eklendi.", car);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateCarDTO updateCarDTO)
        {
            var car = carDTOs.SingleOrDefault(c => c.CarId == id);

            if (car == null)
            {
                return NotFound();
            }
            else
            {
                car.Brand = updateCarDTO.Brand;
                car.CarModelName = updateCarDTO.CarModelName;
                car.Color = updateCarDTO.Color;
                car.Price = updateCarDTO.Price;

                return Ok();
            }


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var car = carDTOs.SingleOrDefault(c => c.CarId == id);

            if (car == null)
            {
                return NotFound();
            }
            else
            {
                carDTOs.Remove(car);
                return Ok();
            }
        }


    }
}
