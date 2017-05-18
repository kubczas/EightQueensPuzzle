using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services.Constraints
{
    public interface IConstraint
    {
        bool IsConstraintMet(ChessboardField destinationChessboardField);

        bool IsConstraintMet(ChessboardField destinationChessboardField, int scope);
    }
}
