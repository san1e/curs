public abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Description { get; set; }

    protected Animal(string name, int age, string description)
    {
        Name = name;
        Age = age;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Name}, Age: {Age}, Description: {Description}";
    }
}

public class Dog : Animal
{
    public string Breed { get; private set; }

    public Dog(string name, int age, string description, string breed)
        : base(name, age, description)
    {
        Breed = breed;
    }

    public override string ToString()
    {
        return $"Dog: {base.ToString()}, Breed: {Breed}";
    }
}

public class Cat : Animal
{
    public string Characteristics { get; private set; }

    public Cat(string name, int age, string description, string characteristics)
        : base(name, age, description)
    {
        Characteristics = characteristics;
    }

    public override string ToString()
    {
        return $"Cat: {base.ToString()}, Characteristics: {Characteristics}";
    }
}
