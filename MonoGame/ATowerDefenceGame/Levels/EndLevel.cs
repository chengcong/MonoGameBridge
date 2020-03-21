using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;

namespace ATowerDefenceGame
{
    class EndLevel : ILevel
    {
        //private (string text, Vector2 position)[] _lines;

        private int _index;
        private float _waittinme;

        public EndLevel()
        {
            GameSettings.SetCursor(CursorType.None);
            BackgroundColor = Color.Black;
            _waittinme = 1f;
            _index = 0;

            /*_lines = new(string, Vector2)[2];
            _lines[0] = (
                "And so, the evil wizard and princess lived happily ever after...",
                new Vector2(32, 32)
            );

            var ms = GameContent.Font.IntroFont.MeasureString("The End");
            _lines[1] = (
                "The End",
                new Vector2(GameSettings.BaseWidth - ms.X - 16, GameSettings.BaseHeight - ms.Y - 8)
            );*/
        }

        public override void Update(GameTime gameTime)
        {
            /*if ((InputManager.KeyPressed(Keys.Space) || _waittinme > 2f) && _index <= _lines.Length)
            {
                if (_index == _lines.Length)
                {
                    return;
                }

                Objects.Add(new FadeInText(_lines[_index].text) {
                    Position = _lines[_index].position
                });

                _waittinme = 0f;
                _index++;
            }

            _waittinme += (float)gameTime.ElapsedGameTime.TotalSeconds;*/

            base.Update(gameTime);
        }
    }
}