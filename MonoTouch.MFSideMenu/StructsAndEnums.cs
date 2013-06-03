using System;

namespace MonoTouch.MFSideMenu
{
	public enum MFSideMenuPanMode {
		MFSideMenuPanModeNone = 0,
		MFSideMenuPanModeCenterViewController = 1,
		MFSideMenuPanModeSideMenu = 2,
		MFSideMenuPanModeDefault = 3
	}

	public enum MFSideMenuState {
		MFSideMenuStateClosed = 0,
		MFSideMenuStateLeftMenuOpen = 1,
		MFSideMenuStateRightMenuOpen = 2
	}

	public enum MFSideMenuStateEvent {
		MFSideMenuStateEventMenuWillOpen = 0,
		MFSideMenuStateEventMenuDidOpen = 1,
		MFSideMenuStateEventMenuWillClose = 2,
		MFSideMenuStateEventMenuDidClose = 3
	}
}

