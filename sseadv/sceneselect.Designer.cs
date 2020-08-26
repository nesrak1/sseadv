namespace sseadv
{
    partial class sceneselect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sceneselect));
            this.sceneList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // sceneList
            // 
            this.sceneList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sceneList.FormattingEnabled = true;
            this.sceneList.IntegralHeight = false;
            this.sceneList.Location = new System.Drawing.Point(0, 0);
            this.sceneList.Name = "sceneList";
            this.sceneList.Size = new System.Drawing.Size(287, 523);
            this.sceneList.TabIndex = 0;
            this.sceneList.DoubleClick += new System.EventHandler(this.sceneList_DoubleClick);
            // 
            // sceneselect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 523);
            this.Controls.Add(this.sceneList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "sceneselect";
            this.Text = "scene-select";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox sceneList;
    }
}