using System;
using System.ComponentModel.DataAnnotations;


namespace MyHealth.Models
{
    public class MyPressure
    {
        [Required]
        public int High { get; set; }

        [Required]
        public int Low { get; set; }

        [Required]
        public DateTime When { get; set; }

        [Required]
        public int Tonometer { get; set; }

        [Required]
        public int Person { get; set; }

        [StringLength(255)]
        public string Comment { get; set; }
    }
}