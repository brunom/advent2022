<Query Kind="Program" />

IEnumerable<int> Split(IEnumerable<string> input)
{
	int sum = 0;
	foreach (var line in input)
	{
		if (string.IsNullOrWhiteSpace(line))
		{
			yield return sum;
			sum = 0;
		}
		else
		{
			sum += int.Parse(line);			
		}
	}
	yield return sum;
}
void Main()
{
	var lines = File.ReadLines(@"C:\tools\advent2022\1\input.txt");
	var sums = Split(lines).ToList();
	sums.Max().Dump();
	sums.OrderByDescending(x => x).Take(3).Sum().Dump();
	
}