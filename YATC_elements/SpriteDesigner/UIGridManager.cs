﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpriteDesigner
{
    /// <summary>
    /// EventArgs for the custom grid click event.
    /// </summary>
    public class UIGridClickEventArgs : EventArgs
    {
        public CellPanel Affected { get; set; }
    }

    /// <summary>
    /// Event to handle custom grid clicks
    /// </summary>
    public delegate void CellEventHandler(object sender, UIGridClickEventArgs e);

    /// <summary>
    /// Simple class to create a grid in UI with basic "click" functionality.
    /// </summary>
    public class UiGridManager
    {
        protected CellPanel[,] pixels;
        public byte Width { get; private set; }
        public byte Height { get; private set; }

        public byte PixelWidth { get; private set; }

        public Control Target { get; private set; }

        public event CellEventHandler CellClick;

        public UiGridManager(Control target, byte pixelWidth = 15, byte width = 8, byte height = 8)
        {
            Width = width;
            Height = height;
            Target = target;
            PixelWidth = pixelWidth;

            Init();
        }

        void MakePixel(byte x, byte y, byte w)
        {
            var pixel = new CellPanel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(x * w, y * w),
                Size = new Size(w, w),
                BackColor = Color.Empty,
                TabIndex = 0,
                X = x,
                Y = y
            };

            pixel.Click += (s, e) =>
            {
                CellClick?.Invoke(e, new UIGridClickEventArgs { Affected = pixel });
            };

            pixels[x, y] = pixel;

            Target.Controls.Add(pixel);
        }

        void Init()
        {
            //create a grid
            pixels = new CellPanel[Width, Height];
            for (byte x = 0; x < Width; x++)
            {
                for (byte y = 0; y < Height; y++)
                {
                    MakePixel(x, y, PixelWidth);
                }
            }
        }
    }

    public class TileUIGridManager : UiGridManager
    {
        public TileUIGridManager(Control target, byte pixelWidth = 15) : base(target, pixelWidth, Tile.TileWidth, Tile.TileHeight)
        {
        }

        public Tile GetTile()
        {
            var result = new Tile();

            for (byte x = 0; x < Width; x++)
                for (byte y = 0; y < Height; y++)
                {
                    result.Set(x, y, PaletteUtility.GetPalette(pixels[x, y].BackColor));
                }

            return result;
        }
    }


    public class PaletteUIGridManager : UiGridManager
    {
        public PaletteUIGridManager(Control target, byte pixelWidth = 15) : base(target, pixelWidth, 2, 8)
        {
            Init();
        }

        void Init()
        {
            byte c = 0;
            //set the colours
            for (byte x = 0; x < Width; x++)
            {
                for (byte y = 0; y < Height; y++)
                {
                    pixels[x, y].BackColor = PaletteUtility.GetColor((Palette)(c++));
                }
            }

            var p = pixels[0, 0];
            p.ForeColor = Color.Red;
            p.Paint += (s, e) =>
            {
                e.Graphics.DrawLine(Pens.Red, 0, 0, p.Width, p.Height);
                e.Graphics.DrawLine(Pens.Red, p.Width - 2, 0, 0, p.Height -2);
            };
        }
    }

    /// <summary>
    /// Simple panel subclass to add in some extra properties
    /// </summary>
    public class CellPanel : Panel
    {
        public byte X { get; internal set; }
        public byte Y { get; internal set; }
    }
}