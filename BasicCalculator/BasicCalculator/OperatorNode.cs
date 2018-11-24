namespace BasicCalculator
{
    internal abstract class EquationNode
    {
        public abstract ValueNode GetValue();
    }
    // Select 
    internal class OperatorNode : EquationNode
    {
        internal operation Operation;
        internal EquationNode L;
        internal EquationNode R;

        public OperatorNode(string newOperator)
        {
            switch (newOperator)
            {
                case "+": Operation = operation.add; break;
                case "-": Operation = operation.subtract; break;
                case "×": Operation = operation.multiply; break;
                case "/": Operation = operation.divide; break;
                case "%": Operation = operation.modulo; break;
                default: Operation = operation.add; break;
            }
        }

        public override ValueNode GetValue()
        {
            throw new System.NotImplementedException();
        }
    }
    internal class ValueNode : EquationNode
    {
        private double v;

        public ValueNode(double v)
        {
            this.v = v;
        }

        public override ValueNode GetValue()
        {
            throw new System.NotImplementedException();
        }
    }
}