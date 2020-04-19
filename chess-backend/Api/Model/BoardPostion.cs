namespace Api.Model
{
    public class BoardPostion
    {
        public BoardPostion(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var bp = (BoardPostion)obj;
            return (Row == bp.Row && Column == bp.Column);
        }

        public int Row { get; set; }
        public int Column { get; set; }
    }
}
