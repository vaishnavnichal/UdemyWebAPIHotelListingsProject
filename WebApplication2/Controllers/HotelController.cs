using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DTO;
using WebApplication2.IRepository;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly ILogger<HotelController> _logger;

        public HotelController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<HotelController> logger)
        {
            _unitofwork = unitOfWork;
            _mapper = mapper;
            _logger = logger;


        }


        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {

            try
            {
                var hotels = await _unitofwork.Hotels.GetAll();
                var results = _mapper.Map<IList<HotelDTO>>(hotels);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"SOmething went wrong in the {nameof(GetHotels)}");
                return StatusCode(500, "Internal Server Error");

            }

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHotel(int id)
        {

            try
            {
                var hotel = await _unitofwork.Hotels.Get(q => q.Id == id, new List<string> {"Country" });
                var result = _mapper.Map<HotelDTO>(hotel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"SOmething went wrong in the {nameof(GetHotel)}");
                return StatusCode(500, "Internal Server Error");

            }

        }








    }
}
