using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D26 RID: 19750
	public class MarkBookPrevReleaseComponent : HotKeyComponent
	{
		// Token: 0x060334E6 RID: 210150 RVA: 0x00CD6F4E File Offset: 0x00CD514E
		public MarkBookPrevReleaseComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334E7 RID: 210151 RVA: 0x00CD6F57 File Offset: 0x00CD5157
		protected override void OnRelease(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.BookMarkNavigation(ELGUINavigationDirection.Up, base.GetBindButtonTag());
		}

		// Token: 0x060334E8 RID: 210152 RVA: 0x00CD6F6C File Offset: 0x00CD516C
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
