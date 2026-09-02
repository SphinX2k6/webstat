using System;
using System.Collections.Generic;
using Aki.Protocol;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C2D RID: 23597
	public class InstanceDungeonEntranceFlowTrapDefense : InstanceDungeonEntranceFlowBase
	{
		// Token: 0x0603BA3A RID: 244282 RVA: 0x00F1C50C File Offset: 0x00F1A70C
		protected override void OnCreate()
		{
			base.AddStep(delegate
			{
				BaseInstanceDungeonViewModel param = new BaseInstanceDungeonViewModel();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonEntranceView, param, null);
			});
			base.AddStep(delegate
			{
				ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId, false, true, false, null);
			});
			base.AddStep(delegate
			{
				int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
				TrapDefenseLevelData valueOrDefault = ModelBase<TrapDefenseModel>.Instance.LevelDataFromInstIdMap.GetValueOrDefault(instanceId);
				int configId = (valueOrDefault != null) ? valueOrDefault.Config.Id : 1;
				ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.TrapDefenseCtx = new TrapDefenseCtx
				{
					ConfigId = configId,
					NewChallenge = false
				};
				ControllerBase<InstanceDungeonEntranceController>.Instance.EnterInstanceDungeon().ContinueWith(delegate(bool result)
				{
					ControllerBase<EditBattleTeamController>.Instance.CloseEditBattleTeamView();
					if (result)
					{
						base.Reset();
						return;
					}
					base.RevertStep();
				});
			});
		}
	}
}
