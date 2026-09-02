using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D0A RID: 19722
	public class HonamiStoryQuickEquipOffComponent : HonamiStoryComponentBase
	{
		// Token: 0x06033436 RID: 209974 RVA: 0x00CD534C File Offset: 0x00CD354C
		public HonamiStoryQuickEquipOffComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033437 RID: 209975 RVA: 0x00CD5355 File Offset: 0x00CD3555
		protected override void OnPress(HotKeyMap config)
		{
			if (base.Logic == null)
			{
				return;
			}
			if (ControllerBase<UiNavigationNewController>.Instance.IsNavigationMousePositionDragging())
			{
				ControllerBase<UiNavigationNewController>.Instance.NotifyNavigationMousePositionDragState(false);
				ControllerBase<UiNavigationNewController>.Instance.SimulationPointerTrigger(false);
			}
			base.Logic.QuickEquipOff();
		}

		// Token: 0x06033438 RID: 209976 RVA: 0x00CD5390 File Offset: 0x00CD3590
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			if (base.Logic == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
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
			HonamiStoryItemGridItem curItem = base.Logic.GetCurItem();
			if (curItem == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (curItem.GetBackpackType() != EHonamiStoryBackpackType.Player)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}
	}
}
