using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teacher
{
    public partial class TeacherInterface : Form
    {
        public TeacherInterface(String username)
        {
            InitializeComponent();
            Teacher teacher = new Teacher(username);
            panel_classes.Visible = true;
        }
    }
}
