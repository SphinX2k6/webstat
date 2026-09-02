using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.FlagChallenge;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F17 RID: 24343
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class FlagChallengeBattleController : ControllerBase<FlagChallengeBattleController>
	{
		// Token: 0x0603D219 RID: 250393 RVA: 0x00F8872C File Offset: 0x00F8692C
		protected override bool OnInit()
		{
			Singleton<Net>.Instance.Register<FlagChallengeTempRoleLevelNotify>(ENotifyMessageId.FlagChallengeTempRoleLevelNotify, new Action<FlagChallengeTempRoleLevelNotify, Net.CallbackStatus>(this.OnTempRoleLevelNotify));
			Singleton<Net>.Instance.Register<FlagChallengeInstNotify>(ENotifyMessageId.FlagChallengeInstNotify, new Action<FlagChallengeInstNotify, Net.CallbackStatus>(this.OnInstNotify));
			Singleton<Net>.Instance.Register<FlagChallengeSettleNotify>(ENotifyMessageId.FlagChallengeSettleNotify, new Action<FlagChallengeSettleNotify, Net.CallbackStatus>(this.OnSettleNotify));
			Singleton<Net>.Instance.Register<FlagChallengeBoxExpNotify>(ENotifyMessageId.FlagChallengeBoxExpNotify, new Action<FlagChallengeBoxExpNotify, Net.CallbackStatus>(this.OnBoxExpNotify));
			Singleton<EventSystem>.Instance.Add(EEventName.OnFlagChallengeStrongholdOccupied, new Action<int>(this.OnStrongholdOccupied));
			Singleton<EventSystem>.Instance.Add(EEventName.OnFlagChallengeFixedRoleLevelUpdate, new Action<int, int, int>(this.OnFixedRoleLevelUpdate));
			return true;
		}

		// Token: 0x0603D21A RID: 250394 RVA: 0x00F887E4 File Offset: 0x00F869E4
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FlagChallengeTempRoleLevelNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FlagChallengeInstNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FlagChallengeSettleNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FlagChallengeBoxExpNotify);
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeStrongholdOccupied, new Action<int>(this.OnStrongholdOccupied));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeFixedRoleLevelUpdate, new Action<int, int, int>(this.OnFixedRoleLevelUpdate));
			return true;
		}

		// Token: 0x0603D21B RID: 250395 RVA: 0x00F8886A File Offset: 0x00F86A6A
		protected override bool OnLeaveLevel()
		{
			ModelBase<FlagChallengeBattleModel>.Instance.OnLeaveInstance();
			return true;
		}

		// Token: 0x0603D21C RID: 250396 RVA: 0x00F88878 File Offset: 0x00F86A78
		public UniTask LeaveFlagChallengeInstance()
		{
			FlagChallengeBattleController.<LeaveFlagChallengeInstance>d__3 <LeaveFlagChallengeInstance>d__;
			<LeaveFlagChallengeInstance>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LeaveFlagChallengeInstance>d__.<>1__state = -1;
			<LeaveFlagChallengeInstance>d__.<>t__builder.Start<FlagChallengeBattleController.<LeaveFlagChallengeInstance>d__3>(ref <LeaveFlagChallengeInstance>d__);
			return <LeaveFlagChallengeInstance>d__.<>t__builder.Task;
		}

		// Token: 0x0603D21D RID: 250397 RVA: 0x00F888B4 File Offset: 0x00F86AB4
		[NullableContext(2)]
		private void OnTempRoleLevelNotify(FlagChallengeTempRoleLevelNotify notify, Net.CallbackStatus callbackStatus)
		{
			int challengeLevelId = notify.ChallengeLevelId;
			Aki.Protocol.FlagChallengeRoleLevelInfo flagChallengeRoleLevelInfo = notify.FlagChallengeRoleLevelInfo;
			FlagChallengeBattleModel instance = ModelBase<FlagChallengeBattleModel>.Instance;
			if (challengeLevelId != instance.LevelId || flagChallengeRoleLevelInfo == null)
			{
				return;
			}
			instance.UpdateRoleTempLevelData(flagChallengeRoleLevelInfo.PerLevel, flagChallengeRoleLevelInfo.PerExp);
			int preTempLevel = instance.GetPreTempLevel();
			int tempLevel = instance.GetTempLevel();
			if (tempLevel != preTempLevel)
			{
				int calculatedLevel = instance.GetCalculatedLevel();
				ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(instance.ActivityId).CheckBuffStatusChange(calculatedLevel + preTempLevel, calculatedLevel + tempLevel);
			}
		}

		// Token: 0x0603D21E RID: 250398 RVA: 0x00F8892C File Offset: 0x00F86B2C
		[NullableContext(2)]
		private void OnInstNotify(FlagChallengeInstNotify notify, Net.CallbackStatus callbackStatus)
		{
			int challengeLevelId = notify.ChallengeLevelId;
			int activityId = ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(challengeLevelId).Value.ActivityId;
			ModelBase<FlagChallengeBattleModel>.Instance.HandleInstNotify(notify);
		}

		// Token: 0x0603D21F RID: 250399 RVA: 0x00F88968 File Offset: 0x00F86B68
		private void OnSettleNotify(FlagChallengeSettleNotify notify, [Nullable(2)] Net.CallbackStatus callbackStatus)
		{
			int challengeLevelId = notify.ChallengeLevelId;
			ModelBase<FlagChallengeBattleModel>.Instance.HandleSettleNotify(challengeLevelId);
			this.OpenSettleView();
		}

		// Token: 0x0603D220 RID: 250400 RVA: 0x00F88990 File Offset: 0x00F86B90
		private void OnBoxExpNotify(FlagChallengeBoxExpNotify notify, [Nullable(2)] Net.CallbackStatus callbackStatus)
		{
			int challengeLevelId = notify.ChallengeLevelId;
			FlagChallengeBattleModel instance = ModelBase<FlagChallengeBattleModel>.Instance;
			if (challengeLevelId != instance.LevelId)
			{
				return;
			}
			int boxExp = notify.BoxExp;
			instance.UpdateBoxExp(boxExp);
			int preTotalLevel = instance.GetPreTotalLevel();
			int totalLevel = instance.GetTotalLevel();
			if (totalLevel != preTotalLevel)
			{
				ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(instance.ActivityId).CheckBuffStatusChange(preTotalLevel, totalLevel);
			}
		}

		// Token: 0x0603D221 RID: 250401 RVA: 0x00F889E9 File Offset: 0x00F86BE9
		private void OnStrongholdOccupied(int strongholdId)
		{
			if (!ModelBase<FlagChallengeBattleModel>.Instance.IsInFlagChallengeDungeon)
			{
				return;
			}
			this.OpenOccupiedSuccessView(strongholdId);
		}

		// Token: 0x0603D222 RID: 250402 RVA: 0x00F88A00 File Offset: 0x00F86C00
		private void OnFixedRoleLevelUpdate(int activityId, int level, int exp)
		{
			FlagChallengeBattleModel instance = ModelBase<FlagChallengeBattleModel>.Instance;
			if (activityId != instance.ActivityId)
			{
				return;
			}
			instance.UpdateRoleLevelData(level, exp);
			int preTotalLevel = instance.GetPreTotalLevel();
			int totalLevel = instance.GetTotalLevel();
			if (totalLevel != preTotalLevel)
			{
				ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(activityId).CheckBuffStatusChange(preTotalLevel, totalLevel);
			}
		}

		// Token: 0x0603D223 RID: 250403 RVA: 0x00F88A49 File Offset: 0x00F86C49
		public void OpenOccupiedSuccessView(int strongholdId)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FlagChallengeOccupiedSuccessView, new FlagChallengeOccupiedSuccessViewParams
			{
				ActivityId = ModelBase<FlagChallengeBattleModel>.Instance.ActivityId,
				StrongholdId = strongholdId
			}, null);
		}

		// Token: 0x0603D224 RID: 250404 RVA: 0x00F88A77 File Offset: 0x00F86C77
		public void OpenSettleView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FlagChallengeSettleView, null, null);
		}

		// Token: 0x0603D225 RID: 250405 RVA: 0x00F88A8A File Offset: 0x00F86C8A
		public void OpenPauseView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FlagChallengePauseView, null, null);
		}
	}
}
