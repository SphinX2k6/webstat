using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CE6 RID: 19686
	[NullableContext(1)]
	[Nullable(0)]
	public class ClickBtnComponent : HotKeyComponent
	{
		// Token: 0x060333B8 RID: 209848 RVA: 0x00CD41E8 File Offset: 0x00CD23E8
		public ClickBtnComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333B9 RID: 209849 RVA: 0x00CD41F1 File Offset: 0x00CD23F1
		protected override void OnPress(HotKeyMap config)
		{
			this.ClickButton(config.BindButtonTag);
		}

		// Token: 0x060333BA RID: 209850 RVA: 0x00CD4200 File Offset: 0x00CD2400
		private void ClickButton(string tag)
		{
			if (tag == "tag1")
			{
				ControllerBase<UiNavigationNewController>.Instance.HotKeyCloseView();
				return;
			}
			ControllerBase<UiNavigationNewController>.Instance.ClickButton(tag);
		}

		// Token: 0x060333BB RID: 209851 RVA: 0x00CD4228 File Offset: 0x00CD2428
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
