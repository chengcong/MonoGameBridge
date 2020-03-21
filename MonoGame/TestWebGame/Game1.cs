using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TestWebGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        Retyped.dom.HTMLDivElement divdata;
        GraphicsDeviceManager graphics;
        Song song;
        MouseState prevstate;
        bool playing;
        KeyboardState prevkstate;
        SpriteBatch spriteBatch;
        Texture2D texBall;
        SoundEffect _seffect;
        SoundEffectInstance _sinstance;
        Model _model;
        bool loading = true;
        SpriteFont font;
        
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
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // effect = await Content.LoadAsync<Effect>("effect");

            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            divdata = Retyped.dom.document.getElementById("testoutput") as Retyped.dom.HTMLDivElement;

            MediaPlayer.Volume = 0.1f;

            LoadContentAsync();
        }

        public async void LoadContentAsync()
        {
            song = await Content.LoadAsync<Song>("awake");
            // font = await Content.LoadAsync<SpriteFont>("File");
            texBall = await Content.LoadAsync<Texture2D>("hacker");
            // Texture2D.FromURL(GraphicsDevice, "Content/Hacker.png");
            //_seffect = Content.Load<SoundEffect>("horse");
            // _model = await Content.LoadAsync<Model>("helicopter");

            loading = false;

            MediaPlayer.Play(song);
            playing = true;
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
            if (loading)
                return;

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var state = Mouse.GetState();
            var kstate = Keyboard.GetState();
            var jstate = Joystick.GetState(0);
            var gstate = GamePad.GetState(0);

            if (prevstate.RightButton == ButtonState.Released && state.RightButton == ButtonState.Pressed)
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }

            if (prevkstate.IsKeyUp(Keys.M) && kstate.IsKeyDown(Keys.M))
            {
                if (playing)
                    MediaPlayer.Pause();
                else
                    MediaPlayer.Resume();

                playing = !playing;
            }

            if (prevkstate.IsKeyUp(Keys.S) && kstate.IsKeyDown(Keys.S))
                _seffect.Play();

            divdata.innerHTML = "Left: " + state.LeftButton + "<br>Right: " + state.RightButton + "<br>Mouse pos: " + state.Position + "<br>A: " + kstate.IsKeyDown(Keys.A) + "<br>Caps: " + kstate.CapsLock;

            prevstate = state;
            prevkstate = kstate;

            base.Update(gameTime);
        }

        int frame = 0;
        int frameCounter = 0;
        int _lastTime = 0;

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (loading)
            {
                GraphicsDevice.Clear(Color.YellowGreen);
                return;
            }

            if (gameTime.TotalGameTime.Seconds > _lastTime)
            {
                _lastTime = gameTime.TotalGameTime.Seconds;
                frame = frameCounter;
                frameCounter = 0;
            }
            else
            {
                frameCounter++;
            }

            //GraphicsDevice.SetRenderTarget(target);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(texBall, new Rectangle(0, 0, 100, 100), new Rectangle(50, 50, 100, 100), Color.White);
            // spriteBatch.DrawString(font, "Fps: " + frame + System.Environment.NewLine + "Well spritefonts are working as well...", Vector2.Zero, Color.White);
            spriteBatch.End();
            //GraphicsDevice.SetRenderTarget(null);

            /*spriteBatch.Begin();
            spriteBatch.Draw(target, new Rectangle(0, 0, 640, 480), Color.White);
            spriteBatch.End();*/

            base.Draw(gameTime);
        }
    }
}
