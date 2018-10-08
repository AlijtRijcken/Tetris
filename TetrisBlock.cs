using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TetrisBlock
{
    public int[,] block;
    public bool setBlock;
    int[] position;
    public Color setColor;
    InputHelper input;

    public TetrisBlock()
    {
        //Default Tetris block. 
        block = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        setBlock = false;
        position = new int[2] { 0, 0 };
    }

       
    //rotation current tetrisblock. 
    //rotation matrix -> when two matrixes available a and b, with a given. b(x,y) = a(y, x)
    public void CounterRotate()
    {
        int[,] tempBlock = new int[4, 4];

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                tempBlock[x, y] = block[3-y, x];
           }

        }
        block = tempBlock;
    }
    public void Rotate()
    {
        int[,] tempBlock = new int[4, 4];

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                tempBlock[x, y] = block[y, 3 - x];
            }

        }
        block = tempBlock;
    }
    public void Move(int I)
    {

        position[0] = position[0] + I;
    }


    public void Input(GameTime gametime, InputHelper input)
    {

        if (input.KeyPressed(Keys.Z))
        {
            CounterRotate();
        }
        if (input.KeyPressed(Keys.X))
        {
            Rotate();
        }
        if (input.KeyPressed(Keys.Right))
        {
            Move(1);
        }
        if (input.KeyPressed(Keys.Left))
        {
            Move(-1);
        }
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
                    spriteBatch.Draw(TetrisGrid.emptyCell, new Vector2((position[0] + i)* TetrisGrid.emptyCell.Width, (position[1] + j)* TetrisGrid.emptyCell.Height), setColor);
            }

        }

    }

    //movement
    //rotation

}

