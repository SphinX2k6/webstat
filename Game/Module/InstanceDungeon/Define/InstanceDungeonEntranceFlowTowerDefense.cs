using System;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C2C RID: 23596
	public class InstanceDungeonEntranceFlowTowerDefense : InstanceDungeonEntranceFlowBase
	{
		// Token: 0x0603BA36 RID: 244278 RVA: 0x00F1C454 File Offset: 0x00F1A654
		protected override void OnCreate()
		{
			base.AddStep(delegate
			{
				ControllerBase<TowerDefenseController>.Instance.SetIsUiFlowOpen(true);
				Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerDefenseLevelView, null, null);
			});
			base.AddStep(delegate
			{
				ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId, false, true, false, null);
				ControllerBase<TowerDefenseController>.Instance.SetPhantomViewOpened(false);
			});
			base.AddStep(delegate
			{
				ControllerBase<TowerDefenseController>.Instance.EnterTowerDefense().ContinueWith(delegate(bool result)
				{
					ControllerBase<EditBattleTeamController>.Instance.CloseEditBattleTeamView();
					if (result)
					{
						base.Reset();
						ControllerBase<TowerDefenseController>.Instance.SetIsUiFlowOpen(false);
						return;
					}
					base.RevertStep();
				});
			});
		}
	}
}
