using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.Threading;


namespace Frogger
{
    public class Player : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Game game;
        Texture2D player;
        private Vector2 position;
        public Rectangle rect;
        private bool apertou;
        private int time;
        private string[] playerText;
        int index;

       // Thread doCaralho;
        bool[] homes;
        Thread move;
        bool sobe;
        bool vira;
        Thread render;
        public Texture2D inHome; //sapo imagem
        public Rectangle[] rectHome; //onde o sapo vai ficar

        public Player(Game game) :base(game)
        {
            this.game = game;

            
        }



        public void setPlayerText()
        {
            #region Player Textures

            this.playerText[0] = @"Images/Player/player-up";
            this.playerText[1] = @"Images/Player/player-down";
            this.playerText[2] = @"Images/Player/player-left";
            this.playerText[3] = @"Images/Player/player-right";
            this.playerText[4] = @"Images/Player/sapo-v";

            #endregion
        }

        public void setHomePosition()
        {
            #region Home Position

            this.rectHome = new Rectangle[5];
            // setar os valores das casas
            this.rectHome[0] = new Rectangle(65 - this.player.Width / 2, 10, 50, 50);
            this.rectHome[1] = new Rectangle(230 - this.player.Width / 2, 10, 50, 50);
            // nao alterar este indice, esta correto
            this.rectHome[2] = new Rectangle(395 - this.player.Width / 2, 10, 50, 50);
            this.rectHome[3] = new Rectangle(560 - this.player.Width / 2, 10, 50, 50);
            this.rectHome[4] = new Rectangle(725 - this.player.Width / 2, 10, 50, 50);

            #endregion
        }

        public override void Initialize()
        {
            #region Player Config

            this.playerText = new string[5];
            this.setPlayerText();
            this.player = this.game.Content.Load<Texture2D>(playerText[0]);
            this.position = new Vector2(600 - player.Width / 2, 485);
            this.rect = new Rectangle((int)this.position.X, (int)this.position.Y, 30, 30);
            this.sobe = false;
            this.vira = false;
            #endregion
            
            #region Home Config
           
            this.homes = new bool[5]; //casas preenchidas
            this.setHomePosition();
            this.inHome = this.game.Content.Load<Texture2D>(playerText[4]);

            #endregion
            
          //  this.render = new Thread(new ThreadStart(this.MovePlayer_K));
         //  this.render.Name = "RenderPlayer";
         
            //this.render.Start();
            // doCaralho.Start();
            this.apertou = false;
            base.Initialize();
        }

        public void MovePlayer(int time)
        {
            #region IA
            this.time = time;
            if (time > 500)
            {
                this.rect.Y -= 40;
                GameConfig.score += 10;
               this.time = 0;
                VerificaVitoria();
            }

            #endregion
        } 
        public void MoveTeste()
        {
            while (true)
            {


                Console.WriteLine("chamou");
                if (Thread.CurrentThread.Name == "VerificaTeclado" &&
                      render.ThreadState != ThreadState.Unstarted)
                    if (render.Join(2000))

                        Console.WriteLine("Render has termminated.");
                    else
                        Console.WriteLine("The timeout has elapsed and Thread1 will resume.");

                Thread.Sleep(4000);

            }
        }
     

        public void MovePlayer_K()
        {
            #region MOVE KEYBOARD
           
           

                if (Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down) &&
                    Keyboard.GetState().IsKeyUp(Keys.Left) && Keyboard.GetState().IsKeyUp(Keys.Right))
                {
                    this.apertou = false;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up) && (!this.apertou))
                {
                    this.player = this.game.Content.Load<Texture2D>(this.playerText[0]);
                    this.rect.Y -= 40;
                    this.apertou = true;
                    this.VerificaVitoria();
                    move.Join(1000);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down) && (!this.apertou))
                {
                    this.player = this.game.Content.Load<Texture2D>(this.playerText[1]);
                    this.rect.Y += 40;
                    this.apertou = true;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right) && (!this.apertou))
                {
                    this.player = this.game.Content.Load<Texture2D>(this.playerText[3]);
                    this.rect.X += 40;
                    this.apertou = true;

                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Left) && (!this.apertou))
                {
                    this.player = this.game.Content.Load<Texture2D>(this.playerText[2]);
                    this.rect.X -= 40;
                    this.apertou = true;
                }
               
                Console.WriteLine("Ta verificando amada");
         //   Thread.Sleep(1000);
          
            #endregion
        } 
        public void MovePlayer_XBOX()
        {
            GamePadState padState = GamePad.GetState(PlayerIndex.One);
            
            if (padState.IsConnected)
            {
                if(padState.DPad.Left == ButtonState.Pressed)
                {
                    Console.WriteLine("Apertou PRA ESQUERDA");
                    this.player = this.game.Content.Load<Texture2D>(this.playerText[2]);
                    this.rect.X -= 2;
                    this.apertou = true;
                    this.VerificaVitoria();
                }
                if (padState.DPad.Right == ButtonState.Pressed)
                {
                    Console.WriteLine("Apertou PRA DIREITA");
                    this.player = this.game.Content.Load<Texture2D>(this.playerText[3]);
                    this.rect.X += 2;
                    this.apertou = true;
                    this.VerificaVitoria();
                }
                if (padState.DPad.Up == ButtonState.Pressed)
                {
                   
                        Console.WriteLine("Apertou PRA DIREITA");
                        this.player = this.game.Content.Load<Texture2D>(this.playerText[0]);
                        this.rect.Y -= 2;
                        this.apertou = true;
                       
                        this.VerificaVitoria();
                    
                }
                if (padState.DPad.Down == ButtonState.Pressed)
                {
                    
                        this.player = this.game.Content.Load<Texture2D>(this.playerText[1]);
                        this.rect.Y += 2;
                        this.apertou = true;
                  
                        this.VerificaVitoria();
                   
                   
                }




            }
            

        } 

        public void VerificaVitoria()
        {
            
           
            if (this.rect.Y == 45)
            {
               
                if (this.rect.X >= 30 && this.rect.X <= 110)
                {
                    
                    index = 0;
                    GameConfig.score += 10;
                    SetSpriteinHome(index);
                }
                else if (this.rect.X >= 195 && this.rect.X <= 275)
                {
                    index = 1;
                    GameConfig.score += 10;
                    SetSpriteinHome(index);
                }
                else if (this.rect.X >= 360 && this.rect.X <= 420)
                {
                    index = 2;
                    GameConfig.score += 10;
                    SetSpriteinHome(index);
                }
                else if (this.rect.X <= 605 &&  this.rect.X >= 525  )
                {
                    index = 3;
                    GameConfig.score += 10;
                    SetSpriteinHome(index);
                }
                else if (this.rect.X >= 690 && this.rect.X <= 770)
                {
                    index = 4;
                    GameConfig.score += 10;
                    SetSpriteinHome(index);
                }
                // index = 3;
                this.rect.X = (int)position.X;
                this.rect.Y = (int)position.Y;
            }
        } //transforma em Update

        public void SetSpriteinHome(int index)
        {
            // seta a casa que o player colidiu como true
              this.homes[index] = true;
            Console.WriteLine(index);
        }

        
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;

            sb.Begin();

            sb.Draw(this.player, this.rect, Color.White);

            for(var i = 0; i < homes.Length; i++)
            {
                // se a casa tiver setada como true, desenha o sprite do player
                if(homes[i])
                    sb.Draw(this.inHome, this.rectHome[i], Color.White);
            }
            
            
            sb.End();

            base.Draw(gameTime);
        }


    }
}
