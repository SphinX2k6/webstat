using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CEC RID: 19692
	public class CommonConsumeNavigationInsideNext : HotKeyComponent
	{
		// Token: 0x060333D3 RID: 209875 RVA: 0x00CD464E File Offset: 0x00CD284E
		public CommonConsumeNavigationInsideNext(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333D4 RID: 209876 RVA: 0x00CD4657 File Offset: 0x00CD2857
		protected override void OnRelease(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.HandleCommonConsumeNavigationInside();
		}

		// Token: 0x060333D5 RID: 209877 RVA: 0x00CD4664 File Offset: 0x00CD2864
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
