using System;
using MonoTouch.UIKit;
using MonoTouch.MediaPlayer;
using MonoTouch.Foundation;

namespace MonoTouch.MFSideMenu.Demo
{
	public class BasicViewController : UIViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.White;

			var addViewButton = new UIButton (UIButtonType.RoundedRect);
			addViewButton.SetTitle ("Push view", UIControlState.Normal);
			addViewButton.TouchUpInside += AddViewButtonClicked;
			addViewButton.Frame = new System.Drawing.RectangleF (new System.Drawing.PointF((View.Frame.Width / 2) - 50, 50), new System.Drawing.SizeF (100, 45));
			View.AddSubview (addViewButton);

			SetupMenubarButtonItems ();

//			var moviePlayer = new MPMoviePlayerViewController (new NSUrl("http://vjs.zencdn.net/v/oceans.mp4"));
//			PresentMoviePlayerViewController (moviePlayer);
		}

		void AddViewButtonClicked (object sender, EventArgs e)
		{
			NavigationController.PushViewController (new BasicViewController(), true);
		}

		void SetupMenubarButtonItems ()
		{
			NavigationItem.RightBarButtonItem = RightMenubarButtonItem ();
			if (MenuContainerViewController.MenuState == MFSideMenuState.MFSideMenuStateClosed &&
				!(NavigationController.ViewControllers [0] == this)) {
				NavigationItem.LeftBarButtonItem = BackMenubarButtonItem ();
			} else {
				NavigationItem.LeftBarButtonItem = LeftMenubarButtonItem ();
			}
		}

		MFSideMenuContainerViewController MenuContainerViewController {
			get {
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



		public class SideMenuViewController : UITableViewController
		{
			public override void ViewDidLoad ()
			{
				base.ViewDidLoad ();
				base.TableView.Source = new SideMenuTableSource(this);
			}

			public MFSideMenuContainerViewController Container { get; set; }

			public class SideMenuTableSource : UITableViewSource
			{
				SideMenuViewController _controller;

				public SideMenuTableSource (SideMenuViewController viewController)
				{
					_controller = viewController;
				}

				public override int NumberOfSections (UITableView tableView)
				{
					return 2;
				}

				public override int RowsInSection (UITableView tableView, int section)
				{
					return 10;
				}

				public override string TitleForHeader (UITableView tableView, int section)
				{
					return "Section " + section;
				}

				public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
				{
					var cell = tableView.DequeueReusableCell ("cell");

					if (cell == null) {
						cell = new UITableViewCell (UITableViewCellStyle.Default, "cell");
						cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
					}

					cell.TextLabel.Text = "Item " + indexPath.Row;

					return cell;
				}

				public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
				{
					var demoController = new BasicViewController ();
					demoController.Title = "Demo " + indexPath.Section + "-" + indexPath.Row;

					var navigationController = _controller.Container.CenterViewController as UINavigationController;
					navigationController.PushViewController (demoController, true);
					_controller.Container.MenuState = MFSideMenuState.MFSideMenuStateClosed;
				}
			}
		}
	}
}

