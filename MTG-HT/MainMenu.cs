using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace MTG_HT;

class MainMenu
{
    enum MainMenu_State
    {
        Start,
        NewGame,
        Settings
    }

    //Classes
    private SpriteBatch _spriteBatch;
    UI _ui; 

    //Fonts & Assets
    SpriteFont std;
    Texture2D butTex, Ryan;

    //Buttons & TBA
    Button NewGame, Settings;
    Button p2, p3, p4, p5;
    Button commander, startgame, back;


    //Variables
    MainMenu_State MMS = MainMenu_State.Start;

    public MainMenu (UI _u)
    {
        _ui = _u;
        MMS = MainMenu_State.Start;

        //Initilasie buttons
        NewGame = new Button(new Vector2(980, 540), new Vector2(1740, 750), "New Game");
        Settings = new Button(new Vector2(1040, 850), new Vector2(1640, 925), "Settings");

        back = new Button(new Vector2(1290, 200), new Vector2(1500, 350), "BACK");

    }

    public void Load(SpriteFont s,  Texture2D b, Texture2D r)
    {
        //Get textures
        std = s;
        butTex = b;
        Ryan = r;

        //Load textures to buttons
        NewGame.Load(std, butTex);
        Settings.Load(std, Ryan);
        back.Load(std, butTex);
    }

    public void Uppdate(Vector2 mp)
    {
        if (MMS == MainMenu_State.Start)
        {
            if(NewGame.clicked(mp, _ui.LMH)) //Change state
                MMS = MainMenu_State.NewGame;
            Settings.clicked(mp, _ui.LMH); //Change state
        }
        else if (MMS == MainMenu_State.NewGame)
        {
            if(back.clicked(mp, _ui.LMH)) //Change state
                MMS = MainMenu_State.Start;
        }
    }

    public void Draw(SpriteBatch _s)
    {
        if (MMS == MainMenu_State.Start)
        {
            NewGame.Draw(_s);
            Settings.Draw(_s);
        }
        else if (MMS == MainMenu_State.NewGame)
        {
            back.Draw(_s);
        }
    }

}