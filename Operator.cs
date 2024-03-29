﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/**
 * Класс оператор будет представлять собой какое либо математическое действие.
 * symbol - символ операции который будет использован при записи выражения, пример "^" - возведение в степень
 * associativity - ассоциативность оператора, левая или правоя
 * operation - операция в языке, пример Math.Pow в С# (оставим на будуйщее)
 */
namespace Stack_machine
{
    public class Operator
    {
        public Operator(string symbol, int priority, string associativity)
        {
            this.symbol = symbol;
            this.associativity = associativity;
            this.priority = priority;
        }
        private string symbol;
        private string associativity;
        private int priority;

        public string Symbol
        {
            get { return this.symbol; }
        }
        public string Associativity
        {
            get { return this.associativity; }
        }
        public int Priority
        {
            get { return this.priority; }
        }
    }
}
