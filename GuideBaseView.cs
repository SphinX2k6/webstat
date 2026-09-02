using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Guide.StepInfo;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.LevelConditions;
using CSharpScript.Game.Ui;

// Token: 0x02001E29 RID: 7721
[NullableContext(1)]
[Nullable(0)]
public abstract class GuideBaseView : UiViewBase
{
	// Token: 0x170011CA RID: 4554
	// (get) Token: 0x0600E425 RID: 58405 RVA: 0x003D6F24 File Offset: 0x003D5124
	public float TotalDuration
	{
		get
		{
			if (this.GuideStepInfo == null)
			{
				return 0f;
			}
			return (float)this.GuideStepInfo.Config.Duration;
		}
	}

	// Token: 0x0600E426 RID: 58406 RVA: 0x003D6F54 File Offset: 0x003D5154
	public GuideBaseView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E427 RID: 58407 RVA: 0x003D708C File Offset: 0x003D528C
	private void CheckCondition()
	{
		GuideStep config = this.GuideStepInfo.Config;
		if (this.SuccessConditionCallback == null)
		{
			int successCondition = config.SuccessCondition;
			if (successCondition > 0 && ControllerBase<LevelGeneralController>.Instance.CheckCondition(successCondition.ToString(), null, false, Array.Empty<object>()))
			{
				this.OnFinishConditionOk(null);
			}
		}
		if (this.FailureConditionCallback == null)
		{
			int failureCondition = config.FailureCondition;
			if (failureCondition > 0 && ControllerBase<LevelGeneralController>.Instance.CheckCondition(failureCondition.ToString(), null, false, Array.Empty<object>()))
			{
				this.OnFinishConditionFail(null);
			}
		}
	}

	// Token: 0x0600E428 RID: 58408 RVA: 0x003D7110 File Offset: 0x003D5310
	protected bool CheckTickCondition()
	{
		int tickCondition = this.GuideStepInfo.Config.TickCondition;
		if (tickCondition == 0)
		{
			return true;
		}
		this.TickConditionDirtyFlag = true;
		return ControllerBase<LevelGeneralController>.Instance.CheckCondition(tickCondition.ToString(), null, true, new object[]
		{
			base.GetViewId()
		});
	}

