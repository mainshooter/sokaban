using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DKD_Sokaban {
    public class Field {
        public int X { get; set; }

        public int Y { get; set; }

        public bool WalkOn { get; protected set; }

        public Box Box {get; set;}

        public bool NeedsToHaveBox {get; set;}

        public Character Character {get;set;}

        public Field Up {
            get; set;
        }

        public Field Down {
            get; set;
        }

        public Field Left {
            get; set;
        }

        public Field Right {
            get; set;
        }

        public Field() {
            this.WalkOn = true;
            this.NeedsToHaveBox = false;
        }

        public Field GetFieldOfDirection(string direction) {
            Field field = null;
            switch (direction) {
                case "up":
                    field = Up;
                    break;
                case "down":
                    field = Down;
                    break;
                case "left":
                    field = Left;
                    break;
                case "right":
                    field = Right;
                    break;
            }
            return field;
        }
    }
}