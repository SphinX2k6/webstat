using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D25 RID: 19749
	public class MarkBookNextReleaseComponent : HotKeyComponent
	{
		// Token: 0x060334E3 RID: 210147 RVA: 0x00CD6EDE File Offset: 0x00CD50DE
		public MarkBookNextReleaseComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334E4 RID: 210148 RVA: 0x00CD6EE7 File Offset: 0x00CD50E7
		protected override void OnRelease(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.BookMarkNavigation(ELGUINavigationDirection.Down, base.GetBindButtonTag());
		}

		// Token: 0x060334E5 RID: 210149 RVA: 0x00CD6EFC File Offset: 0x00CD50FC
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (string.IsNullOrEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener activeListenerByTag = viewHandle.GetActiveListenerByTag(bindButtonTag);
			NavigationGroup navigationGroup = (activeListenerByTag != null) ? activeListenerByTag.GetNavigationGroup() : null;
			if (navigationGroup == null)
			{
				return;
			}
			List<TsUiNavigationBehaviorListener> markBookActiveListenerList = ControllerBase<UiNavigationNewController>.Instance.GetMarkBookActiveListenerList(navigationGroup);
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, markBookActiveListenerList.Count > 1, false);
		}
	}
}
