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

namespace FontOutput.GraphicsSupport
{
    static class FontSupport
    {
        static private SpriteFont sTheFont = null;
        static private Color sDefaultColor = Color.Black;
        static private Vector2 sStatusLocation = new Vector2(5, 5);

        static private void LoadFont()
        {
            if (null == sTheFont)
                sTheFont = Game1.sContent.Load<SpriteFont>("Arial");
        }

        static private Color ColorToUse(Nullable<Color> c)
        {
            return (null == c) ? sDefaultColor : (Color)c;
        }

        static public void PrintStatus(String msg, Nullable<Color> drawColor)
        {
            LoadFont();
            Color useColor = ColorToUse(drawColor);

            //compute top left corner as the reference for output status
            Game1.sSpriteBatch.DrawString(sTheFont, msg, sStatusLocation, useColor);
        }

        static public void PrintStatusAt(Vector2 pos, String msg, Nullable<Color> drawColor)
        {
            LoadFont();

            Color useColor = ColorToUse(drawColor);

            int pixelX, pixelY;
            Camera.ComputePixelPosition(pos, out pixelX, out pixelY);
            Game1.sSpriteBatch.DrawString(sTheFont, msg, new Vector2(pixelX, pixelY), useColor);
        }
    }
}
