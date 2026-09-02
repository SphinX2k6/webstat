using System;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C28 RID: 23592
	public class InstanceDungeonEntranceFlowMowingRisk : InstanceDungeonEntranceFlowBase
	{
		// Token: 0x0603BA28 RID: 244264 RVA: 0x00F1C1FC File Offset: 0x00F1A3FC
		protected override void OnCreate()
		{
			base.AddStep(delegate
			{
				MowingRiskInstanceDungeonViewModel param = new MowingRiskInstanceDungeonViewModel();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonEntranceView, param, null);
			});
			base.AddStep(delegate
			{
				ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId, false, true, false, null);
			});
			base.AddStep(delegate
			{
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
