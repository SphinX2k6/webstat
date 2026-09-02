using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Activity.ActivityContent.FarmGold;
using CSharpScript.Module.InstanceDungeon;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C23 RID: 23587
	public class InstanceDungeonEntranceFlowFarmGold : InstanceDungeonEntranceFlowBase
	{
		// Token: 0x0603BA16 RID: 244246 RVA: 0x00F1BE68 File Offset: 0x00F1A068
		protected override void OnCreate()
		{
			base.AddStep(delegate
			{
				ControllerBase<FarmGoldController>.Instance.OpenDefaultFarmGoldView();
			});
			base.AddStep(delegate
			{
				ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId, false, true, false, null);
			});
			base.AddStep(delegate
			{
				List<int> item = ModelBase<EditBattleTeamModel>.Instance.GetOwnRoleConfigIdList.Item1;
				int currentSelectEntranceId = FarmGoldData.CurrentSelectEntranceId;
				ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId, item, currentSelectEntranceId, 0, ModelBase<InstanceDungeonEntranceModel>.Instance.TransitionOption, ModelBase<TowerDefenseModel>.Instance.GetProtocolPhantomIdList(item));
			});
		}
	}
}
