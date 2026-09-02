using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Guide.GroupInfo;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Guide.StepInfo
{
	// Token: 0x02004A79 RID: 19065
	[NullableContext(2)]
	[Nullable(0)]
	public class GuideStepInfo
	{
		// Token: 0x1700849D RID: 33949
		// (get) Token: 0x06031C35 RID: 203829 RVA: 0x00C75CCC File Offset: 0x00C73ECC
		public GuideStep Config
		{
			get
			{
				if (this.ConfigInner == null)
				{
					this.ConfigInner = new GuideStep?(ConfigBase<GuideConfig>.Instance.GetStep(this.Id).Value);
				}
				return this.ConfigInner.Value;
			}
		}

		// Token: 0x06031C36 RID: 203830 RVA: 0x00C75D14 File Offset: 0x00C73F14
		[NullableContext(1)]
		public GuideStepInfo(int stepId, GuideGroupInfo owner)
		{
			this.Id = stepId;
			this.OwnerGroup = owner;
			GuideGroup? guideGroup;
			this.OwnerGroupPriority = ((ConfigBase<GuideConfig>.Instance.GetGroup(owner.Id) != null) ? guideGroup.GetValueOrDefault().Priority : 0);
			this.ViewData = new GuideStepViewData(this);
			this.StateMachine = new StateMachine<GuideStepInfo, EGuideStepState>(this, null);
			this.StateMachine.AddState<InitState>(EGuideStepState.Init, null);
			this.StateMachine.AddState<ExecutingState>(EGuideStepState.Executing, null);
			this.StateMachine.AddState<PendingState>(EGuideStepState.Pending, null);
			this.StateMachine.AddState<BreakState>(EGuideStepState.Break, null);
			this.StateMachine.AddState<FinishState>(EGuideStepState.Finish, null);
			this.StateMachine.AddState<EndState>(EGuideStepState.End, null);
			this.StateMachine.Start(EGuideStepState.Init);
		}

		// Token: 0x06031C37 RID: 203831 RVA: 0x00C75DDB File Offset: 0x00C73FDB
		public void TryEnterExecuting()
		{
			if (this.CanEnterExecuting())
			{
				this.SwitchState(EGuideStepState.Executing);
				return;
			}
			this.SwitchState(EGuideStepState.Pending);
		}

		// Token: 0x06031C38 RID: 203832 RVA: 0x00C75DF4 File Offset: 0x00C73FF4
		public void AssignGuideView(GuideBaseView view)
		{
			if (view == null)
			{
				return;
			}
			EUiViewName name = view.ViewInfo.Name;
			int viewId = view.GetViewId();
			if (this.StateMachine.CurrentState.GetValueOrDefault() != EGuideStepState.Executing)
			{
				Singleton<UiManager>.Instance.CloseViewById(viewId, null);
				return;
			}
			this.GuideView = view;
		}

		// Token: 0x06031C39 RID: 203833 RVA: 0x00C75E44 File Offset: 0x00C74044
		public void SwitchState(EGuideStepState toState)
		{
			if (this.StateMachine.CurrentState.GetValueOrDefault() == EGuideStepState.End && toState != EGuideStepState.Init)
			{
				return;
			}
			this.StateMachine.Switch(toState);
		}

		// Token: 0x06031C3A RID: 203834 RVA: 0x00C75E78 File Offset: 0x00C74078
		private bool CheckEnterExecutingConditions()
		{
			return Singleton<UiLayer>.Instance.IsUiActive() && !ModelBase<GuideModel>.Instance.ShouldBlockGuideBecauseUiNotRender && !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PhantomExploreView);
		}

		// Token: 0x06031C3B RID: 203835 RVA: 0x00C75EAC File Offset: 0x00C740AC
		private bool IsNeedNormalMask()
		{
			if (this.Config.ContentType == 4)
			{
				GuideFocusNew? guideFocus = ConfigBase<GuideConfig>.Instance.GetGuideFocus(this.Id);
				if (guideFocus != null && guideFocus.Value.UseMask)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06031C3C RID: 203836 RVA: 0x00C75EF8 File Offset: 0x00C740F8
		private unsafe bool CheckTargetViewOpen()
		{
			GuideFocusNew value = ConfigBase<GuideConfig>.Instance.GetGuideFocus(this.Id).Value;
			string viewName = value.ViewName;
			string dynamicTabName = value.DynamicTabName;
			if (GuideTestUtil.CheckIsTestStep(this.Id))
			{
				viewName = GuideTestUtil.GuideTestParams.ViewName;
			}
			if (string.IsNullOrEmpty(viewName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.TL;
				string message = "聚焦引导步骤未配置界面名称";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("步骤Id", value.GuideId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			UiViewInfo uiViewInfo = Singleton<UiConfig>.Instance.TryGetViewInfo((EUiViewName)viewName);
			if (uiViewInfo == null)
			{
				return false;
			}
			UiViewBase uiViewBase;
			if (uiViewInfo.Type == ELayerType.Float)
			{
				uiViewBase = Singleton<UiModel>.Instance.GetFloatView((EUiViewName)viewName);
				if (uiViewBase == null)
				{
				}
			}
			else
			{
				uiViewBase = Singleton<UiModel>.Instance.GetTopView(uiViewInfo.Type);
			}
			if (uiViewBase == null)
			{
				return false;
			}
			if (uiViewBase.ViewInfo.Name != viewName)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Guide;
				ELogAuthor author2 = ELogAuthor.TL;
				string message2 = "当前打开的界面与聚焦步骤的目标界面不一致";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("当前打开界面", uiViewBase.ViewInfo.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("聚焦引导目标界面", viewName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("步骤Id", value.GuideId);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return false;
			}
			if (!string.IsNullOrEmpty(dynamicTabName))
			{
				Singleton<EventSystem>.Instance.Emit<GuideStepInfo, GuideFocusNew>(EEventName.GuideFocusNeedUiTabView, this, value);
			}
			else
			{
				this.ViewData.SetAttachedView(uiViewBase);
			}
			return true;
		}

		// Token: 0x06031C3D RID: 203837 RVA: 0x00C760A8 File Offset: 0x00C742A8
		private bool CheckCanTriggerTimeDilationGuide()
		{
			if (Singleton<UiTimeDilation>.Instance.IsUiTimeDilated)
			{
				return true;
			}
			if (Singleton<UiModel>.Instance.GetTopView(ELayerType.Pop) != null)
			{
				return false;
			}
			UiViewBase topView = Singleton<UiModel>.Instance.GetTopView(ELayerType.Normal);
			EUiViewName? euiViewName;
			if (topView == null)
			{
				euiViewName = null;
			}
			else
			{
				UiViewInfo viewInfo = topView.ViewInfo;
				euiViewName = ((viewInfo != null) ? new EUiViewName?(viewInfo.Name) : null);
			}
			return euiViewName == EUiViewName.BattleView;
		}

		// Token: 0x06031C3E RID: 203838 RVA: 0x00C7612A File Offset: 0x00C7432A
		private void StartLockInput()
		{
			if (this.LockInputTimer == null)
			{
				ModelBase<GuideModel>.Instance.AddGuideLockInput();
				this.LockInputTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float id)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Guide;
					ELogAuthor author = ELogAuthor.JT;
					string message = "[Guide][引导触发后5秒没打开对应界面,触发保底]";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("步骤Id", this.Id);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					this.SwitchState(EGuideStepState.Break);
					if (ModelBase<GuideModel>.Instance.IsGuideLockingInput)
					{
						ModelBase<GuideModel>.Instance.RemoveGuideLockInput();
					}
				}, 4000f, null, null, true, 1f);
			}
		}

		// Token: 0x06031C3F RID: 203839 RVA: 0x00C76167 File Offset: 0x00C74367
		public void StopLockInput()
		{
			if (this.LockInputTimer != null)
			{
				ModelBase<GuideModel>.Instance.RemoveGuideLockInput();
				TimerSystem.GameplayTimeInstance.Remove(this.LockInputTimer);
				this.LockInputTimer = null;
			}
		}

		// Token: 0x06031C40 RID: 203840 RVA: 0x00C76194 File Offset: 0x00C74394
		public bool CanEnterExecuting()
		{
			if (!this.CheckEnterExecutingConditions())
			{
				return false;
			}
			switch (this.Config.ContentType)
			{
			case 1:
			{
				bool flag = false;
				foreach (EUiViewName viewName in GuideDefine.guideTipsAllowedViews)
				{
					if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Guide;
					ELogAuthor author = ELogAuthor.WZ;
					string message = "tip引导步骤触发时, 玩家没有位于允许触发的界面";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("步骤Id", this.Id);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return false;
				}
				if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GuideTipsView))
				{
					ModelBase<GuideModel>.Instance.BreakTypeViewStep((EGuideViewType)this.Config.ContentType);
					return false;
				}
				if (!this.CheckCanTriggerTimeDilationGuide() && this.Config.TimeScale < 1f)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Guide;
					ELogAuthor author2 = ELogAuthor.WZ;
					string message2 = "[Guide][有时停的【tip引导】触发时，有非战斗的页面打开，且ui未时停。引导不可触发]";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("步骤Id", this.Id);
					instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return false;
				}
				return true;
			}
			case 3:
				if (!this.CheckCanTriggerTimeDilationGuide() && this.Config.TimeScale < 1f)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Guide;
					ELogAuthor author3 = ELogAuthor.WZ;
					string message3 = "[Guide][有时停的【图文引导】触发时，有非战斗的页面打开，且ui未时停。引导不可触发]";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("步骤Id", this.Id);
					instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					return false;
				}
				return true;
			case 4:
			{
				if (!this.CheckTargetViewOpen())
				{
					this.StopLockInput();
					return false;
				}
				if (this.IsNeedNormalMask())
				{
					this.StartLockInput();
				}
				UiPanelBase viewObj = this.ViewData.GetAttachedView();
				if (viewObj == null)
				{
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.Guide;
					ELogAuthor author4 = ELogAuthor.TL;
					string message4 = "聚焦引导  依附的页签界面不存在或未打开";
					ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("this.Id", this.Id);
					instance4.Warn(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
					return false;
				}
				if (this.GuideFocusBehavior == null)
				{
					this.GuideFocusBehavior = new UiBehaviorGuideFocus(viewObj);
					this.GuideFocusBehavior.SetParam(new object[]
					{
						this
					});
				}
				this.GuideFocusBehavior.SetOwner(viewObj);
				if (!this.GuideFocusBehavior.PrepareForOpenGuideFocus())
				{
					return false;
				}
				UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.GuideFocusView);
				if (viewByName != null && !viewByName.WaitToDestroy && !viewByName.IsDestroyOrDestroying)
				{
					ModelBase<GuideModel>.Instance.BreakTypeViewStep((EGuideViewType)this.Config.ContentType);
					return false;
				}
				if (this.GuideFocusBehaviorProxy == null)
				{
					this.GuideFocusBehaviorProxy = new UiBehaviorBaseProxy(this.GuideFocusBehavior);
					this.GuideFocusBehaviorProxy.CreateAsync().ContinueWith(delegate(bool _)
					{
						if (this.GuideFocusBehaviorProxy == null)
						{
							return;
						}
						this.GuideFocusBehaviorProxy.StartAsync().Forget<bool>();
						viewObj.AddUiBehaviorProxy(this.GuideFocusBehaviorProxy);
					});
				}
				this.StopLockInput();
				return true;
			}
			}
			return true;
		}

		// Token: 0x06031C41 RID: 203841 RVA: 0x00C76480 File Offset: 0x00C74680
		public void ClearGuideFocusBehavior()
		{
			UiBehaviorGuideFocus guideFocusBehavior = this.GuideFocusBehavior;
			if (guideFocusBehavior != null)
			{
				guideFocusBehavior.CleanGuideStep();
			}
			this.GuideFocusBehavior = null;
			this.GuideFocusBehaviorProxy = null;
		}

		// Token: 0x06031C42 RID: 203842 RVA: 0x00C764A4 File Offset: 0x00C746A4
		public bool SetLimitInputDistribute()
		{
			bool result = false;
			int contentType = this.Config.ContentType;
			if (contentType != 1)
			{
				if (contentType == 4)
				{
					GuideFocusNew value = ConfigBase<GuideConfig>.Instance.GetGuideFocus(this.Id).Value;
					foreach (string actionName in value.LimitInputEnumsIter())
					{
						ModelBase<InputDistributeModel>.Instance.AddToLimitInputDistributeActions(actionName);
					}
					if (ModelBase<InputDistributeModel>.Instance.HasActionLimitSet())
					{
						if (value.UseClick || value.UseMask || this.Config.TimeScale < 1f)
						{
							ModelBase<InputDistributeModel>.Instance.AddToLimitInputDistributeActions("UI左键点击");
							ModelBase<InputDistributeModel>.Instance.AddToLimitInputDistributeActions("显示鼠标");
						}
						result = true;
					}
				}
			}
			else
			{
				foreach (string actionName2 in ConfigBase<GuideConfig>.Instance.GetGuideTips(this.Id).Value.LimitInputEnumsIter())
				{
					ModelBase<InputDistributeModel>.Instance.AddToLimitInputDistributeActions(actionName2);
				}
				if (ModelBase<InputDistributeModel>.Instance.HasActionLimitSet())
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0401D231 RID: 119345
		public readonly int Id;

		// Token: 0x0401D232 RID: 119346
		public readonly GuideGroupInfo OwnerGroup;

		// Token: 0x0401D233 RID: 119347
		public readonly int OwnerGroupPriority;

		// Token: 0x0401D234 RID: 119348
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public readonly StateMachine<GuideStepInfo, EGuideStepState> StateMachine;

		// Token: 0x0401D235 RID: 119349
		public readonly GuideStepViewData ViewData;

		// Token: 0x0401D236 RID: 119350
		public GuideBaseView GuideView;

		// Token: 0x0401D237 RID: 119351
		public UiBehaviorBaseProxy GuideFocusBehaviorProxy;

		// Token: 0x0401D238 RID: 119352
		private UiBehaviorGuideFocus GuideFocusBehavior;

		// Token: 0x0401D239 RID: 119353
		private GuideStep? ConfigInner;

		// Token: 0x0401D23A RID: 119354
		private TimerHandle LockInputTimer;

		// Token: 0x0401D23B RID: 119355
		public bool IsExitingFromExecuting;
	}
}
