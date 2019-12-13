using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;


namespace Frogger
{
    public class Fundo : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Texture2D fundo;
        Vector2 position;
        Rectangle rect;
        
        public Fundo(Game game): base(game)
        {

            this.fundo = game.Content.Load<Texture2D>(@"Images/Scene/fundo");
            this.position = Vector2.Zero;
            this.rect = new Rectangle((int)position.X, (int)position.Y, this.fundo.Width, this.fundo.Height);
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sb = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;

            sb.Begin();
            sb.Draw(this.fundo, this.rect, Color.White);
            sb.End();

            base.Draw(gameTime);
        }
    }
}
