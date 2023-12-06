    using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GG1RKK_HFT_202324.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [StringLength(100)]
        public string ItemName { get; set; }

        [Range(0, 1000)]
        public int Price { get; set; }
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
        public Item()
        {
            
        }

    }
}
