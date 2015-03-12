#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace InputWrapper
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager mGraphics;
        SpriteBatch mSpriteBatch;

        //support for loading and drawing the JPG image
        Texture2D mJPGImage;    //the UWB-JPG.jpg image to be loaded
        Vector2 mJPGPosition;   //Top-left pixel position of UWB-JPG.jpg

        //support for loading and drawing the PNG image
        Texture2D mPNGImage;    //the UWB-PNG.png image to be loaded
        Vector2 mPGNPosition;   //Top-left pixel position of UWB-PNG.png

        public Game1()
            : base()
        {
            mGraphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Initialize the initial image position
            mJPGPosition = new Vector2(10f, 10f);
            mPGNPosition = new Vector2(100f, 100f);

            //Important to let the base class perform its initialization
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            mSpriteBatch = new SpriteBatch(GraphicsDevice);

            //load the images
            mJPGImage = Content.Load<Texture2D>("UWB-JPG");
            mPNGImage = Content.Load<Texture2D>("UWB-PNG");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //allow the game to exit
            if (InputWrapper.Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //update the image position with left/right thumbsticks
            mJPGPosition += InputWrapper.ThumbSticks.left;
            mPGNPosition += InputWrapper.ThumbSticks.right;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //clear to background color
            GraphicsDevice.Clear(Color.CornflowerBlue);

            mSpriteBatch.Begin();   //initialize drawing support

            //draw the JPG image
            mSpriteBatch.Draw(mJPGImage, mJPGPosition, Color.White);

            //draw the PNG image
            mSpriteBatch.Draw(mPNGImage, mPGNPosition, Color.White);

            mSpriteBatch.End();     //inform graphic system we are done drawing

            base.Draw(gameTime);
        }
    }
}
