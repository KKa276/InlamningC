namespace InlämningC;

public class RentalSystem
{
    private List<BicyclesApp> bicyclesApps = new List<BicyclesApp>();
    private List<Customer> Customers = new List<Customer>();

    private int nextBicyclesApp = 1;
    private int nextCustomer = 1;

    public RentalSystem()
    {
        bicyclesApps.Add(new Bike(nextBicyclesApp++));
        bicyclesApps.Add(new Bike(nextBicyclesApp++));

        bicyclesApps.Add(new Ebike(nextBicyclesApp++, 80));
        bicyclesApps.Add(new Ebike(nextBicyclesApp++, 25));


    }
    public void ShowBicylesApps()
    {
        Console.WriteLine("\n=== Kajens Cykeluthyrning ===");
        Console.WriteLine("Nr   Typ       Status   Batteri");

        foreach (BicyclesApp bicycle in bicyclesApps)
        {
            string typ = "Cykel";
            string batteri = "-";
            string status = "ledig";

            if (bicycle is Ebike ebike)
            {
                typ = "Elcykel";
                batteri = ebike.BatteryLevel + " %";
            }

            if (!bicycle.IsAvailable)
            {
                status = "uthyrd";
            }

            Console.WriteLine($"{bicycle.Number,-5}{typ,-10}{status,-9}{batteri}");
        }
    }
    public void RegisterCustomer()
    {
        Console.Write("Namn:");
        string name = Console.ReadLine() ?? "";

        if (name == "")

        {
            Console.WriteLine("Skriv ditt namn");
            return;
        }
        else
        {
            Console.Write("Ålder: ");

        }
        string input = Console.ReadLine() ?? "";
        if (int.TryParse(input, out int age))
        {
            if (age < 0)
            {
                Console.WriteLine("Ogiltig ålder");
                return;
            }
        }


        Console.Write("Medlem? (j/n): ");
        string answer = Console.ReadLine() ?? "";
        bool member;
        if (answer.ToLower() == "j")
        {
            member = true;
        }
        else
        {
            member = false;
        }
        Customer customer = new Customer(nextCustomer, name, age, member);
        Customers.Add(customer);
        nextCustomer++;
        Console.WriteLine($"Kund: {customer.Number}");

    }
    public void RentBicyclesApp()
    {
        if (Customers.Count == 0)
        {
            Console.WriteLine("Registrera kund först.");
            return;
        }
        else
        {
            Console.Write(" Ange kundnummer: ");

        }
        if (!int.TryParse(Console.ReadLine(), out int customerNumber))
        {
            Console.WriteLine("Ogiltig nummer.");
            return;
        }
        Customer? customer = null;

        foreach (Customer c in Customers)
        {
            if (c.Number == customerNumber)
            {
                customer = c;
            }
        }
        if (customer == null)
        {
            Console.WriteLine("Kunden hittades inte");
            return;
        }
        else
        {
            ShowBicylesApps();
        }
        Console.WriteLine("Fordonnummer: ");
        if (!int.TryParse(Console.ReadLine(), out int BicylesNummer))
        {
            Console.WriteLine("Ogiltig nummer.");
            return;
        }
        BicyclesApp? bicyclesApp = null;
        foreach (BicyclesApp b in bicyclesApps)
        {
            if (b.Number == BicylesNummer)
            {
                bicyclesApp = b;
            }
        }
        if (bicyclesApp == null)
        {
            Console.WriteLine("Fordonet hittades inte.");
            return;
        }


        if (!bicyclesApp.IsAvailable)
        {
            Console.WriteLine("Fordonet är redan uthyrt.");
            return;
        }

        if (bicyclesApp is Ebike ebike)
        {
            if (customer.Age < 18)
            {
                Console.WriteLine("Du måste vara minst 18 år.");
                return;
            }
            else if (ebike.BatteryLevel < 30)
            {
                Console.WriteLine("Ladda elcykeln först.");
                return;
            }
        }
        else if (customer.Age < 15)
        {
            Console.WriteLine("Du måste vara minst 15 år.");
            return;
        }

        Console.Write("Antal timmar: ");

        if (!int.TryParse(Console.ReadLine(), out int hours))
        {
            Console.WriteLine("Ogiltigt antal timmar.");
            return;
        }


        bicyclesApp.RentedBy = customer;
        bicyclesApp.RentalHours = hours;
        bicyclesApp.IsAvailable = false;

        decimal basePrice = bicyclesApp.Price * hours;
        decimal price = basePrice;


        if (customer.IsMember)
        {
            price = price * 0.90m;
            Console.WriteLine("Du får 10 % medlemsrabatt.");
        }
        else
        {
            Console.WriteLine("Du betalar ordinarie pris.");
        }

        Console.WriteLine("Fordonet är uthyrt.");
        Console.WriteLine($"Ordinarie pris: {basePrice:F2} kr");
        Console.WriteLine($"Att betala: {price:F2} kr");
        bicyclesApp.RentedBy = customer;
        bicyclesApp.RentalHours = hours;
        bicyclesApp.IsAvailable = false;




    }

