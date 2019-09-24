using DKD_Sokaban.model;
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
					// In Field moet vertellen
                    Field field = fieldRow[j];
					row += field.FieldCharacter;
                }
                Console.WriteLine(row);
            }
        }
    }
}
