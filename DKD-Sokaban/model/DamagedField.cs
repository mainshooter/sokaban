using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKD_Sokaban.model {
	class DamagedField : Field {
		public int UsesLeft { get; set; }
		private Character _character;
		public override Character Character {
			get {
				return _character;
			}
			set {
				if (value == null) {
					_character = value;
					return;
				}
				if (IsFieldBroken()) {
					return;
				}
				_character = value;
				UsesLeft--;
			}
		}
		private Box _box;

		public override Box Box {
			get {
				return _box;
			}
			set {
				if (value == null) {
					_box = value;
					return;
				}
				if (IsFieldBroken()) {
					return;
				}
				_box = value;
				UsesLeft--;
			}
		}
		public override string FieldCharacter {
			get {
				if (IsFieldBroken()) {
					return " ";
				}
				if (Character != null) {
					return "@";
				} else if (Box != null && !NeedsToHaveBox && WalkOn) {
					return "o";
				} else if (Box != null && NeedsToHaveBox && WalkOn && Character == null) {
					return "0";
				} else if (Box == null && NeedsToHaveBox && WalkOn && Character == null) {
					return "x";
				}
				return "~";
			}
		}
		public DamagedField() : base() {
			UsesLeft = 3;
			IsFieldBroken();
		}

		private bool IsFieldBroken() {
			if (UsesLeft > 0) {
				BrokenField = false;
			}
			else {
				BrokenField = true;
			}
			return BrokenField;
		}
	}
}
