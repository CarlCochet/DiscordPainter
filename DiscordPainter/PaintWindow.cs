using System;
using System.Collections.Generic;
using System.Text;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

using TGUI;

namespace DiscordPainter
{
    class PaintWindow
    {
        private RenderWindow window;
        private Gui gui;
        private bool colorMode;
        private Canvas canvas;
        private bool pressed;


        public void Run()
        {
            var mode = new VideoMode(Utils.WIDTH, Utils.HEIGHT);
            window = new RenderWindow(mode, "Discord Painter");
            window.Closed += (_, __) => window.Close();
            window.MouseButtonPressed += Window_MouseButtonPressed;
            window.MouseMoved += Window_MouseMoved;
            window.MouseButtonReleased += Window_MouseButtonReleased;

            gui = new Gui(window);
            canvas = new Canvas();

            pressed = false;

            CreateGUI();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear();

                
                canvas.Render(ref window);
                gui.Draw();

                window.Display();
            }

        }

        public void CloseWindow()
        {
            window.Close();
        }

        private void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            var window = (Window)sender;

            // Just set the new start coords eveytime the Left mouse button is pressed
            if (e.Button == Mouse.Button.Left)
            {
                pressed = true;
                canvas.ChangePixel(e.X / Utils.SQUARE_SIZE, e.Y / Utils.SQUARE_SIZE, colorMode);
            }
        }

        private void Window_MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            var window = (Window)sender;

            // Just set the new start coords eveytime the Left mouse button is pressed
            if (e.Button == Mouse.Button.Left)
            {
                pressed = false;
            }
        }

        private void Window_MouseMoved(object sender, MouseMoveEventArgs e)
        {
            var window = (Window)sender;

            if (pressed)
                canvas.ChangePixel(e.X / Utils.SQUARE_SIZE, e.Y / Utils.SQUARE_SIZE, colorMode);
        }

        public void CreateGUI()
        {
            if (gui != null)
                gui.RemoveAllWidgets();

            var buttonWhite = new Button("White")
            {
                Position = new Vector2f(Utils.WIDTH * 41 / 50, Utils.HEIGHT * 1 / 7),
                Size = new Vector2f(Utils.WIDTH * 8 / 50, Utils.HEIGHT / 10),
                TextSize = (uint)(0.5 * Utils.HEIGHT / 10)
            };
            gui.Add(buttonWhite);

            buttonWhite.Pressed += (s, e) => SwitchColor(true);

            var buttonBlack = new Button("Black")
            {
                Position = new Vector2f(Utils.WIDTH * 41 / 50, Utils.HEIGHT * 2 / 7),
                Size = new Vector2f(Utils.WIDTH * 8 / 50, Utils.HEIGHT / 10),
                TextSize = (uint)(0.5 * Utils.HEIGHT / 10)
            };
            gui.Add(buttonBlack);

            buttonBlack.Pressed += (s, e) => SwitchColor(false);

            var buttonNew = new Button("New")
            {
                Position = new Vector2f(Utils.WIDTH * 41 / 50, Utils.HEIGHT * 4 / 7),
                Size = new Vector2f(Utils.WIDTH * 8 / 50, Utils.HEIGHT / 10),
                TextSize = (uint)(0.5 * Utils.HEIGHT / 10)
            };
            gui.Add(buttonNew);

            buttonNew.Pressed += (s, e) => NewPaint();

            var buttonOutput = new Button("Output")
            {
                Position = new Vector2f(Utils.WIDTH * 41 / 50, Utils.HEIGHT * 5 / 7),
                Size = new Vector2f(Utils.WIDTH * 8 / 50, Utils.HEIGHT / 10),
                TextSize = (uint)(0.5 * Utils.HEIGHT / 10)
            };
            gui.Add(buttonOutput);

            buttonOutput.Pressed += (s, e) => OutputPaint();

            var buttonQuit = new Button("Exit")
            {
                Position = new Vector2f(Utils.WIDTH * 41 / 50, Utils.HEIGHT * 6 / 7),
                Size = new Vector2f(Utils.WIDTH * 8 / 50, Utils.HEIGHT / 10),
                TextSize = (uint)(0.5 * Utils.HEIGHT / 10)
            };
            gui.Add(buttonQuit);

            buttonQuit.Pressed += (s, e) => CloseWindow();
        }

        public void SwitchColor(bool color)
        {
            colorMode = color;
        }

        public void OutputPaint()
        {
            StringBuilder output = new StringBuilder();
            
            for (int i = 0; i < Utils.SIZE_MAP_X; i++)
            {
                for (int k = 0; k < Utils.SIZE_MAP_Y; k++)
                {
                    if (canvas.tiles[k][i] == 1)
                    {
                        output.Append(Utils.WHITE);
                    }
                    else
                    {
                        output.Append(Utils.BLACK);
                    }
                }
                if (i == (Utils.SIZE_MAP_X / 2) - 1)
                    output.Append("\n");

                output.Append("\n");
            }

            Console.WriteLine(output);
        }

        public void NewPaint()
        {
            canvas = new Canvas();
        }

    }
}
