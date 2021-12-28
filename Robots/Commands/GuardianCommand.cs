using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    class GuardianCommand : IGuardianMoveCommand
    {
        public Point Destination
        {
            get; set;
        }
        public bool ShouldGuard { get; set; }

        public static GuardianCommand ForCounter(int counter)
        {
            return new GuardianCommand
            {
                Destination = new Point { X = counter * 0.5, Y = counter * 0.5 },
                ShouldGuard = counter % 2 == 0
            };
        }
    }
}
