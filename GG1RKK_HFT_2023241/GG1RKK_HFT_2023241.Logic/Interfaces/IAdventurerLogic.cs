using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Repository.Database;
using System.Linq;

namespace GG1RKK_HFT_2023241.Logic.Interfaces
{
    public interface IAdventurerLogic
    {
        void Create(Adventurer adventurer);
        void Delete(int id);
        Adventurer Read(int id);
        IQueryable<Adventurer> ReadAll();
        void Update(Adventurer adventurer);
    }
}