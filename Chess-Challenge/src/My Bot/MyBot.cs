using ChessChallenge.API;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;

public class MyBot : IChessBot
{
    public Move Think(Board board, Timer timer)
    {
        // Debug output for IsWhiteToMove() and PlyCount
        Console.WriteLine("IsWhiteToMove: " + board.IsWhiteToMove);
        Console.WriteLine("PlyCount: " + board.PlyCount);

        Move[] moves = board.GetLegalMoves();

        List<string> l = new List<string> { "e2e4", "f1c4", "d1h5", "h5f7"};
        Move nextMove = new Move(l[board.PlyCount / 2], board); // fix index out of range error for move 5+
        if (board.IsWhiteToMove && Array.Exists(moves, move => move.Equals(nextMove)))
        {
            return nextMove;
        }
        else
        {
            System.Random rng = new();
            return moves[rng.Next(moves.Length)];
        }
    }
}

