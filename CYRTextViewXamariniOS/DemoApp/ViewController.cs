﻿using System;

using UIKit;

namespace DemoApp
{
    public partial class ViewController : UIViewController
    {
        //protected ViewController(IntPtr handle) : base(handle)
        //{
        //    // Note: this .ctor should not contain any initialization logic.
        //}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = UIColor.White;
            QEDTextView textView = new QEDTextView(View.Bounds);
            textView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            View.AddSubview(textView);
            textView.Text = @"// Test comment\n\n
    // Let's solve our first equation\n
    x = 1 / (1 + x) // equation to solve for x\n
    x > 0 // restrict to positive root\n\n
    // Let's create a user function\n
    // The standard function random returns a random value between 0 an 1\n
    g(x) := 0.005 * (x + 1) * (x - 1) + 0.1 * (random - 0.5)\n\n
    // Now let's plot the two functions together on one chart\n
    plot f(x), g(x)";
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
