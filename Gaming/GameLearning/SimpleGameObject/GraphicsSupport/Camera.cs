using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BookExample
{
    /// <summary>
    /// The camera class: a static class, meant to only allow one camera.
    /// </summary>
    static public class Camera
    {
        static private Vector2 sOrigin = Vector2.Zero;      // Origin of the world
        static private float sWidth = 100f;                 // Width of the world
        static private float sRatio = -1f;                  // Ratio between camera window and pixel 
        static private float sHeight = -1f;

        /// <summary>
        /// Computes the transformation ratio
        /// </summary>
        static private float cameraWindowToPixelRatio()
        {
            if (sRatio < 0f)
            {
                sRatio = (float)Game1.sGraphics.PreferredBackBufferWidth / sWidth;
                sHeight = sWidth * (float)Game1.sGraphics.PreferredBackBufferHeight / (float)Game1.sGraphics.PreferredBackBufferWidth;
            }
            return sRatio;
        }

        /// <summary>
        /// Sets the window visible by the camera
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="width"></param>
        static public void SetCameraWindow(Vector2 origin, float width)
        {
            sOrigin = origin;
            sWidth = width;
            cameraWindowToPixelRatio();
        }

        /// <summary>
        /// Compute pixel position for cameraPosition
        /// </summary>
        /// <param name="cameraPosition">Input position in camera window</param>
        /// <param name="x">output pixel x-position </param>
        /// <param name="y">output pixel y-position </param>
        static public void ComputePixelPosition(Vector2 cameraPosition, out int x, out int y)
        {
            float ratio = cameraWindowToPixelRatio();

            // Convert the position to pixel space
            x = (int)(((cameraPosition.X - sOrigin.X) * ratio) + 0.5f);
            y = (int)(((cameraPosition.Y - sOrigin.Y) * ratio) + 0.5f);

            y = Game1.sGraphics.PreferredBackBufferHeight - y;
        }

        /// <summary>
        /// Computes the pixel rectangle to be displayed
        /// </summary>
        /// <param name="position">In Camera Window Space</param>
        /// <param name="size">In camera Window Space</param>
        /// <returns></returns>
        static public Rectangle ComputePixelRectangle(Vector2 position, Vector2 size)
        {
            float ratio = cameraWindowToPixelRatio();

            // Convert size from Camera Window Space to pixel space
            int width = (int)((size.X * ratio) + 0.5f);
            int height = (int)((size.Y * ratio) + 0.5f);

            // Convert the position to pixel space
            int x, y;
            ComputePixelPosition(position, out x, out y);

            // Reference position is the center
            y -= height / 2;
            x -= width / 2;

            return new Rectangle(x, y, width, height);
        }

        //accessors to the camera window bounds
        static public Vector2 CameraWindowLoverLeftPosition { get { return sOrigin; } }
        static public Vector2 CameraWindowUpperRightPosition { get { return sOrigin + new Vector2(sWidth, sHeight); } }

        //support collision with the camera bounds
        public enum CameraWindowCollisitonStatus
        {
            CollideTop = 0,
            CollideBottom = 1,
            CollideLeft = 2,
            CollideRight = 3,
            InsideWindow = 4
        };

        static public CameraWindowCollisitonStatus ColideWidthCameraWidnow(TexturedPrimitive prim)
        {
            Vector2 min = CameraWindowLoverLeftPosition;
            Vector2 max = CameraWindowUpperRightPosition;

            if (prim.MaxBound.Y > max.Y)
                return CameraWindowCollisitonStatus.CollideTop;
            if (prim.MinBound.X < min.X)
                return CameraWindowCollisitonStatus.CollideLeft;
            if (prim.MaxBound.X > max.X)
                return CameraWindowCollisitonStatus.CollideRight;
            if (prim.MinBound.Y < min.Y)
                return CameraWindowCollisitonStatus.CollideBottom;

            return CameraWindowCollisitonStatus.InsideWindow;
        }
    }
}
