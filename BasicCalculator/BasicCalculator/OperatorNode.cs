using System;

namespace BasicCalculator
{
    internal abstract class EquationNode
    {
        public abstract ValueNode GetResult();
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

        public override ValueNode GetResult()
        {
            switch (Operation)
            {
                case operation.add:
                    return L.GetResult() + R.GetResult();
                case operation.subtract:
                    return L.GetResult() - R.GetResult();
                case operation.multiply:
                    return L.GetResult() * R.GetResult();
                case operation.divide:
                    return L.GetResult() / R.GetResult();
                case operation.modulo:
                    return L.GetResult() % R.GetResult();
                default:
                    throw new ArgumentNullException("Operation");
            }
        }
        public override string ToString()
        {
            string result = "";
            if(!(L is null))
            {
                result += L.ToString();
            }
            switch (Operation)
            {
                case operation.add:
                    result += "+";
                    break;
                case operation.subtract:
                    result += "-";
                    break;
                case operation.multiply:
                    result += "×";
                    break;
                case operation.divide:
                    result += "/";
                    break;
                case operation.modulo:
                    result += "%";
                    break;
                default:
                    break;
            }
            if(!(R is null))
            {
                result += R.ToString();
            }
            return result;
        }
    }
    internal class ValueNode : EquationNode
    {
        private double doubleValue;

        private bool isMonetary;

        public bool IsMonetary
        {
            get { return isMonetary; }
            set { isMonetary = value; }
        }
        public double DoubleValue
        {
            get { return doubleValue; }
            set { doubleValue = value; }
        }
        public ValueNode(double value)
        {
            this.DoubleValue = value;
            this.isMonetary = false;
        }

        public override ValueNode GetResult()
        {
            return this;
        }

        public override string ToString()
        {
            string Result = "";
            double T = Math.Abs(doubleValue);
            
            if (T != doubleValue)
                Result += "-";
            if (isMonetary)
                Result += "€";
            Result += T.ToString();
            return Result;
        }

        public static ValueNode operator +(ValueNode lv,ValueNode rv)
        {
            double n = lv.doubleValue + rv.doubleValue;
            bool ismonetary = lv.isMonetary & rv.isMonetary;
            ValueNode NewNode = new ValueNode(n) { IsMonetary = true };
            return NewNode;
        }
        public static ValueNode operator -(ValueNode lv,ValueNode rv)
        {
            double n = lv.doubleValue - rv.doubleValue;
            bool ismonetary = lv.isMonetary & rv.isMonetary;
            ValueNode NewNode = new ValueNode(n) { IsMonetary = true };
            return NewNode;
        }
        public static ValueNode operator *(ValueNode lv, ValueNode rv)
        {
            double n = lv.doubleValue * rv.doubleValue;
            bool ismonetary = lv.isMonetary | rv.isMonetary;
            ValueNode NewNode = new ValueNode(n) { IsMonetary = true };
            return NewNode;
        }
        public static ValueNode operator /(ValueNode lv, ValueNode rv)
        {
                double n = lv.doubleValue / rv.doubleValue;
                bool ismonetary = lv.isMonetary | rv.isMonetary;
                ValueNode NewNode = new ValueNode(n) { IsMonetary = true };
                return NewNode;   
        }
        public static ValueNode operator %(ValueNode lv, ValueNode rv)
        {
            double n = lv.doubleValue % rv.doubleValue;
            bool ismonetary = lv.isMonetary | rv.isMonetary;
            ValueNode NewNode = new ValueNode(n) { IsMonetary = true };
            return NewNode;
        }
    }
}