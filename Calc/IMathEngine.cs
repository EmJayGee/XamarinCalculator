
namespace Calc
{
	/// <summary>
	/// Interface to a math engine.
	/// 
	/// Provides the operations used to compute the results of arithmatic operations
	/// 
	/// We use double for the standard for passing values around.  It's possible that
	/// a math engine may want to have a private opaque format but that significantly complicates
	/// the interface and it's unclear how to necessarily map the private format back to
	/// a value that can be represented in the calculator's display.
	/// 
	/// </summary>
	public interface IMathEngine
	{
		double Add(double left, double right);
		double Subtract(double sum, double subtrahend);
		double Multiply(double factor1, double factor2);
		double Divide(double numerator, double denominator);
	}
}
