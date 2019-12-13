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
    public class TroncoP
    {
        Game game;
        Texture2D enemyTroncoPText;
        Vector2 position;
        public Rectangle rect;
        int speedX;
      
        public TroncoP(Game game, Vector2 posTroncoP)
        {
            this.game = game;
            this.position = posTroncoP;
            this.rect = new Rectangle((int)this.position.X, (int)this.position.Y, 80, 25);
            this.setEnemyTroncoPText();
            this.speedX = 2;
        }
        public void MoveTroncoP(int speed)
        {
            this.rect.X += speed;
        }

        public void setEnemyTroncoPText()
        {
            this.enemyTroncoPText = this.game.Content.Load<Texture2D>(@"Images/Enemies/troncoP");
        }
        public void Update(GameTime gameTime)
        {
            MoveTroncoP(speedX);

            if (this.rect.X + this.rect.Width > 890)
            {
                this.rect.X = 0 - enemyTroncoPText.Width;
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(this.enemyTroncoPText, this.rect, Color.White);
        }

    }
}
