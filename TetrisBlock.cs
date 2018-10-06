﻿using Microsoft.Xna.Framework;
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
    Vector2 position;
    public Color setColor; 

    public TetrisBlock()
    {
        //Default Tetris block. 
        block = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        setBlock = false;
        position = new Vector2(0, 0);
    }

    //rotation current tetrisblock. 
    //rotation matrix -> when two matrixes available a and b, with a given. b(x,y) = a(y, x)
    public void RotatingBlock()
    {
        int[,] tempBlock = new int[4, 4];

        for (int x = 0; x < block.GetLength(0); x++)
        {
            for (int y = 0; y < block.GetLength(0); y++)
            {
                tempBlock[x, y] = block[y, x];
            }
        }

        //for (int y = 0; y < block.GetLength(0); y++)
        //{
        //    for (int x = 0; x < block.GetLength(0); x++)
        //    {
        //        if (tempBlock[x, y] != 0) ;
                    
        //    }

        //}
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

