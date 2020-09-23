namespace sseadv
{
    partial class sse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sse));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pickFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticallyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pickFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thisSpriteCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thisFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thisAnimationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allSpriteCollectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allAnimationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveThisSpriteCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spriteCollectionsList = new System.Windows.Forms.ListBox();
            this.spritesLabel = new System.Windows.Forms.Label();
            this.framesLabel = new System.Windows.Forms.Label();
            this.framesList = new System.Windows.Forms.ListBox();
            this.frameSlider = new System.Windows.Forms.TrackBar();
            this.frameInfo = new System.Windows.Forms.Label();
            this.playFrames = new System.Windows.Forms.Button();
            this.animationsList = new System.Windows.Forms.ListBox();
            this.animationsLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(796, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oneToolStripMenuItem,
            this.allToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.openToolStripMenuItem.Text = "open";
            // 
            // oneToolStripMenuItem
            // 
            this.oneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automaticallyToolStripMenuItem,
            this.pickFileToolStripMenuItem});
            this.oneToolStripMenuItem.Name = "oneToolStripMenuItem";
            this.oneToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.oneToolStripMenuItem.Text = "one file";
            // 
            // automaticallyToolStripMenuItem
            // 
            this.automaticallyToolStripMenuItem.Name = "automaticallyToolStripMenuItem";
            this.automaticallyToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.automaticallyToolStripMenuItem.Text = "automatically";
            this.automaticallyToolStripMenuItem.Click += new System.EventHandler(this.automaticallyToolStripMenuItem_Click);
            // 
            // pickFileToolStripMenuItem
            // 
            this.pickFileToolStripMenuItem.Name = "pickFileToolStripMenuItem";
            this.pickFileToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.pickFileToolStripMenuItem.Text = "pick file";
            this.pickFileToolStripMenuItem.Click += new System.EventHandler(this.pickFileToolStripMenuItem_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automaticallyAllToolStripMenuItem,
            this.pickFolderToolStripMenuItem});
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.allToolStripMenuItem.Text = "all files";
            // 
            // automaticallyAllToolStripMenuItem
            // 
            this.automaticallyAllToolStripMenuItem.Name = "automaticallyAllToolStripMenuItem";
            this.automaticallyAllToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.automaticallyAllToolStripMenuItem.Text = "automatically";
            // 
            // pickFolderToolStripMenuItem
            // 
            this.pickFolderToolStripMenuItem.Name = "pickFolderToolStripMenuItem";
            this.pickFolderToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.pickFolderToolStripMenuItem.Text = "pick folder";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thisToolStripMenuItem,
            this.allToolStripMenuItem1});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.saveToolStripMenuItem.Text = "save";
            // 
            // thisToolStripMenuItem
            // 
            this.thisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thisSpriteCollectionToolStripMenuItem,
            this.thisFrameToolStripMenuItem,
            this.thisAnimationToolStripMenuItem});
            this.thisToolStripMenuItem.Name = "thisToolStripMenuItem";
            this.thisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.thisToolStripMenuItem.Text = "this";
            // 
            // thisSpriteCollectionToolStripMenuItem
            // 
            this.thisSpriteCollectionToolStripMenuItem.Name = "thisSpriteCollectionToolStripMenuItem";
            this.thisSpriteCollectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.thisSpriteCollectionToolStripMenuItem.Text = "sprite collection";
            this.thisSpriteCollectionToolStripMenuItem.Click += new System.EventHandler(this.thisSpriteCollectionToolStripMenuItem_Click);
            // 
            // thisFrameToolStripMenuItem
            // 
            this.thisFrameToolStripMenuItem.Name = "thisFrameToolStripMenuItem";
            this.thisFrameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.thisFrameToolStripMenuItem.Text = "frame";
            this.thisFrameToolStripMenuItem.Click += new System.EventHandler(this.thisFrameToolStripMenuItem_Click);
            // 
            // thisAnimationToolStripMenuItem
            // 
            this.thisAnimationToolStripMenuItem.Name = "thisAnimationToolStripMenuItem";
            this.thisAnimationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.thisAnimationToolStripMenuItem.Text = "animation";
            this.thisAnimationToolStripMenuItem.Click += new System.EventHandler(this.thisAnimationToolStripMenuItem_Click);
            // 
            // allToolStripMenuItem1
            // 
            this.allToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allSpriteCollectionsToolStripMenuItem,
            this.allFramesToolStripMenuItem,
            this.allAnimationsToolStripMenuItem});
            this.allToolStripMenuItem1.Name = "allToolStripMenuItem1";
            this.allToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.allToolStripMenuItem1.Text = "all";
            // 
            // allSpriteCollectionsToolStripMenuItem
            // 
            this.allSpriteCollectionsToolStripMenuItem.Name = "allSpriteCollectionsToolStripMenuItem";
            this.allSpriteCollectionsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.allSpriteCollectionsToolStripMenuItem.Text = "sprite collections";
            // 
            // allFramesToolStripMenuItem
            // 
            this.allFramesToolStripMenuItem.Name = "allFramesToolStripMenuItem";
            this.allFramesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.allFramesToolStripMenuItem.Text = "frames";
            // 
            // allAnimationsToolStripMenuItem
            // 
            this.allAnimationsToolStripMenuItem.Name = "allAnimationsToolStripMenuItem";
            this.allAnimationsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.allAnimationsToolStripMenuItem.Text = "animations";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thisToolStripMenuItem1});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "edit";
            // 
            // thisToolStripMenuItem1
            // 
            this.thisToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveThisSpriteCollectionToolStripMenuItem});
            this.thisToolStripMenuItem1.Name = "thisToolStripMenuItem1";
            this.thisToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.thisToolStripMenuItem1.Text = "this";
            // 
            // saveThisSpriteCollectionToolStripMenuItem
            // 
            this.saveThisSpriteCollectionToolStripMenuItem.Name = "saveThisSpriteCollectionToolStripMenuItem";
            this.saveThisSpriteCollectionToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.saveThisSpriteCollectionToolStripMenuItem.Text = "sprite collection";
            this.saveThisSpriteCollectionToolStripMenuItem.Click += new System.EventHandler(this.saveThisSpriteCollectionToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.aboutToolStripMenuItem.Text = "about";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // spriteCollectionsList
            // 
            this.spriteCollectionsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.spriteCollectionsList.FormattingEnabled = true;
            this.spriteCollectionsList.IntegralHeight = false;
            this.spriteCollectionsList.Location = new System.Drawing.Point(12, 53);
            this.spriteCollectionsList.Name = "spriteCollectionsList";
            this.spriteCollectionsList.Size = new System.Drawing.Size(250, 600);
            this.spriteCollectionsList.TabIndex = 2;
            this.spriteCollectionsList.SelectedIndexChanged += new System.EventHandler(this.spriteCollectionsList_SelectedIndexChanged);
            // 
            // spritesLabel
            // 
            this.spritesLabel.Location = new System.Drawing.Point(12, 27);
            this.spritesLabel.Name = "spritesLabel";
            this.spritesLabel.Size = new System.Drawing.Size(250, 23);
            this.spritesLabel.TabIndex = 4;
            this.spritesLabel.Text = "sprite collections";
            // 
            // framesLabel
            // 
            this.framesLabel.Location = new System.Drawing.Point(272, 27);
            this.framesLabel.Name = "framesLabel";
            this.framesLabel.Size = new System.Drawing.Size(250, 23);
            this.framesLabel.TabIndex = 5;
            this.framesLabel.Text = "frames";
            // 
            // framesList
            // 
            this.framesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.framesList.FormattingEnabled = true;
            this.framesList.IntegralHeight = false;
            this.framesList.Location = new System.Drawing.Point(272, 53);
            this.framesList.Name = "framesList";
            this.framesList.Size = new System.Drawing.Size(250, 600);
            this.framesList.TabIndex = 6;
            this.framesList.SelectedIndexChanged += new System.EventHandler(this.framesList_SelectedIndexChanged);
            // 
            // frameSlider
            // 
            this.frameSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.frameSlider.Enabled = false;
            this.frameSlider.Location = new System.Drawing.Point(528, 584);
            this.frameSlider.Name = "frameSlider";
            this.frameSlider.Size = new System.Drawing.Size(256, 45);
            this.frameSlider.TabIndex = 7;
            this.frameSlider.ValueChanged += new System.EventHandler(this.frameSlider_ValueChanged);
            // 
            // frameInfo
            // 
            this.frameInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.frameInfo.Location = new System.Drawing.Point(528, 632);
            this.frameInfo.Name = "frameInfo";
            this.frameInfo.Size = new System.Drawing.Size(256, 21);
            this.frameInfo.TabIndex = 8;
            this.frameInfo.Text = "nothing playing";
            // 
            // playFrames
            // 
            this.playFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playFrames.Location = new System.Drawing.Point(528, 555);
            this.playFrames.Name = "playFrames";
            this.playFrames.Size = new System.Drawing.Size(256, 23);
            this.playFrames.TabIndex = 9;
            this.playFrames.Text = "play animation";
            this.playFrames.UseVisualStyleBackColor = true;
            this.playFrames.Click += new System.EventHandler(this.playFrames_Click);
            // 
            // animationsList
            // 
            this.animationsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationsList.FormattingEnabled = true;
            this.animationsList.IntegralHeight = false;
            this.animationsList.Location = new System.Drawing.Point(528, 338);
            this.animationsList.Name = "animationsList";
            this.animationsList.Size = new System.Drawing.Size(256, 211);
            this.animationsList.TabIndex = 10;
            this.animationsList.SelectedIndexChanged += new System.EventHandler(this.animationsList_SelectedIndexChanged);
            // 
            // animationsLabel
            // 
            this.animationsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.animationsLabel.Location = new System.Drawing.Point(528, 312);
            this.animationsLabel.Name = "animationsLabel";
            this.animationsLabel.Size = new System.Drawing.Size(256, 23);
            this.animationsLabel.TabIndex = 5;
            this.animationsLabel.Text = "animations";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(528, 53);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(256, 256);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 11;
            this.pictureBox.TabStop = false;
            // 
            // sse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(796, 665);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.animationsList);
            this.Controls.Add(this.playFrames);
            this.Controls.Add(this.frameInfo);
            this.Controls.Add(this.frameSlider);
            this.Controls.Add(this.framesList);
            this.Controls.Add(this.animationsLabel);
            this.Controls.Add(this.framesLabel);
            this.Controls.Add(this.spritesLabel);
            this.Controls.Add(this.spriteCollectionsList);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "sse";
            this.Text = "super-sprite-extractor advanced tk2d edition";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automaticallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pickFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automaticallyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pickFolderToolStripMenuItem;
        private System.Windows.Forms.ListBox spriteCollectionsList;
        private System.Windows.Forms.Label spritesLabel;
        private System.Windows.Forms.Label framesLabel;
        private System.Windows.Forms.ListBox framesList;
        private System.Windows.Forms.TrackBar frameSlider;
        private System.Windows.Forms.Label frameInfo;
        private System.Windows.Forms.Button playFrames;
        private System.Windows.Forms.ListBox animationsList;
        private System.Windows.Forms.Label animationsLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripMenuItem thisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thisSpriteCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thisFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thisAnimationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allSpriteCollectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allFramesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allAnimationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thisToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveThisSpriteCollectionToolStripMenuItem;
    }
}

