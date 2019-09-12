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
        }
    }
}