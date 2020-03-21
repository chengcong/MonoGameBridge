using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ATowerDefenceGame
{
    abstract class Projectile : IObject
    {
        public float Damage;
        public Vector2 Speed;
        public Vector2 Position;
        public Texture2D Texture { get; }
        public bool Destroyed;

        public abstract Vector2 Origin { get; }
        public abstract float Radius { get; }

        public Circle Bounding => new Circle(Position, Radius);

        private float Top => Position.Y - Origin.Y;
        private float Bottom => Position.Y + Origin.Y;
        private float Left => Position.X - Origin.X;
        private float Right => Position.X + Origin.X;

        public Projectile(Vector2 position, Texture2D texture)
        {
            Position = position;
            Texture = texture;
        }

        public virtual void Hit(Enemy enemy)
        {
            enemy.Health -= Damage;
            Destroyed = true;
        }

        public override void Update(GameTime gameTime)
        {
            var dt = (float) gameTime.ElapsedGameTime.TotalSeconds;
            Position += dt * Speed;
            if (IsOffscreen())
                Destroyed = true;
        }

        public bool IsOffscreen()
        {
            return (Bottom < 0 || Top > GameSettings.BaseHeight) &&
                   (Right < 0 || Left > GameSettings.BaseWidth);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var rot = Speed.GetAngle();
            spriteBatch.Draw(Texture, Position, null, Color.White, rot, Origin, Vector2.One, SpriteEffects.None, 0f);
        }
    }
}