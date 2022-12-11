using System.Diagnostics;

part1();
part2();

void part1()
{
    HashSet<(int x, int y)> visited = new();
    var h = (x: 0, y: 0);
    var t = (x: 0, y: 0);

    visited.Add(t);
    foreach (var line in File.ReadLines("input.txt"))
    {
        int steps = int.Parse(line.AsSpan().Slice(2));
        for (int i = 0; i < steps; ++i)
        {
            switch (line[0])
            {
                case 'U':
                    if (t.y < h.y)
                        t = h;
                    ++h.y;
                    break;
                case 'D':
                    if (t.y > h.y)
                        t = h;
                    --h.y;
                    break;
                case 'L':
                    if (t.x < h.x)
                        t = h;
                    ++h.x;
                    break;
                case 'R':
                    if (t.x > h.x)
                        t = h;
                    --h.x;
                    break;
                default:
                    throw new ArgumentException();
            }
            Debug.Assert(Math.Abs(h.x - t.x) <= 1);
            Debug.Assert(Math.Abs(h.y - t.y) <= 1);
            visited.Add(t);
        }
    }
    Console.WriteLine(visited.Count());
}

void part2()
{
    HashSet<(int x, int y)> visited = new();
    (int x, int y)[] rope = new (int x, int y)[10];

    visited.Add(rope.Last());
    foreach (var line in File.ReadLines("input.txt"))
    {
        int steps = int.Parse(line.AsSpan().Slice(2));
        for (int s = 0; s < steps; ++s)
        {
            switch (line[0])
            {
                case 'U':
                    ++rope[0].y;
                    break;
                case 'D':
                    --rope[0].y;
                    break;
                case 'L':
                    ++rope[0].x;
                    break;
                case 'R':
                    --rope[0].x;
                    break;
                default:
                    throw new ArgumentException();
            }
            for (int r = 1; r < rope.Count(); ++r)
            {
                ref var h = ref rope[r - 1];
                ref var t = ref rope[r];

                if (Math.Abs(h.x - t.x) > 1 ||
                    Math.Abs(h.y - t.y) > 1)
                {
                    int dx = Math.Sign(h.x - t.x);
                    int dy = Math.Sign(h.y - t.y);
                    t.x += dx;
                    t.y += dy;
                }

                Debug.Assert(Math.Abs(h.x - t.x) <= 1);
                Debug.Assert(Math.Abs(h.y - t.y) <= 1);
            }
            visited.Add(rope.Last());
        }
    }
    Console.WriteLine(visited.Count());
}