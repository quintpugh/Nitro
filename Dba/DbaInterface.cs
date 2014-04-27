using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dba
{
    public partial class DbaInterface : Form
    {
        private List<Teacher> teachers;
        private List<DbaClass> classes;
        private DbaUser dba;

        public DbaInterface(String uName)
        {
            InitializeComponent();

            this.dba = new DbaUser(uName);
            teachers = Teacher.Generate();
            Combo_Class_Teacher.DataSource = teachers;
            Combo_Class_Teacher.DisplayMember = "fullName";

            classes = DbaClass.Generate();
            Listbox_Class.DataSource = classes;
            Listbox_Class.DisplayMember = "name";
        }

        private void Listbox_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbaClass c = classes.ElementAt(Listbox_Class.SelectedIndex);
            Textbox_Class_Name.Text = c.name;

            if (c.teacher != null)
            {
               // Combo_Class_Teacher.SelectedIndex =
            }

        }
    }
}
