using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CCC RID: 19660
	public class NavigationRouletteExitButton : NavigationButton, INavigationInteractPrevGroup
	{
		// Token: 0x060332BE RID: 209598 RVA: 0x00CCF7AD File Offset: 0x00CCD9AD
		[NullableContext(1)]
		public NavigationRouletteExitButton(ULGUIBehaviour selectable, string type, List<string> paramList) : base(selectable, type, paramList)
		{
		}

		// Token: 0x060332BF RID: 209599 RVA: 0x00CCF7B8 File Offset: 0x00CCD9B8
		public void InteractClickPrevGroup()
		{
			TsUiNavigationBehaviorListener currentNavigationFocusListener = ControllerBase<UiNavigationNewController>.Instance.GetCurrentNavigationFocusListener();
			if (((currentNavigationFocusListener != null) ? currentNavigationFocusListener.GroupName : null) == "Group1")
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnRouletteItemUnlock);
			}
		}
	}
}
