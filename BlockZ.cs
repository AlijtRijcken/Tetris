﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

public class BlockZ : TetrisBlock
{
    public BlockZ()
    {
        block[0, 0] = 7;
        block[1, 0] = 7;
        block[1, 1] = 7;
        block[2, 1] = 7;

        setColor = Color.BlanchedAlmond; 
    }
}
