using System.IO;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewValley;

namespace FerngillCustomWeathers
{
    /// <summary> Sprites used for drawing various weather stuff </summary>
    public class Icons
    {
        public Texture2D LightFogTexture;
        public Texture2D FogTexture;
        public Texture2D BlindingFogTexture;
        //public Texture2D DarudeTexture;
        public static Texture2D Source2;

        public Icons(IContentHelper helper)
        {
            FogTexture = helper.Load<Texture2D>(Path.Combine("assets", "ThickerFog.png"));
            BlindingFogTexture = helper.Load<Texture2D>(Path.Combine("assets", "ThickerFog2.png"));
            LightFogTexture = helper.Load<Texture2D>(Path.Combine("assets", "LighterFog.png"));
            //DarudeTexture = helper.Load<Texture2D>(Path.Combine("assets", "sandstormtexture.png"));
            Source2 = Game1.mouseCursors;
        }
    }
}
