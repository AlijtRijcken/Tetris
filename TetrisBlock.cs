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
    public bool setBlock = false;
    int[] position;
    public Color setColor;
    InputHelper input;
    int ticks;
    int speed = 40;

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
        bool test = false;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if(block[i,j] != 0 && TetrisGrid.Grid[position[0] + i + I , position[1] + j ]!=0)
                {
                    test = true;
                }
            }

        }
        if (test == false) { position[0] = position[0] + I; ; }
        else
        {
            test = false;
        }
        
    }
    public void down()
    {
        ticks++;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (block[i, j] != 0 && TetrisGrid.Grid[position[0] + i, position[1] + j+1] != 0)
                {
                    setBlock = true;
                }
            }

        }


        if (ticks >= speed)
        {
            position[1]++;
            ticks = 0;
        }

    }

    public void upload()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (block[i, j] != 0) {
                    TetrisGrid.Grid[i + position[0], j + position[1]] = block[i, j];
                 }
            }
        }
    }

    public void Input(GameTime gametime, InputHelper input)
    {

        if (input.KeyPressed(Keys.Z)&&setBlock == false)
        {
            CounterRotate();
        }
        if (input.KeyPressed(Keys.X) && setBlock == false)
        {
            Rotate();
        }
        if (input.KeyPressed(Keys.Right) && setBlock == false)
        {
            Move(1);
        }
        if (input.KeyPressed(Keys.Left) && setBlock == false)
        {
            Move(-1);
        }
        if (input.KeyDown(Keys.Down) && setBlock == false)
        {
            speed = 10;
        }
        if (input.KeyDown(Keys.Down)==false && setBlock == false)
        {
            speed = 40;
        }
    }

    public void Update(GameTime gameTime)
    {
        if (setBlock == false)
        {
            down();
        }
        if (setBlock)
        {
            upload();
        }
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

