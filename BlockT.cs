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
        block[1, 0] = 6;
        block[0, 1] = 6;
        block[1, 1] = 6;
        block[2, 0] = 6;

        setColor = Color.Maroon;

    }
}

