using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D75 RID: 19829
	public class WorldMapShowOnlyComponent : HotKeyComponent
	{
		// Token: 0x060335E6 RID: 210406 RVA: 0x00CD8E53 File Offset: 0x00CD7053
		public WorldMapShowOnlyComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335E7 RID: 210407 RVA: 0x00CD8E5C File Offset: 0x00CD705C
		[NullableContext(1)]
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			if (ControllerBase<ActivityMowingRiskController>.Instance.CheckInInstanceDungeon())
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (ControllerBase<InstanceDungeonEntranceController>.Instance.CheckInstanceShieldView(EUiViewName.WorldMapView))
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x060335E8 RID: 210408 RVA: 0x00CD8EA8 File Offset: 0x00CD70A8
		protected override bool OnIsOccupancyFightInput()
		{
			return false;
		}
	}
}
