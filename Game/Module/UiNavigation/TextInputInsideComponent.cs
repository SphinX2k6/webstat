using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D74 RID: 19828
	public class TextInputInsideComponent : HotKeyComponent
	{
		// Token: 0x060335E3 RID: 210403 RVA: 0x00CD8DD5 File Offset: 0x00CD6FD5
		public TextInputInsideComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335E4 RID: 210404 RVA: 0x00CD8DDE File Offset: 0x00CD6FDE
		protected override void OnPress(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.ActiveTextInputInside(config.BindButtonTag);
		}

		// Token: 0x060335E5 RID: 210405 RVA: 0x00CD8DF4 File Offset: 0x00CD6FF4
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (string.IsNullOrEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (focusListener == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			TsUiNavigationBehaviorListener focusListenerInsideListenerByTag = ControllerBase<UiNavigationNewController>.Instance.GetFocusListenerInsideListenerByTag(focusListener, bindButtonTag);
			if (focusListenerInsideListenerByTag == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, focusListenerInsideListenerByTag != null && focusListenerInsideListenerByTag.IsListenerActive(), false);
		}
	}
}
