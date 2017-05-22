using Caliburn.Micro;
using TickTackToe.Models;

namespace TickTackToe.ViewModels
{
    public class CellViewModel : PropertyChangedBase
    {
        private Cell cell;
        private string pathPicture;
        private string pathCross="Resources/Cross.png";
        private string pathZero="Resources/Zero.png";

        public StateCell State
         {
             get { return cell.State; }
             set
             {
                if (value == cell.State) return;
                cell.ChangeState(value);
                NotifyOfPropertyChange(() => State);
             }
         }
        public CellViewModel(Cell cell1)
        {
            cell = cell1;
        }

        public string PathPicture {
            get { return pathPicture; }
            set
            {
                if (value == pathPicture) return;
                pathPicture = value;
                NotifyOfPropertyChange(() => pathPicture);
            }
        }

        public void PlayerStroke()
         {
            if (State != StateCell.Empty)
            {
                return;
            }
            State = MainViewModel.CurrentSign;
            if (MainViewModel.CurrentSign == StateCell.X)
            {
                PathPicture = pathCross;
            }
            else
            {
                PathPicture = pathZero;
            }
            MainViewModel.NextCurrentSign();
         }
    }
}
