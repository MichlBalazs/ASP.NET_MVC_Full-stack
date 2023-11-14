using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace GG1RKK_HFT_202324.Models
{
    public class Manufacturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManufacturerId { get; set; }

        [Required]
        [StringLength(240)]
        public string ManufacturerName { get; set; }


        public Manufacturer()
        {

        }

        //public Manufacturer(string line)
        //{
        //    string[] split = line.Split('#');
        //    ManufacturerId = int.Parse(split[0]);
        //    ManufacturerName = split[1];
        //}
    }
}
