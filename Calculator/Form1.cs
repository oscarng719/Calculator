using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        Double reselt = 0;
        String operation;
        Boolean operatorClicked = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button button_click = (Button)sender;

            if (text_result.Text == "0")
                text_result.Clear();

            if (button_click.Text == ".")
            {
                if(!text_result.Text.Contains("."))
                    text_result.Text = text_result.Text + button_click.Text;
            }
            else
             text_result.Text = text_result.Text + button_click.Text;
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button_click = (Button)sender;
            operation = button_click.Text;

            if (!operatorClicked)
            {
                reselt = Double.Parse(text_result.Text);
                operatorClicked = true;

                if (label_view.Text == "")
                    label_view.Text = reselt.ToString() + " " + operation;
                else
                    label_view.Text = label_view.Text + " " + reselt.ToString() + " " + operation;
                text_result.Text = "";
            }
            else
            {
                label_view.Text = reselt.ToString() + " " + operation;
            }
        }

        private void CE_click(object sender, EventArgs e)
        {
            text_result.Text = "0";
            reselt = 0;
            label_view.Text = "";
            operatorClicked = false;
        }

        private void E_click(object sender, EventArgs e)
        {
            text_result.Text = "0";
        }

        private void result_click(object sender, EventArgs e)
        {
            label_view.Text = "";
            operatorClicked = false;
            switch (operation)
            {
                case "+":
                    text_result.Text = ((reselt + Double.Parse(text_result.Text)).ToString());
                    break;
                case "-":
                    text_result.Text = ((reselt - Double.Parse(text_result.Text)).ToString());
                    break;
                case "*":
                    text_result.Text = ((reselt * Double.Parse(text_result.Text)).ToString());
                    break;
                case "/":
                    text_result.Text = ((reselt / Double.Parse(text_result.Text)).ToString());
                    break;
            }
        }

    }
}
