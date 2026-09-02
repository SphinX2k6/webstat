using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D0D RID: 19725
	public class HonamiStoryLookComponent : ClickBtnInsideReleaseComponent
	{
		// Token: 0x0603343F RID: 209983 RVA: 0x00CD5565 File Offset: 0x00CD3765
		public HonamiStoryLookComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033440 RID: 209984 RVA: 0x00CD5570 File Offset: 0x00CD3770
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			HonamiStoryGamepadLogicController gamepadLogic = ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic();
			if (gamepadLogic == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, gamepadLogic.GetSelectItem() == null, false);
		}
	}
}
