using DKD_Sokaban.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKD_Sokaban {

  public class Controller {
        private Game Game;

        public Controller () {

        }

        public void Start() {
            StartView start = new StartView(this);
        }

        public void StartViewInput(string input)
        {
            switch (input)
            {
                case "1":
                    throw new NotImplementedException();
                    break;
                case "2":
                    throw new NotImplementedException();
                    break;
                case "3":
                    throw new NotImplementedException();
                    break;
                case "4":
                    throw new NotImplementedException();
                    break;
                case "s":
                    throw new NotImplementedException();
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }
        }

        public void LoadGame(int index) {
            Game = new Game();
            Game.Parse(index);
        }

        public void Move(string direction) {
            Game.Character.walk(direction);
        }
    }
}
