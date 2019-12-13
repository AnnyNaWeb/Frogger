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
    public class Turtle
    {
        public Texture2D enemyTurtleText;
        Point tamanhoFoto;
        Point fotoAtual; 
        Point tamanho;
        public Rectangle rect;
        public Vector2 posicaoFoto;
        Game game;
        int speedX;
       
        float temporizador;
        float intervalo; 
        public Turtle(Game game, Vector2 posTurtle, int qnt)
        {
            this.game = game;
            this.rect = new Rectangle((int)this.posicaoFoto.X, (int)this.posicaoFoto.Y, 180, 30);
            if (qnt == 2)
            { this.tamanhoFoto = new Point(65, 27); }
            else this.tamanhoFoto= new Point(100, 27);
             this.fotoAtual = new Point(0, 0);
             this.tamanho = new Point(1, 2);
             this.posicaoFoto = posTurtle;//new Vector2(810, 230);
             this.setEnemyTurtleText();
             this.temporizador = 0f;
             this.intervalo = 1000f/1.5f;
             this.speedX = 50;
        
        }

        public void setEnemyTurtleText()
        {
            this.enemyTurtleText = this.game.Content.Load<Texture2D>(@"Images/Enemies/turtles");
        }
        public void Update(GameTime gameTime)
        {
            temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            
            if (temporizador > intervalo)
            {
                ++fotoAtual.X;
                if (fotoAtual.X >= tamanho.X)
                {
                    fotoAtual.X = 0;
                    ++fotoAtual.Y;
                    if (fotoAtual.Y >= tamanho.Y)
                        fotoAtual.Y = 0;
                }
                posicaoFoto.X -= speedX;
                temporizador = 0f;
            }
            if (posicaoFoto.X + tamanhoFoto.X < 0)
            {
                posicaoFoto.X = 810;
            }
            
        }
        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(enemyTurtleText, posicaoFoto,
            new Rectangle(fotoAtual.X * tamanhoFoto.X, fotoAtual.Y * tamanhoFoto.Y,
             tamanhoFoto.X, tamanhoFoto.Y), Color.White, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 0);
        }
       
    }
}
