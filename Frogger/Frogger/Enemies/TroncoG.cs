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
   public class TroncoG
    {
        
        Game game;
        Texture2D enemyTroncoGText;
       public Vector2 position;
        public Rectangle rect;
        int speedX;
      
        public TroncoG(Game game, Vector2 posTroncoG)
        {
            this.game = game;
            this.position = posTroncoG;
            this.rect = new Rectangle((int)this.position.X, (int)this.position.Y, 180, 30);
            this.setEnemyTroncoGText();
            this.speedX = 4;
        }
        public void MoveTroncoG(int speed)
        {
            this.rect.X += speed;
        }

        public void setEnemyTroncoGText()
        {
            this.enemyTroncoGText = this.game.Content.Load<Texture2D>(@"Images/Enemies/troncoG");
        }
        public void Update(GameTime gameTime)
        {
            MoveTroncoG(speedX);

            if (this.rect.X + this.rect.Width > 980)
            {
                this.rect.X = 0 - enemyTroncoGText.Width;
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(this.enemyTroncoGText, this.rect, Color.White);
        }

    }
}
