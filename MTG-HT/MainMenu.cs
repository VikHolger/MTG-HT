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
    Button commander, normmal, back;


    //Variables
    MainMenu_State MMS = MainMenu_State.Start;

    public MainMenu (UI _u)
    {
        _ui = _u;
        MMS = MainMenu_State.Start;

        //Initilasie buttons
        NewGame = new Button(new Vector2(980, 540), new Vector2(1740, 750), "New Game");
        Settings = new Button(new Vector2(1040, 850), new Vector2(1640, 925), "Settings");
            //"New games" button
        back = new Button(new Vector2(1250, 200), new Vector2(1500, 350), "BACK");
        p2 = new Button (new Vector2(825, 500), new Vector2(1025, 700), "2");
        p3 = new Button (new Vector2(1125, 500), new Vector2(1325, 700), "3");
        p4 = new Button (new Vector2(1425, 500), new Vector2(1625, 700), "4");
        p5 = new Button (new Vector2(1725, 500), new Vector2(1925, 700), "5");
        commander = new Button (new Vector2(800, 1000), new Vector2(1300, 1200), "Commander");
        normmal = new Button (new Vector2(1500, 1000), new Vector2(2000, 1200), "Normal");


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
            //"New games" Button
        back.Load(std, butTex);
        p2.Load(std, Ryan);
        p3.Load(std, Ryan);
        p4.Load(std, butTex);
        p5.Load(std, Ryan);
        commander.Load(std, butTex);
        normmal.Load(std, butTex);
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

            p2.clicked(mp, _ui.LMH);
            p3.clicked(mp, _ui.LMH);
            p4.clicked(mp, _ui.LMH);
            p5.clicked(mp, _ui.LMH);

            commander.clicked(mp, _ui.LMH);
            normmal.clicked(mp, _ui.LMH);
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
            p2.Draw(_s);
            p3.Draw(_s);
            p4.Draw(_s);
            p5.Draw(_s);
            commander.Draw(_s);
            normmal.Draw(_s);
        }
    }

}