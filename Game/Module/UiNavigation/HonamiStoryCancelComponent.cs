using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D01 RID: 19713
	public class HonamiStoryCancelComponent : HonamiStoryComponentBase
	{
		// Token: 0x0603341D RID: 209949 RVA: 0x00CD5032 File Offset: 0x00CD3232
		public HonamiStoryCancelComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603341E RID: 209950 RVA: 0x00CD503B File Offset: 0x00CD323B
		protected override void OnPress(HotKeyMap config)
		{
			if (base.Logic == null)
			{
				return;
			}
			if (ControllerBase<UiNavigationNewController>.Instance.IsNavigationMousePositionDragging())
			{
				base.Logic.CancelOperationByGamepad();
				ControllerBase<UiNavigationNewController>.Instance.NotifyNavigationMousePositionDragState(false);
				ControllerBase<UiNavigationNewController>.Instance.SimulationPointerTrigger(false);
			}
		}

		// Token: 0x0603341F RID: 209951 RVA: 0x00CD5073 File Offset: 0x00CD3273
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			if (!viewHandle.HasGamepadControlMouse())
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (!viewHandle.IsNavigationMousePositionDragging())
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}
	}
}
