using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_machine
{
    public class UnaryOperatorException: Exception
    {
        public override string ToString()
        {
            return "Не поддерживается перегрузка унарных операторов!";
        }
    }
}
