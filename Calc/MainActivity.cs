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
		Calculator calculator = new Calculator();

		Button button_0, button_1, button_2, button_3, button_4, button_5, button_6, button_7, button_8, button_9;
		Button button_add, button_subtract, button_multiply, button_divide, button_equals;
		TextView textView_display;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			this.button_0 = FindViewById<Button>(Resource.Id.button_0);
			this.button_1 = FindViewById<Button>(Resource.Id.button_1);
			this.button_2 = FindViewById<Button>(Resource.Id.button_2);
			this.button_3 = FindViewById<Button>(Resource.Id.button_3);
			this.button_4 = FindViewById<Button>(Resource.Id.button_4);
			this.button_5 = FindViewById<Button>(Resource.Id.button_5);
			this.button_6 = FindViewById<Button>(Resource.Id.button_6);
			this.button_7 = FindViewById<Button>(Resource.Id.button_7);
			this.button_8 = FindViewById<Button>(Resource.Id.button_8);
			this.button_9 = FindViewById<Button>(Resource.Id.button_9);
			this.button_add = FindViewById<Button>(Resource.Id.button_add);
			this.button_subtract = FindViewById<Button>(Resource.Id.button_subtract);
			this.button_multiply = FindViewById<Button>(Resource.Id.button_multiply);
			this.button_divide = FindViewById<Button>(Resource.Id.button_divide);
			this.button_equals = FindViewById<Button>(Resource.Id.button_equals);
			this.textView_display = FindViewById<TextView>(Resource.Id.display);

			this.button_0.Click += (sender, e) => this.calculator.OnDigitInput(0);
			this.button_1.Click += (sender, e) => this.calculator.OnDigitInput(1);
			this.button_2.Click += (sender, e) => this.calculator.OnDigitInput(2);
			this.button_3.Click += (sender, e) => this.calculator.OnDigitInput(3);
			this.button_4.Click += (sender, e) => this.calculator.OnDigitInput(4);
			this.button_5.Click += (sender, e) => this.calculator.OnDigitInput(5);
			this.button_6.Click += (sender, e) => this.calculator.OnDigitInput(6);
			this.button_7.Click += (sender, e) => this.calculator.OnDigitInput(7);
			this.button_8.Click += (sender, e) => this.calculator.OnDigitInput(8);
			this.button_9.Click += (sender, e) => this.calculator.OnDigitInput(9);

			this.calculator.AccumulatorChanged += (sender, e) => this.textView_display.Text = e.Value.ToString();
		}
	}
}


