using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Repository.Database;
using GG1RKK_HFT_2023241.Repository.Generic_Repository;
using GG1RKK_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG1RKK_HFT_2023241.Repository.ModelRepositories
{
    public class OrderRepository : Repository<Order>, IRepository<Order>
    {
        public OrderRepository(ShopDbContext ctx) : base(ctx)
        {
        }
        public override Order Read(int id)
        {
            return ctx.Orders.FirstOrDefault(t => t.OrderId == id);
        }

        public override void Update(Order item)
        {
            var old = Read(item.OrderId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
