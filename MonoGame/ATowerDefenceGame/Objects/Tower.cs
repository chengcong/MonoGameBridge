using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace ATowerDefenceGame
{
    class Tower : IObject
    {
        public static List<Tower> Towers = new List<Tower>();

        public static Tower GetBottomTower()
        {
            Tower tower = null;
            var max = 0;

            foreach (var _tower in Towers)
            {
                if (_tower.Position.Y > max)
                {
                    tower = _tower;
                    max = _tower.Position.Y;
                }
            }

            return tower;
        }

        public float Health { get; set;  }
        public Rectangle Position { get; set; }
        private Rectangle _sourceRectangle;

        private Texture2D _damageTexture;
        private int _damagePixelsMax;

        public Tower(int index)
        {
            _sourceRectangle = new Rectangle(0, index * 32, 32, 32);

            Towers.Add(this);
        }

        public Tower() : this((int)(RngGenerator.GetUInt32() % 4) + 1)
        {
            Health = 100f;
        }

        public void DealDamage(float damage)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GameContent.Texture.Tower, Position, _sourceRectangle, Color.White);
        }
    }
}
