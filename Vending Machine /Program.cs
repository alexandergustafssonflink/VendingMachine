using System.Security.Cryptography;
using System.Collections.Generic;
using System; 

namespace Vending_Machine_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var vendingMachine = new VendingMachine();
            var wallet = new Wallet();
            var bank = new Bank();
            var inventory = new Inventory();
            
            var sword = new Item(50, "sword");
            var cheeseDoodle =  new Item(3, "cheeseDoodle");
            var vacuumCleaner = new Item(40, "vacuumCleaner");

            vendingMachine.Storage.Add(sword);
            vendingMachine.Storage.Add(cheeseDoodle);
            vendingMachine.Storage.Add(vacuumCleaner);
            
            Console.WriteLine("Howdy Partner and welcome to this epic world of bank, vending machine and... Not that much more in fact. Hope you wont stay for long!");
            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("A - Go to the Bank");
                Console.WriteLine("B - Go to the Vending Maching");
                Console.WriteLine("C - See Inventory");
                Console.WriteLine("D - Check wallet");
                var answer = Console.ReadLine();

                // BANK
                if (answer == "A")
                {
                    Console.WriteLine("Hi and welcome to the Bank. What can I do you for? ");
                    Console.WriteLine("A - Withdraw cash");
                    Console.WriteLine("B - Insert cash");

                    var answer1 = Console.ReadLine();

                    if (answer1 == "A")
                    {
                        Console.WriteLine("How much money would you like to withdraw?");
                        var amount = Console.ReadLine();
                        int parsedAmount = Int32.Parse(amount);
                        if (bank.WithdrawAmount(parsedAmount))
                        {
                            wallet.InsertAmount(parsedAmount);
                        }
                        else
                        {
                            continue; 
                        }

                    } else if ( answer1 == "B")
                    {
                        Console.WriteLine("How much money would you like to insert?");
                        var amount = Console.ReadLine();
                        int parsedAmount = Int32.Parse(amount);

                        if (parsedAmount > wallet.amount)
                        {
                            Console.WriteLine("You dont have that much money on ya");
                        } else {
                        bank.InsertAmount(parsedAmount);
                        }
                    }

                }
                // VENDING MACHINE
                else if (answer == "B")
                {
                    Console.WriteLine("Welcome to the most awesome Vendor Machine you have ever laid your pretty eyes on, Sonny.");

                    Console.WriteLine(" What would you like to do?");
                    Console.WriteLine("A - See list of items");
                    Console.WriteLine("B - Insert money");
                    Console.WriteLine("C - Return to menu");

                    var answer3 = Console.ReadLine();

                    if (answer3 == "A")
                    {
                        vendingMachine.ListStorage();

                    } else if (answer3 == "B")
                    {
                        Console.WriteLine("How much money would you like to put in?");
                        var amount1 = Console.ReadLine();
                        var parsedAmount1 = int.Parse(amount1);

                        if (parsedAmount1 > wallet.amount)
                        {
                            Console.WriteLine(parsedAmount1 + " " + wallet.amount);
                            Console.WriteLine("You dont have that sort of money baby");
                        }
                        else
                        {
                            vendingMachine.DepositCoin(parsedAmount1);
                            wallet.amount -= parsedAmount1;
                            Console.WriteLine("Your current deposited amount is " + vendingMachine.depositedAmount);
                            Console.WriteLine("What would you like to buy? Type the name and we'll be sure to give it to ya. Given that you put your money where your text is, so to speak.");
                            vendingMachine.ListStorage();
                            var wantedItem = Console.ReadLine();

                            for (int i = 0; i < vendingMachine.Storage.Count; i++)
                            {
                                if (vendingMachine.Storage[i].Name == wantedItem)
                                {
                                    var product = vendingMachine.Storage[i];
                                    inventory.AddItem(product);
                                    vendingMachine.GetProduct(product);
                                    Console.WriteLine($"You just bought yourself a {product.Name}. Lucky bastard!");
                                    wallet.amount += vendingMachine.GetRefund();
                                    break;
                                }
                            }
                        }
                    }
                    else if (answer3 == "C")
                    {
                        continue; 
                    }
                }
                else if (answer == "C")
                {
                    inventory.ListStorage();
                }
                else if (answer == "D")
                {
                    wallet.CheckBalance(); 
                }
            }

        }
    }
}