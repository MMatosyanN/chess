namespace chess;

public struct Coord
{
    public int X;
    public char Y;
    public char F;
    public Coord(int XCoord, char YCoord, char Figur)
    {
        X = XCoord;
        Y = YCoord;
        F = Figur;
    }
}
