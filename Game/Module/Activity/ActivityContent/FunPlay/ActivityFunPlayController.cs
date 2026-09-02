using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FunPlay
{
	// Token: 0x02006771 RID: 26481
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityFunPlayController : ActivityControllerBase<ActivityFunPlayController>
	{
		// Token: 0x0604202D RID: 270381 RVA: 0x010EFC73 File Offset: 0x010EDE73
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x0604202E RID: 270382 RVA: 0x010EFC76 File Offset: 0x010EDE76
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x0604202F RID: 270383 RVA: 0x010EFC78 File Offset: 0x010EDE78
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityInterestMain";
		}

		// Token: 0x06042030 RID: 270384 RVA: 0x010EFC7F File Offset: 0x010EDE7F
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivitySubViewFunPlay();
		}

		// Token: 0x06042031 RID: 270385 RVA: 0x010EFC86 File Offset: 0x010EDE86
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.Data = new ActivityFunPlayData();
			return this.Data;
		}

		// Token: 0x06042032 RID: 270386 RVA: 0x010EFC99 File Offset: 0x010EDE99
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<FunPlayChallengeInfoUpdateNotify>(ENotifyMessageId.FunPlayChallengeInfoUpdateNotify, new Action<FunPlayChallengeInfoUpdateNotify, Net.CallbackStatus>(this.OnFunPlayChallengeInfoUpdateNotify));
		}

		// Token: 0x06042033 RID: 270387 RVA: 0x010EFCB8 File Offset: 0x010EDEB8
		private void OnFunPlayChallengeInfoUpdateNotify(FunPlayChallengeInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus _)
		{
			foreach (FunPlayChallengeInfo data in message.FunPlayChallengeInfos)
			{
				ActivityFunPlayModel instance = ModelBase<ActivityFunPlayModel>.Instance;
				if (instance != null)
				{
					instance.UpdateChallengeData(data);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.ActivityFunPlayInfoRefresh);
		}

		// Token: 0x06042034 RID: 270388 RVA: 0x010EFD20 File Offset: 0x010EDF20
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.FunPlayChallengeInfoUpdateNotify);
		}

		// Token: 0x06042035 RID: 270389 RVA: 0x010EFD34 File Offset: 0x010EDF34
		public void ChallengeAwardRequest(int challengeId)
		{
			FunPlayChallengeAwardRequest funPlayChallengeAwardRequest = FunPlayChallengeAwardRequest.Create();
			funPlayChallengeAwardRequest.ChallengeId = challengeId;
			Singleton<Net>.Instance.Call<FunPlayChallengeAwardResponse>(ERequestMessageId.FunPlayChallengeAwardRequest, funPlayChallengeAwardRequest, delegate(FunPlayChallengeAwardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.ActivityFunPlay, ELogAuthor.CB, "领取奖励回包为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23926, null, true, true);
				}
			}, 0);
		}

		// Token: 0x06042036 RID: 270390 RVA: 0x010EFD80 File Offset: 0x010EDF80
		public UniTask RequestEnterChallengeAsync(int challengeId)
		{
			ActivityFunPlayController.<RequestEnterChallengeAsync>d__10 <RequestEnterChallengeAsync>d__;
			<RequestEnterChallengeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestEnterChallengeAsync>d__.<>4__this = this;
			<RequestEnterChallengeAsync>d__.challengeId = challengeId;
			<RequestEnterChallengeAsync>d__.<>1__state = -1;
			<RequestEnterChallengeAsync>d__.<>t__builder.Start<ActivityFunPlayController.<RequestEnterChallengeAsync>d__10>(ref <RequestEnterChallengeAsync>d__);
			return <RequestEnterChallengeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042037 RID: 270391 RVA: 0x010EFDCC File Offset: 0x010EDFCC
		private List<int> GetEnterChallengeRoleIds(int instId)
		{
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instId);
			if (config == null)
			{
				EditFormationData getCurrentFormationData = ModelBase<EditFormationModel>.Instance.GetCurrentFormationData;
				List<int> list;
				if (getCurrentFormationData == null)
				{
					list = null;
				}
				else
				{
					int[] getRoleIdList = getCurrentFormationData.GetRoleIdList;
					list = ((getRoleIdList != null) ? getRoleIdList.ToList<int>() : null);
				}
				return list ?? new List<int>();
			}
			int trialRoleFormation = config.Value.TrialRoleFormation;
			if (trialRoleFormation != 0)
			{
				InstanceTrialRoleConfig? trialRoleConfig = ConfigBase<InstanceDungeonConfig>.Instance.GetTrialRoleConfig(trialRoleFormation);
				if (trialRoleConfig != null)
				{
					bool flag = trialRoleConfig.Value.MaleFormationLength > 0 && trialRoleConfig.Value.FemaleFormationLength > 0;
					if (trialRoleConfig.Value.OnlyTrial && flag)
					{
						return new List<int>();
					}
				}
			}
			Aki.Config.FightFormation? fightFormationConfig = ConfigBase<EditBattleTeamConfig>.Instance.GetFightFormationConfig(config.Value.FightFormationId);
			int[] array = (fightFormationConfig != null) ? fightFormationConfig.GetValueOrDefault().GetAutoRoleArray() : null;
			if (array != null && array.Length != 0)
			{
				List<int> list2 = new List<int>();
				foreach (int id in array)
				{
					list2.Add(ConfigBase<RoleConfig>.Instance.GetTrialRoleIdConfigByGroupId(id));
				}
				return list2;
			}
			EditFormationData getCurrentFormationData2 = ModelBase<EditFormationModel>.Instance.GetCurrentFormationData;
			List<int> list3;
			if (getCurrentFormationData2 == null)
			{
				list3 = null;
			}
			else
			{
				int[] getRoleIdList2 = getCurrentFormationData2.GetRoleIdList;
				list3 = ((getRoleIdList2 != null) ? getRoleIdList2.ToList<int>() : null);
			}
			return list3 ?? new List<int>();
		}

		// Token: 0x06042038 RID: 270392 RVA: 0x010EFF30 File Offset: 0x010EE130
		[NullableContext(0)]
		public UniTask<bool> OpenActivityFunPlayView()
		{
			ActivityFunPlayController.<OpenActivityFunPlayView>d__12 <OpenActivityFunPlayView>d__;
			<OpenActivityFunPlayView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenActivityFunPlayView>d__.<>1__state = -1;
			<OpenActivityFunPlayView>d__.<>t__builder.Start<ActivityFunPlayController.<OpenActivityFunPlayView>d__12>(ref <OpenActivityFunPlayView>d__);
			return <OpenActivityFunPlayView>d__.<>t__builder.Task;
		}

		// Token: 0x04024D04 RID: 150788
		[Nullable(2)]
		public ActivityFunPlayData Data;
	}
}
