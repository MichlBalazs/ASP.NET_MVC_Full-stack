using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Logic.Interfaces;
using GG1RKK_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG1RKK_HFT_2023241.Logic.Classes
{
    internal class ManufacturerLogic : IManufacturerLogic
    {
        IRepository<Manufacturer> repo;
        public ManufacturerLogic(IRepository<Manufacturer> repo)
        {
            this.repo = repo;
        }
        public void Create(Manufacturer item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Manufacturer Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Manufacturer> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Manufacturer item)
        {
            repo.Update(item);
        }
    }
}
