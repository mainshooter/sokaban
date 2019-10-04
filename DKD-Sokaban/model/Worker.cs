using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKD_Sokaban.model
{
    public class Worker : Character
    {
        public Boolean IsSleeping { get; set; }

        public void CheckForSleep()
        {
            Random random = new Random();
            if(IsSleeping)
            {
                if (random.Next(1, 10) == 1)
                {
                    IsSleeping = false;
                }
            }
            else
            {
                if (random.Next(1, 4) == 3)
                {
                    IsSleeping = true;
                }
            }

        }

        public void WakeUp()
        {
            IsSleeping = false;
        }

        public override void Walk(string direction)
        {
            CheckForSleep();
            if (IsSleeping)
            {
                return;
            }
            Field nextField = Field.GetFieldOfDirection(direction);
            if(nextField.Character != null)
            {
                nextField.Character.Walk(direction);
            }
            if (nextField == null)
            {
                return;
            }

            if (!nextField.WalkOn)
            {
                return;
            }

            if (nextField.Box != null)
            {
                Field nextFieldOfBox = nextField.GetFieldOfDirection(direction);
                if (nextFieldOfBox == null)
                {
                    return;
                }
                if (!nextFieldOfBox.WalkOn)
                {
                    return;
                }
                if (nextFieldOfBox.Box != null)
                {
                    return;
                }
                if (nextField.BrokenField)
                {
                    nextField.Box = null;
                }
                nextFieldOfBox.Box = nextField.Box;
                nextField.Box = null;
            }
            if (nextField.BrokenField)
            {
                return;
            }

            if (nextField.Worker != null)
            {
                return;
            }

            if(nextField.Character != null)
            {
                return;
            }

            Field.Worker = null;
            nextField.Worker = this;
            Field = nextField;
        }
    }
}
