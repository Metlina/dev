#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using TexturePrimitive.GraphicsSupport;
#endregion

namespace TexturePrimitive
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        static public SpriteBatch sSpriteBatch;         //Drawing support
        static public ContentManager sContent;          //Loading textures
        static public GraphicsDeviceManager sGraphics;  //Current display size

        //preferred windowed size
        const int kWindowWidth = 1000;
        const int kWindowHeight = 700;

        const int kNumObjects = 4;
        //work with the TexturedPrimitive class
        TexturedPrimitive[] mGraphicsObjects;        //array of objects
        int mCurrentIndex = 0;

        public Game1()
            : base()
        {
            // Content resource loading support
            Content.RootDirectory = "Content";
            Game1.sContent = Content;

            // Create graphics device to access window size
            Game1.sGraphics = new GraphicsDeviceManager(this);
            //set preffered windows size
            Game1.sGraphics.PreferredBackBufferWidth = kWindowWidth;
            Game1.sGraphics.PreferredBackBufferHeight = kWindowHeight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Game1.sSpriteBatch = new SpriteBatch(GraphicsDevice);

            //create the primitives
            mGraphicsObjects = new TexturedPrimitive[kNumObjects];
            mGraphicsObjects[0] = new TexturedPrimitive("UWB-JPG", new Vector2(10, 10), new Vector2(30, 30));
            mGraphicsObjects[1] = new TexturedPrimitive("UWB-JPG", new Vector2(200, 200), new Vector2(100, 100));
            mGraphicsObjects[2] = new TexturedPrimitive("UWB-PNG", new Vector2(50, 10), new Vector2(30, 30));
            mGraphicsObjects[3] = new TexturedPrimitive("UWB-PNG", new Vector2(50, 200), new Vector2(100, 100));
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
            //Allows the game to exit
            if (InputWrapper.InputWrapper.Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            //"A" toggle to full screen
            if (InputWrapper.InputWrapper.Buttons.A == ButtonState.Pressed)
            {
                if (!sGraphics.IsFullScreen)
                {
                    sGraphics.IsFullScreen = true;
                    sGraphics.ApplyChanges();
                }
            }
            
            //"B" toggles back to window
            if (InputWrapper.InputWrapper.Buttons.B == ButtonState.Pressed)
            {
                if (sGraphics.IsFullScreen)
                {
                    sGraphics.IsFullScreen = false;
                    sGraphics.ApplyChanges();
                }
            }

            //button X to select the next object to work with
            if (InputWrapper.InputWrapper.Buttons.X == ButtonState.Pressed)
                mCurrentIndex = (mCurrentIndex + 1) % kNumObjects;

            //update currently working object with thumb stick
            mGraphicsObjects[mCurrentIndex].Update(InputWrapper.InputWrapper.ThumbSticks.left, InputWrapper.InputWrapper.ThumbSticks.right);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //clear the background color
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Game1.sSpriteBatch.Begin();     //initialize the drawing support

            //loop over and draw each primitive
            foreach (TexturedPrimitive p in mGraphicsObjects)
            {
                p.Draw();
            }

            Game1.sSpriteBatch.End();       //inform graphics system we are done drawing
            
            base.Draw(gameTime);
        }
    }
}
