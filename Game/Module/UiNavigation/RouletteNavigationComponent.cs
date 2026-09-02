using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D4D RID: 19789
	public class RouletteNavigationComponent : HotKeyComponent
	{
		// Token: 0x06033571 RID: 210289 RVA: 0x00CD8231 File Offset: 0x00CD6431
		public RouletteNavigationComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033572 RID: 210290 RVA: 0x00CD823A File Offset: 0x00CD643A
		protected override void OnPress(HotKeyMap config)
		{
			this.Listener = ControllerBase<UiNavigationNewController>.Instance.GetCurrentNavigationFocusListener();
			this.IsPressSuccess = ControllerBase<UiNavigationNewController>.Instance.Interact(true, config.Id);
		}

		// Token: 0x06033573 RID: 210291 RVA: 0x00CD8264 File Offset: 0x00CD6464
		protected override void OnRelease(HotKeyMap config)
		{
			TsUiNavigationBehaviorListener currentNavigationFocusListener = ControllerBase<UiNavigationNewController>.Instance.GetCurrentNavigationFocusListener();
			bool flag = ControllerBase<UiNavigationNewController>.Instance.Interact(false, config.Id);
			if (this.Listener == currentNavigationFocusListener && this.IsPressSuccess && flag)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.RouletteNavigationComponentEmit);
			}
		}

		// Token: 0x06033574 RID: 210292 RVA: 0x00CD82B8 File Offset: 0x00CD64B8
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (focusListener != null && focusListener.GroupName == "Group1")
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
		}

		// Token: 0x0401DC61 RID: 121953
		[Nullable(2)]
		private TsUiNavigationBehaviorListener Listener;

		// Token: 0x0401DC62 RID: 121954
		private bool IsPressSuccess;
	}
}
