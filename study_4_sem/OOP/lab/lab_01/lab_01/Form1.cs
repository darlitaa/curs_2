using System;
using System.Windows.Forms;

namespace TextCalculator
{
    public partial class Form1 : Form
    {
        private Calculator calculator;

        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator();
            calculator.OnCalculationPerformed += DisplayResult;
        }

        private void DisplayResult(string result)
        {
            txtOutput.Text = result;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            bool operationSuccessful = false;
            try
            {
                calculator.ReplaceSubstring(txtInput.Text, txtOldSubstring.Text, txtNewSubstring.Text);
                operationSuccessful = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (operationSuccessful)
                {
                    MessageBox.Show("Операция выполнена успешно!");
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            bool operationSuccessful = false;
            try
            {
                calculator.RemoveSubstring(txtInput.Text, txtSubstringToRemove.Text);
                operationSuccessful = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (operationSuccessful)
                {
                    MessageBox.Show("Операция выполнена успешно!");
                }
            }
        }

        private void btnCharAtIndex_Click(object sender, EventArgs e)
        {
            bool operationSuccessful = false;
            try
            {
                int index = Convert.ToInt32(txtIndex.Text);
                calculator.GetCharAtIndex(txtInput.Text, index);
                operationSuccessful = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (operationSuccessful)
                {
                    MessageBox.Show("Операция выполнена успешно!");
                }
            }
        }

        private void btnLength_Click(object sender, EventArgs e)
        {
            bool operationSuccessful = false;
            try
            {
                calculator.GetLength(txtInput.Text);
                operationSuccessful = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (operationSuccessful)
                {
                    MessageBox.Show("Операция выполнена успешно!");
                }
            }
        }

        private void btnSentenceCount_Click(object sender, EventArgs e)
        {
            bool operationSuccessful = false;
            try
            {
                calculator.GetSentenceCount(txtInput.Text);
                operationSuccessful = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (operationSuccessful)
                {
                    MessageBox.Show("Операция выполнена успешно!");
                }
            }
        }

        private void btnWordCount_Click(object sender, EventArgs e)
        {
            bool operationSuccessful = false;
            try
            {
                calculator.GetWordCount(txtInput.Text);
                operationSuccessful = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (operationSuccessful)
                {
                    MessageBox.Show("Операция выполнена успешно!");
                }
            }
        }

        private void btnVowelsCount_Click(object sender, EventArgs e)
        {
            bool operationSuccessful = false;
            try
            {
                calculator.GetVowelsCount(txtInput.Text);
                operationSuccessful = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (operationSuccessful)
                {
                    MessageBox.Show("Операция выполнена успешно!");
                }
            }
        }

        private void btnConsonantsCount_Click(object sender, EventArgs e)
        {
            bool operationSuccessful = false;
            try
            {
                calculator.GetConsonantsCount(txtInput.Text);
                operationSuccessful = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (operationSuccessful)
                {
                    MessageBox.Show("Операция выполнена успешно!");
                }
            }
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}