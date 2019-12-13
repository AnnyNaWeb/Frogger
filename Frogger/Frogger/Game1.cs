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
using KopiLua;
using NLua;
using System.Threading;
using System.Threading.Tasks;
namespace Frogger
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //   NLua.Lua lua;
        bool entrou = false;
        Audio trilha;
      
        Player player;

        EnemyManager enemy;
        GameManager gManager;
       // Colisao collision;
        Thread move;
        Fundo fundo;
       // Thread tInput;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
           
            this.IsMouseVisible = true;
           // this.tInput = new Thread(new ThreadStart(Input));
            Content.RootDirectory = "Content";
          
        }
      
        protected override void Initialize()
        {
            this.fundo = new Fundo(this);
            Components.Add(this.fundo);
        //    this.collision = new Colisao();
           

            this.player = new Player(this);
            this.Components.Add(this.player);
            
          
            this.gManager = new GameManager(this);
            this.Components.Add(this.gManager);

            this.enemy = new EnemyManager(this);
            Components.Add(this.enemy);

            this.trilha = new Audio(this);
            Components.Add(this.trilha);

          /*  this.move = new Thread(new ThreadStart(this.player.MovePlayer_K));
            this.move.Name = "MOVENDO";
            this.move.Start();
            this.move.Join();*/



            //  this.lua = new NLua.Lua();
            //   this.lua.RegisterFunction("MovePlayer", this.player, this.player.GetType().GetMethod("MovePlayer"));

            // this.lua.RegisterFunction("MovePlayer_K", this.player, this.player.GetType().GetMethod("MovePlayer_K"));
            //   this.lua.RegisterLuaClassType(typeof(GameTime), typeof(GameTime));
            //  this.t = new Thread(new ThreadStart(Colisao));
            
            base.Initialize();
        }
       /* public delegate void InvokeDelegate();
        public void InvokeMethod()
        {
            Console.WriteLine("TESTE DO CARALHO");
        }*/
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), this.spriteBatch);
           


        }

        protected override void UnloadContent()
        {
            
        }
        
       
        protected override void Update(GameTime gameTime)
        {
          
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
          
            try
                
            {
              this.player.MovePlayer_K();
              Colisao();
               

                /*  this.lua["time"] = this.player.time ;
                this.lua["gt"] = gameTime;
                  this.lua["aux"];
                 this.lua.DoFile(@"lua.txt");
                 this.lua["time"];
                 Console.WriteLine(  this.lua["aux"]);*/
             //   this.player.MovePlayer_K();

            }
            catch (Exception e)
           {
               Console.WriteLine("ERRO: " + e.Message);

           }
           base.Update(gameTime);
       }

        public void Colisao()
        {
                for (var i = 0; i < 4; i++)
                {
                    if (this.player.rect.Intersects(this.enemy.troncoG[i].rect))
                    {        
                        this.player.rect.X = this.enemy.troncoG[i].rect.X;
                    }
                    if (this.player.rect.Intersects(this.enemy.troncoM[i].rect))
                    {
                        this.player.rect.X = this.enemy.troncoM[i].rect.X;
                    }
                    if (this.player.rect.Intersects(this.enemy.troncoP[i].rect))
                    {
                        this.player.rect.X = this.enemy.troncoP[i].rect.X;
                    }
                    if (this.player.rect.Intersects(this.enemy.tartarugaD[i].rect))
                    {
                        this.player.rect.X = this.enemy.tartarugaD[i].rect.X;
                    }
                    if (this.player.rect.Intersects(this.enemy.car1[i].rect))
                    { 
                        this.player.rect.Y = 485;
                    }
                    if (this.player.rect.Intersects(this.enemy.caminhao[i].rect))
                    {
                        Console.WriteLine("Colidiu");
                        this.player.rect.Y = 485;
                    }
                    if (this.player.rect.Intersects(this.enemy.car2[i].rect))
                    {
                        Console.WriteLine("Colidiu");
                        this.player.rect.Y = 485;
                    }
                    if (this.player.rect.Intersects(this.enemy.car3[i].rect))
                    {
                        Console.WriteLine("Colidiu");
                        this.player.rect.Y = 485;
                    }
                 //   Thread.Sleep(1000);
                }

            

        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}
