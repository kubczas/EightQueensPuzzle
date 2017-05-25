using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using BaseReuseServices;
using EightQueensPuzzle.Helpers;
using EightQueensPuzzle.Services;
using EightQueensPuzzle.ViewModels;
using Microsoft.Practices.Unity;
using WpfUtilities;

namespace EightQueensPuzzle.Models
{
    public class ChessboardField : INotifyPropertyChanged
    {
        public static bool IsReadonly = true;
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
            SetDefaultRectangleColorCommand = new RelayCommand(SetDefaultFieldColor);
            ClickRectangleCommand = new RelayCommand(ManagePawn);
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

        private void ManagePawn(object obj)
        {
            if(IsReadonly)
                return;
            lock (_thisLock)
            {
                if (!IsPawnSet && !Equals(CurrentFieldColor, FieldColorHelper.BadFieldColor))
                {
                    var queen = new ImageBrush {ImageSource = ViewModelBase.GameSettings.SelectedPawn.Image};
                    CurrentFieldColor = queen;
                    IsPawnSet = true;
                }
                else
                {
                    IsPawnSet = false;
                    CurrentFieldColor = DefaultFieldColor;
                }
            }
        }

        private void ChangeColor(object obj)
        {
            if (IsReadonly)
                return;
            lock (_thisLock)
            {
                if (CurrentFieldColor is SolidColorBrush)
                    CurrentFieldColor = _tipService.GetChangedFieldColor(this);
            }
        }

        private void SetDefaultFieldColor(object obj)
        {
            if (IsReadonly)
                return;
            lock (_thisLock)
            {
                if (!IsPawnSet)
                    CurrentFieldColor = DefaultFieldColor;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
