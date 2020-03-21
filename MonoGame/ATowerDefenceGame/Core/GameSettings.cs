using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ATowerDefenceGame
{
    static class GameSettings
    {
        public const int BaseWidth = 1024;
        public const int BaseHeight = 576;
        public static int FloorLevel = BaseHeight - 32 * 3;
        public static GraphicsDeviceManager GDManager;
        private static MouseCursor _cursorPointer, _cursorWand;

        public static void Init(GraphicsDeviceManager graphicsDeviceManager)
        {
            GDManager = graphicsDeviceManager;
            /*_cursorPointer = MouseCursor.FromTexture2D(GameContent.Texture.Pointer, 1, 1);
            _cursorWand = MouseCursor.FromTexture2D(GameContent.Texture.Wand, 1, 1);*/
        }

        public static void SetCursor(CursorType type)
        {
            /*switch(type)
            {
                case CursorType.None:
                    Game1.Instance.IsMouseVisible = false;
                    break;
                case CursorType.Pointer:
                    Game1.Instance.IsMouseVisible = true;
                    Mouse.SetCursor(_cursorPointer);
                    break;
                case CursorType.Wand:
                    Game1.Instance.IsMouseVisible = true;
                    Mouse.SetCursor(_cursorWand);
                    break;
            }*/
        }
    }
}
