using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005650 RID: 22096
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityPermanentRogueController : ActivityControllerBase<ActivityPermanentRogueController>
	{
		// Token: 0x06038522 RID: 230690 RVA: 0x00E42389 File Offset: 0x00E40589
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06038523 RID: 230691 RVA: 0x00E4238B File Offset: 0x00E4058B
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityRogue23Main";
		}

		// Token: 0x06038524 RID: 230692 RVA: 0x00E42394 File Offset: 0x00E40594
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			ActivityPermanentRogueController.<OnOpenSubView>d__6 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.<>4__this = this;
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<ActivityPermanentRogueController.<OnOpenSubView>d__6>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}

		// Token: 0x06038525 RID: 230693 RVA: 0x00E423D7 File Offset: 0x00E405D7
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivitySubViewPermanentRogue();
		}

		// Token: 0x06038526 RID: 230694 RVA: 0x00E423DE File Offset: 0x00E405DE
		[PreserveBaseOverrides]
		protected new virtual ActivityPermanentRogueData OnCreateActivityData(ActivityData data)
		{
			this.ActivityId = data.Id;
			this.ActivityData = new ActivityPermanentRogueData();
			return this.ActivityData;
		}

		// Token: 0x06038527 RID: 230695 RVA: 0x00E423FD File Offset: 0x00E405FD
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06038528 RID: 230696 RVA: 0x00E42400 File Offset: 0x00E40600
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<RogueResIllustrationUpdateNotify>(ENotifyMessageId.RogueResIllustrationUpdateNotify, new Action<RogueResIllustrationUpdateNotify, Net.CallbackStatus>(this.OnRogueResIllustrationUpdateNotify));
			Singleton<Net>.Instance.Register<RogueResTaskUpdateNotify>(ENotifyMessageId.RogueResTaskUpdateNotify, new Action<RogueResTaskUpdateNotify, Net.CallbackStatus>(this.OnRogueResTaskUpdateNotify));
			Singleton<Net>.Instance.Register<RogueResCurrencyNotify>(ENotifyMessageId.RogueResCurrencyNotify, new Action<RogueResCurrencyNotify, Net.CallbackStatus>(this.OnRogueResCurrencyNotify));
			Singleton<Net>.Instance.Register<RogueResEndingUpdateNotify>(ENotifyMessageId.RogueResEndingUpdateNotify, new Action<RogueResEndingUpdateNotify, Net.CallbackStatus>(this.OnRogueResEndingUpdateNotify));
			Singleton<Net>.Instance.Register<RogueResCurrencyUpdateNotify>(ENotifyMessageId.RogueResCurrencyUpdateNotify, new Action<RogueResCurrencyUpdateNotify, Net.CallbackStatus>(this.OnRogueResCurrencyUpdateNotify));
			Singleton<Net>.Instance.Register<RogueResTotalShopItemUpdateNotify>(ENotifyMessageId.RogueResTotalShopItemUpdateNotify, new Action<RogueResTotalShopItemUpdateNotify, Net.CallbackStatus>(this.OnRogueResTotalShopItemUpdateNotify));
			Singleton<Net>.Instance.Register<RogueResTalentUnlockNotify>(ENotifyMessageId.RogueResTalentUnlockNotify, new Action<RogueResTalentUnlockNotify, Net.CallbackStatus>(this.OnRogueResTalentUnlockNotify));
		}

		// Token: 0x06038529 RID: 230697 RVA: 0x00E424D4 File Offset: 0x00E406D4
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResIllustrationUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResTaskUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResCurrencyNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResEndingUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResCurrencyUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResTotalShopItemUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueResTalentUnlockNotify);
		}

		// Token: 0x0603852A RID: 230698 RVA: 0x00E42551 File Offset: 0x00E40751
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnCloseLoadingView, new Action(this.OnCloseLoading));
		}

		// Token: 0x0603852B RID: 230699 RVA: 0x00E4256F File Offset: 0x00E4076F
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCloseLoadingView, new Action(this.OnCloseLoading));
		}

		// Token: 0x0603852C RID: 230700 RVA: 0x00E42590 File Offset: 0x00E40790
		public new void OnShowActivityFirstUnlockView(ActivityBaseData data)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType(EPromptSubViewType.RogueResOpen, null, null, null, null, null, null);
		}

		// Token: 0x0603852D RID: 230701 RVA: 0x00E425B8 File Offset: 0x00E407B8
		private void OnCloseLoading()
		{
			if (!this.IsFromRogue)
			{
				return;
			}
			this.IsFromRogue = false;
			RogueResDungeonConfig? config = ConfigRogueResDungeonConfigById.GetConfig(this.DungeonId, true);
			if (config == null)
			{
				return;
			}
			int seasonId = config.Value.SeasonId;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueSeasonEntranceView, seasonId, null);
		}

		// Token: 0x0603852E RID: 230702 RVA: 0x00E42614 File Offset: 0x00E40814
		public void SetReturnToWorld(int dungeonId)
		{
			if (ConfigRogueResDungeonConfigById.GetConfig(dungeonId, true) == null)
			{
				return;
			}
			this.DungeonId = dungeonId;
			this.IsFromRogue = true;
		}

		// Token: 0x0603852F RID: 230703 RVA: 0x00E42644 File Offset: 0x00E40844
		[NullableContext(2)]
		public ActivityRogueData GetCurrentActivityData()
		{
			ActivityRogueData activityRogueData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as ActivityRogueData;
			if (activityRogueData == null)
			{
				return null;
			}
			return activityRogueData;
		}

		// Token: 0x06038530 RID: 230704 RVA: 0x00E4266D File Offset: 0x00E4086D
		private void OnRogueResIllustrationUpdateNotify(RogueResIllustrationUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<ActivityPermanentRogueModel>.Instance.GetActivityData().UpdateIllustrateState(message);
		}

		// Token: 0x06038531 RID: 230705 RVA: 0x00E42680 File Offset: 0x00E40880
		public void RequestIllustrationAward(int[] configId)
		{
			RogueResIllustrationAwardRequest rogueResIllustrationAwardRequest = RogueResIllustrationAwardRequest.Create();
			rogueResIllustrationAwardRequest.ConfigIds.AddRange(configId);
			Singleton<Net>.Instance.Call<RogueResIllustrationAwardResponse>(ERequestMessageId.RogueResIllustrationAwardRequest, rogueResIllustrationAwardRequest, delegate(RogueResIllustrationAwardResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26934, null, true, true);
					return;
				}
				if (response.IsFull)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_EchoLimit_Text", Array.Empty<object>());
				}
				this.ActivityData.SetIllustratedRewardGot(configId);
				Singleton<EventSystem>.Instance.Emit(EEventName.PermanentRogueRewardUpdate);
				HashSet<int> hashSet = new HashSet<int>();
				List<int> list = new List<int>();
				foreach (int num in configId)
				{
					RogueResCollection value = ConfigRogueResCollectionByIdKey.GetConfig(num, true).Value;
					if (value.Type == 0)
					{
						list = this.ActivityData.GetTokenInSeason(num);
					}
					else if (value.Type == 1)
					{
						list = this.ActivityData.GetEventNormalInSeason(num);
					}
					else
					{
						list = this.ActivityData.GetEventMapInSeason(num);
					}
					foreach (int item in list)
					{
						hashSet.Add(item);
					}
				}
				foreach (int p in list)
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.PermanentRogueSeasonRedDotUpdate, p);
				}
			}, 0);
		}

		// Token: 0x06038532 RID: 230706 RVA: 0x00E426D8 File Offset: 0x00E408D8
		public void RequestTaskAward(int configId)
		{
			RogueResTaskAwardRequest rogueResTaskAwardRequest = RogueResTaskAwardRequest.Create();
			rogueResTaskAwardRequest.ConfigId = configId;
			Singleton<Net>.Instance.Call<RogueResTaskAwardResponse>(ERequestMessageId.RogueResTaskAwardRequest, rogueResTaskAwardRequest, delegate(RogueResTaskAwardResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15499, null, true, true);
					return;
				}
				ModelBase<ActivityPermanentRogueModel>.Instance.GetActivityData().SetTaskRewardGot(configId);
				Singleton<EventSystem>.Instance.Emit(EEventName.PermanentRogueRewardUpdate);
			}, 0);
		}

		// Token: 0x06038533 RID: 230707 RVA: 0x00E42724 File Offset: 0x00E40924
		public void RequestEnterDungeon(int dungeonId)
		{
			RogueResInstStartRequest rogueResInstStartRequest = RogueResInstStartRequest.Create();
			rogueResInstStartRequest.InstId = dungeonId;
			Singleton<Net>.Instance.Call<RogueResInstStartResponse>(ERequestMessageId.RogueResInstStartRequest, rogueResInstStartRequest, delegate(RogueResInstStartResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23210, null, true, true);
				}
			}, 0);
		}

		// Token: 0x06038534 RID: 230708 RVA: 0x00E4276E File Offset: 0x00E4096E
		private void OnRogueResTaskUpdateNotify(RogueResTaskUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<ActivityPermanentRogueModel>.Instance.GetActivityData().UpdateTaskNotify(message);
		}

		// Token: 0x06038535 RID: 230709 RVA: 0x00E42780 File Offset: 0x00E40980
		private void OnRogueResCurrencyNotify(RogueResCurrencyNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<ActivityPermanentRogueModel>.Instance.InitCurrency(message.CurrencyDict);
		}

		// Token: 0x06038536 RID: 230710 RVA: 0x00E42792 File Offset: 0x00E40992
		private void OnRogueResCurrencyUpdateNotify(RogueResCurrencyUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<ActivityPermanentRogueModel>.Instance.UpdateCurrency(message.CurrencyUpdateDict, new int?(message.EventType));
		}

		// Token: 0x06038537 RID: 230711 RVA: 0x00E427AF File Offset: 0x00E409AF
		private void OnRogueResTotalShopItemUpdateNotify(RogueResTotalShopItemUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<ActivityPermanentRogueModel>.Instance.UpdateTotalShopItem(message.SeasonId, message.TotalShopItem);
		}

		// Token: 0x06038538 RID: 230712 RVA: 0x00E427C7 File Offset: 0x00E409C7
		private void OnRogueResTalentUnlockNotify(RogueResTalentUnlockNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<ActivityPermanentRogueModel>.Instance.UpdateSkillTreeUnlockState(message.SkillId);
		}

		// Token: 0x06038539 RID: 230713 RVA: 0x00E427DC File Offset: 0x00E409DC
		public UniTask RequestRogueResTalentSkillLevel(int skillId)
		{
			ActivityPermanentRogueController.<RequestRogueResTalentSkillLevel>d__27 <RequestRogueResTalentSkillLevel>d__;
			<RequestRogueResTalentSkillLevel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RequestRogueResTalentSkillLevel>d__.skillId = skillId;
			<RequestRogueResTalentSkillLevel>d__.<>1__state = -1;
			<RequestRogueResTalentSkillLevel>d__.<>t__builder.Start<ActivityPermanentRogueController.<RequestRogueResTalentSkillLevel>d__27>(ref <RequestRogueResTalentSkillLevel>d__);
			return <RequestRogueResTalentSkillLevel>d__.<>t__builder.Task;
		}

		// Token: 0x0603853A RID: 230714 RVA: 0x00E42820 File Offset: 0x00E40A20
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<RogueResLastInstInfoResponse> RequestRogueResLastInstInfo()
		{
			ActivityPermanentRogueController.<RequestRogueResLastInstInfo>d__28 <RequestRogueResLastInstInfo>d__;
			<RequestRogueResLastInstInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<RogueResLastInstInfoResponse>.Create();
			<RequestRogueResLastInstInfo>d__.<>1__state = -1;
			<RequestRogueResLastInstInfo>d__.<>t__builder.Start<ActivityPermanentRogueController.<RequestRogueResLastInstInfo>d__28>(ref <RequestRogueResLastInstInfo>d__);
			return <RequestRogueResLastInstInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0603853B RID: 230715 RVA: 0x00E4285B File Offset: 0x00E40A5B
		private void OnRogueResEndingUpdateNotify(RogueResEndingUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<ActivityPermanentRogueModel>.Instance.GetActivityData().UpdateEndingNotify(message);
		}

		// Token: 0x0603853C RID: 230716 RVA: 0x00E42870 File Offset: 0x00E40A70
		public void RequestRogueResEndingReward(int seasonId, int configId, int index)
		{
			RogueResEndingRewardRequest rogueResEndingRewardRequest = RogueResEndingRewardRequest.Create();
			rogueResEndingRewardRequest.SeasonId = seasonId;
			rogueResEndingRewardRequest.Index = index;
			Singleton<Net>.Instance.Call<RogueResEndingRewardResponse>(ERequestMessageId.RogueResEndingRewardRequest, rogueResEndingRewardRequest, delegate(RogueResEndingRewardResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16241, null, true, true);
					return;
				}
				ModelBase<ActivityPermanentRogueModel>.Instance.SetEndingAwardData(configId);
				IActivityRewardViewData endingAwardViewData = ModelBase<ActivityPermanentRogueModel>.Instance.GetEndingAwardViewData(seasonId);
				Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, endingAwardViewData);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.PermanentRogueSeasonRedDotUpdate, seasonId);
			}, 0);
		}

		// Token: 0x0603853D RID: 230717 RVA: 0x00E428C8 File Offset: 0x00E40AC8
		[NullableContext(0)]
		public UniTask<bool> OpenSeasonMainView()
		{
			ActivityPermanentRogueController.<OpenSeasonMainView>d__31 <OpenSeasonMainView>d__;
			<OpenSeasonMainView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenSeasonMainView>d__.<>1__state = -1;
			<OpenSeasonMainView>d__.<>t__builder.Start<ActivityPermanentRogueController.<OpenSeasonMainView>d__31>(ref <OpenSeasonMainView>d__);
			return <OpenSeasonMainView>d__.<>t__builder.Task;
		}

		// Token: 0x04020210 RID: 131600
		public int ActivityId;

		// Token: 0x04020211 RID: 131601
		private int DungeonId;

		// Token: 0x04020212 RID: 131602
		private bool IsFromRogue;

		// Token: 0x04020213 RID: 131603
		[Nullable(2)]
		private ActivityPermanentRogueData ActivityData;
	}
}
