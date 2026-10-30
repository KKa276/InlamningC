namespace InlämningC;
public class Bike: BicyclesApp
{
    public Bike (int number) : base (number, 40m)
    {
        
    }
    public override void ShowInfo()
    {
        string status;
        if (IsAvailable)
        {
            status ="Ledig";
        }
        else
        {
            status = "Uthyrd";
        }
        Console.WriteLine($"Fordonsnummer: {Number}, Type: Bike,"+ $" Price: {Price} SEK/hour, Status: {status}");
    }
}
