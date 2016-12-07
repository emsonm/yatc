using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpriteDesigner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpriteDesigner.Tests
{
    [TestClass]
    public class SpriteTests
    {
        [TestMethod]
        public void SpriteTest()
        {
            var sprite = new Sprite(8, 8);

            sprite.Set(5, 5);
            Assert.IsTrue(sprite.Data[5, 5] == (byte)Palette.Black, "Colour was not set");

            sprite.Set(6, 6);
            Assert.IsTrue(sprite.Get(6, 6) == Palette.Black, "Colour was not set");

            sprite.Set(7, 7, Palette.Red);
            Assert.IsTrue(sprite.Get(7, 7) != Palette.Black, "Colour was set to black instead of red");
            Assert.IsTrue(sprite.Get(7, 7) == Palette.Red, "Colour was not set");
        }

        [TestMethod]
        public void SpriteTestString()
        {
            var s = new Sprite(4, 4);
            s.Set(0, 0); s.Set(3, 0);
            s.Set(1, 1); s.Set(2, 1);
            s.Set(2, 2); s.Set(1, 2);
            s.Set(3, 3); s.Set(0, 3);

            var s2 = new Sprite(4, 4);
            s2.FromString(s.ToString());

            for (byte x = 0; x < 4; x++)
                for (byte y = 0; y < 4; y++)
                    Assert.AreEqual(s.Get(x, y), s2.Get(x, y));
        }

        [TestMethod]
        public void RenderTest()
        {
            var tileString = "1111111111000011101001011001100110011001101001011100001111111111";
            var map = "1111110001100011000111111";
            var list = new TileList();
            list.Add(tileString);
            var mapFactory = new TileMapFactory(list);
            var tileMap = mapFactory.GetTileMap(map, 5, 5);
            var bitmap = tileMap.Render();
            bitmap.Save("test.bmp");
        }           
    }
}