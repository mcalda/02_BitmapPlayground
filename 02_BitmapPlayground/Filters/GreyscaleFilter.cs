using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BitmapPlayground.Filters
{
  class GreyscaleFilter : IFilter
  {
    
    public Color[,] Apply(Color[,] input)
    {
      int width = input.GetLength(0);
      int height = input.GetLength(1);
      Color[,] result = new Color[width, height];

      Parallel.For(0, width, x =>
      {
        Parallel.For(0, height, y =>
        {
          var p = input[x, y];
          int grayScale = (int)((p.R * 0.3) + (p.G * 0.59) + (p.B * 0.11));
          result[x, y] = Color.FromArgb(p.A, grayScale, grayScale, grayScale);
        });
      });

      return result;
    }
    public string Name => "Grayscale filter";
    public override string ToString()
        => Name;
  }
}
