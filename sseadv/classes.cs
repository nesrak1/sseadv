using AssetsTools.NET;
using AssetsTools.NET.Extra;
using System.Collections.Generic;
using System.Drawing;

namespace sseadv
{
    public class TkSpriteCollection
    {
        public string name;
        public int version;
        public Bitmap baseTexture;
        public Dictionary<int, Bitmap> textures;
        public byte[] rawBytes;
        //public AssetExternal textureExt;
        public List<AssetExternal> textureExts;
        public List<TkSpriteDefinition> sprites;

        //for listview
        public override string ToString()
        {
            return name;
        }
    }

    public class TkSpriteDefinition
    {
        public TkSpriteCollection parent;
        public string name;
        public int x;
        public int y;
        public int width;
        public int height;
        public float xOff;
        public float yOff;
        public int materialId;
        public float fullWidth;
        public float fullHeight;
        public bool flipped;
        public Bitmap cropCache;

        //for listview
        public override string ToString()
        {
            if (name == string.Empty)
                return "[unnamed]";
            return name;
        }
    }

    public class TkSpriteAnimation
    {
        public List<TkSpriteCollection> parents;
        public List<AssetID> parentIds;
        public string gameObjectName;
        public List<TkSpriteAnimationClip> clips;

        //for listview
        public override string ToString()
        {
            if (gameObjectName == string.Empty)
                return "[unnamed]";
            return gameObjectName;
        }
    }

    public class TkSpriteAnimationClip
    {
        public TkSpriteAnimation parent;
        public string name;
        public float fps;
        public int loopStart;
        public WrapMode wrapMode;
        public List<TkSpriteFrame> frames;

        //for listview
        public override string ToString()
        {
            string result = name;
            if (result == string.Empty)
                result = "[unnamed]";
            if (parent.gameObjectName != string.Empty)
                result += " on " + parent.gameObjectName;
            return result;
        }
    }

    public class TkSpriteFrame
    {
        public TkSpriteCollection collection;
        public AssetID collectionId;
        public int spriteId;
    }

    public enum WrapMode
    {
        Loop,
        LoopSection,
        Once,
        PingPong,
        RandomFrame,
        RandomLoop,
        Single
    }

    //TODO UPDATE NUGET
    public class AssetID
    {
        public string fileName;
        public long pathID;
        public AssetID(string fileName, long pathID)
        {
            this.fileName = fileName;
            this.pathID = pathID;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is AssetID))
                return false;
            AssetID cobj = (AssetID)obj;
            return cobj.fileName == fileName && cobj.pathID == pathID;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + fileName.GetHashCode();
            hash = hash * 23 + pathID.GetHashCode();
            return hash;
        }
        public static bool operator ==(AssetID idA, AssetID idB)
        {
            if (idA is null && idB is null)
                return true;
            else if (idA is null)
                return false;
            else if (idB is null)
                return false;

            return idA.fileName == idB.fileName && idA.pathID == idB.pathID;
        }
        public static bool operator !=(AssetID idA, AssetID idB)
        {
            return !(idA == idB);
        }
    }
}
