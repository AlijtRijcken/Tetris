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
    public SpriteFont font;
    public bool state = false;
    TetrisGrid grid;
    TetrisBlock useBlock;
    TetrisBlock previewBlock;
    TetrisBlock type;
    public double score;
    public double Score { get { return score; } set { score = value; } }
    int nextblock;

    public GameWorld()
    {
        
        random = new Random();
        previewBlock = new TetrisBlock();
        font = TetrisGame.ContentManager.Load<SpriteFont>("SpelFont");
        grid = new TetrisGrid();
        nextblock = random.Next(0, 7);
        Spawn();
        nextblock = random.Next(0, 7);
        useBlock = type;
        score = 0;
    }

    //check if death row contains values other than zero, ifso Game over
    public void CheckIfGameOver()
    {
        for (int i = 1; i < TetrisGrid.GridWidth + 1; i++)
        {
            if (TetrisGrid.Grid[i, 0] != 0)
            {
                //TetrisGame.GameState.Playing = TetrisGame.GameState.GameOver;
                state = true;
                grid.Clear();
            }
        }
    }
    
    //Check if full rows 
    public void CheckIfFullRow()
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

        score += Math.Round(multiplier * 1.25);            //meer punten
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
                type = new BlockI();
                break;
            case 1:
                type = new BlockJ();
                break;
            case 2:
                type = new BlockL();
                break;
            case 3:
                type = new BlockO();
                break;
            case 4:
                type = new BlockS();
                break;
            case 5:
                type = new BlockT();
                break;
            case 6:
                type = new BlockZ();
                break;

        }
        //level snelheid aanpassing.

        type.Basespeed = 40-(int)score*2;

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
            
            CheckIfFullRow();
            CheckIfGameOver();
            for (int i = 0; i < 4; i++)
            {
                CheckIfEmptyLines();
            }
            Spawn();
            useBlock = type;
            nextblock = random.Next(0, 7);
            Spawn();
            previewBlock = type;
            previewBlock.position = new int[2] { 12, 3 };
        }
        useBlock.Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        useBlock.Draw(gameTime, spriteBatch);
        previewBlock.Draw(gameTime, spriteBatch);
        spriteBatch.DrawString(font, "Score:" + (int)score, new Vector2(360,5), Color.Blue);
        spriteBatch.End();
    }

    public void Reset()
    {

    }

}
