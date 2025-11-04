using System.Collections.Immutable;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Numerics;
using System.Text;

public class Day11
{
    [Fact]
    public void Test1()
    {
        var monkeysExample = new (long inspections, List<long> levels, Func<long, long> operation, int test, int m1, int m2)[] {
            (
                0,
                [ 79, 98, ],
                old => old * 19,
                23, 2, 3
            ),
            (
                0,
                [ 54, 65, 75, 74, ],
                old => old + 6,
                19, 2, 0
            ),
            (
                0,
                [ 79, 60, 97, ],
                old => old * old,
                13, 1, 3
            ),
            (
                0,
                [ 74, ],
                old => old + 3,
                17, 0, 1
            ),
        };
        var monkeysInput = new (long inspections, List<long> levels, Func<long, long> operation, int test, int m1, int m2)[] {
            (
                0,
                [ 57, ],
                old => old * 13,
                11,
                3,
                2
            ),
            (
                0,
                [  58, 93, 88, 81, 72, 73, 65, ],
                old => old + 2,
                7,
                6,
                7
            ),
            (
                0,
                [65, 95, ],
                old => old + 6,
                13,
                3,
                5
            ),
            (
                0,
                [58, 80, 81, 83],
                old => old * old,
                5,
                4,
                5
            ),
            (
                0,
                [ 58, 89, 90, 96, 55 ],
                old => old + 3,
                3,
                1,
                7
            ),
            (
                0,
                [ 66, 73, 87, 58, 62, 67 ],
                old => old * 7,
                17,
                4,
                1
            ),
            (
                0,
                [  85, 55, 89 ],
                old => old + 4,
                2,
                2,
                0
            ),
            (
                0,
                [ 73, 80, 54, 94, 90, 52, 69, 58 ],
                old => old + 7,
                19,
                6,
                0
            ),
        };
        var monkeys = monkeysInput;

        long mod = monkeys.Select(m => m.test).Aggregate((a, b) => a * b);
        void Turn(int iMonkey)
        {
            for (int iLevel = 0; iLevel < monkeys[iMonkey].levels.Count; ++iLevel)
            {
                long level = monkeys[iMonkey].levels[iLevel];
                monkeys[iMonkey].inspections += 1;
                level = monkeys[iMonkey].operation(level);
                level = level % mod;
                int iNextMonkey;
                if (level % monkeys[iMonkey].test == 0)
                {
                    iNextMonkey = monkeys[iMonkey].m1;
                }
                else
                {
                    iNextMonkey = monkeys[iMonkey].m2;
                }
                monkeys[iNextMonkey].levels.Add(level);
            }
            monkeys[iMonkey].levels.Clear();
        }
        void Round()
        {
            for (int iMonkey = 0; iMonkey < monkeys.Length; iMonkey++)
            {
                Turn(iMonkey);
            }
        }
        for (int iRound = 0; iRound < 10000; iRound++)
        {
            Round();
        }
        long business = monkeys.Select(m => m.inspections).OrderDescending().Take(2).Aggregate((a, b) => a * b);

        Assert.Equal(121450, business);
    }
}
