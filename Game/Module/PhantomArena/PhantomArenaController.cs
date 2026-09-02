using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;
using CSharpScript.Game.Module.PhantomArena.Prepare.Entrance;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005469 RID: 21609
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class PhantomArenaController : ActivityControllerBase<PhantomArenaController>
	{
		// Token: 0x06037149 RID: 225609 RVA: 0x00DFC029 File Offset: 0x00DFA229
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x0603714A RID: 225610 RVA: 0x00DFC02C File Offset: 0x00DFA22C
		protected override void OnOpenView(ActivityBaseData data)
		{
			if (!data.GetPreGuideQuestFinishState())
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, data.GetUnFinishPreGuideQuestId(), null);
				return;
			}
			PhantomArenaBattleController.OpenPhantomArenaMapEntrance(null, null);
		}

		// Token: 0x0603714B RID: 225611 RVA: 0x00DFC074 File Offset: 0x00DFA274
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId)
		{
			PhantomArenaController.<OnOpenSubView>d__5 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.viewName = viewName;
			<OnOpenSubView>d__.activityId = activityId;
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<PhantomArenaController.<OnOpenSubView>d__5>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}

		// Token: 0x0603714C RID: 225612 RVA: 0x00DFC0BF File Offset: 0x00DFA2BF
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_SoundRemnantArenaMain";
		}

		// Token: 0x0603714D RID: 225613 RVA: 0x00DFC0C6 File Offset: 0x00DFA2C6
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new PhantomArenaSubView();
		}

		// Token: 0x0603714E RID: 225614 RVA: 0x00DFC0CD File Offset: 0x00DFA2CD
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new PhantomArenaActivityData();
		}

		// Token: 0x0603714F RID: 225615 RVA: 0x00DFC0D4 File Offset: 0x00DFA2D4
		protected override void OnRegisterNetEvent()
		{
			if (ControllerBase<PhantomArenaController>.Instance.NetRegistered)
			{
				return;
			}
			Singleton<Net>.Instance.Register<PhantomBattleChallengeInfoUpdateNotify>(ENotifyMessageId.PhantomBattleChallengeInfoUpdateNotify, new Action<PhantomBattleChallengeInfoUpdateNotify, Net.CallbackStatus>(this.OnChallengeInfoUpdateNotify));
			Singleton<Net>.Instance.Register<PhantomBattleChallengeUpdateNotify>(ENotifyMessageId.PhantomBattleChallengeUpdateNotify, new Action<PhantomBattleChallengeUpdateNotify, Net.CallbackStatus>(this.OnChallengeUpdateNotify));
			Singleton<Net>.Instance.Register<PhantomBattleMasterInfoNotify>(ENotifyMessageId.PhantomBattleMasterInfoNotify, new Action<PhantomBattleMasterInfoNotify, Net.CallbackStatus>(this.OnMasterInfoNotify));
			Singleton<Net>.Instance.Register<PhantomBattleBadgeInfoUpdateNotify>(ENotifyMessageId.PhantomBattleBadgeInfoUpdateNotify, new Action<PhantomBattleBadgeInfoUpdateNotify, Net.CallbackStatus>(this.OnBadgeInfoUpdateNotify));
			Singleton<Net>.Instance.Register<PhantomBattleBadgeRewardInfoUpdateNotify>(ENotifyMessageId.PhantomBattleBadgeRewardInfoUpdateNotify, new Action<PhantomBattleBadgeRewardInfoUpdateNotify, Net.CallbackStatus>(this.OnBadgeRewardInfoUpdateNotify));
			Singleton<Net>.Instance.Register<PhantomBattleCardRewardInfoUpdateNotify>(ENotifyMessageId.PhantomBattleCardRewardInfoUpdateNotify, new Action<PhantomBattleCardRewardInfoUpdateNotify, Net.CallbackStatus>(this.OnCardRewardInfoUpdateNotify));
			Singleton<Net>.Instance.Register<PhantomBattleRoleInfoUpdateNotify>(ENotifyMessageId.PhantomBattleRoleInfoUpdateNotify, new Action<PhantomBattleRoleInfoUpdateNotify, Net.CallbackStatus>(this.OnRoleInfoUpdateNotify));
			Singleton<Net>.Instance.Register<PhantomBattleCardInfoUpdateNotify>(ENotifyMessageId.PhantomBattleCardInfoUpdateNotify, new Action<PhantomBattleCardInfoUpdateNotify, Net.CallbackStatus>(this.OnCardInfoUpdateNotify));
			Singleton<Net>.Instance.Register<PhantomBattleTaskInfoNotify>(ENotifyMessageId.PhantomBattleTaskInfoNotify, new Action<PhantomBattleTaskInfoNotify, Net.CallbackStatus>(this.OnTaskInfoUpdateNotify));
			ControllerBase<PhantomArenaController>.Instance.NetRegistered = true;
		}

		// Token: 0x06037150 RID: 225616 RVA: 0x00DFC1F8 File Offset: 0x00DFA3F8
		protected override void OnUnRegisterNetEvent()
		{
			if (!ControllerBase<PhantomArenaController>.Instance.NetRegistered)
			{
				return;
			}
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomBattleChallengeInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomBattleChallengeUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomBattleMasterInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomBattleBadgeInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomBattleBadgeRewardInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomBattleCardRewardInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomBattleRoleInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomBattleCardInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomBattleTaskInfoNotify);
			ControllerBase<PhantomArenaController>.Instance.NetRegistered = false;
		}

		// Token: 0x06037151 RID: 225617 RVA: 0x00DFC2AD File Offset: 0x00DFA4AD
		protected override void OnAddEvents()
		{
			if (ControllerBase<PhantomArenaController>.Instance.EventsRegistered)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			ControllerBase<PhantomArenaController>.Instance.EventsRegistered = true;
		}

		// Token: 0x06037152 RID: 225618 RVA: 0x00DFC2E3 File Offset: 0x00DFA4E3
		protected override void OnRemoveEvents()
		{
			if (!ControllerBase<PhantomArenaController>.Instance.EventsRegistered)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			ControllerBase<PhantomArenaController>.Instance.EventsRegistered = false;
		}

		// Token: 0x06037153 RID: 225619 RVA: 0x00DFC319 File Offset: 0x00DFA519
		private void OnWorldDone()
		{
			ControllerBase<PhantomArenaController>.Instance.PostUnlockView();
		}

		// Token: 0x06037154 RID: 225620 RVA: 0x00DFC328 File Offset: 0x00DFA528
		public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.PhantomArenaOpen, null, null, null, null, null, null, null, null, false, null);
		}

		// Token: 0x06037155 RID: 225621 RVA: 0x00DFC35B File Offset: 0x00DFA55B
		private void OnChallengeInfoUpdateNotify(PhantomBattleChallengeInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify == null)
			{
				return;
			}
			ModelBase<PhantomArenaModel>.Instance.UpdateChallengeInfoByNotify(notify);
		}

		// Token: 0x06037156 RID: 225622 RVA: 0x00DFC36C File Offset: 0x00DFA56C
		private void OnChallengeUpdateNotify(PhantomBattleChallengeUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify == null)
			{
				return;
			}
			int challengeId = notify.ChallengeId;
			bool unlock = notify.Unlock;
			bool isPassRewarded = notify.IsPassRewarded;
			bool isUncover = notify.IsUncover;
			ModelBase<PhantomArenaModel>.Instance.UpdateChallengeInfoBySettleResult(challengeId, unlock, isPassRewarded, isUncover);
			foreach (PhantomBattleChallengeInfo phantomBattleChallengeInfo in notify.ChallengeInfo)
			{
				PhantomArenaActivityData permanentPhantomArenaActivityData = ModelBase<PhantomArenaModel>.Instance.GetPermanentPhantomArenaActivityData();
				if (permanentPhantomArenaActivityData != null)
				{
					permanentPhantomArenaActivityData.UpdateChallengeFinishConditions(phantomBattleChallengeInfo.PhantomBattleChallengeId, phantomBattleChallengeInfo.FinishConditions.ToList<int>());
				}
			}
		}

		// Token: 0x06037157 RID: 225623 RVA: 0x00DFC410 File Offset: 0x00DFA610
		private void OnMasterInfoNotify(PhantomBattleMasterInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify == null)
			{
				return;
			}
			ModelBase<PhantomArenaModel>.Instance.UpdateMasterInfoByNotify(notify);
		}

		// Token: 0x06037158 RID: 225624 RVA: 0x00DFC424 File Offset: 0x00DFA624
		private void OnBadgeInfoUpdateNotify(PhantomBattleBadgeInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify == null)
			{
				return;
			}
			ModelBase<PhantomArenaModel>.Instance.AddBadgeListByNotify(notify);
			foreach (PhantomBattleBadgeInfo phantomBattleBadgeInfo in notify.PhantomBattleBadgeInfos)
			{
				ModelBase<PhantomArenaModel>.Instance.BadgeUnlockQueue.Add(phantomBattleBadgeInfo.PhantomBattleBadgeId);
			}
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				ControllerBase<PhantomArenaController>.Instance.PostUnlockView();
			}
		}

		// Token: 0x06037159 RID: 225625 RVA: 0x00DFC4A8 File Offset: 0x00DFA6A8
		private void OnBadgeRewardInfoUpdateNotify(PhantomBattleBadgeRewardInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify == null)
			{
				return;
			}
			ModelBase<PhantomArenaModel>.Instance.UpdateBadgeRewardByNotify(notify);
		}

		// Token: 0x0603715A RID: 225626 RVA: 0x00DFC4B9 File Offset: 0x00DFA6B9
		private void OnCardRewardInfoUpdateNotify(PhantomBattleCardRewardInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify == null)
			{
				return;
			}
			ModelBase<PhantomArenaModel>.Instance.UpdateCardRewardByNotify(notify);
		}

		// Token: 0x0603715B RID: 225627 RVA: 0x00DFC4CC File Offset: 0x00DFA6CC
		private void OnRoleInfoUpdateNotify(PhantomBattleRoleInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify == null)
			{
				return;
			}
			ModelBase<PhantomArenaModel>.Instance.AddRoleByNotify(notify);
			if (!ControllerBase<GameModeController>.Instance.IsInInstance() || ControllerBase<PhantomArenaController>.Instance.CheckInPhantomArenaDungeon())
			{
				foreach (PhantomBattleRoleInfo phantomBattleRoleInfo in notify.PhantomBattleRoleInfos)
				{
					if (!ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardRole(phantomBattleRoleInfo.PhantomBattleRoleId).IsTrail)
					{
						ModelBase<PhantomArenaModel>.Instance.RoleUnlockQueue.Add(phantomBattleRoleInfo.PhantomBattleRoleId);
					}
				}
			}
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				ControllerBase<PhantomArenaController>.Instance.PostUnlockView();
			}
		}

		// Token: 0x0603715C RID: 225628 RVA: 0x00DFC580 File Offset: 0x00DFA780
		public bool CheckInPhantomArenaDungeon()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
				InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
				return config != null && config.GetValueOrDefault().InstSubType == 36;
			}
			return false;
		}

		// Token: 0x0603715D RID: 225629 RVA: 0x00DFC5D0 File Offset: 0x00DFA7D0
		private void OnCardInfoUpdateNotify(PhantomBattleCardInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify == null)
			{
				return;
			}
			if (!ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				foreach (PhantomBattleCardInfo phantomBattleCardInfo in notify.PhantomBattleCardInfos)
				{
					int phantomBattleCardId = phantomBattleCardInfo.PhantomBattleCardId;
					int num = ModelBase<PhantomArenaModel>.Instance.IsCardUnlock(phantomBattleCardId) ? 1 : 0;
					bool isUnlock = phantomBattleCardInfo.IsUnlock;
					if (num == 0 && isUnlock)
					{
						ModelBase<PhantomArenaModel>.Instance.CardUnlockQueue.Add(phantomBattleCardId);
					}
					int num2 = ModelBase<PhantomArenaModel>.Instance.IsCardOutlookUnlock(phantomBattleCardId) ? 1 : 0;
					bool isUnlockOutLook = phantomBattleCardInfo.IsUnlockOutLook;
					if (num2 == 0 && isUnlockOutLook)
					{
						ModelBase<PhantomArenaModel>.Instance.CardOutlookUnlockQueue.Add(phantomBattleCardId);
					}
				}
			}
			ModelBase<PhantomArenaModel>.Instance.AddCardListByNotify(notify);
			ControllerBase<PhantomArenaController>.Instance.PostUnlockView();
		}

		// Token: 0x0603715E RID: 225630 RVA: 0x00DFC69C File Offset: 0x00DFA89C
		private void OnTaskInfoUpdateNotify(PhantomBattleTaskInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (notify == null)
			{
				return;
			}
			ModelBase<PhantomArenaModel>.Instance.UpdateTaskInfo(notify);
		}

		// Token: 0x0603715F RID: 225631 RVA: 0x00DFC6B0 File Offset: 0x00DFA8B0
		public void TaskRewardRequest(int taskId)
		{
			PhantomBattleTaskRewardRequest phantomBattleTaskRewardRequest = PhantomBattleTaskRewardRequest.Create();
			phantomBattleTaskRewardRequest.TaskId = taskId;
			Singleton<Net>.Instance.Call<PhantomBattleTaskRewardResponse>(ERequestMessageId.PhantomBattleTaskRewardRequest, phantomBattleTaskRewardRequest, delegate(PhantomBattleTaskRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26934, null, true, true);
					return;
				}
				ModelBase<PhantomArenaModel>.Instance.UpdateTaskByIds(new List<int>
				{
					taskId
				});
			}, 0);
		}

		// Token: 0x06037160 RID: 225632 RVA: 0x00DFC6FC File Offset: 0x00DFA8FC
		public void TaskAllRewardRequest(int taskId)
		{
			PhantomBattleTask? taskConfigById = ConfigBase<PhantomArenaConfig>.Instance.GetTaskConfigById(taskId);
			if (taskConfigById == null)
			{
				return;
			}
			List<int> taskIds = ModelBase<PhantomArenaModel>.Instance.GetAllCanReceiveTaskIdsByTabId(taskConfigById.Value.ActivityId, taskConfigById.Value.TaskType);
			PhantomBattleRepeatedTaskRewardRequest phantomBattleRepeatedTaskRewardRequest = PhantomBattleRepeatedTaskRewardRequest.Create();
			phantomBattleRepeatedTaskRewardRequest.TaskId.Add(taskIds);
			Singleton<Net>.Instance.Call<PhantomBattleRepeatedTaskRewardResponse>(ERequestMessageId.PhantomBattleRepeatedTaskRewardRequest, phantomBattleRepeatedTaskRewardRequest, delegate(PhantomBattleRepeatedTaskRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26151, null, true, true);
					return;
				}
				ModelBase<PhantomArenaModel>.Instance.UpdateTaskByIds(taskIds);
			}, 0);
		}

		// Token: 0x06037161 RID: 225633 RVA: 0x00DFC788 File Offset: 0x00DFA988
		public void MasterLevelMultiRewardRequest(int[] levelConfigIds, int activityId)
		{
			MulPhantomBattleMasterLevelRewardRequest mulPhantomBattleMasterLevelRewardRequest = MulPhantomBattleMasterLevelRewardRequest.Create();
			mulPhantomBattleMasterLevelRewardRequest.PhantomBattleMasterLevelId.Add(levelConfigIds);
			mulPhantomBattleMasterLevelRewardRequest.ActivityId = activityId;
			Singleton<Net>.Instance.Call<MulPhantomBattleMasterLevelRewardResponse>(ERequestMessageId.MulPhantomBattleMasterLevelRewardRequest, mulPhantomBattleMasterLevelRewardRequest, delegate(MulPhantomBattleMasterLevelRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25575, null, true, true);
					return;
				}
				ModelBase<PhantomArenaModel>.Instance.UpdateMasterLevelByConfigIds(levelConfigIds.ToList<int>(), activityId);
			}, 0);
		}

		// Token: 0x06037162 RID: 225634 RVA: 0x00DFC7EC File Offset: 0x00DFA9EC
		public void BadgeRewardRequest(int[] rewardIds, int activityId)
		{
			PhantomBattleBadgeRewardRequest phantomBattleBadgeRewardRequest = PhantomBattleBadgeRewardRequest.Create();
			phantomBattleBadgeRewardRequest.ActivityId = activityId;
			phantomBattleBadgeRewardRequest.BadgeRewardId.Add(rewardIds);
			Singleton<Net>.Instance.Call<PhantomBattleBadgeRewardResponse>(ERequestMessageId.PhantomBattleBadgeRewardRequest, phantomBattleBadgeRewardRequest, delegate(PhantomBattleBadgeRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26934, null, true, true);
					return;
				}
				ModelBase<PhantomArenaModel>.Instance.UpdateBadgeRewardByIds(rewardIds.ToList<int>());
			}, 0);
		}

		// Token: 0x06037163 RID: 225635 RVA: 0x00DFC844 File Offset: 0x00DFAA44
		[NullableContext(2)]
		public void CardOutLookUpRequest(int cardId, Action<int> successCallBack = null)
		{
			PhantomBattleCardOutLookUpRequest phantomBattleCardOutLookUpRequest = PhantomBattleCardOutLookUpRequest.Create();
			phantomBattleCardOutLookUpRequest.CardId = cardId;
			Singleton<Net>.Instance.Call<PhantomBattleCardOutLookUpResponse>(ERequestMessageId.PhantomBattleCardOutLookUpRequest, phantomBattleCardOutLookUpRequest, delegate(PhantomBattleCardOutLookUpResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20313, null, true, true);
					return;
				}
				ModelBase<PhantomArenaModel>.Instance.OnCardOutlookUnlock(cardId);
				ModelBase<PhantomArenaModel>.Instance.CardOutlookUnlockQueue.Add(cardId);
				ControllerBase<PhantomArenaController>.Instance.PostUnlockView();
				Action<int> successCallBack2 = successCallBack;
				if (successCallBack2 == null)
				{
					return;
				}
				successCallBack2(cardId);
			}, 0);
		}

		// Token: 0x06037164 RID: 225636 RVA: 0x00DFC894 File Offset: 0x00DFAA94
		public void CardRewardRequest(int[] rewardIds, int activityId)
		{
			PhantomBattleCardRewardRequest phantomBattleCardRewardRequest = PhantomBattleCardRewardRequest.Create();
			phantomBattleCardRewardRequest.ActivityId = activityId;
			phantomBattleCardRewardRequest.CardRewardId.Add(rewardIds);
			Singleton<Net>.Instance.Call<PhantomBattleCardRewardResponse>(ERequestMessageId.PhantomBattleCardRewardRequest, phantomBattleCardRewardRequest, delegate(PhantomBattleCardRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26934, null, true, true);
					return;
				}
				ModelBase<PhantomArenaModel>.Instance.UpdateCardRewardByIds(rewardIds.ToList<int>());
			}, 0);
		}

		// Token: 0x06037165 RID: 225637 RVA: 0x00DFC8EC File Offset: 0x00DFAAEC
		[NullableContext(2)]
		public void RoleRewardRequest(int cardRoleId, Action<int> successCallBack = null)
		{
			PhantomBattleRoleRewardRequest phantomBattleRoleRewardRequest = PhantomBattleRoleRewardRequest.Create();
			phantomBattleRoleRewardRequest.PhantomBattleRoleId = cardRoleId;
			Singleton<Net>.Instance.Call<PhantomBattleRoleRewardResponse>(ERequestMessageId.PhantomBattleRoleRewardRequest, phantomBattleRoleRewardRequest, delegate(PhantomBattleRoleRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20313, null, true, true);
					return;
				}
				ModelBase<PhantomArenaModel>.Instance.OnRoleReward(cardRoleId);
				Action<int> successCallBack2 = successCallBack;
				if (successCallBack2 == null)
				{
					return;
				}
				successCallBack2(cardRoleId);
			}, 0);
		}

		// Token: 0x06037166 RID: 225638 RVA: 0x00DFC93C File Offset: 0x00DFAB3C
		public void CardGroupAddRequest(string name, int[] cardIdList, int activityId, [Nullable(2)] Action<int> successCallBack = null)
		{
			PhantomBattleCardGroupAddRequest phantomBattleCardGroupAddRequest = PhantomBattleCardGroupAddRequest.Create();
			phantomBattleCardGroupAddRequest.Name = name;
			phantomBattleCardGroupAddRequest.EquipCardIds.Add(cardIdList);
			phantomBattleCardGroupAddRequest.ActivityId = activityId;
			Singleton<Net>.Instance.Call<PhantomBattleCardGroupAddResponse>(ERequestMessageId.PhantomBattleCardGroupAddRequest, phantomBattleCardGroupAddRequest, delegate(PhantomBattleCardGroupAddResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27488, null, true, true);
					return;
				}
				if (response.PhantomBattleCardGroupInfo == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.LZK, "创建卡组时服务器返回数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				Aki.Protocol.PhantomBattleCardGroupInfo phantomBattleCardGroupInfo = response.PhantomBattleCardGroupInfo;
				ModelBase<PhantomArenaModel>.Instance.AddProtocolDeckInfo(phantomBattleCardGroupInfo, activityId);
				Action<int> successCallBack2 = successCallBack;
				if (successCallBack2 == null)
				{
					return;
				}
				successCallBack2(phantomBattleCardGroupInfo.Index);
			}, 0);
		}

		// Token: 0x06037167 RID: 225639 RVA: 0x00DFC9A0 File Offset: 0x00DFABA0
		[NullableContext(2)]
		public void CardGroupDeleteRequest(int deckServerId, int activityId, Action<int> successCallBack = null)
		{
			PhantomBattleCardGroupDeleteRequest phantomBattleCardGroupDeleteRequest = PhantomBattleCardGroupDeleteRequest.Create();
			phantomBattleCardGroupDeleteRequest.Index = deckServerId;
			phantomBattleCardGroupDeleteRequest.ActivityId = activityId;
			Singleton<Net>.Instance.Call<PhantomBattleCardGroupDeleteResponse>(ERequestMessageId.PhantomBattleCardGroupDeleteRequest, phantomBattleCardGroupDeleteRequest, delegate(PhantomBattleCardGroupDeleteResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24534, null, true, true);
					return;
				}
				ModelBase<PhantomArenaModel>.Instance.UpdateDeckList(response.PhantomBattleCardGroupInfo, activityId);
				ModelBase<PhantomArenaModel>.Instance.SetLastUsedCardDeckServerId(response.LastUseCardGroupIndex, activityId);
				Action<int> successCallBack2 = successCallBack;
				if (successCallBack2 == null)
				{
					return;
				}
				successCallBack2(deckServerId);
			}, 0);
		}

		// Token: 0x06037168 RID: 225640 RVA: 0x00DFCA04 File Offset: 0x00DFAC04
		public void CardGroupUpdateRequest(int deckServerId, int[] cardIds, int activityId, [Nullable(2)] Action<int> successCallBack = null)
		{
			PhantomBattleCardGroupUpdateRequest phantomBattleCardGroupUpdateRequest = PhantomBattleCardGroupUpdateRequest.Create();
			phantomBattleCardGroupUpdateRequest.Index = deckServerId;
			phantomBattleCardGroupUpdateRequest.EquipCardIds.Add(cardIds);
			phantomBattleCardGroupUpdateRequest.ActivityId = activityId;
			Singleton<Net>.Instance.Call<PhantomBattleCardGroupUpdateResponse>(ERequestMessageId.PhantomBattleCardGroupUpdateRequest, phantomBattleCardGroupUpdateRequest, delegate(PhantomBattleCardGroupUpdateResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24620, null, true, true);
					return;
				}
				Aki.Protocol.PhantomBattleCardGroupInfo phantomBattleCardGroupInfo = response.PhantomBattleCardGroupInfo;
				if (phantomBattleCardGroupInfo == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.LZK, "更新卡组时服务器返回数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				ModelBase<PhantomArenaModel>.Instance.UpdateProtocolDeckInfo(phantomBattleCardGroupInfo, activityId);
				Action<int> successCallBack2 = successCallBack;
				if (successCallBack2 == null)
				{
					return;
				}
				successCallBack2(deckServerId);
			}, 0);
		}

		// Token: 0x06037169 RID: 225641 RVA: 0x00DFCA74 File Offset: 0x00DFAC74
		[NullableContext(0)]
		public UniTask<Aki.Protocol.ErrorCode> CardGroupNameRequest([Nullable(1)] string newName, int deckServerId, int activityId)
		{
			PhantomArenaController.<CardGroupNameRequest>d__35 <CardGroupNameRequest>d__;
			<CardGroupNameRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
			<CardGroupNameRequest>d__.newName = newName;
			<CardGroupNameRequest>d__.deckServerId = deckServerId;
			<CardGroupNameRequest>d__.activityId = activityId;
			<CardGroupNameRequest>d__.<>1__state = -1;
			<CardGroupNameRequest>d__.<>t__builder.Start<PhantomArenaController.<CardGroupNameRequest>d__35>(ref <CardGroupNameRequest>d__);
			return <CardGroupNameRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603716A RID: 225642 RVA: 0x00DFCAC8 File Offset: 0x00DFACC8
		[NullableContext(2)]
		public void CardUnlockRequest(int cardId, Action<int> successCallBack = null)
		{
			PhantomBattleCardUnlockRequest phantomBattleCardUnlockRequest = PhantomBattleCardUnlockRequest.Create();
			phantomBattleCardUnlockRequest.CardId = cardId;
			Singleton<Net>.Instance.Call<PhantomBattleCardUnlockResponse>(ERequestMessageId.PhantomBattleCardUnlockRequest, phantomBattleCardUnlockRequest, delegate(PhantomBattleCardUnlockResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28106, null, true, true);
					return;
				}
				Action<int> successCallBack2 = successCallBack;
				if (successCallBack2 == null)
				{
					return;
				}
				successCallBack2(cardId);
			}, 0);
		}

		// Token: 0x0603716B RID: 225643 RVA: 0x00DFCB18 File Offset: 0x00DFAD18
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<PhantomBattleReChallengeResponse> ReChallengeRequestAsync(int challengeId)
		{
			PhantomArenaController.<ReChallengeRequestAsync>d__37 <ReChallengeRequestAsync>d__;
			<ReChallengeRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<PhantomBattleReChallengeResponse>.Create();
			<ReChallengeRequestAsync>d__.challengeId = challengeId;
			<ReChallengeRequestAsync>d__.<>1__state = -1;
			<ReChallengeRequestAsync>d__.<>t__builder.Start<PhantomArenaController.<ReChallengeRequestAsync>d__37>(ref <ReChallengeRequestAsync>d__);
			return <ReChallengeRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603716C RID: 225644 RVA: 0x00DFCB5C File Offset: 0x00DFAD5C
		public bool PostUnlockView()
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomArenaRoleUnlockView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomArenaBadgeUnlockView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomArenaCardsRewardView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomArenaCardOutlookRewardView))
			{
				return false;
			}
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return false;
			}
			if (ModelBase<PhantomArenaModel>.Instance.RoleUnlockQueue.Count > 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaRoleUnlockView, null, null);
				return true;
			}
			List<int> cardUnlockQueue = ModelBase<PhantomArenaModel>.Instance.CardUnlockQueue;
			if (cardUnlockQueue.Count > 0)
			{
				Action callbackClose = delegate()
				{
					ControllerBase<PhantomArenaController>.Instance.PostUnlockView();
				};
				ControllerBase<PhantomArenaBattleController>.Instance.PhantomBattleResultShowCards(cardUnlockQueue, callbackClose);
				return true;
			}
			if (ModelBase<PhantomArenaModel>.Instance.CardOutlookUnlockQueue.Count > 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaCardOutlookRewardView, null, null);
				return true;
			}
			if (ModelBase<PhantomArenaModel>.Instance.BadgeUnlockQueue.Count > 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaBadgeUnlockView, null, null);
				return true;
			}
			if (ModelBase<PhantomArenaModel>.Instance.EntranceOpenQueue && ControllerBase<PhantomArenaController>.Instance.OpenEntranceViewActivityId != 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomArenaEntranceView, ControllerBase<PhantomArenaController>.Instance.OpenEntranceViewActivityId, null);
				ModelBase<PhantomArenaModel>.Instance.EntranceOpenQueue = false;
				ControllerBase<PhantomArenaController>.Instance.OpenEntranceViewActivityId = 0;
				return true;
			}
			return true;
		}

		// Token: 0x0603716D RID: 225645 RVA: 0x00DFCCBE File Offset: 0x00DFAEBE
		public void OpenPhantomArenaConfirmBoxView(ConfirmBoxDataNew data, bool isNew = false)
		{
			data.CustomPopType = new EUiBehaviourPopType?(EUiBehaviourPopType.PhantomArenaSmall);
			if (isNew)
			{
				data.CustomResourceId = "UiItem_SoundRemnantArenaTipsInfo_New";
			}
			else
			{
				data.CustomResourceId = "UiItem_SoundRemnantArenaTipsInfo";
			}
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(data);
		}

		// Token: 0x0603716E RID: 225646 RVA: 0x00DFCCF4 File Offset: 0x00DFAEF4
		public void UpdateCardDetailLockState(UpdateCardDetailLockStateContext context)
		{
			if (context.IsUnLocked)
			{
				context.UnlockBtnItem.SetActive(false);
				context.TipText.SetUIActive(false);
				context.LockTipItem.SetUIActive(false);
				return;
			}
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(context.CardId);
			if (!phantomBattleCardConfig.EnableBuy)
			{
				context.LockTipItem.SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(context.LockTipText, phantomBattleCardConfig.ConditionDesc, Array.Empty<object>());
				context.TipText.SetUIActive(false);
				context.UnlockBtnItem.SetActive(false);
				return;
			}
			EFunctionType functionId = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(phantomBattleCardConfig.ActivityId) ? EFunctionType.PermanentPhantomArenaCardUnlock : EFunctionType.PhantomArenaCardUnlock;
			if (!ModelBase<FunctionModel>.Instance.IsOpen(functionId))
			{
				context.TipText.SetUIActive(false);
				context.LockTipItem.SetUIActive(false);
				context.UnlockBtnItem.SetActive(true);
				context.UnlockBtnItem.SetEnableClick(false);
				context.UnlockBtnItem.SetLocalTextNew("GenericPrompt_Unlocked_TipsText", Array.Empty<object>());
				return;
			}
			int itemId = phantomBattleCardConfig.UnlockConsumeItems()[0].ItemId;
			int count = phantomBattleCardConfig.UnlockConsumeItems()[0].Count;
			bool flag = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemId, 0) >= count;
			context.TipText.SetUIActive(true);
			context.LockTipItem.SetUIActive(false);
			context.UnlockBtnItem.SetActive(true);
			context.UnlockBtnItem.SetEnableClick(flag);
			context.UnlockBtnItem.SetRedDotVisible(context.ShowUnlockRedDotWhenCanUnlock && flag);
			context.UnlockBtnItem.SetLocalTextNew("PhantomBattle_1010", Array.Empty<object>());
			string iconSmall = ConfigBase<ItemConfig>.Instance.GetConfig(itemId).Value.IconSmall;
			string textStringId = flag ? "PhantomBattle_1012" : "PhantomBattle_1011";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(context.TipText, textStringId, new <>z__ReadOnlyArray<object>(new object[]
			{
				iconSmall,
				count
			}));
		}

		// Token: 0x0603716F RID: 225647 RVA: 0x00DFCEEC File Offset: 0x00DFB0EC
		public void ReportDeckUpdate(PhantomArenaReportDeckUpdateContext context)
		{
			PhantomArenaDeckUpdateEvent phantomArenaDeckUpdateEvent = new PhantomArenaDeckUpdateEvent();
			DeckInfo deckInfo = context.DeckInfo;
			phantomArenaDeckUpdateEvent.i_activity_id = context.ActivityId;
			phantomArenaDeckUpdateEvent.i_deck_order = deckInfo.GetDeckServerId() + 1;
			phantomArenaDeckUpdateEvent.s_deck_name = deckInfo.GetDeckName();
			phantomArenaDeckUpdateEvent.i_operation = (int)context.Operation;
			List<DeckCardSlotInfo> cardSlotList = deckInfo.GetCardSlotList();
			Dictionary<int, PhantomArenaReportCardInfo> dictionary = new Dictionary<int, PhantomArenaReportCardInfo>();
			foreach (DeckCardSlotInfo deckCardSlotInfo in cardSlotList)
			{
				int cardId = deckCardSlotInfo.CardId;
				int cost = deckCardSlotInfo.Cost;
				PhantomArenaReportCardInfo phantomArenaReportCardInfo;
				if (!dictionary.TryGetValue(cost, out phantomArenaReportCardInfo))
				{
					phantomArenaReportCardInfo = new PhantomArenaReportCardInfo(cost);
					dictionary[cost] = phantomArenaReportCardInfo;
				}
				for (int i = 0; i < deckCardSlotInfo.Count; i++)
				{
					phantomArenaReportCardInfo.CardIdList.Add(cardId);
				}
			}
			phantomArenaDeckUpdateEvent.o_deck_info = dictionary.Values.ToArray<PhantomArenaReportCardInfo>();
			phantomArenaDeckUpdateEvent.i_build_id = context.LastQuicklyBuildId;
			List<string> list = new List<string>();
			foreach (KeyValuePair<int, int> keyValuePair in context.QuicklyBuildDeckUseTimes)
			{
				if (keyValuePair.Value > 0)
				{
					List<string> list2 = list;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(keyValuePair.Key);
					defaultInterpolatedStringHandler.AppendLiteral(":");
					defaultInterpolatedStringHandler.AppendFormatted<int>(keyValuePair.Value);
					list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
				}
			}
			phantomArenaDeckUpdateEvent.o_build_click = string.Join("", list);
			phantomArenaDeckUpdateEvent.i_deck_status = ((deckInfo.GetCanUse() > false) ? 1 : 0);
			int fieldCardConditionCurNum = deckInfo.GetFieldCardConditionCurNum();
			int fieldCardConditionTargetNum = deckInfo.GetFieldCardConditionTargetNum();
			phantomArenaDeckUpdateEvent.i_special_effect = ((fieldCardConditionTargetNum != 0 && fieldCardConditionCurNum >= fieldCardConditionTargetNum) ? 1 : 0);
			ControllerBase<LogReportController>.Instance.LogReport(phantomArenaDeckUpdateEvent);
		}

		// Token: 0x06037170 RID: 225648 RVA: 0x00DFD0CC File Offset: 0x00DFB2CC
		public void OpenDeckBuilderCardInfoViewWithoutOutlookTab(int cardId)
		{
			DeckBuilderCardInfoViewData param = new DeckBuilderCardInfoViewData
			{
				CurCardId = cardId,
				NeedOutlookTab = false
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DeckBuilderCardInfoView, param, null);
		}

		// Token: 0x06037171 RID: 225649 RVA: 0x00DFD100 File Offset: 0x00DFB300
		public void RequestCheckCardSkillUnlock(DeckInfo deckInfo, Action<PhantomBattleCheckCardSkillUnlockResponse> callback)
		{
			if (deckInfo.GetFieldCardSlot() == null)
			{
				return;
			}
			PhantomBattleCheckCardSkillUnlockRequest phantomBattleCheckCardSkillUnlockRequest = PhantomBattleCheckCardSkillUnlockRequest.Create();
			List<int> cardIdList = deckInfo.GetCardIdList();
			phantomBattleCheckCardSkillUnlockRequest.CardConfig.Add(cardIdList);
			Singleton<Net>.Instance.Call<PhantomBattleCheckCardSkillUnlockResponse>(ERequestMessageId.PhantomBattleCheckCardSkillUnlockRequest, phantomBattleCheckCardSkillUnlockRequest, delegate(PhantomBattleCheckCardSkillUnlockResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15798, null, true, true);
					return;
				}
				deckInfo.SetFieldCardConditionProgress(response.CurNum, response.TargetNum);
				callback(response);
			}, 0);
		}

		// Token: 0x06037172 RID: 225650 RVA: 0x00DFD16C File Offset: 0x00DFB36C
		public void CreateTempActivityData()
		{
			ActivityData activityData = ActivityData.Create();
			activityData.Id = 105200001;
			activityData.Type = ActivityType.PhantomBattle;
			activityData.PhantomBattleActivityInfo = PhantomBattleActivityInfo.Create();
			ModelBase<ActivityModel>.Instance.OnActivityUpdate(new ActivityData[]
			{
				activityData
			});
		}

		// Token: 0x0401FAA6 RID: 129702
		private bool EventsRegistered;

		// Token: 0x0401FAA7 RID: 129703
		private bool NetRegistered;

		// Token: 0x0401FAA8 RID: 129704
		private int OpenEntranceViewActivityId;
	}
}
