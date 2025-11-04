public interface ICalculator
{
    /// <summary>
    /// Add two numbers together
    /// </summary>
    /// <param name="a">value of a</param>
    /// <param name="b">value of b</param>
    /// <returns>double</returns>
    double AddNumbers(double a, double b);
    /// <summary>
    /// Subtracts the value of b from a
    /// </summary>
    /// <param name="a">the value of a</param>
    /// <param name="b">the value of b</param>
    /// <returns>double</returns>
    double SubtractNumbers(double a, double b);
    /// <summary>
    /// Multiply the value of a to b
    /// </summary>
    /// <param name="a">value of a</param>
    /// <param name="b">value of b</param>
    /// <returns>double</returns>
    double MultiplyNumbers(double a, double b);
    /// <summary>
    /// Divides the value of a using b when b does not equal zero
    /// </summary>
    /// <param name="a">value of a</param>
    /// <param name="b">value of b</param>
    /// <returns>double</returns>
    double DivideNumbers(double a, double b);
}