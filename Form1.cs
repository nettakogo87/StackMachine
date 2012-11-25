using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stack_machine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InfToPostButton_Click(object sender, EventArgs e)
        {
            PostfixNotationExpression postExp = new PostfixNotationExpression();
            try
            {
                string[] str = postExp.ConvertToPostfixNotation(this.InfToPostTextBox.Text);
                this.PostToInfTextBox.Clear();
                for (int i = 0; i < str.Length; i++)
                {
                    this.PostToInfTextBox.Text += str[i] + "\r\n";
                }
            }
            catch (NotMatchedBracketsException ex)
            {
                const string caption = "Ошибка в выражении!";
                var result = MessageBox.Show(ex.ToString(), caption,
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Question);
            }
        }

        private void PostToInfButton_Click(object sender, EventArgs e)
        {
            InfixNotationExpression infExp = new InfixNotationExpression();
            string[] constrain = { "\r\n" };
            string[] inputs = this.PostToInfTextBox.Text.Split(constrain, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                string exptession = infExp.ConvertToInfixNotation(inputs);
                this.InfToPostTextBox.Clear();
                this.InfToPostTextBox.Text = exptession;
            }
            catch (NotValidTokenException ex)
            {
                this.ThrowMessageException(ex.ToString());
            }
            catch (UnaryOperatorException ex)
            {
                this.ThrowMessageException(ex.ToString());
            }
            catch
            {
                this.ThrowMessageException("Да какого?!!");
            }
            
        }

        private void PostCalculateButton_Click(object sender, EventArgs e)
        {
            InfixNotationExpression infExp = new InfixNotationExpression();
            string[] constrain = { "\r\n" };
            string[] inputs = this.PostToInfTextBox.Text.Split(constrain, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                string calc = infExp.CalculateExpression(inputs);
                this.CalculateTextBox.Clear();
                this.CalculateTextBox.Text = calc;
            }
            catch (CalculationOfVariableException ex)
            {
                this.ThrowMessageException(ex.ToString());
            }
            catch (NotValidTokenException ex)
            {
                this.ThrowMessageException(ex.ToString());
            }
            catch (UnaryOperatorException ex)
            {
                this.ThrowMessageException(ex.ToString());
            }
            catch
            {
                this.ThrowMessageException("Да какого?!!");
            }
        }
        private void ThrowMessageException(string exceptionString)
        {
            const string caption = "Ошибка в выражении!";
            var result = MessageBox.Show(exceptionString, caption,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Question);
        }
    }
}
