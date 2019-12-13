using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Frogger
{
   public class Caminhao
    {
        Game game;
        Texture2D enemyCaminhaoText;
        Vector2 position;
        public Rectangle rect;
        int speedX;

        public Caminhao(Game game, Vector2 posCaminhao)
        {
            this.game = game;
            this.position = posCaminhao;
            this.rect = new Rectangle((int)this.position.X, (int)this.position.Y, 50, 30);
            this.setEnemyCaminhaoText();
            this.speedX = 2;
        }
        public void MoveCaminhao(int speed)
        {
            this.rect.X -= speed;
        }

        public void setEnemyCaminhaoText()
        {
            this.enemyCaminhaoText = this.game.Content.Load<Texture2D>(@"Images/Enemies/caminhao");
        }
        public void Update(GameTime gameTime)
        {
            MoveCaminhao(speedX);

            if (this.rect.X + this.rect.Width < 0)
            {
                this.rect.X = 800 + enemyCaminhaoText.Width;
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(this.enemyCaminhaoText, this.rect, Color.White);
        }
    }
}
