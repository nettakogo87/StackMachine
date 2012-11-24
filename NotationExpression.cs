using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/**
 * Абстрактный класс выражения. Тут будут храниться общие для данные и методы 
 * для инфиксного и постфиксного преобразования
 */
namespace Stack_machine
{
    abstract public class NotationExpression
    {
        private List<Operator> operators;
        public NotationExpression()
        {
            this.operators = new List<Operator>();
            string allText = System.IO.File.ReadAllText(@"def.txt");
            string[] constrain = {"\r\n"};
            string[] operations = allText.Split(constrain, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < operations.Length; i++)
            {
                string[] strMass = operations[i].Split(' ');
                Operator newOperator = new Operator(strMass[0], Convert.ToInt16(strMass[1]), strMass[2]);
                this.operators.Add(newOperator);
            }
           
        }

        protected IEnumerable<string> Separate(string input)
        {
            List<string> inputSeparated = new List<string>();
            int position = 0;
            while (position < input.Length)
            {
                string output = string.Empty + input[position];
                if (!this.ContainsOperation(input[position].ToString()))
                {
                    if (Char.IsDigit(input[position]))
                        for (int i = position + 1; i < input.Length &&
                            (Char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                            output += input[i];
                    else if (Char.IsLetter(input[position]))
                        for (int i = position + 1; i < input.Length &&
                            (Char.IsLetter(input[i]) || Char.IsDigit(input[i])); i++)
                            output += input[i];
                }
                yield return output;
                position += output.Length;
            }
        }
        protected bool ContainsOperation(string input)
        {
            foreach (Operator oper in this.operators)
            {
                if (oper.Symbol == input)
                {
                    return true;
                }
            }
            return false;
        }
        protected int GetPriority(string input)
        {
            foreach (Operator oper in this.operators)
            {
                if (oper.Symbol == input)
                {
                    return oper.Priority;
                }
            }
            return -1;
        }
    }
}
