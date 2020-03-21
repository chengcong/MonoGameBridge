using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;

namespace ATowerDefenceGame
{
    class BootLevel : ILevel
    {
        private string[] _lines = new[] {
            "Once upon time...",
            "                                                                 in a land far away",
            "                                                         there lived a princess",
            "       who got kidnapped",
            "                  and you are the bastard who did it!"
        };
        private int _index;
        private float _waittinme;

        private GraphicsDevice _graphicsDevice;

        public BootLevel(GraphicsDevice graphicsDevice)
        {
            GameSettings.SetCursor(CursorType.None);
            BackgroundColor = Color.Black;
            _waittinme = 1.5f;
            _index = 0;

            _graphicsDevice = graphicsDevice;
        }

        public override void Update(GameTime gameTime)
        {
            if ((InputManager.KeyPressed(Keys.Space) || _waittinme > 2f) && _index <= _lines.Length)
            {
                if (_index == _lines.Length)
                {
                    LevelManager.LoadLevel(new MenuLevel());
                    return;
                }

                var y = GameContent.Font.IntroFontSize * 2 * _index;
                Objects.Add(new FadeInText(_lines[_index]) {
                    Position = new Vector2(16, y)
                });

                _waittinme = 0f;
                _index++;
            }

            _waittinme += (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }
    }
}