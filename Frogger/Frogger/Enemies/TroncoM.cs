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
    public class TroncoM
    {
         Game game;
        Texture2D enemyTroncoMText;
        Vector2 position;
        public Rectangle rect;
        int speedX;

        public TroncoM(Game game, Vector2 posTroncoM)
        {
            this.game = game;
            this.position = posTroncoM;
            this.rect = new Rectangle((int)this.position.X, (int)this.position.Y, 120, 30);
            this.setEnemyTroncoMText();
            this.speedX = 3;
        }
        public void MoveTroncoM(int speed)
        {
            this.rect.X += speed;
        }

        public void setEnemyTroncoMText()
        {
            this.enemyTroncoMText = this.game.Content.Load<Texture2D>(@"Images/Enemies/troncoM");
        }
        public void Update(GameTime gameTime)
        {
            MoveTroncoM(speedX);

            if (this.rect.X + this.rect.Width > 980)
            {
                this.rect.X = 0 - enemyTroncoMText.Width;
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(this.enemyTroncoMText, this.rect, Color.White);
        }

    }
}
