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


namespace TexturePrimitive.GraphicsSupport
{
    class TexturedPrimitive
    {
        protected Texture2D mImage;     //the UWB-JPG image to be loaded
        protected Vector2 mPosition;    //Center position of image
        protected Vector2 mSize;        //Size of the image to be drawn

        public TexturedPrimitive(String imageName, Vector2 position, Vector2 size)
        {
            mImage = Game1.sContent.Load<Texture2D>(imageName);
            mPosition = position;
            mSize = size;
        }

        public void Update(Vector2 deltaTranslate, Vector2 deltaScale)
        {
            mPosition += deltaTranslate;
            mSize += deltaScale;
        }

        public void Draw()
        {
            //define where and size of texture to show
            Rectangle destRect = new Rectangle((int)mPosition.X, (int)mPosition.Y, (int)mSize.X, (int)mSize.Y);
            Game1.sSpriteBatch.Draw(mImage, destRect, Color.White);
        }
    }
}
