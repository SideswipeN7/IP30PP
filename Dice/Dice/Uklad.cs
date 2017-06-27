using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    public class Uklad
    {
        public int[] kosci = new int[5];
        public int punkty;
        private int dwojka=0;
        private int trojka=0;
        private bool poker=false;
        private bool kareta = false;
        private string strit;
        private bool full = false;
        

        public Uklad()
        {
           
        }
        public int Graj(int x1, int x2, int x3, int x4, int x5)
        {
            kosci[0] = x1;
            kosci[1] = x2;
            kosci[2] = x3;
            kosci[3] = x4;
            kosci[4] = x5;
            Reset();
            Licz();
            return punkty;
        }

        private void LiczPare()
        {
            int x1 = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (kosci[i] == 1)
                    {
                        x1++;
                    }
                }
            int x2 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (kosci[i] == 2)
                {
                    x2++;
                }
            }
            int x3 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (kosci[i] == 3)
                {
                    x3++;
                }
            }
            int x4 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (kosci[i] == 4)
                {
                    x4++;
                }
            }
            int x5 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (kosci[i] == 5)
                {
                    x5++;
                }
            }
            int x6 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (kosci[i] == 6)
                {
                    x6++;
                }
            }

            if (x1 == 2||x1==4)
            {
                dwojka++;
            }
            if (x2 == 2 || x2 == 4)
            {
                dwojka++;
            }
            if (x3 == 2 || x3 == 4)
            {
                dwojka++;
            }
            if (x4 == 2 || x4 == 4)
            {
                dwojka++;
            }
            if (x5 == 2 || x5 == 4)
            {
                dwojka++;
            }
            if (x6 == 2 || x6 == 4)
            {
                dwojka++;
            }
            //}
        }
        private void LiczTrojke()
        {
            int x1 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (kosci[i] == 1)
                {
                    x1++;
                }
            }
            int x2 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (kosci[i] == 2)
                {
                    x2++;
                }
            }
            int x3 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (kosci[i] == 3)
                {
                    x3++;
                }
            }
            int x4 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (kosci[i] == 4)
                {
                    x4++;
                }
            }
            int x5 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (kosci[i] == 5)
                {
                    x5++;
                }
            }
            int x6 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (kosci[i] == 6)
                {
                    x6++;
                }
            }

            if (x1==3)
            {
                trojka++;
            }
            if (x2 == 3)
            {
                trojka++;
            }
            if (x3 == 3)
            {
                trojka++;
            }
            if (x4 == 3)
            {
                trojka++;
            }
            if (x5 == 3)
            {
                trojka++;
            }
            if (x6 == 3)
            {
                trojka++;
            }
        }
        private void Poker()
        {            
            for(int i =0;i<5; i++)
            {
                if(kosci[i]==kosci[0])
                { poker = true; }
                else { poker = false; }
            }

        }

        private void Kareta()
        {
            int x1 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (kosci[i] == 1)
                {
                    x1++;
                }

                int x2 = 0;
                for (i = 0; i < 5; i++)
                {
                    if (kosci[i] == 2)
                    {
                        x2++;
                    }
                    int x3 = 0;
                    for (i = 0; i < 5; i++)
                    {
                        if (kosci[i] == 3)
                        {
                            x3++;
                        }

                    }

                    int x4 = 0;
                    for (i = 0; i < 5; i++)
                    {
                        if (kosci[i] == 4)
                        {
                            x4++;
                        }

                    }
                    int x5 = 0;
                    for (i = 0; i < 5; i++)
                    {
                        if (kosci[i] == 5)
                        {
                            x5++;
                        }

                    }
                    int x6 = 0;
                    for (i = 0; i < 5; i++)
                    {
                        if (kosci[i] == 6)
                        {
                            x6++;
                        }

                    }
                    if(x1==4)
                    { kareta = true; }
                    if (x2 == 4)
                    { kareta = true; }
                    if (x3 == 4)
                    { kareta = true; }
                    if (x4 == 4)
                    { kareta = true; }
                    if (x5 == 4)
                    { kareta = true; }
                    if (x6 == 4)
                    { kareta = true; }

                }
            }
        }
        private void Strit()
        {
            if(kosci[0]==1&&kosci[1]==2&&kosci[2]==3&&kosci[3]==4&&kosci[4]==5)
            {
                strit = "m";
            }
            if (kosci[0] == 2 && kosci[1] == 3 && kosci[2] == 4 && kosci[3] == 5 && kosci[4]==6)
            {
                strit = "d";
            }

        }
        private void Sortuj()
        {
            int n = kosci.Length;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (kosci[i] > kosci[i + 1])
                    {
                        int tmp = kosci[i];
                        kosci[i] = kosci[i + 1];
                        kosci[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);

        }
        private void Full()
        {
            if(dwojka==1&&trojka==1)
            { full = true; }
        }

        private void Licz()
        {
            Sortuj();
            LiczTrojke();
            LiczPare();
            Poker();
            Kareta();
            Full();
            Strit();
            if (trojka == 1)
            { punkty = 3; }
            if (dwojka == 2)
            { punkty = 2; }
            if (dwojka == 1)
            { punkty = 1; }
            if (poker)
            { punkty = 8; }
            if(kareta)
            { punkty = 7; }
            if(full)
            { punkty = 6; }
            if(strit=="d")
            { punkty = 5; }
            if(strit=="m")
            { punkty = 4; }
            

        }
        private void Reset()
        {
            dwojka = 0;
            trojka = 0;
            poker = false;
            full = false;
            kareta = false;
            strit = "n";
            punkty = 0;
        }
    }
}
