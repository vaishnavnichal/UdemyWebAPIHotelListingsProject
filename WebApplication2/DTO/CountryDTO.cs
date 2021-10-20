﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.DTO
{
    public class CreateCountryDTO
    {
        

        [Required]
        [StringLength(maximumLength:50,ErrorMessage ="Country name is too long")]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength:2,ErrorMessage ="Short name maximum value exceeds")]
        public string ShortName { get; set; }
    }


    public class CountryDTO:CreateCountryDTO
    {
        public int Id { get; set; }
        public IList<HotelDTO> Hotels { get; set; }
    }


}
