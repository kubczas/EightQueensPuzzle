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
        private readonly IGameViewModel _gameViewModel;
        private readonly IChessboardValidatorStrategy _validatorStrategy;
        private readonly object _thisLock;
        private static readonly SolidColorBrush DefaultFieldColor = new SolidColorBrush(Color.FromRgb(100, 181, 246));
        private Brush _currentFieldColor;

        public ChessboardField(int row, int column)
        {
            Row = row;
            Column = column;
            _tipService = UnityService.Instance.Get().Resolve<ITipService>();
            _gameViewModel = UnityService.Instance.Get().Resolve<IGameViewModel>();
            _validatorStrategy = UnityService.Instance.Get().Resolve<IChessboardValidatorManager>().GetChessboardValidatorStrategy(_gameViewModel.SelectedPawn.GetType());
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
                if (!IsPawnSet && _validatorStrategy.Validate(this))
                {
                    SetPawnOnField();
                    _gameViewModel.NumberOfLeftPawns = _gameViewModel.NumberOfLeftPawns - 1;
                }
                else if(Equals(CurrentFieldColor, FieldColorHelper.GoodFieldColor))
                {
                    _gameViewModel.NumberOfLeftPawns = _gameViewModel.NumberOfLeftPawns + 1;
                    ClearField();
                }
            }
        }

        private void ClearField()
        {
            IsPawnSet = false;
            CurrentFieldColor = DefaultFieldColor;
        }

        private void SetPawnOnField()
        {
            var queen = new ImageBrush {ImageSource = ViewModelBase.GameSettings.SelectedPawn.Image};
            CurrentFieldColor = queen;
            IsPawnSet = true;
        }

        private void ChangeColor(object obj)
        {
            if (IsReadonly)
                return;
            lock (_thisLock)
            {
                if (CurrentFieldColor is SolidColorBrush && _gameViewModel.IsTipsEnabled)
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
