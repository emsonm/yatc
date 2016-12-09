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
            this.imagePanel = new System.Windows.Forms.Panel();
            this.updateButton = new System.Windows.Forms.Button();
            this.actualImage = new System.Windows.Forms.PictureBox();
            this.previewImage = new System.Windows.Forms.PictureBox();
            this.selectedColourPanel = new System.Windows.Forms.Panel();
            this.palettePanel = new System.Windows.Forms.Panel();
            this.tileString = new System.Windows.Forms.TextBox();
            this.copyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.actualImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).BeginInit();
            this.SuspendLayout();
            // 
            // imagePanel
            // 
            this.imagePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imagePanel.Location = new System.Drawing.Point(12, 12);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(338, 323);
            this.imagePanel.TabIndex = 0;
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateButton.Location = new System.Drawing.Point(464, 12);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 28);
            this.updateButton.TabIndex = 0;
            this.updateButton.Text = "Preview";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // actualImage
            // 
            this.actualImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.actualImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.actualImage.Location = new System.Drawing.Point(545, 12);
            this.actualImage.Name = "actualImage";
            this.actualImage.Size = new System.Drawing.Size(30, 30);
            this.actualImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.actualImage.TabIndex = 1;
            this.actualImage.TabStop = false;
            // 
            // previewImage
            // 
            this.previewImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.previewImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewImage.Location = new System.Drawing.Point(464, 46);
            this.previewImage.Name = "previewImage";
            this.previewImage.Size = new System.Drawing.Size(150, 150);
            this.previewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewImage.TabIndex = 2;
            this.previewImage.TabStop = false;
            // 
            // selectedColourPanel
            // 
            this.selectedColourPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedColourPanel.BackColor = System.Drawing.Color.Black;
            this.selectedColourPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedColourPanel.Location = new System.Drawing.Point(356, 13);
            this.selectedColourPanel.Name = "selectedColourPanel";
            this.selectedColourPanel.Size = new System.Drawing.Size(25, 25);
            this.selectedColourPanel.TabIndex = 3;
            // 
            // palettePanel
            // 
            this.palettePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.palettePanel.Location = new System.Drawing.Point(356, 46);
            this.palettePanel.Name = "palettePanel";
            this.palettePanel.Size = new System.Drawing.Size(93, 237);
            this.palettePanel.TabIndex = 5;
            // 
            // tileString
            // 
            this.tileString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tileString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tileString.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileString.Location = new System.Drawing.Point(464, 201);
            this.tileString.Multiline = true;
            this.tileString.Name = "tileString";
            this.tileString.ReadOnly = true;
            this.tileString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tileString.Size = new System.Drawing.Size(152, 141);
            this.tileString.TabIndex = 6;
            this.tileString.WordWrap = false;
            // 
            // copyButton
            // 
            this.copyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copyButton.Location = new System.Drawing.Point(396, 289);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(53, 29);
            this.copyButton.TabIndex = 7;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 347);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.tileString);
            this.Controls.Add(this.palettePanel);
            this.Controls.Add(this.selectedColourPanel);
            this.Controls.Add(this.previewImage);
            this.Controls.Add(this.actualImage);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.imagePanel);
            this.MinimumSize = new System.Drawing.Size(640, 385);
            this.Name = "MainForm";
            this.Text = "Sprite Designer";
            ((System.ComponentModel.ISupportInitialize)(this.actualImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.PictureBox actualImage;
        private System.Windows.Forms.PictureBox previewImage;
        private System.Windows.Forms.Panel selectedColourPanel;
        private System.Windows.Forms.Panel palettePanel;
        private System.Windows.Forms.TextBox tileString;
        private System.Windows.Forms.Button copyButton;
    }
}

