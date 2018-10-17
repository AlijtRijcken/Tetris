using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


/// A class for representing the game world.
/// This contains the grid, the falling block, and everything else that the player can see/do.
//CONTROLER, 
class GameWorld
{

    public static Random Random { get { return random; } }
    static Random random;
    /// The main font of the game.
    SpriteFont font;
    public int state = 0;
    TetrisGrid grid;
    TetrisBlock useBlock;
    InputHelper input;
    public int score;
    public int Score { get { return score; } set { score = value; } }
    int nextblock;

    public GameWorld()
    {
        
        random = new Random();
        nextblock = random.Next(0, 7);
        font = TetrisGame.ContentManager.Load<SpriteFont>("SpelFont");
        grid = new TetrisGrid();
        Spawn();
        score = 0; 
    }
    public void CheckFinish()
    {
        for (int i = 1; i < TetrisGrid.GridWidth + 1; i++)
        {
            if (TetrisGrid.Grid[i, 0] != 0)
            {
                //TetrisGame.GameState.Playing = TetrisGame.GameState.GameOver;
                state = 1;
                grid.Clear();
            }
        }
    }
    public void Check()
    {
        int multiplier = 0;
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
                multiplier++;
                for (int k = 1; k <TetrisGrid.GridWidth+1; k++)
                {
                    TetrisGrid.Grid[k,i] = 0;
                    
                }

            }
        }
        score += multiplier;
    }
    //Check if emptylines
    public void CheckIfEmptyLines()
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
        switch (nextblock)
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
        //level snelheid aanpassing.
        useBlock.Basespeed = 40-score*3;
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
            
            Check();
            CheckFinish();
            for (int i = 0; i < 4; i++)
            {
                CheckIfEmptyLines();
            }
            Spawn();
            nextblock = random.Next(0, 7);
        }
        useBlock.Update(gameTime);
          //miste soms lijnen als hij in if staat, aanpassen methode?

    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        useBlock.Draw(gameTime, spriteBatch);
        spriteBatch.DrawString(font, "Score:" + score, new Vector2(340,5), Color.Blue);
        spriteBatch.End();
    }

    public void Reset()
    {

    }

}
