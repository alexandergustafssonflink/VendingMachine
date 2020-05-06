using System.Security.Cryptography;
using System.Collections.Generic;
using System;

namespace Vending_Machine_2
{
    public class Inventory
    {
        public List<Item> Storage { get; set; }

        public Inventory()
        {
            Storage = new List<Item>();
        }
        
        public bool AddItem(Item item)
        {
            Storage.Add(item);
            return true; 
        }
        public void ListStorage()
        {
            if (Storage.Count == 0)
            {
                Console.WriteLine("You have got nothing here brother");
                return;
            }
            foreach (var item in Storage)
            {
                Console.WriteLine("Your inventory looks as follows...");
                Console.WriteLine(item.Name);
            }
        }
    }
}