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

namespace Lecture6Examples
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Lecture6ExampleGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private SpriteFont _arialFont;
        private float _textHeight;

        private MouseState _mouseState;
        private Vector2 _mousePos;
        private string _mouseInfo;
        private Vector2 _mouseInfoTextSize;

        public Lecture6ExampleGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _arialFont = Content.Load<SpriteFont>("Arial");
            _textHeight = _arialFont.MeasureString("H").Y;

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _mouseState = Mouse.GetState();
            _mousePos = new Vector2(_mouseState.X, _mouseState.Y);
            _mouseInfo = _mousePos.ToString();
            _mouseInfoTextSize = _arialFont.MeasureString(_mouseInfo);
            _mouseInfoTextSize.X = _mouseInfoTextSize.X / 2.0f;
            _mouseInfoTextSize.Y = 0;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.DrawString(_arialFont, "Hello world!",Vector2.Zero, Color.Pink);
            spriteBatch.DrawString(_arialFont,_mouseInfo, _mousePos - _mouseInfoTextSize, Color.Red);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}