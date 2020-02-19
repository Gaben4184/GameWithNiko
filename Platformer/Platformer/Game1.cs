using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //player stuff
        Texture2D playerText;
        Rectangle playerRect;

        //enemy stuff
        Texture2D chef1Text;
        Rectangle chef1Rect;

        //variables
        int state = 0;
        int lives;

        //states
        Texture2D startText;
        Rectangle startRect;


        KeyboardState oldKB;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            //window
            this.graphics.PreferredBackBufferWidth = 1200;
            this.graphics.PreferredBackBufferHeight = 800;
            this.graphics.ApplyChanges();

            //states
            startRect = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            state = 1;

            //player stuff 
            lives = 3;
            playerRect = new Rectangle(100, 100, 100, 100);

            //enemy stuff 
            chef1Rect = new Rectangle(200, 200, 100, 100);

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

            //state stuff
            startText = Content.Load<Texture2D>("Meme5");

            //player stuff
            playerText = Content.Load<Texture2D>("pizzasteve1");

            //enemy stuff 
            chef1Text = Content.Load<Texture2D>("chef1");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (state == 1)
            {
                KeyboardState kb = Keyboard.GetState();
                if (kb.IsKeyDown(Keys.Space) && oldKB.IsKeyUp(Keys.Space))
                {
                    state = 2;
                }
            }
            if (state == 2)
            {
                checkKeys();
                checkCollisions();
            }



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (state == 1)
            {
                spriteBatch.Draw(startText, startRect, Color.White);
            }
            if (state == 2)
            {
                spriteBatch.Draw(playerText, playerRect, Color.White);
                spriteBatch.Draw(chef1Text, chef1Rect, Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void checkKeys()
        {
            //Game controls
            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.A))
            {
                playerRect.X -= 5;
            }
            if (kb.IsKeyDown(Keys.W))
            {
                playerRect.Y -= 5;
            }
            if (kb.IsKeyDown(Keys.D))
            {
                playerRect.X += 5;
            }
            if (kb.IsKeyDown(Keys.S))
            {
                playerRect.Y += 5;
            }
        }
        private void checkCollisions()
        {
            if (playerRect.Intersects (chef1Rect))
            {
                playerRect.Location = new Point(0, 0);
                lives -= 1;
            }
        }
    }
}
