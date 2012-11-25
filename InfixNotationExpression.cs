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
                    string newDigit = "";
                    newDigit = newChar.Replace('.', ',');
                    try
                    {
                        Convert.ToDouble(newDigit);
                    }
                    catch
                    {
                        throw new NotValidTokenException();
                    }
                    stack.Push(newDigit);
                }
                if (this.ContainsOperation(newChar))
                {
                    if (stack.Count >= 2)
                    {
                        string element2 = stack.Pop();
                        string element1 = stack.Pop();
                        if (this.ExpressionContainsPrioritylessOperator(element1, newChar))
                        {
                            element1 = "(" + element1 + ")";
                        }
                        if (this.ExpressionContainsPrioritylessOperator(element2, newChar))
                        {
                            element2 = "(" + element2 + ")";
                        }
                        oper = newChar;
                        stack.Push(element1 + newChar + element2);
                    }
                    else
                    {
                        throw new UnaryOperatorException();
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

        private bool ExpressionContainsPrioritylessOperator(string element, string oper)
        {
            for (int i = 0; i < element.Length; i++)
            {
                if (this.ContainsOperation(element[i].ToString()) && this.GetPriority(element[i].ToString()) < this.GetPriority(oper))
                {
                    return true;
                }
            }
            return false;
        }
        public string CalculateExpression(string[] input)
        {
            Stack<string> stack = new Stack<string>();
            foreach (string newChar in input)
            {
                if (Char.IsDigit(newChar[0]))
                {
                    string newDigit = "";
                    newDigit = newChar.Replace('.', ',');
                    try
                    {
                        Convert.ToDouble(newDigit);
                    }
                    catch
                    {
                        throw new NotValidTokenException();
                    }
                    stack.Push(newDigit);
                }
                if (this.ContainsOperation(newChar))
                {
                    if (stack.Count >= 2)
                    {
                        string element2 = stack.Pop();
                        string element1 = stack.Pop();
                        switch (newChar)
                        {
                            case "+":
                                stack.Push((Convert.ToDouble(element1) + Convert.ToDouble(element2)).ToString());
                                break;
                            case "-":
                                stack.Push((Convert.ToDouble(element1) - Convert.ToDouble(element2)).ToString());
                                break;
                            case "*":
                                stack.Push((Convert.ToDouble(element1) * Convert.ToDouble(element2)).ToString());
                                break;
                            case "/":
                                stack.Push((Convert.ToDouble(element1) / Convert.ToDouble(element2)).ToString());
                                break;
                            case "^":
                                stack.Push(Math.Pow((Convert.ToDouble(element1)), Convert.ToDouble(element2)).ToString());
                                break;
                        }
                    }
                    else
                    {
                        throw new UnaryOperatorException();
                    }
                }
                if (this.IsFunction(newChar))
                {
                    string element1 = stack.Pop();
                    switch (newChar)
                    {
                        case "exp":
                            stack.Push(Math.Exp(Convert.ToDouble(element1)).ToString());
                            break;
                        case "abs":
                            stack.Push(Math.Abs(Convert.ToDouble(element1)).ToString());
                            break;
                        case "cos":
                            stack.Push(Math.Cos(Convert.ToDouble(element1)).ToString());
                            break;
                        case "sin":
                            stack.Push(Math.Sin(Convert.ToDouble(element1)).ToString());
                            break;
                        case "tan":
                            stack.Push(Math.Tan(Convert.ToDouble(element1)).ToString());
                            break;
                        case "atn":
                            stack.Push(Math.Atan(Convert.ToDouble(element1)).ToString());
                            break;
                        case "sqr":
                            stack.Push(Math.Sqrt(Convert.ToDouble(element1)).ToString());
                            break;
                    }
                }
                if (Char.IsLetter(newChar[0]) && !this.IsFunction(newChar))
                {
                    throw new CalculationOfVariableException();
                }
            }
            return stack.Pop();
        }
    }
}
