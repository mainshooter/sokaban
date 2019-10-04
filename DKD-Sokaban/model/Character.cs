using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DKD_Sokaban {
    public class Character: IWalk {
        public Field Field { get; set; }

        public virtual void Walk(string direction) {
            Field nextField = Field.GetFieldOfDirection(direction);
            if (nextField == null) {
                return;
            }

            if (!nextField.WalkOn) {
                return;
            }

			if (nextField.Box != null) {
                Field nextFieldOfBox = nextField.GetFieldOfDirection(direction);
                if (nextFieldOfBox == null) {
                    return;
                } 
                if (!nextFieldOfBox.WalkOn) {
                    return;
                }
                if (nextFieldOfBox.Box != null) {
                    return;
                }
				if (nextField.BrokenField) {
					nextField.Box = null;
				}
                nextFieldOfBox.Box = nextField.Box;
                nextField.Box = null;
            }
			if (nextField.BrokenField) {
				return;
			}

            if (nextField.Worker != null)
            {
                if (nextField.Worker.IsSleeping)
                {
                    nextField.Worker.WakeUp();
                }
                return;
            }

			Field.Character = null;
            nextField.Character = this;
            Field = nextField;
        }
    }
}