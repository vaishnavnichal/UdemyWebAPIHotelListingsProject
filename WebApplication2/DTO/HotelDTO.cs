using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.DTO
{
    public class CreateHotelDTO
    {
        [Required]
        [StringLength(maximumLength:50,ErrorMessage ="Hotel name should be of 50 bytes")]
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }

        [Required]
        public int CountryId { get; set; }
        

    }


    public class HotelDTO:CreateHotelDTO
    {
        public int Id { get; set; }
        public CountryDTO Country { get; set; }

    }

}
