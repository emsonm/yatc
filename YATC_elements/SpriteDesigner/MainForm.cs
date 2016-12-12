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


        public MainForm()
        {
            InitializeComponent();

            tileManager = new TileUIGridManager(imagePanel, 20);
            tileManager.CellClick += Manager_UIGridClick;

            paletteManager = new PaletteUIGridManager(palettePanel, 25);
            paletteManager.CellClick += PaletteManager_CellClick;

            tileListManager = new TileListUIGridManager(tileListPanel);
            tileListManager.CellClick += TileListManager_CellClick;
            
        }

        private void TileListManager_CellClick(object sender, CellClickEventArgs e)
        {
            var tile = tileManager.GetTile();

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
