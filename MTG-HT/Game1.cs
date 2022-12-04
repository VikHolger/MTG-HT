using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace MTG_HT;

public class MTG_HT : Game
{
    enum GameState
    {
        MainMenu,
        Game,
        Creddits
    }

    //Classes
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    UI _ui; 
    MainMenu MM;

    //Fonts & Assets
    SpriteFont std;
    Texture2D ButtonTex, Ryan;

    //Variables
    Vector2 MousePos;
    int _width = 0, _height = 0; //Fullscreen

    public MTG_HT()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {

        //Fullscreen
        _width = Window.ClientBounds.Width;
        _height = Window.ClientBounds.Height;

        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        _graphics.HardwareModeSwitch = true;

        _graphics.IsFullScreen = true;
        _graphics.ApplyChanges();

        //Classes
        _ui = new UI();
        MM = new MainMenu(_ui);

        //Initialize
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        //Load Content
        std = this.Content.Load<SpriteFont>("Fonts/SourceCodePro");
        ButtonTex = this.Content.Load<Texture2D>("Sprites/ButtonWhite");
        Ryan = this.Content.Load<Texture2D>("Sprites/Button_Temp");

        //Give texture to classes
        MM.Load(std, ButtonTex, Ryan);

    }

    protected override void Update(GameTime gameTime)
    {
        //Exit game
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        //Uppdate Mousy things
        MouseState mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
        MousePos = new Vector2(mouseState.X, mouseState.Y);

        //Uppdate classes
        _ui.update();
        MM.Uppdate(MousePos);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        //Draw mainscreen
        MM.Draw(_spriteBatch);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
