using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace XNA_Innlevering2.GameComponents
{
    interface ICollidable
    {
        bool CheckCollision(Rectangle box1, Rectangle box2);
    }


    public class ObjectCollisionComponent : Microsoft.Xna.Framework.GameComponent, ICollidable
    {
        public ObjectCollisionComponent(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(ICollidable), this);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public bool CheckCollision(Rectangle box1, Rectangle box2)
        {
            if (box1.Intersects(box2))
            {
                Console.WriteLine("COLLISION");
            }
        }
    }
}
