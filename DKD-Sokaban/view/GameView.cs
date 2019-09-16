using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKD_Sokaban.view {
    class GameView {
        private Game game;

        public GameView(Game game) {
            this.game = game;
        }

        public void Render() {

            Console.Clear();
            for (int i = 0; i < game.Map.Count; i++) {
                string row = "";
                List<Field> fieldRow = game.Map[i];
                for (int j = 0; j < fieldRow.Count; j++) {
                    Field field = fieldRow[j];

                    if (field.Character != null) {
                        row += "@";
                    }
                    else if (!field.WalkOn) {
                        row += "M";
                    }
                    else if (field.Box == null && !field.NeedsToHaveBox && field.Character == null) {
                        row += ".";
                    }
                    else if (field.Box != null && !field.NeedsToHaveBox && field.WalkOn) {
                        row += "o";
                    }
                    else if (field.Box != null && field.NeedsToHaveBox && field.WalkOn && field.Character == null) {
                        row += "0";
                    }
                    else if (field.Box == null && field.NeedsToHaveBox && field.WalkOn && field.Character == null) {
                        row += "x";
                    }
                }
                Console.WriteLine(row);
            }
        }
    }
}
