using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BookExample
{
    class ChaserGameObject : GameObject
    {
        //the target to go toward
        protected TexturedPrimitive mTarget;
        //have we hit the target yet?
        protected bool mHitTarget;
        //how rapidly the chaser homes in on the target
        protected float mHomeInRate;

        public ChaserGameObject(String imageName, Vector2 position, Vector2 size, TexturedPrimitive target)
            : base(imageName, position, size, null)
        {
            Target = target;
            mHomeInRate = 0.05f;
            mHitTarget = false;
            mSpeed = 0.1f;
        }

        public void ChaseTarget()
        {
            #region step a : check for null target and calls the base update function
            if (null == mTarget)
                return;
            //move the GameObject in the velocity direction
            base.Update();
            #endregion

            #region step b
            mHitTarget = PrimitivesTouches(mTarget);

            if (!mHitTarget)
            {
                #region calculate angle
                Vector2 targetDir = mTarget.Position - Position;
                float distTotargetSq = targetDir.LengthSquared();

                targetDir /= (float)Math.Sqrt(distTotargetSq);
                float cosTheta = Vector2.Dot(FrontDirection, targetDir);
                float theta = (float)Math.Acos(cosTheta);
                #endregion

                #region calculate rotation direction
                if (theta > float.Epsilon)
                {
                    //not quite aligned ...
                    Vector3 fIn3D = new Vector3(FrontDirection, 0f);
                    Vector3 tIn3D = new Vector3(targetDir, 0f);
                    Vector3 sing = Vector3.Cross(tIn3D, fIn3D);

                    RotateAngleInRadian += Math.Sign(sing.Z) * theta * mHomeInRate;
                    VelocityDirection = FrontDirection;
                }
                #endregion
            }
            #endregion
        }

        public float HomeInRate { get { return mHomeInRate; } set { mHomeInRate = value; } }
        public bool HitTarget { get { return mHitTarget; } }
        public bool HasValidTarget { get { return null != mTarget; } }

        public TexturedPrimitive Target
        {
            get { return mTarget; }
            set
            {
                mTarget = value;
                mHitTarget = false;
                if (null != mTarget)
                {
                    FrontDirection = mTarget.Position - Position;
                    VelocityDirection = FrontDirection;
                }
            }
        }
    }
}
