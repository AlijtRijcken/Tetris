using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

public class BlockO : TetrisBlock
{
    public BlockO()
    {
        block[1, 1] = 1;
        block[2, 1] = 1;
        block[1, 2] = 1;
        block[2, 2] = 1;

        setColor = Color.Blue;

    }
}

