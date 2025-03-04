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
            for (int row = 0; row < 3; row++)
                if (!IsEmpty(row * 3)
                    && locations[row * 3] == locations[row * 3 + 1]
                    && locations[row * 3 + 1] == locations[row * 3 + 2])
                    return true;
            return false;
        }
        public bool HasCompletedColumn()
        {
            for (int col = 0; col < 3; col++)
                if (!IsEmpty(col)
                    && locations[col] == locations[col + 3]
                    && locations[col + 3] == locations[col + 6])
                    return true;
            return false;
        }
        public bool HasCompletedDiagonal()
        {
            return HasCompletedTopLeftDiagonal() || HasCompletedTopRightDiagonal();
        }
        public bool HasCompletedTopLeftDiagonal()
        {
            return !IsEmpty(0) && locations[0] == locations[4] && locations[4] == locations[8];
        }
        public bool HasCompletedTopRightDiagonal()
        {
            return !IsEmpty(2) && locations[2] == locations[4] && locations[4] == locations[6];
        }
        private bool IsEmpty(int location)
        {
            return locations[location] == Symbol.Empty;
        }
        public void ClaimLocation(Player player, int location)
        {
            if (IsEmpty(location))
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
