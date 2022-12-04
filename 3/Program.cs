int Prio(char ch)
{
    if ('a' <= ch && ch <= 'z')
        return 1 + ch - 'a';
    if ('A' <= ch && ch <= 'Z')
        return 27 + ch - 'A';
    throw new ArgumentOutOfRangeException();
}

var sacks = File.ReadLines("input.txt").ToList();

var prios1 =
    from sack in sacks
    let comp0 = sack.Take(sack.Count() / 2)
    let comp1 = sack.Skip(sack.Count() / 2)
    select Prio(comp0.Intersect(comp1).Single());
Console.WriteLine(prios1.Sum());

var prios2 =
    from ig in Enumerable.Range(0, sacks.Count() / 3)
    let g = sacks.Skip(3*ig).Take(3)
    let common = g.Aggregate<IEnumerable<char>>(Enumerable.Intersect)
    select Prio(common.Single());
Console.WriteLine(prios2.Sum());
