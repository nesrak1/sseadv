namespace sseadv
{
    partial class exportoptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(exportoptions));
            this.exportingHeader = new System.Windows.Forms.Label();
            this.enableBordersChk = new System.Windows.Forms.CheckBox();
            this.consistentSizeChk = new System.Windows.Forms.CheckBox();
            this.spriteNameChk = new System.Windows.Forms.CheckBox();
            this.exportBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exportingHeader
            // 
            this.exportingHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportingHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportingHeader.Location = new System.Drawing.Point(12, 9);
            this.exportingHeader.Name = "exportingHeader";
            this.exportingHeader.Size = new System.Drawing.Size(248, 30);
            this.exportingHeader.TabIndex = 0;
            this.exportingHeader.Text = "exporting ...";
            // 
            // enableBordersChk
            // 
            this.enableBordersChk.AutoSize = true;
            this.enableBordersChk.Checked = true;
            this.enableBordersChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableBordersChk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.enableBordersChk.Location = new System.Drawing.Point(34, 65);
            this.enableBordersChk.Name = "enableBordersChk";
            this.enableBordersChk.Size = new System.Drawing.Size(120, 18);
            this.enableBordersChk.TabIndex = 1;
            this.enableBordersChk.Text = "enable red borders";
            this.enableBordersChk.UseVisualStyleBackColor = true;
            // 
            // consistentSizeChk
            // 
            this.consistentSizeChk.AutoSize = true;
            this.consistentSizeChk.Checked = true;
            this.consistentSizeChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.consistentSizeChk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.consistentSizeChk.Location = new System.Drawing.Point(15, 42);
            this.consistentSizeChk.Name = "consistentSizeChk";
            this.consistentSizeChk.Size = new System.Drawing.Size(156, 18);
            this.consistentSizeChk.TabIndex = 1;
            this.consistentSizeChk.Text = "keep sprite size consistent";
            this.consistentSizeChk.UseVisualStyleBackColor = true;
            this.consistentSizeChk.CheckStateChanged += new System.EventHandler(this.consistentSizeChk_CheckStateChanged);
            // 
            // spriteNameChk
            // 
            this.spriteNameChk.AutoSize = true;
            this.spriteNameChk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.spriteNameChk.Location = new System.Drawing.Point(15, 88);
            this.spriteNameChk.Name = "spriteNameChk";
            this.spriteNameChk.Size = new System.Drawing.Size(183, 18);
            this.spriteNameChk.TabIndex = 1;
            this.spriteNameChk.Text = "use sprite name instead of index";
            this.spriteNameChk.UseVisualStyleBackColor = true;
            // 
            // exportBtn
            // 
            this.exportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.exportBtn.Location = new System.Drawing.Point(15, 212);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(245, 23);
            this.exportBtn.TabIndex = 2;
            this.exportBtn.Text = "export";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelBtn.Location = new System.Drawing.Point(15, 241);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(245, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // exportoptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 276);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.spriteNameChk);
            this.Controls.Add(this.consistentSizeChk);
            this.Controls.Add(this.enableBordersChk);
            this.Controls.Add(this.exportingHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "exportoptions";
            this.Text = "export-options";
            this.Load += new System.EventHandler(this.exportoptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label exportingHeader;
        private System.Windows.Forms.CheckBox enableBordersChk;
        private System.Windows.Forms.CheckBox consistentSizeChk;
        private System.Windows.Forms.CheckBox spriteNameChk;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}