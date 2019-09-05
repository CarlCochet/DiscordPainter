using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordPainter
{
    public static class Utils
    {
        // Some useful constants
        public const int WIDTH = 1000;
        public const int HEIGHT = 800;

        public const int SIZE_MAP_X = 14;
        public const int SIZE_MAP_Y = 14;

        public const int GUI_WIDTH = 200;

        public const int SQUARE_SIZE = (WIDTH - GUI_WIDTH) / SIZE_MAP_X;

        public static Dictionary<string, string> COLORS = new Dictionary<string, string>()
        {
            {"BLACK", ":black_large_square:" },
            {"WHITE", ":white_large_square:" },
            {"RED", ":u5408:" },
            {"GREEN", ":u6307:" },
            {"BLUE", ":one:" },
            {"YELLOW", ":u7533:" },
            {"PURPLE", ":u7a7a:" },
        };

        // Creating a 2D array with a set value
        public static int[][] CreateMap(int width, int height, int value)
        {
            int[][] map = new int[width][];
            for (int i = 0; i < width; i++)
            {
                map[i] = new int[height];
                for (int k = 0; k < height; k++)
                {
                    map[i][k] = value;
                }
            }

            return map;
        }
    }
}
