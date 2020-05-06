using System;

namespace Vending_Machine_2
{
    public class Bank
    {
        private int AmountOnAccout;

        public Bank()
        {
            AmountOnAccout = 500; 
        }

        public void InsertAmount(int InsertedAmount)
        { 
            AmountOnAccout += InsertedAmount;
            Console.WriteLine("You have inserted " + InsertedAmount);
            Console.WriteLine("The amount on your account is now " + AmountOnAccout);
        }
        
        public bool WithdrawAmount(int WithdrawedAmount)
        {
            if (WithdrawedAmount > AmountOnAccout)
            {
                Console.WriteLine("You dont have that sort of money here. What do you take me for? A FOOL?! Guards! Get this fella outta here");
                return false; 
            }
            else {
                
            AmountOnAccout -= WithdrawedAmount; 
            
            Console.WriteLine("You have withdrawed " + WithdrawedAmount);
            Console.WriteLine("Amount left on your account is " + AmountOnAccout);
            return true; 
            }
        }
        
    }
}
