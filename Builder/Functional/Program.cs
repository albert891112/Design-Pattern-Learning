var person = new Builder()
    .Called("John")
    .Age(30)
    .Address("123 London Road")
    .PhoneNumber("1234567")
    .Email("abc@gmail.com")
    .Build();

    System.Console.WriteLine(person);

public class Person{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"Name : {Name} , Age : {Age} , Address : {Address} , PhoneNumber : {PhoneNumber} , Email : {Email}";
    }

}


public class FunctionalBuilder<TSubject , TSelf>
 where TSelf : FunctionalBuilder<TSubject , TSelf>
 where TSubject : new(){
    private TSubject _person = new TSubject();

    public readonly List<Func<TSubject , TSubject>> actions = new List<Func<TSubject , TSubject>>();
    
    public TSelf Do(Action<TSubject> action)
     => Addaction(action);

    private TSelf Addaction(Action<TSubject> action){
        actions.Add(p => { action(p); return p;});
        return (TSelf)this;
    }

    public TSubject Build()
     => actions.Aggregate(_person , (p , f) => f(p));
 }


 public class Builder : FunctionalBuilder<Person , Builder>{
    public Builder Called(string name)
        => Do(p => p.Name = name);

    public Builder Age(int age)
        => Do(p => p.Age = age);

    public Builder Address(string address)
        => Do(p => p.Address = address);

    public Builder PhoneNumber(string phoneNumber)
        => Do(p => p.PhoneNumber = phoneNumber);
    
    public Builder Email(string email)
        => Do(p => p.Email = email);
 }


 
