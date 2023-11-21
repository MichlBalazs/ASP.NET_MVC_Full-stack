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
    public class CategoryRepositrory : Repository<Category>, IRepository<Category>
    {
        public CategoryRepositrory(ShopDbContext ctx) : base(ctx)
        {
        }
        public override Category Read(int id)
        {
            return ctx.Manufacturers.FirstOrDefault(t => t.CategoryId == id);
        }

        public override void Update(Category item)
        {
            var old = Read(item.CategoryId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
