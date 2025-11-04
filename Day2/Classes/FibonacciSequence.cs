using Spectre.Console;
public static class FibonacciSequence
{
    public static void CalculateSequenceSignedInt()
    {
        int a = 0;
        int b = 1;
        int index = 1;

        AnsiConsole.MarkupLine($"[green]Fib({0}) = {a}[/]");
        AnsiConsole.MarkupLine($"[green]Fib({1}) = {b}[/]");

        try
        {
            checked
            {
                while (true)
                {
                    int next = a + b;
                    index++;
                    AnsiConsole.MarkupLine($"[green]Fib({index})[/] = {next}");
                    a = b;
                    b = next;
                }
            }
        }
        catch (OverflowException)
        {
            AnsiConsole.MarkupLine($"[red]Overflow happened on index: {index}[/]");
        }
    }
}