using GG1RKK_HFT_202324.Models;
using GG1RKK_HFT_2023241.Repository.Database;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace GG1RKK_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Adventurer")
            {
                Console.Write("Enter Adventurer Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Adventurer Level: ");
                int level = int.Parse(Console.ReadLine());
                Console.Write("Enter Adventurer Class: ");
                string c = Console.ReadLine();
                rest.Post(new Adventurer() { AdventurerName = name, Level = level, Class = c}, "adventurer");
            }
            else if (entity == "Item")
            {
                Console.Write("Enter Item Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Item Price: ");
                int price = int.Parse(Console.ReadLine());
                Console.Write("Enter Item Category ID: ");
                int c = int.Parse(Console.ReadLine());
                rest.Post(new Item() { ItemName = name, Price = price, CategoryId = c }, "item");
            }
        }
        static void List(string entity)
        {
            if (entity == "Adventurer")
            {
                List<Adventurer> adventurers = rest.Get<Adventurer>("adventurer");
                foreach (var a in adventurers)
                {
                    Console.WriteLine(a.AdventurerId + ": " + a.AdventurerName + $" Level {a.Level} " + a.Class);
                }
            }
            else if (entity == "Item")
            {
                List<Item> items = rest.Get<Item>("item");
                foreach (var item in items)
                {
                    Console.WriteLine(item.ItemId + ": " + item.ItemName + " " + item.Price);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Adventurer")
            {
                Console.Write("Enter Adventurer's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Adventurer one = rest.Get<Adventurer>(id, "adventurer");
                Console.Write($"New name [old: {one.AdventurerName}]: ");
                string name = Console.ReadLine();
                one.AdventurerName = name;
                rest.Put(one, "adventurer");
            }
            else if (entity == "Item")
            {
                Console.Write("Enter Item's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Item one = rest.Get<Item>(id, "item");
                Console.Write($"New name [old: {one.ItemName}]: ");
                string name = Console.ReadLine();
                one.ItemName = name;
                rest.Put(one, "item");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Adventurer")
            {
                Console.Write("Enter Adventurer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "adventurer");
            }
            else if (entity == "Item")
            {
                Console.Write("Enter Item's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "item");
            }
        }

        static void Main(string[] args)
        {

            rest = new RestService("http://localhost:4112/");
        }
    }
}
