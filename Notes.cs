using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Notes
    {
        /* 
         Collection of the blok objecten maken? List maken van bv TretrisBlok objecten, elk verschillend Tetris blok is dan weer een sub daarvan. 
         Makkelijk door deze list heen gaan als je random wil kiezen welk TetrisBlok het volgende speel blokje wordt?
        
         Aparte class voor gameRules -> die controleert die alle contstrains afhandelt, scores (hele rij gevuld) 

        Stil staande blokjes sla je op in de grid, dus waard verandert van 0 naar iets anders ( een kleur)
        
        bewegende blokjes: positie bijhouden, 


       
        RemovingRow()
        {
            for (int y = 20; y >= 0; y--)
            {
                for (int x = 0; x < 10; x++)
                {
                    grid[x,y+1] = grid[x,y]
                }

            }
        }

        todo list
        roteren kan niet altijd, clipping met de rand
        volgend blokje zichtbaar in zijbalk
        score
        spawnen in het midden
        niet gelijk setblok omzetten
        instantdrop?
        versnellen drops aan hand van score
         */

    }
}
