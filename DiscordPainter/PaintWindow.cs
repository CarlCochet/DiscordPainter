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


        public void Run()
        {
            var mode = new VideoMode(Utils.WIDTH, Utils.HEIGHT);
            window = new RenderWindow(mode, "Discord Painter");
            window.Closed += (_, __) => window.Close();

            gui = new Gui(window);
            canvas = new Canvas();

            CreateGUI();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear();

                gui.Draw();
                canvas.Render(ref window);

                window.Display();
            }

        }

        public void CloseWindow()
        {
            window.Close();
        }

        public void CreateGUI()
        {
            if (gui != null)
                gui.RemoveAllWidgets();

            var buttonWhite = new Button("White")
            {
                Position = new Vector2f(Utils.WIDTH * 21 / 25, Utils.HEIGHT * 1 / 7),
                Size = new Vector2f(Utils.WIDTH * 3 / 25, Utils.HEIGHT / 10),
                TextSize = (uint)(0.6 * Utils.HEIGHT / 10)
            };
            gui.Add(buttonWhite);

            buttonWhite.Pressed += (s, e) => SwitchColor(true);

            var buttonBlack = new Button("Black")
            {
                Position = new Vector2f(Utils.WIDTH * 21 / 25, Utils.HEIGHT * 2 / 7),
                Size = new Vector2f(Utils.WIDTH * 3 / 25, Utils.HEIGHT / 10),
                TextSize = (uint)(0.6 * Utils.HEIGHT / 10)
            };
            gui.Add(buttonBlack);

            buttonBlack.Pressed += (s, e) => SwitchColor(false);

            var buttonNew = new Button("New Painting")
            {
                Position = new Vector2f(Utils.WIDTH * 21 / 25, Utils.HEIGHT * 4 / 7),
                Size = new Vector2f(Utils.WIDTH * 3 / 25, Utils.HEIGHT / 10),
                TextSize = (uint)(0.6 * Utils.HEIGHT / 10)
            };
            gui.Add(buttonNew);

            buttonNew.Pressed += (s, e) => NewPaint();

            var buttonOutput = new Button("Output Painting")
            {
                Position = new Vector2f(Utils.WIDTH * 21 / 25, Utils.HEIGHT * 5 / 7),
                Size = new Vector2f(Utils.WIDTH * 3 / 25, Utils.HEIGHT / 10),
                TextSize = (uint)(0.6 * Utils.HEIGHT / 10)
            };
            gui.Add(buttonOutput);

            buttonOutput.Pressed += (s, e) => OutputPaint();

            var buttonQuit = new Button("Exit")
            {
                Position = new Vector2f(Utils.WIDTH * 21 / 25, Utils.HEIGHT * 6 / 7),
                Size = new Vector2f(Utils.WIDTH * 3 / 25, Utils.HEIGHT / 10),
                TextSize = (uint)(0.6 * Utils.HEIGHT / 10)
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

        }

        public void NewPaint()
        {

        }

    }
}
