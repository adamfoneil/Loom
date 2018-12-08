using System.Drawing;

namespace Loom.Controls
{
	public class ColorOption
	{
		public string Name { get; set; }
		public Brush Brush { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}