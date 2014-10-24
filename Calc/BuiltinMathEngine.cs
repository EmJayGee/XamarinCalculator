namespace Calc
{
	class BuiltinMathEngine : IMathEngine{
		double IMathEngine.Add(double left, double right) {
			return left + right;
		}

		double IMathEngine.Subtract(double sum, double subtrahend) {
			return sum - subtrahend;
		}

		double IMathEngine.Multiply(double factor1, double factor2) {
			return factor1 * factor2;
		}

		double IMathEngine.Divide(double numerator, double denominator) {
			return numerator / denominator;
		}
	}
}

