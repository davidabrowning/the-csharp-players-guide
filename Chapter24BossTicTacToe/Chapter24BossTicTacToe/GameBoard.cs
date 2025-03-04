using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter24BossTicTacToe
{
    internal class GameBoard
    {
        private Symbol[] locations;
        public int TotalClaimedLocations { get { return CalculateTotalClaimedLocations();  } }
        public GameBoard()
        {
            locations = new Symbol[9];
        }
        public Symbol GetWinningSymbol()
        {
            if (!HasWinner())
                return Symbol.Empty;
            if (HasCompletedRow())
                return RowWinner();
            if (HasCompletedColumn())
                return ColumnWinner();
            if (HasCompletedDiagonal())
                return DiagonalWinner();
            return Symbol.Empty;
        }
        public bool HasWinner()
        {
            return HasCompletedRow() || HasCompletedColumn() || HasCompletedDiagonal();
        }
        public bool HasDraw()
        {
            return IsFull() && !HasWinner();
        }
        public bool HasCompletedRow()
        {
            return RowWinner() != Symbol.Empty;
        }
        public bool HasCompletedColumn()
        {
            return ColumnWinner() != Symbol.Empty;
        }
        public bool HasCompletedDiagonal()
        {
            return DiagonalWinner() != Symbol.Empty;
        }
        public Symbol DiagonalWinner()
        {
            if (TopLeftDiagonalWinner() != Symbol.Empty)
                return TopLeftDiagonalWinner();
            if (TopRightDiagonalWinner() != Symbol.Empty)
                return TopRightDiagonalWinner();
            return Symbol.Empty;
        }
        public Symbol RowWinner()
        {
            for (int row = 0; row < 3; row++)
                if (!IsEmpty(row * 3)
                    && locations[row * 3] == locations[row * 3 + 1]
                    && locations[row * 3 + 1] == locations[row * 3 + 2])
                    return SymbolAt(row * 3);
            return Symbol.Empty;
        }
        public Symbol ColumnWinner()
        {
            for (int col = 0; col < 3; col++)
                if (!IsEmpty(col)
                    && locations[col] == locations[col + 3]
                    && locations[col + 3] == locations[col + 6])
                    return SymbolAt(col);
            return Symbol.Empty;
        }
        public Symbol TopLeftDiagonalWinner()
        {
            if (!IsEmpty(0) && locations[0] == locations[4] && locations[4] == locations[8])
                return SymbolAt(0);
            return Symbol.Empty;
        }
        public Symbol TopRightDiagonalWinner()
        {
            if (!IsEmpty(2) && locations[2] == locations[4] && locations[4] == locations[6])
                return SymbolAt(2);
            return Symbol.Empty;
        }
        private bool IsEmpty(int location)
        {
            return locations[location] == Symbol.Empty;
        }
        public void ClaimLocation(Player player, int location)
        {
            if (location < 0)
                throw new Exception("Location number too low");
            if (location >= locations.Length)
                throw new Exception("Location number too high.");
            if (!IsEmpty(location))
                throw new Exception("Location number already claimed.");
            locations[location] = player.PlayerSymbol;
        }
        public bool IsFull()
        {
            foreach (Symbol location in locations)
                if (location == Symbol.Empty)
                    return false;
            return true;
        }
        private int CalculateTotalClaimedLocations()
        {
            int totalClaimedLocations = 0;
            foreach (Symbol location in locations)
                if (location != Symbol.Empty)
                    totalClaimedLocations++;
            return totalClaimedLocations;
        }
        public Symbol SymbolAt(int location)
        {
            return locations[location];
        }
    }
}
