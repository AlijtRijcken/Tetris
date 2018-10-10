using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

//MODEL, WORLD 
// houdt bij wat bv het volgende blokje is, de scores bijhouden -> property score uit de GameWorld. 
// het blokje bestaat alleen in het model

class TetrisGrid
{
    // The sprite of a single empty cell in the grid.
    public static Texture2D emptyCell;

    // The position at which this TetrisGrid should be drawn.
    Vector2 position;

    // The number of grid elements in the x-direction.
    static public int GridWidth { get { return 10; } }

    // The number of grid elements in the y-direction.
    static public int GridHeight { get { return 20; } }

    static public int[,] Grid = new int[GridWidth+2, GridHeight+1];

    Random random;
    private int number;
    TetrisBlock block; 
 
// Creates a new TetrisGrid.
public TetrisGrid()
    {
        emptyCell = TetrisGame.ContentManager.Load<Texture2D>("block");
        position = Vector2.Zero;

        //number = random.Next(0, 7);

        Clear();
    }

    //Draws the grid on the screen.
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        for (int x = 0; x < GridWidth+2; x++)
        {
            for (int y = 0; y < GridHeight+1; y++)
            {
                if (Grid[x, y] == 0)
                {
                    spriteBatch.Draw(emptyCell, new Vector2(x * emptyCell.Width, y * emptyCell.Height), Color.White);
                }
                else if (Grid[x, y] == 1)
                {
                    spriteBatch.Draw(emptyCell, new Vector2(x * emptyCell.Width, y * emptyCell.Height), Color.Blue);
                }
                else if (Grid[x, y] == 2)
                {
                    spriteBatch.Draw(emptyCell, new Vector2(x * emptyCell.Width, y * emptyCell.Height), Color.Green);
                }
                else if (Grid[x, y] == 3)
                {
                    spriteBatch.Draw(emptyCell, new Vector2(x * emptyCell.Width, y * emptyCell.Height), Color.Red);
                }
                else if (Grid[x, y] == 4)
                {
                    spriteBatch.Draw(emptyCell, new Vector2(x * emptyCell.Width, y * emptyCell.Height), Color.Pink);
                }
                else if (Grid[x, y] == 5)
                {
                    spriteBatch.Draw(emptyCell, new Vector2(x * emptyCell.Width, y * emptyCell.Height), Color.Purple);
                }
                else if (Grid[x, y] == 6)
                {
                    spriteBatch.Draw(emptyCell, new Vector2(x * emptyCell.Width, y * emptyCell.Height), Color.Maroon);
                }
                else if (Grid[x, y] == 7)
                {
                    spriteBatch.Draw(emptyCell, new Vector2(x * emptyCell.Width, y * emptyCell.Height), Color.Orange);
                }
                else if (Grid[x, y] == 8)
                {
                    spriteBatch.Draw(emptyCell, new Vector2(x * emptyCell.Width, y * emptyCell.Height), Color.DarkTurquoise);
                }
            }
        }
    }

    /*public void SpawnNextBlock()
    {
        switch (number)
        {
            case 0;
                block = new BlockI();
                break;
            case 1;
                block = new BlockJ();
                break;
            case 2;
                block = new BlockL();
                break;
            case 3;
                block = new BlockO();
                break;
            case 4;
                block = new BlockS();
                break;
            case 5;
                block = new BlockT();
                break;
            case 6;
                block = new BlockZ();
                break;
        }
    }
    */

    // Clears the grid.
    public void Clear()
    {
        for (int x = 0; x < GridWidth+2; x++)
        {
            for (int y = 0; y < GridHeight; y++)
            {
                Grid[x, y] = 0;
                Grid[0, y] = 8;
                Grid[GridWidth + 1,y] = 8;
                Grid[x, GridHeight] = 8;
            }

        }
    }
}

