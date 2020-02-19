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
        //Added for animation
        Texture2D animateplayer;
        Rectangle animateRect;
        int animateCount = 0;
        int animateSpeed = 10;
        int animateNumPics = 3;
        Texture2D player1;
        Texture2D player2;
        Texture2D player3;
        Texture2D player4;
        Texture2D player5;
        Texture2D fplayer1;
        Texture2D fplayer2;
        Texture2D fplayer3;
        Texture2D fplayer4;
        Texture2D fplayer5;

        //enemy stuff
        Texture2D chef1Text;
        Rectangle chef1Rect;

        //variables
        int state = 0;

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
            playerRect = new Rectangle(100, 100, 100, 100);
            //animateRect = new Rectangle(100, 300, 24, 59);
            animateSpeed = 20;
            animateNumPics = 3;
            animateCount = 0;


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
            
            player1 = Content.Load<Texture2D>("pizzasteve1");
            player2 = Content.Load<Texture2D>("pizzasteve2");
            player3 = Content.Load<Texture2D>("pizzasteve3");
            player4 = Content.Load<Texture2D>("pizzasteve4");
            player5 = Content.Load<Texture2D>("pizzasteve5");
            fplayer1 = Content.Load<Texture2D>("fpizzasteve1");
            fplayer2 = Content.Load<Texture2D>("fpizzasteve2");
            fplayer3 = Content.Load<Texture2D>("fpizzasteve3");
            fplayer4 = Content.Load<Texture2D>("fpizzasteve4");
            fplayer5 = Content.Load<Texture2D>("fpizzasteve5");

            playerText = player1;


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
                spriteBatch.Draw(playerText, animateRect, Color.White);
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
                Lanimatecode();
            }
            if (kb.IsKeyDown(Keys.W))
            {
                playerRect.Y -= 5;
            }
            if (kb.IsKeyDown(Keys.D))
            {
                playerRect.X += 5;
                Ranimatecode();
            }
            if (kb.IsKeyDown(Keys.S))
            {
                playerRect.Y += 5;
            }
            
        }
        private void Ranimatecode()
        {
            animateCount++;
            if (animateCount < animateSpeed)
            {
                playerText = player1;
            }
            else if (animateCount < animateSpeed * 1.2)
            {
                playerText = player3;
            }
            else if (animateCount < animateSpeed * 1.4)
            {
                playerText = player2;
            }
            else if (animateCount < animateSpeed * 1.6)
            {
                playerText = player3;
            }
            else if (animateCount < animateSpeed * 1.8)
            {
                playerText = player4;
            }
            else if (animateCount < animateSpeed * 2)
            {
                playerText = player5;
            }
            else if (animateCount < animateSpeed * 2.2)
            {
                playerText = player4;
            }
            //else if (animateCount < animateSpeed * 2.4)
            //{
               // playerText = player1;
            //}
            else
            {
                animateCount = 0;
            }

        }
        private void Lanimatecode()
        {
            animateCount++;
            if (animateCount < animateSpeed)
            {
                playerText = fplayer1;
            }
            else if (animateCount < animateSpeed * 1.2)
            {
                playerText = fplayer3;
            }
            else if (animateCount < animateSpeed * 1.4)
            {
                playerText = fplayer2;
            }
            else if (animateCount < animateSpeed * 1.6)
            {
                playerText = fplayer3;
            }
            else if (animateCount < animateSpeed * 1.8)
            {
                playerText = fplayer4;
            }
            else if (animateCount < animateSpeed * 2)
            {
                playerText = fplayer5;
            }
            else if (animateCount < animateSpeed * 2.2)
            {
                playerText = fplayer4;
            }
            //else if (animateCount < animateSpeed * 2.4)
            //{
            // playerText = player1;
            //}
            else
            {
                animateCount = 0;
            }
        }
    }
}
