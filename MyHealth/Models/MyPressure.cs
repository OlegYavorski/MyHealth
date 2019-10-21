using System;
using System.ComponentModel.DataAnnotations;


namespace MyHealth.Models
{
    public class MyPressure
    {
        public int Id { get; set; }

        [Required]
        public int High { get; set; }

        [Required]
        public int Low { get; set; }

        [Required]
        public DateTime When { get; set; }

        [Required]
        public int TonometerId { get; set; }

        [Required]
        public int PersonId { get; set; }

        [StringLength(255)]
        public string Comment { get; set; }
    }
}