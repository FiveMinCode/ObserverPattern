// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Hello, World!");

Subject product = new Subject("Lee cooper shorts", 123, "Out of Stock");
Observer user1 = new Observer("John");
user1.AddSubscriber(product);
Observer user2 = new Observer("Alek");
user2.AddSubscriber(product);
Observer user3 = new Observer("Rita");
user3.AddSubscriber(product);
Console.WriteLine("Lee Cooper shorts current availability state : " + product.GetAvailability());
Console.WriteLine();
product.SetAvailability("Available");
Console.Read();


public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

public class Subject: ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private string ProductName { get; set; }
    private int ProductId { get; set; }
    private string Availability { get; set; }

    public Subject(string productName, int productId, string availability)
    {
        ProductName = productName;
        ProductId = ProductId;
        Availability = availability;
    }

    public string GetAvailability()
    {
        return Availability;
    }

    public void SetAvailability(string availability)
    {
        this.Availability = availability;
        Console.WriteLine("Availability status changed");
        NotifyObservers();
    }

    public void RegisterObserver(IObserver observer)
    {
        Console.WriteLine("Observer Added: " + ((Observer)observer).UserName);
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        Console.WriteLine("Observer Removed: " + ((Observer)observer).UserName);
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        Console.WriteLine("Product Name : " + ProductName + ", Product Id "
            + ProductId + " is now Available. Notifying Users.");
        Console.WriteLine();
        foreach (var observer in observers)
        {
            observer.Update(Availability);
        }
    }
}


public interface IObserver
{
    void Update(string availability);
}

public class Observer: IObserver
{
    public string UserName { get; set; }
    public Observer(string username)
    {
        UserName = username;
    }

    public void AddSubscriber(ISubject subject)
    {
        subject.RegisterObserver(this);
    }

    public void RemoveSubscriber(ISubject subject)
    {
        subject.RemoveObserver(this);
    }

    public void Update(string availability)
    {
        Console.WriteLine(UserName + ", Procut is now " + availability);
    }
}