using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D07 RID: 19719
	public class HonamiStoryMoveLeftComponent : HonamiStoryComponentBase
	{
		// Token: 0x0603342D RID: 209965 RVA: 0x00CD52AC File Offset: 0x00CD34AC
		public HonamiStoryMoveLeftComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603342E RID: 209966 RVA: 0x00CD52B5 File Offset: 0x00CD34B5
		protected override void OnPress(HotKeyMap config)
		{
			if (base.Logic == null)
			{
				return;
			}
			base.Logic.JumpToPrevPanelNew();
		}

		// Token: 0x0603342F RID: 209967 RVA: 0x00CD52CB File Offset: 0x00CD34CB
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
