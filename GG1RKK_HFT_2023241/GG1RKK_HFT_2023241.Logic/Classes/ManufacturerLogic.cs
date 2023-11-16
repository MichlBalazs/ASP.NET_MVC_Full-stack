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
    public class ManufacturerLogic : IManufacturerLogic
    {
        IRepository<Manufacturer> repo;
        public ManufacturerLogic(IRepository<Manufacturer> repo)
        {
            this.repo = repo;
        }
        public void Create(Manufacturer m)
        {
            if (m.ManufacturerName.Length < 3)
            {
                throw new ArgumentException("Name is too short");
            }
            repo.Create(m);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Manufacturer Read(int id)
        {
            var m = this.repo.Read(id);
            if (m == null)
            {
                throw new ArgumentException("Manufacturer not exist");
            }
            return m;
        }

        public IQueryable<Manufacturer> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Manufacturer m)
        {
            repo.Update(m);
        }
    }
}
