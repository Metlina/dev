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
using SimpleGameState.GraphicsSupport;


namespace SimpleGameState
{
    public class MyGame
    {
        //hero stuff
        TexturedPrimitive mHero;
        Vector2 kHeroSize = new Vector2(15, 15);
        Vector2 kHeroPosition = Vector2.Zero;

        //basketballs
        List<BasketBall> mBBallList;
        TimeSpan mCreationTimeSpan;
        int mTotalBallCreated = 0;
        //this is 0,5 seconds
        const int kBallMSecInterval = 500;

        //game state
        int mScore = 0;
        int mBBallMissed = 0, mBBallHit = 0;
        const int kBallTouchScore = 1;
        const int kBallMissedScore = -2;
        const int kWinScore = 10;
        const int kLossScore = -10;
        TexturedPrimitive mFinal = null;

        public MyGame()
        {
            //hero
            mHero = new TexturedPrimitive("Me", kHeroPosition, kHeroSize);

            //basketballs
            mCreationTimeSpan = new TimeSpan(0);
            mBBallList = new List<BasketBall>();
        }

        public void UpdateGame(GameTime gameTime)
        {
            #region step a
            if (null != mFinal)     //done
                return;
            #endregion step a

            #region steb b
            //hero movement : right thumb stic
            mHero.Update(InputWrapper.ThumbSticks.Right);

            //basketball
            for (int b = mBBallList.Count - 1; b >= 0; b--)
            {
                if (mBBallList[b].UpdateAndExplode())
                {
                    mBBallList.RemoveAt(b);
                    mBBallMissed++;
                    mScore += kBallMissedScore;
                }
            }
            #endregion step b

            #region step c
            for (int b = mBBallList.Count - 1; b >= 0; b--)
            {
                if (mHero.PrimitiveTouches(mBBallList[b]))
                {
                    mBBallList.RemoveAt(b);
                    mBBallHit++;
                    mScore += kBallTouchScore;
                }
            }
            #endregion step c

            #region step d
            //check for new basketball condition
            TimeSpan timePassed = gameTime.TotalGameTime;
            timePassed = timePassed.Subtract(mCreationTimeSpan);
            if (timePassed.TotalMilliseconds > kBallMSecInterval)
            {
                mCreationTimeSpan = gameTime.TotalGameTime;
                BasketBall b = new BasketBall();
                mTotalBallCreated++;
                mBBallList.Add(b);
            }
            #endregion stepd

            #region step e
            //check for winning condition ...
            if (mScore > kWinScore)
                mFinal = new TexturedPrimitive("Winner", new Vector2(75, 50), new Vector2(30, 20));
            else if (mScore < kWinScore)
                mFinal = new TexturedPrimitive("Loser", new Vector2(75, 50), new Vector2(30, 20));
            #endregion step e
        }

        public void Drawgame()
        {
            mHero.Draw();

            foreach (BasketBall b in mBBallList)
            {
                b.Draw();
            }

            if (null != mFinal)
                mFinal.Draw();

            //drawn last to always show up on top
            FontSupport.PrintStatus("Status: " + "Score=" + mScore + " Basketball: Generated( " + mTotalBallCreated + ") Collected(" + mBBallList + ") Missed(" + mBBallMissed + ")", null);
        }
    }
}
