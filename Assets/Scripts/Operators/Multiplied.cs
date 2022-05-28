namespace Operators
{
    public class Multiplied : IOperator
    {
        public float Execute(float leftOperand, float rightOperand)
        {
            return leftOperand * rightOperand;
        }
    }
}