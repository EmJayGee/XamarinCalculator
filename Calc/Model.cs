﻿using System.Collections.Generic;

namespace Calc
{
	/// <summary>
	/// The Calculator class represents an object that performs the functions of a calculator.
	/// 
	/// We will use double for the type of values manipulated.  It would be slightly nicer to use
	/// a BigNum style arbitrary precision package because we are not performance sensitive here and
	/// it would be preferable for the user to not be exposed to the oddities of IEEE floating point
	/// but there is not one built in to the .net framework today and I didn't want to pick one up
	/// from somewhere.
	/// 
	/// Ironically my Java implementation of a similar project uses the built-in BigDecimal type
	/// which serves the function well.  Maybe someone will extend the framework with a big decimal
	/// type at some point.
	/// 
	/// </summary>
	public class Calculator
	{
		public enum Op
		{
			Add,
			Subtract,
			Multiply,
			Divide
		};

		/// <summary>
		/// The saved operation and value pushed on a stack to deal with operator precedence.  For example
		/// if the input is "1", "2", "+", "5", "2", "*" we have to resovle the 52 times whatever comes
		/// next before adding 12 so on the "+" input, the pair (+, 12) is pushed then when the * comes,
		/// the pair (*, 52) is pushed.  If the 2nd operator had been another plus (or any operator with
		/// the same precedence), the top of the stack and the current accumulator would be evaluated
		/// and then the sum and the + operator would be pushed.
		/// </summary>
		private class SavedOpAndValue
		{
			public SavedOpAndValue(Op op, double value)
			{
				this.op = op;
				this.value = value;
			}

			private Op op;
			private double value;
		}

		// Follow the event pattern for notifying of accumulator changes
		public class AccumulatorChangedEventArgs
		{
			public AccumulatorChangedEventArgs(double value)
			{
				this.value = value;
			}

			public double Value { get { return this.value; } }

			private double value;
		}

		public delegate void AccumulatorChangedHandler(object sender, AccumulatorChangedEventArgs args);

		public event AccumulatorChangedHandler AccumulatorChanged;

		// Follow the event pattern for notifying of input error
		public class InputErrorEventArgs
		{
			public InputErrorEventArgs()
			{
			}
		}

		public delegate void InputErrorHandler(object sender, InputErrorEventArgs args);

		public event InputErrorHandler InputError;

		public double Accumulator
		{
			get { return this.Accumulator; }
			set
			{
				this.accumulator = value;
				if (this.AccumulatorChanged != null)
					this.AccumulatorChanged (this, new AccumulatorChangedEventArgs (value));
			}
		}

		public void OnDigitInput(int digit)
		{
			if (this.resetAccumulatorOnNextDigit) {
				this.Accumulator = 0;
				this.resetAccumulatorOnNextDigit = false;
			}

			double newAccumulator;

			// For now we assume we append the digit to the right of the accumulator.
			if (postRadixFactor == 0) {
				// no decimal point yet so multiply the current accumulator by 10, add the digit and refresh.
				newAccumulator = (this.accumulator * 10.0) + digit;
			} else {
				newAccumulator = this.accumulator + (this.postRadixFactor * ((double)digit));
				this.postRadixFactor = this.postRadixFactor / 10;
			}

			this.Accumulator = newAccumulator;
		}

		public void OnDotInput()
		{
			if (this.postRadixFactor != 0) {
				this.RaiseInputError ();
			} else {
				if (this.resetAccumulatorOnNextDigit) {
					this.Accumulator = 0;
					this.resetAccumulatorOnNextDigit = false;
				}

				// Set the post radix factor to 1/10 since the next digit input will be the tenths place
				this.postRadixFactor = 0.1;
			}
		}

		public void OnOpInput(Op op)
		{
			this.opStack.Push (new SavedOpAndValue (op, this.accumulator));
			this.resetAccumulatorOnNextDigit = true;
		}

		public void OnEqualsInput()
		{
			if (this.opStack.Count == 0) {
				// Pressing 1 then 2 then 3 then equals just leaves the accumulator at 123.
			} else if (this.opStack.Count == 1) {
				// If there's one operation on the stack, perform it.
			} else {
				// If the operation stack has more than one operation this is an input error.
				this.RaiseInputError ();
			}
		}

		protected void RaiseInputError()
		{
			if (this.InputError != null)
				this.InputError(this, new InputErrorEventArgs());
		}

		#region Private fields

		private double accumulator = 0;
		private double postRadixFactor = 0; // 0 before decimal is entered, 0.1, 0.01, etc. after.
		private readonly Stack<SavedOpAndValue> opStack = new Stack<SavedOpAndValue>();
		private bool resetAccumulatorOnNextDigit = false; // used to emulate calculator behavior where latest intermediate result is displayed until the next input occurs

		#endregion
	}
}
