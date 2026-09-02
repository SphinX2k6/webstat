using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200261F RID: 9759
[NullableContext(2)]
[Nullable(0)]
public abstract class CommonQteItemBase<[Nullable(0)] TContextType> : CommonQteItemBase where TContextType : CommonQteContextBase
{
	// Token: 0x060132DF RID: 78559 RVA: 0x00552F7F File Offset: 0x0055117F
	protected override void OnRegisterComponent()
	{
		this.IsMobile = Singleton<Info>.Instance.IsInTouch();
	}

	// Token: 0x060132E0 RID: 78560 RVA: 0x00552F94 File Offset: 0x00551194
	protected override void OnStart()
	{
		UUIItem floatUnit = Singleton<UiLayer>.Instance.GetFloatUnit(ELayerType.BattleFloat, 2);
		if (floatUnit != null)
		{
			this.GetOriginalItem().SetUIParent(floatUnit, false);
		}
	}

	// Token: 0x060132E1 RID: 78561 RVA: 0x00552FC0 File Offset: 0x005511C0
	protected override void OnBeforeDestroy()
	{
		this.UnbindEvents();
		this.UnbindAction();
		if (!this.IsQteEnd)
		{
			TContextType tcontextType = this.CommonQteContext;
			if (tcontextType != null && tcontextType.IsActive())
			{
				ControllerBase<CommonQteController>.Instance.StopQte(this.CommonQteContext.HandleId);
			}
		}
		this.CommonQteContext = default(TContextType);
		this.QteHandle = -1;
		this.QteAction = "";
		this.ClearTickTimer();
		if (this.WorldUiRootOriginalDepth != null)
		{
			AActor worldSpaceUiRoot = Singleton<UiLayer>.Instance.WorldSpaceUiRoot;
			ULGUIWorldSpaceInteraction ulguiworldSpaceInteraction = ((worldSpaceUiRoot != null) ? worldSpaceUiRoot.GetComponentByClass(ULGUIWorldSpaceInteraction.StaticClass()) : null) as ULGUIWorldSpaceInteraction;
			if (ulguiworldSpaceInteraction != null)
			{
				ulguiworldSpaceInteraction.depth = this.WorldUiRootOriginalDepth.Value;
			}
			this.WorldUiRootOriginalDepth = null;
		}
	}

