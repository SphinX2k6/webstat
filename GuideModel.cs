using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Guide.GroupInfo;
using CSharpScript.Game.Guide.StepInfo;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001E24 RID: 7716
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class GuideModel : ModelBase<GuideModel>
{
	// Token: 0x170011C7 RID: 4551
	// (get) Token: 0x0600E3DC RID: 58332 RVA: 0x003D526C File Offset: 0x003D346C
	public bool IsGuideLockingInput
	{
		get
		{
			return this.LockingInputGuideStepCount > 0;
		}
	}

	// Token: 0x0600E3DD RID: 58333 RVA: 0x003D5277 File Offset: 0x003D3477
	public void AddGuideLockInput()
	{
		this.LockingInputGuideStepCount++;
		if (this.LockingInputGuideStepCount == 1)
		{
			this.RefreshLockInput();
		}
	}

	// Token: 0x0600E3DE RID: 58334 RVA: 0x003D5296 File Offset: 0x003D3496
	public void RemoveGuideLockInput()
	{
		this.LockingInputGuideStepCount--;
		if (this.LockingInputGuideStepCount == 0)
		{
			this.RefreshLockInput();
		}
	}

	// Token: 0x0600E3DF RID: 58335 RVA: 0x003D52B4 File Offset: 0x003D34B4
	private void RefreshLockInput()
	{
		Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(this.IsGuideLockingInput, "Guide");
		InputDistributeModel instance = ModelBase<InputDistributeModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.RefreshInputDistributeTag();
	}

	// Token: 0x0600E3E0 RID: 58336 RVA: 0x003D52DC File Offset: 0x003D34DC
	protected override bool OnInit()
	{
		this.FinishedGroupIdSet = new HashSet<int>();
		this.DungeonResetIdList = new HashSet<int>();
		foreach (GuideGroup guideGroup in ConfigBase<GuideConfig>.Instance.GetAllGroup())
		{
			if (guideGroup.ResetInDungeon)
			{
				this.DungeonResetIdList.Add(guideGroup.Id);
			}
		}
		this.CurrentGroupMap = new Dictionary<int, GuideGroupInfo>();
		this.TypeViewSingletonMap = new Dictionary<EGuideViewType, GuideStepInfo>
		{
			{
				EGuideViewType.GuideFocus,
				null
			},
			{
				EGuideViewType.GuideTips,
				null
			}
		};
		this.FocusGroupMapByView = new Dictionary<EUiViewName, List<GuideGroupInfo>>();
		this.LockingInputGuideStepCount = 0;
		this.IsGmInvoke = false;
		return true;
	}

	// Token: 0x0600E3E1 RID: 58337 RVA: 0x003D5398 File Offset: 0x003D3598
	public bool CheckGuideInfoExist(int guideId)
	{
		return this.CurrentGroupMap.ContainsKey(guideId);
	}

	// Token: 0x0600E3E2 RID: 58338 RVA: 0x003D53A6 File Offset: 0x003D35A6
	public bool IsLocked()
	{
		return this.IsGmLock || this.IsLock;
	}

	// Token: 0x0600E3E3 RID: 58339 RVA: 0x003D53B8 File Offset: 0x003D35B8
	public void SetLock(bool value)
	{
		if (value == this.IsLock)
		{
			return;
		}
		if (value)
		{
			this.ClearAllGroup();
		}
		this.IsLock = value;
	}

	// Token: 0x0600E3E4 RID: 58340 RVA: 0x003D53D4 File Offset: 0x003D35D4
	public void SetGmLock(bool value)
	{
		if (value == this.IsGmLock)
		{
			return;
		}
		if (value)
		{
			this.ClearAllGroup();
		}
		this.IsGmLock = value;
	}

	// Token: 0x0600E3E5 RID: 58341 RVA: 0x003D53F0 File Offset: 0x003D35F0
	public void AddTutorialInfo(TutorialListInfo tutorialInfo)
	{
		if (this.TutorialList == null)
		{
			this.TutorialList = new List<TutorialListInfo>();
		}
		this.TutorialList.Add(tutorialInfo);
		if (this.TimeHandler == null)
		{
			this.TimeHandler = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.TutorialListCheckFunc), 20f, 1f, null, null, true);
		}
		this.TryShowTutorial();
	}

	// Token: 0x0600E3E6 RID: 58342 RVA: 0x003D5454 File Offset: 0x003D3654
	public void TryShowTutorial()
	{
		if (this.TutorialList.Count <= 0)
		{
			return;
		}
		TutorialListInfo tutorialListInfo = this.TutorialList[this.TutorialList.Count - 1];
		if (this.CurrentShowTutorial != null)
		{
			if (this.CurrentShowTutorial.TipState == ETutorialListType.Pop)
			{
				return;
			}
			if (!tutorialListInfo.TutorialTip || this.CurrentShowTutorial.TipState == ETutorialListType.Timing)
			{
				this.DoShowTutorial(tutorialListInfo);
				return;
			}
		}
		else
		{
			this.DoShowTutorial(tutorialListInfo);
		}
	}

	// Token: 0x0600E3E7 RID: 58343 RVA: 0x003D54C8 File Offset: 0x003D36C8
	private void DoShowTutorial(TutorialListInfo tutorialListInfo)
	{
		this.CurrentShowTutorial = tutorialListInfo;
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GuideTutorialTipsView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.GuideTutorialTipsView, null);
		}
		if (this.CurrentShowTutorial.TutorialTip)
		{
			this.TryResumeTimer();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.GuideTutorialTipsView, this.CurrentShowTutorial, null);
			return;
		}
		this.TryPauseTimer();
		this.TryShowGuideTutorialView(false);
	}

	// Token: 0x0600E3E8 RID: 58344 RVA: 0x003D5534 File Offset: 0x003D3734
	private UniTask ShowTutorialViewUponMultipleQueued()
	{
		GuideModel.<ShowTutorialViewUponMultipleQueued>d__27 <ShowTutorialViewUponMultipleQueued>d__;
		<ShowTutorialViewUponMultipleQueued>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ShowTutorialViewUponMultipleQueued>d__.<>4__this = this;
		<ShowTutorialViewUponMultipleQueued>d__.<>1__state = -1;
		<ShowTutorialViewUponMultipleQueued>d__.<>t__builder.Start<GuideModel.<ShowTutorialViewUponMultipleQueued>d__27>(ref <ShowTutorialViewUponMultipleQueued>d__);
		return <ShowTutorialViewUponMultipleQueued>d__.<>t__builder.Task;
	}

	// Token: 0x0600E3E9 RID: 58345 RVA: 0x003D5578 File Offset: 0x003D3778
	public void TryShowGuideTutorialView(bool isFromTips = false)
	{
		if (isFromTips && this.AreMultipleTutorialsQueued())
		{
			this.ShowTutorialViewUponMultipleQueued().Forget();
			return;
		}
		TutorialListInfo currentShowTutorial = this.CurrentShowTutorial;
		if (currentShowTutorial != null && currentShowTutorial.IsOverrideGuideTutorialView)
		{
			TutorialViewParam param = new TutorialViewParam
			{
				TutorialId = new int?(this.CurrentShowTutorial.GuideId)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TutorialView, param, delegate(bool success, int _)
			{
				this.GuideTutorialViewOpenFailed = (!success && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.TutorialView));
				UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TutorialView);
				if (viewByName != null)
				{
					((TutorialView)viewByName).IsOpenedByGuide = true;
				}
			});
			return;
		}
		GuideConfig instance = ConfigBase<GuideConfig>.Instance;
		TutorialListInfo currentShowTutorial2 = this.CurrentShowTutorial;
		GuideTutorial? guideTutorial = instance.GetGuideTutorial((currentShowTutorial2 != null) ? currentShowTutorial2.GuideId : 0);
		EUiViewName viewName = (guideTutorial == null || guideTutorial.GetValueOrDefault().ShowLayer == 0) ? EUiViewName.GuideTutorialView : EUiViewName.GuideTutorialPopView;
		Singleton<UiManager>.Instance.OpenView(viewName, this.CurrentShowTutorial, delegate(bool success, int _)
		{
			this.GuideTutorialViewOpenFailed = (!success && !Singleton<UiManager>.Instance.IsViewOpen(viewName));
		});
	}

	// Token: 0x0600E3EA RID: 58346 RVA: 0x003D5664 File Offset: 0x003D3864
	public void ShowFailedOpenTutorialView()
	{
		if (this.GuideTutorialViewOpenFailed)
		{
			this.TryShowGuideTutorialView(false);
		}
	}

	// Token: 0x0600E3EB RID: 58347 RVA: 0x003D5678 File Offset: 0x003D3878
	public void ClipTipState()
	{
		foreach (TutorialListInfo tutorialListInfo in this.TutorialList)
		{
			if (tutorialListInfo.TipState == ETutorialListType.Tip)
			{
				tutorialListInfo.TipState = ETutorialListType.Timing;
			}
		}
	}

	// Token: 0x0600E3EC RID: 58348 RVA: 0x003D56D4 File Offset: 0x003D38D4
	public void RemoveCurrentTutorialInfo()
	{
		int num = this.TutorialList.IndexOf(this.CurrentShowTutorial);
		this.CurrentShowTutorial = null;
		if (num >= 0)
		{
			this.TutorialList[num].StopGuide();
			this.TutorialList.RemoveAt(num);
			this.TryPauseTimer();
		}
	}

	// Token: 0x0600E3ED RID: 58349 RVA: 0x003D5721 File Offset: 0x003D3921
	public bool HaveCurrentTutorial()
	{
		return this.CurrentShowTutorial != null;
	}

	// Token: 0x0600E3EE RID: 58350 RVA: 0x003D572C File Offset: 0x003D392C
	public bool AreMultipleTutorialsQueued()
	{
		List<TutorialListInfo> tutorialList = this.TutorialList;
		return ((tutorialList != null) ? tutorialList.Count : 0) > 1;
	}

	// Token: 0x0600E3EF RID: 58351 RVA: 0x003D5744 File Offset: 0x003D3944
	public void TryPauseTimer()
	{
		if (this.TimeHandler != null && !this.TimeHandler.IsPause() && (this.TutorialList.Count == 0 || (this.CurrentShowTutorial != null && this.CurrentShowTutorial.TipState == ETutorialListType.Pop)))
		{
			TimerSystem.GameplayTimeInstance.Pause(this.TimeHandler, null);
		}
	}

	// Token: 0x0600E3F0 RID: 58352 RVA: 0x003D579C File Offset: 0x003D399C
	private void TryResumeTimer()
	{
		if (this.TimeHandler != null && this.TimeHandler.IsPause() && this.TutorialList.Count > 0 && (this.CurrentShowTutorial == null || this.CurrentShowTutorial.TipState != ETutorialListType.Pop))
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.TimeHandler))
			{
				TimerSystem.GameplayTimeInstance.Resume(this.TimeHandler);
				return;
			}
			this.TimeHandler = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.TutorialListCheckFunc), 20f, 1f, null, null, true);
		}
	}

	// Token: 0x0600E3F1 RID: 58353 RVA: 0x003D5830 File Offset: 0x003D3A30
	private void TutorialListCheckFunc(float delta)
	{
		for (int i = 0; i < this.TutorialList.Count; i++)
		{
			if (this.TutorialList[i].Tick(20f))
			{
				this.TutorialList.RemoveAt(i);
				this.TryPauseTimer();
				i--;
			}
		}
	}

	// Token: 0x0600E3F2 RID: 58354 RVA: 0x003D5884 File Offset: 0x003D3A84
	public void BreakTypeViewStep(EGuideViewType type)
	{
		GuideStepInfo guideStepInfo;
		if (this.TypeViewSingletonMap.TryGetValue(type, out guideStepInfo) && guideStepInfo != null)
		{
			guideStepInfo.SwitchState(EGuideStepState.Break);
		}
		this.TypeViewSingletonMap[type] = null;
	}

	// Token: 0x0600E3F3 RID: 58355 RVA: 0x003D58B8 File Offset: 0x003D3AB8
	public void OpenGuideView(GuideStepInfo stepInfo)
	{
		int contentType = stepInfo.Config.ContentType;
		this.TypeViewSingletonMap[(EGuideViewType)contentType] = stepInfo;
		if (contentType == 4)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.GuideFocusView, stepInfo, null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GuideTipsView, stepInfo, null);
	}

	// Token: 0x0600E3F4 RID: 58356 RVA: 0x003D5908 File Offset: 0x003D3B08
	public void RemoveStepViewSingletonMap(GuideStepInfo stepInfo)
	{
		int contentType = stepInfo.Config.ContentType;
		GuideStepInfo guideStepInfo;
		if (this.TypeViewSingletonMap.TryGetValue((EGuideViewType)contentType, out guideStepInfo) && guideStepInfo == stepInfo)
		{
			this.TypeViewSingletonMap[(EGuideViewType)contentType] = null;
		}
	}

	// Token: 0x0600E3F5 RID: 58357 RVA: 0x003D5948 File Offset: 0x003D3B48
	public void EnsureCurrentDungeonId()
	{
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		foreach (KeyValuePair<int, GuideGroupInfo> keyValuePair in this.CurrentGroupMap)
		{
			int key = keyValuePair.Key;
			GuideGroupInfo value = keyValuePair.Value;
			if (!this.CheckDungeonAvailable(key, instanceId, false))
			{
				value.Reset();
				this.CurrentGroupMap.Remove(key);
			}
		}
		foreach (int groupId in this.DungeonResetIdList)
		{
			if (this.CheckDungeonAvailable(groupId, instanceId, false))
			{
				ControllerBase<GuideController>.Instance.ResetFinishedGuide(groupId);
			}
		}
	}

	// Token: 0x0600E3F6 RID: 58358 RVA: 0x003D5A24 File Offset: 0x003D3C24
	public void GmResetAllGuideGroup()
	{
		this.FinishedGroupIdSet.Clear();
		this.ClearAllGroup();
	}

	// Token: 0x0600E3F7 RID: 58359 RVA: 0x003D5A38 File Offset: 0x003D3C38
	public void ClearAllGroup()
	{
		foreach (GuideGroupInfo guideGroupInfo in this.CurrentGroupMap.Values)
		{
			guideGroupInfo.Reset();
		}
		this.CurrentGroupMap.Clear();
	}

	// Token: 0x0600E3F8 RID: 58360 RVA: 0x003D5A98 File Offset: 0x003D3C98
	public void FinishGroup(int groupId)
	{
		GuideGroupInfo guideGroupInfo;
		if (this.CurrentGroupMap.TryGetValue(groupId, out guideGroupInfo))
		{
			guideGroupInfo.Reset();
			this.CurrentGroupMap.Remove(groupId);
		}
		this.FinishedGroupIdSet.Add(groupId);
	}

	// Token: 0x0600E3F9 RID: 58361 RVA: 0x003D5AD5 File Offset: 0x003D3CD5
	public void ResetFinishedGuide(int groupId)
	{
		this.FinishedGroupIdSet.Remove(groupId);
	}

	// Token: 0x0600E3FA RID: 58362 RVA: 0x003D5AE4 File Offset: 0x003D3CE4
	public bool? IsGroupFinished(int groupId)
	{
		HashSet<int> finishedGroupIdSet = this.FinishedGroupIdSet;
		if (finishedGroupIdSet == null)
		{
			return null;
		}
		return new bool?(finishedGroupIdSet.Contains(groupId));
	}

	// Token: 0x0600E3FB RID: 58363 RVA: 0x003D5B10 File Offset: 0x003D3D10
	public bool CanGroupInvoke(int groupId)
	{
		return !this.IsGroupFinished(groupId).GetValueOrDefault() || this.IsGroupCanRepeat(groupId);
	}

	// Token: 0x0600E3FC RID: 58364 RVA: 0x003D5B38 File Offset: 0x003D3D38
	public bool IsGroupCanRepeat(int groupId)
	{
		HashSet<int> limitRepeatStepSetOfGroup = ConfigBase<GuideConfig>.Instance.GetLimitRepeatStepSetOfGroup(groupId);
		return limitRepeatStepSetOfGroup.Count == 0 || (!limitRepeatStepSetOfGroup.Contains(-1) && (!this.CheckGuideInfoExist(groupId) || !this.CurrentGroupMap[groupId].HasAnyFinishedStep(limitRepeatStepSetOfGroup)));
	}

	// Token: 0x0600E3FD RID: 58365 RVA: 0x003D5B88 File Offset: 0x003D3D88
	[NullableContext(2)]
	public unsafe GuideGroupInfo TryGetGuideGroup(int groupId)
	{
		if (this.CheckGuideInfoExist(groupId))
		{
			return this.CurrentGroupMap[groupId];
		}
		if (this.IsLocked())
		{
			Singleton<Log>.Instance.Warn(ELogModule.Guide, ELogAuthor.TL, "引导当前处于屏蔽状态, 无法创建", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		GuideGroup? group = ConfigBase<GuideConfig>.Instance.GetGroup(groupId);
		if (group == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.TL;
			string message = "引导组的客户端配置不存在, 无法创建";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("组Id", groupId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		if (!this.CanGroupInvoke(groupId))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Guide;
			ELogAuthor author2 = ELogAuthor.TL;
			string message2 = "引导组服务端已记录完成且未配置为可重复完成, 不能重复执行";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("组Id", groupId);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, GuideGroupInfo> keyValuePair in this.CurrentGroupMap)
		{
			int key = keyValuePair.Key;
			GuideGroupInfo value = keyValuePair.Value;
			GuideGroup? group2 = ConfigBase<GuideConfig>.Instance.GetGroup(key);
			if (group2 == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Guide;
				ELogAuthor author3 = ELogAuthor.WZ;
				string message3 = "当前引导组缓存不存在客户端配置";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("组Id", key);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return null;
			}
			if (group2.Value.Priority > group.Value.Priority)
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.Guide;
				ELogAuthor author4 = ELogAuthor.TL;
				string message4 = "引导组当前缓存中存在更高优先级的引导, 不能触发新引导";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("当前组Id", groupId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("高优先级组Id", key);
				instance4.Warn(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return null;
			}
			GuideStepInfo currentGuideStep = value.CurrentGuideStep;
			int num = (currentGuideStep != null) ? currentGuideStep.Id : 0;
			if (num == 0)
			{
				num = ((value.StepInfoList.Count > 0) ? value.StepInfoList[0].Id : 0);
				Log instance5 = Singleton<Log>.Instance;
				ELogModule module5 = ELogModule.Guide;
				ELogAuthor author5 = ELogAuthor.TZJ;
				string message5 = "[TryGetGuideGroup.优先级校验] 当前引导步骤为0，使用第一个步骤Id";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("当前组Id", key);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("第一个步骤Id", num);
				instance5.Info(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			}
			HashSet<int> breakExcludeStepIdSet = value.BreakExcludeStepIdSet;
			if (breakExcludeStepIdSet != null && breakExcludeStepIdSet.Contains(num))
			{
				list.Add(key);
			}
		}
		EGuideOnlineMode onlineMode = (EGuideOnlineMode)group.Value.OnlineMode;
		if (!ControllerBase<GuideController>.Instance.CheckAvailableWhenOnline(onlineMode))
		{
			Log instance6 = Singleton<Log>.Instance;
			ELogModule module6 = ELogModule.Guide;
			ELogAuthor author6 = ELogAuthor.WZ;
			string message6 = "引导组用于是否联机的情况不匹配";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("组Id", groupId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("OnlineMode", onlineMode);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("是否处于联机", ModelBase<GameModeModel>.Instance.IsMulti);
			instance6.Warn(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			return null;
		}
		int openLimitCondition = group.Value.OpenLimitCondition;
		if (openLimitCondition != 0 && !this.IsGmInvoke && !ControllerBase<LevelGeneralController>.Instance.CheckCondition(openLimitCondition.ToString(), null, true, Array.Empty<object>()))
		{
			Log instance7 = Singleton<Log>.Instance;
			ELogModule module7 = ELogModule.Guide;
			ELogAuthor author7 = ELogAuthor.TL;
			string message7 = "引导组的入队条件组不通过";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("组Id", groupId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("conditionGroupId", openLimitCondition);
			instance7.Warn(module7, author7, message7, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
			return null;
		}
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		if (!this.CheckDungeonAvailable(groupId, instanceId, false))
		{
			Log instance8 = Singleton<Log>.Instance;
			ELogModule module8 = ELogModule.Guide;
			ELogAuthor author8 = ELogAuthor.TL;
			string message8 = "引导组的副本Id与当前所在副本不匹配";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("组Id", groupId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("当前所在副本Id", instanceId);
			instance8.Warn(module8, author8, message8, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 2));
			return null;
		}
		if (list.Count > 0)
		{
			foreach (int num2 in list)
			{
				this.CurrentGroupMap[num2].Reset();
				this.CurrentGroupMap.Remove(num2);
				Log instance9 = Singleton<Log>.Instance;
				ELogModule module9 = ELogModule.Guide;
				ELogAuthor author9 = ELogAuthor.TZJ;
				string message9 = "当前引导组优先级低于新引导组，且配置了BreakExcludeStepId，当前引导组被重置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray6 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 0) = new ValueTuple<string, object>("当前组Id", num2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 1) = new ValueTuple<string, object>("新组Id", groupId);
				instance9.Info(module9, author9, message9, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray6, 2));
			}
		}
		GuideGroupInfo guideGroupInfo = new GuideGroupInfo(groupId);
		this.CurrentGroupMap.Add(guideGroupInfo.Id, guideGroupInfo);
		return guideGroupInfo;
	}

	// Token: 0x0600E3FE RID: 58366 RVA: 0x003D60F8 File Offset: 0x003D42F8
	public void SwitchGroupState(int groupId, EGuideGroupState groupState)
	{
		GuideGroupInfo guideGroupInfo;
		if (!this.CurrentGroupMap.TryGetValue(groupId, out guideGroupInfo))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.TL;
			string message = "引导组数据未创建";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("组Id", groupId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		guideGroupInfo.SwitchState(groupState);
	}

	// Token: 0x0600E3FF RID: 58367 RVA: 0x003D614C File Offset: 0x003D434C
	public unsafe bool CheckGroupStatus(int groupId, EGuideGroupState targetState, string operatorStr)
	{
		if (this.FinishedGroupIdSet == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.TL;
			string message = "无法判定引导组状态, 引导数据尚未初始化";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("groupId", groupId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("status", targetState);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("operator", operatorStr);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return false;
		}
		if (ConfigBase<GuideConfig>.Instance.GetGroup(groupId) == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Guide;
			ELogAuthor author2 = ELogAuthor.TL;
			string message2 = "不存在ID的引导组数据, 请策划检查配置是否有误！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("组Id", groupId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		EGuideGroupState left = EGuideGroupState.Init;
		GuideGroupInfo guideGroupInfo;
		if (this.FinishedGroupIdSet.Contains(groupId))
		{
			left = EGuideGroupState.Finishing;
		}
		else if (this.CurrentGroupMap.TryGetValue(groupId, out guideGroupInfo))
		{
			left = guideGroupInfo.StateMachine.CurrentState.Value;
		}
		return GuideModel.CheckOperator((int)left, (int)targetState, operatorStr);
	}

	// Token: 0x0600E400 RID: 58368 RVA: 0x003D6260 File Offset: 0x003D4460
	private static bool CheckOperator(int left, int right, string operatorStr)
	{
		if (operatorStr == "")
		{
			return left == right;
		}
		if (operatorStr == "!=")
		{
			return left != right;
		}
		if (operatorStr == ">")
		{
			return left > right;
		}
		if (operatorStr == ">=")
		{
			return left >= right;
		}
		if (operatorStr == "<")
		{
			return left < right;
		}
		return operatorStr == "<=" && left <= right;
	}

	// Token: 0x0600E401 RID: 58369 RVA: 0x003D62E4 File Offset: 0x003D44E4
	protected override bool OnClear()
	{
		this.FinishedGroupIdSet.Clear();
		this.CurrentGroupMap.Clear();
		this.DungeonResetIdList.Clear();
		this.FocusGroupMapByView.Clear();
		if (this.TutorialList != null)
		{
			this.TutorialList.Clear();
		}
		if (this.TimeHandler != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimeHandler);
		}
		this.FinishedGroupIdSet = null;
		this.CurrentGroupMap = null;
		this.DungeonResetIdList = null;
		this.TutorialList = null;
		this.CurrentShowTutorial = null;
		this.TimeHandler = null;
		this.GuideTutorialViewOpenFailed = false;
		return true;
	}

	// Token: 0x0600E402 RID: 58370 RVA: 0x003D637C File Offset: 0x003D457C
	public int[] GetRunningGroupIdList()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, GuideGroupInfo> keyValuePair in this.CurrentGroupMap)
		{
			int key = keyValuePair.Key;
			if (keyValuePair.Value.CheckIsGuideRunning())
			{
				list.Add(key);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600E403 RID: 58371 RVA: 0x003D63F4 File Offset: 0x003D45F4
	public int[] GetRunningWithoutPendingGroupIdList()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, GuideGroupInfo> keyValuePair in this.CurrentGroupMap)
		{
			int key = keyValuePair.Key;
			if (keyValuePair.Value.CheckIsGuideRunningWithoutPending())
			{
				list.Add(key);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600E404 RID: 58372 RVA: 0x003D646C File Offset: 0x003D466C
	public unsafe void AddFocusGuideGroupToView(GuideGroupInfo group)
	{
		GuideGroupInfo group2 = group;
		if (((group2 != null) ? group2.CurrentGuideStep : null) == null || group.CurrentGuideStep.Config.ContentType != 4)
		{
			return;
		}
		GuideFocusNew? guideFocus = ConfigBase<GuideConfig>.Instance.GetGuideFocus(group.CurrentGuideStep.Id);
		if (guideFocus == null)
		{
			return;
		}
		string viewName = guideFocus.Value.ViewName;
		if (!this.FocusGroupMapByView.ContainsKey((EUiViewName)viewName))
		{
			this.FocusGroupMapByView.Add((EUiViewName)viewName, new List<GuideGroupInfo>
			{
				group
			});
			return;
		}
		List<GuideGroupInfo> list = this.FocusGroupMapByView[(EUiViewName)viewName];
		if (list.Any((GuideGroupInfo g) => g.Id == group.Id))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "尝试添加已存在的引导组到View";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("组Id", group.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("View", viewName);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		list.Add(group);
	}

	// Token: 0x0600E405 RID: 58373 RVA: 0x003D65C0 File Offset: 0x003D47C0
	public unsafe void RemoveFocusGuideGroupFromView(GuideGroupInfo group)
	{
		GuideGroupInfo group2 = group;
		if (((group2 != null) ? group2.CurrentGuideStep : null) == null || group.CurrentGuideStep.Config.ContentType != 4)
		{
			return;
		}
		GuideFocusNew? guideFocus = ConfigBase<GuideConfig>.Instance.GetGuideFocus(group.CurrentGuideStep.Id);
		if (guideFocus == null)
		{
			return;
		}
		string viewName = guideFocus.Value.ViewName;
		if (!this.FocusGroupMapByView.ContainsKey((EUiViewName)viewName))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "尝试从不存在的View中移除引导组";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("组Id", group.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("View", viewName);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		List<GuideGroupInfo> list = this.FocusGroupMapByView[(EUiViewName)viewName];
		int num = list.FindIndex((GuideGroupInfo g) => g.Id == group.Id);
		if (num >= 0)
		{
			list.RemoveAt(num);
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Guide;
		ELogAuthor author2 = ELogAuthor.HYF;
		string message2 = "尝试从View中移除不存在的引导组";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("组Id", group.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("View", viewName);
		instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
	}

	// Token: 0x0600E406 RID: 58374 RVA: 0x003D6754 File Offset: 0x003D4954
	public void FinishFocusGuideGroupOnView(EUiViewName viewName)
	{
		List<GuideGroupInfo> list;
		if (!this.FocusGroupMapByView.TryGetValue(viewName, out list) || list.Count == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.HYF;
			string message = "尝试结束不存在的引导组";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("View", viewName);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			GuideGroupInfo guideGroupInfo = list[i];
			this.FinishGroup(guideGroupInfo.Id);
		}
		this.FocusGroupMapByView.Remove(viewName);
	}

	// Token: 0x0600E407 RID: 58375 RVA: 0x003D67D8 File Offset: 0x003D49D8
	private int[] GetAvailableDungeonIdList(int groupId)
	{
		GuideGroup? group = ConfigBase<GuideConfig>.Instance.GetGroup(groupId);
		if (group == null)
		{
			return Array.Empty<int>();
		}
		if (group.Value.DungeonSets() == null || group.Value.DungeonSets().Length == 0)
		{
			return group.Value.GetDungeonIdArray();
		}
		HashSet<int> hashSet = new HashSet<int>();
		foreach (string setId in group.Value.DungeonSets())
		{
			GuideDungeonSetDefine? guideDungeonSet = ConfigBase<GuideConfig>.Instance.GetGuideDungeonSet(setId);
			if (guideDungeonSet != null)
			{
				foreach (int item in guideDungeonSet.Value.DungeonIdList())
				{
					hashSet.Add(item);
				}
			}
		}
		return hashSet.ToArray<int>();
	}

	// Token: 0x0600E408 RID: 58376 RVA: 0x003D68B4 File Offset: 0x003D4AB4
	public bool CheckDungeonAvailable(int groupId, int dungeonId, bool log = false)
	{
		if (GuideTestUtil.CheckIsTestGroup(groupId))
		{
			return true;
		}
		GuideGroup? group = ConfigBase<GuideConfig>.Instance.GetGroup(groupId);
		if (group == null)
		{
			return false;
		}
		if (group.Value.DungeonSets() == null || group.Value.DungeonSets().Length == 0)
		{
			return group.Value.DungeonId().Contains(dungeonId);
		}
		foreach (string setId in group.Value.DungeonSets())
		{
			GuideDungeonSetDefine? guideDungeonSet = ConfigBase<GuideConfig>.Instance.GetGuideDungeonSet(setId);
			if (guideDungeonSet != null && GuideModel.CheckDungeonAvailableBySet(guideDungeonSet.Value, dungeonId, log))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600E409 RID: 58377 RVA: 0x003D6968 File Offset: 0x003D4B68
	public bool CheckDungeonAvailableForSetDefine(string setDefineId, int dungeonId, bool log = false)
	{
		GuideDungeonSetDefine? guideDungeonSet = ConfigBase<GuideConfig>.Instance.GetGuideDungeonSet(setDefineId);
		return guideDungeonSet != null && GuideModel.CheckDungeonAvailableBySet(guideDungeonSet.Value, dungeonId, log);
	}

	// Token: 0x0600E40A RID: 58378 RVA: 0x003D69A4 File Offset: 0x003D4BA4
	private static bool CheckDungeonAvailableBySet(GuideDungeonSetDefine setConfig, int dungeonId, bool log = false)
	{
		for (int i = 0; i < setConfig.ExcludeIdListLength; i++)
		{
			if (setConfig.ExcludeIdList(i) == dungeonId)
			{
				return false;
			}
		}
		for (int j = 0; j < setConfig.DungeonIdListLength; j++)
		{
			if (setConfig.DungeonIdList(j) == dungeonId)
			{
				return true;
			}
		}
		InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
		InstanceDungeon? instanceDungeon = (instance != null) ? instance.GetConfig(dungeonId) : null;
		if (instanceDungeon == null)
		{
			return false;
		}
		for (int k = 0; k < setConfig.DungeonTypeSetListLength; k++)
		{
			GuideDungeonTypeSet? config = ConfigGuideDungeonTypeSetById.GetConfig(setConfig.DungeonTypeSetList(k), true);
			if (config != null && config.Value.InstType == instanceDungeon.Value.InstType && config.Value.InstSubType == instanceDungeon.Value.InstSubType)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04006D93 RID: 28051
	public bool IsLock;

	// Token: 0x04006D94 RID: 28052
	public bool IsGmLock;

	// Token: 0x04006D95 RID: 28053
	public bool IsGmInvoke;

	// Token: 0x04006D96 RID: 28054
	public bool ShouldBlockGuideBecauseUiNotRender;

	// Token: 0x04006D97 RID: 28055
	[Nullable(2)]
	private HashSet<int> DungeonResetIdList;

	// Token: 0x04006D98 RID: 28056
	[Nullable(2)]
	private HashSet<int> FinishedGroupIdSet;

	// Token: 0x04006D99 RID: 28057
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, GuideGroupInfo> CurrentGroupMap;

	// Token: 0x04006D9A RID: 28058
	public Dictionary<EUiViewName, List<GuideGroupInfo>> FocusGroupMapByView;

	// Token: 0x04006D9B RID: 28059
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<TutorialListInfo> TutorialList;

	// Token: 0x04006D9C RID: 28060
	[Nullable(2)]
	private TimerHandle TimeHandler;

	// Token: 0x04006D9D RID: 28061
	[Nullable(2)]
	private TutorialListInfo CurrentShowTutorial;

	// Token: 0x04006D9E RID: 28062
	private bool GuideTutorialViewOpenFailed;

	// Token: 0x04006D9F RID: 28063
	[Nullable(2)]
	private Dictionary<EGuideViewType, GuideStepInfo> TypeViewSingletonMap;

	// Token: 0x04006DA0 RID: 28064
	private int LockingInputGuideStepCount;
}
