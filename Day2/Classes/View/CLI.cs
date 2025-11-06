using Spectre.Console;
using Spectre.Console.Rendering;
public class CLI
{
    public void DrawCanvas(double c)
    {
        const int width = 30; // pixel size
        const int height = 15;

        var canvas = new Canvas(width, height);

        // draw axis
        int centerY = height / 2;

        for (int x = 0; x < width; x++)
        {
            canvas.SetPixel(x, centerY, Color.Aqua);
        }
        // draw sin(x)
        for (int x = 0; x < width; x++)
        {
            double radians = x * (x * Math.PI / width);
            double yValue = Math.Sin(radians);
            int y = centerY - (int)(yValue * (height / 2 - 1));

            if (y >= 0 && y < height)
            {
                canvas.SetPixel(x, y, Color.Red);
            }
        }

        AnsiConsole.Write(canvas);
    }

    public void DrawGraph(double x, double y)
    {
        var funcName = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose a function to [green]plot[/]:")
                .AddChoices(new[]
                {
                    "sin(x)",
                    "cos(x)",
                    "x^2",
                    "sqrt(x)",
                    "log(x)",
                    "x * sin(x)",
                })
        );

        Func<double, double> func = funcName switch
        {
            "sin(x)" => x => Math.Sin(x),
            "cos(x)" => x => Math.Cos(x),
            "x^2" => x => Math.Pow(x, 2),
            "sqrt(x)" => x => x >= 0 ? Math.Sqrt(x) : double.NaN,
            "log(x)" => x => x > 0 ? Math.Log(x) : double.NaN,
            "x * sin(x)" => x => x * Math.Sin(x),
            // the underscore, is used as a "discard" value
            _ => x => 0
        };

        PlotFunctions(func, funcName);
    }

    private static void PlotFunctions(Func<double, double> func, string title)
    {
        const int width = 100;
        const int height = 10;
        const double xMinValue = -10;
        const double xMaxValue = 10;

        var canvas = new Canvas(width, height);

        // draw our axes
        int xAxis = height / 2;
        int yAxis = (int)((0 - xMinValue) / (xMaxValue - xMinValue) * width);
        // we use two for-loops, to iterate over our axis, and draw them.
        for (int x = 0; x < width; x++)
        {
            canvas.SetPixel(x, xAxis, Color.Grey);
        }
        for (int y = 0; y < height; y++)
        {
            if (yAxis >= 0 && yAxis < width)
            {
                canvas.SetPixel(yAxis, y, Color.Grey);
            }
        }

        // on the lines below, we draw our functions
        for (int pixel = 0; pixel < width; pixel++)
        {
            double xValue = xMinValue + ((double)pixel / width) * (xMaxValue - xMinValue);
            double yValue = func(xValue);

            if (double.IsNaN(yValue) || double.IsInfinity(yValue))
            {
                continue;
            }

            int posY = height / 2 - (int)(yValue * (height / 4));

            if (posY >= 0 && posY < height)
            {
                canvas.SetPixel(pixel, posY, Color.Red);
            }
        }

        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"[bold yellow]Function:[/] [green]{title}[/]");
        AnsiConsole.Write(canvas);
        AnsiConsole.WriteLine();
    }
}