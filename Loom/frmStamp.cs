using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loom
{
	public partial class frmStamp : Form
	{
		public frmStamp()
		{
			InitializeComponent();
		}

		private void frmStamp_Paint(object sender, PaintEventArgs e)
		{
			const int gridSize = 50;

			var checkeredStamp = new Stamp(3, 2, new StampPoint[]
			{
				new StampPoint(0, 0, Brushes.DarkBlue),
				new StampPoint(1, 0, Brushes.OrangeRed),
				new StampPoint(0, 1, Brushes.OrangeRed),
				new StampPoint(1, 1, Brushes.DarkBlue),
				new StampPoint(2, 0, Brushes.DarkGoldenrod),
				new StampPoint(2, 1, Brushes.DarkKhaki)
			}, this.Font);

			for (int x = 0; x < 25; x += checkeredStamp.Width)
			{
				for (int y = 0; y < 25; y += checkeredStamp.Height)
				{
					checkeredStamp.Draw(e.Graphics, gridSize, x, y);
					Thread.Sleep(150);
				}
			}

		}
	}
}
