using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonesStock.Shared.Models
{
    public class Phone
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Brand { get; set; }

        [Required]
        [StringLength(25)]
        public string Model { get; set; }

        [Required]
        [StringLength(25)]
        public string Color { get; set; }

        [Required]
        [StringLength(25)]
        public string Amperage { get; set; }

        [Required]
        [StringLength(25)]
        public string Storage { get; set; }

        [Required]
        [StringLength(25)]
        public string RAM { get; set; }

        [Required]
        [StringLength(25)]
        public string Processor { get; set; }
    }
}
