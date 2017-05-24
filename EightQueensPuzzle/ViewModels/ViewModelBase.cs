using EightQueensPuzzle.Models;
using Microsoft.Practices.Prism.Mvvm;

namespace EightQueensPuzzle.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        public static GameSettings GameSettings { get; protected set; }
    }
}
