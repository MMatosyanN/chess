
using Program.cs;
using System;
using System.Reflection;
using System.Xml.XPath;

namespace Class2.cs;

internal class Program
{
    static Coord kingCoord = new Coord();
    static Coord rookCoord = new Coord();
    static Coord bishCoord = new Coord();
    static Coord knightCoord = new Coord();
    static Coord queenCoord = new Coord();

    static void Main(string[] args)
    {
        string[] figurner = Enum.GetNames(typeof(Figur));
        char[] figurs = new char[figurner.Length];
        for (int i = 0; i < figurner.Length; i++)
            figurs[i] = figurner[i][0];

        Writechess();
        Console.WriteLine("Insert x (1-8)");
        Console.WriteLine("Insert y (A-H)");
        Console.WriteLine("Insert Figure(K Q R N B)");
        int poss = 9;
        while (true)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(30, poss);
            Console.WriteLine("         ");
            Console.SetCursorPosition(30, poss + 1);
            Console.WriteLine("         ");
            Console.SetCursorPosition(30, poss + 2);
            Console.WriteLine("         ");
            Console.SetCursorPosition(30, poss);
            string a1 = Console.ReadLine();
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("            ");
            Console.SetCursorPosition(30, poss + 1);
            string b1 = Console.ReadLine();
            Console.SetCursorPosition(30, poss + 2);
            string c1 = Console.ReadLine();

            if (int.TryParse(a1, out int resultX) && char.TryParse(b1, out char resultY) && char.TryParse(c1, out char resultF))
            {
                if (resultX >= 1 && resultX <= 8 && resultY >= 'A' && resultY <= 'H' && figurs.Contains(resultF))
                {
                    if (resultF == 'K' && kingCoord.F == 'K')
                    {
                        int tarbX = resultX - kingCoord.X;
                        int tarbY = resultY - kingCoord.Y;
                        if (((tarbX == 1 || tarbX == -1) && tarbY == 0) || (tarbX == 0 && (tarbY == 1 || tarbY == -1)) || ((tarbX == 1 || tarbX == -1) && (tarbY == 1 || tarbY == -1)))
                        {
                            Letter oldLetter = (Letter)Enum.Parse(typeof(Letter), kingCoord.Y.ToString());
                            char oldC = (char)((int)oldLetter - 64);
                            Console.SetCursorPosition(oldC, (9 - kingCoord.X));
                            if (((kingCoord.Y == 'A' || kingCoord.Y == 'C' || kingCoord.Y == 'E' || kingCoord.Y == 'G') && (kingCoord.X % 2 == 0))
                             || ((kingCoord.Y == 'B' || kingCoord.Y == 'D' || kingCoord.Y == 'F' || kingCoord.Y == 'H') && (kingCoord.X % 2 == 1)))
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine(" ");
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine(" ");
                            }
                            Pos(resultX, resultY, resultF);
                        }
                    }

                    if (resultF == 'B' && bishCoord.F == 'B')
                    {
                        int tarbX = Math.Abs(resultX - bishCoord.X);
                        int tarbY = Math.Abs(resultY - bishCoord.Y);
                        if (tarbX == tarbY)
                        {
                            Letter oldLetter = (Letter)Enum.Parse(typeof(Letter), bishCoord.Y.ToString());
                            char oldC = (char)((int)oldLetter - 64);
                            Console.SetCursorPosition(oldC, (9 - bishCoord.X));
                            if (((bishCoord.Y == 'A' || bishCoord.Y == 'C' || bishCoord.Y == 'E' || bishCoord.Y == 'G') && (bishCoord.X % 2 == 0))
                             || ((bishCoord.Y == 'B' || bishCoord.Y == 'D' || bishCoord.Y == 'F' || bishCoord.Y == 'H') && (bishCoord.X % 2 == 1)))
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine(" ");
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine(" ");
                            }
                            Pos(resultX, resultY, resultF);
                        }
                    }

                    if (resultF == 'R' && rookCoord.F == 'R')
                    {
                        int tarbX = Math.Abs(resultX - rookCoord.X);
                        int tarbY = Math.Abs(resultY - rookCoord.Y);
                        if ((tarbX > 0 && tarbY == 0) || (tarbX == 0 && tarbY > 0))
                        {
                            Letter oldLetter = (Letter)Enum.Parse(typeof(Letter), rookCoord.Y.ToString());
                            char oldC = (char)((int)oldLetter - 64);
                            Console.SetCursorPosition(oldC, (9 - rookCoord.X));
                            if (((rookCoord.Y == 'A' || rookCoord.Y == 'C' || rookCoord.Y == 'E' || rookCoord.Y == 'G') && (rookCoord.X % 2 == 0))
                             || ((rookCoord.Y == 'B' || rookCoord.Y == 'D' || rookCoord.Y == 'F' || rookCoord.Y == 'H') && (rookCoord.X % 2 == 1)))
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine(" ");
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine(" ");
                            }
                            Pos(resultX, resultY, resultF);
                        }
                    }

