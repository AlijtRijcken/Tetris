using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

public class BlockT : TetrisBlock
{
    public BlockT()
    {
        block[2, 1] = 6;
        block[1, 2] = 6;
        block[2, 2] = 6;
        block[3, 1] = 6;

        setColor = Color.Maroon;

    }
}

