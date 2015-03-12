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
using BookExample;

namespace SimpleGameObject.GraphicsSupport
{
    public class SoccerBall : TexturedPrimitive
    {
        private Vector2 mDeltaPosition;     //change curretn position by this amount

        public SoccerBall(Vector2 position, float diametar) : base("Soccer", position, new Vector2(diametar, diametar))
        {
            mDeltaPosition.X = (float)(Game1.sRan.NextDouble()) * 2f - 1f;
            mDeltaPosition.Y = (float)(Game1.sRan.NextDouble()) * 2f - 1f;
        }

        public float Radius 
        {
            get { return mSize.X * 0.5f; }
            set { mSize.X = 2f * value; mSize.Y = mSize.X; }
        }

        public void Update()
        {
            Camera.CameraWindowCollisitonStatus status = Camera.ColideWidthCameraWidnow(this);
            switch (status) 
            {
                case Camera.CameraWindowCollisitonStatus.CollideBottom:
                case Camera.CameraWindowCollisitonStatus.CollideTop:
                    mDeltaPosition.Y *= -1;
                    break;
                case Camera.CameraWindowCollisitonStatus.CollideLeft:
                case Camera.CameraWindowCollisitonStatus.CollideRight:
                    mDeltaPosition.X *= -1;
                    break;
            }
            Position += mDeltaPosition;
        }
    }
}
