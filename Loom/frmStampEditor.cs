using JsonSettings;
using Loom.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Loom
{
	public partial class frmStampEditor : Form
	{
		private const string fileDialogFilter = "Stamp Files|*.stamp|All Files|*.*";
		private Stamp _stamp = null;

		public frmStampEditor()
		{
			InitializeComponent();
			dgvStamp.AutoGenerateColumns = false;
		}

		private void tsbOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = fileDialogFilter;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				_stamp = JsonFile.Load<Stamp>(dlg.FileName);
				InitDataBinding(_stamp);
			}
		}

		private void InitDataBinding(Stamp stamp)
		{
			tbWidth.DataBindings.Clear();
			tbHeight.DataBindings.Clear();

			tbWidth.DataBindings.Add(new Binding("Text", stamp, "Width"));
			tbHeight.DataBindings.Add(new Binding("Text", stamp, "Height"));

			BindingList<StampPoint> points = new BindingList<StampPoint>(stamp.Fill);
			dgvStamp.DataSource = points;
		}

		private void tsbSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.DefaultExt = "stamp";
			dlg.Filter = fileDialogFilter;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				JsonFile.Save(dlg.FileName, _stamp);
			}
		}

		private void frmStampEditor_Load(object sender, EventArgs e)
		{			
			FillColorOptions();

			_stamp = new Stamp(1, 1, new List<StampPoint>() { new StampPoint(0, 0, Brushes.AliceBlue) }, this.Font);
			InitDataBinding(_stamp);
		}

		private void FillColorOptions()
		{
			// thanks to https://stackoverflow.com/a/14047729/2023653

			colColor.Items.Clear();
			colColor.ValueMember = "Brush";
			colColor.DisplayMember = "Name";

			var colors = typeof(Brushes).GetProperties().Select(pi => new ColorOption() { Name = pi.Name, Brush = pi.GetValue(null) as Brush }).ToArray();
			foreach (var item in colors) colColor.Items.Add(item);
		}

		private void dgvStamp_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			// ignore
		}
	}
}