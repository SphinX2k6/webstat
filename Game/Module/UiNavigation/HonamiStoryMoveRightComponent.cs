using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D08 RID: 19720
	public class HonamiStoryMoveRightComponent : HonamiStoryComponentBase
	{
		// Token: 0x06033430 RID: 209968 RVA: 0x00CD52E8 File Offset: 0x00CD34E8
		public HonamiStoryMoveRightComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033431 RID: 209969 RVA: 0x00CD52F1 File Offset: 0x00CD34F1
		protected override void OnPress(HotKeyMap config)
		{
			if (base.Logic == null)
			{
				return;
			}
			base.Logic.JumpToNextPanelNew();
		}

		// Token: 0x06033432 RID: 209970 RVA: 0x00CD5307 File Offset: 0x00CD3507
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
