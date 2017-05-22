using Caliburn.Micro;
using System.Windows;
using TickTackToe.Models;

namespace TickTackToe.ViewModels
{
    public class SmallFieldViewModel : PropertyChangedBase
    {
        public CellViewModel[] Cells { get; set; }
        private Models.FieldCell fieldCell;

        public StateCell State
        {
            get { return fieldCell.State; }
            set
            {
                if (value == fieldCell.State) return;
                fieldCell.ChangeState(value);
                NotifyOfPropertyChange(() => State);
            }
        }

        public Visibility CircleState { get => circleState; set
            {
                if (value == circleState) return;
                circleState = value;
                NotifyOfPropertyChange(() => circleState);
            }
        }

        public Visibility CrossState { get => crossState; set
            {
                if (value == crossState) return;
                crossState = value;
                NotifyOfPropertyChange(() => crossState);
            }
        }

        protected System.Windows.Visibility circleState=Visibility.Hidden;
        protected System.Windows.Visibility crossState=Visibility.Hidden;

        public SmallFieldViewModel(Models.FieldCell field)
        {
            fieldCell = field;
            Cells = new CellViewModel[9];
            for (int i = 0; i < 9; i++)
            {
                Cells[i] = new CellViewModel(fieldCell.getCell(i % 3, i / 3));
            }
            field.StateCellChangedEvent += ChangedState;
        }

        public void ChangedState(StateCell state)
        {
            if (state == StateCell.X)
            {
                CircleState = Visibility.Hidden;
                CrossState = Visibility.Visible;
            }
            if (state == StateCell.O)
            {
                CircleState = Visibility.Visible;
                CrossState = Visibility.Hidden;
            }
            if (state == StateCell.Empty)
            {
                CircleState = Visibility.Hidden;
                CrossState = Visibility.Hidden;
            }
            State = state;
        }
    }
}
