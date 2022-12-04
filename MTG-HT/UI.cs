using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace MTG_HT
{
    class UI
    {
        public bool RMC = false, RMH = false;
        public bool LMC = false, LMH = false;

        public void update ()
        {
            //Uppdate Right mouse
            if (!RMH && Mouse.GetState().RightButton == ButtonState.Pressed) {RMC = true; RMH = true;}
            else if (RMC && RMH && Mouse.GetState().RightButton == ButtonState.Pressed) {RMC = false;}
            else if (Mouse.GetState().RightButton == ButtonState.Released) {RMC =false; RMH = false;}

            //Uppdate Left mouse
            if (!LMH && Mouse.GetState().LeftButton == ButtonState.Pressed) {LMC = true; LMH = true;}
            else if (LMC && LMH && Mouse.GetState().LeftButton == ButtonState.Pressed) {LMC = false;}
            else if (Mouse.GetState().LeftButton == ButtonState.Released) {LMC =false; LMH = false;}
        }
    }

    class Button
    {
        //Variables & more
        public Vector2 UL {get;}
        public Vector2 DR {get;}
        SpriteFont std;
        Texture2D tex;
        string name;
        Color C = Color.White;

        public Button(Vector2 UL, Vector2 DR, string n)
        {
            this.UL = UL;
            this.DR = DR;
            name = n;
        }

        public void Load (SpriteFont s, Texture2D t)
        {
            std = s;
            tex = t;
        }

        public bool clicked (Vector2 mousePos, bool c)
        {
            bool colide = true;
            if (!c)
                colide = false;
            else
            {
                if (UL.X > mousePos.X)
                    colide = false;
                if (UL.Y > mousePos.Y)
                    colide = false;
                if (DR.X < mousePos.X)
                    colide = false;
                if (DR.Y < mousePos.Y)
                    colide = false;
            }

            //Change Collor
            if(colide)
                C = Color.Gray;
            else
                C = Color.White;
            
            return colide;
        }

        public void Draw(SpriteBatch _s)
        {
            _s.Draw(tex, new Rectangle((int)UL.X, (int)UL.Y, (int)(DR.X - UL.X), (int)(DR.Y - UL.Y)), new Rectangle(0, 0, tex.Width, tex.Height), C);
            _s.DrawString(std, name, new Vector2(UL.X + (DR.X - UL.X)/2 - (name.Length*std.Texture.Width/22), UL.Y + ((DR.Y - UL.Y)/2) - (std.LineSpacing/2)), Color.Red);
        }
    }

    class Toogle
    {
        //Variables & more
        public Vector2 UL {get;}
        public Vector2 DR {get;}
        SpriteFont std;
        Texture2D tex;
        string name;
        Color C;

        public Toogle(Vector2 UL, Vector2 DR, string n, bool DefeaultState)
        {
            this.UL = UL;
            this.DR = DR;
            name = n;

            if(DefeaultState)
                C = Color.Gray;
            else
                C = Color.White;
        }

        public void Load (SpriteFont s, Texture2D t)
        {
            std = s;
            tex = t;
        }

        public bool getState()
        {
            if (C == Color.Gray)
                return true;
            else
                return false;
        }

        public void Uppdate (Vector2 mousePos, bool c)
        {
            bool colide = true;
            
            if (UL.X > mousePos.X && c)
                colide = false;
            if (UL.Y > mousePos.Y && c)
                colide = false;
            if (DR.X < mousePos.X && c)
                colide = false;
            if (DR.Y < mousePos.Y && c)
                colide = false;

            //Change Collor
            if(colide && c)
                C = Color.Gray;
            else if (c)
                C = Color.White;
        }

        public void Draw(SpriteBatch _s)
        {
            _s.Draw(tex, new Rectangle((int)UL.X, (int)UL.Y, (int)(DR.X - UL.X), (int)(DR.Y - UL.Y)), new Rectangle(0, 0, tex.Width, tex.Height), C);
            _s.DrawString(std, name, new Vector2(UL.X + (DR.X - UL.X)/2 - (name.Length*std.Texture.Width/22), UL.Y + ((DR.Y - UL.Y)/2) - (std.LineSpacing/2)), Color.Red);
        }
    }
}