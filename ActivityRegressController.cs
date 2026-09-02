using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x02001501 RID: 5377
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityRegressController : ActivityControllerBase<ActivityRegressController>
{
	// Token: 0x0600968C RID: 38540 RVA: 0x00275FF4 File Offset: 0x002741F4
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0600968D RID: 38541 RVA: 0x00275FF7 File Offset: 0x002741F7
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x0600968E RID: 38542 RVA: 0x00275FFC File Offset: 0x002741FC
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(this.OnActivityUpdate));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnInventoryUpdate));
		Singleton<EventSystem>.Instance.Add<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x0600968F RID: 38543 RVA: 0x0027607C File Offset: 0x0027427C
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(this.OnActivityUpdate));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnInventoryUpdate));
		Singleton<EventSystem>.Instance.Remove<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06009690 RID: 38544 RVA: 0x002760F9 File Offset: 0x002742F9
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<RegressActivityTrialRoleUpdateNotify>(ENotifyMessageId.RegressActivityTrialRoleUpdateNotify, new Action<RegressActivityTrialRoleUpdateNotify, Net.CallbackStatus>(this.RegressActivityTrialRoleUpdateNotify));
		Singleton<Net>.Instance.Register<RegressTrialRoleUnlockNotify>(ENotifyMessageId.RegressTrialRoleUnlockNotify, new Action<RegressTrialRoleUnlockNotify, Net.CallbackStatus>(this.RegressTrialRoleUnlockNotify));
	}

	// Token: 0x06009691 RID: 38545 RVA: 0x00276133 File Offset: 0x00274333
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RegressActivityTrialRoleUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RegressTrialRoleUnlockNotify);
	}

	// Token: 0x06009692 RID: 38546 RVA: 0x00276155 File Offset: 0x00274355
	protected override bool OnClear()
	{
		this.ActivityStartConditionMap.Clear();
		return true;
	}

	// Token: 0x06009693 RID: 38547 RVA: 0x00276163 File Offset: 0x00274363
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_CircumfluenceMain30";
	}

	// Token: 0x06009694 RID: 38548 RVA: 0x0027616A File Offset: 0x0027436A
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		ModelBase<ActivityRegressModel>.Instance.ActivityId = data.Id;
		return new ActivityRegressData();
	}

	// Token: 0x06009695 RID: 38549 RVA: 0x00276181 File Offset: 0x00274381
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivityRegress30MainView();
	}

	// Token: 0x06009696 RID: 38550 RVA: 0x00276188 File Offset: 0x00274388
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		foreach (EUiViewName viewName in new EUiViewName[]
		{
			EUiViewName.ActivityNewPlayerSupportTrialRoleView
		})
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06009697 RID: 38551 RVA: 0x002761CE File Offset: 0x002743CE
	public void RequestClaimSignReward(int rewardId)
	{
		this.RegressTaskRewardRequest(rewardId, RegressTaskTypeEnum.SignReward);
	}

	// Token: 0x06009698 RID: 38552 RVA: 0x002761D8 File Offset: 0x002743D8
	public void RequestClaimQuestionnaireReward(ERegressQuestionnaireType type)
	{
		RegressInvestigation? regressQuestionnaireConfig = ConfigBase<ActivityRegressConfig>.Instance.GetRegressQuestionnaireConfig(type);
		if (regressQuestionnaireConfig == null)
		{
			return;
		}
		this.RegressTaskRewardRequest(regressQuestionnaireConfig.Value.Id, RegressTaskTypeEnum.Questionnaire);
	}

	// Token: 0x06009699 RID: 38553 RVA: 0x00276214 File Offset: 0x00274414
	public void RequestClaimScoreReward(List<int> rewardIds)
	{
		ActivityRegressController.<>c__DisplayClass15_0 CS$<>8__locals1 = new ActivityRegressController.<>c__DisplayClass15_0();
		CS$<>8__locals1.rewardIds = rewardIds;
		int activityId = ModelBase<ActivityRegressModel>.Instance.ActivityId;
		RegressBonusRequest regressBonusRequest = RegressBonusRequest.Create();
		regressBonusRequest.Ids.AddRange(CS$<>8__locals1.rewardIds);
		regressBonusRequest.ActivityId = activityId;
		Singleton<Net>.Instance.Call<RegressBonusResponse>(ERequestMessageId.RegressBonusRequest, regressBonusRequest, new Action<RegressBonusResponse, Net.CallbackStatus>(CS$<>8__locals1.<RequestClaimScoreReward>g__Response|0), 0);
	}

	// Token: 0x0600969A RID: 38554 RVA: 0x00276274 File Offset: 0x00274474
	public void RequestClaimTaskReward(int taskId)
	{
		this.RegressTaskRewardRequest(taskId, RegressTaskTypeEnum.TaskReward);
	}

	// Token: 0x0600969B RID: 38555 RVA: 0x00276280 File Offset: 0x00274480
	private void RegressTaskRewardRequest(int taskId, RegressTaskTypeEnum rewardType)
	{
		int activityId = ModelBase<ActivityRegressModel>.Instance.ActivityId;
		RegressTaskRequest regressTaskRequest = RegressTaskRequest.Create();
		regressTaskRequest.ActivityId = activityId;
		regressTaskRequest.RewardType = rewardType;
		regressTaskRequest.TaskId = taskId;
		Singleton<Net>.Instance.Call<RegressTaskResponse>(ERequestMessageId.RegressTaskRequest, regressTaskRequest, new Action<RegressTaskResponse, Net.CallbackStatus>(ActivityRegressController.<RegressTaskRewardRequest>g__Response|17_0), 0);
	}

	// Token: 0x0600969C RID: 38556 RVA: 0x002762D0 File Offset: 0x002744D0
	public void RequestClaimAllTaskReward()
	{
		List<RegressQuest> list = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetRegressTaskListByType(ERegressTaskType.Constant) ?? new List<RegressQuest>();
		List<RegressQuest> regressTaskListByType = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetRegressTaskListByType(ERegressTaskType.Daily);
		if (regressTaskListByType != null)
		{
			list.AddRange(regressTaskListByType);
		}
		List<RegressQuest> regressTaskListByType2 = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetRegressTaskListByType(ERegressTaskType.Once);
		if (regressTaskListByType2 != null)
		{
			list.AddRange(regressTaskListByType2);
		}
		List<int> list2 = new List<int>();
		for (int i = 0; i < list.Count; i++)
		{
			int id = list[i].Id;
			if (ModelBase<ActivityRegressModel>.Instance.ActivityData.GetTaskRewardState(id) == ERegressRewardState.Reached)
			{
				list2.Add(id);
			}
		}
		if (list2.Count == 0)
		{
			return;
		}
		int activityId = ModelBase<ActivityRegressModel>.Instance.ActivityId;
		RegressRepeatedTaskRequest regressRepeatedTaskRequest = RegressRepeatedTaskRequest.Create();
		regressRepeatedTaskRequest.ActivityId = activityId;
		regressRepeatedTaskRequest.TaskId.AddRange(list2);
		Singleton<Net>.Instance.Call<RegressRepeatedTaskResponse>(ERequestMessageId.RegressRepeatedTaskRequest, regressRepeatedTaskRequest, new Action<RegressRepeatedTaskResponse, Net.CallbackStatus>(ActivityRegressController.<RequestClaimAllTaskReward>g__Response|18_0), 0);
	}

	// Token: 0x0600969D RID: 38557 RVA: 0x002763C8 File Offset: 0x002745C8
	public UniTask RequestGachaInfo()
	{
		ActivityRegressController.<RequestGachaInfo>d__19 <RequestGachaInfo>d__;
		<RequestGachaInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestGachaInfo>d__.<>1__state = -1;
		<RequestGachaInfo>d__.<>t__builder.Start<ActivityRegressController.<RequestGachaInfo>d__19>(ref <RequestGachaInfo>d__);
		return <RequestGachaInfo>d__.<>t__builder.Task;
	}

	// Token: 0x0600969E RID: 38558 RVA: 0x00276404 File Offset: 0x00274604
	public void RegressSetCurUseTrialRoleRequest(int roleId, Action<int> callback)
	{
		ActivityRegressController.<>c__DisplayClass20_0 CS$<>8__locals1 = new ActivityRegressController.<>c__DisplayClass20_0();
		CS$<>8__locals1.callback = callback;
		RegressSetCurUseTrialRoleRequest regressSetCurUseTrialRoleRequest = Aki.Protocol.RegressSetCurUseTrialRoleRequest.Create();
		regressSetCurUseTrialRoleRequest.TrialRoleId = roleId;
		Singleton<Net>.Instance.Call<RegressSetCurUseTrialRoleResponse>(ERequestMessageId.RegressSetCurUseTrialRoleRequest, regressSetCurUseTrialRoleRequest, new Action<RegressSetCurUseTrialRoleResponse, Net.CallbackStatus>(CS$<>8__locals1.<RegressSetCurUseTrialRoleRequest>g__Response|0), 0);
	}

	// Token: 0x0600969F RID: 38559 RVA: 0x00276448 File Offset: 0x00274648
	private void RegressActivityTrialRoleUpdateNotify(RegressActivityTrialRoleUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		RepeatedField<int> trialRoleId = notify.TrialRoleId;
		roleInfo curUseRoleInfo = notify.CurUseRoleInfo;
		foreach (int num in trialRoleId)
		{
			if (curUseRoleInfo != null && curUseRoleInfo.RoleId == num)
			{
				this.UpdateActivatedTrialRoleInternal(num, curUseRoleInfo);
			}
			else
			{
				this.UpdateActivatedTrialRoleInternal(num, null);
			}
		}
	}

	// Token: 0x060096A0 RID: 38560 RVA: 0x002764B4 File Offset: 0x002746B4
	private void RegressTrialRoleUnlockNotify(RegressTrialRoleUnlockNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		foreach (int roleId in notify.RoleId)
		{
			this.UpdateActivatedTrialRoleInternal(roleId, null);
		}
	}

	// Token: 0x060096A1 RID: 38561 RVA: 0x00276504 File Offset: 0x00274704
	[NullableContext(2)]
	private void UpdateActivatedTrialRoleInternal(int roleId, roleInfo trialRoleInfo = null)
	{
		TrialRoleConfig instance = ConfigBase<TrialRoleConfig>.Instance;
		int? num = (instance != null) ? instance.GetTrialRoleGroupId(roleId) : null;
		if (ModelBase<TrialRoleModel>.Instance.GetDataByGroupId(num.Value).IsLocked())
		{
			ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
			if (activityData != null)
			{
				activityData.SetTrialRoleRedDotChecked(false);
			}
		}
		ModelBase<TrialRoleModel>.Instance.SetGroupTrialRoleId(roleId, trialRoleInfo);
	}

	// Token: 0x060096A2 RID: 38562 RVA: 0x00276568 File Offset: 0x00274768
	public void RegressTrialRoleLvUpRequest(int trialRoleId)
	{
		RegressTrialRoleLvUpRequest regressTrialRoleLvUpRequest = Aki.Protocol.RegressTrialRoleLvUpRequest.Create();
		regressTrialRoleLvUpRequest.TrialRoleId = trialRoleId;
		Singleton<Net>.Instance.Call<RegressTrialRoleLvUpResponse>(ERequestMessageId.RegressTrialRoleLvUpRequest, regressTrialRoleLvUpRequest, delegate(RegressTrialRoleLvUpResponse response, Net.CallbackStatus _)
		{
			if (response == null || response.Code != Aki.Protocol.ErrorCode.Success)
			{
				if (response != null)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, EResponseMessageId.RegressTrialRoleLvUpResponse, null, true, true);
				}
				return;
			}
			this.UpdateActivatedTrialRoleInternal(response.RoleId, response.CurUseRoleInfo);
		}, 0);
	}

	// Token: 0x060096A3 RID: 38563 RVA: 0x0027659F File Offset: 0x0027479F
	private void OnWorldDone()
	{
		this.ActivityStartConditionMap[ERecallStartCondition.WorldDone] = true;
		this.CheckIsStart(false);
	}

	// Token: 0x060096A4 RID: 38564 RVA: 0x002765B8 File Offset: 0x002747B8
	private void OnActivityUpdate()
	{
		bool isActivityRecallReady = ModelBase<ActivityRegressModel>.Instance.IsActivityRecallReady;
		this.ActivityStartConditionMap[ERecallStartCondition.RecallReady] = isActivityRecallReady;
		bool value = ModelBase<ActivityRegressModel>.Instance.IsActivityRecallSplashFirstShow();
		this.ActivityStartConditionMap[ERecallStartCondition.FirstShow] = value;
		bool activityRecallForbidStart = ModelBase<ActivityRegressModel>.Instance.ActivityRecallForbidStart;
		this.ActivityStartConditionMap[ERecallStartCondition.UnForbidStart] = !activityRecallForbidStart;
		bool isActivityOpen = ModelBase<ActivityRegressModel>.Instance.IsActivityOpen;
		this.ActivityStartConditionMap[ERecallStartCondition.IsOpen] = isActivityOpen;
		this.CheckIsStart(true);
	}

	// Token: 0x060096A5 RID: 38565 RVA: 0x00276630 File Offset: 0x00274830
	private void CheckIsStart(bool isInstantly = false)
	{
		bool flag = true;
		foreach (object obj in Enum.GetValues(typeof(ERecallStartCondition)))
		{
			ERecallStartCondition key = (ERecallStartCondition)obj;
			bool flag2;
			if (!this.ActivityStartConditionMap.TryGetValue(key, out flag2) || !flag2)
			{
				flag = false;
				key.ToString();
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		if (ModelBase<ActivityRegressModel>.Instance.AlreadyStartView)
		{
			return;
		}
		SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.Recall, ESplashScreenType.Config, delegate()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressStartupView, null, null);
		});
		ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, isInstantly);
	}

	// Token: 0x060096A6 RID: 38566 RVA: 0x002766FC File Offset: 0x002748FC
	private void OnInventoryUpdate(int configId, int count)
	{
		if (ModelBase<ActivityRegressModel>.Instance.ActivityData != null && 20 == configId)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, ModelBase<ActivityRegressModel>.Instance.ActivityId);
			ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
			int prevBpExp = activityData.PrevBpExp;
			IRegressLevelProgressData? levelProgressDataByScore = activityData.GetLevelProgressDataByScore(prevBpExp);
			IRegressLevelProgressData? levelProgressDataByScore2 = activityData.GetLevelProgressDataByScore(count);
			if (levelProgressDataByScore == null || levelProgressDataByScore2 == null)
			{
				return;
			}
			int level = levelProgressDataByScore.Value.Level;
			int level2 = levelProgressDataByScore2.Value.Level;
			float p = (levelProgressDataByScore.Value.NeedScore > 0) ? ((float)levelProgressDataByScore.Value.CurScore / (float)levelProgressDataByScore.Value.NeedScore) : 0f;
			float p2 = (levelProgressDataByScore2.Value.NeedScore > 0) ? ((float)levelProgressDataByScore2.Value.CurScore / (float)levelProgressDataByScore2.Value.NeedScore) : 0f;
			Singleton<EventSystem>.Instance.Emit<int, int, float, float>(EEventName.RegressBpExpAnim, level, level2, p, p2);
			activityData.RefreshPrevBpExp();
		}
	}

	// Token: 0x060096A7 RID: 38567 RVA: 0x00276834 File Offset: 0x00274A34
	public void OpenQuestionnaire(ERegressQuestionnaireType type)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.ActivityRegress;
		ELogAuthor author = ELogAuthor.LRX;
		string message = "回流活动->打开调查问卷";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		bool flag = !ControllerBase<KuroSdkController>.Instance.CanUseSdk();
		string questionnaireUrl = this.GetQuestionnaireUrl(type);
		bool isLandscape = true;
		string title = "";
		if (flag)
		{
			ModelBase<MailModel>.Instance.OpenWebBrowser(questionnaireUrl);
			return;
		}
		ControllerBase<KuroSdkController>.Instance.SdkOpenUrlWnd(title, questionnaireUrl, isLandscape, false, true);
	}

	// Token: 0x060096A8 RID: 38568 RVA: 0x002768AC File Offset: 0x00274AAC
	public void RequestQuestionOpen(ERegressQuestionnaireType type)
	{
		ActivityRegressController.<>c__DisplayClass30_0 CS$<>8__locals1 = new ActivityRegressController.<>c__DisplayClass30_0();
		RegressInvestigation? regressQuestionnaireConfig = ConfigBase<ActivityRegressConfig>.Instance.GetRegressQuestionnaireConfig(type);
		if (regressQuestionnaireConfig == null)
		{
			return;
		}
		CS$<>8__locals1.questionConfig = regressQuestionnaireConfig.Value;
		RegressQuestionOpenRequest regressQuestionOpenRequest = RegressQuestionOpenRequest.Create();
		regressQuestionOpenRequest.QuestionId = CS$<>8__locals1.questionConfig.Id;
		Singleton<Net>.Instance.Call<RegressQuestionOpenResponse>(ERequestMessageId.RegressQuestionOpenRequest, regressQuestionOpenRequest, new Action<RegressQuestionOpenResponse, Net.CallbackStatus>(CS$<>8__locals1.<RequestQuestionOpen>g__Response|0), 0);
	}

	// Token: 0x060096A9 RID: 38569 RVA: 0x00276918 File Offset: 0x00274B18
	public UniTask NewTrialRoleGetNightmarePhantomInstInfoRequest()
	{
		ActivityRegressController.<NewTrialRoleGetNightmarePhantomInstInfoRequest>d__31 <NewTrialRoleGetNightmarePhantomInstInfoRequest>d__;
		<NewTrialRoleGetNightmarePhantomInstInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<NewTrialRoleGetNightmarePhantomInstInfoRequest>d__.<>1__state = -1;
		<NewTrialRoleGetNightmarePhantomInstInfoRequest>d__.<>t__builder.Start<ActivityRegressController.<NewTrialRoleGetNightmarePhantomInstInfoRequest>d__31>(ref <NewTrialRoleGetNightmarePhantomInstInfoRequest>d__);
		return <NewTrialRoleGetNightmarePhantomInstInfoRequest>d__.<>t__builder.Task;
	}

	// Token: 0x060096AA RID: 38570 RVA: 0x00276954 File Offset: 0x00274B54
	public string GetQuestionnaireUrl(ERegressQuestionnaireType type)
	{
		RegressInvestigation value = ConfigBase<ActivityRegressConfig>.Instance.GetRegressQuestionnaireConfig(type).Value;
		string value2 = ModelBase<LoginModel>.Instance.GetServerId() ?? "";
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		string stringConfig = ConfigCommonParamById.GetStringConfig("mail_question_key");
		int questionnaireId = value.QuestionnaireId;
		string hyperLink = value.HyperLink;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 4);
		defaultInterpolatedStringHandler.AppendFormatted<int>(questionnaireId);
		defaultInterpolatedStringHandler.AppendFormatted<int?>(id);
		defaultInterpolatedStringHandler.AppendLiteral(";");
		defaultInterpolatedStringHandler.AppendFormatted(value2);
		defaultInterpolatedStringHandler.AppendFormatted(stringConfig);
		string text = defaultInterpolatedStringHandler.ToStringAndClear();
		text = UKuroStaticLibrary.HashStringWithSHA1(text);
		int questionnaireId2 = ConfigBase<LanguageConfig>.Instance.GetLanguageDefineByLanguageCode(Singleton<LanguageSystem>.Instance.PackageLanguage).Value.QuestionnaireId;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 5);
		defaultInterpolatedStringHandler.AppendFormatted(hyperLink);
		defaultInterpolatedStringHandler.AppendLiteral("?sojumpparm=");
		defaultInterpolatedStringHandler.AppendFormatted<int?>(id);
		defaultInterpolatedStringHandler.AppendLiteral(";");
		defaultInterpolatedStringHandler.AppendFormatted(value2);
		defaultInterpolatedStringHandler.AppendLiteral("&parmsign=");
		defaultInterpolatedStringHandler.AppendFormatted(text);
		defaultInterpolatedStringHandler.AppendLiteral("&langv=");
		defaultInterpolatedStringHandler.AppendFormatted<int>(questionnaireId2);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060096AB RID: 38571 RVA: 0x00276A90 File Offset: 0x00274C90
	public void RequestAllTaskScoreRewards()
	{
		IReadOnlyList<RegressBonusReward> sortedRegressBonusRewardConfigList = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetSortedRegressBonusRewardConfigList();
		List<int> list = new List<int>();
		ModelBase<ActivityRegressModel>.Instance.NeedShowExtraRewardView = false;
		for (int i = 0; i < sortedRegressBonusRewardConfigList.Count; i++)
		{
			RegressBonusReward config = sortedRegressBonusRewardConfigList[i];
			int id = config.Id;
			ERegressRewardState regressTaskScoreRewardState = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetRegressTaskScoreRewardState(config);
			ERegressRewardState regressTaskPayScoreRewardState = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetRegressTaskPayScoreRewardState(config);
			if ((i + 1) % 5 == 0 && regressTaskScoreRewardState == ERegressRewardState.Reached)
			{
				ModelBase<ActivityRegressModel>.Instance.NeedShowExtraRewardView = true;
			}
			if (regressTaskScoreRewardState == ERegressRewardState.Reached || regressTaskPayScoreRewardState == ERegressRewardState.Reached)
			{
				list.Add(id);
			}
		}
		if (list.Count > 0)
		{
			this.RequestClaimScoreReward(list);
		}
	}

	// Token: 0x060096AC RID: 38572 RVA: 0x00276B40 File Offset: 0x00274D40
	public unsafe bool JumpByQuestConfig(RegressQuest config)
	{
		ERegressTaskType taskType = (ERegressTaskType)config.TaskType;
		if (taskType == ERegressTaskType.Constant || taskType == ERegressTaskType.Once)
		{
			ERegressConstantTaskSubType taskSubType = (ERegressConstantTaskSubType)config.TaskSubType;
			if (taskSubType == ERegressConstantTaskSubType.MainQuestAndRole)
			{
				int? firstUnFinishMainQuestId = ModelBase<ActivityRegressModel>.Instance.GetFirstUnFinishMainQuestId();
				global::RoleQuest firstShowRoleQuest = ModelBase<ActivityRegressModel>.Instance.GetFirstShowRoleQuest();
				if (firstUnFinishMainQuestId != null)
				{
					return this.JumpToMainlineQuest(config);
				}
				if (firstShowRoleQuest != null)
				{
					return this.JumpToRoleQuest(config);
				}
				return this.JumpToMainlineQuest(config);
			}
			else
			{
				if (taskSubType == ERegressConstantTaskSubType.Explore)
				{
					return this.ExploreJump();
				}
				SkipTaskManager.RunByConfigId(config.AccessPathId, null);
				return true;
			}
		}
		else
		{
			if (taskType == ERegressTaskType.Daily)
			{
				ControllerBase<AdventureGuideController>.Instance.OpenGuideView(new EUiTabViewName?(EUiTabViewName.DailyActivityTabView), null, null);
				return true;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ActivityRegress;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "回流活动->JumpToQuestView 没有定义该类型的回流活动任务跳转！";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("taskType: ", taskType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("taskSubType: ", config.TaskSubType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("config: ", config);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
	}

	// Token: 0x060096AD RID: 38573 RVA: 0x00276C68 File Offset: 0x00274E68
	private bool JumpToMainlineQuest(RegressQuest config)
	{
		int? firstUnFinishMainQuestId = ModelBase<ActivityRegressModel>.Instance.GetFirstUnFinishMainQuestId();
		if (firstUnFinishMainQuestId == null)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RecallActivity_Tips_01", Array.Empty<object>());
			return false;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, firstUnFinishMainQuestId.Value, null);
		return true;
	}

	// Token: 0x060096AE RID: 38574 RVA: 0x00276CBC File Offset: 0x00274EBC
	private bool JumpToRoleQuest(RegressQuest config)
	{
		global::RoleQuest firstShowRoleQuest = ModelBase<ActivityRegressModel>.Instance.GetFirstShowRoleQuest();
		if (firstShowRoleQuest == null)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RecallActivity_Role_Precondition", Array.Empty<object>());
			return false;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, firstShowRoleQuest.Id, null);
		return true;
	}

	// Token: 0x060096AF RID: 38575 RVA: 0x00276D0C File Offset: 0x00274F0C
	public bool ExploreJump()
	{
		ExploreAreaData firstUnlockArea = this.GetFirstUnlockArea();
		if (firstUnlockArea == null)
		{
			return false;
		}
		Aki.Config.Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(firstUnlockArea.AreaId);
		if (areaInfo == null)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RecallActivity_Tips_01", Array.Empty<object>());
			return false;
		}
		Aki.Config.Area value = areaInfo.Value;
		WorldMapViewOpenParams data = new WorldMapViewOpenParams
		{
			MarkId = new int?(value.DeliveryMarkId),
			MarkType = (EMarkType)value.DeliveryMarkType,
			StartScale = new float?(ModelBase<WorldMapModel>.Instance.MapScaleMin),
			OpenFogId = new int?(0)
		};
		ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
		return true;
	}

	// Token: 0x060096B0 RID: 38576 RVA: 0x00276DB4 File Offset: 0x00274FB4
	[NullableContext(2)]
	public unsafe ExploreAreaData GetFirstUnlockArea()
	{
		Dictionary<int, bool> allUnlockedAreas = ModelBase<MapModel>.Instance.GetAllUnlockedAreas();
		if (allUnlockedAreas == null || allUnlockedAreas.Count <= 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RecallActivity_Tips_01", Array.Empty<object>());
			return null;
		}
		List<ExploreAreaData> list = new List<ExploreAreaData>();
		foreach (KeyValuePair<int, bool> keyValuePair in allUnlockedAreas)
		{
			int key = keyValuePair.Key;
			ExploreAreaData exploreAreaData = ModelBase<ExploreProgressModel>.Instance.GetExploreAreaData(key);
			if (exploreAreaData != null)
			{
				list.Add(exploreAreaData);
			}
		}
		list.Sort((ExploreAreaData a, ExploreAreaData b) => a.GetProgress() - b.GetProgress());
		if (list.Count <= 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RecallActivity_Tips_01", Array.Empty<object>());
			Singleton<Log>.Instance.Warn(ELogModule.ActivityRegress, ELogAuthor.LRX, "[回流活动]ActivityRegress->RecallDailyExploreTaskJump 探索任务跳转失败，当前没有探索度数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		foreach (ExploreAreaData exploreAreaData2 in list)
		{
			int areaId = exploreAreaData2.AreaId;
			Aki.Config.Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaId);
			if (areaInfo == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.ActivityRegress;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "[回流活动]ActivityRegress->RecallDailyExploreTaskJump 探索任务跳转缺少area配置, 请检查q.区域表";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("areaId: ", areaId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				Aki.Config.Area value = areaInfo.Value;
				if (value.DeliveryMarkId != 0)
				{
					return exploreAreaData2;
				}
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RecallActivity_Tips_01", Array.Empty<object>());
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.ActivityRegress;
				ELogAuthor author2 = ELogAuthor.LRX;
				string message2 = "[回流活动]ActivityRegress-> 探索任务跳转缺少DeliveryMarkId配置, 请检查q.区域表,并联系技术策划对齐";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("areaId: ", areaId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DeliveryMarkId: ", value.DeliveryMarkId);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		return null;
	}

	// Token: 0x060096B1 RID: 38577 RVA: 0x00276FFC File Offset: 0x002751FC
	public void RegressDisposableRewardRequest()
	{
		RegressDisposableRewardRequest message = Aki.Protocol.RegressDisposableRewardRequest.Create();
		Singleton<Net>.Instance.Call<RegressDisposableRewardResponse>(ERequestMessageId.RegressDisposableRewardRequest, message, new Action<RegressDisposableRewardResponse, Net.CallbackStatus>(ActivityRegressController.<RegressDisposableRewardRequest>g__Response|39_0), 0);
	}

	// Token: 0x060096B2 RID: 38578 RVA: 0x0027702C File Offset: 0x0027522C
	public bool IsNeedExtraRewardView()
	{
		return ModelBase<ActivityRegressModel>.Instance.NeedShowExtraRewardView;
	}

	// Token: 0x060096B3 RID: 38579 RVA: 0x00277038 File Offset: 0x00275238
	public RewardData<IBattlePassExtraRewardInfo> BuildExtraRewardData(List<RewardItemData> rewardItemDataList)
	{
		List<RewardItemData> list = new List<RewardItemData>();
		ERegressGrade grade = ModelBase<ActivityRegressModel>.Instance.Grade;
		IReadOnlyList<RegressBonusReward> readOnlyList = ConfigBase<ActivityRegressConfig>.Instance.GetRegressBonusRewardConfigList(grade) ?? Array.Empty<RegressBonusReward>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		int regressTaskScore = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetRegressTaskScore();
		for (int i = 0; i < readOnlyList.Count; i++)
		{
			RegressBonusReward config = readOnlyList[i];
			if (regressTaskScore >= config.NeedScore && ModelBase<ActivityRegressModel>.Instance.ActivityData.GetRegressTaskPayScoreRewardState(config) != ERegressRewardState.Claim)
			{
				int payDrop = config.PayDrop;
				if (payDrop > 0)
				{
					DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(payDrop);
					if (dropPackage != null)
					{
						foreach (KeyValuePair<int, int> keyValuePair in dropPackage.Value.DropPreview())
						{
							int key = keyValuePair.Key;
							int value = keyValuePair.Value;
							if (dictionary.ContainsKey(key))
							{
								dictionary[key] += value;
							}
							else
							{
								dictionary[key] = value;
							}
						}
					}
				}
			}
		}
		foreach (KeyValuePair<int, int> keyValuePair2 in dictionary)
		{
			int key2 = keyValuePair2.Key;
			int value2 = keyValuePair2.Value;
			list.Add(new RewardItemData(key2, value2, null, EDropItemType.Normal));
		}
		list.Sort(delegate(RewardItemData a, RewardItemData b)
		{
			int qualityId = a.GetQualityId();
			int qualityId2 = b.GetQualityId();
			if (qualityId == qualityId2)
			{
				return a.Count - b.Count;
			}
			return qualityId2 - qualityId;
		});
		BattlePassExtraRewardInfo battlePassExtraRewardInfo = new BattlePassExtraRewardInfo();
		battlePassExtraRewardInfo.Type = ERewardInfoType.BattlePassExtra;
		battlePassExtraRewardInfo.ViewName = EUiViewName.BattlePassExtraRewardView;
		battlePassExtraRewardInfo.CommonItems = rewardItemDataList;
		battlePassExtraRewardInfo.ExtraItems = list;
		battlePassExtraRewardInfo.TipsTextId = "Regress_BattlePass_Purchase_Tips";
		battlePassExtraRewardInfo.LeftAction = delegate()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RegressBpPayView, null, null);
		};
		battlePassExtraRewardInfo.RightAction = delegate()
		{
		};
		return new RewardData<IBattlePassExtraRewardInfo>(battlePassExtraRewardInfo, null);
	}

	// Token: 0x060096B4 RID: 38580 RVA: 0x00277284 File Offset: 0x00275484
	public void RequestBuyBattlePassLevel(int level)
	{
		RegressBuyBonusLvRequest regressBuyBonusLvRequest = RegressBuyBonusLvRequest.Create();
		regressBuyBonusLvRequest.BuyLv = level;
		Singleton<Net>.Instance.Call<RegressBuyBonusLvResponse>(ERequestMessageId.RegressBuyBonusLvRequest, regressBuyBonusLvRequest, delegate(RegressBuyBonusLvResponse _, Net.CallbackStatus __)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
		}, 0);
	}

	// Token: 0x060096B5 RID: 38581 RVA: 0x002772CE File Offset: 0x002754CE
	private void OnPayItemSuccess(PayItemSuccess notify)
	{
		if (notify.PayItemId == 46)
		{
			ModelBase<ActivityRegressModel>.Instance.ActivityData.SetPayRewardUnlock(true);
			Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RegressBpLevelUpTipsView, null, null);
		}
	}

	// Token: 0x060096B6 RID: 38582 RVA: 0x0027730C File Offset: 0x0027550C
	public static void OpenGameIntroductionByRoleId(int roleId)
	{
		string text = ModelBase<ChannelModel>.Instance.GameIntroductionUrl;
		if (text == "")
		{
			if (ControllerBase<KuroSdkController>.Instance.GetIfGlobalSdk())
			{
				text = ConfigBase<CommonConfig>.Instance.GetGameIntroductionGlobalUrl();
			}
			else
			{
				text = ConfigBase<CommonConfig>.Instance.GetGameIntroductionUrl();
			}
		}
		string externalUrl = Singleton<PublicUtil>.Instance.GetExternalUrl(text, PublicUtil.EExternalUrlReason.GameIntroduction);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
		defaultInterpolatedStringHandler.AppendLiteral("&role_id=");
		defaultInterpolatedStringHandler.AppendFormatted<int>(roleId);
		string url = externalUrl + defaultInterpolatedStringHandler.ToStringAndClear();
		GameInformationClickLogEvent logData = new GameInformationClickLogEvent();
		ControllerBase<LogReportController>.Instance.LogReport(logData);
		ControllerBase<KuroSdkController>.Instance.OpenWebView("", url, true, true, true, "Default");
	}

	// Token: 0x060096B7 RID: 38583 RVA: 0x002773B8 File Offset: 0x002755B8
	public void OpenTrialRoleView(int? selectedGroupId = null)
	{
		NewPlayerSupportTrialRoleViewModel newPlayerSupportTrialRoleViewModel = new NewPlayerSupportTrialRoleViewModel(ETrialRoleType.ReturnSupportTrial, ConfigCommonParamById.GetStringConfig("NewPlayerSupportTrialRoleIcon"), ConfigCommonParamById.GetStringConfig("NewPlayerSupportTrialRoleTitle"), 465, selectedGroupId);
		newPlayerSupportTrialRoleViewModel.SetRequestTrialRoleLvUpFunc(new Action<int>(this.RegressTrialRoleLvUpRequest));
		newPlayerSupportTrialRoleViewModel.SetRequestSetCurUseTrialRoleFunc(new Action<int, Action<int>>(this.RegressSetCurUseTrialRoleRequest));
		Dictionary<int, string> trialRoleUnlockDesc = ConfigBase<ActivityRegressConfig>.Instance.GetTrialRoleUnlockDesc();
		newPlayerSupportTrialRoleViewModel.SetTrialRoleGroupUnlockDesc(trialRoleUnlockDesc);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityNewPlayerSupportTrialRoleView, newPlayerSupportTrialRoleViewModel, null);
	}

	// Token: 0x060096B8 RID: 38584 RVA: 0x00277430 File Offset: 0x00275630
	public static void RegressStartJumpToActivity(Action callback)
	{
		bool flag = Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityRegressNewVersionMainView);
		Singleton<UiManager>.Instance.CloseView(flag ? EUiViewName.ActivityRegressNewVersionMainView : EUiViewName.ActivityRegressMainView, delegate(bool _)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.AdventureGuideView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.AdventureGuideView, null);
			}
			callback();
		});
	}

	// Token: 0x060096BA RID: 38586 RVA: 0x00277492 File Offset: 0x00275692
	[NullableContext(2)]
	[CompilerGenerated]
	internal static void <RegressTaskRewardRequest>g__Response|17_0(RegressTaskResponse response, Net.CallbackStatus _)
	{
		if (response == null)
		{
			return;
		}
		if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
		{
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RegressTaskResponse, null, true, true);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
	}

	// Token: 0x060096BB RID: 38587 RVA: 0x002774C8 File Offset: 0x002756C8
	[NullableContext(2)]
	[CompilerGenerated]
	internal static void <RequestClaimAllTaskReward>g__Response|18_0(RegressRepeatedTaskResponse response, Net.CallbackStatus _)
	{
		if (response == null)
		{
			return;
		}
		if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
		{
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RegressRepeatedTaskResponse, null, true, true);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
	}

	// Token: 0x060096BD RID: 38589 RVA: 0x0027753C File Offset: 0x0027573C
	[NullableContext(2)]
	[CompilerGenerated]
	internal static void <RegressDisposableRewardRequest>g__Response|39_0(RegressDisposableRewardResponse response, Net.CallbackStatus _)
	{
		if (response == null)
		{
			return;
		}
		if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
		{
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.RegressDisposableRewardResponse, null, true, true);
			return;
		}
		ModelBase<ActivityRegressModel>.Instance.ActivityData.DisposableReward = true;
		Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
	}

	// Token: 0x040045B0 RID: 17840
	private const int BP_REMINDER_INTERVAL = 5;

	// Token: 0x040045B1 RID: 17841
	private readonly Dictionary<ERecallStartCondition, bool> ActivityStartConditionMap = new Dictionary<ERecallStartCondition, bool>();
}
