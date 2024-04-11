using Program.cs;

namespace Program.cs;

    enum Figur
    {
        K,//King
        Q,//Queen
        B,//Bishop
        N,//Knight
        R,//Rook
    }
    enum Letter
    {
        A = 65,
        B = 67,
        C = 69,
        D = 71,
        E = 73,
        F = 75,
        G = 77,
        H = 79
}

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


