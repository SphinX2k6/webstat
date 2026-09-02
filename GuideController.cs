using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Guide.GroupInfo;
using CSharpScript.Game.LevelGamePlay.LevelConditions;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001E20 RID: 7712
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class GuideController : UiControllerBase<GuideController>
{
	// Token: 0x0600E3A3 RID: 58275 RVA: 0x003D4524 File Offset: 0x003D2724
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<GuideCondDoneNotify>(ENotifyMessageId.GuideCondDoneNotify, new Action<GuideCondDoneNotify, Net.CallbackStatus>(this.OnGuideGroupOpenByServer));
	}

	// Token: 0x0600E3A4 RID: 58276 RVA: 0x003D4542 File Offset: 0x003D2742
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.GuideCondDoneNotify);
	}

	// Token: 0x0600E3A5 RID: 58277 RVA: 0x003D4554 File Offset: 0x003D2754
	private void OnGuideGroupOpenByServer(GuideCondDoneNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		if (notify == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Guide, ELogAuthor.TL, "服务端发来的GuideTriggerNotify为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int groupId = notify.GroupId;
		this.TryStartGuide(groupId);
	}

	// Token: 0x0600E3A6 RID: 58278 RVA: 0x003D4590 File Offset: 0x003D2790
	private void OnAutoOpenConditionPass([Nullable(new byte[]
	{
		2,
		1
	})] object[] param)
	{
		if (!this.TryStartGuide((int)param[0]))
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnGuideTriggerResetEvent);
		}
	}

	// Token: 0x0600E3A7 RID: 58279 RVA: 0x003D45B4 File Offset: 0x003D27B4
	private void RegisterEventsForAllAutoOpenConditions()
	{
		foreach (GuideGroup guideGroup in ConfigBase<GuideConfig>.Instance.GetAllGroup())
		{
			int autoOpenCondition = guideGroup.AutoOpenCondition;
			if (autoOpenCondition != 0)
			{
				int id = guideGroup.Id;
				if (ModelBase<GuideModel>.Instance.CanGroupInvoke(id) && !this.AutoOpenConditionCallBackMap.ContainsKey(id))
				{
					ConditionPassCallback conditionPassCallback = new ConditionPassCallback(new TConditionPassCallback(this.OnAutoOpenConditionPass), new object[]
					{
						id
					});
					Singleton<LevelConditionRegistry>.Instance.RegisterConditionGroup(autoOpenCondition, conditionPassCallback);
					this.AutoOpenConditionCallBackMap.Add(id, conditionPassCallback);
				}
			}
		}
	}

	// Token: 0x0600E3A8 RID: 58280 RVA: 0x003D466C File Offset: 0x003D286C
	private void UnRegisterEventsForAllAutoOpenConditions()
	{
		foreach (GuideGroup guideGroup in ConfigBase<GuideConfig>.Instance.GetAllGroup())
		{
			int autoOpenCondition = guideGroup.AutoOpenCondition;
			if (autoOpenCondition != 0)
			{
				int id = guideGroup.Id;
				ConditionPassCallback conditionPassCallback;
				if (this.AutoOpenConditionCallBackMap.TryGetValue(id, out conditionPassCallback))
				{
					Singleton<LevelConditionRegistry>.Instance.UnRegisterConditionGroup(autoOpenCondition, conditionPassCallback);
					this.AutoOpenConditionCallBackMap.Remove(id);
				}
			}
		}
	}

	// Token: 0x0600E3A9 RID: 58281 RVA: 0x003D46F4 File Offset: 0x003D28F4
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.GuideGroupOpening, new Action<int, bool>(this.OnGuideGroupOpening));
		Singleton<EventSystem>.Instance.Add(EEventName.EnterGameSuccess, new Action(this.OnEnterGameSuccess));
		Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.WorldDone;
		Action handle;
		if ((handle = GuideController.<>O.<0>__OnWorldDone) == null)
		{
			handle = (GuideController.<>O.<0>__OnWorldDone = new Action(GuideController.OnWorldDone));
		}
		instance.Add(name, handle);
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		EventSystem instance2 = Singleton<EventSystem>.Instance;
		EEventName name2 = EEventName.ActiveBattleView;
		Action handle2;
		if ((handle2 = GuideController.<>O.<1>__OnActiveBattleView) == null)
		{
			handle2 = (GuideController.<>O.<1>__OnActiveBattleView = new Action(GuideController.OnActiveBattleView));
		}
		instance2.Add(name2, handle2);
		EventSystem instance3 = Singleton<EventSystem>.Instance;
		EEventName name3 = EEventName.OnBlackFadeScreenFinish;
		Action handle3;
		if ((handle3 = GuideController.<>O.<2>__OnBlackFadeScreenFinish) == null)
		{
			handle3 = (GuideController.<>O.<2>__OnBlackFadeScreenFinish = new Action(GuideController.OnBlackFadeScreenFinish));
		}
		instance3.Add(name3, handle3);
		EventSystem instance4 = Singleton<EventSystem>.Instance;
		EEventName name4 = EEventName.BattleSettlementStateChanged;
		Action<bool> handle4;
		if ((handle4 = GuideController.<>O.<3>__OnGuideTutorialEnabled) == null)
		{
			handle4 = (GuideController.<>O.<3>__OnGuideTutorialEnabled = new Action<bool>(GuideController.OnGuideTutorialEnabled));
		}
		instance4.Add<bool>(name4, handle4);
		Singleton<EventSystem>.Instance.Add<bool, string>(EEventName.OnCameraSequenceSetUiVisible, new Action<bool, string>(this.OnCameraSequenceSetUiVisible));
		EventSystem instance5 = Singleton<EventSystem>.Instance;
		EEventName name5 = EEventName.OnGuideTriggerEvent;
		Action<string> handle5;
		if ((handle5 = GuideController.<>O.<4>__LogGuideTriggerEvent) == null)
		{
			handle5 = (GuideController.<>O.<4>__LogGuideTriggerEvent = new Action<string>(GuideController.LogGuideTriggerEvent));
		}
		instance5.Add<string>(name5, handle5);
		EventSystem instance6 = Singleton<EventSystem>.Instance;
		EEventName name6 = EEventName.NotifyGuideBreakFocus;
		Action handle6;
		if ((handle6 = GuideController.<>O.<5>__OnNotifyGuideBreakFocus) == null)
		{
			handle6 = (GuideController.<>O.<5>__OnNotifyGuideBreakFocus = new Action(GuideController.OnNotifyGuideBreakFocus));
		}
		instance6.Add(name6, handle6);
	}

	// Token: 0x0600E3AA RID: 58282 RVA: 0x003D488C File Offset: 0x003D2A8C
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GuideGroupOpening, new Action<int, bool>(this.OnGuideGroupOpening));
		Singleton<EventSystem>.Instance.Remove(EEventName.EnterGameSuccess, new Action(this.OnEnterGameSuccess));
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.WorldDone;
		Action handle;
		if ((handle = GuideController.<>O.<0>__OnWorldDone) == null)
		{
			handle = (GuideController.<>O.<0>__OnWorldDone = new Action(GuideController.OnWorldDone));
		}
		instance.Remove(name, handle);
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		EventSystem instance2 = Singleton<EventSystem>.Instance;
		EEventName name2 = EEventName.ActiveBattleView;
		Action handle2;
		if ((handle2 = GuideController.<>O.<1>__OnActiveBattleView) == null)
		{
			handle2 = (GuideController.<>O.<1>__OnActiveBattleView = new Action(GuideController.OnActiveBattleView));
		}
		instance2.Remove(name2, handle2);
		EventSystem instance3 = Singleton<EventSystem>.Instance;
		EEventName name3 = EEventName.OnBlackFadeScreenFinish;
		Action handle3;
		if ((handle3 = GuideController.<>O.<2>__OnBlackFadeScreenFinish) == null)
		{
			handle3 = (GuideController.<>O.<2>__OnBlackFadeScreenFinish = new Action(GuideController.OnBlackFadeScreenFinish));
		}
		instance3.Remove(name3, handle3);
		EventSystem instance4 = Singleton<EventSystem>.Instance;
		EEventName name4 = EEventName.BattleSettlementStateChanged;
		Action<bool> handle4;
		if ((handle4 = GuideController.<>O.<3>__OnGuideTutorialEnabled) == null)
		{
			handle4 = (GuideController.<>O.<3>__OnGuideTutorialEnabled = new Action<bool>(GuideController.OnGuideTutorialEnabled));
		}
		instance4.Remove(name4, handle4);
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCameraSequenceSetUiVisible, new Action<bool, string>(this.OnCameraSequenceSetUiVisible));
		EventSystem instance5 = Singleton<EventSystem>.Instance;
		EEventName name5 = EEventName.OnGuideTriggerEvent;
		Action<string> handle5;
		if ((handle5 = GuideController.<>O.<4>__LogGuideTriggerEvent) == null)
		{
			handle5 = (GuideController.<>O.<4>__LogGuideTriggerEvent = new Action<string>(GuideController.LogGuideTriggerEvent));
		}
		instance5.Remove(name5, handle5);
		EventSystem instance6 = Singleton<EventSystem>.Instance;
		EEventName name6 = EEventName.NotifyGuideBreakFocus;
		Action handle6;
		if ((handle6 = GuideController.<>O.<5>__OnNotifyGuideBreakFocus) == null)
		{
			handle6 = (GuideController.<>O.<5>__OnNotifyGuideBreakFocus = new Action(GuideController.OnNotifyGuideBreakFocus));
		}
		instance6.Remove(name6, handle6);
		this.UnRegisterEventsForAllAutoOpenConditions();
	}

	// Token: 0x0600E3AB RID: 58283 RVA: 0x003D4A2C File Offset: 0x003D2C2C
	protected override void OnAddOpenViewCheckFunction()
	{
		UiManager instance = Singleton<UiManager>.Instance;
		EUiViewName guideTutorialView = EUiViewName.GuideTutorialView;
		Func<EUiViewName, object, bool> func;
		if ((func = GuideController.<>O.<6>__CanOpenTutorial) == null)
		{
			func = (GuideController.<>O.<6>__CanOpenTutorial = new Func<EUiViewName, object, bool>(GuideController.CanOpenTutorial));
		}
		instance.AddOpenViewCheckFunction(guideTutorialView, func, "GuideController.CanOpenTutorial");
		UiManager instance2 = Singleton<UiManager>.Instance;
		EUiViewName guideTutorialPopView = EUiViewName.GuideTutorialPopView;
		Func<EUiViewName, object, bool> func2;
		if ((func2 = GuideController.<>O.<6>__CanOpenTutorial) == null)
		{
			func2 = (GuideController.<>O.<6>__CanOpenTutorial = new Func<EUiViewName, object, bool>(GuideController.CanOpenTutorial));
		}
		instance2.AddOpenViewCheckFunction(guideTutorialPopView, func2, "GuideController.CanOpenTutorial");
	}

	// Token: 0x0600E3AC RID: 58284 RVA: 0x003D4A97 File Offset: 0x003D2C97
	private static void LogGuideTriggerEvent(string name)
	{
	}

	// Token: 0x0600E3AD RID: 58285 RVA: 0x003D4A99 File Offset: 0x003D2C99
	private static bool CanOpenTutorial(EUiViewName viewName, object param)
	{
		return !ModelBase<BattleUiModel>.Instance.IsInBattleSettlement;
	}

	// Token: 0x0600E3AE RID: 58286 RVA: 0x003D4AA8 File Offset: 0x003D2CA8
	public void InvokeGuideGroupByGm(int groupId, bool isfake)
	{
		ModelBase<GuideModel>.Instance.IsGmInvoke = true;
		GuideGroupInfo guideGroupInfo = ModelBase<GuideModel>.Instance.TryGetGuideGroup(groupId);
		ModelBase<GuideModel>.Instance.IsGmInvoke = false;
		if (guideGroupInfo == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.TL;
			string message = "引导组  数据创建失败！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("groupId", groupId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		guideGroupInfo.IsFake = isfake;
		if (!isfake)
		{
			this.TryStartGuide(groupId);
			return;
		}
		EGuideGroupState? currentState = guideGroupInfo.StateMachine.CurrentState;
		EGuideGroupState eguideGroupState = EGuideGroupState.Init;
		if (!(currentState.GetValueOrDefault() == eguideGroupState & currentState != null))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Guide;
			ELogAuthor author2 = ELogAuthor.TL;
			string message2 = "(GM)引导组  正在执行中, 不再重复执行";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("group.Id", guideGroupInfo.Id);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		guideGroupInfo.SwitchState(EGuideGroupState.Executing);
	}

	// Token: 0x0600E3AF RID: 58287 RVA: 0x003D4B78 File Offset: 0x003D2D78
	private void OnGuideGroupOpening(int groupId, bool isPreExecute)
	{
		GuideTriggerRequest guideTriggerRequest = GuideTriggerRequest.Create();
		guideTriggerRequest.GroupId = groupId;
		Singleton<Net>.Instance.Call<GuideTriggerResponse>(ERequestMessageId.GuideTriggerRequest, guideTriggerRequest, delegate(GuideTriggerResponse response, Net.CallbackStatus _)
		{
			if (response == null || response.ErrorCode > Aki.Protocol.ErrorCode.Success)
			{
				ModelBase<GuideModel>.Instance.SwitchGroupState(groupId, EGuideGroupState.Init);
				if (response != null)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29786, response.ErrorParams, true, true);
				}
				return;
			}
			if (isPreExecute)
			{
				return;
			}
			ModelBase<GuideModel>.Instance.SwitchGroupState(groupId, EGuideGroupState.Executing);
		}, 0);
	}

	// Token: 0x0600E3B0 RID: 58288 RVA: 0x003D4BC8 File Offset: 0x003D2DC8
	public unsafe void FinishGuide(int groupId, bool isFake = false)
	{
		if (isFake)
		{
			this.OnGuideFinished(groupId);
			return;
		}
		GuideFinishRequest guideFinishRequest = GuideFinishRequest.Create();
		guideFinishRequest.GroupId = groupId;
		Singleton<Net>.Instance.Call<GuideFinishResponse>(ERequestMessageId.GuideFinishRequest, guideFinishRequest, delegate(GuideFinishResponse response, Net.CallbackStatus _)
		{
			if (response == null || response.ErrorCode > Aki.Protocol.ErrorCode.Success)
			{
				Aki.Protocol.ErrorCode? errorCode = (response != null) ? new Aki.Protocol.ErrorCode?(response.ErrorCode) : null;
				bool flag = response == null;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.TL;
				string message = "引导请求服务端完成失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("组Id", groupId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("errorCode", errorCode);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("responseNull", flag);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			this.OnGuideFinished(groupId);
		}, 0);
	}

	// Token: 0x0600E3B1 RID: 58289 RVA: 0x003D4C28 File Offset: 0x003D2E28
	private static void OnNotifyGuideBreakFocus()
	{
		ModelBase<GuideModel>.Instance.BreakTypeViewStep(EGuideViewType.GuideFocus);
	}

	// Token: 0x0600E3B2 RID: 58290 RVA: 0x003D4C35 File Offset: 0x003D2E35
	private static void OnActiveBattleView()
	{
		ModelBase<GuideModel>.Instance.ShowFailedOpenTutorialView();
	}

	// Token: 0x0600E3B3 RID: 58291 RVA: 0x003D4C41 File Offset: 0x003D2E41
	private static void OnBlackFadeScreenFinish()
	{
		ModelBase<GuideModel>.Instance.ShowFailedOpenTutorialView();
	}

	// Token: 0x0600E3B4 RID: 58292 RVA: 0x003D4C4D File Offset: 0x003D2E4D
	private static void OnGuideTutorialEnabled(bool state)
	{
		ModelBase<GuideModel>.Instance.ShowFailedOpenTutorialView();
	}

	// Token: 0x0600E3B5 RID: 58293 RVA: 0x003D4C59 File Offset: 0x003D2E59
	private static void OnWorldDone()
	{
		ModelBase<GuideModel>.Instance.EnsureCurrentDungeonId();
	}

	// Token: 0x0600E3B6 RID: 58294 RVA: 0x003D4C68 File Offset: 0x003D2E68
	private void OnWorldDoneAndCloseLoading()
	{
		Dictionary<int, GuideGroupInfo> currentGroupMap = ModelBase<GuideModel>.Instance.CurrentGroupMap;
		if (currentGroupMap != null)
		{
			foreach (int num in this.OnWorldDoneGuideKillList)
			{
				GuideGroupInfo guideGroupInfo;
				if (currentGroupMap.TryGetValue(num, out guideGroupInfo))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Guide;
					ELogAuthor author = ELogAuthor.TL;
					string message = "引导组在场景加载完成（包括客户端加载和服务器交互确认）前被触发，强制终止引导";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("GuideGroupId", num);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					guideGroupInfo.Break();
					currentGroupMap.Remove(num);
				}
			}
		}
	}

	// Token: 0x0600E3B7 RID: 58295 RVA: 0x003D4CE6 File Offset: 0x003D2EE6
	public void GmCleanGuideData()
	{
		ModelBase<GuideModel>.Instance.GmResetAllGuideGroup();
		this.UnRegisterEventsForAllAutoOpenConditions();
		this.RegisterEventsForAllAutoOpenConditions();
	}

	// Token: 0x0600E3B8 RID: 58296 RVA: 0x003D4CFE File Offset: 0x003D2EFE
	public void OnGmCleanGuideGroupDataByGroupId(int groupId)
	{
		this.ResetFinishedGuide(groupId);
	}

	// Token: 0x0600E3B9 RID: 58297 RVA: 0x003D4D08 File Offset: 0x003D2F08
	private void OnEnterGameSuccess()
	{
		GuideInfoRequest message = GuideInfoRequest.Create();
		Singleton<Net>.Instance.Call<GuideInfoResponse>(ERequestMessageId.GuideInfoRequest, message, delegate(GuideInfoResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Guide, ELogAuthor.TL, "服务端发来的GuideInfoNotify为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			foreach (int groupId in response.GuideGroupFinishList)
			{
				ModelBase<GuideModel>.Instance.FinishGroup(groupId);
			}
			this.RegisterEventsForAllAutoOpenConditions();
		}, 0);
	}

	// Token: 0x0600E3BA RID: 58298 RVA: 0x003D4D38 File Offset: 0x003D2F38
	private void InputControllerChange(EInputControllerType last, EInputControllerType now)
	{
		ModelBase<GuideModel>.Instance.ClearAllGroup();
	}

	// Token: 0x0600E3BB RID: 58299 RVA: 0x003D4D44 File Offset: 0x003D2F44
	private void OnCameraSequenceSetUiVisible(bool isVisible, string cameraName)
	{
		if (cameraName != "MainCamera")
		{
			return;
		}
		ModelBase<GuideModel>.Instance.ShouldBlockGuideBecauseUiNotRender = !isVisible;
	}

	// Token: 0x0600E3BC RID: 58300 RVA: 0x003D4D64 File Offset: 0x003D2F64
	public bool TryStartGuide(int guideId)
	{
		GuideGroupInfo guideGroupInfo = ModelBase<GuideModel>.Instance.TryGetGuideGroup(guideId);
		if (guideGroupInfo == null)
		{
			return false;
		}
		guideGroupInfo.SwitchState(EGuideGroupState.Opening);
		return true;
	}

	// Token: 0x0600E3BD RID: 58301 RVA: 0x003D4D8C File Offset: 0x003D2F8C
	public bool TryFinishGuide(int guideId)
	{
		if (ModelBase<GuideModel>.Instance.IsGroupFinished(guideId).Value)
		{
			return false;
		}
		this.FinishGuide(guideId, false);
		return true;
	}

	// Token: 0x0600E3BE RID: 58302 RVA: 0x003D4DBC File Offset: 0x003D2FBC
	public void TryFinishRunningGuides()
	{
		foreach (int guideId in ModelBase<GuideModel>.Instance.GetRunningGroupIdList())
		{
			this.TryFinishGuide(guideId);
		}
	}

	// Token: 0x0600E3BF RID: 58303 RVA: 0x003D4DF0 File Offset: 0x003D2FF0
	public void FinishGuideGm(int groupId)
	{
		if (!ModelBase<GuideModel>.Instance.CheckGuideInfoExist(groupId))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.TL;
			string message = "引导GM命令请求完成时错误, 当前引导数据不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("引导Id", groupId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.OnGuideFinished(groupId);
	}

	// Token: 0x0600E3C0 RID: 58304 RVA: 0x003D4E3E File Offset: 0x003D303E
	private void OnGuideFinished(int groupId)
	{
		ModelBase<GuideModel>.Instance.FinishGroup(groupId);
		this.UnRegisterEventsForAutoOpenCondition(groupId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.GuideGroupFinished, groupId);
	}

	// Token: 0x0600E3C1 RID: 58305 RVA: 0x003D4E64 File Offset: 0x003D3064
	public void ResetFinishedGuide(int groupId)
	{
		if (!ModelBase<GuideModel>.Instance.IsGroupFinished(groupId).Value)
		{
			return;
		}
		ModelBase<GuideModel>.Instance.ResetFinishedGuide(groupId);
		this.RegisterEventsForAutoOpenCondition(groupId);
	}

	// Token: 0x0600E3C2 RID: 58306 RVA: 0x003D4E9C File Offset: 0x003D309C
	private void RegisterEventsForAutoOpenCondition(int groupId)
	{
		if (this.AutoOpenConditionCallBackMap.ContainsKey(groupId))
		{
			return;
		}
		if (!ModelBase<GuideModel>.Instance.CanGroupInvoke(groupId))
		{
			return;
		}
		int autoOpenCondition = ConfigBase<GuideConfig>.Instance.GetGroup(groupId).Value.AutoOpenCondition;
		if (autoOpenCondition == 0)
		{
			return;
		}
		ConditionPassCallback conditionPassCallback = new ConditionPassCallback(new TConditionPassCallback(this.OnAutoOpenConditionPass), new object[]
		{
			groupId
		});
		Singleton<LevelConditionRegistry>.Instance.RegisterConditionGroup(autoOpenCondition, conditionPassCallback);
		this.AutoOpenConditionCallBackMap.Add(groupId, conditionPassCallback);
	}

	// Token: 0x0600E3C3 RID: 58307 RVA: 0x003D4F24 File Offset: 0x003D3124
	private void UnRegisterEventsForAutoOpenCondition(int groupId)
	{
		ConditionPassCallback conditionPassCallback;
		if (!this.AutoOpenConditionCallBackMap.TryGetValue(groupId, out conditionPassCallback))
		{
			return;
		}
		if (ModelBase<GuideModel>.Instance.CanGroupInvoke(groupId))
		{
			return;
		}
		int autoOpenCondition = ConfigBase<GuideConfig>.Instance.GetGroup(groupId).Value.AutoOpenCondition;
		if (autoOpenCondition == 0)
		{
			return;
		}
		Singleton<LevelConditionRegistry>.Instance.UnRegisterConditionGroup(autoOpenCondition, conditionPassCallback);
		this.AutoOpenConditionCallBackMap.Remove(groupId);
	}

	// Token: 0x0600E3C4 RID: 58308 RVA: 0x003D4F89 File Offset: 0x003D3189
	public bool CheckAvailableWhenOnline(EGuideOnlineMode modeInGuideCfg)
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			if (modeInGuideCfg != EGuideOnlineMode.OffOnly)
			{
				return true;
			}
		}
		else if (modeInGuideCfg != EGuideOnlineMode.OnOnly)
		{
			return true;
		}
		return false;
	}

	// Token: 0x0600E3C5 RID: 58309 RVA: 0x003D4FA4 File Offset: 0x003D31A4
	public bool CheckHasNewTagInHookNameForShow(GuideFocusNew config)
	{
		return config.HookNameForShow.Contains("New:") || (config.ExtraParam().Length != 0 && config.ExtraParam()[0].Contains("New:"));
	}

	// Token: 0x0600E3C6 RID: 58310 RVA: 0x003D4FDC File Offset: 0x003D31DC
	public UniTask WaitForCurrentTutorialFinish()
	{
		GuideController.<WaitForCurrentTutorialFinish>d__37 <WaitForCurrentTutorialFinish>d__;
		<WaitForCurrentTutorialFinish>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitForCurrentTutorialFinish>d__.<>1__state = -1;
		<WaitForCurrentTutorialFinish>d__.<>t__builder.Start<GuideController.<WaitForCurrentTutorialFinish>d__37>(ref <WaitForCurrentTutorialFinish>d__);
		return <WaitForCurrentTutorialFinish>d__.<>t__builder.Task;
	}

	// Token: 0x170011C6 RID: 4550
	// (get) Token: 0x0600E3C7 RID: 58311 RVA: 0x003D5017 File Offset: 0x003D3217
	// (set) Token: 0x0600E3C8 RID: 58312 RVA: 0x003D501F File Offset: 0x003D321F
	public bool GmEnableFocusTextPosTick
	{
		get
		{
			return this.GmEnableFocusTextPosTickInternal;
		}
		set
		{
			this.GmEnableFocusTextPosTickInternal = value;
		}
	}

	// Token: 0x04006D85 RID: 28037
	private readonly Dictionary<int, ConditionPassCallback> AutoOpenConditionCallBackMap = new Dictionary<int, ConditionPassCallback>();

	// Token: 0x04006D86 RID: 28038
	private readonly int[] OnWorldDoneGuideKillList = new int[]
	{
		20013
	};

	// Token: 0x04006D87 RID: 28039
	private bool GmEnableFocusTextPosTickInternal = true;

	// Token: 0x02008182 RID: 33154
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402BFB0 RID: 180144
		[Nullable(0)]
		public static Action <0>__OnWorldDone;

		// Token: 0x0402BFB1 RID: 180145
		[Nullable(0)]
		public static Action <1>__OnActiveBattleView;

		// Token: 0x0402BFB2 RID: 180146
		[Nullable(0)]
		public static Action <2>__OnBlackFadeScreenFinish;

		// Token: 0x0402BFB3 RID: 180147
		[Nullable(0)]
		public static Action<bool> <3>__OnGuideTutorialEnabled;

		// Token: 0x0402BFB4 RID: 180148
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Action<string> <4>__LogGuideTriggerEvent;

		// Token: 0x0402BFB5 RID: 180149
		[Nullable(0)]
		public static Action <5>__OnNotifyGuideBreakFocus;

		// Token: 0x0402BFB6 RID: 180150
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<EUiViewName, object, bool> <6>__CanOpenTutorial;
	}
}
