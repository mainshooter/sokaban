using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DKD_Sokaban {
    public class Game {
        private Character Character;
        private Field startField;

        public string[] maps { get; private set; }

        public Game() {
            maps = new string[4] { "doolhof1", "doolhof2", "doolhof3", "doolhof4" };
        }

        public void Parse(int index) {
            string fileName = "map/" + maps[index];
            fileName += ".txt";
            var lines = File.ReadAllLines(fileName);
            List<List<Field>> fields = new List<List<Field>>();
            for (var i = 0; i < lines.Length; i += 1) {
                var line = lines[i];
                List<Field> currentFields = new List<Field>();
                for (int j = 0; j < line.Length; j++) {
                    Field newField = null;
                    var gameMapChar = line[j];
                    switch (gameMapChar) {
                        case '#':
                            // Add wall
                            newField = new Wall();
                            break;
                        case '.':
                            // Add Field
                            newField = new Field();
                            break;
                        case 'x':
                            // Destination field
                            newField = new DestinationField();
                            break;
                        case '@':
                            // Character
                            newField = new Field();
                            Character = new Character();
                            newField.Character = Character;
                            startField = newField;
                            break;
                        case 'o':
                            newField = new Field();
                            Box box = new Box();
                            newField.Box = box;
                            break;
                    }
                    currentFields.Add(newField);
                }
                fields.Add(currentFields);
            }
            for (int i = fields.Count - 1; i >= 0; i--) {
                var fieldRow = fields[i];
                for (int j = fieldRow.Count - 1; j >= 0; j--) {
                    Field field = fieldRow[j];
                    if (field == null) {
                        continue;
                    }
                    if (i > 0) {
                        Field upperField = fields[i - 1][j];
                        field.Up = upperField;
                    }
                    if (i < fields.Count - 1) {
                        // Field down
                        Field downField = fields[i + 1][j];
                        field.Down = downField;
                    }
                    if (j > 0) {
                        Field leftField = fields[i][j - 1];
                        field.Left = leftField;
                    }
                    if (j < fieldRow.Count - 1) {
                        Field rightField = fields[i][j + 1];
                        field.Right = rightField;
                    }
                }
            }
        }
    }
}