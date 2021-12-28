using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public class GuardianAI
    {
        int counter = 1;

        public object GetCommand()
        {
            return GuardianCommand.ForCounter(counter++);
        }
    }
}
