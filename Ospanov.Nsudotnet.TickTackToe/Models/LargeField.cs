using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTackToe.Models
{
    public class LargeField : FieldCell
    {
        new protected int n = 3;
        private FieldCell focusFiledCell;
        private FieldCell[,] FieldsCells;
        public LargeField() {
            Cells = new FieldCell[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Cells[i, j] = new FieldCell(j, i, this);
                }
            }
        }

        public new FieldCell[,] Cells { get => FieldsCells; set => FieldsCells = value; }
        public FieldCell FocusFiledCell { get => focusFiledCell; set => focusFiledCell = value; }

        public new FieldCell getCell(int x, int y)
        {
            return Cells[y, x];
        }

        public void SetFocusFieldCell(int x, int y)
        {
            FocusFiledCell = Cells[x, y];
        }

        public new bool CheckOnWin(int x, int y, StateCell sign)
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
                if (FieldsCells[y, i].State != sign)
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
            if (x == n - 1 - y)
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
        public new void CellChangeState(int x, int y, StateCell state)
        {
            //if (field != null)
            //{
            //    field.SetFocusFieldCell(x, y);
            //}
            if (State != StateCell.Empty)
            {
                return;
            }
            if (CheckOnWin(x, y, state))
            {
                State = state;
            }
        }
    }
}
