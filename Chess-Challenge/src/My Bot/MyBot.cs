using ChessChallenge.API;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;

public class MyBot : IChessBot
{
    public Move Think(Board board, Timer timer)
    {
        // Debug output
        //Console.WriteLine("IsWhiteToMove: " + board.IsWhiteToMove);

        Move[] moves = board.GetLegalMoves();

        List<string> l = new List<string> { "e2e4", "f1c4", "d1h5", "h5f7"}; // Scholar's mate sequence
        Move nextMove = new Move(l[Math.Min(board.PlyCount / 2, 3)], board); // Math.Min() to fix index out of range issue
        
        // Applies strategy only if Bot is White, Move is legal and for the first 4 moves
        if (board.IsWhiteToMove && Array.Exists(moves, move => move.Equals(nextMove)) && board.PlyCount < 7)
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

