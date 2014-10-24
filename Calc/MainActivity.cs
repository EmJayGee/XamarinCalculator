using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Calc
{
	[Activity (Label = "Calc", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		Calculator calculator = new Calculator(new BuiltinMathEngine());

		TextView textView_display;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			this.textView_display = FindViewById<TextView>(Resource.Id.display);

			// Hook up the buttons to invoke the correct methods on the calculator
			FindViewById<Button>(Resource.Id.button_0).Click += (sender, e) => this.calculator.OnDigitInput(0);
			FindViewById<Button>(Resource.Id.button_1).Click += (sender, e) => this.calculator.OnDigitInput(1);
			FindViewById<Button>(Resource.Id.button_2).Click += (sender, e) => this.calculator.OnDigitInput(2);
			FindViewById<Button>(Resource.Id.button_3).Click += (sender, e) => this.calculator.OnDigitInput(3);
			FindViewById<Button>(Resource.Id.button_4).Click += (sender, e) => this.calculator.OnDigitInput(4);
			FindViewById<Button>(Resource.Id.button_5).Click += (sender, e) => this.calculator.OnDigitInput(5);
			FindViewById<Button>(Resource.Id.button_6).Click += (sender, e) => this.calculator.OnDigitInput(6);
			FindViewById<Button>(Resource.Id.button_7).Click += (sender, e) => this.calculator.OnDigitInput(7);
			FindViewById<Button>(Resource.Id.button_8).Click += (sender, e) => this.calculator.OnDigitInput(8);
			FindViewById<Button>(Resource.Id.button_9).Click += (sender, e) => this.calculator.OnDigitInput(9);

			FindViewById<Button>(Resource.Id.button_add).Click += (o, e) => this.calculator.OnOpInput(Calculator.Op.Add);
			FindViewById<Button>(Resource.Id.button_subtract).Click += (o, e) => this.calculator.OnOpInput(Calculator.Op.Subtract);
			FindViewById<Button>(Resource.Id.button_multiply).Click += (o, e) => this.calculator.OnOpInput(Calculator.Op.Multiply);
			FindViewById<Button>(Resource.Id.button_divide).Click += (o, e) => this.calculator.OnOpInput(Calculator.Op.Divide);

			FindViewById<Button>(Resource.Id.button_equals).Click += (o, e) => this.calculator.OnEqualsInput();
			FindViewById<Button>(Resource.Id.button_clear).Click += (o, e) => this.calculator.OnClearInput();
			FindViewById<Button>(Resource.Id.button_dot).Click += (o, e) => this.calculator.OnDotInput();

			// Change the text shown when the accumulator is changed for the calculator
			this.calculator.AccumulatorChanged += (sender, e) => this.textView_display.Text = e.Value.ToString();
		}
	}
}


