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

    // create the grid
    static public int[,] Grid = new int[GridWidth+2, GridHeight+1]; 
 
// Creates a new TetrisGrid.
public TetrisGrid()
    {
        emptyCell = TetrisGame.ContentManager.Load<Texture2D>("block");
        position = Vector2.Zero;

        Clear();
    }

    //Draws the grid on the screen.  --> Screen
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
                    spriteBatch.Draw(emptyCell, new Vector2(x * emptyCell.Width, y * emptyCell.Height), Color.BlanchedAlmond);
                }
                else if (Grid[x, y] == 8)
                {
                    spriteBatch.Draw(emptyCell, new Vector2(x * emptyCell.Width, y * emptyCell.Height), Color.DarkKhaki);
                }
            }
        }
    }


    // Clears the grid.
    public void Clear()
    {
        for (int x = 0; x < GridWidth+2; x++)
        {
            for (int y = 0; y < GridHeight; y++)
            {
                Grid[x, y] = 0;                     //alle mogelijke combies van x,y op 0 zetten. 
               
                //Groene rand inbrengen. 
                Grid[0, y] = 8;
                Grid[GridWidth + 1,y] = 8;
                Grid[x, GridHeight] = 8;
            }

        }
    }
}

