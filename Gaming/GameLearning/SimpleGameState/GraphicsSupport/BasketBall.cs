using BookExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace SimpleGameState.GraphicsSupport
{
    public class BasketBall : TexturedPrimitive
    {
        //change current position by this amount
        private const float kIncreaseRate = 1.001f;
        private Vector2 kInitSize = new Vector2(5, 5);
        private const float kFinalSize = 15f;

        public BasketBall() : base("BasketBall")
        {
            mPosition = Camera.RandomPosition();
            mSize = kInitSize;
        }

        public bool UpdateAndExplode()
        {
            mSize *= kIncreaseRate;
            return mSize.X > kFinalSize;
        }
    }
}
