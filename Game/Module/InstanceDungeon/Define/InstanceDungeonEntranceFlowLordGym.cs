using System;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C24 RID: 23588
	public class InstanceDungeonEntranceFlowLordGym : InstanceDungeonEntranceFlowBase
	{
		// Token: 0x0603BA18 RID: 244248 RVA: 0x00F1BEEC File Offset: 0x00F1A0EC
		protected override void OnCreate()
		{
			base.AddStep(delegate
			{
				if (ControllerBase<LordGymController>.Instance.IsInLordGymDungeon())
				{
					LordGymDifficultySelectViewParam param = new LordGymDifficultySelectViewParam
					{
						LordEntranceSetId = 200103,
						LordEntranceId = ModelBase<LordGymModel>.Instance.EntranceEntityId,
						IsPlaySpecialSequence = true
					};
					ControllerBase<TowerController>.Instance.ClearAllHatredInTower();
					Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymThirdDifficultySelectView, param, null);
					return;
				}
				if (ModelBase<LordGymModel>.Instance.SkipBossSelectInFlow)
				{
					ModelBase<LordGymModel>.Instance.SkipBossSelectInFlow = false;
					LordGymDifficultySelectViewParam param2 = new LordGymDifficultySelectViewParam
					{
						LordEntranceSetId = 200103,
						LordEntranceId = ModelBase<LordGymModel>.Instance.EntranceEntityId,
						IsPlaySpecialSequence = true
					};
					Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymThirdDifficultySelectView, param2, null);
					return;
				}
				LordGymLordEntranceSelectViewParam param3 = new LordGymLordEntranceSelectViewParam
				{
					EntranceSetId = 200103,
					IsPlaySpecialSequence = new bool?(true),
					NeedBlackScreenAnim = false
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymThirdBossSelectView, param3, null);
			});
			base.AddStep(delegate
			{
				ControllerBase<EditBattleTeamController>.Instance.PlayerOpenEditBattleTeamView(ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId, false, true, true, null);
			});
			base.AddStep(delegate
			{
				if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.EditBattleTeamView))
				{
					base.RevertStep();
					return;
				}
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