	// Token: 0x0600E429 RID: 58409 RVA: 0x003D7164 File Offset: 0x003D5364
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnUiScreenRootVisibleChange, new Action<bool>(this.OnVisibleChanged));
		this.OnGuideBaseViewAddEvent();
	}

	// Token: 0x0600E42A RID: 58410 RVA: 0x003D7188 File Offset: 0x003D5388
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUiScreenRootVisibleChange, new Action<bool>(this.OnVisibleChanged));
		this.OnGuideBaseViewRemoveEvent();
	}

	// Token: 0x0600E42B RID: 58411 RVA: 0x003D71AC File Offset: 0x003D53AC
	private void OnVisibleChanged(bool isShow)
	{
		if (!base.GetActive())
		{
			return;
		}
		if (isShow)
		{
			this.OnAfterShow();
			return;
		}
		this.OnAfterHide();
	}

	// Token: 0x0600E42C RID: 58412 RVA: 0x003D71C8 File Offset: 0x003D53C8
	protected bool HasConflictView()
	{
		foreach (EUiViewName name in this.guideConflictView)
		{
			if (Singleton<UiManager>.Instance.IsViewShow(name))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600E42D RID: 58413 RVA: 0x003D7228 File Offset: 0x003D5428
	public void DoCloseByFinished()
	{
		if (!this.IsFinished)
		{
			this.IsFinished = true;
			this.OnGuideViewCloseWhenFinish();
			this.DoCloseWithMinShowDuration();
		}
	}

	// Token: 0x0600E42E RID: 58414 RVA: 0x003D7248 File Offset: 0x003D5448
	private void DoCloseWithMinShowDuration()
	{
		float remainMinShowDuration = this.RemainMinShowDuration;
		if (remainMinShowDuration < 20f)
		{
			this.DoClose();
			return;
		}
		TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.DoClose();
		}, remainMinShowDuration, null, null, true, 1f);
	}

	// Token: 0x0600E42F RID: 58415 RVA: 0x003D728B File Offset: 0x003D548B
	private void DoClose()
	{
		if (this.TimeTicker != null)
		{
			this.TimeTicker.Remove();
			this.TimeTicker = null;
		}
		base.CloseMe(null);
	}

	// Token: 0x0600E430 RID: 58416 RVA: 0x003D72B0 File Offset: 0x003D54B0
	protected unsafe void BindInput(List<string> rawInputEnums, List<string> inputEnums, TInputHandle<float> callback)
	{
		if (rawInputEnums.Count != inputEnums.Count)
		{
			return;
		}
		if (this.InputCallback == callback)
		{
			return;
		}
		this.InputCallback = callback;
		for (int i = 0; i < inputEnums.Count; i++)
		{
			string text = rawInputEnums[i];
			if (actionMappings.HasField(text))
			{
				ControllerBase<InputDistributeController>.Instance.BindAction(inputEnums[i], new TInputHandle<InputDistributeDefine.EActionType>(this.OnActionCall));
				this.CombineInputMap[inputEnums[i]] = 1f;
			}
			else if (axisMappings.HasField(text))
			{
				ControllerBase<InputDistributeController>.Instance.BindAxis(inputEnums[i], new TInputHandle<float>(this.OnAxisCall));
				this.CombineInputMap[inputEnums[i]] = 0f;
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.TL;
				string message = "引导步骤  填的操作映射未定义";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("this.GuideStepInfo!.Id", this.GuideStepInfo.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("错误的操作映射", text);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
	}

	// Token: 0x0600E431 RID: 58417 RVA: 0x003D73E2 File Offset: 0x003D55E2
	private void OnActionCall(string name, InputDistributeDefine.EActionType value, InputIdentification inputIdentification)
	{
		TInputHandle<float> inputCallback = this.InputCallback;
		if (inputCallback == null)
		{
			return;
		}
		inputCallback(name, (float)value, inputIdentification);
	}

	// Token: 0x0600E432 RID: 58418 RVA: 0x003D73F8 File Offset: 0x003D55F8
	private void OnAxisCall(string name, float value, InputIdentification inputIdentification)
	{
		TInputHandle<float> inputCallback = this.InputCallback;
		if (inputCallback == null)
		{
			return;
		}
		inputCallback(name, value, inputIdentification);
	}

	// Token: 0x0600E433 RID: 58419 RVA: 0x003D7410 File Offset: 0x003D5610
	protected bool IsAllCombineInputPass()
	{
		bool flag = true;
		foreach (KeyValuePair<string, float> keyValuePair in this.CombineInputMap)
		{
			string key = keyValuePair.Key;
			float value = keyValuePair.Value;
			if (actionMappings.HasField(key))
			{
				flag = (flag && value != 1f);
			}
			else if (axisMappings.HasField(key))
			{
				flag = (flag && value > 0f);
			}
		}
		return flag;
	}

	// Token: 0x0600E434 RID: 58420 RVA: 0x003D74A8 File Offset: 0x003D56A8
	protected unsafe void UnbindInput(string[] rawInputEnums, string[] inputEnums)
	{
		if (rawInputEnums.Length != inputEnums.Length)
		{
			return;
		}
		if (this.InputCallback == null)
		{
			return;
		}
		for (int i = 0; i < inputEnums.Length; i++)
		{
			string text = rawInputEnums[i];
			if (actionMappings.HasField(text))
			{
				ControllerBase<InputDistributeController>.Instance.UnBindAction(inputEnums[i], new TInputHandle<InputDistributeDefine.EActionType>(this.OnActionCall));
			}
			else if (axisMappings.HasField(text))
			{
				ControllerBase<InputDistributeController>.Instance.UnBindAxis(inputEnums[i], new TInputHandle<float>(this.OnAxisCall));
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.TL;
				string message = "引导步骤  填的操作映射未定义";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("this.GuideStepInfo!.Id", this.GuideStepInfo.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("错误的操作映射", text);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			this.CombineInputMap.Remove(inputEnums[i]);
		}
		this.InputCallback = null;
	}

	// Token: 0x0600E435 RID: 58421 RVA: 0x003D75A0 File Offset: 0x003D57A0
	protected void OnFinishConditionOk([Nullable(new byte[]
	{
		2,
		1
	})] object[] paramList = null)
	{
		if (!this.OnCheckBaseViewFinishConditionOk())
		{
			return;
		}
		this.DoCloseByFinished();
	}

	// Token: 0x0600E436 RID: 58422 RVA: 0x003D75B1 File Offset: 0x003D57B1
	protected void OnFinishConditionFail([Nullable(new byte[]
	{
		2,
		1
	})] object[] paramList = null)
	{
		if (!this.OnCheckBaseViewFinishConditionFail())
		{
			return;
		}
		this.DoCloseWithMinShowDuration();
	}

	// Token: 0x0600E437 RID: 58423 RVA: 0x003D75C4 File Offset: 0x003D57C4
	protected override void OnBeforeCreate()
	{
		this.IsConditionRegistered = false;
		this.GuideStepInfo = (this.OpenParam as GuideStepInfo);
		this.RemainDuration = this.TotalDuration;
		this.RemainMinShowDuration = (float)this.GuideStepInfo.Config.MinDuration;
		this.GuideStepInfo.AssignGuideView(this);
		this.RegisterFinishCondition();
		this.OnBeforeGuideBaseViewCreate();
	}

	// Token: 0x0600E438 RID: 58424 RVA: 0x003D7627 File Offset: 0x003D5827
	protected override void OnStart()
	{
		this.OnGuideBaseViewStart();
		this.TimeTicker = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnTick), 20f, 1f, null, null, true);
	}

	// Token: 0x0600E439 RID: 58425 RVA: 0x003D7658 File Offset: 0x003D5858
	protected override void OnAfterShow()
	{
		GuideStep config = this.GuideStepInfo.Config;
		if (config.IsDangerous)
		{
			Singleton<LguiUtil>.Instance.LoadPrefabByResourceIdAsync("UiItem_Danger_Tip", this.RootItem, null, ResourceSystem.EResourceLoadPriority.Default, "js_undefined");
		}
		float timeScale = config.TimeScale;
		if (timeScale < 1f && !ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			Singleton<UiTimeDilation>.Instance.SetTimeDilationHighLevel(timeScale, "GuideBase");
		}
		this.RegisterFinishCondition();
		this.OnGuideViewAfterShow();
	}

	// Token: 0x0600E43A RID: 58426 RVA: 0x003D76DC File Offset: 0x003D58DC
	protected override void OnAfterHide()
	{
		if (this.GuideStepInfo.Config.TimeScale < 1f && !ModelBase<GameModeModel>.Instance.IsMulti)
		{
			Singleton<UiTimeDilation>.Instance.ResetTimeDilationHighLevel("GuideBase");
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		}
		this.UnRegisterFinishCondition();
		this.OnGuideBaseViewAfterHide();
	}

	// Token: 0x0600E43B RID: 58427 RVA: 0x003D7734 File Offset: 0x003D5934
	private void RegisterFinishCondition()
	{
		if (this.IsConditionRegistered)
		{
			return;
		}
		this.IsConditionRegistered = true;
		GuideStep config = this.GuideStepInfo.Config;
		if (config.SuccessCondition != 0)
		{
			ConditionPassCallback conditionPassCallback = new ConditionPassCallback(new TConditionPassCallback(this.OnFinishConditionOk), null);
			if (Singleton<LevelConditionRegistry>.Instance.RegisterConditionGroup(config.SuccessCondition, conditionPassCallback))
			{
				this.SuccessConditionCallback = conditionPassCallback;
			}
		}
		if (config.FailureCondition != 0)
		{
			ConditionPassCallback conditionPassCallback2 = new ConditionPassCallback(new TConditionPassCallback(this.OnFinishConditionFail), null);
			if (Singleton<LevelConditionRegistry>.Instance.RegisterConditionGroup(config.FailureCondition, conditionPassCallback2))
			{
				this.FailureConditionCallback = conditionPassCallback2;
			}
		}
	}

	// Token: 0x0600E43C RID: 58428 RVA: 0x003D77CC File Offset: 0x003D59CC
	private void UnRegisterFinishCondition()
	{
		if (!this.IsConditionRegistered)
		{
			return;
		}
		this.IsConditionRegistered = false;
		GuideStep config = this.GuideStepInfo.Config;
		int successCondition = config.SuccessCondition;
		if (this.SuccessConditionCallback != null)
		{
			Singleton<LevelConditionRegistry>.Instance.UnRegisterConditionGroup(config.SuccessCondition, this.SuccessConditionCallback);
			this.SuccessConditionCallback = null;
		}
		int failureCondition = config.FailureCondition;
		if (this.FailureConditionCallback != null)
		{
			Singleton<LevelConditionRegistry>.Instance.UnRegisterConditionGroup(config.FailureCondition, this.FailureConditionCallback);
			this.FailureConditionCallback = null;
		}
	}

	// Token: 0x0600E43D RID: 58429 RVA: 0x003D7854 File Offset: 0x003D5A54
	protected override void OnBeforeDestroy()
	{
		this.TickConditionDirtyFlag = false;
		if (this.TimeTicker != null)
		{
			this.TimeTicker.Remove();
			this.TimeTicker = null;
		}
		GuideStepInfo guideStepInfo = this.GuideStepInfo;
		this.OnGuideBaseViewDestroy();
		if (this.IgnoreState)
		{
			return;
		}
		if (this.IsFinished)
		{
			guideStepInfo.SwitchState(EGuideStepState.Finish);
			return;
		}
		guideStepInfo.SwitchState(EGuideStepState.Break);
	}

	// Token: 0x0600E43E RID: 58430 RVA: 0x003D78B0 File Offset: 0x003D5AB0
	public void OnTick(float delta)
	{
		if (ModelBase<LoadingModel>.Instance.IsLoadingView)
		{
			return;
		}
		this.OnGuideBaseViewTick(delta);
		float num = this.RemainDuration;
		if (num > 0f)
		{
			float num2 = delta;
			GuideStepInfo guideStepInfo = this.GuideStepInfo;
			bool flag;
			if (guideStepInfo == null)
			{
				flag = false;
			}
			else
			{
				GuideStepViewData viewData = guideStepInfo.ViewData;
				flag = ((viewData != null) ? new bool?(viewData.IsAttachToBattleView) : null).GetValueOrDefault();
			}
			if (flag && !base.IsShow && !this.TickConditionDirtyFlag)
			{
				num2 = 0f;
			}
			num -= num2;
			if (num <= 0f)
			{
				this.CloseWhileDurationEnd();
			}
			this.RemainDuration = num;
			this.OnDurationChange(num);
		}
		if (base.IsShow)
		{
			this.RemainMinShowDuration -= delta;
			this.CheckCondition();
		}
	}

	// Token: 0x0600E43F RID: 58431 RVA: 0x003D7969 File Offset: 0x003D5B69
	private void CloseWhileDurationEnd()
	{
		this.DoClose();
	}

	// Token: 0x0600E440 RID: 58432 RVA: 0x003D7971 File Offset: 0x003D5B71
	protected virtual void OnBeforeGuideBaseViewCreate()
	{
	}

	// Token: 0x0600E441 RID: 58433 RVA: 0x003D7973 File Offset: 0x003D5B73
	protected virtual void OnGuideBaseViewStart()
	{
	}

	// Token: 0x0600E442 RID: 58434 RVA: 0x003D7975 File Offset: 0x003D5B75
	protected virtual void OnGuideBaseViewAfterHide()
	{
	}

	// Token: 0x0600E443 RID: 58435 RVA: 0x003D7977 File Offset: 0x003D5B77
	protected virtual void OnGuideViewAfterShow()
	{
	}

	// Token: 0x0600E444 RID: 58436 RVA: 0x003D7979 File Offset: 0x003D5B79
	protected virtual void OnGuideBaseViewDestroy()
	{
	}

	// Token: 0x0600E445 RID: 58437 RVA: 0x003D797B File Offset: 0x003D5B7B
	protected virtual void OnGuideBaseViewAddEvent()
	{
	}

	// Token: 0x0600E446 RID: 58438 RVA: 0x003D797D File Offset: 0x003D5B7D
	protected virtual void OnGuideBaseViewRemoveEvent()
	{
	}

	// Token: 0x0600E447 RID: 58439 RVA: 0x003D797F File Offset: 0x003D5B7F
	protected virtual void OnGuideBaseViewTick(float delta)
	{
	}

	// Token: 0x0600E448 RID: 58440 RVA: 0x003D7981 File Offset: 0x003D5B81
	protected virtual void OnDurationChange(float remainDuration)
	{
	}

	// Token: 0x0600E449 RID: 58441 RVA: 0x003D7983 File Offset: 0x003D5B83
	protected virtual void OnGuideViewCloseWhenFinish()
	{
	}

	// Token: 0x0600E44A RID: 58442 RVA: 0x003D7985 File Offset: 0x003D5B85
	protected virtual bool OnCheckBaseViewFinishConditionOk()
	{
		return true;
	}

	// Token: 0x0600E44B RID: 58443 RVA: 0x003D7988 File Offset: 0x003D5B88
	protected virtual bool OnCheckBaseViewFinishConditionFail()
	{
		return true;
	}

	// Token: 0x04006DB4 RID: 28084
	private HashSet<EUiViewName> guideConflictView = new HashSet<EUiViewName>
	{
		EUiViewName.MonthCardRewardView,
		EUiViewName.QuestRewardView,
		EUiViewName.ExploreRewardView,
		EUiViewName.CommonRewardView,
		EUiViewName.ItemTipsView,
		EUiViewName.ExploreDetailView,
		EUiViewName.TowerUnlockView,
		EUiViewName.TowerOverLockUnlockView,
		EUiViewName.PowerView,
		EUiViewName.ActivityRewardPopUpView,
		EUiViewName.RoleGenderChangeView,
		EUiViewName.ConfirmBoxView,
		EUiViewName.CdKeyInputView,
		EUiViewName.CompositeRewardView,
		EUiViewName.LogUploadView,
		EUiViewName.RacingBetsSuccessTip,
		EUiViewName.RacingBetsFailTip,
		EUiViewName.DangoAbyssInfoView,
		EUiViewName.PhantomArenaStartView,
		EUiViewName.TutorialPopView,
		EUiViewName.ResolutionListView
	}.Concat(LoadingDefine.loadingViewList).ToHashSet<EUiViewName>();

	// Token: 0x04006DB5 RID: 28085
	public bool IgnoreState;

	// Token: 0x04006DB6 RID: 28086
	protected bool IsFinished;

	// Token: 0x04006DB7 RID: 28087
	[Nullable(2)]
	protected GuideStepInfo GuideStepInfo;

	// Token: 0x04006DB8 RID: 28088
	protected readonly Dictionary<string, float> CombineInputMap = new Dictionary<string, float>();

	// Token: 0x04006DB9 RID: 28089
	protected float RemainDuration;

	// Token: 0x04006DBA RID: 28090
	private float RemainMinShowDuration;

	// Token: 0x04006DBB RID: 28091
	private bool IsConditionRegistered;

	// Token: 0x04006DBC RID: 28092
	private bool TickConditionDirtyFlag;

	// Token: 0x04006DBD RID: 28093
	[Nullable(2)]
	private ConditionPassCallback SuccessConditionCallback;

	// Token: 0x04006DBE RID: 28094
	[Nullable(2)]
	private ConditionPassCallback FailureConditionCallback;

	// Token: 0x04006DBF RID: 28095
	[Nullable(2)]
	protected TimerHandle TimeTicker;

	// Token: 0x04006DC0 RID: 28096
	[Nullable(2)]
	private TInputHandle<float> InputCallback;
}
