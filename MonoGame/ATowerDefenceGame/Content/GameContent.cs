using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ATowerDefenceGame
{
    static class GameContent
    {
        public static bool IsLoaded { get; set; }

        public static async void Init(ContentManager content, GraphicsDevice graphics)
        {
            Texture.Pixel = await Texture2D.FromURL(graphics, "Content/Textures/Pixel.png");
            Texture.Tower = await Texture2D.FromURL(graphics, "Content/Textures/Tower.png");
            Texture.EnemyKnight = await Texture2D.FromURL(graphics, "Content/Textures/EnemyKnight.png");
            Texture.Fireball = await Texture2D.FromURL(graphics, "Content/Textures/Fireball.png");
            Texture.Wizard = await Texture2D.FromURL(graphics, "Content/Textures/Wizard.png");
            Texture.Ground = await Texture2D.FromURL(graphics, "Content/Textures/Ground.png");
            Texture.Wand = await Texture2D.FromURL(graphics, "Content/Textures/Wand.png");
            Texture.Pointer = await Texture2D.FromURL(graphics, "Content/Textures/Pointer.png");

            Font.IntroFont = await content.LoadAsync<SpriteFont>("Fonts/IntroFont");
            Font.IntroFontSize = Font.IntroFont.MeasureString("M").Y + Font.IntroFont.Spacing;
            Font.TitleFont = await content.LoadAsync<SpriteFont>("Fonts/TitleFont");

            IsLoaded = true;
        }

        public static class Font
        {
            public static SpriteFont IntroFont;
            public static float IntroFontSize;

            public static SpriteFont TitleFont;
        }

        public static class Texture
        {
            public static Texture2D Pixel;
            public static Texture2D Tower;
            public static Texture2D EnemyKnight;
            public static Texture2D Fireball;
            public static Texture2D Wizard;
            public static Texture2D Ground;
            public static Texture2D Wand;
            public static Texture2D Pointer;
        }
    }
}
