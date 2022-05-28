namespace Operators
{
    public class Plus : IOperator
    {
        public float Execute(float leftOperand, float rightOperand)
        {
            return leftOperand + rightOperand;
        }
    }
}
