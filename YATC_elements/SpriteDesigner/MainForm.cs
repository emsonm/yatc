using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpriteDesigner
{
    public partial class MainForm : Form
    {
        TileUIGridManager tileManager;
        PaletteUIGridManager paletteManager;
        TileListUIGridManager tileListManager;

        byte tileList_x = 0;
        byte tileList_y = 0;
        public MainForm()
        {
            InitializeComponent();

            tileListManager = new TileListUIGridManager(tileListPanel, 50);
            tileListManager.CellClick += TileListManager_CellClick;

            tileManager = new TileUIGridManager(imagePanel, 20);
            tileManager.CellClick += Manager_UIGridClick;

            tileManager.SetTile(tileListManager.GetTile(tileList_x, tileList_y));

            paletteManager = new PaletteUIGridManager(palettePanel, 25);
            paletteManager.CellClick += PaletteManager_CellClick;
            
        }

        void TileListManager_CellClick(object sender, CellClickEventArgs e)
        {
            var tile = tileManager.GetTile();
            tileListManager.SetTile(tileList_x, tileList_y, tile);

            tileList_x = e.Affected.X;
            tileList_y = e.Affected.Y;

            tileManager.SetTile(tileListManager.GetTile(tileList_x, tileList_y));

            tileListManager.Invalidate();
        }

        void PaletteManager_CellClick(object sender, CellClickEventArgs e)
        {
            selectedColourPanel.BackColor = e.Affected.BackColor;
        }

        void Manager_UIGridClick(object sender, CellClickEventArgs e)
        {
            e.Affected.BackColor = selectedColourPanel.BackColor;
        }

        void button1_Click(object sender, EventArgs e)
        {
            var tile = tileManager.GetTile();
            var bitmap = tile.Render();
            var scaled = tile.Render(10);
            actualImage.Image = bitmap;
            previewImage.Image = scaled;
            tileString.Text = tile.ToString();
        }

        void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tileString.Text);
        }
    }
}
