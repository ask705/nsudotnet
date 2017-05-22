using Caliburn.Micro;
using TickTackToe.Models;

namespace TickTackToe.ViewModels
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
            }
        }
        public void ChangedState(StateCell state)
        {
        }
    }
}
