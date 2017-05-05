using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueensPuzzle.Services.Constraints
{
    public interface IConstraint
    {
        bool IsConstraintMet(ChessboardField destinationChessboardField);
    }
}
