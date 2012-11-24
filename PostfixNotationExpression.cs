using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**
 * Собственно класс который и преобразует инфиксную запись в постфиксную 
 * и возвращает это в виде массива строк
 */
namespace Stack_machine
{
    public class PostfixNotationExpression: NotationExpression
    {
        public string[] ConvertToPostfixNotation(string input)
        {
            List<string> outputSeparated = new List<string>();
            Stack<string> stack = new Stack<string>();
            foreach (string newChar in this.Separate(input))
            {
                if (this.ContainsOperation(newChar))
                {
                    if (stack.Count > 0 && !newChar.Equals("("))
                    {
                        if (newChar.Equals(")"))
                        {
                            string outputString = stack.Pop();
                            while (outputString != "(")
                            {
                                outputSeparated.Add(outputString);
                                outputString = stack.Pop();
                            }
                        }
                        else if (this.GetPriority(newChar) >= this.GetPriority(stack.Peek()))
                            stack.Push(newChar);
                        else
                        {
                            while (stack.Count > 0 && GetPriority(newChar) < GetPriority(stack.Peek()))
                                outputSeparated.Add(stack.Pop());
                            stack.Push(newChar);
                        }
                    }
                    else
                        stack.Push(newChar);
                }
                else
                    outputSeparated.Add(newChar);
            }
            if (stack.Count > 0)
                foreach (string c in stack)
                    outputSeparated.Add(c);

            return outputSeparated.ToArray();
        }
    }
}
