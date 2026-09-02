using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CEB RID: 19691
	public class CloseBtnComponent : HotKeyComponent
	{
		// Token: 0x060333CE RID: 209870 RVA: 0x00CD45B2 File Offset: 0x00CD27B2
		public CloseBtnComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333CF RID: 209871 RVA: 0x00CD45BB File Offset: 0x00CD27BB
		protected override void OnPress(HotKeyMap config)
		{
			this.HomeBtnListenerActive = this.CheckHomeBtnListenerActive();
			if (this.HomeBtnListenerActive)
			{
				return;
			}
			ControllerBase<UiNavigationNewController>.Instance.HotKeyCloseView();
		}

		// Token: 0x060333D0 RID: 209872 RVA: 0x00CD45DC File Offset: 0x00CD27DC
		protected override void OnRelease(HotKeyMap config)
		{
			if (!this.HomeBtnListenerActive)
			{
				return;
			}
			ControllerBase<UiNavigationNewController>.Instance.HotKeyCloseView();
		}

		// Token: 0x060333D1 RID: 209873 RVA: 0x00CD45F4 File Offset: 0x00CD27F4
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (StringUtils.IsEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener activeListenerByTag = viewHandle.GetActiveListenerByTag(bindButtonTag);
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, activeListenerByTag != null && activeListenerByTag.IsListenerActive(), false);
		}

		// Token: 0x060333D2 RID: 209874 RVA: 0x00CD462D File Offset: 0x00CD282D
		private bool CheckHomeBtnListenerActive()
		{
			TsUiNavigationBehaviorListener activeListenerByTag = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle().GetActiveListenerByTag("tag_home");
			return activeListenerByTag != null && activeListenerByTag.IsListenerActive();
		}

		// Token: 0x0401DC2E RID: 121902
		private bool HomeBtnListenerActive;
	}
}
