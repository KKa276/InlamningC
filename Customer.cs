namespace InlämningC;

public class Customer
{
    public int Number;
    public string Name;
    public int Age;
    public bool IsMember;

    public Customer(int number, string name, int age, bool member)
    {
        Number = number;
        Name = name;
        Age = age;
        IsMember = member;
    }
    public void ShowInfo()
    {
        Console.WriteLine($"Fordonsnummer: {Number}, Namn: {Name}, " + $"Ålder: {Age}, Medlem: {IsMember}");
    }

}