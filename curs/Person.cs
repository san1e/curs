public class Person
{
    public string Username { get; set; }
    public PersonType Type { get; set; }

    public Person(string username, PersonType type)
    {
        Username = username;
        Type = type;
    }
}

public enum PersonType
{
    User,
    Sponsor
}
