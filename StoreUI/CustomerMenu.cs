namespace UI;

public class CustomerMenu{
    public CustomerMenu(){}

    public void Start(){
        bool exit = false;
        while(!exit){
            Console.WriteLine("Hello and Welcome!");
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("1. Place an order");
            Console.WriteLine("2. See your order history");
            Console.WriteLine("x. Exit");
            string input = Cnsole.ReadLine();
            switch(input){
                case "1":
                break;
                case "2":
                break;
                case "x":
                    Console.WriteLine("Have a nice day!");
                    exit = true;
                break;
                default:
                    Console.WriteLine("I'm sorry friend, I'm afraid I can't do that.");
                break;
            }
        }
    }
}