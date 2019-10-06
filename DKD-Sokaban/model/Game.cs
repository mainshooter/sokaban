using DKD_Sokaban.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DKD_Sokaban {
    public class Game {
        public Character Character { get; private set; }
        public Worker Worker { get; private set; }
        public List<List<Field>> Map { get; private set; }
        private int mapIndex;
        public bool Play { get; private set; }

        public string[] Maps { get; private set; }

        public Game() {
            Maps = new string[6] { "doolhof1", "doolhof2", "doolhof3", "doolhof4", "doolhof5", "doolhof6" };
            Play = false;
        }

        public void Stop() {
            Play = false;
        }

        public void Reset() {
            Parse(mapIndex);
        }

        public bool MapCompleted() {
            for (int i = 0; i < Map.Count; i++) {
                List<Field> fieldRow = Map[i];
                for (int j = 0; j < fieldRow.Count; j++) {
                    Field field = fieldRow[j];
                    if (field == null) {
                        continue;
                    }
                    if (field.NeedsToHaveBox && field.Box == null) {
                        Play = true;
                        return false;
                    }
                }
            }
            Play = false;
            return true;
        }

        public void Parse(int index) {
            mapIndex = index;
            string fileName = "map/" + Maps[index];
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
                            Character.Field = newField;
                            break;
                        case 'o':
                            newField = new Field();
                            Box box = new Box();
                            newField.Box = box;
                            break;
                        case '$':
                            newField = new Field();
                            Worker = new Worker();
                            newField.Worker = Worker;
                            Worker.Field = newField;
                            break;
						case '~':
							newField = new DamagedField();
							break;

					}
                    currentFields.Add(newField);
                }
                fields.Add(currentFields);
            }
            this.Map = fields;
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
            Play = true;
        }
    }
}