using Spectre.Console;
using Spectre.Console.Rendering;
namespace Backend_Basic;

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();
        CLI cli = new CLI();

        while (true)
        {
            AnsiConsole.Clear();
            //AnsiConsole.Write(new FigletText("My Calculator CLI Application").LeftJustified().Color(Color.Aqua));

            AnsiConsole.Write(new Panel(new Markup("[bold green]Terminal calculator[/]")).Border(BoxBorder.Double).Header("[yellow]CLI Calculator[/]", Justify.Center).Padding(1, 1, 1, 1));


            // add operator as a choice in the UI
            var operation = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Choose a [cyan]operator[/]:")
                .AddChoices("+ (addition)", "- (subtraction)", "/ (division)", "* (multiplication)", "^ (power)", "abs (absolute value)", "pythag (pythagoras)", "% (modulo)", "sinx (sin(x))", "cosx (cox(x))", "tanx (tan(x))", "exit (exit program)")
            );

            // we use a pattern matching expression, on our operation variable
            if (operation == "exit" || operation == "Exit")
            {
                AnsiConsole.MarkupLine("[red]Exiting program..[/]");
                break;
            }

            // we get our user input using Spectre.Console's Ask<double> input argument method
            double a = AnsiConsole.Ask<double>("Enter number [green]a[/]:");
            double b = AnsiConsole.Ask<double>("Enter number [green]b[/]:");

            // we "iterate" over our selection prompt using a range.
            string symbol = operation[..1];
            double result = 0;
            bool success = true;

            try
            {
                result = symbol switch
                {
                    "+" => calculator.AddNumbers(a, b),
                    "-" => calculator.SubtractNumbers(a, b),
                    "*" => calculator.MultiplyNumbers(a, b),
                    "/" => calculator.DivideNumbers(a, b),
                    "^" => calculator.Power(a, b),
                    "abs" => calculator.AbsoluteValue(a),
                    "pythag" => calculator.Pythagoras(a, b),
                    "sinx" => calculator.SinX(a),
                    "cosx" => calculator.CosX(a),
                    "tanx" => calculator.TanX(a),
                    _ => throw new InvalidOperationException("Invalid operator selected..")
                };
            }
            catch (Exception e)
            {
                success = false;
                AnsiConsole.MarkupLine($"[red bold]Error:[/] {e.Message}");
            }

            // draw the UI of the calculator
            var expression = $"{a} {symbol} {b}"; // our main expression
            var display = new Panel($"[bold yellow]{expression}[/]\n= [bold green]{(success ? result.ToString() : "Error")}[/]")
            .Header("[blue]Display[/]", Justify.Center).Border(BoxBorder.Double).Padding(1, 1);

            AnsiConsole.WriteLine(); // empty line in the console
            AnsiConsole.Write(display);

            var resultsTable = new Table().Border(TableBorder.Rounded).Title("CLI Calculator");
            resultsTable.AddColumn("Operand 1");
            resultsTable.AddColumn("Operator");
            resultsTable.AddColumn("Operand 2");
            resultsTable.AddColumn("Result");

            resultsTable.AddRow(a.ToString(), symbol, b.ToString(), success ? result.ToString() : "[red]An error occured[/]");

            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[grey]Press any key to continue..[/]");
            Console.ReadKey(); // halts the program, until any key is pressed.
        }
        // Viewable commandline interface
        // cli.DrawCanvas(a);

        // cli.DrawGraph(a, b);
    }
}
