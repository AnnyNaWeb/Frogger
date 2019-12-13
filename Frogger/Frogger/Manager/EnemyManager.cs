using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Frogger
{
    public class EnemyManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Turtle[] tartarugasT, tartarugaD;
        public TroncoP[] troncoP;
        public TroncoG[] troncoG;
        public TroncoM[] troncoM;

        public Car3[] car3;
        public Car2[] car2;
        public Car1[] car1;
        public Caminhao[] caminhao;
        public SpriteBatch sb;
        public Game game;

        public EnemyManager(Game game): base(game)
        {
            this.game = game;
            this.tartarugasT = new Turtle[4];
            this.tartarugaD = new Turtle[5];
            this.troncoP = new TroncoP[4];
            this.troncoG = new TroncoG[4];
            this.troncoM = new TroncoM[4];

            this.car3 = new Car3[4];
            this.car2 = new Car2[4];
            this.car1 = new Car1[4];
            this.caminhao = new Caminhao[4];
        }

        public override void Initialize()
        {
            #region Topo
            for (var i = 0; i < troncoP.Length; i++)
            {
                if (i != 0)
                    troncoP[i] = new TroncoP(this.game, new Vector2(troncoP[i - 1].rect.X + 200, 200));
                else
                    troncoP[i] = new TroncoP(this.game, new Vector2(100, 200));
            }

            for (var i = 0; i < troncoG.Length; i++)
            {
                if (i != 0)
                    troncoG[i] = new TroncoG(this.game, new Vector2(troncoG[i - 1].rect.X + 230, 160));
                else
                    troncoG[i] = new TroncoG(this.game, new Vector2(100, 160));
            }
            for (var i = 0; i < troncoM.Length; i++)
            {
                if (i != 0)
                    troncoM[i] = new TroncoM(this.game, new Vector2(troncoM[i - 1].rect.X + 230, 80));
                else
                    troncoM[i] = new TroncoM(this.game, new Vector2(100, 80));
            }

            for (var i = 0; i < tartarugasT.Length; i++)
            {
                if(i != 0)
                    tartarugasT[i] = new Turtle(this.game, new Vector2(tartarugasT[i-1].posicaoFoto.X + 250, 230),3);
                else
                    tartarugasT[i] = new Turtle(this.game, new Vector2(100, 230),3);
            }
            for (var i = 0; i < tartarugaD.Length; i++)
            {
                if (i != 0)
                    tartarugaD[i] = new Turtle(this.game, new Vector2(tartarugaD[i - 1].posicaoFoto.X + 170, 110), 2);
                else
                    tartarugaD[i] = new Turtle(this.game, new Vector2(200, 110), 2);
            }
            #endregion

            for (var i = 0; i < caminhao.Length; i++)
            {
                if (i != 0)
                    caminhao[i] = new Caminhao(this.game, new Vector2(caminhao[i - 1].rect.X + 200, 320));
                else
                    caminhao[i] = new Caminhao(this.game, new Vector2(100, 320));
            }
            for (var i = 0; i < car1.Length; i++)
            {
                if (i != 0)
                    car1[i] = new Car1(this.game, new Vector2(car1[i - 1].rect.X + 200, 355));
                else
                    car1[i] = new Car1(this.game, new Vector2(100, 355));
            }
            for (var i = 0; i < car2.Length; i++)
            {
                if (i != 0)
                    car2[i] = new Car2(this.game, new Vector2(car2[i - 1].rect.X + 250, 395));
                else
                    car2[i] = new Car2(this.game, new Vector2(150, 395));
            }
            for (var i = 0; i < car3.Length; i++)
            {
                if (i != 0)
                    car3[i] = new Car3(this.game, new Vector2(car3[i - 1].rect.X + 250, 430));
                else
                    car3[i] = new Car3(this.game, new Vector2(150, 430));
            }
            base.Initialize();
        }
        
        public override void Update(GameTime gameTime)
        {
            #region Topo
            for (var i = 0; i < tartarugasT.Length; i++)
            {
                tartarugasT[i].Update(gameTime);
            }
            for (var i = 0; i < troncoP.Length; i++)
            {
                troncoP[i].Update(gameTime);
            }
            for (var i = 0; i < troncoG.Length; i++)
            {
                troncoG[i].Update(gameTime);
            }
            for (var i = 0; i < troncoM.Length; i++)
            {
                troncoM[i].Update(gameTime);
            }

            for (var i = 0; i < tartarugaD.Length; i++)
            {
                tartarugaD[i].Update(gameTime);
            }
            #endregion
            for (var i = 0; i < caminhao.Length; i++)
            {
                caminhao[i].Update(gameTime);
            }
            for (var i = 0; i < car1.Length; i++)
            {
                car1[i].Update(gameTime);
            }
            for (var i = 0; i < car2.Length; i++)
            {
                car2[i].Update(gameTime);
            }
            for (var i = 0; i < car3.Length; i++)
            {
                car3[i].Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.sb = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;

            this.sb.Begin();
            #region Topo
            for (var i = 0; i < troncoP.Length; i++)
            {
                troncoP[i].Draw(gameTime, this.sb);
            }
            for (var i = 0; i < troncoG.Length; i++)
            {
                troncoG[i].Draw(gameTime, this.sb);
            }
            for (var i = 0; i < troncoM.Length; i++)
            {
                troncoM[i].Draw(gameTime, this.sb);
            }

           /* for (var i = 0; i < tartarugasT.Length; i++)
            {
                tartarugasT[i].Draw(gameTime, this.sb);

            }
            for (var i = 0; i < tartarugaD.Length; i++)
            {
                tartarugaD[i].Draw(gameTime, this.sb);

            }*/
            #endregion
            for (var i = 0; i < caminhao.Length; i++)
            {
                caminhao[i].Draw(gameTime, this.sb);
            }
            for (var i = 0; i < car1.Length; i++)
            {
                car1[i].Draw(gameTime, this.sb);
            }
            for (var i = 0; i < car2.Length; i++)
            {
                car2[i].Draw(gameTime, this.sb);
            }
            for (var i = 0; i < car3.Length; i++)
            {
                car3[i].Draw(gameTime, this.sb);
            }
            this.sb.End();

            base.Draw(gameTime);
        }
    }
}
