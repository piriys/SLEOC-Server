using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLEOC.Helpers
{
    public static class MathHelpers
    {
        public static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;  
        }
    }
}