using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Locations;

namespace FerngillCustomWeathers
{
    internal class FerngillBlizzard
    {
        private Vector2 snowPosA;
        private Vector2 snowPosB;
        private Vector2 snowPosC;

        private bool IsWhiteOut;
        private bool IsBloodMoon;

        public bool HideInCurrentLocation { get; set; }

        public int ExpirationTime { get; private set; }
        public int BeginTime { get; private set; }
        public bool IsWeatherVisible => (Game1.timeOfDay >= BeginTime && Game1.timeOfDay <= ExpirationTime);

        internal FerngillBlizzard()
        {
        }

        public void OnNewDay()
        {
            Reset();
        }

        /// <summary> This function resets the fog. </summary>
        public void Reset()
        {
            IsWhiteOut = false;
            IsBloodMoon = false;
            BeginTime = 600;
            ExpirationTime = 600;
        }

        public void SetWhiteOut(bool whiteout)
        {
            IsWhiteOut = whiteout;
        }

        public void SetWeatherTime(int begin, int end)
        {
            FerngillCustomWeathers.Logger.Log($"Firing weather set time for {begin} and {end}", LogLevel.Info);

            BeginTime = begin;
            ExpirationTime = end;
        }

        public void DrawWeather()
        {
            if (!IsWeatherVisible && !HideInCurrentLocation)
                return;

            Color snowColor = (IsBloodMoon ? Color.Red : Color.White) * .8f * Game1.options.snowTransparency;

            if (Game1.IsSnowingHere() && (bool)Game1.currentLocation.IsOutdoors && !(Game1.currentLocation is Desert))
            {
                snowPosA.X %= 64f;
                Vector2 v = default(Vector2);

                for (float x = -64f + snowPosA.X % 64f; x < (float)Game1.viewport.Width; x += 64f)
                {
                    for (float y = -64f + snowPosA.Y % 64f; y < (float)Game1.viewport.Height; y += 64f)
                    {
                        v.X = (int)x;
                        v.Y = (int)y;
                        Game1.spriteBatch.Draw(Game1.mouseCursors, v, new Microsoft.Xna.Framework.Rectangle(368 + (int)(Game1.currentGameTime.TotalGameTime.TotalMilliseconds + 150 % 1200.0) / 75 * 16, 192, 16, 16), snowColor, 0f, Vector2.Zero, 4.001f, SpriteEffects.None, 1f);
                    }
                }
            }

            if (Game1.IsSnowingHere() && (bool) Game1.currentLocation.IsOutdoors &&
                !(Game1.currentLocation is Desert) && IsWhiteOut)
            {
                snowPosB.X %= 64f;
                Vector2 v2 = default(Vector2);

                for (float x = -64f + snowPosB.X % 64f; x < (float)Game1.viewport.Width; x += 64f)
                {
                    for (float y = -64f + snowPosB.Y % 64f; y < (float)Game1.viewport.Height; y += 64f)
                    {
                        v2.X = (int)x;
                        v2.Y = (int)y;
                        Game1.spriteBatch.Draw(Game1.mouseCursors, v2, new Microsoft.Xna.Framework.Rectangle?
                            (new Microsoft.Xna.Framework.Rectangle
                                (368 + (int)((Game1.currentGameTime.TotalGameTime.TotalMilliseconds + 225) % 1200.0) / 75 * 16, 192, 16, 16)),
                            snowColor, 0.0f, Vector2.Zero,
                            Game1.pixelZoom + 1f / 1000f, SpriteEffects.None, 1f);
                    }
                }

                snowPosC.X %= 64f;
                Vector2 v3 = default(Vector2);

                for (float x = -64f + snowPosC.X % 64f; x < (float)Game1.viewport.Width; x += 64f)
                {
                    for (float y = -64f + snowPosC.Y % 64f; y < (float)Game1.viewport.Height; y += 64f)
                    {
                        v2.X = (int)x;
                        v2.Y = (int)y;
                        Game1.spriteBatch.Draw(Game1.mouseCursors,v3, new Microsoft.Xna.Framework.Rectangle?
                            (new Microsoft.Xna.Framework.Rectangle
                                (368 + (int)((Game1.currentGameTime.TotalGameTime.TotalMilliseconds + 125) % 1200.0) / 75 * 16, 192, 16, 16)),
                            snowColor, 0.0f, Vector2.Zero,
                            Game1.pixelZoom + 1f / 1000f, SpriteEffects.None, 1f);
                    }
                }
            }
        }
    }

}
