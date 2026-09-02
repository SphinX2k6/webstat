using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D09 RID: 19721
	public class HonamiStoryPickUpDownComponent : HonamiStoryComponentBase
	{
		// Token: 0x06033433 RID: 209971 RVA: 0x00CD5324 File Offset: 0x00CD3524
		public HonamiStoryPickUpDownComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033434 RID: 209972 RVA: 0x00CD532D File Offset: 0x00CD352D
		protected override void OnPress(HotKeyMap config)
		{
		}

		// Token: 0x06033435 RID: 209973 RVA: 0x00CD532F File Offset: 0x00CD352F
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			if (base.Logic == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}
	}
}
