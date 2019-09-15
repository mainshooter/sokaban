using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DKD_Sokaban {
    public class Character: IWalk {
        public Field Field {
            get => default;
            set {
            }
        }

        public void walk(string direction) {
            Field field = null;
            switch (direction) {
                case "up":
                    field = Field.Up;
                    break;
                case "down":
                    field = Field.Down;
                    break;
                case "left":
                    field = Field.Left;
                    break;
                case "right":
                    field = Field.Right;
                    break;
            }
            if (field == null) {
                return;
            }

            if (!field.WalkOn) {
                return;
            }
            Field = field;
        }
    }
}