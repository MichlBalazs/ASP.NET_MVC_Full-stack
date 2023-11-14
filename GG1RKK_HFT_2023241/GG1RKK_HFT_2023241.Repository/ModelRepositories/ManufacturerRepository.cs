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
    public class ManufacturerRepository : Repository<Manufacturer>, IRepository<Manufacturer>
    {
        public ManufacturerRepository(ShopDbContext ctx) : base(ctx)
        {
        }
        public override Manufacturer Read(int id)
        {
            return ctx.Manufacturers.FirstOrDefault(t => t.ManufacturerId == id);
        }

        public override void Update(Manufacturer item)
        {
            var old = Read(item.ManufacturerId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
