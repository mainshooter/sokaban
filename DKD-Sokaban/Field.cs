using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DKD_Sokaban {
    public class Field {
        public int X {
            get => default;
            set {
            }
        }

        public int Y {
            get => default;
            set {
            }
        }

        public bool WalkOn {
            get => default;
            protected set {
            }
        }

        public Box Box {
            get => default;
            set {
            }
        }

        public Field UpField() {

        }

        public bool NeedsToHaveBox {
            get => default;
            set {
            }
        }

        public Field() {
            WalkOn = true;
        }
    }
}