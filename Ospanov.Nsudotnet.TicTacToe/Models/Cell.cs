using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicTacToe.Models
{

    public delegate void StateCellChangedEventHandler(StateCell stateCell); 
    public class Cell
    {
        protected int x;
        protected int y;
        protected StateCell state;
        private FieldCell field;

        public event StateCellChangedEventHandler StateCellChangedEvent = StubStateCellChangedEnent;

        public Cell() {
            X = 0;
            Y = 0;
            State = StateCell.Empty;
        }
        public Cell(int x, int y, FieldCell field)
        {
            X = x;
            Y = y;
            State = StateCell.Empty;
            Field = field;
        }
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            State = StateCell.Empty;
        }

        public bool ChangeState(StateCell state)
        {
            if (state == State)
            {
                return false;
            }
            else
            {
                State = state;
                Field.CellChangeState(X, Y, State);
                return true;
            }
        }

        public bool IsCross()
        {
            return state == StateCell.X;
        }
        public bool IsZero()
        {
            return state == StateCell.O;
        }
        public bool IsEmpty()
        {
            return state == StateCell.Empty;
        }

        public int Y { get => y; set => y = value; }
        public StateCell State { get => state;
            set
            {
                if (value == state) return;
                state = value;
                StateCellChangedEvent(state);
            }
        }
        static void StubStateCellChangedEnent(StateCell state) { }
        public int X { get => x; set => x = value; }
        public FieldCell Field { get => field; set => field = value; }
    }
}
