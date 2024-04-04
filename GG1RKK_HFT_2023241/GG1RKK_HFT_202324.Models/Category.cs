using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;

namespace GG1RKK_HFT_202324.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }
        
        public int ItemId { get; set; }
        [JsonIgnore]
        public virtual ICollection<Item> Items { get; set; }

        public Category()
        {

        }
    }
}
