using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_machine
{
    public class NotValidTokenException: Exception
    {
        public override string ToString()
        {
            return "В выражении указан не валидный элемент!";
        }
    }
}