                    if (resultF == 'N' && rookCoord.F == 'N')
                    {
                        int tarbX = Math.Abs(resultX - knightCoord.X);
                        int tarbY = Math.Abs(resultY - knightCoord.Y);
                        if ((tarbX == 1 && tarbY == 2) || (tarbX == 2 && tarbY == 1))
                        {
                            Letter oldLetter = (Letter)Enum.Parse(typeof(Letter), knightCoord.Y.ToString());
                            char oldC = (char)((int)oldLetter - 64);
                            Console.SetCursorPosition(oldC, (9 - knightCoord.X));
                            if (((knightCoord.Y == 'A' || knightCoord.Y == 'C' || knightCoord.Y == 'E' || knightCoord.Y == 'G') && (knightCoord.X % 2 == 0))
                             || ((knightCoord.Y == 'B' || knightCoord.Y == 'D' || knightCoord.Y == 'F' || knightCoord.Y == 'H') && (knightCoord.X % 2 == 1)))
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine(" ");
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine(" ");
                            }
                            Pos(resultX, resultY, resultF);
                        }
                    }

                    if (resultF == 'Q' && rookCoord.F == 'Q')
                    {
                        int tarbX = Math.Abs(resultX - queenCoord.X);
                        int tarbY = Math.Abs(resultY - queenCoord.Y);
                        if ((tarbX == tarbY) || (tarbX > 0 && tarbY == 0) || (tarbX == 0 && tarbY > 0))
                        {
                            Letter oldLetter = (Letter)Enum.Parse(typeof(Letter), queenCoord.Y.ToString());
                            char oldC = (char)((int)oldLetter - 64);
                            Console.SetCursorPosition(oldC, (9 - queenCoord.X));
                            if (((queenCoord.Y == 'A' || queenCoord.Y == 'C' || queenCoord.Y == 'E' || queenCoord.Y == 'G') && (queenCoord.X % 2 == 0))
                             || ((queenCoord.Y == 'B' || queenCoord.Y == 'D' || queenCoord.Y == 'F' || queenCoord.Y == 'H') && (queenCoord.X % 2 == 1)))
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine(" ");
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine(" ");
                            }
                            Pos(resultX, resultY, resultF);
                        }
                        else
                            Pos(resultX, resultY, resultF);
                    }
                    else
                    {
                        Console.WriteLine("Not found");
                    }
                }
            }
        }

        static void Writechess()
        {
            Console.WriteLine(" A B C D E F G H");
            for (int i = 8; i > 0; i--)
            {
                for (int j = 1; j < 10; j++)
                {
                    if (j == 9)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(i);
                    }
                    else
                    {
                        if ((i + j) % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("  ");
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("  ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        static void Pos(int x, char y, char f)
        {
            int x1 = x;
            x = 9 - x;
            Letter letter = (Letter)Enum.Parse(typeof(Letter), y.ToString());
            char c = (char)((int)letter - 64);
            Console.SetCursorPosition(c, x);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (((y == 'A' || y == 'C' || y == 'E' || y == 'G') && (x1 % 2 == 0)) || ((y == 'B' || y == 'D' || y == 'F' || y == 'H') && (x1 % 2 == 1)))
            {
                Console.BackgroundColor = ConsoleColor.White;
                WriteFigure(x1, y, f);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                WriteFigure(x1, y, f);
            }
        }


        static void WriteFigure(int x, char y, char f)
        {
            Console.WriteLine(f);

            if (f == 'K')
            {
                kingCoord.X = x;
                kingCoord.Y = y;
                kingCoord.F = f;
            }
            if (f == 'R')
            {
                rookCoord.X = x;
                rookCoord.Y = y;
                rookCoord.F = f;
            }
            if (f == 'B')
            {
                bishCoord.X = x;
                bishCoord.Y = y;
                bishCoord.F = f;
            }
            if (f == 'N')
            {
                knightCoord.X = x;
                knightCoord.Y = y;
                knightCoord.F = f;
            }
            if (f == 'Q')
            {
                queenCoord.X = x;
                queenCoord.Y = y;
                queenCoord.F = f;
            }
        }
    }    
}
