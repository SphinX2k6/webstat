using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D24 RID: 19748
	public class MarkBookPrevComponent : HotKeyComponent
	{
		// Token: 0x060334E0 RID: 210144 RVA: 0x00CD6E6E File Offset: 0x00CD506E
		public MarkBookPrevComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334E1 RID: 210145 RVA: 0x00CD6E77 File Offset: 0x00CD5077
		protected override void OnPress(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.BookMarkNavigation(ELGUINavigationDirection.Up, base.GetBindButtonTag());
		}

		// Token: 0x060334E2 RID: 210146 RVA: 0x00CD6E8C File Offset: 0x00CD508C
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
