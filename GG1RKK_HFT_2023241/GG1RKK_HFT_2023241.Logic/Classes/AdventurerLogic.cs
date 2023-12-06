using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Logic.Interfaces;
using GG1RKK_HFT_2023241.Repository.Database;
using GG1RKK_HFT_2023241.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GG1RKK_HFT_2023241.Logic.Classes
{
    public class AdventurerLogic : IAdventurerLogic
    {
        IRepository<Adventurer> repo;
        public AdventurerLogic(IRepository<Adventurer> repo)
        {
            this.repo = repo;
        }

        public void Create(Adventurer adventurer)
        {
            if (adventurer.AdventurerName.Length < 3)
            {
                throw new ArgumentException("Name is too short");
            }
            else if (adventurer.Level < 1 || adventurer.Level > 20)
            {
                throw new ArgumentException("Level must be between 1 and 20");
            }
            repo.Create(adventurer);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Adventurer Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Adventurer> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Adventurer adventurer)
        {
            repo.Update(adventurer);
        }
        
        

    }
}
