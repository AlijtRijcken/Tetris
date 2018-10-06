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
        block[0, 1] = 5;
        block[1, 1] = 5;
        block[1, 0] = 5;
        block[2, 1] = 5;

        setColor = Color.Purple;
    }
}

