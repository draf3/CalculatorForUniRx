namespace Operators
{
    public class Divided : IOperator
    {
        public float Execute(float leftOperand, float rightOperand)
        {
            return leftOperand / rightOperand;
        }
    }
}