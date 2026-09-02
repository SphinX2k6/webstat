using System;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C25 RID: 23589
	public class InstanceDungeonEntranceFlowLordGymFirst : InstanceDungeonEntranceFlowBase
	{
		// Token: 0x0603BA1C RID: 244252 RVA: 0x00F1BFB0 File Offset: 0x00F1A1B0
		protected override void OnCreate()
		{
			base.AddStep(delegate
			{
				if (ControllerBase<LordGymController>.Instance.IsInLordGymDungeon())
				{
					ControllerBase<TowerController>.Instance.ClearAllHatredInTower();
					LordGymDifficultySelectViewParam param = new LordGymDifficultySelectViewParam
					{
						LordEntranceSetId = 200105,
						LordEntranceId = ModelBase<LordGymModel>.Instance.EntranceEntityId,
						IsPlaySpecialSequence = false
					};
					Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymFirstDifficultySelectView, param, null);
					return;
				}
				if (ModelBase<LordGymModel>.Instance.SkipBossSelectInFlow)
				{
					ModelBase<LordGymModel>.Instance.SkipBossSelectInFlow = false;
					LordGymDifficultySelectViewParam param2 = new LordGymDifficultySelectViewParam
					{
						LordEntranceSetId = 200105,
						LordEntranceId = ModelBase<LordGymModel>.Instance.EntranceEntityId,
						IsPlaySpecialSequence = false
					};
					Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymFirstDifficultySelectView, param2, null);
					return;
				}
				LordGymLordEntranceSelectViewParam param3 = new LordGymLordEntranceSelectViewParam
				{
					EntranceSetId = 200105,
					IsPlaySpecialSequence = new bool?(false),
					NeedBlackScreenAnim = false
				};
				Singleton<UiManager>.Instance.OpenView(EUiViewName.LordGymFirstBossSelectView, param3, null);
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
