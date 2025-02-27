using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08ChallengeTheDefenseOfConsolas
{
    public record Location
    {
        public readonly int Row;
        public readonly int Column;
        public Location() : this(0, 0)
        {

        }
        public Location(int row, int column)
        {
            Row = row;
            Column = column;
        }
        private Location Move(int rowChange, int columnChange)
        {
            return new Location(Row + rowChange, Column + columnChange);
        }
        public Location MoveUp() => Move(1, 0);
        public Location MoveDown() => Move(-1, 0);
        public Location MoveLeft() => Move(0, -1);
        public Location MoveRight() => Move(0, 1);
    }
}
