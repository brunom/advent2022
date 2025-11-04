using System.Collections.Immutable;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;

public class Day12
{
    [Fact]
    public void Test1()
    {
        var map =
            File.ReadLines("input.txt")
            .Select(line => line.Where(ch => !char.IsWhiteSpace(ch)).ToArray())
            .ToArray();
        int rows = map.Length;
        int cols = map[0].Length;
        char ReadMap(int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols)
                return (char)('z' + 2);
            return map[row][col];
        }
        (int row, int col) start = default;
        (int row, int col) end = default;
        for (int row = 0; row < rows; ++row)
        {
            for (int col = 0; col < cols; ++col)
            {
                char ch = map[row][col];
                if (ch == 'S')
                {
                    start = (row, col);
                    map[row][col] = 'a';
                }
                else if (ch == 'E')
                {
                    end = (row, col);
                    map[row][col] = 'z';
                }
            }
        }
        List<(int row, int col, int dist)> byDist = new();
        // made by br1 and br2
        Dictionary<(int row, int col), int> byPos = new();
        byDist.Add((start.row, start.col, 0));
        byPos.Add(start, 0);

        for (int iSquare = 0; iSquare < byDist.Count; ++iSquare)
        {
            char oldHeight = ReadMap(byDist[iSquare].row, byDist[iSquare].col);
            void visit(int row, int col)
            {
                char newHeight = ReadMap(row, col);
                if (oldHeight + 1 < newHeight)
                    return;
                if (byPos.ContainsKey((row, col)))
                    return;
                int newDist = byDist[iSquare].dist + 1;
                byDist.Add((row, col, newDist));
                byPos.Add((row, col), newDist);
            }
            visit(byDist[iSquare].row + 0, byDist[iSquare].col + 1);
            visit(byDist[iSquare].row + 0, byDist[iSquare].col - 1);
            visit(byDist[iSquare].row + 1, byDist[iSquare].col + 0);
            visit(byDist[iSquare].row - 1, byDist[iSquare].col + 0);
        }

        //byDist = por distancia.byPos = por posision
        Assert.Equal(31, byPos[end]);
    }
}
