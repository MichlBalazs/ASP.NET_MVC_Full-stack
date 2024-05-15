using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GG1RKK_HFT_2023241.Repository.Database;
using System.Text.Json.Serialization;

namespace GG1RKK_HFT_202324.Models
{

    public class Order
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int AdventurerId { get; set; }

        public virtual Adventurer Adventurer { get; set; }

        public int ItemId { get; set; }
     
        public virtual Item Item { get; set; }
        public Order()
        {
            
        }
    }
}
