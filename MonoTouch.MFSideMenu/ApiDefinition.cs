using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonoTouch.MFSideMenu
{
	public delegate void CompletionDelegate();

	[BaseType (typeof (UIViewController))]
	public partial interface MFSideMenuContainerViewController {

		[Static, Export ("containerWithCenterViewController:leftMenuViewController:rightMenuViewController:")]
		MFSideMenuContainerViewController ContainerWithCenterViewController ([NullAllowed]NSObject centerViewController, [NullAllowed]NSObject leftMenuViewController, [NullAllowed]NSObject rightMenuViewController);

		[Export ("centerViewController")]
		NSObject CenterViewController { get; set; }

		[Export ("leftMenuViewController")]
		UIViewController LeftMenuViewController { get; set; }

		[Export ("rightMenuViewController")]
		UIViewController RightMenuViewController { get; set; }

		[Export ("menuState")]
		MFSideMenuState MenuState { get; set; }

		[Export ("panMode")]
		MFSideMenuPanMode PanMode { get; set; }

		[Export ("menuAnimationDefaultDuration")]
		float MenuAnimationDefaultDuration { get; set; }

		[Export ("menuAnimationMaxDuration")]
		float MenuAnimationMaxDuration { get; set; }

		[Export ("menuWidth")]
		float MenuWidth { get; set; }

		[Export ("leftMenuWidth")]
		float LeftMenuWidth { get; set; }

		[Export ("rightMenuWidth")]
		float RightMenuWidth { get; set; }

		[Export ("shadowEnabled")]
		bool ShadowEnabled { get; set; }

		[Export ("shadowRadius")]
		float ShadowRadius { get; set; }

		[Export ("shadowOpacity")]
		float ShadowOpacity { get; set; }

		[Export ("shadowColor")]
		UIColor ShadowColor { get; set; }

		[Export ("menuSlideAnimationEnabled")]
		bool MenuSlideAnimationEnabled { get; set; }

		[Export ("menuSlideAnimationFactor")]
		float MenuSlideAnimationFactor { get; set; }

		[Export ("toggleLeftSideMenuCompletion:")]
		void ToggleLeftSideMenuCompletion (CompletionDelegate completion);

		[Export ("toggleRightSideMenuCompletion:")]
		void ToggleRightSideMenuCompletion (CompletionDelegate completion);
	}
}

