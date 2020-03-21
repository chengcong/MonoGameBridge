using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ATowerDefenceGame
{
    static class InputManager
    {
        public static KeyboardState KeyState;
        public static KeyboardState PrevKeyState;
        public static MouseState MouseState;
        public static MouseState PrevMouseState;

        public static Point MousePosition => new Point(
            MouseState.X * GameSettings.BaseWidth / GameSettings.GDManager.GraphicsDevice.PresentationParameters.BackBufferWidth,
            MouseState.Y * GameSettings.BaseHeight / GameSettings.GDManager.GraphicsDevice.PresentationParameters.BackBufferHeight
        );

        public static void Update()
        {
            PrevKeyState = KeyState;
            KeyState = Keyboard.GetState();
            PrevMouseState = MouseState;
            MouseState = Mouse.GetState();
        }

        public static bool KeyPressed(Keys key)
        {
            return PrevKeyState.IsKeyUp(key) && KeyState.IsKeyDown(key);
        }

        public static bool MousePressed()
        {
            return PrevMouseState.LeftButton == ButtonState.Released &&
                MouseState.LeftButton == ButtonState.Pressed;
        }
    }
}