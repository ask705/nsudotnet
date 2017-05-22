using Caliburn.Micro;
using TickTackToe.Models;
using TickTackToe.Views;

namespace TickTackToe.ViewModels
{
    public class MainViewModel : Screen
    {
        private static StateCell currentSign = StateCell.X;
        private LargeFieldViewModel _gameField;
        private Models.LargeField ladgeField;

        public LargeFieldViewModel GameField
        {
            get { return _gameField; }
            set
            {
                if (Equals(value, _gameField)) return;
                _gameField = value;
                NotifyOfPropertyChange(() => GameField);
            }
        }

        public static StateCell CurrentSign { get => currentSign; set => currentSign = value; }

        public MainViewModel()
        {
        }

        public void NewGame()
        {
            ladgeField = new Models.LargeField();
            GameField = new LargeFieldViewModel(ladgeField);
            ladgeField.StateCellChangedEvent += Win;
        }

        private void Win(StateCell stateCell)
        {
            WinView winWindow = new Views.WinView(this, stateCell);
            winWindow.Show();
        }

        public static void NextCurrentSign()
        {
            if (CurrentSign == StateCell.X)
            {
                CurrentSign = StateCell.O;
            }
            else
            {
                CurrentSign = StateCell.X;
            }
        }
    }
}
