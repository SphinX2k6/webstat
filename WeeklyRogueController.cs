using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.Weather;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002D56 RID: 11606
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WeeklyRogueController : ActivityControllerBase<WeeklyRogueController>
{
	// Token: 0x060176C4 RID: 95940 RVA: 0x0067E9E2 File Offset: 0x0067CBE2
	protected override void OnOpenView(ActivityBaseData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRogueActivityView, EWeeklyRogueOpenWay.UI, null);
	}

	// Token: 0x060176C5 RID: 95941 RVA: 0x0067E9FA File Offset: 0x0067CBFA
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityRogue21";
	}

	// Token: 0x060176C6 RID: 95942 RVA: 0x0067EA01 File Offset: 0x0067CC01
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new WeeklyRogueSubView();
	}

	// Token: 0x060176C7 RID: 95943 RVA: 0x0067EA08 File Offset: 0x0067CC08
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new WeeklyRogueData();
	}

	// Token: 0x060176C8 RID: 95944 RVA: 0x0067EA0F File Offset: 0x0067CC0F
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		throw new SystemException("Method not implemented.");
	}

	// Token: 0x060176C9 RID: 95945 RVA: 0x0067EA1B File Offset: 0x0067CC1B
	private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason _)
	{
		WeeklyRogueData activityDataNew = ModelBase<WeeklyRogueModel>.Instance.ActivityDataNew;
		if (activityDataNew == null)
		{
			return;
		}
		activityDataNew.OnQuestStateChange(questId, state);
	}

	// Token: 0x060176CA RID: 95946 RVA: 0x0067EA34 File Offset: 0x0067CC34
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		Singleton<EventSystem>.Instance.Add<ENewLinkStatus>(EEventName.OnNewLinkStatusChanged, new Action<ENewLinkStatus>(this.OnNewLinkStatusChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
	}

	// Token: 0x060176CB RID: 95947 RVA: 0x0067EA98 File Offset: 0x0067CC98
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		Singleton<EventSystem>.Instance.Remove<ENewLinkStatus>(EEventName.OnNewLinkStatusChanged, new Action<ENewLinkStatus>(this.OnNewLinkStatusChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
	}

	// Token: 0x060176CC RID: 95948 RVA: 0x0067EAFC File Offset: 0x0067CCFC
	public void MarkAutoOpenDailyActivityWeekly()
	{
		bool isOpenedViewByWorld = ModelBase<WeeklyRogueModel>.Instance.IsOpenedViewByWorld;
		ModelBase<WeeklyRogueModel>.Instance.IsOpenedViewByWorld = false;
		this.IsNeedShowDailyActivityWeekly = !isOpenedViewByWorld;
	}

	// Token: 0x060176CD RID: 95949 RVA: 0x0067EB2C File Offset: 0x0067CD2C
	private void OnWorldDone()
	{
		if (!this.IsNeedShowDailyActivityWeekly)
		{
			return;
		}
		this.IsNeedShowDailyActivityWeekly = false;
		SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.None, ESplashScreenType.Other, delegate()
		{
			ControllerBase<AdventureGuideController>.Instance.OpenGuideView(new EUiTabViewName?(EUiTabViewName.DailyActivityTabView), new int?(2), delegate(bool success, int _)
			{
				ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.None);
			});
		});
		ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, false);
	}

	// Token: 0x060176CE RID: 95950 RVA: 0x0067EB7C File Offset: 0x0067CD7C
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<RogueWeeklyRoomInfoNotify>(ENotifyMessageId.RogueWeeklyRoomInfoNotify, new Action<RogueWeeklyRoomInfoNotify, Net.CallbackStatus>(this.OnRogueWeeklyRoomInfoNotify));
		Singleton<Net>.Instance.Register<RogueWeeklyResultNotify>(ENotifyMessageId.RogueWeeklyResultNotify, new Action<RogueWeeklyResultNotify, Net.CallbackStatus>(this.OnRogueWeeklyResultNotify));
		Singleton<Net>.Instance.Register<RogueWeeklySubLevelNotify>(ENotifyMessageId.RogueWeeklySubLevelNotify, new Action<RogueWeeklySubLevelNotify, Net.CallbackStatus>(this.OnRogueWeeklySubLevelNotify));
		Singleton<Net>.Instance.Register<RogueWeeklyInstInfoNotify>(ENotifyMessageId.RogueWeeklyInstInfoNotify, new Action<RogueWeeklyInstInfoNotify, Net.CallbackStatus>(this.OnRogueWeeklyInstInfoNotify));
		Singleton<Net>.Instance.Register<RogueWeeklyBlackFlowerNotify>(ENotifyMessageId.RogueWeeklyBlackFlowerNotify, new Action<RogueWeeklyBlackFlowerNotify, Net.CallbackStatus>(this.OnRogueWeeklyBlackFlowerNotify));
		Singleton<Net>.Instance.Register<RogueWeeklyCurrencyNotify>(ENotifyMessageId.RogueWeeklyCurrencyNotify, new Action<RogueWeeklyCurrencyNotify, Net.CallbackStatus>(this.OnRogueWeeklyCurrencyNotify));
		Singleton<Net>.Instance.Register<RogueWeeklyCurrencyUpdateNotify>(ENotifyMessageId.RogueWeeklyCurrencyUpdateNotify, new Action<RogueWeeklyCurrencyUpdateNotify, Net.CallbackStatus>(this.OnRogueWeeklyCurrencyUpdateNotify));
		Singleton<Net>.Instance.Register<RogueWeeklyInteractionResultNotify>(ENotifyMessageId.RogueWeeklyInteractionResultNotify, new Action<RogueWeeklyInteractionResultNotify, Net.CallbackStatus>(this.OnRogueWeeklyInteractionResultNotify));
	}

	// Token: 0x060176CF RID: 95951 RVA: 0x0067EC6C File Offset: 0x0067CE6C
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueWeeklyRoomInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueWeeklyResultNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueWeeklySubLevelNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueWeeklyInstInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueWeeklyBlackFlowerNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueWeeklyCurrencyNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueWeeklyCurrencyUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueWeeklyInteractionResultNotify);
	}

	// Token: 0x060176D0 RID: 95952 RVA: 0x0067ECFC File Offset: 0x0067CEFC
	private void OnRogueWeeklyRoomInfoNotify(RogueWeeklyRoomInfoNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<WeeklyRogueModel>.Instance.CurrentLayer = data.CurLayer;
		ModelBase<WeeklyRogueModel>.Instance.MaxLayer = data.MaxLayer;
		RogueWeeklyRoomPool? roomPoolConfig = ConfigBase<WeeklyRogueConfig>.Instance.GetRoomPoolConfig(data.RoguelikeRoomId);
		Aki.Config.RogueWeeklyRoomType value = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyRoomType(data.RoguelikeRoomTypeId).Value;
		ModelBase<WeeklyRogueModel>.Instance.CurrentRoomTypeId = value.RoomType;
		ModelBase<WeeklyRogueModel>.Instance.CurrentRoomId = data.RoguelikeRoomId;
		ModelBase<WeeklyRogueModel>.Instance.CurrentScore = data.Score;
		if (!StringUtils.IsEmpty((roomPoolConfig != null) ? roomPoolConfig.GetValueOrDefault().RoomsMusicState : null))
		{
			ModelBase<WeeklyRogueModel>.Instance.CurrentRoomMusicState = roomPoolConfig.Value.RoomsMusicState;
		}
		else
		{
			ModelBase<WeeklyRogueModel>.Instance.CurrentRoomMusicState = value.RoomsMusicState;
		}
		if (data.SkyBoxId != 0)
		{
			ModelBase<WeatherModel>.Instance.GetWorldWeatherActor().ChangeWeather(data.SkyBoxId, 0f);
			return;
		}
		ControllerBase<WeatherController>.Instance.StopWeather();
	}

	// Token: 0x060176D1 RID: 95953 RVA: 0x0067EE00 File Offset: 0x0067D000
	private void OnRogueWeeklyInteractionResultNotify(RogueWeeklyInteractionResultNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		WeeklyRogueResultCheckData param = new WeeklyRogueResultCheckData
		{
			CurrentInGameScore = notify.CurScore,
			MaxInGameScore = notify.MaxScore
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRogueResultCheckView, param, null);
	}

	// Token: 0x060176D2 RID: 95954 RVA: 0x0067EE3C File Offset: 0x0067D03C
	private void OnRogueWeeklyCurrencyNotify(RogueWeeklyCurrencyNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<WeeklyRogueModel>.Instance.CurrencyDictMap.Clear();
		foreach (KeyValuePair<int, int> keyValuePair in data.CurrencyDict)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			ModelBase<WeeklyRogueModel>.Instance.SetCurrency(key, value);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPlayerCurrencyChange, key);
		}
	}

	// Token: 0x060176D3 RID: 95955 RVA: 0x0067EEC0 File Offset: 0x0067D0C0
	private void OnRogueWeeklyCurrencyUpdateNotify(RogueWeeklyCurrencyUpdateNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		foreach (KeyValuePair<int, int> keyValuePair in data.CurrencyDict)
		{
			int key = keyValuePair.Key;
			int currency = ModelBase<WeeklyRogueModel>.Instance.GetCurrency(key);
			int value = keyValuePair.Value;
			int count = currency + value;
			if (value > 0)
			{
				ControllerBase<ItemHintController>.Instance.AddRoguelikeItemList(key, value);
			}
			ModelBase<WeeklyRogueModel>.Instance.SetCurrency(key, count);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPlayerCurrencyChange, key);
		}
	}

	// Token: 0x060176D4 RID: 95956 RVA: 0x0067EF54 File Offset: 0x0067D154
	private void OnRogueWeeklyResultNotify(RogueWeeklyResultNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRogueSettleView, data, null);
	}

	// Token: 0x060176D5 RID: 95957 RVA: 0x0067EF68 File Offset: 0x0067D168
	private void OnRogueWeeklySubLevelNotify(RogueWeeklySubLevelNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		WeeklyRogueController.<>c__DisplayClass18_0 CS$<>8__locals1 = new WeeklyRogueController.<>c__DisplayClass18_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.notify = notify;
		Action cancelFunc = delegate()
		{
			CS$<>8__locals1.<>4__this.GotoNextRoomRequest(false).Forget();
		};
		Action action = delegate()
		{
			string name = "WeeklyRoguelikeSubLevelChangeTask";
			Func<UniTask<bool>> runHandle;
			if ((runHandle = CS$<>8__locals1.<>9__2) == null)
			{
				runHandle = (CS$<>8__locals1.<>9__2 = delegate()
				{
					WeeklyRogueController.<>c__DisplayClass18_0.<<OnRogueWeeklySubLevelNotify>b__2>d <<OnRogueWeeklySubLevelNotify>b__2>d;
					<<OnRogueWeeklySubLevelNotify>b__2>d.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
					<<OnRogueWeeklySubLevelNotify>b__2>d.<>4__this = CS$<>8__locals1;
					<<OnRogueWeeklySubLevelNotify>b__2>d.<>1__state = -1;
					<<OnRogueWeeklySubLevelNotify>b__2>d.<>t__builder.Start<WeeklyRogueController.<>c__DisplayClass18_0.<<OnRogueWeeklySubLevelNotify>b__2>d>(ref <<OnRogueWeeklySubLevelNotify>b__2>d);
					return <<OnRogueWeeklySubLevelNotify>b__2>d.<>t__builder.Task;
				});
			}
			AsyncTask task = new AsyncTask(name, runHandle, null, null, null);
			Singleton<TaskSystem>.Instance.AddTask(task);
			Singleton<TaskSystem>.Instance.Run().Forget<bool>();
		};
		if (CS$<>8__locals1.notify.IsExtra && LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.WeeklyRogueExtraEnterTips, true))
		{
			ExtraRoomTipsData param = new ExtraRoomTipsData
			{
				CurScore = CS$<>8__locals1.notify.CurScore,
				MaxScore = CS$<>8__locals1.notify.MaxScore,
				ConfirmFunc = action,
				CancelFunc = cancelFunc
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRogueExtraRoomConfirmView, param, null);
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.WeeklyRogueExtraEnterTips, false);
			return;
		}
		action();
	}

	// Token: 0x060176D6 RID: 95958 RVA: 0x0067F018 File Offset: 0x0067D218
	private void OnRogueWeeklyBlackFlowerNotify(RogueWeeklyBlackFlowerNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		int cycleBlackFlowerCost = ModelBase<WeeklyRogueModel>.Instance.ActivityData.GetCycleBlackFlowerCost();
		bool isReceive = false;
		WeeklyRogueRewardPopViewData param = new WeeklyRogueRewardPopViewData
		{
			SinglePowerCost = cycleBlackFlowerCost,
			RewardCallBack = delegate(int count, int silentId)
			{
				isReceive = true;
				this.BlackFlowerRewardRequest(data.EntityConfigId, true, count == 2, silentId);
			},
			CloseCallBack = delegate
			{
				if (!isReceive)
				{
					this.BlackFlowerRewardRequest(data.EntityConfigId, false, false, -1);
				}
			},
			AvailableSilentArea = data.SilentAreaIds.ToList<int>(),
			FreeCount = ModelBase<WeeklyRogueModel>.Instance.ActivityData.FreeCount,
			FreeMax = ModelBase<WeeklyRogueModel>.Instance.ActivityData.FreeCountMax
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRoguePhantomRewardView, param, null);
	}

	// Token: 0x060176D7 RID: 95959 RVA: 0x0067F0D4 File Offset: 0x0067D2D4
	[return: Nullable(new byte[]
	{
		0,
		1,
		1,
		1,
		1
	})]
	private ValueTuple<string[], string[]> FilterSameSubLevel(RogueWeeklySubLevelNotify notify)
	{
		List<string> list = new List<string>();
		foreach (string item in notify.UnLoadSubLevels)
		{
			if (notify.LoadSubLevels.IndexOf(item) < 0)
			{
				list.Add(item);
			}
		}
		List<string> list2 = new List<string>();
		foreach (string item2 in notify.LoadSubLevels)
		{
			if (notify.UnLoadSubLevels.IndexOf(item2) < 0)
			{
				list2.Add(item2);
			}
		}
		return new ValueTuple<string[], string[]>(list.ToArray(), list2.ToArray());
	}

	// Token: 0x060176D8 RID: 95960 RVA: 0x0067F19C File Offset: 0x0067D39C
	private void OnRogueWeeklyInstInfoNotify(RogueWeeklyInstInfoNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<WeeklyRogueModel>.Instance.UpdateInstInfo(data);
		Singleton<EventSystem>.Instance.Emit(EEventName.WeeklyRogueInstDataUpdate);
	}

	// Token: 0x060176D9 RID: 95961 RVA: 0x0067F1BC File Offset: 0x0067D3BC
	[NullableContext(2)]
	public void SelectOptionRequest(Action<bool> callback = null)
	{
		RogueWeeklyOptionSelectRequest rogueWeeklyOptionSelectRequest = RogueWeeklyOptionSelectRequest.Create();
		rogueWeeklyOptionSelectRequest.BindId = ModelBase<WeeklyRogueModel>.Instance.CurrentBindId;
		rogueWeeklyOptionSelectRequest.Index = ModelBase<WeeklyRogueModel>.Instance.SelectEntry.Index;
		Singleton<Net>.Instance.Call<RogueWeeklyOptionSelectResponse>(ERequestMessageId.RogueWeeklyOptionSelectRequest, rogueWeeklyOptionSelectRequest, delegate(RogueWeeklyOptionSelectResponse response, Net.CallbackStatus status)
		{
			if (response == null)
			{
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(false);
				return;
			}
			else if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 21488, response.ErrorParams.ToArray<string>(), true, true);
				Action<bool> callback3 = callback;
				if (callback3 == null)
				{
					return;
				}
				callback3(false);
				return;
			}
			else
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.WeeklyRogueSelectOption);
				Action<bool> callback4 = callback;
				if (callback4 == null)
				{
					return;
				}
				callback4(true);
				return;
			}
		}, 0);
	}

	// Token: 0x060176DA RID: 95962 RVA: 0x0067F220 File Offset: 0x0067D420
	[NullableContext(0)]
	public UniTask<bool> SelectArtifactRequest()
	{
		WeeklyRogueController.<SelectArtifactRequest>d__23 <SelectArtifactRequest>d__;
		<SelectArtifactRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SelectArtifactRequest>d__.<>1__state = -1;
		<SelectArtifactRequest>d__.<>t__builder.Start<WeeklyRogueController.<SelectArtifactRequest>d__23>(ref <SelectArtifactRequest>d__);
		return <SelectArtifactRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060176DB RID: 95963 RVA: 0x0067F25C File Offset: 0x0067D45C
	[NullableContext(2)]
	public void InstanceSettleRequest(Action<bool> callback = null)
	{
		RogueWeeklyResultRequest message = RogueWeeklyResultRequest.Create();
		Singleton<Net>.Instance.Call<RogueWeeklyResultResponse>(ERequestMessageId.RogueWeeklyResultRequest, message, delegate(RogueWeeklyResultResponse response, Net.CallbackStatus status)
		{
			if (response == null)
			{
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(false);
				return;
			}
			else if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15348, null, true, true);
				Action<bool> callback3 = callback;
				if (callback3 == null)
				{
					return;
				}
				callback3(false);
				return;
			}
			else
			{
				if (ModelBase<WeeklyRogueModel>.Instance.HasLastInfo())
				{
					ModelBase<WeeklyRogueModel>.Instance.ActivityData.LastInstInfo = null;
				}
				Action<bool> callback4 = callback;
				if (callback4 == null)
				{
					return;
				}
				callback4(true);
				return;
			}
		}, 0);
	}

	// Token: 0x060176DC RID: 95964 RVA: 0x0067F29C File Offset: 0x0067D49C
	public UniTask GotoNextRoomRequest(bool confirmEnter = true)
	{
		WeeklyRogueController.<GotoNextRoomRequest>d__25 <GotoNextRoomRequest>d__;
		<GotoNextRoomRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<GotoNextRoomRequest>d__.confirmEnter = confirmEnter;
		<GotoNextRoomRequest>d__.<>1__state = -1;
		<GotoNextRoomRequest>d__.<>t__builder.Start<WeeklyRogueController.<GotoNextRoomRequest>d__25>(ref <GotoNextRoomRequest>d__);
		return <GotoNextRoomRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060176DD RID: 95965 RVA: 0x0067F2E0 File Offset: 0x0067D4E0
	public void BlackFlowerRewardRequest(int entityId, bool isReceive, bool isDouble, int areaId)
	{
		RogueWeeklyBlackFlowerRequest rogueWeeklyBlackFlowerRequest = RogueWeeklyBlackFlowerRequest.Create();
		rogueWeeklyBlackFlowerRequest.EntityConfigId = entityId;
		rogueWeeklyBlackFlowerRequest.IsDouble = isDouble;
		rogueWeeklyBlackFlowerRequest.Ret = isReceive;
		rogueWeeklyBlackFlowerRequest.SilentAreaId = areaId;
		Singleton<Net>.Instance.Call<RogueWeeklyBlackFlowerResponse>(ERequestMessageId.RogueWeeklyBlackFlowerRequest, rogueWeeklyBlackFlowerRequest, delegate(RogueWeeklyBlackFlowerResponse response, Net.CallbackStatus status)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29958, null, true, true);
				return;
			}
			if (isReceive)
			{
				ModelBase<WeeklyRogueModel>.Instance.ActivityData.FreeCount = response.MaxFreeCount - response.UseFreeCount;
				ModelBase<WeeklyRogueModel>.Instance.ActivityData.FreeCountMax = response.MaxFreeCount;
			}
		}, 0);
	}

	// Token: 0x060176DE RID: 95966 RVA: 0x0067F340 File Offset: 0x0067D540
	public void RogueWeeklyStartRequest(List<int> roleList)
	{
		RogueWeeklyStartRequest rogueWeeklyStartRequest = Aki.Protocol.RogueWeeklyStartRequest.Create();
		rogueWeeklyStartRequest.CycleId = ModelBase<WeeklyRogueModel>.Instance.CycleId;
		rogueWeeklyStartRequest.Roles.AddRange(roleList);
		Singleton<Net>.Instance.Call<RogueWeeklyStartResponse>(ERequestMessageId.RogueWeeklyStartRequest, rogueWeeklyStartRequest, delegate(RogueWeeklyStartResponse response, Net.CallbackStatus status)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29662, null, true, true);
				return;
			}
		}, 0);
	}

	// Token: 0x060176DF RID: 95967 RVA: 0x0067F3A0 File Offset: 0x0067D5A0
	public UniTask RogueWeeklyArtifactSelectStartRequest()
	{
		WeeklyRogueController.<RogueWeeklyArtifactSelectStartRequest>d__28 <RogueWeeklyArtifactSelectStartRequest>d__;
		<RogueWeeklyArtifactSelectStartRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RogueWeeklyArtifactSelectStartRequest>d__.<>1__state = -1;
		<RogueWeeklyArtifactSelectStartRequest>d__.<>t__builder.Start<WeeklyRogueController.<RogueWeeklyArtifactSelectStartRequest>d__28>(ref <RogueWeeklyArtifactSelectStartRequest>d__);
		return <RogueWeeklyArtifactSelectStartRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060176E0 RID: 95968 RVA: 0x0067F3DC File Offset: 0x0067D5DC
	public void MultiRogueWeeklyRewardRequest()
	{
		MulRogueWeeklyRewardRequest mulRogueWeeklyRewardRequest = MulRogueWeeklyRewardRequest.Create();
		mulRogueWeeklyRewardRequest.ActivityId = ModelBase<WeeklyRogueModel>.Instance.ActivityData.Id;
		List<IActivityRewardData> dataList = ModelBase<WeeklyRogueModel>.Instance.GetScoreRewardData().DataPageList[0].DataList;
		List<int> configIds = new List<int>();
		foreach (IActivityRewardData activityRewardData in dataList)
		{
			if (activityRewardData.RewardState == EActivityRewardState.Enable && activityRewardData.Id != null)
			{
				configIds.Add(activityRewardData.Id.Value);
			}
		}
		if (configIds.Count == 0)
		{
			return;
		}
		mulRogueWeeklyRewardRequest.ConfigId.AddRange(configIds);
		Singleton<Net>.Instance.Call<MulRogueWeeklyRewardResponse>(ERequestMessageId.MulRogueWeeklyRewardRequest, mulRogueWeeklyRewardRequest, delegate(MulRogueWeeklyRewardResponse response, Net.CallbackStatus status)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25747, null, true, true);
				return;
			}
			foreach (int id in configIds)
			{
				ModelBase<WeeklyRogueModel>.Instance.ActivityData.SetScoreRewardState(id, SignState.IsReceive);
			}
			Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, ModelBase<WeeklyRogueModel>.Instance.GetScoreRewardData());
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, ModelBase<WeeklyRogueModel>.Instance.ActivityData.Id);
			Singleton<EventSystem>.Instance.Emit(EEventName.WeeklyRogueRedDotInfoRefresh);
		}, 0);
	}

	// Token: 0x060176E1 RID: 95969 RVA: 0x0067F4D8 File Offset: 0x0067D6D8
	public UniTask RogueWeeklyLastInfoRequest()
	{
		WeeklyRogueController.<RogueWeeklyLastInfoRequest>d__30 <RogueWeeklyLastInfoRequest>d__;
		<RogueWeeklyLastInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RogueWeeklyLastInfoRequest>d__.<>1__state = -1;
		<RogueWeeklyLastInfoRequest>d__.<>t__builder.Start<WeeklyRogueController.<RogueWeeklyLastInfoRequest>d__30>(ref <RogueWeeklyLastInfoRequest>d__);
		return <RogueWeeklyLastInfoRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060176E2 RID: 95970 RVA: 0x0067F514 File Offset: 0x0067D714
	[NullableContext(0)]
	public UniTask<bool> OpenTokenSelectViewById(int boardId)
	{
		WeeklyRogueController.<OpenTokenSelectViewById>d__31 <OpenTokenSelectViewById>d__;
		<OpenTokenSelectViewById>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenTokenSelectViewById>d__.<>4__this = this;
		<OpenTokenSelectViewById>d__.boardId = boardId;
		<OpenTokenSelectViewById>d__.<>1__state = -1;
		<OpenTokenSelectViewById>d__.<>t__builder.Start<WeeklyRogueController.<OpenTokenSelectViewById>d__31>(ref <OpenTokenSelectViewById>d__);
		return <OpenTokenSelectViewById>d__.<>t__builder.Task;
	}

	// Token: 0x060176E3 RID: 95971 RVA: 0x0067F560 File Offset: 0x0067D760
	public EUiViewName? GetViewNameByType(RogueWeeklyEntryType optionType)
	{
		if (optionType == RogueWeeklyEntryType.Unknow)
		{
			return null;
		}
		if (optionType == RogueWeeklyEntryType.Goods)
		{
			return new EUiViewName?(EUiViewName.WeeklyRogueShop);
		}
		if (optionType != RogueWeeklyEntryType.CommonBuff)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.WeeklyRogue;
			ELogAuthor author = ELogAuthor.LPH;
			string message = "未知选项类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("optionType", optionType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new EUiViewName?(EUiViewName.WeeklyRogueSelectToken);
	}

	// Token: 0x060176E4 RID: 95972 RVA: 0x0067F5D3 File Offset: 0x0067D7D3
	private void OnNewLinkStatusChanged(ENewLinkStatus stage)
	{
		this.NewLinkStage = (ENewLinkStage)stage;
		if (this.NewLinkStage == ENewLinkStage.Burst)
		{
			this.AddLinkBuffAndBullet();
			return;
		}
		this.ClearLinkBurstBuffs();
	}

	// Token: 0x060176E5 RID: 95973 RVA: 0x0067F5F4 File Offset: 0x0067D7F4
	public bool RequestNewLinkBurst()
	{
		if (this.NewLinkStage != ENewLinkStage.Ready)
		{
			return false;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
		if (worldEntity == null)
		{
			return false;
		}
		Singleton<CombatNet>.Instance.Send(EPushMessageId.NewLinkBurstPush, worldEntity, NewLinkBurstPush.Create(), null, null, null);
		return true;
	}

	// Token: 0x060176E6 RID: 95974 RVA: 0x0067F65C File Offset: 0x0067D85C
	private void AddLinkBuffAndBullet()
	{
		if (!ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue())
		{
			return;
		}
		WorldEntity entity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity;
		CharacterBuffComponent component = entity.GetComponent<CharacterBuffComponent>();
		RogueWeeklyCycle? cycleConfig = ModelBase<WeeklyRogueModel>.Instance.ActivityData.GetCycleConfig();
		int? num = (cycleConfig != null) ? new int?(cycleConfig.GetValueOrDefault().LinkId) : null;
		if (num == null)
		{
			return;
		}
		BattleLinkConfig instance = ConfigBase<BattleLinkConfig>.Instance;
		LinkData? linkData = (instance != null) ? instance.GetLinkDataConfig(num.Value) : null;
		if (linkData == null)
		{
			return;
		}
		long? messageId = ControllerBase<BattleLinkController>.Instance.GetMessageId();
		if (messageId == null)
		{
			return;
		}
		long value = Singleton<MathUtils>.Instance.LongToBigInt(messageId.Value);
		foreach (long num2 in linkData.Value.BuffIdsInBrust())
		{
			component.AddBuff(num2, new AddBuffParam
			{
				InstigatorId = component.CreatureDataId,
				Reason = "周常肉鸽link增加buff",
				PreMessageId = new long?(value)
			});
			if (this.CurrentLinkBurstBuffs == null)
			{
				this.CurrentLinkBurstBuffs = new List<long>();
			}
			this.CurrentLinkBurstBuffs.Add(num2);
		}
		foreach (long num3 in linkData.Value.BulletIdsInBrust())
		{
			ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(entity, num3.ToString(), null, null, new long?(value), global::EBulletCreateSource.Others);
		}
	}

	// Token: 0x060176E7 RID: 95975 RVA: 0x0067F7F8 File Offset: 0x0067D9F8
	private void ClearLinkBurstBuffs()
	{
		if (this.CurrentLinkBurstBuffs == null || this.CurrentLinkBurstBuffs.Count == 0)
		{
			return;
		}
		if (!ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue())
		{
			this.CurrentLinkBurstBuffs.Clear();
			return;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
		CharacterBuffComponent characterBuffComponent = (worldEntity != null) ? worldEntity.GetComponent<CharacterBuffComponent>() : null;
		if (characterBuffComponent != null)
		{
			foreach (long buffId in this.CurrentLinkBurstBuffs)
			{
				characterBuffComponent.RemoveBuff(buffId, -1, "周常肉鸽离开Link爆发状态", null, null, null);
			}
		}
		this.CurrentLinkBurstBuffs.Clear();
	}

	// Token: 0x0400B3AD RID: 45997
	public bool IsNeedShowDailyActivityWeekly;

	// Token: 0x0400B3AE RID: 45998
	public ENewLinkStage NewLinkStage;

	// Token: 0x0400B3AF RID: 45999
	[Nullable(2)]
	private List<long> CurrentLinkBurstBuffs;
}
