using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKD_Sokaban {
    class Controller {
        private Game Game;

        public Controller () {

        }

        public void Start() {

        }

        public void LoadGame(int index) {
            Game = new Game();
            Game.Parse(index);
        }
    }
}
