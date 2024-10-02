



var person = new Builder()
    .Called("John")
    .WorksAsA("Developer")
    .Age(25)
    .Build();

System.Console.WriteLine(person.Name);
System.Console.WriteLine(person.Job);
System.Console.WriteLine(person.Age);


public class Person {
    public string Name { get; set; }
    public string Job { get; set; }

    public int Age { get; set; }
}

public class Builder : PersonAgeBuilder<Builder>
{
}

public class PersonBuilder {
    protected Person _person = new Person();

    public Person Build() => _person;
}

public class PersonInfoBuilder<self> : PersonBuilder
    where self : PersonInfoBuilder<self>
{
    public self Called(string name){
        _person.Name = name;
        return (self)this;
    }
}

public class PersonJobBuilder<self> : PersonInfoBuilder<PersonJobBuilder<self>>
    where self : PersonJobBuilder<self>
{
    public self WorksAsA(string job){
        _person.Job = job;
        return (self)this;
    }

}

public class PersonAgeBuilder<self> : PersonJobBuilder<PersonAgeBuilder<self>>
    where self : PersonAgeBuilder<self>
{
    public self Age(int age){
        _person.Age = age;
        return (self)this;
    }
}

