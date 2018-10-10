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
    public void Check()
    {
        for (int i = 0; i < TetrisGrid.GridHeight; i++)
        {
            bool check = false;
            for (int j = 1; j < TetrisGrid.GridWidth + 1; j++)
            {

                if (TetrisGrid.Grid[j, i] == 0)
                {
                    check = true;
                }
            }

            if (check == false)
            {
                for (int k = 1; k <TetrisGrid.GridWidth+1; k++)
                {
                    TetrisGrid.Grid[k,i] = 0;
                }

            }
        }
    }
    public void CheckLines()
    {
        for (int i = TetrisGrid.GridHeight; i >= 0; i--)
        {
            bool tester = false;
            for (int j = 1; j < TetrisGrid.GridWidth + 1; j++)
            {
                if (TetrisGrid.Grid[j, i] != 0)
                {
                    tester = true;
                }
            }
            if (tester == false)
            {
                for (int y = i; y >= 1; y--)
                {
                    for (int j = 1; j < TetrisGrid.GridWidth + 1; j++)
                    {
                        TetrisGrid.Grid[j, y] = TetrisGrid.Grid[j, y-1];
                    }
                }
             }
        }
    }
        //spawns random block (kan dit in tetrisblock?
        public void Spawn()
    {
        switch (random.Next(0, 7))
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
        //input van block
        useBlock.Input(gameTime,inputHelper);


    }

    public void Update(GameTime gameTime)
    {
        //spawnt nieuw random block als vorige is geplaatst
        if (useBlock.setBlock)
        {
            Spawn();
            Check();
            CheckLines();
        }
        useBlock.Update(gameTime);

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
