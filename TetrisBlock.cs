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
    public int[,] block;                //default array[4,4]
    public bool setBlock = false;
    int[] position;
    public Color setColor;

    InputHelper input;
    int ticks;
    int speed;
    public int Basespeed = 0;
    int[,] Fakegrid = new int[TetrisGrid.GridWidth + 2, TetrisGrid.GridHeight + 1];
    int length = 4; 

    public TetrisBlock()
    {
        //Default Tetris block. 

        block = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        setBlock = false;
        position = new int[2] { 4, -4 };
        speed = Basespeed;
    }


    public void CreateGrid()
    {
        for (int x = 0; x < TetrisGrid.GridWidth + 2; x++)
        {
            for (int y = 0; y < TetrisGrid.GridHeight; y++)
            {
                if (TetrisGrid.Grid[x,y] == 0)
                {
                    Fakegrid[x, y] = 0;
                }
                else if(TetrisGrid.Grid[x,y]!=0)
                {
                    Fakegrid[x, y] = 1;
                }
            }

        }
    }

    //rotation current tetrisblock. 
    //rotation matrix -> when two matrixes available a and b, with a given. b(x,y) = a(y, x)
    private void CounterRotate()
    {
        int[,] tempBlock = new int[length, length];

        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < length; y++)
            {
                tempBlock[x, y] = block[3 - y, x];
           }

        }
        block = tempBlock;

        bool test = false;
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (position[1] >= 0)
                {
                    if (block[i, j] != 0 && TetrisGrid.Grid[position[0] + i, position[1] + j] != 0)
                    {
                        test = true;
                    }
                }

            }
        }
        if (test == true)
        {
            Rotate();
        }
    }
    private void Rotate()
    {
        int[,] tempBlock = new int[length, length];

        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < length; y++)
            {
                tempBlock[x, y] = block[y, 3 - x];
            }

        }
        block = tempBlock;

        bool test = false;
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                    if (position[0]<=TetrisGrid.GridWidth-2)
                    {
                        if (block[i, j] != 0 && TetrisGrid.Grid[position[0] + i, position[1] + j] != 0)
                        {
                            test = true;
                        }
                    } 
            }
        }
        if (test == true)
        {
            CounterRotate();
        }
    }

    //links/rechts bewegen van het blockje
    public void Movement(int I)

    {
        bool test = false;
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (position[1] >= 0)
                {
                    if (block[i, j] != 0 && TetrisGrid.Grid[position[0] + i + I, position[1] + j] != 0)
                    {
                        test = true;
                    }
                }
                else
                {
                    if (block[i, j] != 0 && TetrisGrid.Grid[position[0] + i + I,j] != 0)
                    {
                        test = true;
                    }
                }
            }
        }
        if (test == false)
        {
            position[0] = position[0] + I;
        }
        else
        {
            test = false;
        }
        
    }

    //vallen
    public void DownMovement()
    {
        //Gametime
        ticks++;
        int count = 0;
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if(position[1]>=0)
                {

                    if (block[i, j] != 0 && TetrisGrid.Grid[position[0] + i, position[1] + j + 1] != 0)
                    {
                        count = ticks;
                        if (count >= 60)
                        {
                            setBlock = true;
                        }
                    }
                }
            }
        }
        if (ticks >= speed && count == 0)
        {
            position[1]++;
            ticks = 0;
        }

    }

    //geplaatst blockje  in grid vastleggen
    public void UploadGrid(int[,] grid,int[,] TempBlock)

    {
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                if (TempBlock[i, j] != 0) {
                    grid[i + position[0], j + position[1]] = block[i, j];
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
            Movement(1);
        }
        if (input.KeyPressed(Keys.Left) && setBlock == false)
        {
            Movement(-1);
        }
        if (input.KeyDown(Keys.Down) && setBlock == false)
        {
            speed = 4;
        }
        if (input.KeyDown(Keys.Space) && setBlock == false)
        {
            speed = 0;
        }
        if (input.KeyDown(Keys.Down)==false && input.KeyDown(Keys.Space) == false && setBlock == false)
        {
            speed = Basespeed;
        }
    }

    public void Update(GameTime gameTime)
    {
        if (setBlock == false)
        {
            DownMovement();
        }
        if (setBlock)
        {
            UploadGrid(TetrisGrid.Grid,block);
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

}

