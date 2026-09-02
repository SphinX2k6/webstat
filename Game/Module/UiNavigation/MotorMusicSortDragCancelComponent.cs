using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D28 RID: 19752
	public class MotorMusicSortDragCancelComponent : HotKeyComponent
	{
		// Token: 0x060334EC RID: 210156 RVA: 0x00CD7013 File Offset: 0x00CD5213
		public MotorMusicSortDragCancelComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334ED RID: 210157 RVA: 0x00CD701C File Offset: 0x00CD521C
		protected override void OnPress(HotKeyMap config)
		{
			if (ControllerBase<UiNavigationNewController>.Instance.IsNavigationMousePositionDragging())
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnMotorMusicSortDragCancel);
				ControllerBase<UiNavigationNewController>.Instance.NotifyNavigationMousePositionDragState(false);
				ControllerBase<UiNavigationNewController>.Instance.SimulationPointerTrigger(false);
			}
		}

		// Token: 0x060334EE RID: 210158 RVA: 0x00CD7050 File Offset: 0x00CD5250
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
