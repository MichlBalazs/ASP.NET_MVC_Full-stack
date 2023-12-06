using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using GG1RKK_HFT_202324.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GG1RKK_HFT_2023241.Repository.Database
{
    public class Adventurer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdventurerId { get; set; }

        [Required]
        [StringLength(100)]
        public string AdventurerName { get; set; }
        [StringLength(100)]
        public string Class { get; set; }
        [Range(1,20)]
        public int Level { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
        public Adventurer()
        {
                
        }
    }
}