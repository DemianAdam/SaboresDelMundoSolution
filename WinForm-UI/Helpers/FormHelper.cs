using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_UI.Helpers
{
    public static class FormHelper
    {
        public static string? GetNullableText(this TextBox txt)
        {
            return string.IsNullOrWhiteSpace(txt.Text) ? null : txt.Text.Trim();
        }
        public static T? GetSelected<T>(this DataGridView dgv)
        {
            if (dgv.SelectedRows.Count == 1)
            {
                return (T)dgv.SelectedRows[0].DataBoundItem;
            }
            return default;
        }

        public static T? GetSelected<T>(this ComboBox cmb)
        {
            if (cmb.SelectedItem != null)
            {
                return (T)cmb.SelectedItem;
            }
            return default;
        }

        public static void AddMdiChild<T>(this Form form, T childForm) where T : Form
        {
            childForm.MdiParent = form;
            childForm.Show();
        }

        public static void UpdateControl<T>(DataGridView dgv, IGetAll<T> service)
        {
            UpdateControl(dgv, service.GetAll());
        }
        public static void UpdateControl<T>(DataGridView dgv, List<T> list)
        {
            dgv.DataSource = null;
            dgv.DataSource = list;
        }
        public static void UpdateControl<T>(ComboBox cmb, IGetAll<T> service, string? dispalyMember = null)
        {
            UpdateControl(cmb, service.GetAll(), dispalyMember);
        }
        public static void UpdateControl<T>(ComboBox cmb, List<T> list, string? dispalyMember = null)
        {
            cmb.DataSource = null;
            cmb.DataSource = list;
            if (dispalyMember is not null)
            {
                cmb.DisplayMember = dispalyMember;
            }
        }
    }
}
