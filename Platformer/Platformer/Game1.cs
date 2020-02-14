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

        //Player pizza
        Texture2D playerText;
        Rectangle playerRect;

        //Enemy stuff
        Texture2D chef1Text;
        Rectangle chef1Rect;

        //pizzasteve animations
        Texture2D pizzasteve1;
        Texture2D pizzasteve2;
        Texture2D pizzasteve3;
        Texture2D animateSteve;
        Rectangle animateRect;
        int animateCount = 0;
        int animateSpeed = 10;
        int animateNumPics = 3;
        //variables
        KeyboardState oldKB;
        int state = 0;
        int speed;
        int Lives;


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
            //background
            this.graphics.PreferredBackBufferWidth = 1200;
            this.graphics.PreferredBackBufferHeight = 800;
            this.graphics.ApplyChanges();

            startRect = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            speed = 5;

            playerRect = new Rectangle(300, 300, 50, 59);
            chef1Rect = new Rectangle(500, 300, 100, 100);
            animateRect = new Rectangle(100, 300, 50, 50);
            animateSpeed = 20;
            animateNumPics = 3;
            animateCount = 0;
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

            //Background
            startText = Content.Load<Texture2D>("Meme5");

            //player textures
            playerText = Content.Load<Texture2D>("pizzasteve1");

            //enemy textures
            chef1Text = Content.Load<Texture2D>("chef1");
            pizzasteve1 = Content.Load<Texture2D>("pizzasteve1");
            pizzasteve2 = Content.Load<Texture2D>("pizzasteve2");
            pizzasteve3 = Content.Load<Texture2D>("pizzasteve3"); 
            playerText = pizzasteve1;

            //variables
            state = 1;
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
                checkCollision();
                checkLives();
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
                Color col1 = new Color(168, 9, 9, 255);
                
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
            if (kb.IsKeyDown(Keys.A) && oldKB.IsKeyUp(Keys.A))
            {
                playerRect.X -= 50;
                animateCount++;
                if (animateCount < animateSpeed)
                {
                    playerText = pizzasteve1;
                }
                else if (animateCount < animateSpeed * 2)
                {
                    playerText = pizzasteve2;
                }
                else if (animateCount < animateSpeed * 3)
                {
                    playerText = pizzasteve3;
                }
                else
                {
                    animateCount = 0;
                }
            }
            if (kb.IsKeyDown(Keys.W) && oldKB.IsKeyUp(Keys.W))
            {
                playerRect.Y -= 50;
            }
            if (kb.IsKeyDown(Keys.D) && oldKB.IsKeyUp(Keys.D))
            {
                playerRect.X += 50;
                animateCount++;
                if (animateCount < animateSpeed)
                {
                    playerText = pizzasteve1;
                }
                else if (animateCount < animateSpeed * 2)
                {
                    playerText = pizzasteve2;
                }
                else if (animateCount < animateSpeed * 3)
                {
                    playerText = pizzasteve3;
                }
                else
                {
                    animateCount = 0;
                }
            }
            if (kb.IsKeyDown(Keys.S) && oldKB.IsKeyUp(Keys.S))
            {
                playerRect.Y += 50;
            }
            oldKB = kb;
        }
        private void checkCollision()
        {
            if (playerRect.Intersects(chef1Rect))
            {
                playerRect.Location = new Point(375, 550);
                Lives -= 1;
            }
            /*if (playerRect.Intersects(car2Rect))
            {
                playerRect.Location = new Point(375, 550);
                Lives -= 1;
            }
            if (playerRect.Intersects(car3Rect))
            {
                playerRect.Location = new Point(375, 550);
                Lives -= 1;
            }
            
            if (playerRect.Intersects(appleRect))
            {
                state = 4;
            }
            */
        }
        private void checkLives()
        {
            if (Lives == 0)
            {
                state = 3;
            }

        }
    }
}
