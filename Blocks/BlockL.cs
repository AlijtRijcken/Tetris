using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

public class BlockL : TetrisBlock
{
    public BlockL()
    {
        block[1, 0] = 2;
        block[1, 1] = 2;
        block[1, 2] = 2;
        block[2, 2] = 2;

        setColor = Color.Green;

    }
}

