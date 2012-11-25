using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_machine
{
    public class CalculationOfVariableException : Exception
    {
        public override string ToString()
        {
            return "Невозможно вычислить выражение содержащее переменную!";
        }
    }
}
