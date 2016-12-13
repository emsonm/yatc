namespace SpriteDesigner
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spriteEditorPanel = new System.Windows.Forms.Panel();
            this.copyButton = new System.Windows.Forms.Button();
            this.tileString = new System.Windows.Forms.TextBox();
            this.palettePanel = new System.Windows.Forms.Panel();
            this.selectedColourPanel = new System.Windows.Forms.Panel();
            this.previewImage = new System.Windows.Forms.PictureBox();
            this.actualImage = new System.Windows.Forms.PictureBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.tileListPanel = new System.Windows.Forms.Panel();
            this.exportButton = new System.Windows.Forms.Button();
            this.spriteEditorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualImage)).BeginInit();
            this.SuspendLayout();
            // 
            // spriteEditorPanel
            // 
            this.spriteEditorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spriteEditorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spriteEditorPanel.Controls.Add(this.copyButton);
            this.spriteEditorPanel.Controls.Add(this.tileString);
            this.spriteEditorPanel.Controls.Add(this.palettePanel);
            this.spriteEditorPanel.Controls.Add(this.selectedColourPanel);
            this.spriteEditorPanel.Controls.Add(this.previewImage);
            this.spriteEditorPanel.Controls.Add(this.actualImage);
            this.spriteEditorPanel.Controls.Add(this.updateButton);
            this.spriteEditorPanel.Controls.Add(this.imagePanel);
            this.spriteEditorPanel.Location = new System.Drawing.Point(5, 5);
            this.spriteEditorPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.spriteEditorPanel.Name = "spriteEditorPanel";
            this.spriteEditorPanel.Size = new System.Drawing.Size(653, 338);
            this.spriteEditorPanel.TabIndex = 0;
            // 
            // copyButton
            // 
            this.copyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copyButton.Location = new System.Drawing.Point(428, 279);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(53, 29);
            this.copyButton.TabIndex = 23;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // tileString
            // 
            this.tileString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tileString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileString.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileString.Location = new System.Drawing.Point(496, 195);
            this.tileString.Multiline = true;
            this.tileString.Name = "tileString";
            this.tileString.ReadOnly = true;
            this.tileString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tileString.Size = new System.Drawing.Size(152, 137);
            this.tileString.TabIndex = 22;
            this.tileString.WordWrap = false;
            // 
            // palettePanel
            // 
            this.palettePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.palettePanel.Location = new System.Drawing.Point(388, 40);
            this.palettePanel.Name = "palettePanel";
            this.palettePanel.Size = new System.Drawing.Size(93, 237);
            this.palettePanel.TabIndex = 21;
            // 
            // selectedColourPanel
            // 
            this.selectedColourPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedColourPanel.BackColor = System.Drawing.Color.Black;
            this.selectedColourPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedColourPanel.Location = new System.Drawing.Point(388, 7);
            this.selectedColourPanel.Name = "selectedColourPanel";
            this.selectedColourPanel.Size = new System.Drawing.Size(25, 25);
            this.selectedColourPanel.TabIndex = 20;
            // 
            // previewImage
            // 
            this.previewImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.previewImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewImage.Location = new System.Drawing.Point(496, 40);
            this.previewImage.Name = "previewImage";
            this.previewImage.Size = new System.Drawing.Size(150, 150);
            this.previewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewImage.TabIndex = 19;
            this.previewImage.TabStop = false;
            // 
            // actualImage
            // 
            this.actualImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.actualImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.actualImage.Location = new System.Drawing.Point(577, 6);
            this.actualImage.Name = "actualImage";
            this.actualImage.Size = new System.Drawing.Size(30, 30);
            this.actualImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.actualImage.TabIndex = 18;
            this.actualImage.TabStop = false;
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateButton.Location = new System.Drawing.Point(496, 6);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 28);
            this.updateButton.TabIndex = 16;
            this.updateButton.Text = "Preview";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // imagePanel
            // 
            this.imagePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imagePanel.Location = new System.Drawing.Point(25, 4);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(338, 323);
            this.imagePanel.TabIndex = 17;
            // 
            // tileListPanel
            // 
            this.tileListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tileListPanel.Location = new System.Drawing.Point(3, 349);
            this.tileListPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tileListPanel.Name = "tileListPanel";
            this.tileListPanel.Size = new System.Drawing.Size(608, 160);
            this.tileListPanel.TabIndex = 1;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Location = new System.Drawing.Point(614, 361);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(45, 29);
            this.exportButton.TabIndex = 24;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 512);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.tileListPanel);
            this.Controls.Add(this.spriteEditorPanel);
            this.MinimumSize = new System.Drawing.Size(680, 550);
            this.Name = "MainForm";
            this.Text = "Sprite Designer";
            this.spriteEditorPanel.ResumeLayout(false);
            this.spriteEditorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel spriteEditorPanel;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.TextBox tileString;
        private System.Windows.Forms.Panel palettePanel;
        private System.Windows.Forms.Panel selectedColourPanel;
        private System.Windows.Forms.PictureBox previewImage;
        private System.Windows.Forms.PictureBox actualImage;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.Panel tileListPanel;
        private System.Windows.Forms.Button exportButton;
    }
}

