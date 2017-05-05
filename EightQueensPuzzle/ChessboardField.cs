using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using BaseReuseServices;
using EightQueensPuzzle.Services;
using Microsoft.Practices.Unity;
using WpfUtilities;

namespace EightQueensPuzzle
{
    public class ChessboardField : INotifyPropertyChanged
    {
        private readonly ITipService _tipService;
        private readonly object _thisLock;
        private static readonly SolidColorBrush DefaultFieldColor = new SolidColorBrush(Color.FromRgb(100, 181, 246));
        private Brush _currentFieldColor;

        public ChessboardField(int row, int column)
        {
            Row = row;
            Column = column;
            _tipService = UnityService.Instance.Get().Resolve<ITipService>();
            _thisLock = new object();
            ChangeRectangleColorCommand = new RelayCommand(ChangeColor);
            SetDefaultRectangleColorCommand = new RelayCommand(ChangeColor);
            ClickRectangleCommand = new RelayCommand(SetPawn);
            CurrentFieldColor = DefaultFieldColor;
        }

        public RelayCommand ChangeRectangleColorCommand { get; set; }

        public RelayCommand SetDefaultRectangleColorCommand { get; set; }

        public RelayCommand ClickRectangleCommand { get; set; }

        public Brush CurrentFieldColor
        {
            get { return _currentFieldColor; }
            private set
            {
                _currentFieldColor = value;
                OnPropertyChanged(nameof(CurrentFieldColor));
            }
        }

        public int Row { get; }

        public int Column { get; }

        public bool IsPawnSet { get; private set; }

        private void SetPawn(object obj)
        {
            lock (_thisLock)
            {
                var queen = new ImageBrush { ImageSource = ImageHelper.QueenPawn };
                CurrentFieldColor = queen;
                IsPawnSet = true;
            }
        }

        private void ChangeColor(object obj)
        {
            lock (_thisLock)
            {
                var brush = CurrentFieldColor as SolidColorBrush;
                if (brush != null)
                    CurrentFieldColor = _tipService.GetChangedFieldColor(this);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
