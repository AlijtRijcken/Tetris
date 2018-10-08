using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

public class BlockS : TetrisBlock
{
    public BlockS()
    {
        block[1, 2] = 5;
        block[2, 2] = 5;
        block[2, 1] = 5;
        block[3, 2] = 5;

        setColor = Color.Purple;
    }
}

