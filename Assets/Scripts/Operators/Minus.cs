namespace Operators
{
    public class Minus : IOperator
    {
        public float Execute(float leftOperand, float rightOperand)
        {
            return leftOperand - rightOperand;
        }
    }
}