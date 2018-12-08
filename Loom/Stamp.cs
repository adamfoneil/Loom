using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Loom
{
	/// <summary>
	/// A pattern of colored squares that forms a single large rectangle
	/// </summary>
	public class Stamp
	{
		public Stamp(int width, int height, List<StampPoint> fill, Font font)
		{
			Width = width;
			Height = height;
			Fill = fill;
			Font = font;
		}

		public int Width { get; set; }
		public int Height { get; set; }
		public List<StampPoint> Fill { get; set; }

		[JsonIgnore]
		public Font Font { get; }

		public void Draw(Graphics graphics, int scale, int gridX, int gridY)
		{
			// stamp position
			graphics.DrawString($"{gridX}, {gridY}", Font, Brushes.White, new PointF(gridX * scale, gridY * scale));

			foreach (var point in Fill)
			{
				var rect = point.GetRectangle(scale, gridX, gridY);
				graphics.FillRectangle(point.Brush, rect);

				graphics.DrawString($"{point.X}, {point.Y}", Font, Brushes.PapayaWhip, rect);

			}
		}
	}

	public class StampPoint
	{
		public StampPoint(int x, int y, Brush brush)
		{
			X = x;
			Y = y;
			Brush = brush;
		}

		public int X { get; set; }
		public int Y { get; set; }
		[JsonIgnore]
		public Brush Brush { get; set; }

		public string BrushName
		{
			get { return typeof(Brush).Name; }
			set { Brush = new SolidBrush(Color.FromName(value)); }
		}

		public Rectangle GetRectangle(int scale, int gridX, int gridY)
		{
			return new Rectangle(
				new Point((X * scale) + (gridX * scale), (Y * scale) + (gridY * scale)), 
				new Size(scale, scale));
		}
	}
}