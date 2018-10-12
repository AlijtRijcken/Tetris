using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

public class BlockI : TetrisBlock
{
    
    public BlockI()
    {
        block[1, 0] = 4;
        block[1, 1] = 4;
        block[1, 2] = 4   ;
        block[1, 3] = 4;

        setColor = Color.Pink; 

    }
}
