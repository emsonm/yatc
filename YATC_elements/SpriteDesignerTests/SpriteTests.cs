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
            var tileString = "11111111111111111303030110B0B0B1133333311B0B0B011303030110B0B0B1133333311B0B0B011303030110B0B0B1111111111111111110202021120202011020202112020201111111111111111110B0B0B1103030311B0B0B011333333110B0B0B1103030311B0B0B011333333110B0B001103030311111111111111111";
            var map = "1111110001100011000111111";
            var list = new TileList();
            list.Add(tileString);
            var bitmap = list[1].Render(5);
            bitmap.Save("tile.bmp");

            var mapFactory = new TileMapFactory(list);
            var tileMap = mapFactory.GetTileMap(map, 5, 5);
            bitmap = tileMap.Render();
            bitmap.Save("map.bmp");
        }

        [TestMethod]
        public void RenderTest2()
        {
            var tileString1 = "11111111111111111303030110B0B0B1133333311B0B0B011303030110B0B0B1133333311B0B0B011303030110B0B0B1111111111111111110202021120202011020202112020201111111111111111110B0B0B1103030311B0B0B011333333110B0B0B1103030311B0B0B011333333110B0B001103030311111111111111111";
            var tileString2 = "22222222222222222303030220B0B0B2233333322B0B0B022303030220B0B0B2233333322B0B0B022303030220B0B0B2222222222222222220202022220202022020202222020202222222222222222220B0B0B2203030322B0B0B011333333110B0B0B2203030322B0B0B022333333220B0B002203030322222222222222222";
            var map = "1111110002200022000111111";
            var list = new TileList();
            list.Add(tileString1);
            list.Add(tileString2);
            var bitmap = list[1].Render(5);
            bitmap.Save("tile1.bmp");
            bitmap = list[2].Render(10);
            bitmap.Save("tile2.bmp");

            var mapFactory = new TileMapFactory(list);
            var tileMap = mapFactory.GetTileMap(map, 5, 5);
            bitmap = tileMap.Render();
            bitmap.Save("map2.bmp");

            bitmap = tileMap.Render(5);
            bitmap.Save("map2_5.bmp");
        }
    }
}