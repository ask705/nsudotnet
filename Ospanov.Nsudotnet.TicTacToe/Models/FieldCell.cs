using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class FieldCell : Cell 
    {
        protected int n = 3;
        private Cell[,] cells;
        private LargeField ladgeField;


        //new LargeField field;

        public Cell[,] Cells { get => cells; set => cells = value; }
        public new LargeField Field { get => ladgeField; set => ladgeField = value; }

        public FieldCell() : base()
        {
            Cells = new Cell[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Cells[i, j] = new Cell(j, i, this);
                }
            }
        }
        public FieldCell(int x, int y, LargeField field) : base(x,y)
        {
            Field = field;
            Cells = new Cell[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Cells[i, j] = new Cell(j, i, this);
                }
            }
        }

        public Cell getCell(int x, int y)
        {
            return cells[y, x];
        }

        public void CellChangeState(int x, int y, StateCell state)
        {
            if (Field != null)
            {
                Field.SetFocusFieldCell(x, y);
            }
            if (State != StateCell.Empty)
            {
                return;
            }
            if (CheckOnWin(x, y, state))
            {
                Win(state);
            }
        }

        public bool IsFulled()
        {
            foreach (Cell cell in cells)
            {
                if (cell.IsEmpty())
                {
                    return false;
                }
            }
            return true;
        }

        public FieldCell(int x, int y, int n, LargeField field) : base(x, y, field)
        {
            this.n = n;
            Cells = new Cell[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Cells[i, j] = new Cell(j, i, this);
                }
            }
        }
        public bool CheckOnWin(int x, int y, StateCell sign)
        {
            int i;
            bool win = true;
            for (i = 0; i < n; i++)
            {
                if (Cells[i, x].State != sign)
                {
                    win = false;
                    break;
                }
            }
            if (win == true)
            {
                return true;
            }
            win = true;
            for (i = 0; i < n; i++)
            {
                if (cells[y, i].State != sign)
                {
                    win = false;
                    break;
                }
            }
            if (win == true)
            {
                return true;
            }
            if (x == y)
            {
                win = true;
                for (i = 0; i < n; i++)
                {
                    if (Cells[i, i].State != sign)
                    {
                        win = false;
                        break;
                    }
                }
                if (win == true)
                {
                    return true;
                }
            }
            if (x == n -1 - y)
            {
                win = true;
                for (i = 0; i < n; i++)
                {
                    if (Cells[i, n - 1 - i].State != sign)
                    {
                        win = false;
                        break;
                    }
                }
                if (win == true)
                {
                    return true;
                }
                win = true;
            }
            return false;
        }
        public void Win(StateCell state)
        {
            ChangeState(state);
        }
        public new bool ChangeState(StateCell state)
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
    }

}
