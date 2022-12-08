string[] lines = File.ReadAllLines("input.txt");
int sum100000 = 0;
int iLine = 0;
int target = -1;
int best = -1;
int total = TotalSize();
Console.WriteLine(sum100000);

iLine = 0;
best = 70000000;
target = total + 30000000 - 70000000;
TotalSize();
Console.WriteLine(best);

int TotalSize()
{
    int total = 0;
    while (iLine < lines.Length)
    {
        string line = lines[iLine];
        ++iLine;
        if (line == "$ cd ..")
        {
            break;
        }
        else if (char.IsAsciiDigit(line.First()))
        {
            int size = int.Parse(line.AsSpan().Slice(0, line.IndexOf(' ')));
            total += size;
        }
        else if (line.StartsWith("$ cd"))
        {
            int size = TotalSize();
            total += size;
        }
    }
    if (target <= total  && total < best)
    {
        best = total;
    }
    if (total < 100000)
    {
        sum100000 += total;
    }
    return total;
}