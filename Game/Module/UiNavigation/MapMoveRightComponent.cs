using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D1D RID: 19741
	[NullableContext(1)]
	[Nullable(0)]
	public class MapMoveRightComponent : HotKeyComponent
	{
		// Token: 0x060334CC RID: 210124 RVA: 0x00CD6BE4 File Offset: 0x00CD4DE4
		public MapMoveRightComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334CD RID: 210125 RVA: 0x00CD6BF0 File Offset: 0x00CD4DF0
		protected override void OnInit()
		{
			string axisName = base.GetAxisName();
			ModelBase<WorldMapModel>.Instance.WorldMapAxisInteractValidation.InitAxisLock(axisName);
		}

		// Token: 0x060334CE RID: 210126 RVA: 0x00CD6C14 File Offset: 0x00CD4E14
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			TsUiNavigationBehaviorListener focusListener = viewHandle.GetFocusListener();
			if (focusListener == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
				return;
			}
			NavigationGroup navigationGroup = focusListener.GetNavigationGroup();
			if (StringUtils.IsEmpty(navigationGroup.GroupName))
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (navigationGroup.GroupName != "GroupCursor")
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x060334CF RID: 210127 RVA: 0x00CD6C78 File Offset: 0x00CD4E78
		protected override void OnInputAxis(string axisName, float value)
		{
			WorldMapAxisInteractValidation worldMapAxisInteractValidation = ModelBase<WorldMapModel>.Instance.WorldMapAxisInteractValidation;
			worldMapAxisInteractValidation.InputAxis(axisName, value);
			if (!worldMapAxisInteractValidation.IsInValid)
			{
				Singleton<EventSystem>.Instance.Emit<float>(EEventName.NavigationTriggerMapRight, value);
			}
		}
	}
}
