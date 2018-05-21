using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    interface IGame
    {
        bool checkVert();
        bool checkGoriz();
        bool checkDiag();
        void checkMas();
        bool nextStep(int i, int j, int v);
    }
}
