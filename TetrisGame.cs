using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

class TetrisGame : Game
{
    SpriteBatch spriteBatch;
    InputHelper inputHelper;
    public GameWorld gameWorld;
    /// An enum for the different game states that the game can have.
    public enum GameState
    {
        Playing,
        GameOver
    }
    /// The current game state.
    public GameState gameState = GameState.GameOver;
    
    /// A static reference to the ContentManager object, used for loading assets.
    public static ContentManager ContentManager { get; private set; }
    

    /// <summary>
    /// A static reference to the width and height of the screen.
    /// </summary>
    public static Point ScreenSize { get; private set; }

    [STAThread]
    static void Main(string[] args)
    {
        TetrisGame game = new TetrisGame();
        game.Run();
    }

    public TetrisGame()
    {
        gameState = GameState.Playing;

        // initialize the graphics device
        GraphicsDeviceManager graphics = new GraphicsDeviceManager(this);

        // store a static reference to the content manager, so other objects can use it
        ContentManager = Content;
        
        // set the directory where game assets are located
        Content.RootDirectory = "Content";

        // set the desired window size
        ScreenSize = new Point(800, 640);
        graphics.PreferredBackBufferWidth = ScreenSize.X;
        graphics.PreferredBackBufferHeight = ScreenSize.Y;

        // create the input helper object
        inputHelper = new InputHelper();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // create and reset the game world
        gameWorld = new GameWorld();
        gameWorld.Reset();
    }

    protected override void Update(GameTime gameTime)
    {
        inputHelper.Update(gameTime);
        if (gameWorld.state == true) { gameState =GameState.GameOver; }
        switch (gameState)
        {
            case GameState.Playing:
                gameWorld.Update(gameTime);
                gameWorld.HandleInput(gameTime, inputHelper);
                break;
            case GameState.GameOver:

                break;
            default:
                break;
        }



    }

    protected override void Draw(GameTime gameTime)
    {
        

        GraphicsDevice.Clear(Color.White);
        if (gameWorld.state == true) { gameState = GameState.GameOver; }
        switch (gameState)
        {
            case GameState.Playing:
                gameWorld.Draw(gameTime, spriteBatch);
                break;
            case GameState.GameOver:

                spriteBatch.Begin();
                spriteBatch.DrawString(gameWorld.font, "Score:" + gameWorld.score, new Vector2(400, 200), Color.Blue);
                spriteBatch.End();
                break;
            default:
                break;
        }


        

    }
}

