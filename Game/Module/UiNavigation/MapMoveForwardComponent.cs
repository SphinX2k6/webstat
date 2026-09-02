using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D1C RID: 19740
	[NullableContext(1)]
	[Nullable(0)]
	public class MapMoveForwardComponent : HotKeyComponent
	{
		// Token: 0x060334C8 RID: 210120 RVA: 0x00CD6B25 File Offset: 0x00CD4D25
		public MapMoveForwardComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060334C9 RID: 210121 RVA: 0x00CD6B30 File Offset: 0x00CD4D30
		protected override void OnInit()
		{
			string axisName = base.GetAxisName();
			ModelBase<WorldMapModel>.Instance.WorldMapAxisInteractValidation.InitAxisLock(axisName);
		}

		// Token: 0x060334CA RID: 210122 RVA: 0x00CD6B54 File Offset: 0x00CD4D54
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

		// Token: 0x060334CB RID: 210123 RVA: 0x00CD6BB8 File Offset: 0x00CD4DB8
		protected override void OnInputAxis(string axisName, float value)
		{
			WorldMapAxisInteractValidation worldMapAxisInteractValidation = ModelBase<WorldMapModel>.Instance.WorldMapAxisInteractValidation;
			worldMapAxisInteractValidation.InputAxis(axisName, value);
			if (!worldMapAxisInteractValidation.IsInValid)
			{
				Singleton<EventSystem>.Instance.Emit<float>(EEventName.NavigationTriggerMapForward, value);
			}
		}
	}
}
