using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiNavigation;

// Token: 0x02000FA5 RID: 4005
public class ProjectionPhotoItemDragCancelComponent : HotKeyComponent
{
	// Token: 0x06006682 RID: 26242 RVA: 0x0019CDC2 File Offset: 0x0019AFC2
	public ProjectionPhotoItemDragCancelComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
	{
	}

	// Token: 0x06006683 RID: 26243 RVA: 0x0019CDCB File Offset: 0x0019AFCB
	protected override void OnPress(HotKeyMap config)
	{
		if (ControllerBase<UiNavigationNewController>.Instance.IsNavigationMousePositionDragging())
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnProjectionPhotoItemDragCancel);
			ControllerBase<UiNavigationNewController>.Instance.NotifyNavigationMousePositionDragState(false);
			ControllerBase<UiNavigationNewController>.Instance.SimulationPointerTrigger(false);
		}
	}

	// Token: 0x06006684 RID: 26244 RVA: 0x0019CDFF File Offset: 0x0019AFFF
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
