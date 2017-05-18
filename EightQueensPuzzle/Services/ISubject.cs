namespace EightQueensPuzzle.Services
{
    interface ISubject
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Notify();
    }
}
