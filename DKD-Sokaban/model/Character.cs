﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DKD_Sokaban {
    public class Character: IWalk {
        public Field Field { get; set; }

        public void Walk(string direction) {
            Field field = Field.GetFieldOfDirection(direction);
            if (field == null) {
                return;
            }

            if (!field.WalkOn) {
                return;
            }

            if (field.Box != null) {
                Field nextFieldOfBox = field.GetFieldOfDirection(direction);
                if (nextFieldOfBox == null) {
                    return;
                } 
                if (!nextFieldOfBox.WalkOn) {
                    return;
                }
                if (nextFieldOfBox.Box != null) {
                    return;
                }
                nextFieldOfBox.Box = field.Box;
                field.Box = null;
            }
            Field.Character = null;
            field.Character = this;
            Field = field;
        }
    }
}