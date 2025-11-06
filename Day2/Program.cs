using Spectre.Console;
using Spectre.Console.Rendering;
namespace Backend_Basic;

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();
        CLI cli = new CLI();

        AnsiConsole.Write(new FigletText("My Calculator CLI Application").LeftJustified().Color(Color.Aqua));

        // we get our user input using Spectre.Console's Ask<double> input argument method
        double a = AnsiConsole.Ask<double>("Enter number [green]a[/]:");
        double b = AnsiConsole.Ask<double>("Enter number [green]b[/]:");

        // we can now create a table for our CLI calculator display, we also define our columns and set attritubes to our table
        var table = new Table();
        table.Border = TableBorder.Rounded;
        table.Title("Sharp Calculator CLI");
        table.AddColumn("Operation");
        table.AddColumn("Result");

        // we define our rows and pass arguments to our calculator object
        table.AddRow("[grey93]Addition (+)[/]", $"[green]{calculator.AddNumbers(a, b)}[/]");
        table.AddRow("Subtraction (-)", calculator.SubtractNumbers(a, b).ToString());
        table.AddRow("Multiply (*)", calculator.MultiplyNumbers(a, b).ToString());
        table.AddRow("Division (/)", calculator.DivideNumbers(a, b).ToString());
        table.AddRow("Power (^)", calculator.Power(a, b).ToString());
        table.AddRow("Absoulute value of a:", calculator.AbsoluteValue(a).ToString());
        table.AddRow("Pythagoras (c^2=a^2+b^2)", calculator.Pythagoras(a, b).ToString());
        table.AddRow($"Modulo (%)", calculator.Modulo(a, b).ToString());
        table.AddRow($"SinX (sin(x))", calculator.SinX(a).ToString());
        table.AddRow($"CosX (cos(x))", calculator.CosX(a).ToString());
        table.AddRow($"TanX (tan(x))", calculator.TanX(a).ToString());

        AnsiConsole.Write(table);


        // Viewable commandline interface
        cli.DrawCanvas(a);

        cli.DrawGraph(a, b);
    }
}
