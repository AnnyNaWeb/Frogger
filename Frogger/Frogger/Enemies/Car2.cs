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
   public class Car2
    {
        Game game;
        Texture2D enemyCar2Text;
        Vector2 position;
        public Rectangle rect;
        int speedX;

        public Car2(Game game, Vector2 posCa2)
        {
            this.game = game;
            this.position = posCa2;
            this.rect = new Rectangle((int)this.position.X, (int)this.position.Y, 35, 30);
            this.setEnemyCar2Text();
            this.speedX = 1;
        }
        public void MoveCar2(int speed)
        {
            this.rect.X -= speed;
        }

        public void setEnemyCar2Text()
        {
            this.enemyCar2Text = this.game.Content.Load<Texture2D>(@"Images/Enemies/car2");
        }
        public void Update(GameTime gameTime)
        {
            MoveCar2(speedX);

            if (this.rect.X + this.rect.Width < 0)
            {
                this.rect.X = 800 + enemyCar2Text.Width;
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(this.enemyCar2Text, this.rect, Color.White);
        }
    }
}
