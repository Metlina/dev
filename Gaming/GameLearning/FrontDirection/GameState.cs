﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BookExample
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameState
    {
        //rocket support
        Vector2 mRocketInitDirection = Vector2.UnitY;       //this does not change
        TexturedPrimitive mRocket;

        //support the flying net
        TexturedPrimitive mNet;
        bool mNetInFlight = false;
        Vector2 mNetVelocity = Vector2.Zero;
        float mNetSpeed = 0.5f;

        //insect support
        TexturedPrimitive mInsect;
        bool mInsectPreset = true;

        //simple game status
        int mNumInsectShot;
        int mNumMissed;

        /// <summary>
        /// Constructor
        /// </summary>
        public GameState()
        {
            //create and set up the primitives
            mRocket = new TexturedPrimitive("Rocket", new Vector2(5, 5), new Vector2(3, 10));
            //initially the rocket pointing in the positive y direction
            mRocketInitDirection = Vector2.UnitY;

            mNet = new TexturedPrimitive("Net", new Vector2(0, 0), new Vector2(2, 5));
            mNetInFlight = false;           //until users press A, rocket is not in flight
            mNetVelocity = Vector2.Zero;
            mNetSpeed = 0.5f;

            // initialize a new insect
            mInsect = new TexturedPrimitive("Insect", Vector2.Zero, new Vector2(5, 5));
            mInsectPreset = false;

            //initialize game status
            mNumInsectShot = 0;
            mNumMissed = 0;
        }

        /// <summary>
        /// Updates the game state
        /// </summary>
        public void UpdateGame()
        {
            #region rocket behaviour
            mRocket.RotateAngleInRadian += MathHelper.ToRadians(InputWrapper.ThumbSticks.Right.X);
            mRocket.Position += InputWrapper.ThumbSticks.Left;
            #endregion

            #region projectile net behaviour
            //set net to flight
            if (InputWrapper.Buttons.A == ButtonState.Pressed)
            {
                mNetInFlight = true;
                mNet.RotateAngleInRadian = mRocket.RotateAngleInRadian;
                mNet.Position = mRocket.Position;
                mNetVelocity = ShowVector.RotateVectorByAngle(mRocketInitDirection, mNet.RotateAngleInRadian) * mNetSpeed;
            }
            #endregion

            #region bee
            if (!mInsectPreset)
            {
                float x = 15f + ((float)Game1.sRan.NextDouble() * 30f);
                float y = 15f + ((float)Game1.sRan.NextDouble() * 30);
                mInsect.Position = new Vector2(x, y);
                mInsectPreset = true;
            }
            #endregion

            #region net in flight and collision with insect
            if (mNetInFlight)
            {
                mNet.Position += mNetVelocity;
                if (mNet.PrimitivesTouches(mInsect))
                {
                    mInsectPreset = false;
                    mNetInFlight = false;
                    mNumInsectShot++;
                }

                if ((Camera.CollidedWithCameraWindow(mNet) != Camera.CameraWindowCollisionStatus.InsideWindow))
                {
                    mNetInFlight = false;
                    mNumMissed++;
                }
            }
            #endregion
        }

        /// <summary>
        /// Draws the game state
        /// </summary>
        public void DrawGame()
        {
            mRocket.Draw();
            if (mNetInFlight)
                mNet.Draw();

            if (mInsectPreset)
                mInsect.Draw();

            //print out text message to echo status
            FontSupport.PrintStatus("Num insects netted = " + mNumInsectShot + " Num missed = " + mNumMissed, null);
        }
    }
}
