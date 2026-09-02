using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D73 RID: 19827
	public class TextInputComponent : HotKeyComponent
	{
		// Token: 0x060335E0 RID: 210400 RVA: 0x00CD8D7D File Offset: 0x00CD6F7D
		public TextInputComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335E1 RID: 210401 RVA: 0x00CD8D86 File Offset: 0x00CD6F86
		protected override void OnPress(HotKeyMap config)
		{
			ControllerBase<UiNavigationNewController>.Instance.ActiveTextInput(config.BindButtonTag);
		}

		// Token: 0x060335E2 RID: 210402 RVA: 0x00CD8D9C File Offset: 0x00CD6F9C
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (string.IsNullOrEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener activeListenerByTag = viewHandle.GetActiveListenerByTag(bindButtonTag);
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, activeListenerByTag != null && activeListenerByTag.IsListenerActive(), false);
		}
	}
}
