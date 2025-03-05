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
        public bool HasWinner { get { return HasCompletedRow() || HasCompletedColumn() || HasCompletedDiagonal(); } }
        public bool HasDraw { get { return IsFull && !HasWinner; } }
        public bool IsFull { get { return UnclaimedLocationCount() == 0; } }
        public int LocationsClaimed { get { return ClaimedLocationCount();  } }
        public GameBoard()
        {
            locations = new Symbol[9];
        }
        public Symbol SymbolAt(int location) => locations[location];
        public Symbol GetWinningSymbol()
        {
            if (HasCompletedRow())
                return RowWinner();
            if (HasCompletedColumn())
                return ColumnWinner();
            if (HasCompletedDiagonal())
                return DiagonalWinner();
            throw new Exception("No winner.");
        }
        public void ClaimLocation(Player player, int location)
        {
            if (location < (int)Location.TopLeft)
                throw new Exception("Location number too low.");
            if (location > (int)Location.BottomRight)
                throw new Exception("Location number too high.");
            if (!IsEmpty(location))
                throw new Exception("Location number already claimed.");
            locations[location] = player.PlayerSymbol;
        }
        private bool HasCompletedRow() => RowWinner() != Symbol.Empty;
        private bool HasCompletedColumn() => ColumnWinner() != Symbol.Empty;
        private bool HasCompletedDiagonal() => DiagonalWinner() != Symbol.Empty;
        private Symbol DiagonalWinner()
        {
            if (TopLeftDiagonalWinner() != Symbol.Empty)
                return TopLeftDiagonalWinner();
            if (TopRightDiagonalWinner() != Symbol.Empty)
                return TopRightDiagonalWinner();
            return Symbol.Empty;
        }
        private Symbol RowWinner()
        {
            for (int row = 0; row < 3; row++)
                if (!IsEmpty(row * 3)
                    && locations[row * 3] == locations[row * 3 + 1]
                    && locations[row * 3 + 1] == locations[row * 3 + 2])
                    return SymbolAt(row * 3);
            return Symbol.Empty;
        }
        private Symbol ColumnWinner()
        {
            for (int col = 0; col < 3; col++)
                if (!IsEmpty(col)
                    && locations[col] == locations[col + 3]
                    && locations[col + 3] == locations[col + 6])
                    return SymbolAt(col);
            return Symbol.Empty;
        }
        private Symbol TopLeftDiagonalWinner()
        {
            if (!IsEmpty((int)Location.Center) 
                && locations[(int)Location.TopLeft] == locations[(int)Location.Center] 
                && locations[(int)Location.Center] == locations[(int)Location.BottomRight])
                return SymbolAt((int)Location.Center);
            return Symbol.Empty;
        }
        private Symbol TopRightDiagonalWinner()
        {
            if (!IsEmpty((int)Location.Center) 
                && locations[(int)Location.TopRight] == locations[(int)Location.Center] 
                && locations[(int)Location.Center] == locations[(int)Location.BottomLeft])
                return SymbolAt((int)Location.Center);
            return Symbol.Empty;
        }
        private bool IsEmpty(int location) => locations[location] == Symbol.Empty;
        private int UnclaimedLocationCount() => locations.Where(location => location == Symbol.Empty).Count();
        private int ClaimedLocationCount() => locations.Where(location => location != Symbol.Empty).Count();
    }
}
