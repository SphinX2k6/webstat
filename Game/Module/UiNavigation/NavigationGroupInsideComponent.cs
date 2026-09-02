using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D35 RID: 19765
	public class NavigationGroupInsideComponent : HotKeyComponent
	{
		// Token: 0x06033519 RID: 210201 RVA: 0x00CD74ED File Offset: 0x00CD56ED
		public NavigationGroupInsideComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603351A RID: 210202 RVA: 0x00CD74F6 File Offset: 0x00CD56F6
		protected override void OnRelease(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.JumpInsideNavigationGroup();
		}

		// Token: 0x0603351B RID: 210203 RVA: 0x00CD7504 File Offset: 0x00CD5704
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (focusListener == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (!base.IsLinkListener(focusListener.GetOwner()))
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (ControllerBase<UiNavigationNewController>.Instance.GetCanFocusInsideListener(focusListener) == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}
	}
}
