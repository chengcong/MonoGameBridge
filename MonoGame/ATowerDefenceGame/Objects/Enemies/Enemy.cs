using Microsoft.Xna.Framework;

namespace ATowerDefenceGame
{
    abstract class Enemy : IObject
    {
        public Vector2 Origin;
        public float Radius;
        public Circle Bounding => new Circle(Position, Radius);
        public Vector2 Position;

        public float MaxHealth { get; }
        public float Health { get; set; }

        public bool Dead => Health < 0;

        public Enemy(float maxHealth)
        {
            MaxHealth = maxHealth;
            Health = MaxHealth;
        }
    }
}