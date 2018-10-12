using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


/// A class for representing the game world.
/// This contains the grid, the falling block, and everything else that the player can see/do.
/// 
//CONTROLER, 
class GameWorld
{
    /// An enum for the different game states that the game can have.
    enum GameState
    {
        Playing,
        GameOver
    }
 
    /// The random-number generator of the game.

    public static Random Random { get { return random; } }
    static Random random;
    /// The main font of the game.
    SpriteFont font;

    /// The current game state.
    GameState gameState;

    /// The main grid of the game.
    TetrisGrid grid;
    TetrisBlock useBlock;
    InputHelper input;

    public int score; 

    public int Score { get { return score; } set { score = value;  } }

    public GameWorld()
    {
        random = new Random();
        gameState = GameState.Playing;

        font = TetrisGame.ContentManager.Load<SpriteFont>("SpelFont");

        grid = new TetrisGrid();
        Spawn();
        score = 0; 
    }
    public void Spawn()
    {
        switch (random.Next(0, 6))
        {
            case 0:
                useBlock = new BlockI();
                break;
            case 1:
                useBlock = new BlockJ();
                break;
            case 2:
                useBlock = new BlockL();
                break;
            case 3:
                useBlock = new BlockO();
                break;
            case 4:
                useBlock = new BlockS();
                break;
            case 5:
                useBlock = new BlockT();
                break;
            case 6:
                useBlock = new BlockZ();
                break;

        }
    }
    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        useBlock.Input(gameTime,inputHelper);


    }

    public void Update(GameTime gameTime)
    {
        if (useBlock.setBlock)
        {
            Spawn();

        }
        useBlock.Update(gameTime);
        
        //Als een key ingedrukt, detecteer en dan doorsturen, aanroepen.  -> Tetrisblock en die controleerd weer verder. 
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        useBlock.Draw(gameTime, spriteBatch);
        spriteBatch.DrawString(font, "Score:" + score, new Vector2(320,5), Color.Blue);
        spriteBatch.End();
    }

    public void Reset()
    {
    }

}
