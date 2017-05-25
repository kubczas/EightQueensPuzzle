namespace EightQueensPuzzle.Services.Constraints
{
    public interface IConstraintFactory
    {
        IConstraint GetDiagonalConstraint();
        IConstraint GetHorizontalConstraint();
        IConstraint GetVerticalConstraint();
        IConstraint GetKnightConstraint();
    }
}
