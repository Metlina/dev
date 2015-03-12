﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SimpleGameState;

namespace BookExample
{
    /// <summary>
    /// TexturedPrimitive class
    /// </summary>
    public class TexturedPrimitive
    {
        // Support for drawing the image
        protected Texture2D mImage;     // The UWB-JPG.jpg image to be loaded
        protected Vector2 mPosition;    // Center position of image
        protected Vector2 mSize;        // Size of the image to be drawn
        private string p;

        /// <summary>
        /// Constructor of TexturePrimitive
        /// </summary>
        /// <param name="imageName">name of the image to be loaded as texture.</param>
        /// <param name="position">center position of the texture to be drawn</param>
        /// <param name="size">width/height of the texture to be drawn</param>
        public TexturedPrimitive(String imageName, Vector2 position, Vector2 size)
        {
            mImage = Game1.sContent.Load<Texture2D>(imageName);
            mPosition = position;
            mSize = size;
        }

        public TexturedPrimitive(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        // accessors
        public Vector2 Position { get { return mPosition; } set { mPosition = value; } }
        public float PositionX { get { return mPosition.X; } set { mPosition.X = value; } }
        public float PositionY { get { return mPosition.Y; } set { mPosition.Y = value; } }
        public Vector2 Size { get { return mSize; } set { mSize = value; } }
        public float Width { get { return mSize.X; } set { mSize.X = value; } }
        public float Height { get { return mSize.Y; } set { mSize.Y = value; } }
        public Vector2 MinBound { get { return mPosition - (0.5f * mSize); } }
        public Vector2 MaxBound { get { return mPosition + (0.5f * mSize); } }

        /// <summary>
        /// Allows the primitive object to update its state
        /// </summary>
        /// <param name="deltaTranslate">Amount to change the position of the primitive. 
        ///                              Value of 0 says position is not changed.</param>
        /// <param name="deltaScale">Amount to change of the scale the primitive. 
        ///                          Value of 0 says size is not changed.</param>
        public void Update(Vector2 deltaTranslate/*, Vector2 deltaScale*/)
        {
            mPosition += deltaTranslate;
            //mSize += deltaScale;
        }

        /// <summary>
        /// Draw the primitive
        /// </summary>
        public void Draw()
        {
            // Defines where and size of the texture to show
            Rectangle destRect = Camera.ComputePixelRectangle(Position, Size);
            Game1.sSpriteBatch.Draw(mImage, destRect, Color.White);
        }

        public bool PrimitiveTouches(TexturedPrimitive otherPrim)
        {
            Vector2 v = mPosition - otherPrim.mPosition;
            float dist = v.Length();
            return (dist < ((mSize.X / 2f) + (otherPrim.mSize.Y / 2f)));
        }
    }
}
