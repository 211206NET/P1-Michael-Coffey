namespace UI;

using DL;

public static class MenuFactory{
    public static IMenu GetMenu(string menuString){
        menuString = menuString.ToLower();
        string connectionString = File.ReadAllText("connectionString.txt");
        IMRepo repo = new DBRepo(connectionString);
        MBL bl = new MBL(repo);
        switch(menuString){
            case "main":
                return new MainMenu(bl);
            case "manager":
                return new ManagerMenu(bl);
            case "customer":
                return new CustomerMenu(bl);
            default:
                return new MainMenu(bl);
        }
    }
}