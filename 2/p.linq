<Query Kind="Program" />

enum RPS
{
	R, P, S,
}
RPS Parse(string s)
{
	switch (s)
	{
		case "X":
		case "A":
			return RPS.R;
		case "Y":
		case "B":
			return RPS.P;
		case "Z":
		case "C":
			return RPS.S;
		default:
			throw null;
	}
}

int SelectedPoints(RPS rps)
{
	switch (rps)
	{
		case RPS.R: return 1;
		case RPS.P: return 2;
		case RPS.S: return 3;
		default: throw null;
	}
}
int OutcomePoints(RPS them, RPS us)
{
	switch (us - them)
	{
		case -1:
		case 2:
			return 0;
		case 0:
			return 3;
		case 1:
		case -2:
			return 6;
		default: throw null;
	}
}
(RPS them, RPS us) ParseLine(string s)
{
	var arr = s.Split();
	return (Parse(arr[0]), Parse(arr[1]));
}

int Parse2(string s)
{
	var arr = s.Split();
	var 
	switch(s.Split()[1])
	{
		case "X": return 0;
		case "Y": return 3;
		case "Z": return 6;
		default: throw null;
	}
}
void Main()
{
	var lines = File.ReadLines(@"C:\tools\advent2022\2\input.txt");
	var matches = lines.Select(x => ParseLine(x));
	var points = matches.Select(x => OutcomePoints(x.them, x.us) + SelectedPoints(x.us));
	var s = points.Sum();
	s.Dump();
	
	lines.Select(x => Parse2(x)).Sum().Dump(); // 8046 too low
}