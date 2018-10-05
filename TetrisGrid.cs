using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//MODEL, WORLD 
// houdt bij wat bv het volgende blokje is, de scores bijhouden -> property score uit de GameWorld. 
// het blokje bestaat alleen in het model

class TetrisGrid
{
    /// The sprite of a single empty cell in the grid.
    Texture2D emptyCell;

    /// The position at which this TetrisGrid should be drawn.
    Vector2 position;

    /// The number of grid elements in the x-direction.
    static public int Width { get { return 10; } }

    /// The number of grid elements in the y-direction.
    static public int Height { get { return 20; } }
    public int[,] Grid = new int[Width, Height];
     
    /// Creates a new TetrisGrid.
    /// <param name="b"></param>
    public TetrisGrid()
    {
        emptyCell = TetrisGame.ContentManager.Load<Texture2D>("block");
        position = Vector2.Zero;
        Clear();
    }

    /// Draws the grid on the screen.
    /// <param name="gameTime">An object with information about the time that has passed in the game.</param>
    /// <param name="spriteBatch">The SpriteBatch used for drawing sprites and text.</param>
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        for(int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
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
            }
        }
    }
    /// Clears the grid.
    public void Clear()
    {
    }
}

