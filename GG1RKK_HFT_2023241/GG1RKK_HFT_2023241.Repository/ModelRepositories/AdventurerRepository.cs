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
    public class AdventurerRepository : Repository<Adventurer>, IRepository<Adventurer>
    {
        public AdventurerRepository(ShopDbContext ctx) : base(ctx)
        {
        }
        public override Adventurer Read(int id)
        {
            return ctx.Adventurers.FirstOrDefault(t => t.AdventurerId == id);
        }

        public override void Update(Adventurer adventurer)
        {
            var old = Read(adventurer.AdventurerId);
            foreach (var prop in old.GetType().GetProperties().Where(t => t.Name.Contains("Name")))
            {
                prop.SetValue(old, prop.GetValue(adventurer));
            }
            ctx.SaveChanges();
        }
    }
}

