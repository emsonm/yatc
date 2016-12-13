using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpriteDesigner
{
    public enum Palette : byte { Nothing = 0, Black = 1, Blue = 2, Red = 3, Magenta = 4, Green = 5, Cyan = 6, Yellow = 7, White = 8, Grey = 9, LightBlue = 10, LightRed = 11, Pink = 12, LightGreen = 13, Orange = 14, Brown = 15 }


    public class PaletteUtility
    {
        public static Color GetColour(byte colour)
        {
            return GetColor((Palette)colour);
        }

        public static Palette GetPalette(Color colour)
        {
            if (colour == Color.Black) return Palette.Black;
            if (colour == Color.Blue) return Palette.Blue;
            if (colour == Color.Brown) return Palette.Brown;
            if (colour == Color.Cyan) return Palette.Cyan;
            if (colour == Color.Green) return Palette.Green;
            if (colour == Color.Gray) return Palette.Grey;
            if (colour == Color.LightBlue) return Palette.LightBlue;
            if (colour == Color.LightGreen) return Palette.LightGreen;
            if (colour == Color.OrangeRed) return Palette.LightRed;
            if (colour == Color.Magenta) return Palette.Magenta;
            if (colour == Color.Orange) return Palette.Orange;
            if (colour == Color.LightPink) return Palette.Pink;
            if (colour == Color.Red) return Palette.Red;
            if (colour == Color.White) return Palette.White;
            if (colour == Color.Yellow) return Palette.Yellow;
            return Palette.Nothing;
        }

        public static Color GetColor(Palette colour)
        {
            switch (colour)
            {
                case Palette.Black:
                    return Color.Black;
                case Palette.Blue:
                    return Color.Blue;
                case Palette.Brown:
                    return Color.Brown;
                case Palette.Cyan:
                    return Color.Cyan;
                case Palette.Green:
                    return Color.Green;
                case Palette.Grey:
                    return Color.Gray;
                case Palette.LightBlue:
                    return Color.LightBlue;
                case Palette.LightGreen:
                    return Color.LightGreen;
                case Palette.LightRed:
                    return Color.OrangeRed;
                case Palette.Magenta:
                    return Color.Magenta;
                case Palette.Orange:
                    return Color.Orange;
                case Palette.Pink:
                    return Color.LightPink;
                case Palette.Red:
                    return Color.Red;
                case Palette.White:
                    return Color.White;
                case Palette.Yellow:
                    return Color.Yellow;
                default:
                    return Color.Empty;
            }
        }
    }

    /// <summary>
    /// Basic graphic class - implements the common functionality we want to re-use
    /// </summary>
    public class Sprite
    {
        public byte Width { get; private set; }
        public byte Height { get; private set; }

        public Sprite(byte width, byte height)
        {
            Width = width;
            Height = height;

            Data = new byte[width, height];
        }

        public byte[,] Data { get; private set; }

        public void Set(byte x, byte y, Palette value = Palette.Black)
        {
            Data[x, y] = (byte)value;
        }

        public Palette Get(byte x, byte y)
        {
            return (Palette)Data[x, y];
        }

        public void Unset(byte x, byte y)
        {
            Data[x, y] = 0;
        }

        public void FromString(string data)
        {
            var x = 0;
            var y = 0;
            foreach (var ch in data)
            {
                if (ch == '\r' || ch == '\n')
                    continue;

                var b = byte.Parse(ch.ToString(), System.Globalization.NumberStyles.HexNumber);

                Data[y, x] = b;

                x++;
                if (x == Width)
                {
                    x = 0;
                    y++;
                }
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                    result.Append(Data[y, x].ToString("X"));
                result.AppendLine(string.Empty);
            }

            return result.ToString();
        }

        public byte Flag { get; set; }
        public byte Id { get; set; }
    }

    public class Tile : Sprite
    {
        public readonly static byte TileWidth = 16;
        public readonly static byte TileHeight = 16;

        public Tile() : base(TileWidth, TileHeight)
        {

        }

        public Bitmap Render(byte scale = 1)
        {

            var result = scale <= 1 ? new Bitmap(Width, Height) : new Bitmap(Width * scale, Height * scale);

            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    if (scale <= 1)
                    {
                        result.SetPixel(x, y, PaletteUtility.GetColour(Data[x, y]));
                    }
                    else
                    {
                        using (var g = Graphics.FromImage(result))
                        {
                            var brush = new SolidBrush(PaletteUtility.GetColour(Data[x, y]));

                            g.FillRectangle(brush, (x * scale), (y * scale), scale, scale);
                        }
                    }
                }
            }

            return result;
        }
    }

    public class TileList
    {
        List<Tile> tiles;
        public TileList()
        {
            tiles = new List<Tile>();
        }

        public Tile this[byte index]
        {
            get
            {
                if (index <= 0 || index > tiles.Count)
                    return null;

                return tiles[index - 1];
            }
            set
            {
                if (index > 0 || index <= tiles.Count)
                {
                    tiles[index - 1] = value;
                }
            }
        }

        public byte Add(Tile value)
        {
            tiles.Add(value);
            value.Id = (byte)tiles.Count;
            return value.Id;
        }

        public byte Add(string value)
        {
            var tile = new Tile();
            tile.FromString(value);
            return Add(tile);
        }
    }

    public class TileMap
    {
        public byte Width { get; private set; }
        public byte Height { get; private set; }

        public Tile[,] Data { get; private set; }

        public TileMap() : this(160, 160)
        {

        }

        public TileMap(byte width, byte height)
        {
            Width = width;
            Height = height;

            Data = new Tile[width, height];
        }

        public void Set(byte x, byte y, Tile value)
        {
            if (value.Id == 0) throw new Exception("Id must be set"); //TODO: make this more generic
            Data[x, y] = value;
        }

        public Tile Get(byte x, byte y)
        {
            return Data[x, y];
        }

        public void Unset(byte x, byte y)
        {
            Data[x, y] = null;
        }

        public bool FlagTest(byte x, byte y, byte flag)
        {
            return Data[x, y] != null ? Data[x, y].Flag == flag : false;
        }

        public Bitmap Render()
        {
            var result = new Bitmap(Width * Tile.TileWidth, Height * Tile.TileHeight);
            result.MakeTransparent(Color.Empty);

            using (var g = Graphics.FromImage(result))
            {
                for (var x = 0; x < Width; x++)
                {
                    for (var y = 0; y < Height; y++)
                    {
                        var data = Data[x, y];
                        if (data != null)
                        {
                            var tile = data.Render();
                            if (tile != null)
                            {
                                g.DrawImage(tile, x * Tile.TileWidth, y * Tile.TileHeight);
                            }
                        }
                    }
                }
            }

            return result;
        }
    }

    public class TileMapFactory
    {
        public TileList List { get; private set; }

        public TileMapFactory(TileList list)
        {
            List = list;
        }

        public TileMap GetTileMap(string data, byte width, byte height)
        {
            var result = new TileMap(width, height);

            byte x = 0;
            byte y = 0;
            foreach (var ch in data)
            {
                if (ch == '\r' || ch == '\n')
                    continue;

                var b = byte.Parse(ch.ToString());

                if (b > 0)
                {
                    var tile = List[b];
                    if (tile != null)
                    {
                        result.Set(x, y, tile);
                    }
                }

                x++;
                if (x == width)
                {
                    x = 0;
                    y++;
                }
            }

            return result;
        }
    }
}
