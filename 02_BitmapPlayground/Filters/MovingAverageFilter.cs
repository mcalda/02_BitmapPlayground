using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BitmapPlayground.Filters
{
  class MovingAverageFilter :IFilter
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
          if (x != 0 && x != width - 1 && y != 0 && y != height - 1)
          {
            result[x, y] = CalculateAverage(input, x, y);
          }
          else
          {
            result[x, y] = p;
          }
        });
      });

      return result;
    }

    private static Color CalculateAverage(Color[,] input, int x, int y)
    {
      int averageAlpha = (int)(input[x - 1, y].A + input[x + 1, y].A + input[x, y - 1].A + input[x, y + 1].A) / 4;
      int averageRed = (int)(input[x - 1, y].R + input[x + 1, y].R + input[x, y - 1].R + input[x, y + 1].R) / 4;
      int averageGreen = (int)(input[x - 1, y].G + input[x + 1, y].G + input[x, y - 1].G + input[x, y + 1].G) / 4;
      int averageBlue = (int)(input[x - 1, y].B + input[x + 1, y].B + input[x, y - 1].B + input[x, y + 1].B) / 4;

      return Color.FromArgb(averageAlpha, averageRed, averageGreen, averageBlue);
    }

    public string Name => "Moving average filter";
    public override string ToString()
        => Name;
  }
}
