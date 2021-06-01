using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientPoster.Models
{
    public class MinMax
    {
        [Required(ErrorMessage = "Введите число")]
        public double Min { get; set; }
        [Required(ErrorMessage = "Введите число")]
        public double Max { get; set; }


    }
}
