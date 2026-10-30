namespace InlämningC;
public class BicyclesApp
{
    public int Number {get; set;}
    public decimal Price {get;}
    public bool IsAvailable { get; set; } = true;
    public Customer? RentedBy { get; set; }
    public int RentalHours { get; set; }


    public BicyclesApp (int number, decimal pricer)
    {
        Number = number;
        Price= pricer;
        IsAvailable =true;
    }

        public void Rent()
    {
        IsAvailable = true;
    }
    public void Retun()
    {
        IsAvailable = true;
    }

    public decimal CalculatePrice(int hours)
    {
        return Price * hours;

    }
        public virtual void ShowInfo()
    {
        Console.WriteLine($"Fordonsnummer: {Number }");
    }



}