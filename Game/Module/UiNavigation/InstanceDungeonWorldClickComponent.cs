using System;
using Aki.Config;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D0F RID: 19727
	public class InstanceDungeonWorldClickComponent : HotKeyComponent
	{
		// Token: 0x06033486 RID: 210054 RVA: 0x00CD6163 File Offset: 0x00CD4363
		public InstanceDungeonWorldClickComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033487 RID: 210055 RVA: 0x00CD616C File Offset: 0x00CD436C
		protected override bool OnIsOccupancyFightInput()
		{
			return !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.InteractionHintView);
		}

		// Token: 0x06033488 RID: 210056 RVA: 0x00CD6182 File Offset: 0x00CD4382
		protected override void OnPress(HotKeyMap config)
		{
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.InteractionHintView))
			{
				return;
			}
			ControllerBase<UiNavigationNewController>.Instance.ClickButton(config.BindButtonTag);
		}
	}
}
