using System.Security.Cryptography;
using System.Collections.Generic;
using System; 

namespace Vending_Machine_2
{
    public class VendingMachine
    {
        
        public int depositedAmount;
        public List<Item> Storage { get; set; }

        public VendingMachine()
        {
            depositedAmount = 0; 
            Storage = new List<Item>();
        }

        public void DepositCoin (int coinAmount)
        {
            depositedAmount = coinAmount; 
        }

        public void GetProduct(Item item)
        {
            if (depositedAmount >= item.Price)
            {
                Storage.RemoveAll(t => t.Name == item.Name);
                depositedAmount -= item.Price; 
            }
            else
            {
                Console.WriteLine("Insert more money hubby");
            }
        }

        public int GetRefund()
        {
            Console.WriteLine("You were refunded " + depositedAmount);
            int amountToRefund = depositedAmount; 
            depositedAmount = 0;
            return amountToRefund; 
        }
        
        public void ListStorage()
        {
            if (Storage.Count == 0)
            {
                Console.WriteLine("Everythings sold out mister");
                return;
            }
            foreach (var item in Storage)
            {
                Console.WriteLine(item.Name + " will cost ya " + item.Price);
            }
        }
        
        public Item BuyItem(Item item)
        {
            Storage.Remove(item);
            return item;
        }

    }

    }
