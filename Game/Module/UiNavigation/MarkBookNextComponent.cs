using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D23 RID: 19747
	public class MarkBookNextComponent : HotKeyComponent
	{
		// Token: 0x060334DD RID: 210141 RVA: 0x00CD6DFE File Offset: 0x00CD4FFE
		public MarkBookNextComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334DE RID: 210142 RVA: 0x00CD6E07 File Offset: 0x00CD5007
		protected override void OnPress(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.BookMarkNavigation(ELGUINavigationDirection.Down, base.GetBindButtonTag());
		}

		// Token: 0x060334DF RID: 210143 RVA: 0x00CD6E1C File Offset: 0x00CD501C
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
