using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Repository.Database;
using GG1RKK_HFT_2023241.Repository.Generic_Repository;
using GG1RKK_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GG1RKK_HFT_2023241.Repository.ModelRepositories
{
    public class ItemRepository : Repository<Item>, IRepository<Item>
    {
        public ItemRepository(ShopDbContext ctx) : base(ctx)
        {
        }
        public override Item Read(int id)
        {
            return ctx.Items.FirstOrDefault(t => t.ItemId == id);
        }

        public override void Update(Item item)
        {
            var old = Read(item.ItemId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
