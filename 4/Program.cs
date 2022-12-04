var lines = File.ReadLines("input.txt").ToList();
var p =
    from line in lines
    let elves = line.Split(',').Select(x => x.Split('-').Select(y => int.Parse(y)).ToArray()).ToArray()
    // where elves[0][0] <= elves[1][0] && elves[1][1] <= elves[0][1]
    // ||  elves[1][0] <= elves[0][0] && elves[0][1] <= elves[1][1]
    where elves[0][1] >= elves[1][0] && elves[1][1] >= elves[0][0]
    select elves;
Console.WriteLine(p.Count());
