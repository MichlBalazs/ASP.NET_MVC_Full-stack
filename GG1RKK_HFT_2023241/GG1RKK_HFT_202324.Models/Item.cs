using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GG1RKK_HFT_202324.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        //[StringLength(100)]
        //public string Type { get; set; }

        [StringLength(100)]
        public string ItemName { get; set; }

        [Range(0, 1000)]
        public int Price { get; set; }

        [Range(0, 100)]
        public int InStock { get; set; }
        public int ManufacturerId { get; set; }

    }
}
