using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BlockJ  : TetrisBlock
{ 
    public BlockJ()
    {
        block[2, 0] = 3;
        block[2, 1] = 3;
        block[2, 2] = 3;
        block[1, 2] = 3;

        setColor = Color.Red;

    }
}


