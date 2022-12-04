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

    //Temp
    Button A;
    string temp = "";

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

        //Temp
        A = new Button(new Vector2(500, 500), new Vector2(750, 750), "Test");

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

        A.Load(std, ButtonTex);
    }

    protected override void Update(GameTime gameTime)
    {
        _ui.update();
        MM.Uppdate(MousePos);

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        MouseState mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
        MousePos = new Vector2(mouseState.X, mouseState.Y);

        temp = A.clicked(MousePos, _ui.LMH).ToString();


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _spriteBatch.DrawString(std, "Mouse Position: " + MousePos.X + " " + MousePos.Y, new Vector2(50, 50), Color.Red);
        _spriteBatch.DrawString(std, "RM: " + _ui.RMC.ToString() + _ui.RMH.ToString() + " LM: " + _ui.LMC.ToString() + _ui.LMH.ToString(), new Vector2(50, 100), Color.Red);
        _spriteBatch.DrawString(std, "Buton is pressed?: " + temp, new Vector2(50, 150), Color.Red);

        A.Draw(_spriteBatch);

        MM.Draw(_spriteBatch);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
