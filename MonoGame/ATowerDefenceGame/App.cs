using Bridge;
using System;
using System.IO;
using static Retyped.dom;
using Console = System.Console;
using Microsoft.Xna.Framework;

namespace ATowerDefenceGame
{
    public class App
    {
		private static Game game;
		
        public static void Main()
		{
            var divdata = new HTMLDivElement();
			divdata.innerHTML = "This is an example web game that uses MonoGame, it just uses a prototype that @Jjagg and me made in like 3h for a gamejam, and than didn't have the time to finish it...<br><br>Once in game press space to spawn enemies.<br><br>Green screen means that the game is loading, I didn't want to bother implementing a custom loading screen.<br><br>";
			document.body.appendChild(divdata);

            var button = new HTMLButtonElement();
            button.innerHTML = "Run Game";
			divdata.appendChild(button);

			var brelem = new HTMLBRElement();
			document.body.appendChild(brelem);

			var canvas = new HTMLCanvasElement();
			canvas.width = 1024;
			canvas.height = 576;
			canvas.id = "monogamecanvas";
			document.body.appendChild(canvas);

            button.onclick = (ev) =>
            {
				game = new Game1();
				game.Run();

				document.body.removeChild(divdata);
				document.body.removeChild(brelem);
			};
        }
    }
}
