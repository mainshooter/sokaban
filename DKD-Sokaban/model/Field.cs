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

        public bool NeedsToHaveBox {
            get => default;
            set {
            }
        }

        public Field() {
            WalkOn = true;
            this.NeedsToHaveBox = false;
        }

        public Character Character {
            get => default;
            set {
            }
        }

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
    }
}