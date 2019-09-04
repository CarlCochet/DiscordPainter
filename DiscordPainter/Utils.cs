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

        public const int SIZE_MAP_X = 10;
        public const int SIZE_MAP_Y = 10;

        public const int SQUARE_SIZE = WIDTH / SIZE_MAP_X;

        public const String BLACK = ":black_large_square:";
        public const String WHITE = ":white_large_square:";

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
