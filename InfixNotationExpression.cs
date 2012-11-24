using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack_machine
{
    public class InfixNotationExpression : NotationExpression
    {
        public string ConvertToInfixNotation(string[] input)
        {
            string oper = "", output = "";
            Stack<string> stack = new Stack<string>();
            foreach (string newChar in input)
            {
                if (Char.IsDigit(newChar[0]))
                {
                    stack.Push(newChar);
                }
                if (this.ContainsOperation(newChar))
                {
                    if (stack.Count >= 2)
                    {
                        string element2 = stack.Pop();
                        string element1 = stack.Pop();
                        if (("" != oper) && (this.GetPriority(oper) < this.GetPriority(newChar)))
                        {
                            stack.Push("(" + element1 + ")" + newChar + element2);
                        }
                        else
                        {
                            oper = newChar;
                            stack.Push(element1 + newChar + element2);
                        }
                    }
                    else
                    {
                        string element1 = stack.Pop();
                        stack.Push(newChar + element1);
                    }
                }
                if (this.IsFunction(newChar))
                {
                    string element1 = stack.Pop();
                    stack.Push(newChar + "(" + element1 + ")");
                }
                if (Char.IsLetter(newChar[0]) && !this.IsFunction(newChar))
                {
                    stack.Push(newChar);
                }
            }
            if (stack.Count > 0)
                foreach (string c in stack)
                    output += c;

            return output;
        }
    }
}
