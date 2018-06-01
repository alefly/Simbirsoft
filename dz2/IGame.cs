using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2
{
    interface IGame
    {
        bool CheckVert();
        bool CheckGoriz();
        bool CheckDiag();
        void CheckMas();
        bool nextStep(int i, int j, int v);
    }
}
