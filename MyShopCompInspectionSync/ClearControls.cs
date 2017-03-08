﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyShopCompInspectionSync
{
  public class Helper
  {
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
