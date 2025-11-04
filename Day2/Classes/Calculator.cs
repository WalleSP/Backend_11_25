/// <summary>
/// A basic calculator class, that supports basic expressions & also utilizes builtin methods
/// </summary>
public class Calculator : ICalculator
{
    public double AddNumbers(double a, double b)
    {
        return a + b;
    }

    public double SubtractNumbers(double a, double b)
    {
        return a - b;
    }

    public double MultiplyNumbers(double a, double b)
    {
        return a * b;
    }

    public double DivideNumbers(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by 0");
        }
        return a / b;
    }

    public double Power(double a, double exponent)
    {
        return Math.Pow(a, exponent);
    }

    public double AbsoluteValue(double a)
    {
        return Math.Abs(a);
    }

    public double Pythagoras(double a, double b)
    {
        double c = Math.Pow(a, 2) + Math.Pow(b, 2);
        return Math.Sqrt(c);
    }

    public double Modulo(double a, double b)
    {
        return a % b;
    }

    public double SinX(double x)
    {
        return Math.Sin(x);
    }

    public double CosX(double x)
    {
        return Math.Cos(x);
    }

    public double TanX(double x)
    {
        return Math.Tan(x);
    }
}