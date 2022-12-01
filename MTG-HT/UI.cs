using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
        public Vector2 UL {get;}
        public Vector2 DR {get;}

        public Button(Vector2 UL, Vector2 DR)
        {
            this.UL = UL;
            this.DR = DR;
        }

        public bool clicked (Vector2 mousePos)
        {
            bool colide = true;

            if (UL.X > mousePos.X)
                colide = false;
            if (UL.Y > mousePos.Y)
                colide = false;
            if (DR.X < mousePos.X)
                colide = false;
            if (DR.Y < mousePos.Y)
                colide = false;
            
            return colide;
        }
    }
}