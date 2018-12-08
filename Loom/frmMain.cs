using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loom
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void frmMain_Paint(object sender, PaintEventArgs e)
		{
			var warpBrush = Brushes.Aqua;
			var weftBrush = Brushes.Goldenrod;

			/*for (int i = 0; i < 50; i++)
			{
				e.Graphics.FillRectangle(warpBrush, new Rectangle(new Point(0, i * 10), new Size(this.ClientRectangle.Width, 10)));
				e.Graphics.FillRectangle(weftBrush, new Rectangle(new Point(0, (i * 10) + 10), new Size(this.ClientRectangle.Width, 10)));
				i += 1;
			}*/

			const int pointSize = 20;

			

			for (int x = 1; x < this.ClientRectangle.Width; x += pointSize)
			{
				for (int y = 1; y < this.ClientRectangle.Height; y += pointSize)
				{
					int xSquare = x / pointSize;
					int ySquare = y / pointSize;

					if ((xSquare % 2) == 0)
					{
						e.Graphics.FillRectangle(warpBrush, new Rectangle(new Point(x, y + pointSize), new Size(pointSize, pointSize)));
					}
					else
					{
						
					}			
					
					if ((ySquare % 2) == 0)
					{
						e.Graphics.FillRectangle(weftBrush, new Rectangle(new Point(x + (pointSize - 1 * pointSize), y + pointSize), new Size(pointSize, pointSize)));
					}
				}
			}
			
		}
	}
}
