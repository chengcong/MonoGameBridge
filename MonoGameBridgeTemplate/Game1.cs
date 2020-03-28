using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace $safeprojectname$
{
    /// <summary>
    /// 游戏类
    /// </summary>
    public class Game1 : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    Texture2D panda;
    Vector2 position;
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
    }

    /// <summary>
    /// 游戏在开始运行前执行初始化
    /// 在这里可以进行服务或加载任何非图形操作
    /// 调用base.Initialize初始化components
    /// </summary>
    protected override void Initialize()
    {
        // 注: 添加初始化逻辑代码

        base.Initialize();
    }

    /// <summary>
    /// 加载游戏所需要的资源内容（每场游戏中调用一次）
    /// </summary>
    protected override void LoadContent()
    {
        // 创建SpriteBatch用于绘制纹理（Textures）.
        spriteBatch = new SpriteBatch(GraphicsDevice);
        // 注: 使用this.Content加载游戏资源内容
        panda = Content.Load<Texture2D>("panda");
        position = new Vector2(0, 0);

    }

    /// <summary>
    /// 卸载游戏的资源内容（每场游戏中调用一次）
    /// </summary>
    protected override void UnloadContent()
    {
        // 注: 卸载游戏资源内容（每场游戏中调用一次）
    }

    /// <summary>
    /// 更新游戏运行逻辑，如更新世界，检查碰撞、收集输入和播放音频等
    /// </summary>
    /// <param name="gameTime">游戏计时</param>
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // 注: 添加你的游戏逻辑代码
        position.X = Mouse.GetState().X;
        position.Y = Mouse.GetState().Y;
          

        base.Update(gameTime);
    }

    /// <summary>
    /// 游戏应该绘制自己时调用
    /// </summary>
    /// <param name="gameTime">游戏计时</param>
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // 注: 添加绘制代码
        spriteBatch.Begin();
        spriteBatch.Draw(panda, position, Color.White);
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
}
