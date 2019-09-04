using System;
using System.Collections.Generic;
using System.Text;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace DiscordPainter
{
    class Canvas
    {
        public int[][] tiles { get; private set; }

        public Canvas()
        {
            tiles = Utils.CreateMap(Utils.SIZE_MAP_X, Utils.SIZE_MAP_Y, 1);
        }

        public void Render(ref RenderWindow window)
        {
            var square = new RectangleShape(new Vector2f(Utils.SQUARE_SIZE, Utils.SQUARE_SIZE))
            {
                OutlineColor = Color.Black,
                OutlineThickness = 1f
            };

            for (int i = 0; i < Utils.SIZE_MAP_X; i++)
            {
                for (int k = 0; k < Utils.SIZE_MAP_Y; k++)
                {
                    square.Position = new Vector2f(i * Utils.SQUARE_SIZE, k * Utils.SQUARE_SIZE);

                    // Fill color is changed for obstacles
                    if (tiles[i][k] == 1) { square.FillColor = Color.White; }
                    else if (tiles[i][k] == 0) { square.FillColor = Color.Black; }
                    else { square.FillColor = new Color(128, 128, 128); }

                    window.Draw(square);
                }
            }
        }

        public void ChangePixel(int x, int y, bool color)
        {
            if (x < Utils.SIZE_MAP_X && x >= 0 && y < Utils.SIZE_MAP_Y && y >= 0) {
                if (color)
                    tiles[x][y] = 1;
                else
                    tiles[x][y] = 0;
            }
        }
    }
}
