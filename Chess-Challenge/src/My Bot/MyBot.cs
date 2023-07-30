using ChessChallenge.API;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

public class MyBot : IChessBot
{
    public Move Think(Board board, Timer timer)
    {
        // Debug output for IsWhiteToMove() and PlyCount
        Console.WriteLine("IsWhiteToMove: " + board.IsWhiteToMove);
        Console.WriteLine("PlyCount: " + board.PlyCount);

        Move[] moves = board.GetLegalMoves();

        //moveSequence = ["e2e4", "f1c4", "d1h5", "h5f7"]

        if (board.IsWhiteToMove)
        {
            // Create a Scholar's mate bot
            if (board.PlyCount == 0)
            {
                return new Move("e2e4", board);
            }
            else if (board.PlyCount == 2)
            {
                return new Move("f1c4", board);
            }
            else if (board.PlyCount == 4)
            {
                return new Move("d1h5", board);
            }
            else if (board.PlyCount == 6)
            {
                return new Move("h5f7", board);
            }
            else
            {
                System.Random rng = new();
                return moves[rng.Next(moves.Length)];
            }
        }
        else
        {
            System.Random rng = new();
            return moves[rng.Next(moves.Length)];
        }
    }
}

