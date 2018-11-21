using System.Collections.Generic;

namespace BasicCalculator
{
    internal enum operation { add, subtract, multiply,divide,modulo}
    internal class Equation
    {
        public List<EquationNode> Left = new List<EquationNode>();
    }
}