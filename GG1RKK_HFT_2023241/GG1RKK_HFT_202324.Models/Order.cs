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

        public ICollection<int> ItemIdList { get; set; }


        public Order()
        {
            
        }
        //public Order(string line)
        //{
        //    string[] split = line.Split('#');
        //    OrderId = int.Parse(split[0]);
        //    CustomerName = split[1];
        //    string[] split2 = split[2].Split(',');
        //    foreach (var item in split2)
        //    {
        //        ItemIdList.Add(int.Parse(item));
        //    }
        //}
    }
}
