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

namespace BookExample
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameState
    {
        //work with TexturedPrimitive
        TexturedPrimitive mBall, mUWBLogo;
        TexturedPrimitive mWorkPrim;

        /// <summary>
        /// Constructor
        /// </summary>
        public GameState()
        {
            //create the primitives
            mBall = new TexturedPrimitive("Soccer", new Vector2(30, 30), new Vector2(10, 15));
            mUWBLogo = new TexturedPrimitive("UWB-JPG", new Vector2(60, 30), new Vector2(20, 20));
            mWorkPrim = mBall;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        public void UpdateGame()
        {
            #region select which primitive to work on
            if (InputWrapper.Buttons.A == ButtonState.Pressed)
                mWorkPrim = mBall;
            else if (InputWrapper.Buttons.B == ButtonState.Pressed)
                mWorkPrim = mUWBLogo;
            #endregion select which primitive to work on

            #region update the work primitive
            float rotation = 0;
            if (InputWrapper.Buttons.X == ButtonState.Pressed)
                rotation = MathHelper.ToRadians(1f);            //1 degree pre-press
            if (InputWrapper.Buttons.Y == ButtonState.Pressed)
                rotation = MathHelper.ToRadians(-1f);           //1 degree pre-press
            mWorkPrim.Update(InputWrapper.ThumbSticks.Left, InputWrapper.ThumbSticks.Right, rotation);
            #endregion
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary
        public void DrawGame()
        {
            mBall.Draw();
            FontSupport.PrintStatusAt(mBall.Position, mBall.RotateAngleInRadin.ToString(), Color.Red);

            mUWBLogo.Draw();
            FontSupport.PrintStatusAt(mUWBLogo.Position, mUWBLogo.Position.ToString(), Color.Black);

            FontSupport.PrintStatus("A-Soccer B-logo Left Thumb:move RightThumb:Scale X/Y:Rotate", null);
        }
    }
}