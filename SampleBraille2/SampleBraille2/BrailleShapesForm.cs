using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleBraille2
{
    public partial class BrailleShapesForm : Form
    {
        BrailleWServiceRef.BrailleWServiceSoapClient client = new BrailleWServiceRef.BrailleWServiceSoapClient();
        public BrailleShapesForm()
        {
            InitializeComponent();
            InitComponents();
            PopulateComboBox();
        }

        private void InitComponents()
        {
            label2.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button1.Enabled = false;
        }

        private void PopulateComboBox()//This is to avoid regenerating shapes in the dropdown
        {
            string[] shapes = client.Shapes().ToArray();

            foreach (string shape in shapes)
            {
                comboBox1.Items.Add(shape);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 

            if(comboBox1.SelectedIndex >= 0)
            {
                string selectedShape = comboBox1.SelectedItem.ToString();

                string[] parameters = client.parameters(selectedShape).ToArray();//calling web service parameters

                if(selectedShape.Equals("circle"))
                {
                    //enabling necessary components
                    label2.Enabled = true;
                    button1.Enabled = true;
                    textBox1.Enabled = true;

                    label3.Enabled = false;
                    textBox2.Enabled = false;

                    string message = string.Join(",", parameters);
                    label2.Text = "Enter the " + message;
                    button1.Text = "Circumference";
                    
                }
                else if (selectedShape.Equals("square"))
                {
                    //enabling necessary components
                    label2.Enabled = true;
                    button1.Enabled = true;
                    textBox1.Enabled = true;

                    label3.Enabled = false;
                    textBox2.Enabled = false;

                    button1.Text = "Perimeter";

                    string message = string.Join("",parameters);
                    label2.Text = "Enter the " + message;
                    
                }
                else if (selectedShape.Equals("rectangle"))
                {
                    //enabling necessary components
                    label2.Enabled = true;
                    button1.Enabled = true;
                    textBox1.Enabled = true;

                    button1.Text = "Perimeter";

                    string message1 = parameters[0];
                    string message2 = parameters[1];

                    label3.Enabled = true;
                    textBox2.Enabled = true;
                    label2.Text = "Enter the " + message1;
                    label3.Text = "Enter the " + message2;
                    
                }
                else if (selectedShape.Equals("triangle"))
                {
                    //enabling necessary components
                    label2.Enabled = true;
                    button1.Enabled = true;
                    textBox1.Enabled = true;

                    label3.Enabled = false;
                    textBox2.Enabled = false;

                    button1.Text = "Perimeter";

                    string message = string.Join("", parameters);
                    label2.Text = "Enter the " + message;
                    
                }
                else
                {
                    MessageBox.Show("No parameters for this shape");
                }
            }
        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double data1 = Convert.ToDouble(textBox1.Text.ToString());
            
            string selectedShape = comboBox1.SelectedItem.ToString();

            if (selectedShape.Equals("circle"))
            {
               double circum = client.circumference(data1);
                MessageBox.Show("Circumference:" + circum);
                textBox3.Text = client.reqDotAmount(circum).ToString();
            }
            if (selectedShape.Equals("square"))
            {
                double perim = client.perimeter(selectedShape,data1,0);
                MessageBox.Show("Perimeter:" + perim);
                textBox3.Text = client.reqDotAmount(perim).ToString();

            }
            if (selectedShape.Equals("rectangle"))
            {
                try
                {
                    double data2 = Convert.ToDouble(textBox2.Text.ToString());
                    double perim = client.perimeter(selectedShape, data1, data2);
                    MessageBox.Show("Perimeter:" + perim);
                    textBox3.Text = client.reqDotAmount(perim).ToString();


                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a value for the breadth");
                }
                
                
                
            }
            if (selectedShape.Equals("triangle"))
            {
                double perim = client.perimeter(selectedShape, data1, 0);
                MessageBox.Show("Perimeter:" + perim);
                textBox3.Text = client.reqDotAmount(perim).ToString();

            }

            label4.Enabled = true;
            textBox3.Enabled = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.ResetText();
            InitComponents();
        }
    }
}
