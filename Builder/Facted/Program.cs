
Person person = new PersonBuilder()
.Called("Albert")
.AgedIs(25)
.Works
.WorksAsA("Develsper")
.WorksAt("Google")
.Live
.City("New York")
.Country("USA")
.LiveIn("1234");

System.Console.WriteLine(person);


public class Person{

    //personInfo
    public string Name { get; set; }
    public int Age { get; set; }

    //personJob
    public string Job { get; set; }
    public string  CompanyLocation { get; set; }

    //personlive
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public static implicit operator Person(PersonBuilder pb)
    {
        return pb._person;
    }



    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Job: {Job}, CompanyLocation: {CompanyLocation}, Address: {Address}, City: {City}, Country: {Country}";
    }
}

public class PersonBuilder{
    public Person _person = new Person();

    public PersonJobBuilder Works => new PersonJobBuilder(_person);
    public PersonLiveBuilder Live => new PersonLiveBuilder(_person);

    public PersonBuilder Called(string name){
        _person.Name = name;
        return this;
    }

    public PersonBuilder AgedIs(int age){
        _person.Age = age;
        return this;
    }

}


public class PersonLiveBuilder : PersonBuilder{
    public PersonLiveBuilder(Person person){
        this._person = person;
    }

    public PersonLiveBuilder LiveIn(string address){
        _person.Address = address;
        return this;
    }

    public PersonLiveBuilder City(string city){
        _person.City = city;
        return this;
    }

    public PersonLiveBuilder Country(string country){
        _person.Country = country;
        return this;
    }
}
public class  PersonJobBuilder : PersonBuilder
{
    public PersonJobBuilder(Person person){
        this._person = person;
    }


    public PersonJobBuilder WorksAsA(string job){
        _person.Job = job;
        return this;
    }

    public PersonJobBuilder WorksAt(string companyLocation){
        _person.CompanyLocation = companyLocation;
        return this;
    }
}