using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chattter
{
    public partial class RateForm : Form
    {
        private int selectedIndex;
        private int rating;
        
        public int SelectedIndex
        {
            get { return selectedIndex; }
        }

        public int Rating
        {
            get { return rating; }
        }

        public RateForm()
        {
            InitializeComponent();
        }

        void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            selectedIndex = int.Parse(radioButton.Text)-1;
        }

        private void IgnoreButton_Click(object sender, EventArgs e)
        {
            //TODO 
            //count how many times specific teacher was not rated?
            Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            rating = selectedIndex + 1;
            //TODO
            //ratings need to be saved in database
            //figure out how to get specific teacher that participated in conversation
            //maybe create a class Teacher/User with some properties like name, username, type...
            Console.WriteLine("Rated: " + rating + ".");
            Close();
        }
    }
}
