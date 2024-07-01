using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWindowsForms
{
    public partial class WelcomePage : Form
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameForm form = new GameForm();
            form.Show();
        }

        private void End_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
