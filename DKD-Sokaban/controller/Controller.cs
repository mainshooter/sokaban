using DKD_Sokaban.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKD_Sokaban {

  public class Controller {
        private Game Game;

        public void Start() {
            StartView start = new StartView(this);
        }

        public void StartViewInput(string input)
        {
            bool canProgress = false;
            switch (input)
            {
                case "1":
                    canProgress = true;
                    break;
                case "2":
                    canProgress = true;
                    break;
                case "3":
                    canProgress = true;
                    break;
                case "4":
                    canProgress = true;
                    break;
				case "5":
					canProgress = true;
					break;
				case "6":
					canProgress = true;
					break;
            }
            if (input == "s") {
                return;
            }
			if (!canProgress) {
				return;
			}
            int loadIndex = Int32.Parse(input) - 1;
            LoadGame(loadIndex);
        }

        public void LoadGame(int index) {
            Game = new Game();
            Game.Parse(index);
            PlayGame();
        }

        public void PlayGame() {
            GameView gameView = new GameView(Game);
            while(Game.Play) {
                var input = Console.ReadKey();
                switch (input.Key) {
                    case ConsoleKey.UpArrow:
                        Move("up");
                        break;
                    case ConsoleKey.DownArrow:
                        Move("down");
                        break;
                    case ConsoleKey.LeftArrow:
                        Move("left");
                        break;
                    case ConsoleKey.RightArrow:
                        Move("right");
                        break;
                    case ConsoleKey.R:
                        Game.Reset();
                        break;
                    case ConsoleKey.S:
                        Game.Stop();
                        return;
                }
                gameView.Render();
                Game.MapCompleted();
            }
            EndGameView endView = new EndGameView();
            endView.ShowEndGame();
            Start();
        }

        public void Move(string direction) {
            Random random = new Random();
            int numberDirection = random.Next(1, 4);
			if (Game.Worker == null) {
				Game.Character.Walk(direction);
				return;
			}
            switch (numberDirection)
            {
                case 1:
                    Game.Worker.Walk("up");
                    break;
                case 2:
                    Game.Worker.Walk("down");
                    break;
                case 3:
                    Game.Worker.Walk("left");
                    break;
                case 4:
                    Game.Worker.Walk("right");
                    break;
                default:
                    break;
            }

            Game.Character.Walk(direction);
        }
    }
}
