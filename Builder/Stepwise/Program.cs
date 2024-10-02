


var car = CarBuilder.Create() // CarBuilder
.OfType(CarType.SUV) // ISpecifyCarType
.OfYear(2022) // ISpecifyCarYear
.OfMake("Toyota") // ISpecifyCarMake
.OfLocation("Japan") // ISpecifyCarLocation
.Build(); // IBuildCar

System.Console.WriteLine(car);

public class Car{
    public CarType type { get; set; }
    public int year { get; set; }
    public string make { get; set; }

    public string location { get; set; }

    public override string ToString(){
        return $"Type: {type}, Year: {year}, Make: {make} , Location: {location}";
    }
}

public enum CarType{
    Sedan,
    SUV,
    Truck
}

public interface ISpecifyCarType{
    public ISpecifyCarYear OfType(CarType type);
}
public interface ISpecifyCarYear{
    public ISpecifyCarMake OfYear(int year);
}
public interface ISpecifyCarMake{
    public ISpecifyCarLocation OfMake(string make);
}

public interface ISpecifyCarLocation{
    public IBuildCar OfLocation(string location);
}
public interface IBuildCar{
    public Car Build();
}

public class Impl : ISpecifyCarType, ISpecifyCarYear, ISpecifyCarMake,  ISpecifyCarLocation ,IBuildCar{
    public Car car = new Car();
    
    public ISpecifyCarYear OfType(CarType type){
        car.type = type;
        return this;
    }

    public ISpecifyCarMake OfYear(int year){
        car.year = year;
        return this;
    }

    public IBuildCar OfLocation(string location){
        car.location = location;
        return this;
    }

    public ISpecifyCarLocation OfMake(string make){
        car.make = make;
        return this;
    }


    public Car Build(){
        return car;
    }
}

public class CarBuilder{
    public static Impl Create(){
        return new Impl();
    }
}