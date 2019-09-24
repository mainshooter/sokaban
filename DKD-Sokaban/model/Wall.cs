using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DKD_Sokaban {
	public class Wall : Field {

		public override string FieldCharacter {
			get {
				return "█";
			}
		}
        public Wall() {
            this.WalkOn = false;
        }
    }
}