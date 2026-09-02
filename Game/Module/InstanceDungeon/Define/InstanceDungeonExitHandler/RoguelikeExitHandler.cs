using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C42 RID: 23618
	public class RoguelikeExitHandler : InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA93 RID: 244371 RVA: 0x00F1D378 File Offset: 0x00F1B578
		public override bool Checker()
		{
			return ModelBase<RoguelikeModel>.Instance.CheckInRoguelike() || ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue();
		}

		// Token: 0x0603BA94 RID: 244372 RVA: 0x00F1D394 File Offset: 0x00F1B594
		[NullableContext(2)]
		public override void HandleExit(InstanceDungeonExitHandlerData data)
		{
			if (ModelBase<RoguelikeModel>.Instance.CheckInRoguelike())
			{
				RogueChallengeModeType? rogueModeType = ModelBase<RoguelikeModel>.Instance.RogueModeType;
				if (rogueModeType.GetValueOrDefault() == RogueChallengeModeType.NormalInst)
				{
					this.RoguelikeNormalExit();
					return;
				}
				if (rogueModeType.GetValueOrDefault() == RogueChallengeModeType.TowerTrial)
				{
					this.RoguelikeTowerTrialExit();
				}
				return;
			}
			else
			{
				if (ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue())
				{
					this.WeeklyRogueExit();
					return;
				}
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default);
				return;
			}
		}

		// Token: 0x0603BA95 RID: 244373 RVA: 0x00F1D3F9 File Offset: 0x00F1B5F9
		private void RoguelikeNormalExit()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeExitTips, null, null);
		}

		// Token: 0x0603BA96 RID: 244374 RVA: 0x00F1D40C File Offset: 0x00F1B60C
		private void RoguelikeTowerTrialExit()
		{
			int instId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoguelikeBossChallengeExitConfirm);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				ControllerBase<RoguelikeController>.Instance.RoguelikeBossChallengeResultRequest(instId, null);
			};
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<RoguelikeController>.Instance.RoguelikeQuitRequest();
			};
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603BA97 RID: 244375 RVA: 0x00F1D497 File Offset: 0x00F1B697
		private void WeeklyRogueExit()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRogueExitTips, null, null);
		}
	}
}
