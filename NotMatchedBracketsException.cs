using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_machine
{
    public class NotMatchedBracketsException: Exception
    {
        public override string ToString()
        {
            return "В выражении не согласованы скобки!";
        }
    }
}
