using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ATowerDefenceGame
{
    class Wizard : IObject
    {
        // position of the center of the feet of the wizard
        public Vector2 Position;

        public Wizard(Vector2 position)
        {
            Position = position;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var drawPos = Position - new Vector2(GameContent.Texture.Wizard.Width / 2, GameContent.Texture.Wizard.Height);
            spriteBatch.Draw(GameContent.Texture.Wizard, drawPos, null, Color.White);
        }
    }
}