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
using BookExample;

namespace UserDefinedCooridnateSystem.GraphicsSupport
{
    static public class Camera
    {
        static private Vector2 sOrigin = Vector2.Zero;  //Origin of the world
        static private float sWidht = 100f;             //Widht of the world
        static private float sRatio = -1f;              //Ration between camera window and pixel


        static private float cameraWindowToPixelRation()
        {
            if (sRatio < 0f)
                sRatio = (float)Game1.sGraphics.PreferredBackBufferWidth / sWidht;
            return sRatio;
        }

        static public void SetCameraWindow(Vector2 origin, float widht)
        {
            sOrigin = origin;
            sWidht = widht;
        }

        static public void ComputePixelPosition(Vector2 cameraPosition, out int x, out int y)
        {
            float ration = cameraWindowToPixelRation();

            //convert position to pixel size
            x = (int)(((cameraPosition.X - sOrigin.X) * ration) + 0.5f);
            y = (int)(((cameraPosition.Y - sOrigin.Y) * ration) + 0.5f);

            y = Game1.sGraphics.PreferredBackBufferHeight - y;
        }

        static public Rectangle ComputePixelRectangle(Vector2 position, Vector2 size)
        {
            float ration = cameraWindowToPixelRation();

            //convert size from camera window space to pixel space
            int width = (int)((size.X * ration) + 0.5f);
            int height = (int)((size.Y * ration) + 0.5f);

            //convert the position to pixel space
            int x, y;
            ComputePixelPosition(position, out x, out y);

            //reference position is the center
            y -= height / 2;
            x -= width / 2;

            return new Rectangle(x, y, width, height);
        }
    }
}
