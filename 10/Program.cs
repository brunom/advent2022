char[] screen = new char[6 * 40];
int cycle = 1;
int X = 1;

void Paint()
{
    if (Math.Abs(X - (cycle - 1) % 40) <= 1)
    {
        screen[cycle - 1] = '#';
    }
    else
    {
        screen[cycle - 1] = '.';
    }
}

foreach (var line in File.ReadLines("input.txt"))
{
    Paint();
    if (line == "noop")
    {
        ++cycle;
        Console.WriteLine(new { cycle, X, line });
    }
    else if (line.StartsWith("addx"))
    {
        ++cycle;
        Paint();
        Console.WriteLine(new { cycle, X, line });

        Paint();

        int a = int.Parse(line.AsSpan().Slice("addx".Length + 1));
        X += a;
        ++cycle;
        Paint();
        Console.WriteLine(new { cycle, X });
    }
    else throw new ArgumentException();
}

for (int y = 0; y < 6; ++y)
{
    for (int x = 0; x < 40; ++x)
    {
        Console.Write(screen[y*40+x]);
    }
    Console.WriteLine();
}
