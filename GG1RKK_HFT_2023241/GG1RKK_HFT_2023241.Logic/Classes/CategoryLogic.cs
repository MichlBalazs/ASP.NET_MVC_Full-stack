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
    public class CategoryLogic : ICategoryLogic
    {
        IRepository<Category> repo;
        public CategoryLogic(IRepository<Category> repo)
        {
            this.repo = repo;
        }
        public void Create(Category c)
        {
            if (c.CategoryName.Length < 3)
            {
                throw new ArgumentException("Name is too short");
            }
            repo.Create(c);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Category Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Category> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Category m)
        {
            repo.Update(m);
        }
        public int GetItemsNumberInCategory(string category)
        {
            return this.repo.ReadAll().FirstOrDefault(x => x.CategoryName == category).Items.Count;
        }
    }
}
