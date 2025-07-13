using System.ComponentModel;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {



           




        }
    }
}
public class Calculator
{

    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    public static double Add(double a, double b)
    {
        return a + b;
    }

}
public class Rectangle
{
    private int Width;
    private int Height;

    public Rectangle()
    {
        Width = 0;
        Height = 0;
    }

 
    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

      
    public Rectangle(int size)
    {
        Width = size;
        Height = size;
    }
}
public class Complex
{
    private int Real;
    private int Imag;
    public Complex(int real, int imag)
    {
        Real = real;
        Imag = imag;
    }

    
    public static Complex operator +(Complex c1, Complex c2)
    {
        return new Complex(
            c1.Real + c2.Real,
            c1.Imag + c2.Imag
        );
    }

    
    public static Complex operator -(Complex c1, Complex c2)
    {
        return new Complex(
            c1.Real - c2.Real,
            c1.Imag - c2.Imag
        );
    }
    public  string Display()
    {
        return $"{Real}+{Imag}i";
    }
}
class Employee
{
    public virtual void Work()
    {
        Console.WriteLine("Employee is working");
    }
}

class Manager : Employee
{
    public override void Work()
    {
        Employee emp=new Employee();
        emp.Work();
        Console.WriteLine("Manager is managing");
    }
}
class BaseClass
{
    public virtual void DisplayMessage()
    {
        Console.WriteLine("Message from BaseClass");
    }
}

class DerivedClass1 : BaseClass
{
    public override void DisplayMessage()
    {
        Console.WriteLine("Message from DerivedClass1");
    }
}

class DerivedClass2 : BaseClass
{
    public new void DisplayMessage()
    {
        Console.WriteLine("Message from DerivedClass2");
    }
}
// new do in compile time
// override do in run time
class Duration
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    
    public Duration(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }
    public Duration(int totSeconds)
    {
        Hours = totSeconds / 3600;
        totSeconds %= 3600;
        Minutes = totSeconds / 60;
        Seconds = totSeconds % 60;
    }


    public override string ToString()
    {
        return $"Hours: {Hours}, Minutes :{Minutes}, Seconds :{Seconds}";
    }

    public int ToSeconds()
    { return Hours * 3600 + Minutes * 60 + Seconds; }
    public override bool Equals(object obj)
    {
        if (obj == null )
            return false;

        Duration d = (Duration)obj;
        if (this.Hours == d.Hours && this.Minutes == d.Minutes &&
               this.Seconds == d.Seconds)
            return true ;
        return false ;
    }
    
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    public static Duration operator +(Duration d1, Duration d2)
    {
      return  new Duration(d1.Hours+d2.Hours,d1.Minutes+d2.Minutes,d1.Seconds +d2.Seconds);
    }
    public static Duration operator +(Duration d1, int seconds)
    {
        
        return new Duration(d1.ToSeconds() + seconds);

    }
    public static Duration operator +(int seconds, Duration d)
    {
        return d + seconds;

    }
    public static Duration operator ++(Duration d)
    {  return new Duration(d.ToSeconds() + 60); }
    public static Duration operator --(Duration d)
    { return new Duration(Math.Max(d.ToSeconds() - 60,0)); }
    public static Duration operator -(Duration d1, Duration d2)
    {

        return new Duration (Math.Max(d1.ToSeconds()-d2.ToSeconds(), 0)); 


    }
    public static bool operator >(Duration d1, Duration d2)
    { 
        return d1.ToSeconds() > d2.ToSeconds();
    }
    public static bool operator <(Duration d1, Duration d2)
    {
        return d1.ToSeconds() > d2.ToSeconds();
    }
    public static bool operator >=(Duration d1, Duration d2)
    { 
       return d1.ToSeconds() >= d2.ToSeconds();
    }
    
    public static bool operator <=(Duration d1, Duration d2)
    {
        return d1.ToSeconds() <= d2.ToSeconds();
    }
    public static bool operator true(Duration d) { return d.ToSeconds() > 0; }
    public static bool operator false(Duration d) {return d.ToSeconds() == 0; }
    public static explicit operator DateTime(Duration d)
    {
        return DateTime.Today.AddSeconds(d.ToSeconds());
    }
}

