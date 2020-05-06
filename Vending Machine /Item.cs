namespace Vending_Machine_2
{
    public class Item
    {
        public int Price { get; set; }
        public string Name { get; set;  }
      

        public Item(int price, string name)
        {
            Price = price;
            Name = name; 

        }
    }
}