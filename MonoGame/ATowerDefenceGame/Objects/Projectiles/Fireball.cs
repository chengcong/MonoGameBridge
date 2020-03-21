using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ATowerDefenceGame
{
    class Fireball : Projectile
    {
        public override Vector2 Origin => new Vector2(24, 15.5f);
        public override float Radius => 10f;

        public Fireball(Vector2 position, Vector2 speed)
            : base(position, GameContent.Texture.Fireball)
        {
            Speed = speed;
            Damage = 50;
        }
    }
}