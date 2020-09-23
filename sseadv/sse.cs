using AssetsTools.NET;
using AssetsTools.NET.Extra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sseadv
{
    public partial class sse : Form
    {
        private static string TITLE_DEF = "super-sprite-extractor advanced tk2d edition";

        private AssetsManager am;
        private Dictionary<AssetID, Bitmap> bitmapCache;
        private AssetsFileInstance activeFile;

        private List<TkSpriteCollection> collections;
        private List<TkSpriteAnimation> animations;
        private List<TkSpriteAnimationClip> animationClips;

        private TkSpriteCollection activeCollection;
        private TkSpriteAnimationClip activeAnimation;
        private bool playingAnimation;
        private int activeFrame;
        private Timer animationTimer;

        private bool onMono;

        public sse()
        {
            InitializeComponent();

            onMono = Type.GetType("Mono.Runtime") != null;
            
            if (onMono)
                TITLE_DEF += " [compat mode]";

            am = new AssetsManager();
            am.LoadClassDatabase("cldb.dat");
            am.useTemplateFieldCache = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sse-adv v1 -nes", "about", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void automaticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists("pathinfo.txt"))
            {
                DialogResult res = MessageBox.Show("pathinfo.txt does not exist, would you like to create it?", "sse-adv",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    res = MessageBox.Show("are you using steam?", "sse-adv",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        File.WriteAllLines("pathinfo.txt", new[] { "steam", "appid", "game title", "game data folder name" });
                        MessageBox.Show("please fill in the values in pathinfo.txt with your game info", "sse-adv");
                        return;
                    }
                    else
                    {
                        string newGameDataPath = SelectFolder("select game's _data path");
                        if (newGameDataPath != string.Empty)
                        {
                            File.WriteAllLines("pathinfo.txt", new[] { "path", newGameDataPath });
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }

            string[] pathInfoCfg = File.ReadAllLines("pathinfo.txt");
            string gameDataPath;

            if (pathInfoCfg[0] == "steam")
            {
                int appId = int.Parse(pathInfoCfg[1]);
                string gameName = pathInfoCfg[2];
                string dataFolderName = pathInfoCfg[3];
                gameDataPath = Path.Combine(SteamHelper.FindSteamGamePath(appId, gameName), dataFolderName);
            }
            else if (pathInfoCfg[0] == "path")
            {
                gameDataPath = pathInfoCfg[1];
            }
            else
            {
                MessageBox.Show("pathinfo.txt invalid", "sse-adv");
                return;
            }

            if (string.IsNullOrEmpty(gameDataPath))
                return;

            AssetsFileInstance inst = am.LoadAssetsFile(Path.Combine(gameDataPath, "globalgamemanagers"), false);
            AssetFileInfoEx buildSettings = inst.table.GetAssetInfo(11);

            List<string> scenes = new List<string>();
            AssetTypeValueField baseField = am.GetATI(inst.file, buildSettings).GetBaseField();
            AssetTypeValueField sceneArray = baseField.Get("scenes").Get("Array");
            for (int i = 0; i < sceneArray.GetValue().AsArray().size; i++)
            {
                scenes.Add(sceneArray[i].GetValue().AsString());
            }
            sceneselect sel = new sceneselect(scenes);
            sel.ShowDialog();
            if (sel.selectedFile != string.Empty)
            {
                OpenFile(Path.Combine(gameDataPath, sel.selectedFile));
            }
        }

        private void pickFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Title = "Select a file from game_Data"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OpenFile(ofd.FileName);
            }
        }

        private void thisSpriteCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeCollection == null)
                return;

            string saveFolder = SelectFolder();

            if (saveFolder != string.Empty)
            {
                int counter = 0;
                List<TkSpriteDefinition> sortedSpriteList = activeCollection.sprites.OrderBy(s => s.name).ToList();
                foreach (TkSpriteDefinition sprite in sortedSpriteList)
                {
                    Bitmap croppedImage = GetBitmap(sprite, false, true, true);
                    croppedImage.Save(Path.Combine(saveFolder, $"{activeCollection.name}_{counter.ToString().PadLeft(3, '0')}.png"));
                    counter++;
                }
            }
        }

        private void thisAnimationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeAnimation == null)
                return;

            string saveFolder = SelectFolder();

            if (saveFolder != string.Empty)
            {
                int counter = 0;
                foreach (TkSpriteFrame frame in activeAnimation.frames)
                {
                    Bitmap croppedImage = GetBitmap(frame.collection.sprites[frame.spriteId], false, true, true);
                    croppedImage.Save(Path.Combine(saveFolder, $"{activeAnimation.name}_{counter.ToString().PadLeft(3, '0')}.png"));
                    counter++;
                }
                activeAnimation.frames[0].collection.baseTexture.Save(Path.Combine(saveFolder, $"{activeAnimation.name}_full.png"));
            }
        }

        private void saveThisSpriteCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeCollection == null)
                return;

            string saveFolder = SelectFolder();

            if (saveFolder != string.Empty)
            {
                int counter = 0;
                Bitmap baseTexture = activeCollection.sprites[0].parent.baseTexture;
                //o boy, hope this is the right size
                Bitmap canvas = new Bitmap(baseTexture.Width, baseTexture.Height);
                foreach (TkSpriteDefinition sprite in activeCollection.sprites)
                {
                    string fileName = Path.Combine(saveFolder, $"{activeCollection.name}_{counter.ToString().PadLeft(3, '0')}.png");
                    SetBitmap(canvas, (Bitmap)Image.FromFile(fileName), sprite);
                    counter++;
                }
                canvas.Save(Path.Combine(saveFolder, $"{activeCollection.name}_edit.png"));
            }
        }

        private void thisFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeCollection == null)
                return;

            string saveFolder = SelectFolder();

            if (saveFolder != string.Empty && framesList.SelectedItem is TkSpriteDefinition spriteDef)
            {
                Bitmap croppedImage = GetBitmap(spriteDef, false, true, true);
                croppedImage.Save(Path.Combine(saveFolder, $"{spriteDef.name}.png"));
            }
        }

        private void spriteCollectionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (animationTimer != null)
                StopAnimation();

            frameSlider.Value = 0;
            frameSlider.Enabled = false;

            object item = spriteCollectionsList.SelectedItem;
            if (item is TkSpriteCollection col)
            {
                if (col.baseTexture == null)
                {
                    Text = TITLE_DEF + " [loading texture...]";
                    col.baseTexture = GetTexture(col.textureExts[0]);
                    Text = TITLE_DEF;
                }

                activeCollection = col;

                List<TkSpriteAnimationClip> colAnis = animationClips.Where(a => a.parent.parents.Contains(col)).ToList();

                framesList.Items.Clear();
                framesList.Items.AddRange(col.sprites.OrderBy(s => s.name).ToArray());
                animationsList.Items.Clear();
                animationsList.Items.Add("[None]");
                animationsList.Items.AddRange(colAnis.OrderBy(a => a.name).ToArray());
                pictureBox.Image = col.baseTexture;
            }
        }

        private void framesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            object item = framesList.SelectedItem;
            if (item is TkSpriteDefinition def)
            {
                int materialId = def.materialId;
                TkSpriteCollection col = def.parent;
                if (!col.textures.ContainsKey(materialId) || col.textures[materialId] == null)
                {
                    col.textures[def.materialId] = GetTexture(col.textureExts[materialId]);
                }

                Bitmap pictureBoxBitmap;
                if (def.cropCache != null)
                    pictureBoxBitmap = def.cropCache;
                else
                    pictureBoxBitmap = GetBitmap(def, true, false, false);

                pictureBox.Image = pictureBoxBitmap;
            }
        }

        private void animationsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (animationTimer != null)
                StopAnimation();

            object item = animationsList.SelectedItem;
            if (item is TkSpriteAnimationClip anim)
            {
                framesList.Items.Clear();
                foreach (TkSpriteFrame frame in anim.frames)
                {
                    if (frame.spriteId < frame.collection.sprites.Count)
                        framesList.Items.Add(frame.collection.sprites[frame.spriteId]);
                    else
                        framesList.Items.Add("[nonexistant sprite]");
                }
                frameSlider.Minimum = 0;
                frameSlider.Maximum = anim.frames.Count - 1;
                frameSlider.Enabled = true;
                frameInfo.Text = $"{anim.name} at {anim.fps} fps";
                activeAnimation = anim;
            }
            else
            {
                object colItem = spriteCollectionsList.SelectedItem;
                if (colItem is TkSpriteCollection col)
                {
                    if (col.baseTexture == null)
                    {
                        col.baseTexture = GetTexture(col.textureExts[0]);
                    }

                    List<TkSpriteAnimationClip> colAnis = animationClips.Where(a => a.parent.parents.Contains(col)).ToList();

                    framesList.Items.Clear();
                    framesList.Items.AddRange(col.sprites.OrderBy(s => s.name).ToArray());
                    pictureBox.Image = col.baseTexture;
                }
                frameSlider.Enabled = false;
                frameInfo.Text = "nothing playing";
                activeAnimation = null;
            }

            activeFrame = 0;
            if (framesList.Items.Count > 0)
                framesList.SelectedIndex = 0;
            if (frameSlider.Maximum > 0)
                frameSlider.Value = 0;
        }

        private void playFrames_Click(object sender, EventArgs e)
        {
            if (!playingAnimation)
            {
                if (activeAnimation == null)
                    return;

                playingAnimation = true;
                activeFrame = 0;
                framesList.SelectedIndex = activeFrame;
                frameSlider.Value = activeFrame;
                animationTimer = new Timer()
                {
                    Interval = (int)(1f / activeAnimation.fps * 1000f)
                };
                animationTimer.Tick += AnimationTimer_Tick;
                animationTimer.Start();
            }
            else
            {
                StopAnimation();
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            activeFrame++;
            if (activeFrame >= activeAnimation.frames.Count)
            {
                activeFrame = activeAnimation.loopStart;
            }
            framesList.SelectedIndex = activeFrame;
            frameSlider.Value = activeFrame;
        }

        private void frameSlider_ValueChanged(object sender, EventArgs e)
        {
            activeFrame = frameSlider.Value;
            if (framesList.Items.Count > 0)
                framesList.SelectedIndex = activeFrame;
        }

        private void ResetUI()
        {
            spriteCollectionsList.Items.Clear();
            framesList.Items.Clear();
            animationsList.Items.Clear();
        }

        private void StopAnimation()
        {
            playingAnimation = false;
            animationTimer.Stop();
            animationTimer.Dispose();
            animationTimer = null;
        }

        private void OpenFile(string fileName)
        {
            ResetUI();
            Text = TITLE_DEF + " [loading assets...]";

            activeFile = am.LoadAssetsFile(fileName, true);
            am.UpdateDependencies();

            bitmapCache = new Dictionary<AssetID, Bitmap>();

            GetTk2dSprites(activeFile);

            spriteCollectionsList.Items.Add("==================================");
            spriteCollectionsList.Items.Add(Path.GetFileName(fileName));
            spriteCollectionsList.Items.Add("==================================");
            spriteCollectionsList.Items.AddRange(collections.ToArray());

            Text = TITLE_DEF;
        }

        private void GetTk2dSprites(AssetsFileInstance inst)
        {
            collections = new List<TkSpriteCollection>();
            animations = new List<TkSpriteAnimation>();
            animationClips = new List<TkSpriteAnimationClip>();
            List<TkSpriteFrame> sprFrames = new List<TkSpriteFrame>();
            string managedPath = Path.Combine(Path.GetDirectoryName(inst.path), "Managed");

            Dictionary<AssetID, TkSpriteCollection> collectionLookup = new Dictionary<AssetID, TkSpriteCollection>();
            int tk2dSCid = -1;
            int tk2dSAid = -1;
            foreach (AssetFileInfoEx mbInf in inst.table.GetAssetsOfType(0x72))
            {
                string scriptName = null;
                ushort scriptIndex = inst.file.typeTree.unity5Types[mbInf.curFileTypeOrIndex].scriptIndex;
                if (tk2dSCid != -1 && scriptIndex == tk2dSCid)
                {
                    scriptName = "tk2dSpriteCollectionData";
                }
                else if (tk2dSAid != -1 && scriptIndex == tk2dSAid)
                {
                    scriptName = "tk2dSpriteAnimation";
                }

                if (tk2dSCid == -1 || tk2dSAid == -1) //still looking for script ids
                {
                    AssetTypeValueField mbBase = am.GetATI(inst.file, mbInf).GetBaseField();
                    AssetTypeValueField scBase = am.GetExtAsset(inst, mbBase.Get("m_Script")).instance.GetBaseField();
                    scriptName = scBase.Get("m_Name").GetValue().AsString();
                    if (scriptName == "tk2dSpriteCollectionData")
                        tk2dSCid = scriptIndex;
                    else if (scriptName == "tk2dSpriteAnimation")
                        tk2dSAid = scriptIndex;
                    else
                        continue; //nope, nobody cares
                }

                if (scriptName == null)
                    continue;

                AssetTypeValueField mbSerialBase = am.GetMonoBaseFieldCached(inst, mbInf, managedPath);
                if (scriptName == "tk2dSpriteCollectionData")
                {
                    AssetTypeValueField textures = mbSerialBase.Get("textures");

                    List<AssetExternal> textureExts = new List<AssetExternal>();
                    List<int> textureWidths = new List<int>();
                    List<int> textureHeights = new List<int>();
                    for (int i = 0; i < textures.childrenCount; i++)
                    {
                        AssetExternal textureExt = am.GetExtAsset(inst, mbSerialBase.Get("textures")[i]);
                        AssetTypeValueField textureBase = textureExt.instance.GetBaseField();
                        textureExts.Add(textureExt);
                        textureWidths.Add(textureBase.Get("m_Width").GetValue().AsInt());
                        textureHeights.Add(textureBase.Get("m_Height").GetValue().AsInt());
                    }

                    TkSpriteCollection collection = new TkSpriteCollection()
                    {
                        name = mbSerialBase.Get("spriteCollectionName").GetValue().AsString(),
                        version = mbSerialBase.Get("version").GetValue().AsInt(),
                        baseTexture = null, //do later
                        textures = new Dictionary<int, Bitmap>(), //same
                        textureExts = textureExts,
                        sprites = new List<TkSpriteDefinition>()
                    };
                    collectionLookup[new AssetID(inst.name, mbInf.index)] = collection;
                    AssetTypeValueField spriteDefinitions = mbSerialBase.Get("spriteDefinitions");
                    foreach (AssetTypeValueField def in spriteDefinitions.children)
                    {
                        bool flipped = def.Get("flipped").GetValue().AsInt() == 1;
                        int materialId = def.Get("materialId").GetValue().AsInt();
                        int textureWidth = textureWidths[materialId];
                        int textureHeight = textureHeights[materialId];

                        double uxn = double.MaxValue;
                        double uxp = 0;
                        double uyn = double.MaxValue;
                        double uyp = 0;
                        double pxn = double.MaxValue;
                        double pyn = double.MaxValue;
                        AssetTypeValueField positions = def.Get("positions");
                        AssetTypeValueField uvs = def.Get("uvs");
                        for (int i = 0; i < 4; i++)
                        {
                            AssetTypeValueField pos = positions[i];
                            AssetTypeValueField uv = uvs[i];
                            double posX = pos.Get("x").GetValue().AsFloat();
                            double posY = pos.Get("y").GetValue().AsFloat();
                            double uvX = Math.Round(uv.Get("x").GetValue().AsFloat() * textureWidth);
                            double uvY = textureHeight - Math.Round(uv.Get("y").GetValue().AsFloat() * textureHeight);
                            if (posX < pxn)
                                pxn = posX;
                            if (posY < pyn)
                                pyn = posY;

                            if (uvX < uxn)
                                uxn = uvX;
                            if (uvX > uxp)
                                uxp = uvX;
                            if (uvY < uyn)
                                uyn = uvY;
                            if (uvY > uyp)
                                uyp = uvY;
                        }
                        int spriteX = (int)uxn;
                        int spriteY = (int)uyn;
                        int spriteWidth = (int)(uxp - uxn);
                        int spriteHeight = (int)(uyp - uyn);

                        AssetTypeValueField boundsData = def.Get("boundsData");
                        AssetTypeValueField untrimmedBoundsData = def.Get("untrimmedBoundsData");
                        AssetTypeValueField texelSize = def.Get("texelSize");

                        float texelX = texelSize.Get("x").GetValue().AsFloat();
                        float texelY = texelSize.Get("y").GetValue().AsFloat();

                        float realX = ((float)pxn) / texelX;
                        float realY = -((flipped ? spriteWidth : spriteHeight) + ((float)pyn) / texelY);

                        TkSpriteDefinition sprite = new TkSpriteDefinition()
                        {
                            parent = collection,
                            name = def.Get("name").GetValue().AsString(),
                            x = spriteX,
                            y = spriteY,
                            width = spriteWidth,
                            height = spriteHeight,
                            xOff = realX,
                            yOff = realY,
                            materialId = materialId,
                            fullWidth = untrimmedBoundsData[1].Get("x").GetValue().AsFloat() / texelX,
                            fullHeight = untrimmedBoundsData[1].Get("y").GetValue().AsFloat() / texelY,
                            flipped = flipped
                        };
                        collection.sprites.Add(sprite);
                    }
                    collections.Add(collection);
                }
                else if (scriptName == "tk2dSpriteAnimation")
                {
                    AssetFileInfoEx gameObjectInfo = inst.table.GetAssetInfo(mbSerialBase.Get("m_GameObject").Get("m_PathID").GetValue().AsInt64());
                    TkSpriteAnimation animation = new TkSpriteAnimation()
                    {
                        parents = new List<TkSpriteCollection>(), //do later
                        parentIds = new List<AssetID>(),
                        gameObjectName = AssetHelper.GetAssetNameFast(inst.file, am.classFile, gameObjectInfo),
                        clips = new List<TkSpriteAnimationClip>()
                    };

                    AssetTypeValueField clips = mbSerialBase.Get("clips");
                    foreach (AssetTypeValueField clip in clips.children)
                    {
                        TkSpriteAnimationClip aniClip = new TkSpriteAnimationClip()
                        {
                            parent = animation,
                            name = clip.Get("name").GetValue().AsString(),
                            fps = clip.Get("fps").GetValue().AsFloat(),
                            loopStart = clip.Get("loopStart").GetValue().AsInt(),
                            wrapMode = (WrapMode)clip.Get("wrapMode").GetValue().AsInt(),
                            frames = new List<TkSpriteFrame>()
                        };
                        animation.clips.Add(aniClip);
                        animationClips.Add(aniClip);

                        AssetTypeValueField frames = clip.Get("frames");
                        foreach (AssetTypeValueField frame in frames.children)
                        {
                            AssetExternal collectionExt = am.GetExtAsset(inst, frame.Get("spriteCollection"));
                            AssetID collectionId = new AssetID(collectionExt.file.name, collectionExt.info.index);
                            if (!animation.parentIds.Contains(collectionId))
                            {
                                animation.parentIds.Add(collectionId);
                            }
                            TkSpriteFrame sprFrame = new TkSpriteFrame()
                            {
                                collection = null, //do later
                                collectionId = collectionId,
                                spriteId = frame.Get("spriteId").GetValue().AsInt()
                            };
                            sprFrames.Add(sprFrame);
                            aniClip.frames.Add(sprFrame);
                        }
                    }
                    animations.Add(animation);
                }
            }

            foreach (TkSpriteAnimation animation in animations)
            {
                foreach (AssetID parentId in animation.parentIds)
                {
                    animation.parents.Add(collectionLookup[parentId]);
                }
            }
            foreach (TkSpriteFrame frame in sprFrames)
            {
                frame.collection = collectionLookup[frame.collectionId];
            }
        }

        private Bitmap GetTexture(AssetExternal textureExt)
        {
            if (textureExt.instance == null)
                return null;

            AssetTypeValueField textureBase = textureExt.instance.GetBaseField();
            AssetID id = new AssetID(textureExt.file.name, textureExt.info.index);
            if (bitmapCache.ContainsKey(id))
                return bitmapCache[id];

            TextureFile texture = TextureFile.ReadTextureFile(textureBase);
            byte[] textureBytes = texture.GetTextureData(textureExt.file);
            if (textureBytes != null && textureBytes.Length > 0)
            {
                Bitmap canvas = new Bitmap(texture.m_Width, texture.m_Height, PixelFormat.Format32bppArgb);

                Rectangle dimension = new Rectangle(0, 0, canvas.Width, canvas.Height);
                BitmapData picData = canvas.LockBits(dimension, ImageLockMode.ReadWrite, canvas.PixelFormat);
                picData.Stride = texture.m_Width * 4;
                IntPtr pixelStartAddress = picData.Scan0;

                Marshal.Copy(textureBytes, 0, pixelStartAddress, textureBytes.Length);

                canvas.UnlockBits(picData);

                //easy way, but wine doesn't have UnsafeAddrOfPinnedArrayElement for some reason
                //Bitmap canvas = new Bitmap(texture.m_Width, texture.m_Height, texture.m_Width * 4, PixelFormat.Format32bppArgb,
                //    Marshal.UnsafeAddrOfPinnedArrayElement(textureBytes, 0));
                canvas.RotateFlip(RotateFlipType.RotateNoneFlipY);
                bitmapCache[id] = canvas;
                return canvas;
            }
            return null;
        }

        private Bitmap GetBitmap(TkSpriteDefinition def, bool bg, bool round, bool border)
        {
            TkSpriteCollection col = def.parent;

            Bitmap croppedBitmap = new Bitmap(def.width, def.height);

            using (Graphics graphics = Graphics.FromImage(croppedBitmap))
            {
                graphics.DrawImage(GetTexture(col.textureExts[def.materialId]), new Rectangle(0, 0, def.width, def.height), new Rectangle(def.x, def.y, def.width, def.height), GraphicsUnit.Pixel);
            }

            Bitmap croppedBitmapGdiSafe;
            if (onMono)
            {
                //pretty crappy, but there's a bug with mono's internal
                //image format that won't let us rotate it after we drawimage it
                using (MemoryStream ms = new MemoryStream())
                {
                    croppedBitmap.Save(ms, ImageFormat.Png);
                    croppedBitmapGdiSafe = new Bitmap(ms);
                }
            }
            else
            {
                croppedBitmapGdiSafe = croppedBitmap;
            }

            if (def.flipped)
                croppedBitmapGdiSafe.RotateFlip(RotateFlipType.Rotate270FlipX);

            Bitmap resizedBitmap = new Bitmap((int)def.fullWidth, (int)def.fullHeight);
            using (Graphics graphics = Graphics.FromImage(resizedBitmap))
            {
                float drawX = def.xOff + def.fullWidth / 2;
                float drawY = def.yOff + def.fullHeight / 2;
                float drawXRound = (float)Math.Round(drawX, MidpointRounding.AwayFromZero);
                float drawYRound = (float)Math.Round(drawY, MidpointRounding.AwayFromZero);

                if (round)
                {
                    drawX = drawXRound;
                    drawY = drawYRound;
                }

                if (bg)
                {
                    graphics.FillRectangle(Brushes.Gray, new Rectangle(0, 0, (int)def.fullWidth, (int)def.fullHeight));
                }

                if (border)
                {
                    graphics.DrawRectangle(Pens.Red, drawXRound - 1, drawYRound - 1,
                                           croppedBitmapGdiSafe.Width + 1, croppedBitmapGdiSafe.Height + 1);
                }

                graphics.DrawImage(croppedBitmapGdiSafe, drawX, drawY);
                croppedBitmapGdiSafe.Dispose();
            }
            def.cropCache = resizedBitmap;
            return resizedBitmap;
        }

        private void SetBitmap(Bitmap canvas, Bitmap newImage, TkSpriteDefinition def)
        {
            int width, height;
            if (!def.flipped)
            {
                width = def.width;
                height = def.height;
            }
            else
            {
                width = def.height;
                height = def.width;
            }

            Bitmap croppedBitmap = new Bitmap(width, height);

            using (Graphics graphics = Graphics.FromImage(croppedBitmap))
            {
                float readX = def.xOff + def.fullWidth / 2;
                float readY = def.yOff + def.fullHeight / 2;
                //do NOT remove (int)(float) it is needed for accurate rounding
                int readXRound = (int)(float)Math.Round(readX, MidpointRounding.AwayFromZero);
                int readYRound = (int)(float)Math.Round(readY, MidpointRounding.AwayFromZero);

                graphics.DrawImage(newImage, new Rectangle(0, 0, width, height), new Rectangle(readXRound, readYRound, width, height), GraphicsUnit.Pixel);
            }

            Bitmap croppedBitmapGdiSafe;
            if (onMono)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    croppedBitmap.Save(ms, ImageFormat.Png);
                    croppedBitmapGdiSafe = new Bitmap(ms);
                }
            }
            else
            {
                croppedBitmapGdiSafe = croppedBitmap;
            }

            if (def.flipped)
                croppedBitmapGdiSafe.RotateFlip(RotateFlipType.Rotate270FlipX);

            using (Graphics graphics = Graphics.FromImage(canvas))
            {
                float drawX = def.x;
                float drawY = def.y;

                graphics.DrawImage(croppedBitmapGdiSafe, drawX, drawY);
            }
        }

        private string SelectFolder(string title = "select folder to save to")
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                CheckFileExists = false,
                FileName = "[select folder]",
                Title = title
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string dirName = Path.GetDirectoryName(ofd.FileName);
                if (Directory.Exists(dirName))
                {
                    return dirName;
                }
                else
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }
    }
}
