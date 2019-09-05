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
                    if (tiles[i][k] == 0) { square.FillColor = Color.Black; }
                    else if (tiles[i][k] == 1) { square.FillColor = Color.White; }
                    else if (tiles[i][k] == 2) { square.FillColor = new Color(221, 46, 68); }
                    else if (tiles[i][k] == 3) { square.FillColor = new Color(119, 178, 85); }
                    else if (tiles[i][k] == 4) { square.FillColor = new Color(59, 136, 195); }
                    else if (tiles[i][k] == 5) { square.FillColor = new Color(244, 144, 12); }
                    else if (tiles[i][k] == 6) { square.FillColor = new Color(116, 78, 170); }

                    window.Draw(square);
                }
            }
        }

        public void ChangePixel(int x, int y, string color)
        {
            if (x < Utils.SIZE_MAP_X && x >= 0 && y < Utils.SIZE_MAP_Y && y >= 0) {

                switch (color)
                {
                    case "BLACK":
                        tiles[x][y] = 0;
                        break;
                    case "WHITE":
                        tiles[x][y] = 1;
                        break;
                    case "RED":
                        tiles[x][y] = 2;
                        break;
                    case "GREEN":
                        tiles[x][y] = 3;
                        break;
                    case "BLUE":
                        tiles[x][y] = 4;
                        break;
                    case "YELLOW":
                        tiles[x][y] = 5;
                        break;
                    case "PURPLE":
                        tiles[x][y] = 6;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
