using System;
using Caliburn.Micro;
using TicTacToe.Models;

namespace TicTacToe.ViewModels
{
    public class LargeFieldViewModel : PropertyChangedBase
    {
        private Models.LargeField field;
        public SmallFieldViewModel[] Fields { get; set; }
        public LargeField Field { get => field; }

        public LargeFieldViewModel(Models.LargeField field)
        {
            this.field = field;
            Fields = new SmallFieldViewModel[9];
            for (int i = 0; i < 9; i++)
            {
            
                Fields[i] = new SmallFieldViewModel(Field.getCell(i % 3, i / 3));
                Field.StateCellChangedEvent += ChangedState;
                Field.FocusFieldChangedEvent += FocusFieldChangedHandler;
            }
        }
        private void FocusFieldChangedHandler(int x, int y)
        {
            if (x < 0)
            {
                foreach (SmallFieldViewModel smallField in Fields)
                {
                    smallField.IsEnabled = true;
                }
                return;
            }
            else
            {
                foreach (SmallFieldViewModel smallField in Fields)
                {
                    smallField.IsEnabled = false;
                }
                Fields[y * 3 + x].IsEnabled = true;
            }
        }

        public void ChangedState(StateCell state)
        {
        }
    }
}
