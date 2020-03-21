using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ATowerDefenceGame
{
    class EnemyKnight : Enemy
    {
        public EnemyState State;
        public float Rotation;
        
        private float _angleChange;
        private Vector2 _movement;
        private SpriteEffects _effect;
        private const float _attackpower = 4f;

        public EnemyKnight() : this(RngGenerator.GetBool())
        {
            
        }

        public EnemyKnight(bool left)
            : base(100f)
        {
            State = EnemyState.Walking;
            Origin = new Vector2(8, 8);
            Radius = 8f;
            Position = new Vector2(
                left ? -40f : GameSettings.BaseWidth + 40f, 
                GameSettings.FloorLevel - Origin.Y
            );
            Rotation = 0f;

            _movement = new Vector2(50f * (left ? 1f : -1f), 50f);
            _angleChange = 200f;
            _effect = left ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        }

        public override void Update(GameTime gameTime)
        {
            // rotate left right
            if (Rotation < -30f || Rotation > 30f)
                _angleChange *= -1;

            // move up down
            if (Position.Y < GameSettings.FloorLevel - Origin.Y - 3 ||
                Position.Y > GameSettings.FloorLevel - Origin.Y + 3)
                _movement.Y *= -1;

            // update values
            Rotation += (float)gameTime.ElapsedGameTime.TotalSeconds * _angleChange;
            Position.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * _movement.Y;

            if (State == EnemyState.Walking)
            {
                Position.X += (float)gameTime.ElapsedGameTime.TotalSeconds * _movement.X;

                if (Math.Abs(Position.X - GameSettings.BaseWidth / 2) < 20f + Origin.X)
                    State = EnemyState.Attacking;
            }
            else
            {
                Tower.GetBottomTower().DealDamage(_attackpower * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                GameContent.Texture.EnemyKnight,
                Position,
                null,
                Color.White,
                MathHelper.ToRadians(Rotation),
                Origin,
                Vector2.One,
                _effect,
                0
            );
        }
    }
}