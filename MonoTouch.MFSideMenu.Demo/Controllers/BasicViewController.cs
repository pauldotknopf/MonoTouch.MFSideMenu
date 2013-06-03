using System;
using MonoTouch.UIKit;

namespace MonoTouch.MFSideMenu.Demo
{
	public class BasicViewController : UIViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			SetupMenubarButtonItems ();
		}

		void SetupMenubarButtonItems ()
		{
			NavigationItem.RightBarButtonItem = RightMenubarButtonItem ();
			if (MenuContainerViewController.MenuState == MFSideMenuState.MFSideMenuStateClosed &&
				!(NavigationController.ViewControllers[0] == this)) {
				NavigationItem.LeftBarButtonItem = BackMenubarButtonItem ();
			} else {
				NavigationItem.LeftBarButtonItem = LeftMenubarButtonItem ();
			}
		}

		MFSideMenuContainerViewController MenuContainerViewController 
		{
			get 
			{
				return this.NavigationController.ParentViewController as MFSideMenuContainerViewController;
			}
		}

		UIBarButtonItem LeftMenubarButtonItem ()
		{
			return new UIBarButtonItem (UIImage.FromFile("Images/menu-icon.png"), UIBarButtonItemStyle.Bordered, delegate {
				LeftButtonPressed ();
			});
		}

		UIBarButtonItem RightMenubarButtonItem ()
		{
			return new UIBarButtonItem (UIImage.FromFile("Images/menu-icon.png"), UIBarButtonItemStyle.Bordered, delegate {
				RightButtonPressed ();
			});
		}

		UIBarButtonItem BackMenubarButtonItem ()
		{
			return new UIBarButtonItem (UIImage.FromFile("Images/back-arrow.png"), UIBarButtonItemStyle.Bordered, delegate {
				BackButtonPressed ();
			});
		}

		private void LeftButtonPressed ()
		{
			MenuContainerViewController.ToggleLeftSideMenuCompletion (delegate{
				SetupMenubarButtonItems();
			});
		}

		private void RightButtonPressed ()
		{
			MenuContainerViewController.ToggleRightSideMenuCompletion (delegate{
				SetupMenubarButtonItems();
			});
		}

		private void BackButtonPressed ()
		{
			NavigationController.PopViewControllerAnimated (true);
		}

		public class SideMenuViewController : UIViewController
		{
		}
	}
}