	// Token: 0x060132E2 RID: 78562 RVA: 0x0055308C File Offset: 0x0055128C
	protected void BindAction()
	{
		if (this.HasBindAction)
		{
			return;
		}
		this.HasBindAction = true;
		if (!this.IsMobile && this.IsUseBaseAction() && !string.IsNullOrEmpty(this.QteAction))
		{
			ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit(this.QteAction, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
			if (this.QteAction == "幻象1")
			{
				ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputInteract));
			}
		}
		this.OnBindAction();
	}

	// Token: 0x060132E3 RID: 78563 RVA: 0x00553118 File Offset: 0x00551318
	protected void UnbindAction()
	{
		if (!this.HasBindAction)
		{
			return;
		}
		this.HasBindAction = false;
		if (!this.IsMobile && this.IsUseBaseAction() && !string.IsNullOrEmpty(this.QteAction))
		{
			ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit(this.QteAction, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputCallback));
			if (this.QteAction == "幻象1")
			{
				ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputInteract));
			}
		}
		this.OnUnbindAction();
	}

	// Token: 0x060132E4 RID: 78564 RVA: 0x005531A1 File Offset: 0x005513A1
	protected virtual void OnBindAction()
	{
	}

	// Token: 0x060132E5 RID: 78565 RVA: 0x005531A3 File Offset: 0x005513A3
	protected virtual void OnUnbindAction()
	{
	}

	// Token: 0x060132E6 RID: 78566 RVA: 0x005531A5 File Offset: 0x005513A5
	protected virtual bool IsUseBaseAction()
	{
		return true;
	}

	// Token: 0x060132E7 RID: 78567 RVA: 0x005531A8 File Offset: 0x005513A8
	[NullableContext(1)]
	protected void OnInputCallback(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
	{
		if (!this.IsValidInput())
		{
			return;
		}
		if (actionType == InputDistributeDefine.EActionType.Press)
		{
			this.OnInputPress();
			return;
		}
		if (actionType == InputDistributeDefine.EActionType.Release)
		{
			this.OnInputRelease();
		}
	}

	// Token: 0x060132E8 RID: 78568 RVA: 0x005531C8 File Offset: 0x005513C8
	[NullableContext(1)]
	private void OnInputInteract(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			SkillButtonUiModel instance = ModelBase<SkillButtonUiModel>.Instance;
			bool flag;
			if (instance == null)
			{
				flag = false;
			}
			else
			{
				SkillButtonUiGamepadDataBase gamepadData = instance.GamepadData;
				flag = ((gamepadData != null) ? new bool?(gamepadData.SwitchInteractData.IsSwitchInteractOpen) : null).GetValueOrDefault();
			}
			if (flag)
			{
				SkillButtonUiModel instance2 = ModelBase<SkillButtonUiModel>.Instance;
				bool flag2;
				if (instance2 == null)
				{
					flag2 = false;
				}
				else
				{
					SkillButtonUiGamepadDataBase gamepadData2 = instance2.GamepadData;
					flag2 = (((gamepadData2 != null) ? new EGamepadSwitchInteractState?(gamepadData2.SwitchInteractData.State) : null).GetValueOrDefault() == EGamepadSwitchInteractState.Explore);
				}
				if (flag2 && this.QteAction == "幻象1")
				{
					this.OnInputCallback(this.QteAction, actionType, inputIdentification);
					return;
				}
			}
		}
	}

	// Token: 0x060132E9 RID: 78569 RVA: 0x0055327A File Offset: 0x0055147A
	protected virtual void OnInputPress()
	{
	}

	// Token: 0x060132EA RID: 78570 RVA: 0x0055327C File Offset: 0x0055147C
	protected virtual void OnInputRelease()
	{
	}

	// Token: 0x060132EB RID: 78571 RVA: 0x0055327E File Offset: 0x0055147E
	public override void OnInputTest()
	{
		this.OnInputPress();
	}

	// Token: 0x060132EC RID: 78572 RVA: 0x00553286 File Offset: 0x00551486
	protected override void OnAfterShow()
	{
		base.OnAfterShow();
		this.ResumeQte(false);
	}

	// Token: 0x060132ED RID: 78573 RVA: 0x00553295 File Offset: 0x00551495
	protected override void OnBeforeHide()
	{
		base.OnBeforeHide();
		this.PauseQte();
	}

	// Token: 0x060132EE RID: 78574 RVA: 0x005532A4 File Offset: 0x005514A4
	private void BindEvents()
	{
		if (this.IsBindEvents)
		{
			return;
		}
		this.IsBindEvents = true;
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.DisableCustomInputData, this.RootActor.GetName());
		ModelBase<BattleUiModel>.Instance.ChildViewData.AddCallback(EBattleUiChild.PanelQTE, new Action(this.OnBattleUiVisibleChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.TriggerUiTimeDilation, new Action(this.OnTriggerUiTimeDilation));
		Singleton<EventSystem>.Instance.Add<int?>(EEventName.CommonQteEnd, new Action<int?>(this.OnCommonQteEnd));
	}

	// Token: 0x060132EF RID: 78575 RVA: 0x00553330 File Offset: 0x00551530
	private void UnbindEvents()
	{
		if (!this.IsBindEvents)
		{
			return;
		}
		this.IsBindEvents = false;
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.EnableCacheCustomInputData, this.RootActor.GetName());
		ModelBase<BattleUiModel>.Instance.ChildViewData.RemoveCallback(EBattleUiChild.PanelQTE, new Action(this.OnBattleUiVisibleChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.TriggerUiTimeDilation, new Action(this.OnTriggerUiTimeDilation));
		Singleton<EventSystem>.Instance.Remove<int?>(EEventName.CommonQteEnd, new Action<int?>(this.OnCommonQteEnd));
	}

	// Token: 0x060132F0 RID: 78576 RVA: 0x005533BC File Offset: 0x005515BC
	private void OnCommonQteEnd(int? handleId)
	{
		int qteHandle = this.QteHandle;
		int? num = handleId;
		if (!(qteHandle == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		this.HandleQteEnd();
	}

	// Token: 0x060132F1 RID: 78577 RVA: 0x005533EC File Offset: 0x005515EC
	private void OnBattleUiVisibleChanged()
	{
		if (this.CommonQteContext == null || this.IsAttaching)
		{
			return;
		}
		EQteSource? source = this.CommonQteContext.Source;
		EQteSource eqteSource = EQteSource.Battle;
		if (!(source.GetValueOrDefault() == eqteSource & source != null))
		{
			return;
		}
		bool childVisible = ModelBase<BattleUiModel>.Instance.ChildViewData.GetChildVisible(EBattleUiChild.PanelQTE);
		if (base.GetActive() != childVisible)
		{
			this.SetActive(childVisible);
		}
	}

	// Token: 0x060132F2 RID: 78578 RVA: 0x00553459 File Offset: 0x00551659
	private void OnTriggerUiTimeDilation()
	{
		if (this.IsQteEnd)
		{
			return;
		}
		if (ControllerBase<CommonQteController>.Instance.IsSelfTriggeringTimeDilationChange())
		{
			return;
		}
		if (Singleton<Time>.Instance.TimeDilation == 0f)
		{
			this.PauseQte();
			return;
		}
		this.ResumeQte(true);
	}

	// Token: 0x060132F3 RID: 78579 RVA: 0x00553490 File Offset: 0x00551690
	protected void Tick(float delta)
	{
		if (this.IsKeepRelativeToCamera)
		{
			this.UpdateRelativeRotation();
		}
		else if (this.IsUseTargetScreenPos)
		{
			this.UpdateScreenPosition();
		}
		if (this.ScaleCurve != null)
		{
			this.UpdateScale();
		}
		this.OnTick(delta);
	}

	// Token: 0x060132F4 RID: 78580 RVA: 0x005534C8 File Offset: 0x005516C8
	protected virtual void OnTick(float delta)
	{
		UUIItem originalItem = this.GetOriginalItem();
		if (originalItem == null || !originalItem.IsValid())
		{
			if (this.CommonQteContext == null || this.CommonQteContext.IsInvalid())
			{
				this.HandleQteEnd();
				return;
			}
			ControllerBase<CommonQteController>.Instance.StopQte(this.CommonQteContext.HandleId);
			return;
		}
		else
		{
			if (!this.IsQteStart || this.IsQteEnd || this.IsQtePause)
			{
				return;
			}
			if (this.CommonQteContext == null || this.CommonQteContext.IsInvalid())
			{
				this.HandleQteEnd();
				return;
			}
			this.CommonQteContext.UpdateTime(delta);
			if (this.CommonQteContext != null)
			{
				this.OnTickQteItem(delta);
			}
			CommonQteModel instance = ModelBase<CommonQteModel>.Instance;
			if (instance != null && instance.IsRefreshMode)
			{
				this.RefreshUiOffset();
			}
			return;
		}
	}

	// Token: 0x060132F5 RID: 78581 RVA: 0x005535AA File Offset: 0x005517AA
	protected virtual void OnTickQteItem(float delta)
	{
	}

	// Token: 0x060132F6 RID: 78582 RVA: 0x005535AC File Offset: 0x005517AC
	protected void PauseQte()
	{
		if (this.IsQtePause || this.IsQteEnd)
		{
			return;
		}
		TimerHandle tickTimer = this.TickTimer;
		if (tickTimer != null)
		{
			tickTimer.Pause();
		}
		this.IsQtePause = true;
		if (this.IsQteActive)
		{
			this.OnQtePause();
		}
	}

	// Token: 0x060132F7 RID: 78583 RVA: 0x005535E8 File Offset: 0x005517E8
	protected void ResumeQte(bool delay = false)
	{
		if (!this.IsQtePause || this.IsQteEnd)
		{
			return;
		}
		TimerHandle tickTimer = this.TickTimer;
		if (tickTimer != null)
		{
			tickTimer.Resume();
		}
		this.IsQtePause = false;
		if (this.IsQteActive)
		{
			if (delay)
			{
				TimerSystem.Instance.Next(delegate(float _)
				{
					UUIItem originalItem = this.GetOriginalItem();
					if (originalItem == null || !originalItem.IsValid())
					{
						return;
					}
					this.OnQteResume();
				}, null, null);
				return;
			}
			this.OnQteResume();
		}
	}

	// Token: 0x060132F8 RID: 78584 RVA: 0x0055364A File Offset: 0x0055184A
	protected virtual void OnQtePause()
	{
		if (this.CommonQteContext != null)
		{
			ControllerBase<CommonQteController>.Instance.PauseQte(this.CommonQteContext.HandleId);
		}
		this.UnbindAction();
	}

	// Token: 0x060132F9 RID: 78585 RVA: 0x0055367C File Offset: 0x0055187C
	protected virtual void OnQteResume()
	{
		if (this.CommonQteContext != null)
		{
			ControllerBase<CommonQteController>.Instance.ResumeQte(this.CommonQteContext.HandleId);
		}
		if (this.IsQteActive)
		{
			this.BindAction();
		}
		if (!this.IsQtePlayStart)
		{
			this.PlayQteStart();
		}
	}

	// Token: 0x060132FA RID: 78586 RVA: 0x005536CC File Offset: 0x005518CC
	protected void HandleQteEnd()
	{
		if (this.IsQteEnd)
		{
			return;
		}
		this.IsQteEnd = true;
		this.OnHandleQteEnd();
		this.UnbindAction();
		this.ClearTickTimer();
	}

	// Token: 0x060132FB RID: 78587 RVA: 0x005536F0 File Offset: 0x005518F0
	protected virtual void OnHandleQteEnd()
	{
	}

	// Token: 0x060132FC RID: 78588 RVA: 0x005536F2 File Offset: 0x005518F2
	public bool IsValidInput()
	{
		return this.IsQteInteractive && !this.IsQteEnd && !this.IsQtePause;
	}

	// Token: 0x060132FD RID: 78589 RVA: 0x00553710 File Offset: 0x00551910
	public unsafe override void PlayQteStart()
	{
		Singleton<Log>.Instance.Info(ELogModule.CommonQte, ELogAuthor.WWJ, "[CommonQteItemBase] PlayQteStart", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (this.IsQtePlayStart || !this.IsQteActive || this.IsQteEnd || this.IsQtePause || this.CommonQteContext == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CommonQte;
			ELogAuthor author = ELogAuthor.WWJ;
			string message = "[CommonQteItemBase] PlayQteStart Failed";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsQtePlayStart", this.IsQtePlayStart);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsQteActive", this.IsQteActive);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("IsQteEnd", this.IsQteEnd);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("IsQtePause", this.IsQtePause);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("CommonQteContext", this.CommonQteContext != null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			return;
		}
		this.IsQtePlayStart = true;
		this.OnPlayQteStart();
		ControllerBase<CommonQteController>.Instance.SetExpiredTimer(this.CommonQteContext);
	}

	// Token: 0x060132FE RID: 78590 RVA: 0x00553867 File Offset: 0x00551A67
	protected virtual void OnPlayQteStart()
	{
	}

	// Token: 0x060132FF RID: 78591 RVA: 0x0055386C File Offset: 0x00551A6C
	[NullableContext(1)]
	public override void SetQteContext(CommonQteContextBase context)
	{
		if (!this.IsContextMatched(context))
		{
			return;
		}
		this.QteHandle = context.HandleId;
		this.CommonQteContext = (TContextType)((object)context);
		string action = context.GetAction(null);
		if (!string.IsNullOrEmpty(action))
		{
			this.QteAction = action;
			this.OnRefreshActionUi(action);
		}
		this.IsQteInteractive = false;
		object uiConfig = context.GetUiConfig();
		if (uiConfig != null)
		{
			this.ApplyBaseUiConfig(uiConfig);
		}
		this.TryApplyQteUiConfig(uiConfig);
		this.TryApplyQteIcon(context);
		this.RefreshUiOffset();
		this.SetQteActive(context);
		this.PlayQteStart();
	}

	// Token: 0x06013300 RID: 78592 RVA: 0x005538FC File Offset: 0x00551AFC
	[NullableContext(1)]
	private void ApplyBaseUiConfig(object uiConfig)
	{
		FieldInfo field = uiConfig.GetType().GetField("InteractiveTiming");
		if (field != null)
		{
			object value = field.GetValue(uiConfig);
			if (value is ECommonQteInteractiveTiming)
			{
				ECommonQteInteractiveTiming ecommonQteInteractiveTiming = (ECommonQteInteractiveTiming)value;
				this.IsQteInteractive = (ecommonQteInteractiveTiming == ECommonQteInteractiveTiming.始终);
			}
		}
	}

	// Token: 0x06013301 RID: 78593 RVA: 0x00553944 File Offset: 0x00551B44
	[NullableContext(1)]
	protected virtual bool IsContextMatched(CommonQteContextBase context)
	{
		return context is TContextType;
	}

	// Token: 0x06013302 RID: 78594 RVA: 0x0055394F File Offset: 0x00551B4F
	[NullableContext(1)]
	protected virtual void OnRefreshActionUi(string action)
	{
	}

	// Token: 0x06013303 RID: 78595 RVA: 0x00553951 File Offset: 0x00551B51
	protected virtual void TryApplyQteUiConfig(object uiConfig)
	{
	}

	// Token: 0x06013304 RID: 78596 RVA: 0x00553954 File Offset: 0x00551B54
	[NullableContext(1)]
	protected virtual void TryApplyQteIcon(CommonQteContextBase context)
	{
		IQteResource resource = context.Resource;
		ULGUITexturePackerSpriteData ulguitexturePackerSpriteData = (resource != null) ? resource.Icon : null;
		if (ulguitexturePackerSpriteData != null)
		{
			this.OnRefreshIcon(ulguitexturePackerSpriteData);
		}
	}

	// Token: 0x06013305 RID: 78597 RVA: 0x0055397E File Offset: 0x00551B7E
	[NullableContext(1)]
	protected virtual void OnRefreshIcon(ULGUITexturePackerSpriteData sprite)
	{
	}

	// Token: 0x06013306 RID: 78598 RVA: 0x00553980 File Offset: 0x00551B80
	[NullableContext(1)]
	protected void SetQteActive(CommonQteContextBase context)
	{
		this.IsQteActive = true;
		this.ClearTickTimer();
		this.TickTimer = TimerSystem.Instance.Forever(new TTimerAction(this.Tick), this.TickInterval, 1f, null, null, true);
		if (context.IsAttachToActor())
		{
			SCommonQte_Attach? attachConfig = context.GetAttachConfig();
			if (attachConfig != null && attachConfig.GetValueOrDefault().UseTargetScreenPos)
			{
				this.AttachToTargetScreenPos(context);
			}
			else
			{
				this.AttachToTarget(context);
			}
			if (Singleton<Time>.Instance.TimeDilation == 0f)
			{
				this.PauseQte();
			}
		}
		else if (context.Source.GetValueOrDefault() == EQteSource.CG)
		{
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.VideoView);
			if (viewByName != null)
			{
				UUIItem rootItem = viewByName.GetRootItem();
				if (rootItem != null)
				{
					this.GetOriginalItem().SetUIParent(rootItem, false);
				}
			}
		}
		else
		{
			EQteSource? source = context.Source;
			EQteSource eqteSource = EQteSource.Battle;
			if (source.GetValueOrDefault() == eqteSource & source != null)
			{
				bool childVisible = ModelBase<BattleUiModel>.Instance.ChildViewData.GetChildVisible(EBattleUiChild.PanelQTE);
				if (base.GetActive() != childVisible)
				{
					this.SetActive(childVisible);
				}
				if (!childVisible || Singleton<Time>.Instance.TimeDilation == 0f)
				{
					this.PauseQte();
				}
			}
			else if (context.Source.GetValueOrDefault() == EQteSource.Level && Singleton<Time>.Instance.TimeDilation == 0f)
			{
				this.PauseQte();
			}
		}
		this.BindEvents();
		if (!this.IsQtePause)
		{
			this.BindAction();
		}
	}

	// Token: 0x06013307 RID: 78599 RVA: 0x00553B00 File Offset: 0x00551D00
	[NullableContext(1)]
	protected void AttachToTarget(CommonQteContextBase context)
	{
		SCommonQte_Attach? attachConfig = context.GetAttachConfig();
		AActor attachTarget = context.GetAttachTarget();
		if (attachConfig == null || attachTarget == null)
		{
			return;
		}
		SCommonQte_Attach value = attachConfig.Value;
		this.OffsetRotator = Rotator.Create((float)value.Rotation.X, (float)value.Rotation.Y, (float)value.Rotation.Z);
		this.TempRotator = Rotator.Create();
		this.IsKeepRelativeToCamera = value.KeepRelativeToCamera;
		this.AttachTarget = attachTarget;
		USceneComponent parent = attachTarget.GetComponentByClass(USceneComponent.StaticClass()) as USceneComponent;
		AUIBaseActor rootActor = this.RootActor;
		if (rootActor != null)
		{
			rootActor.K2_AttachToComponent(parent, null, EAttachmentRule.KeepRelative, this.IsKeepRelativeToCamera ? EAttachmentRule.KeepWorld : EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
		}
		this.UpdateRelativeRotation();
		Vector vector = Vector.Create(value.Location.X, value.Location.Y, value.Location.Z);
		FHitResult fhitResult = null;
		AUIBaseActor rootActor2 = this.RootActor;
		if (rootActor2 != null)
		{
			rootActor2.D_K2_SetActorRelativeLocation(vector.ToUeVector(false), false, ref fhitResult, true);
		}
		IQteResource resource = context.Resource;
		this.ScaleCurve = ((resource != null) ? resource.ScaleCurve : null);
		if (this.ScaleCurve != null)
		{
			this.TargetLocation = Vector.Create();
			this.ScaleVector = Vector.Create(1.0, 1.0, 1.0);
			this.UpdateScale();
		}
		this.IsAttaching = true;
		base.SetUiActive(true);
		if (context.Source.GetValueOrDefault() == EQteSource.Plot)
		{
			AActor uiRoot = Singleton<UiLayer>.Instance.UiRoot;
			ULGUIScreenSpaceInteraction ulguiscreenSpaceInteraction = ((uiRoot != null) ? uiRoot.GetComponentByClass(ULGUIScreenSpaceInteraction.StaticClass()) : null) as ULGUIScreenSpaceInteraction;
			AActor worldSpaceUiRoot = Singleton<UiLayer>.Instance.WorldSpaceUiRoot;
			ULGUIWorldSpaceInteraction ulguiworldSpaceInteraction = ((worldSpaceUiRoot != null) ? worldSpaceUiRoot.GetComponentByClass(ULGUIWorldSpaceInteraction.StaticClass()) : null) as ULGUIWorldSpaceInteraction;
			if (ulguiscreenSpaceInteraction != null && ulguiworldSpaceInteraction != null)
			{
				this.WorldUiRootOriginalDepth = new int?(ulguiworldSpaceInteraction.depth);
				ulguiworldSpaceInteraction.depth = ulguiscreenSpaceInteraction.depth + 1;
			}
		}
	}

	// Token: 0x06013308 RID: 78600 RVA: 0x00553CF4 File Offset: 0x00551EF4
	private void UpdateRelativeRotation()
	{
		UUIItem attachRootItem = this.GetAttachRootItem();
		if (attachRootItem != null && this.TempRotator != null && this.OffsetRotator != null)
		{
			FRotator frotator;
			if (this.IsKeepRelativeToCamera)
			{
				Rotator cameraRotator = ControllerBase<CameraController>.Instance.MainModel.CameraRotator;
				float num = cameraRotator.Pitch - 90f;
				float num2 = cameraRotator.Yaw + 90f;
				this.TempRotator.Roll = this.OffsetRotator.Roll + num;
				this.TempRotator.Pitch = this.OffsetRotator.Pitch;
				this.TempRotator.Yaw = this.OffsetRotator.Yaw + num2;
				UUIItem uuiitem = attachRootItem;
				frotator = this.TempRotator.ToUeRotator();
				uuiitem.SetUIWorldRotation(frotator);
				return;
			}
			this.TempRotator.Roll = this.OffsetRotator.Roll - 90f;
			this.TempRotator.Pitch = this.OffsetRotator.Pitch;
			this.TempRotator.Yaw = this.OffsetRotator.Yaw;
			UUIItem uuiitem2 = attachRootItem;
			frotator = this.TempRotator.ToUeRotator();
			uuiitem2.SetUIRelativeRotation(frotator);
		}
	}

	// Token: 0x06013309 RID: 78601 RVA: 0x00553E10 File Offset: 0x00552010
	[NullableContext(1)]
	protected void AttachToTargetScreenPos(CommonQteContextBase context)
	{
		SCommonQte_Attach? attachConfig = context.GetAttachConfig();
		AActor attachTarget = context.GetAttachTarget();
		if (attachConfig == null || attachTarget == null)
		{
			return;
		}
		SCommonQte_Attach value = attachConfig.Value;
		this.IsUseTargetScreenPos = value.UseTargetScreenPos;
		this.AttachTarget = attachTarget;
		if (!this.IsInitPositionRef)
		{
			this.IsInitPositionRef = true;
			UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
			this.UiRootSize = Vector2D.Create((double)((uiRootItem != null) ? uiRootItem.GetWidth() : 0f), (double)((uiRootItem != null) ? uiRootItem.GetHeight() : 0f));
			this.PointTransform = Vector2D.Create(1.0, -1.0);
			this.UiPositionOffset = Vector2D.Create(value.Location.X, value.Location.Y);
			this.OffsetRotator = Rotator.Create((float)value.Rotation.X, (float)value.Rotation.Y, (float)value.Rotation.Z);
		}
		this.UpdateScreenPosition();
		this.IsAttaching = true;
		base.SetUiActive(true);
	}

	// Token: 0x0601330A RID: 78602 RVA: 0x00553F20 File Offset: 0x00552120
	protected void UpdateScreenPosition()
	{
		if (this.AttachTarget == null || !this.AttachTarget.IsValid())
		{
			return;
		}
		APlayerController characterController = Global.CharacterController;
		FVectorDouble fvectorDouble = this.AttachTarget.D_K2_GetActorLocation();
		if (!UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble, ref this.ScreenPositionRef, false))
		{
			return;
		}
		FVector2D screenPositionRef = this.ScreenPositionRef;
		Global.CharacterController.GetViewportSize(ref this.ViewportSizeX, ref this.ViewportSizeY);
		int viewportSizeX = this.ViewportSizeX;
		if (this.UiRootSize == null || this.PointTransform == null || this.UiPositionOffset == null)
		{
			return;
		}
		Vector2D vector2D = Vector2D.Create();
		vector2D.FromUeVector2D(screenPositionRef);
		vector2D.MultiplyEqual((double)((float)(this.UiRootSize.X / (double)viewportSizeX)));
		Vector2D vector2D2 = Vector2D.Create();
		this.UiRootSize.Multiply(0.5, vector2D2);
		vector2D.SubtractionEqual(vector2D2);
		vector2D.MultiplyEqual(this.PointTransform);
		vector2D.AdditionEqual(this.UiPositionOffset);
		UUIItem attachRootItem = this.GetAttachRootItem();
		if (attachRootItem != null)
		{
			attachRootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
		}
		if (this.OffsetRotator != null && attachRootItem != null)
		{
			UUIItem uuiitem = attachRootItem;
			FRotator frotator = this.OffsetRotator.ToUeRotator();
			uuiitem.SetUIRelativeRotation(frotator);
		}
	}

	// Token: 0x0601330B RID: 78603 RVA: 0x00554048 File Offset: 0x00552248
	protected void UpdateScale()
	{
		if (this.AttachTarget == null || this.ScaleCurve == null || this.TargetLocation == null || this.ScaleVector == null)
		{
			return;
		}
		Vector cameraLocation = ControllerBase<CameraController>.Instance.MainModel.CameraLocation;
		FVectorDouble fvectorDouble = this.AttachTarget.D_K2_GetActorLocation();
		this.TargetLocation.FromUeVector(fvectorDouble);
		double num = Vector.DistSquared(cameraLocation, this.TargetLocation);
		CommonQteModel instance = ModelBase<CommonQteModel>.Instance;
		if (instance != null)
		{
			bool isRefreshMode = instance.IsRefreshMode;
		}
		float floatValue = this.ScaleCurve.GetFloatValue((float)num);
		if (floatValue <= 0f)
		{
			return;
		}
		if (Math.Abs((float)(this.ScaleVector.Z - (double)floatValue)) > 0.01f)
		{
			this.ScaleVector.X = (double)floatValue;
			this.ScaleVector.Y = (double)floatValue;
			this.ScaleVector.Z = (double)floatValue;
			UUIItem attachRootItem = this.GetAttachRootItem();
			if (attachRootItem == null)
			{
				return;
			}
			FVector fvector = this.ScaleVector.ToUeVectorOld();
			attachRootItem.SetUIRelativeScale3D(fvector);
		}
	}

	// Token: 0x0601330C RID: 78604 RVA: 0x00554133 File Offset: 0x00552333
	protected void ClearTickTimer()
	{
		if (this.TickTimer != null)
		{
			TimerSystem.Instance.Remove(this.TickTimer);
			this.TickTimer = null;
		}
	}

	// Token: 0x0601330D RID: 78605 RVA: 0x00554155 File Offset: 0x00552355
	protected UUIItem GetAttachRootItem()
	{
		return this.AttachRootItem ?? this.GetOriginalItem();
	}

	// Token: 0x0601330E RID: 78606 RVA: 0x00554167 File Offset: 0x00552367
	protected void SetAttachRootItem(UUIItem item)
	{
		this.AttachRootItem = item;
	}

	// Token: 0x0601330F RID: 78607 RVA: 0x00554170 File Offset: 0x00552370
	[NullableContext(1)]
	public override void Reattach(CommonQteContextBase context)
	{
		this.IsInitPositionRef = false;
		if (this.IsUseTargetScreenPos)
		{
			this.AttachToTargetScreenPos(context);
			return;
		}
		this.AttachToTarget(context);
	}

	// Token: 0x06013310 RID: 78608 RVA: 0x00554190 File Offset: 0x00552390
	protected virtual void RefreshUiOffset()
	{
	}

	// Token: 0x040095A9 RID: 38313
	private const float SCALE_TOLERATION = 0.01f;

	// Token: 0x040095AA RID: 38314
	protected bool IsMobile;

	// Token: 0x040095AB RID: 38315
	protected bool IsQteActive;

	// Token: 0x040095AC RID: 38316
	protected bool IsQtePlayStart;

	// Token: 0x040095AD RID: 38317
	protected bool IsQteStart;

	// Token: 0x040095AE RID: 38318
	protected bool IsQteEnd;

	// Token: 0x040095AF RID: 38319
	protected bool IsQteInteractive;

	// Token: 0x040095B0 RID: 38320
	protected bool IsQtePause;

	// Token: 0x040095B1 RID: 38321
	protected bool HasBindAction;

	// Token: 0x040095B2 RID: 38322
	[Nullable(1)]
	protected string QteAction = "";

	// Token: 0x040095B3 RID: 38323
	protected int QteHandle = -1;

	// Token: 0x040095B4 RID: 38324
	protected TContextType CommonQteContext;

	// Token: 0x040095B5 RID: 38325
	protected bool IsBindEvents;

	// Token: 0x040095B6 RID: 38326
	protected TimerHandle TickTimer;

	// Token: 0x040095B7 RID: 38327
	protected Number TickInterval = 20;

	// Token: 0x040095B8 RID: 38328
	protected bool IsAttaching;

	// Token: 0x040095B9 RID: 38329
	protected bool IsKeepRelativeToCamera;

	// Token: 0x040095BA RID: 38330
	protected bool IsUseTargetScreenPos;

	// Token: 0x040095BB RID: 38331
	protected Rotator OffsetRotator;

	// Token: 0x040095BC RID: 38332
	protected Rotator TempRotator;

	// Token: 0x040095BD RID: 38333
	protected bool IsInitPositionRef;

	// Token: 0x040095BE RID: 38334
	protected FVector2D ScreenPositionRef;

	// Token: 0x040095BF RID: 38335
	protected int ViewportSizeX;

	// Token: 0x040095C0 RID: 38336
	protected int ViewportSizeY;

	// Token: 0x040095C1 RID: 38337
	protected Vector2D UiRootSize;

	// Token: 0x040095C2 RID: 38338
	protected Vector2D PointTransform;

	// Token: 0x040095C3 RID: 38339
	protected Vector2D UiPositionOffset;

	// Token: 0x040095C4 RID: 38340
	protected AActor AttachTarget;

	// Token: 0x040095C5 RID: 38341
	protected UUIItem AttachRootItem;

	// Token: 0x040095C6 RID: 38342
	protected UCurveFloat ScaleCurve;

	// Token: 0x040095C7 RID: 38343
	protected Vector ScaleVector;

	// Token: 0x040095C8 RID: 38344
	protected Vector TargetLocation;

	// Token: 0x040095C9 RID: 38345
	private int? WorldUiRootOriginalDepth;
}
