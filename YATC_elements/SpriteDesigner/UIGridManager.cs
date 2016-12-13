using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpriteDesigner
{
    /// <summary>
    /// EventArgs for the custom grid click event.
    /// </summary>
    public class CellClickEventArgs : EventArgs
    {
        public CellPanel Affected { get; set; }
    }

    /// <summary>
    /// Event to handle custom grid clicks
    /// </summary>
    public delegate void CellEventHandler(object sender, CellClickEventArgs e);

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
                CellClick?.Invoke(e, new CellClickEventArgs { Affected = pixel });
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
                    var index = (y * Width) + x;
                    MakePixel(x, y, PixelWidth);
                }
            }
        }
    }

    /// <summary>
    /// Manages the tile data being edited
    /// </summary>
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

        public void SetTile(Tile value)
        {
            for (byte x = 0; x < Width; x++)
                for (byte y = 0; y < Height; y++)
                {
                    pixels[x, y].BackColor = PaletteUtility.GetColor((Palette)value.Data[x, y]);
                }
        }
    }

    /// <summary>
    /// Manages the palette UI being displayed
    /// </summary>
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
                e.Graphics.DrawLine(Pens.Red, p.Width - 2, 0, 0, p.Height - 2);
            };
        }
    }

    public class TileListUIGridManager : UiGridManager
    {
        TileList tiles;
        byte selectedIndex = 0;

        public TileListUIGridManager(Control target, byte pixelWidth = 25) : base(target, pixelWidth, 5, 2)
        {
            tiles = new TileList();
            //pre-populate the list with the number of tiles we defined slots for
            byte x = 0;
            byte y = 0;
            for (byte i = 0; i < (Height * Width); i++)
            {
                var tile = new Tile();

                var pixel = pixels[x, y];
                var scale = 3f;

                pixel.Paint += (s, e) =>
                {
                    var panel = (CellPanel)s;

                    var ptile = GetTile(panel.X, panel.Y, false);

                    for (var ix = 0; ix < ptile.Width; ix++)
                    {
                        for (var iy = 0; iy < ptile.Height; iy++)
                        {
                            var brush = new SolidBrush(PaletteUtility.GetColour(ptile.Data[ix, iy]));

                            e.Graphics.FillRectangle(brush, (ix * scale), (iy * scale), scale, scale);
                        }
                    }

                    var index = (panel.Y * Width) + panel.X;
                    if ((byte)index == selectedIndex)
                    {
                        e.Graphics.DrawRectangle(Pens.Red, 1, 1, pixelWidth - 5, pixelWidth - 5);
                    }
                };

                tiles.Add(tile);

                x++;
                if (x == Width)
                {
                    x = 0;
                    y++;
                }
            }
        }

        public void Invalidate()
        {
            foreach (var pixel in pixels)
            {
                pixel.Invalidate();
            }
        }

        public Tile GetTile(byte x, byte y, bool setIndex = true)
        {
            var index = (Width * y) + x;
            return GetTile((byte)(index + 1), setIndex);
        }

        Tile GetTile(byte index, bool setIndex = true)
        {
            if (setIndex) selectedIndex = (byte)(index - 1);
            return tiles[index];
        }

        public void SetTile(byte x, byte y, Tile value)
        {
            var index = ((Width * y) + x) + 1;
            SetTile((byte)index, value);
        }

        void SetTile(byte index, Tile value)
        {
            tiles[index] = value;
        }

        public Tile GetSelectedTile()
        {
            return tiles[selectedIndex];
        }

        public byte SelectedIndex
        {
            get { return selectedIndex; }
        }
    }

    /// <summary>
    /// Simple panel subclass to add in some extra properties
    /// </summary>
    public class CellPanel : Panel
    {
        public byte X { get; internal set; }
        public byte Y { get; internal set; }

        public byte Index { get; internal set; }
    }
}
