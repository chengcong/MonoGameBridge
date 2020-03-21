using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ATowerDefenceGame
{
    class FadeInText : IObject
    {
        private float _alpha;
        private string _text;

        public FadeInText(string text)
        {
            _alpha = 0f;
            _text = text;

            Position = new Vector2(16, 16);
        }

        public Vector2 Position;

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_alpha < 1f)
                _alpha += (float)gameTime.ElapsedGameTime.TotalSeconds;
            spriteBatch.DrawString(GameContent.Font.IntroFont, _text, Position, Color.White * _alpha);
        }
    }
}