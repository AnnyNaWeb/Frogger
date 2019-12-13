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
using System.Threading;

namespace Frogger
{
    public class GameManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Game game;
        Game1 game1;
        SpriteFont font;
        public EnemyManager enemy;
        private Player player;
        int aux;
        Rectangle timer; //barra
        Texture2D texture;
        Thread t;
        public bool final;
        float frameRate;
        float tempoFrame;
        // Colisao col;
        public GameManager(Game game): base(game)
        {
            this.aux = GameConfig.tempo;
            this.game = game;
            this.font = this.game.Content.Load<SpriteFont>(@"Fonts\Arial");
            
            this.timer = new Rectangle(470, 545, this.aux, 30);
            this.texture = this.game.Content.Load<Texture2D>(@"Images/Scene/time");
            this.game = game;
            this.player = new Player(game);
            this.final = false;
             t = new Thread(new ThreadStart(Teste));
            t.Start();

        }
      
        public void Teste()
        {
            Console.WriteLine(this.aux);
            int time = this.aux;
            this.aux = this.aux * 2;
      
            for (int i = 0; i <= this.aux--; i++)
            {
                
                this.timer.Width = time*10 ;
                time--;
                Console.WriteLine("Thread {0}", i);
                Thread.Sleep(1000);
              
            }
            final = true;
            
            

        }
       
        public override void Update(GameTime gameTime)
        {/*
            aux += gameTime.ElapsedGameTime.Milliseconds;
            if (aux > 1000)
            {
                GameConfig.tempo--;
                aux = 0;
                //vai diminuindo a barra de acordo o tempo
            }

            if (GameConfig.tempo == 0)
            {
                Console.WriteLine("Perdeu");
                this.game.Exit();
            }*/
            if (final)
            {
                this.game.Exit();
            }
              

            // Colisaon();

            base.Update(gameTime);
        }
       
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;

            sb.Begin();
           frameRate = 1/ (float)gameTime.ElapsedGameTime.TotalSeconds;
            sb.DrawString(this.font, "FPS: " + frameRate, new Vector2(200, 520 ), Color.White);
            sb.DrawString(this.font, "TEMPO", new Vector2(470, 520), Color.White);
            sb.Draw(this.texture, this.timer, Color.White);
            sb.DrawString(font, "SCORE: "+ GameConfig.score.ToString(), new Vector2(30, 520), Color.White);
           // Runtime.getRuntime().availableProcessors();
            sb.End();

            base.Draw(gameTime);
        }

    }
}
