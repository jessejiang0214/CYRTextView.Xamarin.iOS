using System;
using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace CYRTextViewXamariniOS
{
    // @interface CYRLayoutManager : NSLayoutManager
    [BaseType(typeof(NSLayoutManager))]
    interface CYRLayoutManager
    {
        // @property (nonatomic, strong) UIFont * lineNumberFont;
        [Export("lineNumberFont", ArgumentSemantic.Strong)]
        UIFont LineNumberFont { get; set; }

        // @property (nonatomic, strong) UIColor * lineNumberColor;
        [Export("lineNumberColor", ArgumentSemantic.Strong)]
        UIColor LineNumberColor { get; set; }

        // @property (nonatomic, strong) UIColor * selectedLineNumberColor;
        [Export("selectedLineNumberColor", ArgumentSemantic.Strong)]
        UIColor SelectedLineNumberColor { get; set; }

        // @property (readonly, nonatomic) CGFloat gutterWidth;
        [Export("gutterWidth")]
        nfloat GutterWidth { get; }

        // @property (assign, nonatomic) NSRange selectedRange;
        [Export("selectedRange", ArgumentSemantic.Assign)]
        NSRange SelectedRange { get; set; }

        // -(CGRect)paragraphRectForRange:(NSRange)range;
        [Export("paragraphRectForRange:")]
        CGRect ParagraphRectForRange(NSRange range);
    }

    // @interface CYRTextStorage : NSTextStorage
    [BaseType(typeof(NSTextStorage))]
    interface CYRTextStorage
    {
        // @property (nonatomic, strong) NSArray * tokens;
        [Export("tokens", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] Tokens { get; set; }

        // @property (nonatomic, strong) UIFont * defaultFont;
        [Export("defaultFont", ArgumentSemantic.Strong)]
        UIFont DefaultFont { get; set; }

        // @property (nonatomic, strong) UIColor * defaultTextColor;
        [Export("defaultTextColor", ArgumentSemantic.Strong)]
        UIColor DefaultTextColor { get; set; }

        // -(void)update;
        [Export("update")]
        void Update();
    }

    // @interface CYRToken : NSObject
    [BaseType(typeof(NSObject))]
    interface CYRToken
    {
        // @property (nonatomic, strong) NSString * name;
        [Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * expression;
        [Export("expression", ArgumentSemantic.Strong)]
        string Expression { get; set; }

        // @property (nonatomic, strong) NSDictionary * attributes;
        [Export("attributes", ArgumentSemantic.Strong)]
        NSDictionary Attributes { get; set; }

        // +(instancetype)tokenWithName:(NSString *)name expression:(NSString *)expression attributes:(NSDictionary *)attributes;
        [Static]
        [Export("tokenWithName:expression:attributes:")]
        CYRToken TokenWithName(string name, string expression, NSDictionary attributes);
    }

    // @interface CYRTextView : UITextView
    [BaseType(typeof(UITextView))]
    interface CYRTextView
    {
        // @property (nonatomic, strong) NSArray * tokens;
        [Export("tokens", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        CYRToken[] Tokens { get; set; }

        // @property (nonatomic, strong) UIPanGestureRecognizer * singleFingerPanRecognizer;
        [Export("singleFingerPanRecognizer", ArgumentSemantic.Strong)]
        UIPanGestureRecognizer SingleFingerPanRecognizer { get; set; }

        // @property (nonatomic, strong) UIPanGestureRecognizer * doubleFingerPanRecognizer;
        [Export("doubleFingerPanRecognizer", ArgumentSemantic.Strong)]
        UIPanGestureRecognizer DoubleFingerPanRecognizer { get; set; }

        // @property UIColor * gutterBackgroundColor;
        [Export("gutterBackgroundColor", ArgumentSemantic.Assign)]
        UIColor GutterBackgroundColor { get; set; }

        // @property UIColor * gutterLineColor;
        [Export("gutterLineColor", ArgumentSemantic.Assign)]
        UIColor GutterLineColor { get; set; }

        // @property (assign, nonatomic) BOOL lineCursorEnabled;
        [Export("lineCursorEnabled")]
        bool LineCursorEnabled { get; set; }

        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    [Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern double CYRTextViewVersionNumber;
        //[Field("CYRTextViewVersionNumber", "__Internal")]
        //double CYRTextViewVersionNumber { get; }

        // extern const unsigned char [] CYRTextViewVersionString;
        //[Field("CYRTextViewVersionString", "__Internal")]
        //int[] CYRTextViewVersionString { get; }
    }
}
