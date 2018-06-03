using dz2;
using System;
using AutoFixture;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class GameFake
    {
        public Game GetGame() {
            Game game = new Fixture().Create<Game>();
            return game;
        }
    }
}
