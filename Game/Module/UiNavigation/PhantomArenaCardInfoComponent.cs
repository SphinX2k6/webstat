using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D3E RID: 19774
	public class PhantomArenaCardInfoComponent : HotKeyComponent
	{
		// Token: 0x06033542 RID: 210242 RVA: 0x00CD7D27 File Offset: 0x00CD5F27
		public PhantomArenaCardInfoComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033543 RID: 210243 RVA: 0x00CD7D30 File Offset: 0x00CD5F30
		protected override void OnPress(HotKeyMap _)
		{
			TsUiNavigationBehaviorListener currentNavigationFocusListener = ControllerBase<UiNavigationNewController>.Instance.GetCurrentNavigationFocusListener();
			if (currentNavigationFocusListener != null)
			{
				Singleton<EventSystem>.Instance.Emit<UUIItem>(EEventName.GamepadTriggerCardInfo, currentNavigationFocusListener.RootUIComp.Get());
			}
		}

		// Token: 0x06033544 RID: 210244 RVA: 0x00CD7D6C File Offset: 0x00CD5F6C
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
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}
	}
}
