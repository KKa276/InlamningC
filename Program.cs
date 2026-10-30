

using InlämningC;

RentalSystem system = new RentalSystem();

bool running = true;

while (running)
{
    Console.WriteLine("\n=== Kajens Cykeluthyrning ===");
    Console.WriteLine("1. Visa cyklar");
    Console.WriteLine("2. Registrera kund");
    Console.WriteLine("3. Hyr cykel");
    Console.WriteLine("4. Lämna tillbaka cykel");
    Console.WriteLine("5. Ladda elcykel");
    Console.WriteLine("6. Avsluta");
    Console.Write("Välj: ");
    string choice = Console.ReadLine() ?? "";

    //system.ShowBicylesApps();
    //system.RegisterCustomer();
    //system.RentBicyclesApp();
   // system.ReturnBicyclesApp();
    //system.ChargeEbike();


    if (choice == "1")
    {
        system.ShowBicylesApps();
    }
    else if (choice == "2")
    {
        system.RegisterCustomer();
    }
    else if (choice == "3")
    {
        system.RentBicyclesApp();
    }
    else if (choice == "4")
    {
        system.ReturnBicyclesApp();
    }
    else if (choice == "5")
    {
        system.ChargeEbike();
    }
    else if (choice == "6")
    {
        running = false;
        Console.WriteLine("Programmet avslutas.");
    }
    else
    {
        Console.WriteLine("Ogiltigt val. Försök igen.");
    }
}

