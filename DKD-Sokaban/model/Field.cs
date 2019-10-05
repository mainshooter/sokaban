using DKD_Sokaban.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DKD_Sokaban {
    public class Field {

        public bool WalkOn { get; protected set; }

        public virtual Box Box {get; set;}

        public bool NeedsToHaveBox {get; set;}

        public virtual Character Character {get;set;}

        public virtual Worker Worker { get; set; }

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

		public virtual bool BrokenField { get; protected set; }

		public virtual string FieldCharacter {
			get {
				if (Character != null) {
					return "@";
				}
                else if(Worker != null){
                    if (Worker.IsSleeping)
                    {
                        return "Z";
                    }
                    return "$";
                }
				else if (Box != null && !NeedsToHaveBox && WalkOn) {
					return "o";
				}
				else if (Box != null && NeedsToHaveBox && WalkOn && Character == null) {
					return "0";
				}
				else if (Box == null && NeedsToHaveBox && WalkOn && Character == null) {
					return "x";
				}
				return ".";
			}
		}

        public Field() {
            this.WalkOn = true;
            this.NeedsToHaveBox = false;
			BrokenField = false;
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