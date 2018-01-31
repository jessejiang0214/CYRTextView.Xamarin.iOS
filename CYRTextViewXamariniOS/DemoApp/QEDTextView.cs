using System;
using CoreGraphics;
using CYRTextViewXamariniOS;
using Foundation;
using UIKit;

namespace DemoApp
{
    public class QEDTextView : CYRTextView
    {
        public UIFont DefaultFont;
        public UIFont BoldFont;
        public UIFont ItalicFont;

        public QEDTextView(CGRect frame) : base(frame)
        {
            DefaultFont = UIFont.SystemFontOfSize(14);
            BoldFont = UIFont.BoldSystemFontOfSize(14);
            ItalicFont = UIFont.ItalicSystemFontOfSize(14);

            Font = DefaultFont;
            TextColor = UIColor.Black;
            Tokens = SolverTokens();
        }

        CYRToken[] SolverTokens()
        {
            return new CYRToken[]{
                CYRToken.TokenWithName("special_numbers","[ʝ]",new NSDictionary<NSString, NSObject> (UIStringAttributeKey.ForegroundColor,UIColor.FromRGB(0,0,255))),
                CYRToken.TokenWithName("mod",@"\bmod\b",new NSDictionary<NSString, NSObject> (UIStringAttributeKey.ForegroundColor,UIColor.FromRGB(245, 0, 110))),
                CYRToken.TokenWithName("string",@"\"".*?(\""|$)",new NSDictionary<NSString, NSObject> (UIStringAttributeKey.ForegroundColor,UIColor.FromRGB(24, 110, 109))),
                CYRToken.TokenWithName("hex_1",@"\\$[\\d a-f]+",new NSDictionary<NSString, NSObject> (UIStringAttributeKey.ForegroundColor,UIColor.FromRGB(0, 0, 255))),
                CYRToken.TokenWithName("octal_1",@"&[0-7]+",new NSDictionary<NSString, NSObject> (UIStringAttributeKey.ForegroundColor,UIColor.FromRGB(0, 0, 255))),
                CYRToken.TokenWithName("binary_1",@"%[01]+",new NSDictionary<NSString, NSObject> (UIStringAttributeKey.ForegroundColor,UIColor.FromRGB(0, 0, 255))),
                CYRToken.TokenWithName("float",@"\\d+\\.?\\d+e[\\+\\-]?\\d+|\\d+\\.\\d+|∞",new NSDictionary<NSString, NSObject> (UIStringAttributeKey.ForegroundColor,UIColor.FromRGB(0, 0, 255))),
                CYRToken.TokenWithName("integer",@"\\d+",new NSDictionary<NSString, NSObject> (UIStringAttributeKey.ForegroundColor,UIColor.FromRGB(0, 0, 255))),
                CYRToken.TokenWithName("operator",@"[/\\*,\\;:=<>\\+\\-\\^!·≤≥]",new NSDictionary<NSString, NSObject> (UIStringAttributeKey.ForegroundColor,UIColor.FromRGB(245,0,110))),
                CYRToken.TokenWithName("round_brackets",@"[\\(\\)]",new NSDictionary<NSString, NSObject> (UIStringAttributeKey.ForegroundColor,UIColor.FromRGB(161,75,0))),
                CYRToken.TokenWithName("square_brackets",@"[\\[\\]]",new NSDictionary<NSString, NSObject> (new NSString[]{UIStringAttributeKey.ForegroundColor, UIStringAttributeKey.Font}, new NSObject[]{UIColor.FromRGB(105,0,0),BoldFont})),
                CYRToken.TokenWithName("absolute_brackets",@"[|]",new NSDictionary<NSString, NSObject> (UIStringAttributeKey.ForegroundColor,UIColor.FromRGB(104,0, 111))),
                CYRToken.TokenWithName("reserved_words",@"(abs|acos|acosh|asin|asinh|atan|atanh|atomicweight|ceil|complex|cos|cosh|crandom|deriv|erf|erfc|exp|eye|floor|frac|gamma|gaussel|getconst|imag|inf|integ|integhq|inv|ln|log10|log2|machineprecision|max|maximize|min|minimize|molecularweight|ncum|ones|pi|plot|random|real|round|sgn|sin|sqr|sinh|sqrt|tan|tanh|transpose|trunc|var|zeros)",new NSDictionary<NSString, NSObject> (new NSString[]{UIStringAttributeKey.ForegroundColor, UIStringAttributeKey.Font}, new NSObject[]{UIColor.FromRGB(104,0,111),BoldFont})),
                CYRToken.TokenWithName("chart_parameters",@"(chartheight|charttitle|chartwidth|color|seriesname|showlegend|showxmajorgrid|showxminorgrid|showymajorgrid|showyminorgrid|transparency|thickness|xautoscale|xaxisrange|xlabel|xlogscale|xrange|yautoscale|yaxisrange|ylabel|ylogscale|yrange)",new NSDictionary<NSString, NSObject> (UIStringAttributeKey.ForegroundColor,UIColor.FromRGB(11,81, 195))),
                CYRToken.TokenWithName("commentbrackets",@"//.*",new NSDictionary<NSString, NSObject> (new NSString[]{UIStringAttributeKey.ForegroundColor, UIStringAttributeKey.Font}, new NSObject[]{UIColor.FromRGB(31,131,0),ItalicFont})),
            };
        }

        public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
        {
            base.ObserveValue(keyPath, ofObject, change, context);
        }
    }
}
