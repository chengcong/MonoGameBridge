using Bridge;
using System;
using System.IO;
using static Retyped.dom;
using Console = System.Console;
using Microsoft.Xna.Framework;

namespace TestWebGame
{
    public class App
    {
		private static Game game;
		
        public static void Main()
		{
			var canvas = new HTMLCanvasElement();
			canvas.width = 800;
			canvas.height = 480;
			canvas.id = "monogamecanvas";

            var divdata = new HTMLDivElement();
			divdata.id = "testoutput";

            var button = new HTMLButtonElement();
            button.innerHTML = "Run Game";

			document.body.appendChild(canvas);
            document.body.appendChild(button);
			document.body.appendChild(divdata);

            button.onclick = (ev) =>
            {
				game = new Game1();
				// game = new PrimitivesSample.PrimitivesSampleGame();
				game.Run();
			};
        }
    }
}
