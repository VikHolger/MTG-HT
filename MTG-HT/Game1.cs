using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MTG_HT;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    int _width = 0;
    int _height = 0;
    Vector2 MousePos;
    SpriteFont font;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        

        _width = Window.ClientBounds.Width;
        _height = Window.ClientBounds.Height;

        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        _graphics.HardwareModeSwitch = true;

        _graphics.IsFullScreen = true;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        font = this.Content.Load<SpriteFont>("Fonts/SourceCodePro");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        MouseState mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
        MousePos = new Vector2(mouseState.X, mouseState.Y);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _spriteBatch.DrawString(font, "Mouse Position: " + MousePos.X + " " + MousePos.Y, new Vector2(50, 50), Color.Red);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
