using System;

namespace Vending_Machine_2
{
    public class Wallet
    {
        public int amount;

        public Wallet()
        {
            amount = 0; 
        }

        public void InsertAmount(int InsertedAmount)
        { 
            amount += InsertedAmount; 
        }
        
        
        public void WithdrawAmount(int WithdrawedAmount)
        {
            amount -= WithdrawedAmount; 
        }

        public void CheckBalance()
        {
            if (amount == 0)
            {
                Console.WriteLine("Your balance is 0. Time to get to work sonny.");
            }
            else
            {
                Console.WriteLine($"Your balance is {amount}. Time to put on them spending pants??");
            }
        
    }

    }
}