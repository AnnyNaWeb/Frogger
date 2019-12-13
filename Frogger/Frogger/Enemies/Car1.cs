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
   public class Car1
    {
       Game game;
        Texture2D enemyCar1Text;
        Vector2 position;
        public Rectangle rect;
        int speedX;

        public Car1(Game game, Vector2 posCa1)
        {
            this.game = game;
            this.position = posCa1;
            this.rect = new Rectangle((int)this.position.X, (int)this.position.Y, 25, 30);
            this.setEnemyCar1Text();
            this.speedX = 4;
        }
        public void MoveCar1(int speed)
        {
            this.rect.X += speed;
        }

        public void setEnemyCar1Text()
        {
            this.enemyCar1Text = this.game.Content.Load<Texture2D>(@"Images/Enemies/car1");
        }
        public void Update(GameTime gameTime)
        {
            MoveCar1(speedX);

            if (this.rect.X + this.rect.Width > 980)
            {
                this.rect.X = 0 - enemyCar1Text.Width;
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(this.enemyCar1Text, this.rect, Color.White);
        }
    }
}
