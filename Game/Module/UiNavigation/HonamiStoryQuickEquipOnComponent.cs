using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D0B RID: 19723
	public class HonamiStoryQuickEquipOnComponent : HonamiStoryComponentBase
	{
		// Token: 0x06033439 RID: 209977 RVA: 0x00CD5408 File Offset: 0x00CD3608
		public HonamiStoryQuickEquipOnComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603343A RID: 209978 RVA: 0x00CD5411 File Offset: 0x00CD3611
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
			base.Logic.QuickEquipOn();
		}

		// Token: 0x0603343B RID: 209979 RVA: 0x00CD544C File Offset: 0x00CD364C
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
			HonamiStoryItemDataBase data = curItem.GetData();
			if (data != null && data.GetItemType() == EHonamiStoryItemType.Normal)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			EHonamiStoryBackpackType backpackType = curItem.GetBackpackType();
			if (backpackType == EHonamiStoryBackpackType.Backpack || backpackType == EHonamiStoryBackpackType.Inventory)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
		}
	}
}
