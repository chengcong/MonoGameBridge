using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ATowerDefenceGame
{
    class MenuButton : IObject
    {
        public EventHandler Activated;
        public string Text;

        private Vector2 _textPosition;
        private float _alpha;
        private Rectangle _size;
        private SpriteFont _font;

        public MenuButton(string text, Vector2 position, bool bigbutton = true)
        {
            Text = text;
            _font = bigbutton ? GameContent.Font.TitleFont : GameContent.Font.IntroFont;

            var size = _font.MeasureString(Text);
            _textPosition = position - (size / 2f);
            _size = new Rectangle((int)_textPosition.X, (int)_textPosition.Y, (int)size.X, (int)size.Y);
            _alpha = 0.1f;
        }

        public override void Update(GameTime gameTime)
        {
            var hover = _size.Contains(InputManager.MousePosition);
            _alpha = hover ? 0.3f : 0.1f;

            if (hover && InputManager.MousePressed())
                Activated?.Invoke(this, EventArgs.Empty);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, Text, _textPosition + new Vector2(3f, 3f), Color.White * _alpha);
            spriteBatch.DrawString(_font, Text, _textPosition + new Vector2(3f, 0f), Color.White * _alpha);
            spriteBatch.DrawString(_font, Text, _textPosition + new Vector2(0f, 3f), Color.White * _alpha);

            spriteBatch.DrawString(_font, Text, _textPosition, Color.White);
        }
    }
}