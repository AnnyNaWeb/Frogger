using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System.Threading;
namespace Frogger
{
    public class Audio : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Song trilha;
        Thread tAudio;
        public Audio(Game game) : base(game)
        {
            this.tAudio = new Thread(new ThreadStart(playAudio));
            this.tAudio.Name = "AUDIO TOCANDO ";
            this.trilha = game.Content.Load<Song>(@"Audio/trilha");
        }

        public override void Initialize()
        {
            this.tAudio.Start();
            base.Initialize();
        }

        public void playAudio()
        {
            while (true)
            {
                MediaPlayer.Play(trilha);
 
               MediaPlayer.IsRepeating = true;
                Console.WriteLine(tAudio.Name);
                Thread.Sleep(30000);
            }
         
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
