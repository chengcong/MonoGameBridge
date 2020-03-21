using System.Collections.Generic;
using ATowerDefenceGame.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ATowerDefenceGame
{
    class ILevel
    {
        public Color BackgroundColor;

        public SafeList<IObject> Objects;
        public SafeList<IObject> BackgroundObjects;

        public ILevel()
        {
            Objects = new SafeList<IObject>();
            BackgroundObjects = new SafeList<IObject>();
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var obj in BackgroundObjects)
                obj.Update(gameTime);

            foreach (var obj in Objects)
                obj.Update(gameTime);

            BackgroundObjects.Commit();
            Objects.Commit();
        }

        public virtual void BeforeDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var obj in BackgroundObjects)
                obj.Draw(gameTime, spriteBatch);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var obj in Objects)
                obj.Draw(gameTime, spriteBatch);
        }
    }
}