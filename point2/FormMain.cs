using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
    public partial class FormMain : Form
    {
        FormOverlay form;

        public FormMain()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            form = new FormOverlay(this);
            if (checkBox1.Checked)
            {
                form.Show();
            }

            else
            {
                form.Hide();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                form.penColor = colorDialog1.Color;
            }
        }

        public int GetNumeric()
        {
            return (int)numericUpDown1.Value;
        }

        private void checkBoxFig_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
