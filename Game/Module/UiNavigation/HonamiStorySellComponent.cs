using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D0C RID: 19724
	public class HonamiStorySellComponent : HonamiStoryComponentBase
	{
		// Token: 0x0603343C RID: 209980 RVA: 0x00CD54EA File Offset: 0x00CD36EA
		public HonamiStorySellComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603343D RID: 209981 RVA: 0x00CD54F3 File Offset: 0x00CD36F3
		protected override void OnPress(HotKeyMap config)
		{
			if (base.Logic == null)
			{
				return;
			}
			base.Logic.SellSingleOne();
		}

		// Token: 0x0603343E RID: 209982 RVA: 0x00CD550C File Offset: 0x00CD370C
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			if (!viewHandle.HasGamepadControlMouse())
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (viewHandle.IsNavigationMousePositionDragging())
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (base.Logic == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, !base.Logic.IsInGame(), false);
		}
	}
}
