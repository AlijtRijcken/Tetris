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

    public GameWorld()
    {
        random = new Random();
        gameState = GameState.Playing;

        font = TetrisGame.ContentManager.Load<SpriteFont>("SpelFont");

        grid = new TetrisGrid();
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
    }

    public void Update(GameTime gameTime)
    {
        //Als een key ingedrukt, detecteer en dan doorsturen, aanroepen.
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        //spriteBatch.DrawString(font, "Hello!", Vector2.Zero, Color.Blue);
        spriteBatch.End();
    }

    public void Reset()
    {
    }

}
