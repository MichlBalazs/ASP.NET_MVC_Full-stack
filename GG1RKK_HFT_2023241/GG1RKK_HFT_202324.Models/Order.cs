using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG1RKK_HFT_202324.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }


        [StringLength(100)]
        public string CustomerName { get; set; }

        public List<int> ItemIdList { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
