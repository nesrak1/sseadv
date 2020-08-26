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
    public partial class sceneselect : Form
    {
        public string selectedFile;

        public sceneselect(List<string> scenes)
        {
            InitializeComponent();

            selectedFile = string.Empty;
            List<SceneListItem> sceneListItems = new List<SceneListItem>();
            int index = 0;
            foreach (string info in scenes)
            {
                string name = info;
                sceneList.Items.Add(new SceneListItem(name, index));
                index++;
            }
            sceneList.Items.Add(new SceneListItem("Resources", -1));
        }

        public struct SceneListItem
        {
            public string name;
            public int index;
            public SceneListItem(string name, int index)
            {
                this.name = name;
                this.index = index;
            }
            public override string ToString()
            {
                string text = name;
                if (index != -1)
                    text += "[" + index + "]";
                return text;
            }
        }

        private void sceneList_DoubleClick(object sender, EventArgs e)
        {
            object item = sceneList.SelectedItem;
            if (item != null && item is SceneListItem sceneItem)
            {
                if (sceneItem.name == "Resources")
                    selectedFile = "resources.assets";
                else
                    selectedFile = "sharedassets" + sceneItem.index + ".assets";
                Close();
            }
        }
    }
}
