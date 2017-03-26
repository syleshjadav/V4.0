using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyShopComp
{
  public class Helper
  {

        public static void ResetAllControls(Control form)
        {
            foreach (Control control in form.Controls)
            {
                RecursiveResetForm(control);
            }
        }

        private static void RecursiveResetForm(Control control)
        {
            if (control.HasChildren)
            {
                foreach (Control subControl in control.Controls)
                {
                    RecursiveResetForm(subControl);
                }
            }
            switch (control.GetType().Name)
            {
                case "TextBox":
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                    break;

                case "ComboBox":
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                    break;

                case "CheckBox":
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                    break;

                case "ListBox":
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                    break;

                case "NumericUpDown":
                    NumericUpDown numericUpDown = (NumericUpDown)control;
                    numericUpDown.Value = 0;
                    break;
            }
        }


        public static void ClearFormControls(Form form)
    {
      foreach (Control control in form.Controls)
      {
        if (control is TextBox)
        {
          TextBox txtbox = (TextBox)control;
          txtbox.Text = string.Empty;
        }
        else if (control is CheckBox)
        {
          CheckBox chkbox = (CheckBox)control;
          chkbox.Checked = false;
        }
        else if (control is RadioButton)
        {
          RadioButton rdbtn = (RadioButton)control;
          rdbtn.Checked = false;
        }
        else if (control is DateTimePicker)
        {
          DateTimePicker dtp = (DateTimePicker)control;
          dtp.Value = DateTime.Now;
        }

        else if (control is GroupBox)
        {
          if (control.HasChildren)
          {
            foreach (Control child in control.Controls)
            {
              if (control is TextBox)
              {
                TextBox txtbox = (TextBox)control;
                txtbox.Text = string.Empty;

              }
            }
          }
        }
      }
    }
  }
}
