string[] lines = File.ReadAllLines("input.txt");
int nrows = lines.Count();
int ncols = lines.First().Count();
var see = new bool[nrows, ncols];
int nsee = 0;

int tallest;

for (int row = 0; row < nrows; ++row)
{
    tallest = -1;
    for (int col = 0; col < ncols; ++col)
        Update(row, col);
    tallest = -1;
    for (int col = ncols; col > 0; --col)
        Update(row, col - 1);
}
for (int col = 0; col < ncols; ++col)
{
    tallest = -1;
    for (int row = 0; row < nrows; ++row)
        Update(row, col);
    tallest = -1;
    for (int row = nrows; row > 0; --row)
        Update(row - 1, col);

}

void Update(int row, int col)
{
    int h = lines[row][col] - '0';
    if (tallest < h)
    {
        tallest = h;
        if (!see[row, col])
        {
            see[row, col] = true;
            ++nsee;
        }
    }
}

Console.WriteLine(nsee);

int Score(int row, int col, int drow, int dcol)
{
    int house = lines[row][col] - '0';
    int result = 0;
    while (true)
    {
        row += drow;
        col += dcol;
        if (row < 0)
            break;
        if (col < 0)
            break;
        if (row >= nrows)
            break;
        if (col >= ncols)
            break;
        ++result;
        if (lines[row][col] - '0' >= house)
            break;
    }
    return result;
}

int bestrow = 0;
int bestcol = 0;
int bestscore = 0;
for (int row = 0; row < nrows; ++row)
{
    for (int col = 0; col < ncols; ++col)
    {
        int score0 = Score(row, col, 0, +1);
        int score1 = Score(row, col, 0, -1);
        int score2 = Score(row, col, +1, 0);
        int score3 = Score(row, col, -1, 0);
        int score = score0 * score1 * score2 * score3;
        if (bestscore < score)
        {
            bestscore = score;
            bestrow = row;
            bestcol = col;
        }
    }
}
Console.WriteLine(bestscore); // 596736 too high
