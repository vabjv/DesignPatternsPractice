using System;
using System.Collections;
using System.Collections.Generic;

public class ChessPieceColor
{
    public string Color { get; }

    public ChessPieceColor(string color) => Color = color;
}

public static class ChessPieceColorFactory
{
    private static Dictionary<string, ChessPieceColor> _chessPieceColors = new();

    public static ChessPieceColor Create(string color)
    {
        if (!_chessPieceColors.ContainsKey(color))
        {
            _chessPieceColors[color] = new ChessPieceColor(color);
        }
        return _chessPieceColors[color];
    }
}

public class ChessPiece
{
    public ChessPieceColor ChessPieceColor { get; }

    private int _x;

    private int _y;

    public ChessPiece(int x, int y, string color)
    {
        _x = x;
        _y = y;
        ChessPieceColor = ChessPieceColorFactory.Create(color);
    }

    public void Show()
    {
        Console.WriteLine($"x:{_x}, y:{_y}, color:{ChessPieceColor.Color}");
    }
}

public class Program
{
    public static void Main()
    {
        ChessPiece chessPiece1 = new ChessPiece(1, 1, "白色");
        ChessPiece chessPiece2 = new ChessPiece(1, 2, "黑色");
        ChessPiece chessPiece3 = new ChessPiece(1, 3, "白色");
        chessPiece1.Show();
        chessPiece2.Show();
        chessPiece3.Show();
        Console.WriteLine(Object.ReferenceEquals(chessPiece1.ChessPieceColor, chessPiece3.ChessPieceColor));
    }
}