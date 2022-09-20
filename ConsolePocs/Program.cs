// See https://aka.ms/new-console-template for more information

var obj1 = new Obj(10);
var obj2 = new Obj(11);
var obj3 = new Obj(10);

Console.WriteLine("1 == 2: " + (obj1 != obj2));
Console.WriteLine("2 == 3: " + (obj2 != obj3));
Console.WriteLine("1 == 3: " + (obj1 != obj3));

public class Obj : ValueObject
{
    public int Age { get; set; }

    public Obj(int age) => Age = age;

    public override bool Equals(ValueObject? other) =>
        other is Obj obj &&
        Age == obj.Age;
}

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract bool Equals(ValueObject? other);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((ValueObject)obj);
    }

    public override int GetHashCode()
    {
        return this.GetHashCode();
    }

    public static bool operator ==(ValueObject a, ValueObject b)
    {
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject a, ValueObject b)
    {
        return !(a == b);
    }
}