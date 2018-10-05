using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TetrisBlock
{
    public int[,] block;
    public bool setBlock;
    Vector2 position;
    public Color setColor; 

    public TetrisBlock()
    {
        block = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        setBlock = false;
        position = new Vector2(0, 0);
        setColor = Color.Black;
    }

    public void Update(GameTime gameTime)
    {


    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        for (int i = 0; i < block.GetLength(0); i++)
        {
            for (int j = 0; j < block.GetLength(1); j++)
            {
                if (block[i,j] != 0)
                    spriteBatch.Draw(TetrisGrid.emptyCell, new Vector2((position.X + i)* TetrisGrid.emptyCell.Width, (position.Y + j)* TetrisGrid.emptyCell.Height), setColor);
            }

        }


    }

    //movement
    //rotation

}

