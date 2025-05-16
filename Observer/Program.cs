// FOR THIS PATTERN, THE .NET HAS ONE METHOD CALLED 'DELEGATE'
// THE DELEGATE SAVE ANY METHODS INTO A VARIABLE AND CALLS THIS VARIABLE WHEN A DETERMINED VALUE CHANGE
Person person = new Person("Yeshua", "jesusc@yahoo.com.br");

Console.WriteLine("==========DELEGATE==========");
RegisterDelegate register = new(person);
register.AddCallBack(new LogService().Log); // Add a callback to the register
register.Save();


// AND, WHAT IS DIFFERENT BETWEEN DELEGATE AND EVENT?
// WE CAN USE EVENT WITH DELEGATE
// AND WE CAN USE EVENT WITHOUT DELEGATE (FOR THIS, WE NEED SEND THE OBJECT AND THE EVENT AND RECEIVED INTO THE METHOD CALLED)
Console.WriteLine("\n\n==========EVENT==========");
RegisterEvent registerEvent = new(person);

//PURE EVENT, WITH SENDER OBJECT
registerEvent.@event += new GenerateNote().Generate;
registerEvent.@event += (sender, e) =>
{
    Console.WriteLine("Fim da rotina de salvamento");
};

//EVENT WITH DELEGATE PERSONALIZED
registerEvent.notify += new GeneratePayment().Generate;

registerEvent.Save();


public class RegisterDelegate
{
    public Person Person { get; private set; }
    Notify notify;

    public RegisterDelegate(Person person)
    {
        Person = person;

        notify += new EmailService().SendEmail;
        notify += new SmsService().SendSms;
    }

    public void Save()
    {
        Console.WriteLine($"Saving {Person.Name} with email {Person.Email}");

        notify?.Invoke(Person);
    }

    public void AddCallBack(Notify notify)
    {
        this.notify += notify;
    }

    public delegate void Notify(Person person);
}


public class RegisterEvent(Person person)
{
    public Person Person { get; private set; } = person;
    public event EventHandler<Person>? @event; // Event declaration
    public event Notify? notify; // Event declaration

    public void Save()
    {
        Console.WriteLine($"Saving {Person.Name} with email {Person.Email}");
        @event?.Invoke(this, Person); // Raise the event
        notify?.Invoke(Person); // Raise the event
    }

    public delegate void Notify(Person person);
}



// MODELS
public class GeneratePayment
{
    public void Generate(Person person)
    {
        Console.WriteLine("Generating payment for {0}", person);
    }
}
public class GenerateNote
{
    public void Generate(object sender, Person person)
    {
        Console.WriteLine("Generating note for {0}", person);
    }
}
public class LogService
{
    public void Log(Person person)
    {
        Console.WriteLine($"Logging {person.Name} with email {person.Email}");
    }
}
public class EmailService
{
    public void SendEmail(Person person)
    {
        Console.WriteLine($"Sending email to {person.Name} with email {person.Email}");
    }
}
public class SmsService
{
    public void SendSms(Person person)
    {
        Console.WriteLine($"Sending SMS to {person.Name} with email {person.Email}");
    }
}
public class Person(string name, string email)
{
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
}