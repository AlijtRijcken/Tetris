using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    TetrisBlock block;

    public int score; 

    public int Score { get { return score; } set { score = value;  } }

    public GameWorld()
    {
        random = new Random();
        gameState = GameState.Playing;

        font = TetrisGame.ContentManager.Load<SpriteFont>("SpelFont");

        grid = new TetrisGrid();
        block = new BlockI();

        score = 0; 
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
    }

    public void Update(GameTime gameTime)
    {

        //Als een key ingedrukt, detecteer en dan doorsturen, aanroepen.  -> Tetrisblock en die controleerd weer verder. 
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        block.Draw(gameTime, spriteBatch);
        spriteBatch.DrawString(font, "Score:" + score, new Vector2(320,5), Color.Blue);
        spriteBatch.End();
    }

    public void Reset()
    {
    }

}
