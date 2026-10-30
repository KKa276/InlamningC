
using InlämningC;

public class Ebike : BicyclesApp 
{
    public int BatteryLevel; 
    public Ebike (int number,int battery) : base (number ,70)
    {
        BatteryLevel= battery;
    
    }
    public void Charge()
    {
        BatteryLevel = 100;
    
    }
    public void UseBattery(int hours)
{
    BatteryLevel -= hours * 10;

    if (BatteryLevel < 0)
    {
        BatteryLevel = 0;
    }
}
    public override void ShowInfo()
    {
        base.ShowInfo();
        string status;
        if (IsAvailable)
        {
            status= "Ledigt";
        }
        else
        {
            status = "Uthyrd";
        }
        Console.WriteLine($"Fordonsnummer: {Number}, Type: Elcyckle, " + $"Price: {Price} SEk/timmen, Status: {status}," + $"Batteri: {BatteryLevel}% ");

    }
}