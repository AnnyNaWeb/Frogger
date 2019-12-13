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
   public class Car3
    {
       Game game;
        Texture2D enemyCar3Text;
        Vector2 position;
        public Rectangle rect;
        int speedX;

        public Car3(Game game, Vector2 posCa3)
        {
            this.game = game;
            this.position = posCa3;
            this.rect = new Rectangle((int)this.position.X, (int)this.position.Y, 35, 30);
            this.setEnemyCar3Text();
            this.speedX = 1;
        }
        public void MoveCar3(int speed)
        {
            this.rect.X += speed;
        }

        public void setEnemyCar3Text()
        {
            this.enemyCar3Text = this.game.Content.Load<Texture2D>(@"Images/Enemies/car3");
        }
        public void Update(GameTime gameTime)
        {
            MoveCar3(speedX);

            if (this.rect.X + this.rect.Width > 835)
            {
                this.rect.X = 0 - enemyCar3Text.Width;
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(this.enemyCar3Text, this.rect, Color.White);
        }
    }
}
