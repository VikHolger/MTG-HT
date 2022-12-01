using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MTG_HT;

public class MTG_HT : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    UI _ui; 
    Button A;

    int _width = 0;
    int _height = 0;
    string temp = "";
    Vector2 MousePos;
    SpriteFont font;
    Texture2D Ryan; // A naughty Temp

    public MTG_HT()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _ui = new UI();

        _width = Window.ClientBounds.Width;
        _height = Window.ClientBounds.Height;

        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        _graphics.HardwareModeSwitch = true;

        _graphics.IsFullScreen = true;
        _graphics.ApplyChanges();

        A = new Button(new Vector2(500, 500), new Vector2(750, 750));

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        font = this.Content.Load<SpriteFont>("Fonts/SourceCodePro");
        Ryan = this.Content.Load<Texture2D>("Sprites/Button_Temp");
    }

    protected override void Update(GameTime gameTime)
    {
        _ui.update();

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        MouseState mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
        MousePos = new Vector2(mouseState.X, mouseState.Y);

        if (_ui.LMH)
            temp = A.clicked(MousePos).ToString();
        else
            temp = "False";

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _spriteBatch.DrawString(font, "Mouse Position: " + MousePos.X + " " + MousePos.Y, new Vector2(50, 50), Color.Red);
        _spriteBatch.DrawString(font, "RM: " + _ui.RMC.ToString() + _ui.RMH.ToString() + " LM: " + _ui.LMC.ToString() + _ui.LMH.ToString(), new Vector2(50, 100), Color.Red);
        _spriteBatch.DrawString(font, "Buuton is pressed?: " + temp, new Vector2(50, 150), Color.Red);

        _spriteBatch.Draw(Ryan, new Rectangle((int)A.UL.X, (int)A.UL.Y, (int)(A.DR.X - A.UL.X), (int)(A.DR.Y - A.UL.Y)), new Rectangle(0, 0, Ryan.Width, Ryan.Height), Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