    public void ReturnBicyclesApp()
    {
        Console.Write("Fordonsnummer: ");

        if (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.WriteLine("Ogiltigt nummer.");
            return;
        }

        BicyclesApp? bicyclesApp = null;

        foreach (BicyclesApp b in bicyclesApps)
        {
            if (b.Number == number)
            {
                bicyclesApp = b;
            }
        }

        if (bicyclesApp == null)
        {
            Console.WriteLine("Fordonet hittades inte.");
            return;
        }
        else if (bicyclesApp.IsAvailable)
        {
            Console.WriteLine("Fordonet är inte uthyrt.");
            return;
        }
        Customer customer = bicyclesApp.RentedBy!;
        int hours = bicyclesApp.RentalHours;

        decimal originalPrice = bicyclesApp.Price * hours;
        decimal discount = 0;

        if (customer.IsMember)
        {
            discount = originalPrice * 0.10m;
        }

        decimal total = originalPrice - discount;

        string typ = "Cykel";

        if (bicyclesApp is Ebike)
        {
            typ = "Elcykel";
        }

        Console.WriteLine("\n=== KVITTO ===");
        Console.WriteLine($"{typ}, {hours} timmar à {bicyclesApp.Price} kr");
        Console.WriteLine($"Ordinarie pris: {originalPrice:F2} kr");
        Console.WriteLine($"Rabatt: {discount:F2} kr");
        Console.WriteLine($"Att betala: {total:F2} kr");

        if (bicyclesApp is Ebike ebike)
        {
            ebike.UseBattery(hours);
            Console.WriteLine($"Batteri kvar: {ebike.BatteryLevel} %");
        }

        bicyclesApp.IsAvailable = true;
        bicyclesApp.RentedBy = null;
        bicyclesApp.RentalHours = 0;

        Console.WriteLine("Fordonet har lämnats tillbaka.");
    }

    public void ChargeEbike()
    {
        Console.Write("Elcykelns fordonsnummer: ");

        if (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.WriteLine("Ogiltigt nummer.");
            return;
        }

        BicyclesApp? bicyclesApp = null;

        foreach (BicyclesApp b in bicyclesApps)
        {
            if (b.Number == number)
            {
                bicyclesApp = b;
            }
        }

        if (bicyclesApp == null)
        {
            Console.WriteLine("Fordonet hittades inte.");
            return;
        }

        if (bicyclesApp is Ebike ebike)
        {
            if (!ebike.IsAvailable)
            {
                Console.WriteLine("Lämna tillbaka elcykeln innan du laddar den.");
                return;
            }
            else
            {
                ebike.Charge();
                Console.WriteLine("Elcykeln är laddad till 100 %.");
            }
        }
        else
        {
            Console.WriteLine("Det här fordonet är inte en elcykel.");
        }
    }
}







