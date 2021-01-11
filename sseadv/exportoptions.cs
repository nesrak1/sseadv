using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sseadv
{
    public partial class exportoptions : Form
    {
        private string name;

        public bool DialogOk { get; private set; }
        public bool ConsistentSpriteSize { get; private set; }
        public bool EnableBorders { get; private set; }
        public bool UseSpriteName { get; private set; }

        public exportoptions(string name)
        {
            this.name = name;
            DialogOk = false;
            InitializeComponent();
        }

        private void exportoptions_Load(object sender, EventArgs e)
        {
            exportingHeader.Text = $"exporting {name}...";
        }

        private void consistentSizeChk_CheckStateChanged(object sender, EventArgs e)
        {
            if (!consistentSizeChk.Checked)
                enableBordersChk.Enabled = false;
            else
                enableBordersChk.Enabled = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            DialogOk = true;
            ConsistentSpriteSize = consistentSizeChk.Checked;
            if (ConsistentSpriteSize)
                EnableBorders = enableBordersChk.Checked;
            else
                EnableBorders = false;
            UseSpriteName = spriteNameChk.Checked;
            Close();
        }
    }
}
