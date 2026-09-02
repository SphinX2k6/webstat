using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FD0 RID: 24528
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleSkillItem : BattleChildView
	{
		// Token: 0x17009A7D RID: 39549
		// (get) Token: 0x0603DB0D RID: 252685 RVA: 0x00FB660C File Offset: 0x00FB480C
		[Nullable(1)]
		protected BattleSkillUltraItem GetUltraComponent
		{
			[NullableContext(1)]
			get
			{
				if (this.UltraComponent == null)
				{
					UUIItem item = base.GetItem(8);
					this.UltraComponent = new BattleSkillUltraItem(item);
				}
				return this.UltraComponent;
			}
		}

		// Token: 0x17009A7E RID: 39550
		// (get) Token: 0x0603DB0E RID: 252686 RVA: 0x00FB663C File Offset: 0x00FB483C
		protected BattleSkillNumItem GetNumComponent
		{
			get
			{
				if (this.IsHideNumComp)
				{
					return null;
				}
				if (this.NumComponent == null)
				{
					UUIItem item = base.GetItem(8);
					this.NumComponent = new BattleSkillNumItem(item);
				}
				return this.NumComponent;
			}
		}

		// Token: 0x17009A7F RID: 39551
		// (get) Token: 0x0603DB0F RID: 252687 RVA: 0x00FB6678 File Offset: 0x00FB4878
		protected BattleSkillDotIndicatorItem GetDotIndicatorComponent
		{
			get
			{
				ISkillButtonData skillButtonData = this.SkillButtonData;
				if (skillButtonData == null || !skillButtonData.IsEnableDotIndicator)
				{
					return null;
				}
				if (this.DotIndicatorComponent == null)
				{
					UUIItem item = base.GetItem(8);
					this.DotIndicatorComponent = new BattleSkillDotIndicatorItem(item);
				}
				return this.DotIndicatorComponent;
			}
		}

		// Token: 0x17009A80 RID: 39552
		// (get) Token: 0x0603DB10 RID: 252688 RVA: 0x00FB66C0 File Offset: 0x00FB48C0
		[Nullable(1)]
		protected BattleSkillSwitchComponent GetSwitchComponent
		{
			[NullableContext(1)]
			get
			{
				if (this.SwitchComponent == null)
				{
					UUIItem item = base.GetItem(8);
					this.SwitchComponent = new BattleSkillSwitchComponent();
					this.SwitchComponent.CreateByResourceIdAsync("UiItem_BattleSkillSwitchItem", item, false).Forget();
				}
				return this.SwitchComponent;
			}
		}

		// Token: 0x17009A81 RID: 39553
		// (get) Token: 0x0603DB11 RID: 252689 RVA: 0x00FB6708 File Offset: 0x00FB4908
		[Nullable(1)]
		protected BattleSkillLongPressItem GetLongPressComponent
		{
			[NullableContext(1)]
			get
			{
				if (this.LongPressComponent == null)
				{
					UUIItem item = base.GetItem(8);
					this.LongPressComponent = new BattleSkillLongPressItem();
					this.LongPressComponent.CreateByResourceIdAsync("UiItem_BattleSkillLongPressItem", item, false).Forget();
				}
				return this.LongPressComponent;
			}
		}

		// Token: 0x17009A82 RID: 39554
		// (get) Token: 0x0603DB12 RID: 252690 RVA: 0x00FB6750 File Offset: 0x00FB4950
		[Nullable(1)]
		protected BattleSkillConfigLongPressItem GetConfigLongPressComponent
		{
			[NullableContext(1)]
			get
			{
				if (this.ConfigLongPressComponent == null)
				{
					UUIItem item = base.GetItem(8);
					this.ConfigLongPressComponent = new BattleSkillConfigLongPressItem();
					this.ConfigLongPressComponent.CreateByResourceIdAsync("UiItem_BattleSkillLongPressItem", item, false).Forget();
				}
				return this.ConfigLongPressComponent;
			}
		}

		// Token: 0x0603DB13 RID: 252691 RVA: 0x00FB6795 File Offset: 0x00FB4995
		protected UUIItem GetExtraContainer()
		{
			return base.GetItem(8);
		}

		// Token: 0x0603DB14 RID: 252692 RVA: 0x00FB679E File Offset: 0x00FB499E
		protected virtual UUIButtonComponent GetPointEventButton()
		{
			return this.SkillButton;
		}

		// Token: 0x0603DB15 RID: 252693 RVA: 0x00FB67A8 File Offset: 0x00FB49A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(13, typeof(UUISprite)));
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(14, typeof(UUIItem)));
			}
		}

		// Token: 0x0603DB16 RID: 252694 RVA: 0x00FB69C8 File Offset: 0x00FB4BC8
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			if (param is int)
			{
				int inputIndex = (int)param;
				this.InputIndex = inputIndex;
			}
			this.SkillButton = base.GetButton(5);
			this.CoolDownUiItem = base.GetItem(0);
			this.CoolDownUiText = base.GetText(2);
			this.CoolDownBarUiSprite = base.GetSprite(1);
			this.SkillTexture = base.GetTexture(4);
			this.SkillSprite = base.GetSprite(3);
			this.SkillTextureTransitionComp = (this.SkillTexture.GetOwner().GetComponentByClass(UUITextureTransitionComponent.StaticClass()) as UUITextureTransitionComponent);
			this.SkillSpriteTransitionComp = (this.SkillSprite.GetOwner().GetComponentByClass(UUISpriteTransition.StaticClass()) as UUISpriteTransition);
			this.DefaultSkillTextureData = this.SkillTexture.GetTexture();
			this.DefaultSkillSpriteData = this.SkillSprite.GetSprite();
			this.IsDefaultSkillTexture = true;
			this.IsDefaultSkillSprite = true;
			this.SkillNameText = base.GetText(11);
			this.ClickEffect = new BattleUiNiagaraItem(base.GetUiNiagara(10));
			this.DynamicEffect = new BattleSkillItemDynamicEffect(base.GetUiNiagara(7));
			base.GetUiNiagara(6).SetNiagaraUIActive(false, false);
			base.GetUiNiagara(7).SetNiagaraUIActive(false, true);
			this.AddEvents();
		}

		// Token: 0x0603DB17 RID: 252695 RVA: 0x00FB6B10 File Offset: 0x00FB4D10
		protected override UniTask InitializeAsync(object param = null)
		{
			BattleSkillItem.<InitializeAsync>d__82 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<BattleSkillItem.<InitializeAsync>d__82>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DB18 RID: 252696 RVA: 0x00FB6B54 File Offset: 0x00FB4D54
		public virtual void Refresh(ISkillButtonData skillButtonData)
		{
			if (this.SkillButtonData != skillButtonData)
			{
				this.TryReleaseButton();
				BattleUiNiagaraItem clickEffect = this.ClickEffect;
				if (clickEffect != null)
				{
					clickEffect.Stop();
				}
				BattleSkillExtraEffectItem extraEffectComponent = this.ExtraEffectComponent;
				if (extraEffectComponent != null)
				{
					extraEffectComponent.Stop();
				}
				ModelBase<BattleUiModel>.Instance.SlideControlData.OnRelease(this.RootItem);
			}
			if (skillButtonData == null)
			{
				return;
			}
			this.SkillButtonData = skillButtonData;
			this.InitVehicleHandle();
			this.RefreshVisible();
			this.RefreshSkillIcon();
			this.RefreshSkillName();
			this.RefreshCdCompletedEffect();
			this.RefreshDynamicEffect();
			this.RefreshKey();
			this.RefreshTimeDilation();
			this.RefreshSkillCoolDown();
			this.RefreshLimitCount(true);
			this.RefreshDotIndicator(true);
			this.RefreshConfigLongPress(-1, 0);
			this.RefreshAttribute(false);
			if (this.RefreshSwitchComponentVisible())
			{
				this.RefreshEquipExplore();
			}
			this.RefreshSkillButtonLongPress();
			this.RefreshSlideControl();
			if (this.HasBattleLinkEvent)
			{
				this.RefreshLinkStatus(new int?(this.LinkStatus));
			}
		}

		// Token: 0x0603DB19 RID: 252697 RVA: 0x00FB6C38 File Offset: 0x00FB4E38
		public virtual void Deactivate()
		{
			this.TryReleaseButton();
			this.ResetSkillCoolDown();
			this.RemoveLongPressTimer();
			this.RemoveEquipEffectTimer();
			ModelBase<BattleUiModel>.Instance.SlideControlData.OnRelease(this.RootItem);
			this.SkillButtonData = null;
			this.SetTextureHandleId = 0;
			this.OnCoolDownFinishedCallback = null;
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem != null)
			{
				keyItem.SetActive(false);
			}
			InputMultiKeyItem keyItem2 = this.KeyItem;
			if (keyItem2 != null)
			{
				keyItem2.ResetLongPress();
			}
			this.KeyActionName = null;
			this.KeyOperationType = null;
			this.PressActionType = CSharpScript.Game.Input.EInputAction.None;
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect != null)
			{
				clickEffect.Stop();
			}
			this.LinkStatus = 0;
			BattleSkillItemDynamicEffect dynamicEffect = this.DynamicEffect;
			if (dynamicEffect != null)
			{
				dynamicEffect.Reset();
			}
			this.CancelLoadCdCompletedNiagara();
			this.HideAndClearSkillSprite("休眠技能按钮");
			this.HideAndClearSkillTexture();
			this.SkillIconPath = null;
			if (this.UltraComponent != null)
			{
				this.UltraComponent.Destroy(null);
				this.UltraComponent = null;
			}
			if (this.NumComponent != null)
			{
				this.NumComponent.Destroy(null);
				this.NumComponent = null;
			}
			if (this.DotIndicatorComponent != null)
			{
				this.DotIndicatorComponent.Destroy(null);
				this.DotIndicatorComponent = null;
			}
			if (this.SwitchComponent != null)
			{
				this.SwitchComponent.Destroy(null);
				this.SwitchComponent = null;
			}
			if (this.LongPressComponent != null)
			{
				this.LongPressComponent.Destroy(null);
				this.LongPressComponent = null;
			}
			if (this.ExtraEffectComponent != null)
			{
				this.ExtraEffectComponent.Stop();
				this.ExtraEffectComponent.Destroy(null);
				this.ExtraEffectComponent = null;
			}
			this.OnRefreshVisible(false);
			this.OnDeactivate();
		}

		// Token: 0x0603DB1A RID: 252698 RVA: 0x00FB6DC9 File Offset: 0x00FB4FC9
		protected override void OnShowBattleChildView()
		{
			UUIItem parentItem = this.ParentItem;
			if (parentItem == null)
			{
				return;
			}
			parentItem.SetUIActive(true);
		}

		// Token: 0x0603DB1B RID: 252699 RVA: 0x00FB6DDC File Offset: 0x00FB4FDC
		protected override void OnHideBattleChildView()
		{
			UUIItem parentItem = this.ParentItem;
			if (parentItem == null)
			{
				return;
			}
			parentItem.SetUIActive(false);
		}

		// Token: 0x0603DB1C RID: 252700 RVA: 0x00FB6DEF File Offset: 0x00FB4FEF
		public void UpdateAlpha()
		{
			this.BaseAlpha = this.RootItem.GetAlpha();
			if (this.BaseAlpha > this.TargetAlpha)
			{
				this.RootItem.SetAlpha(this.TargetAlpha);
				return;
			}
			this.TargetAlpha = this.BaseAlpha;
		}

		// Token: 0x0603DB1D RID: 252701 RVA: 0x00FB6E30 File Offset: 0x00FB5030
		public override void Reset()
		{
			this.RemoveEvents();
			this.Deactivate();
			this.SkillButton = null;
			this.KeyItem = null;
			this.ClickEffect = null;
			this.SkillIconPath = null;
			this.AlphaTweenComp = null;
			this.SkillTexture = null;
			this.SkillSprite = null;
			this.SkillTextureTransitionComp = null;
			this.SkillSpriteTransitionComp = null;
			this.DefaultSkillTextureData = null;
			this.DefaultSkillSpriteData = null;
			this.OnVisibleChangedCallback = null;
			base.Reset();
		}

		// Token: 0x0603DB1E RID: 252702 RVA: 0x00FB6EA3 File Offset: 0x00FB50A3
		public virtual void Tick(float delta)
		{
			this.TickSkillCoolDown(delta);
			BattleSkillConfigLongPressItem configLongPressComponent = this.ConfigLongPressComponent;
			if (configLongPressComponent == null)
			{
				return;
			}
			configLongPressComponent.Tick(delta);
		}

		// Token: 0x0603DB1F RID: 252703 RVA: 0x00FB6EC0 File Offset: 0x00FB50C0
		protected void AddEvents()
		{
			if (this.IsAddedEvents)
			{
				return;
			}
			this.GetPointEventButton().OnPointDownCallBack.Bind(new Action(this.OnSkillButtonPressed));
			this.GetPointEventButton().OnPointUpCallBack.Bind(new Action(this.OnSkillButtonPointUp));
			this.GetPointEventButton().OnPointCancelCallBack.Bind(new Action(this.OnSkillButtonCancel));
			this.DraggableComponent = (this.GetPointEventButton().GetOwner().GetComponentByClass(UUIDraggableComponent.StaticClass()) as UUIDraggableComponent);
			int[] touchIdList = new int[]
			{
				0,
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8,
				9
			};
			ControllerBase<InputDistributeController>.Instance.BindTouches(touchIdList, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
			if (ModelBase<BattleLinkModel>.Instance.CheckInBattleLink())
			{
				this.HasBattleLinkEvent = true;
				Singleton<EventSystem>.Instance.Add<ELinkStatus>(EEventName.OnBattleLinkStatusChanged, new Action<ELinkStatus>(this.OnBattleLinkStatusChanged));
			}
			Singleton<EventSystem>.Instance.Add(EEventName.OnSwitchSelfCenteredMode, new Action<ESelfCenteredMode, float>(this.OnSelfCenteredMode));
			this.IsAddedEvents = true;
		}

		// Token: 0x0603DB20 RID: 252704 RVA: 0x00FB6FD0 File Offset: 0x00FB51D0
		protected void RemoveEvents()
		{
			if (!this.IsAddedEvents)
			{
				return;
			}
			if (this.GetPointEventButton() != null)
			{
				this.GetPointEventButton().OnPointDownCallBack.Unbind();
				this.GetPointEventButton().OnPointUpCallBack.Unbind();
				this.GetPointEventButton().OnPointCancelCallBack.Unbind();
			}
			int[] touchIdList = new int[]
			{
				0,
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8,
				9
			};
			ControllerBase<InputDistributeController>.Instance.UnBindTouches(touchIdList, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
			if (this.HasBattleLinkEvent)
			{
				this.HasBattleLinkEvent = false;
				Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleLinkStatusChanged, new Action<ELinkStatus>(this.OnBattleLinkStatusChanged));
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSwitchSelfCenteredMode, new Action<ESelfCenteredMode, float>(this.OnSelfCenteredMode));
			this.IsAddedEvents = false;
		}

		// Token: 0x0603DB21 RID: 252705 RVA: 0x00FB7097 File Offset: 0x00FB5297
		protected void OnSelfCenteredMode(ESelfCenteredMode selfCenteredMode, float dilation)
		{
			if (TimerSystem.Instance.Has(this.ChangeCoolDownRefreshTimerId))
			{
				TimerSystem.Instance.ChangeDilation(this.ChangeCoolDownRefreshTimerId, 1f / dilation, null);
			}
		}

		// Token: 0x0603DB22 RID: 252706 RVA: 0x00FB70C4 File Offset: 0x00FB52C4
		protected void OnBattleLinkStatusChanged(ELinkStatus status)
		{
			this.RefreshLinkStatus(new int?((int)status));
		}

		// Token: 0x0603DB23 RID: 252707 RVA: 0x00FB70D4 File Offset: 0x00FB52D4
		protected void RefreshLinkStatus(int? status = null)
		{
			int num = status ?? this.LinkStatus;
			this.LinkStatus = num;
			if (this.SkillButtonData == null)
			{
				return;
			}
			CSharpScript.Game.Input.EInputAction actionType = this.SkillButtonData.GetActionType();
			if (actionType != CSharpScript.Game.Input.EInputAction.大招 && actionType != CSharpScript.Game.Input.EInputAction.技能1 && actionType != CSharpScript.Game.Input.EInputAction.攻击 && actionType != CSharpScript.Game.Input.EInputAction.幻象2)
			{
				if (this.IsPlayingLinkEffect)
				{
					base.GetUiNiagara(12).SetNiagaraUIActive(false, true);
					this.IsPlayingLinkEffect = false;
				}
				return;
			}
			if (actionType == CSharpScript.Game.Input.EInputAction.大招)
			{
				this.SetUltraComponentVisible(num != 4, BattleSkillItem.EUltraComponentVisibleReason.Link);
			}
			if (num == 4)
			{
				base.GetUiNiagara(12).SetNiagaraUIActive(true, true);
				this.IsPlayingLinkEffect = true;
				return;
			}
			base.GetUiNiagara(12).SetNiagaraUIActive(false, true);
			this.IsPlayingLinkEffect = false;
		}

		// Token: 0x0603DB24 RID: 252708 RVA: 0x00FB71B8 File Offset: 0x00FB53B8
		[NullableContext(1)]
		protected virtual void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification inputIdentification)
		{
			if (!this.IsLongPress && !this.EnableSlideControl)
			{
				return;
			}
			InputDistributeDefine.ETouchType touchType = touchData.TouchType;
			int fingerIndex = int.Parse(touchIdName);
			TouchFingerData touchFingerData = Singleton<TouchFingerManager>.Instance.GetTouchFingerData((EFingerIndex)fingerIndex);
			USceneComponent usceneComponent;
			if (touchFingerData == null)
			{
				usceneComponent = null;
			}
			else
			{
				ULGUIPointerEventData pointerEventData = touchFingerData.GetPointerEventData();
				usceneComponent = ((pointerEventData != null) ? pointerEventData.pressComponent : null);
			}
			USceneComponent usceneComponent2 = usceneComponent;
			if (usceneComponent2 == null)
			{
				return;
			}
			if (usceneComponent2.GetOwner() != this.SkillButton.GetOwner())
			{
				return;
			}
			if (this.EnableSlideControl)
			{
				ModelBase<BattleUiModel>.Instance.SlideControlData.OnTouch(touchData);
				return;
			}
			if (touchType != InputDistributeDefine.ETouchType.TouchMove)
			{
				return;
			}
			ControllerBase<ControlScreenController>.Instance.ExecuteCameraRotation((EFingerIndex)fingerIndex);
		}

		// Token: 0x0603DB25 RID: 252709 RVA: 0x00FB724C File Offset: 0x00FB544C
		protected virtual void OnSkillButtonPressed()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			if (this.SkillButtonData.IsEnableSlideControl)
			{
				FVector relativeLocation = this.RootItem.RelativeLocation;
				FVector relativeScale3D = this.RootItem.RelativeScale3D;
				ModelBase<BattleUiModel>.Instance.SlideControlData.OnPress(this.RootItem, relativeLocation.X - 120f * relativeScale3D.X, relativeLocation.Y + 120f * relativeScale3D.Y);
				this.EnableSlideControl = true;
				return;
			}
			this.EnableSlideControl = false;
			if (this.SkillButtonData.IsEnableInput() && this.TargetAlpha != 0f)
			{
				CSharpScript.Game.Input.EInputAction actionType = this.SkillButtonData.GetActionType();
				this.OnInputAction(false);
				this.PressActionType = actionType;
				if (Singleton<Info>.Instance.OperationType == EOperationType.Pad)
				{
					string inputAction = this.SkillButtonData.GetInputAction();
					ControllerBase<InputDistributeController>.Instance.InputAction(inputAction, true);
				}
				else
				{
					ControllerBase<InputController>.Instance.InputAction(actionType, EInputState.Press);
				}
			}
			if (!this.IsNeedLongPress())
			{
				return;
			}
			double longPressTime = this.SkillButtonData.GetLongPressTime();
			if (longPressTime <= 0.0)
			{
				this.SkillButtonData.RefreshLongPressTime();
				longPressTime = this.SkillButtonData.GetLongPressTime();
			}
			if (longPressTime <= 0.0)
			{
				return;
			}
			this.LongPressTimerId = TimerSystem.Instance.Delay(new TTimerAction(this.OnLongPress), (float)longPressTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
		}

		// Token: 0x0603DB26 RID: 252710 RVA: 0x00FB73B4 File Offset: 0x00FB55B4
		protected virtual bool IsNeedLongPress()
		{
			return this.SkillButtonData.GetIsLongPressControlCamera().Value;
		}

		// Token: 0x0603DB27 RID: 252711 RVA: 0x00FB73D4 File Offset: 0x00FB55D4
		protected void OnSkillButtonPointUp()
		{
			this.OnSkillButtonReleased();
		}

		// Token: 0x0603DB28 RID: 252712 RVA: 0x00FB73DC File Offset: 0x00FB55DC
		protected virtual void OnSkillButtonReleased()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			if (this.EnableSlideControl)
			{
				ModelBase<BattleUiModel>.Instance.SlideControlData.OnRelease(this.RootItem);
				this.EnableSlideControl = false;
			}
			if (this.PressActionType != CSharpScript.Game.Input.EInputAction.None)
			{
				CSharpScript.Game.Input.EInputAction actionType = this.SkillButtonData.GetActionType();
				if (this.PressActionType == actionType)
				{
					if (Singleton<Info>.Instance.OperationType == EOperationType.Pad)
					{
						string inputAction = this.SkillButtonData.GetInputAction();
						ControllerBase<InputDistributeController>.Instance.InputAction(inputAction, false);
					}
					else
					{
						ControllerBase<InputController>.Instance.InputAction(actionType, EInputState.Release);
					}
				}
				else if (Singleton<Info>.Instance.OperationType == EOperationType.Pad)
				{
					ControllerBase<InputDistributeController>.Instance.InputAction(this.PressActionType.Name, false);
				}
				else
				{
					ControllerBase<InputController>.Instance.InputAction(this.PressActionType, EInputState.Release);
				}
			}
			this.PressActionType = CSharpScript.Game.Input.EInputAction.None;
			this.RemoveLongPressTimer();
			this.IsLongPress = false;
		}

		// Token: 0x0603DB29 RID: 252713 RVA: 0x00FB74CA File Offset: 0x00FB56CA
		protected virtual void OnSkillButtonCancel()
		{
			this.OnSkillButtonReleased();
		}

		// Token: 0x0603DB2A RID: 252714 RVA: 0x00FB74D2 File Offset: 0x00FB56D2
		public void TryReleaseButton()
		{
			if (this.PressActionType != CSharpScript.Game.Input.EInputAction.None)
			{
				this.OnSkillButtonReleased();
			}
		}

		// Token: 0x0603DB2B RID: 252715 RVA: 0x00FB74EC File Offset: 0x00FB56EC
		private void OnLongPress(float _)
		{
			this.IsLongPress = true;
			this.OnLongPressButton();
		}

		// Token: 0x0603DB2C RID: 252716 RVA: 0x00FB74FB File Offset: 0x00FB56FB
		protected virtual void OnLongPressButton()
		{
		}

		// Token: 0x0603DB2D RID: 252717 RVA: 0x00FB7500 File Offset: 0x00FB5700
		public void SetSkillIcon(string skillIconPath)
		{
			if (string.IsNullOrEmpty(skillIconPath))
			{
				return;
			}
			if (this.SkillIconPath == skillIconPath)
			{
				return;
			}
			if (this.SetTextureHandleId != 0)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.SetTextureHandleId);
			}
			this.IsLoadingSkillIcon = true;
			UUITexture skillTexture = this.SkillTexture;
			UUISprite skillSprite = this.SkillSprite;
			this.SkillIconPath = skillIconPath;
			if (this.CheckSkillIconIsTexture(skillIconPath))
			{
				if (skillSprite != null)
				{
					this.HideAndClearSkillSprite("资源类型是Texture");
				}
				this.SetTextureHandleId = Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(skillIconPath, delegate([Nullable(2)] UTexture skillIconTexture, string _)
				{
					this.IsLoadingSkillIcon = false;
					if (skillTexture == null || this.SkillIconPath != skillIconPath)
					{
						return;
					}
					if (skillIconTexture == null)
					{
						this.HideAndClearSkillTexture();
						return;
					}
					this.ShowAndSetSkillTexture(skillIconTexture);
				}, 103, "js_undefined");
				this.SkillIconPath = skillIconPath;
				if (this.IsLoadingSkillIcon)
				{
					skillTexture.SetUIActive(false);
					return;
				}
			}
			else
			{
				this.HideAndClearSkillTexture();
				this.SetTextureHandleId = Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(skillIconPath, delegate([Nullable(2)] ULGUISpriteData_BaseObject skillIconSprite, string _)
				{
					this.IsLoadingSkillIcon = false;
					if (skillSprite == null || this.SkillIconPath != skillIconPath)
					{
						return;
					}
					if (skillIconSprite == null)
					{
						this.HideAndClearSkillSprite("技能图标加载资源失败");
						return;
					}
					this.ShowAndSetSkillSprite(skillIconSprite);
				}, 103, "js_undefined");
				if (this.IsLoadingSkillIcon)
				{
					skillSprite.SetUIActive(false);
				}
			}
		}

		// Token: 0x0603DB2E RID: 252718 RVA: 0x00FB7634 File Offset: 0x00FB5834
		[NullableContext(1)]
		protected virtual bool CheckSkillIconIsTexture(string skillIconPath)
		{
			return skillIconPath.Contains("Image/");
		}

		// Token: 0x0603DB2F RID: 252719 RVA: 0x00FB7644 File Offset: 0x00FB5844
		protected void HideAndClearSkillTexture()
		{
			if (this.SkillTexture == null)
			{
				return;
			}
			if (!this.IsDefaultSkillTexture)
			{
				this.SkillTexture.SetTexture(this.DefaultSkillTextureData);
				UUITextureTransitionComponent skillTextureTransitionComp = this.SkillTextureTransitionComp;
				if (skillTextureTransitionComp != null)
				{
					skillTextureTransitionComp.SetAllStateTexture(this.DefaultSkillTextureData);
				}
				this.IsDefaultSkillTexture = true;
			}
			this.SkillTexture.SetUIActive(false);
		}

		// Token: 0x0603DB30 RID: 252720 RVA: 0x00FB769D File Offset: 0x00FB589D
		[NullableContext(1)]
		protected void ShowAndSetSkillTexture(UTexture textureData)
		{
			this.SkillTexture.SetTexture(textureData);
			UUITextureTransitionComponent skillTextureTransitionComp = this.SkillTextureTransitionComp;
			if (skillTextureTransitionComp != null)
			{
				skillTextureTransitionComp.SetAllStateTexture(textureData);
			}
			this.IsDefaultSkillTexture = false;
			this.SkillTexture.SetUIActive(true);
		}

		// Token: 0x0603DB31 RID: 252721 RVA: 0x00FB76D0 File Offset: 0x00FB58D0
		[NullableContext(1)]
		protected void HideAndClearSkillSprite(string reason)
		{
			if (this.SkillSprite == null)
			{
				return;
			}
			if (!this.IsDefaultSkillSprite)
			{
				this.SkillSprite.SetSprite(this.DefaultSkillSpriteData, true);
				UUISpriteTransition skillSpriteTransitionComp = this.SkillSpriteTransitionComp;
				if (skillSpriteTransitionComp != null)
				{
					skillSpriteTransitionComp.SetAllTransitionSprite(this.DefaultSkillSpriteData);
				}
				this.IsDefaultSkillSprite = true;
			}
			this.SkillSprite.SetUIActive(false);
		}

		// Token: 0x0603DB32 RID: 252722 RVA: 0x00FB772A File Offset: 0x00FB592A
		[NullableContext(1)]
		protected void ShowAndSetSkillSprite(ULGUISpriteData_BaseObject spriteData)
		{
			this.SkillSprite.SetSprite(spriteData, true);
			UUISpriteTransition skillSpriteTransitionComp = this.SkillSpriteTransitionComp;
			if (skillSpriteTransitionComp != null)
			{
				skillSpriteTransitionComp.SetAllTransitionSprite(spriteData);
			}
			this.IsDefaultSkillSprite = false;
			this.SkillSprite.SetUIActive(true);
		}

		// Token: 0x0603DB33 RID: 252723 RVA: 0x00FB7760 File Offset: 0x00FB5960
		public virtual void RefreshSkillIcon()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			if (this.SkillButtonData.IsMultiStageSkill().GetValueOrDefault())
			{
				string multiSkillTexturePath = this.SkillButtonData.GetMultiSkillTexturePath();
				this.SetSkillIcon(multiSkillTexturePath);
				return;
			}
			string skillTexturePath = this.SkillButtonData.GetSkillTexturePath();
			this.SetSkillIcon(skillTexturePath);
		}

		// Token: 0x0603DB34 RID: 252724 RVA: 0x00FB77B4 File Offset: 0x00FB59B4
		public virtual void RefreshSkillName()
		{
			ISkillButtonData skillButtonData = this.SkillButtonData;
			int? num = (skillButtonData != null) ? new int?(skillButtonData.GetSkillId()) : null;
			if (num == null)
			{
				this.SkillNameText.SetUIActive(false);
				return;
			}
			string skillIconName = this.SkillButtonData.GetSkillIconName();
			if (!string.IsNullOrEmpty(skillIconName))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(this.SkillNameText, skillIconName, Array.Empty<object>());
				this.SkillNameText.SetUIActive(true);
				return;
			}
			string skillNameBySkillId = ModelBase<SkillButtonUiModel>.Instance.GetSkillNameBySkillId(num.Value);
			if (!string.IsNullOrEmpty(skillNameBySkillId))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(this.SkillNameText, skillNameBySkillId, Array.Empty<object>());
				this.SkillNameText.SetUIActive(true);
				return;
			}
			this.SkillNameText.SetUIActive(false);
		}

		// Token: 0x0603DB35 RID: 252725 RVA: 0x00FB7877 File Offset: 0x00FB5A77
		protected void SetSkillItemEnable(bool bVisible, bool bForce = false)
		{
			if (this.SkillButton == null)
			{
				return;
			}
			if (bForce)
			{
				this.SkillButton.SetSelfInteractive(bVisible);
				return;
			}
			if (this.SkillButton.GetSelfInteractive() != bVisible)
			{
				this.SkillButton.SetSelfInteractive(bVisible);
			}
		}

		// Token: 0x0603DB36 RID: 252726 RVA: 0x00FB78AC File Offset: 0x00FB5AAC
		public virtual void RefreshKey()
		{
			EOperationType operationType = Singleton<Info>.Instance.OperationType;
			if (operationType != EOperationType.Desktop)
			{
				return;
			}
			string actionName = this.SkillButtonData.GetActionName();
			if (this.KeyActionName == actionName)
			{
				EOperationType? keyOperationType = this.KeyOperationType;
				EOperationType eoperationType = operationType;
				if (keyOperationType.GetValueOrDefault() == eoperationType & keyOperationType != null)
				{
					return;
				}
			}
			if (this.KeyItem != null)
			{
				InputActionOrAxisKeyItem actionOrAxisKeyItem = new InputActionOrAxisKeyItem
				{
					ActionOrAxisName = actionName
				};
				this.KeyItem.RefreshByActionOrAxis(actionOrAxisKeyItem, false);
				this.KeyItem.SetActive(true);
			}
			this.KeyOperationType = new EOperationType?(operationType);
			this.KeyActionName = actionName;
		}

		// Token: 0x0603DB37 RID: 252727 RVA: 0x00FB7944 File Offset: 0x00FB5B44
		public void PauseGame(int flag)
		{
			if (flag == 1)
			{
				if (TimerSystem.Instance.Has(this.ChangeCoolDownRefreshTimerId) && !TimerSystem.Instance.IsPause(this.ChangeCoolDownRefreshTimerId))
				{
					TimerSystem.Instance.Pause(this.ChangeCoolDownRefreshTimerId, null);
				}
				if (TimerSystem.Instance.Has(this.HideCdTimerId) && !TimerSystem.Instance.IsPause(this.HideCdTimerId))
				{
					TimerSystem.Instance.Pause(this.HideCdTimerId, null);
					return;
				}
			}
			else if (flag == 0)
			{
				if (TimerSystem.Instance.Has(this.ChangeCoolDownRefreshTimerId) && TimerSystem.Instance.IsPause(this.ChangeCoolDownRefreshTimerId))
				{
					TimerSystem.Instance.Resume(this.ChangeCoolDownRefreshTimerId);
				}
				if (TimerSystem.Instance.Has(this.HideCdTimerId) && TimerSystem.Instance.IsPause(this.HideCdTimerId))
				{
					TimerSystem.Instance.Resume(this.HideCdTimerId);
				}
			}
		}

		// Token: 0x0603DB38 RID: 252728 RVA: 0x00FB7A35 File Offset: 0x00FB5C35
		public void RefreshSkillCoolDownOnShow()
		{
			if (this.CurrentCoolDownTime <= 0.0 || this.TotalCoolDownTime <= 0.0 || this.CoolDownBarUiSprite == null)
			{
				return;
			}
			this.RefreshSkillCoolDown();
		}

		// Token: 0x0603DB39 RID: 252729 RVA: 0x00FB7A68 File Offset: 0x00FB5C68
		public virtual void RefreshSkillCoolDown()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			if (this.SkillButtonData.TotalCoolDownCustom > 0)
			{
				this.RefreshLimitCount(true);
				this.PlaySkillCd(this.SkillButtonData.GetRemainingCoolDownCustom(), (float)this.SkillButtonData.TotalCoolDownCustom, this.SkillButtonData.HideCoolDownTextCustom);
				this.RefreshEnable(false);
				return;
			}
			if (this.IsSkillInItemUseBuffCd() && this.TryRefreshItemUseBuffCd())
			{
				this.RefreshEnable(false);
				return;
			}
			if (this.IsSkillInItemUseSkillCd() && this.TryRefreshItemUseSkillCd())
			{
				this.RefreshEnable(false);
				return;
			}
			if (this.SkillButtonData.IsMultiStageSkill().GetValueOrDefault() && this.TryRefreshMultiSkillCoolDown())
			{
				this.RefreshEnable(false);
				return;
			}
			if (this.IsVehicleSkillInCd() && this.TryRefreshVehicleSkillCd())
			{
				this.RefreshLimitCount(false);
				this.RefreshEnable(false);
				return;
			}
			this.RefreshLimitCount(false);
			this.TryRefreshCommonSkillCoolDown();
			this.RefreshEnable(false);
		}

		// Token: 0x0603DB3A RID: 252730 RVA: 0x00FB7B4C File Offset: 0x00FB5D4C
		public bool TryRefreshMultiSkillCoolDown()
		{
			MultiSkillInfo multiSkillInfo = this.SkillButtonData.GetMultiSkillInfo();
			if (multiSkillInfo != null)
			{
				int? nextSkillId = multiSkillInfo.NextSkillId;
				int num = 0;
				if (!(nextSkillId.GetValueOrDefault() == num & nextSkillId != null))
				{
					double remainingStartTime = multiSkillInfo.RemainingStartTime;
					float startTime = multiSkillInfo.StartTime;
					if (remainingStartTime > 0.0)
					{
						this.PlaySkillCd((float)remainingStartTime, startTime, false);
					}
					else
					{
						this.PlaySkillCd((float)multiSkillInfo.RemainingStopTime, multiSkillInfo.StopTime - startTime, true);
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603DB3B RID: 252731 RVA: 0x00FB7BC8 File Offset: 0x00FB5DC8
		private void TryRefreshCommonSkillCoolDown()
		{
			if (this.SkillButtonData.GetSkillId() == -1)
			{
				this.PlaySkillCd(0f, 0f, false);
				return;
			}
			GroupSkillCdInfo groupSkillCdInfo = this.SkillButtonData.GetGroupSkillCdInfo();
			if (groupSkillCdInfo == null)
			{
				if (!this.SkillButtonData.HasCdComponent())
				{
					this.PlaySkillCd(0f, 0f, false);
				}
				return;
			}
			if (this.IsHideNumComp && groupSkillCdInfo.RemainingCount > 0)
			{
				this.PlaySkillCd(0f, 0f, false);
				return;
			}
			float curRemainingCd = groupSkillCdInfo.CurRemainingCd;
			float curMaxCd = groupSkillCdInfo.CurMaxCd;
			this.PlaySkillCd(curRemainingCd, curMaxCd, false);
		}

		// Token: 0x0603DB3C RID: 252732 RVA: 0x00FB7C5D File Offset: 0x00FB5E5D
		protected void PlaySkillCd(float remainingCoolDown, float totalCoolDown, bool hideCdText = false)
		{
			this.HideCdText = hideCdText;
			if (remainingCoolDown <= 0f || totalCoolDown <= 0f)
			{
				this.FinishSkillCoolDown();
				return;
			}
			if (this.SkillButtonData.IsCdVisible())
			{
				this.PlayCommonCd((double)remainingCoolDown, (double)totalCoolDown, null);
				return;
			}
			this.PlayHideCd(remainingCoolDown);
		}

		// Token: 0x0603DB3D RID: 252733 RVA: 0x00FB7CA0 File Offset: 0x00FB5EA0
		private void PlayCommonCd(double remainingCoolDown, double totalCoolDown, Action additionalCdFinishedCb = null)
		{
			BattleSkillItem.<>c__DisplayClass120_0 CS$<>8__locals1 = new BattleSkillItem.<>c__DisplayClass120_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.additionalCdFinishedCb = additionalCdFinishedCb;
			BattleSkillItem.<>c__DisplayClass120_0 CS$<>8__locals2 = CS$<>8__locals1;
			ISkillButtonData skillButtonData = this.SkillButtonData;
			CS$<>8__locals2.skillId = ((skillButtonData != null) ? new int?(skillButtonData.GetSkillId()) : null);
			if (this.ShouldListenUltraAttribute())
			{
				this.RefreshMaxEnergyEffect(true, null, new bool?(true));
			}
			this.PlaySkillTimeDown(remainingCoolDown, totalCoolDown, new Action(CS$<>8__locals1.<PlayCommonCd>g__OnSkillCoolDownFinished|0));
		}

		// Token: 0x0603DB3E RID: 252734 RVA: 0x00FB7D18 File Offset: 0x00FB5F18
		private void PlayHideCd(float remainingCoolDown)
		{
			this.ResetSkillCoolDown();
			this.HideCdTimerId = TimerSystem.Instance.Delay(new TTimerAction(this.<PlayHideCd>g__OnHideCdFinish|121_0), remainingCoolDown * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
			this.RefreshTimeDilationAtTimerCreate(this.HideCdTimerId);
		}

		// Token: 0x0603DB3F RID: 252735 RVA: 0x00FB7D68 File Offset: 0x00FB5F68
		private void ActivateCdCompletedNiagara()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			if (this.SkillButtonData.GetCdCompletedEffectId() < 0)
			{
				return;
			}
			if (this.TargetAlpha == 0f)
			{
				return;
			}
			UUINiagara uiNiagara = base.GetUiNiagara(6);
			if (!uiNiagara.bIsUIActive)
			{
				uiNiagara.SetUIActive(true);
			}
			uiNiagara.ActivateSystem(true);
		}

		// Token: 0x0603DB40 RID: 252736 RVA: 0x00FB7DBC File Offset: 0x00FB5FBC
		protected void PlaySkillTimeDown(double coolDownTime, double totalCoolDown, Action onCoolDownFinished = null)
		{
			this.ResetCoolDownTimer();
			this.CurrentCoolDownTime = 0.0;
			if (coolDownTime <= 0.0)
			{
				this.CoolDownUiItem.SetUIActive(false);
				return;
			}
			this.CurrentCoolDownTime = coolDownTime;
			this.TotalCoolDownTime = totalCoolDown;
			this.CoolDownStartTime = Singleton<Time>.Instance.FlowTime * Singleton<TimeUtil>.Instance.Millisecond - (totalCoolDown - coolDownTime);
			this.OnCoolDownFinishedCallback = onCoolDownFinished;
			UUIText coolDownUiText = this.CoolDownUiText;
			string newText;
			if (!this.HideCdText)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("F");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.CdFixedPoint);
				newText = this.CurrentCoolDownTime.ToString(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			else
			{
				newText = string.Empty;
			}
			coolDownUiText.SetText(newText, true);
			this.ChangeCoolDownRefreshTimerId = TimerSystem.Instance.Forever(new TTimerAction(this.OnSkillCoolDownRefresh), 100f, 1f, null, null, true);
			this.RefreshTimeDilationAtTimerCreate(this.ChangeCoolDownRefreshTimerId);
			this.CoolDownUiItem.SetUIActive(true);
			if (ControllerBase<SkillCdController>.Instance.IsPause())
			{
				UUISprite coolDownBarUiSprite = this.CoolDownBarUiSprite;
				if (coolDownBarUiSprite == null)
				{
					return;
				}
				coolDownBarUiSprite.SetFillAmount((float)((totalCoolDown - coolDownTime) / totalCoolDown));
			}
		}

		// Token: 0x0603DB41 RID: 252737 RVA: 0x00FB7EE0 File Offset: 0x00FB60E0
		private void OnSkillCoolDownRefresh(float delta)
		{
			this.CurrentCoolDownTime -= 0.1;
			this.CurrentCoolDownTime = (double)((float)Math.Round(this.CurrentCoolDownTime * 10.0) / 10f);
			if (this.CurrentCoolDownTime > 0.0)
			{
				if (!this.HideCdText)
				{
					UUIText coolDownUiText = this.CoolDownUiText;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
					defaultInterpolatedStringHandler.AppendLiteral("F");
					defaultInterpolatedStringHandler.AppendFormatted<int>(this.CdFixedPoint);
					coolDownUiText.SetText(this.CurrentCoolDownTime.ToString(defaultInterpolatedStringHandler.ToStringAndClear()), true);
					return;
				}
			}
			else
			{
				this.FinishSkillCoolDown();
			}
		}

		// Token: 0x0603DB42 RID: 252738 RVA: 0x00FB7F86 File Offset: 0x00FB6186
		protected void FinishSkillCoolDown()
		{
			this.ResetSkillCoolDown();
			if (this.OnCoolDownFinishedCallback != null)
			{
				Action onCoolDownFinishedCallback = this.OnCoolDownFinishedCallback;
				this.OnCoolDownFinishedCallback = null;
				onCoolDownFinishedCallback();
			}
		}

		// Token: 0x0603DB43 RID: 252739 RVA: 0x00FB7FA8 File Offset: 0x00FB61A8
		private void TickSkillCoolDown(float _)
		{
			if (this.CurrentCoolDownTime <= 0.0 || this.TotalCoolDownTime <= 0.0 || this.CoolDownBarUiSprite == null)
			{
				return;
			}
			double num = (Singleton<Time>.Instance.FlowTime * Singleton<TimeUtil>.Instance.Millisecond - this.CoolDownStartTime) / this.TotalCoolDownTime;
			this.CoolDownBarUiSprite.SetFillAmount((float)num);
		}

		// Token: 0x0603DB44 RID: 252740 RVA: 0x00FB8011 File Offset: 0x00FB6211
		public void ResetSkillCoolDown()
		{
			this.CoolDownUiItem.SetUIActive(false);
			this.ResetCoolDownTimer();
			this.CurrentCoolDownTime = 0.0;
		}

		// Token: 0x0603DB45 RID: 252741 RVA: 0x00FB8034 File Offset: 0x00FB6234
		private void ResetCoolDownTimer()
		{
			if (TimerSystem.Instance.Has(this.ChangeCoolDownRefreshTimerId))
			{
				TimerSystem.Instance.Remove(this.ChangeCoolDownRefreshTimerId);
			}
			if (TimerSystem.Instance.Has(this.HideCdTimerId))
			{
				TimerSystem.Instance.Remove(this.HideCdTimerId);
			}
		}

		// Token: 0x0603DB46 RID: 252742 RVA: 0x00FB8088 File Offset: 0x00FB6288
		public virtual void RefreshEnable(bool bForce = false)
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			bool bVisible = this.IsInputEnable();
			this.SetSkillItemEnable(bVisible, bForce);
		}

		// Token: 0x0603DB47 RID: 252743 RVA: 0x00FB80AD File Offset: 0x00FB62AD
		public void DisableButton()
		{
			this.SetSkillItemEnable(false, true);
		}

		// Token: 0x0603DB48 RID: 252744 RVA: 0x00FB80B8 File Offset: 0x00FB62B8
		public virtual void RefreshVisible()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null || !rootItem.IsValid())
			{
				return;
			}
			bool flag = this.IsVisible();
			if (flag == this.RootItem.bIsUIActive && (this.ParentItem == null || flag == this.ParentItem.bIsUIActive))
			{
				return;
			}
			this.OnRefreshVisible(flag);
		}

		// Token: 0x0603DB49 RID: 252745 RVA: 0x00FB8110 File Offset: 0x00FB6310
		protected void OnRefreshVisible(bool bIsVisible)
		{
			if (bIsVisible)
			{
				if (!base.IsShowOrShowing)
				{
					base.Show(null);
					this.RefreshEnable(true);
					Action onVisibleChangedCallback = this.OnVisibleChangedCallback;
					if (onVisibleChangedCallback == null)
					{
						return;
					}
					onVisibleChangedCallback();
					return;
				}
			}
			else if (!base.IsHideOrHiding)
			{
				this.TryReleaseButton();
				base.Hide(null);
				Action onVisibleChangedCallback2 = this.OnVisibleChangedCallback;
				if (onVisibleChangedCallback2 == null)
				{
					return;
				}
				onVisibleChangedCallback2();
			}
		}

		// Token: 0x0603DB4A RID: 252746 RVA: 0x00FB816C File Offset: 0x00FB636C
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public UUIItem[] GetGuideItem()
		{
			if (base.IsCreateOrCreating)
			{
				return null;
			}
			UUIItem uuiitem = base.GetTexture(4);
			if (uuiitem == null)
			{
				return null;
			}
			if (!ObjectUtils.IsValid(uuiitem) || !uuiitem.IsUIActiveInHierarchy())
			{
				uuiitem = base.GetSprite(3);
				if (uuiitem == null)
				{
					return null;
				}
			}
			return new UUIItem[]
			{
				this.RootItem,
				uuiitem
			};
		}

		// Token: 0x0603DB4B RID: 252747 RVA: 0x00FB81C0 File Offset: 0x00FB63C0
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public UUIItem[] GetSpriteGuideItem()
		{
			if (base.IsCreateOrCreating)
			{
				return null;
			}
			UUISprite sprite = base.GetSprite(3);
			if (sprite == null)
			{
				return null;
			}
			if (!ObjectUtils.IsValid(sprite))
			{
				return null;
			}
			return new UUIItem[]
			{
				this.RootItem,
				sprite
			};
		}

		// Token: 0x0603DB4C RID: 252748 RVA: 0x00FB8204 File Offset: 0x00FB6404
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public UUIItem[] GetTextureGuideItem()
		{
			if (base.IsCreateOrCreating)
			{
				return null;
			}
			UUITexture texture = base.GetTexture(4);
			if (texture == null)
			{
				return null;
			}
			if (!ObjectUtils.IsValid(texture))
			{
				return null;
			}
			return new UUIItem[]
			{
				this.RootItem,
				texture
			};
		}

		// Token: 0x0603DB4D RID: 252749 RVA: 0x00FB8248 File Offset: 0x00FB6448
		protected void RefreshCdCompletedEffect()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			if (this.SkillButtonData.GetCdCompletedEffectId() <= 0)
			{
				return;
			}
			if (this.SkillButtonData.AttributeId > EAttributeType.None)
			{
				return;
			}
			SkillButtonEffect? cdCompletedEffectConfig = this.SkillButtonData.GetCdCompletedEffectConfig();
			if (cdCompletedEffectConfig == null)
			{
				return;
			}
			string niagaraPath = cdCompletedEffectConfig.Value.NiagaraPath;
			if (string.IsNullOrEmpty(niagaraPath))
			{
				return;
			}
			if (!string.IsNullOrEmpty(this.CdCompletedEffectPath) && this.CdCompletedEffectPath == niagaraPath)
			{
				return;
			}
			this.CancelLoadCdCompletedNiagara();
			this.LoadCdCompletedNiagaraHandleId = new int?(Singleton<ResourceSystem>.Instance.LoadAsync<UNiagaraSystem>(niagaraPath, delegate([Nullable(2)] UNiagaraSystem effectObject, string _)
			{
				if (effectObject == null || !effectObject.IsValid())
				{
					return;
				}
				UUINiagara uiNiagara = base.GetUiNiagara(6);
				if (uiNiagara == null)
				{
					return;
				}
				uiNiagara.SetNiagaraSystem(effectObject);
			}, 100, "js_undefined"));
			this.CdCompletedEffectPath = niagaraPath;
		}

		// Token: 0x0603DB4E RID: 252750 RVA: 0x00FB82FD File Offset: 0x00FB64FD
		protected void CancelLoadCdCompletedNiagara()
		{
			if (this.LoadCdCompletedNiagaraHandleId == null)
			{
				return;
			}
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadCdCompletedNiagaraHandleId.Value);
			this.LoadCdCompletedNiagaraHandleId = null;
		}

		// Token: 0x0603DB4F RID: 252751 RVA: 0x00FB8330 File Offset: 0x00FB6530
		protected virtual SkillButtonEffect? GetDynamicEffectConfig()
		{
			ISkillButtonData skillButtonData = this.SkillButtonData;
			if (skillButtonData == null)
			{
				return null;
			}
			return skillButtonData.GetDynamicEffectConfig();
		}

		// Token: 0x0603DB50 RID: 252752 RVA: 0x00FB8356 File Offset: 0x00FB6556
		protected void CancelLoadDynamicEffectNiagara()
		{
			this.DynamicEffect.CancelLoadDynamicEffectNiagara();
		}

		// Token: 0x0603DB51 RID: 252753 RVA: 0x00FB8364 File Offset: 0x00FB6564
		public virtual void RefreshDynamicEffect()
		{
			SkillButtonEffect? dynamicEffectConfig = this.GetDynamicEffectConfig();
			this.DynamicEffect.RefreshDynamicEffect(dynamicEffectConfig);
		}

		// Token: 0x0603DB52 RID: 252754 RVA: 0x00FB8384 File Offset: 0x00FB6584
		protected void SetDynamicEffectVisible(bool visible)
		{
			this.DynamicEffect.SetDynamicEffectVisible(visible);
		}

		// Token: 0x0603DB53 RID: 252755 RVA: 0x00FB8392 File Offset: 0x00FB6592
		public void RefreshTimeDilation()
		{
			this.SetTimeDilation(this.GetTimeDilation());
		}

		// Token: 0x0603DB54 RID: 252756 RVA: 0x00FB83A0 File Offset: 0x00FB65A0
		private float GetTimeDilation()
		{
			if (ControllerBase<SkillCdController>.Instance.IsPause())
			{
				return 0f;
			}
			return Singleton<Time>.Instance.TimeDilation;
		}

		// Token: 0x0603DB55 RID: 252757 RVA: 0x00FB83C0 File Offset: 0x00FB65C0
		[NullableContext(1)]
		private void RefreshTimeDilationAtTimerCreate(TimerHandle timerId)
		{
			float num = this.GetTimeDilation() * ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation;
			if (num != 1f)
			{
				if (num > 0f)
				{
					TimerSystem.Instance.ChangeDilation(timerId, num, null);
					return;
				}
				TimerSystem.Instance.Pause(timerId, null);
			}
		}

		// Token: 0x0603DB56 RID: 252758 RVA: 0x00FB840C File Offset: 0x00FB660C
		private void SetTimeDilation(float timeDilation)
		{
			if (TimerSystem.Instance.Has(this.ChangeCoolDownRefreshTimerId))
			{
				if (timeDilation > 0f)
				{
					if (TimerSystem.Instance.IsPause(this.ChangeCoolDownRefreshTimerId))
					{
						TimerSystem.Instance.Resume(this.ChangeCoolDownRefreshTimerId);
					}
					TimerSystem.Instance.ChangeDilation(this.ChangeCoolDownRefreshTimerId, timeDilation * ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation, null);
				}
				else if (!TimerSystem.Instance.IsPause(this.ChangeCoolDownRefreshTimerId))
				{
					TimerSystem.Instance.Pause(this.ChangeCoolDownRefreshTimerId, null);
				}
			}
			if (TimerSystem.Instance.Has(this.HideCdTimerId))
			{
				if (timeDilation > 0f)
				{
					if (TimerSystem.Instance.IsPause(this.HideCdTimerId))
					{
						TimerSystem.Instance.Resume(this.HideCdTimerId);
					}
					TimerSystem.Instance.ChangeDilation(this.HideCdTimerId, timeDilation, null);
					return;
				}
				if (!TimerSystem.Instance.IsPause(this.HideCdTimerId))
				{
					TimerSystem.Instance.Pause(this.HideCdTimerId, null);
				}
			}
		}

		// Token: 0x0603DB57 RID: 252759 RVA: 0x00FB850F File Offset: 0x00FB670F
		private void RemoveLongPressTimer()
		{
			if (this.LongPressTimerId == null)
			{
				return;
			}
			if (!TimerSystem.Instance.Has(this.LongPressTimerId))
			{
				return;
			}
			TimerSystem.Instance.Remove(this.LongPressTimerId);
			this.LongPressTimerId = null;
		}

		// Token: 0x0603DB58 RID: 252760 RVA: 0x00FB8548 File Offset: 0x00FB6748
		private bool RefreshSwitchComponentVisible()
		{
			ISkillButtonData skillButtonData = this.SkillButtonData;
			bool flag = skillButtonData != null && skillButtonData.GetButtonType() == ESkillButtonType.幻象1 && !this.SkillButtonData.HasConfigFollower();
			if (this.SwitchComponent != null)
			{
				this.GetSwitchComponent.SetComponentActive(flag);
			}
			else if (flag)
			{
				this.GetSwitchComponent.SetComponentActive(flag);
			}
			return flag;
		}

		// Token: 0x0603DB59 RID: 252761 RVA: 0x00FB85A4 File Offset: 0x00FB67A4
		public void RefreshAttribute(bool bBurstMaxEffect = true)
		{
			ISkillButtonData skillButtonData = this.SkillButtonData;
			if (skillButtonData == null || skillButtonData.AttributeUsageMode != ESkillButtonAttributeUsageMode.RecoverWithStack)
			{
				bool flag = this.HasListenAttribute();
				BattleSkillUltraItem ultraComponent = this.UltraComponent;
				bool? flag2 = (ultraComponent != null) ? new bool?(ultraComponent.Visible) : null;
				bool? flag3 = flag2;
				bool flag4 = flag;
				if (!(flag3.GetValueOrDefault() == flag4 & flag3 != null))
				{
					this.SetUltraComponentVisible(flag, BattleSkillItem.EUltraComponentVisibleReason.Attribute);
					if (flag2.GetValueOrDefault())
					{
						this.DeactivateMaxEnergyEffect();
					}
				}
				if (flag)
				{
					this.RefreshFrameSprite();
					this.LoadMaxAttributeEffect();
					this.LoadMaxAttributeBurstEffect();
					this.RefreshAttributePercent(bBurstMaxEffect);
				}
				this.RefreshEnable(false);
				return;
			}
			BattleSkillConfigLongPressItem configLongPressComponent = this.ConfigLongPressComponent;
			if (configLongPressComponent == null)
			{
				return;
			}
			configLongPressComponent.RefreshAttributeValue(this.SkillButtonData.GetAttribute());
		}

		// Token: 0x0603DB5A RID: 252762 RVA: 0x00FB8660 File Offset: 0x00FB6860
		private void SetUltraComponentVisible(bool visible, BattleSkillItem.EUltraComponentVisibleReason reason)
		{
			this.UltraComponentVisibleState = VisibleStateUtil.SetVisible(this.UltraComponentVisibleState, visible, (int)reason);
			bool visible2 = VisibleStateUtil.GetVisible(this.UltraComponentVisibleState);
			if (this.UltraComponent != null)
			{
				this.GetUltraComponent.SetComponentActive(visible2);
				return;
			}
			if (visible2)
			{
				this.GetUltraComponent.SetComponentActive(visible2);
			}
		}

		// Token: 0x0603DB5B RID: 252763 RVA: 0x00FB86B0 File Offset: 0x00FB68B0
		protected void RefreshFrameSprite()
		{
			if (this.ShouldListenUltraAttribute())
			{
				FColor? frameSpriteColor = this.SkillButtonData.GetFrameSpriteColor();
				this.GetUltraComponent.SetFrameSprite(frameSpriteColor.Value);
			}
		}

		// Token: 0x0603DB5C RID: 252764 RVA: 0x00FB86E4 File Offset: 0x00FB68E4
		private void RefreshAttributePercent(bool bBurstMaxEffect = true)
		{
			float attribute = this.SkillButtonData.GetAttribute();
			float maxAttribute = this.SkillButtonData.GetMaxAttribute();
			if (maxAttribute == 0f)
			{
				this.SetEnergyPercent(1f, bBurstMaxEffect);
				this.RefreshMaxEnergyEffect(bBurstMaxEffect, new bool?(false), null);
				return;
			}
			this.SetEnergyPercent(attribute / maxAttribute, bBurstMaxEffect);
			this.RefreshMaxEnergyEffect(bBurstMaxEffect, new bool?(attribute < maxAttribute), null);
		}

		// Token: 0x0603DB5D RID: 252765 RVA: 0x00FB8758 File Offset: 0x00FB6958
		private void RefreshMaxEnergyEffect(bool refreshMaxEffectTip, bool? energyNoEnough, bool? inCoolDown)
		{
			bool? flag = energyNoEnough;
			bool? flag2 = inCoolDown;
			if (!flag.GetValueOrDefault() || flag2.GetValueOrDefault())
			{
				if (energyNoEnough == null)
				{
					float attribute = this.SkillButtonData.GetAttribute();
					float maxAttribute = this.SkillButtonData.GetMaxAttribute();
					flag = new bool?(attribute < maxAttribute);
				}
				bool value = flag2.GetValueOrDefault();
				if (flag2 == null)
				{
					value = (this.SkillButtonData.GetSkillRemainingCoolDown() > 0f);
					flag2 = new bool?(value);
				}
			}
			bool flag3 = !flag.GetValueOrDefault() && !flag2.GetValueOrDefault();
			this.SetMaxEnergyEffectEnable(flag3);
			if (refreshMaxEffectTip)
			{
				this.SetMaxEnergyEffectBurst(flag3);
			}
		}

		// Token: 0x0603DB5E RID: 252766 RVA: 0x00FB8800 File Offset: 0x00FB6A00
		private bool IsSkillInItemUseBuffCd()
		{
			ISkillButtonData skillButtonData = this.SkillButtonData;
			return skillButtonData != null && skillButtonData.GetButtonType() == ESkillButtonType.幻象1 && this.SkillButtonData.IsSkillInItemUseBuffCd();
		}

		// Token: 0x0603DB5F RID: 252767 RVA: 0x00FB882C File Offset: 0x00FB6A2C
		private bool TryRefreshItemUseBuffCd()
		{
			ValueTuple<double, double> equippedItemUsingBuffCd = this.SkillButtonData.GetEquippedItemUsingBuffCd();
			double item = equippedItemUsingBuffCd.Item1;
			double item2 = equippedItemUsingBuffCd.Item2;
			if (item > 0.0)
			{
				this.PlayCommonCd(item, item2, delegate
				{
					Singleton<EventSystem>.Instance.Emit(EEventName.OnChangeSelectedExploreId);
					this.RefreshEnable(false);
				});
				return true;
			}
			return false;
		}

		// Token: 0x0603DB60 RID: 252768 RVA: 0x00FB8874 File Offset: 0x00FB6A74
		private bool IsSkillInItemUseSkillCd()
		{
			ISkillButtonData skillButtonData = this.SkillButtonData;
			return skillButtonData != null && skillButtonData.GetButtonType() == ESkillButtonType.幻象1 && this.SkillButtonData.IsSkillInItemUseSkillCd();
		}

		// Token: 0x0603DB61 RID: 252769 RVA: 0x00FB88A0 File Offset: 0x00FB6AA0
		private bool TryRefreshItemUseSkillCd()
		{
			ValueTuple<double, double> equippedItemUsingSkillCd = this.SkillButtonData.GetEquippedItemUsingSkillCd();
			double item = equippedItemUsingSkillCd.Item1;
			double item2 = equippedItemUsingSkillCd.Item2;
			if (item > 0.0)
			{
				this.PlayCommonCd(item, item2, delegate
				{
					Singleton<EventSystem>.Instance.Emit(EEventName.OnChangeSelectedExploreId);
					this.RefreshEnable(false);
				});
				return true;
			}
			return false;
		}

		// Token: 0x0603DB62 RID: 252770 RVA: 0x00FB88E8 File Offset: 0x00FB6AE8
		private bool IsVehicleSkillInCd()
		{
			ISkillButtonData skillButtonData = this.SkillButtonData;
			return skillButtonData != null && skillButtonData.GetButtonType() == ESkillButtonType.闪避 && this.SkillButtonData.IsVehicleSkillInCd();
		}

		// Token: 0x0603DB63 RID: 252771 RVA: 0x00FB8914 File Offset: 0x00FB6B14
		private bool TryRefreshVehicleSkillCd()
		{
			ValueTuple<double, double> vehicleSkillCd = this.SkillButtonData.GetVehicleSkillCd();
			double item = vehicleSkillCd.Item1;
			double item2 = vehicleSkillCd.Item2;
			if (item > 0.0)
			{
				this.PlayCommonCd(item, item2, delegate
				{
					this.RefreshEnable(false);
				});
				return true;
			}
			return false;
		}

		// Token: 0x0603DB64 RID: 252772 RVA: 0x00FB895C File Offset: 0x00FB6B5C
		public void RefreshEquipExplore()
		{
			UUIItem item = base.GetItem(9);
			if (item.IsUIActiveSelf())
			{
				item.SetUIActive(false);
			}
			if (this.SkillButtonData.GetExploreSkillChange())
			{
				item.SetUIActive(true);
				this.SkillButtonData.SetExploreSkillChange(false);
				this.RemoveEquipEffectTimer();
				this.EquipEffectTimerId = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.EquipEffectTimerId = null;
					item.SetUIActive(false);
				}, 500f, null, null, true, 1f);
			}
			this.GetSwitchComponent.RefreshSwitch();
			ISkillButtonData skillButtonData = this.SkillButtonData;
			if (skillButtonData == null || !skillButtonData.IsExploreAsFight)
			{
				ISkillButtonData skillButtonData2 = this.SkillButtonData;
				if (skillButtonData2 == null || !skillButtonData2.IsSkillIdChangeByTag())
				{
					bool flag = ModelBase<RouletteModel>.Instance.IsExploreSkillHasNum();
					if (!flag)
					{
						this.GetSwitchComponent.UpdateNumPanel(flag, null);
					}
					else
					{
						int exploreSkillShowNum = ModelBase<RouletteModel>.Instance.GetExploreSkillShowNum();
						this.GetSwitchComponent.UpdateNumPanel(flag, new int?(exploreSkillShowNum));
					}
					int currentExploreSkillId = ModelBase<RouletteModel>.Instance.CurrentExploreSkillId;
					bool flag2 = ModelBase<RouletteModel>.Instance.IsExploreSkillHasSetNum(currentExploreSkillId);
					if (!flag2)
					{
						this.GetSwitchComponent.UpdatePointPanel(flag2, null, null);
						return;
					}
					ValueTuple<int, int> exploreSkillShowSetNumById = ModelBase<RouletteModel>.Instance.GetExploreSkillShowSetNumById((ERouletteExploreId)currentExploreSkillId);
					int item3 = exploreSkillShowSetNumById.Item1;
					int item2 = exploreSkillShowSetNumById.Item2;
					this.GetSwitchComponent.UpdatePointPanel(flag2, new int?(item2), new int?(item3));
					return;
				}
			}
			this.GetSwitchComponent.UpdateNumPanel(false, null);
			this.GetSwitchComponent.UpdatePointPanel(false, null, null);
		}

		// Token: 0x0603DB65 RID: 252773 RVA: 0x00FB8B0F File Offset: 0x00FB6D0F
		private void RemoveEquipEffectTimer()
		{
			if (this.EquipEffectTimerId != null)
			{
				TimerSystem.Instance.Remove(this.EquipEffectTimerId);
				this.EquipEffectTimerId = null;
			}
		}

		// Token: 0x0603DB66 RID: 252774 RVA: 0x00FB8B31 File Offset: 0x00FB6D31
		public void SetMaxEnergyEffectEnable(bool bEnable)
		{
			this.GetUltraComponent.SetUltraEffectEnable(bEnable);
		}

		// Token: 0x0603DB67 RID: 252775 RVA: 0x00FB8B3F File Offset: 0x00FB6D3F
		private void SetMaxEnergyTipEffectEnable(bool bEnable)
		{
		}

		// Token: 0x0603DB68 RID: 252776 RVA: 0x00FB8B41 File Offset: 0x00FB6D41
		private void SetEnergyUpEffectEnable(bool bEnable)
		{
			this.GetUltraComponent.SetUltraUpEffectEnable(bEnable);
		}

		// Token: 0x0603DB69 RID: 252777 RVA: 0x00FB8B4F File Offset: 0x00FB6D4F
		public void SetEnergyPercent(float energyPercent, bool bPlayUpEffect)
		{
			this.GetUltraComponent.SetBarPercent(energyPercent, bPlayUpEffect);
		}

		// Token: 0x0603DB6A RID: 252778 RVA: 0x00FB8B5E File Offset: 0x00FB6D5E
		private void SetMaxEnergyEffectBurst(bool bBurst)
		{
			if (this.HasEruptedMaxEffect == bBurst)
			{
				return;
			}
			this.HasEruptedMaxEffect = bBurst;
			if (bBurst)
			{
				this.ActivateBurstMaxEnergyEffect();
				return;
			}
			this.DeactivateMaxEnergyEffect();
		}

		// Token: 0x0603DB6B RID: 252779 RVA: 0x00FB8B81 File Offset: 0x00FB6D81
		private void ActivateBurstMaxEnergyEffect()
		{
			this.SetMaxEnergyTipEffectEnable(true);
		}

		// Token: 0x0603DB6C RID: 252780 RVA: 0x00FB8B8A File Offset: 0x00FB6D8A
		private void DeactivateMaxEnergyEffect()
		{
			if (this.UltraComponent != null)
			{
				this.SetMaxEnergyTipEffectEnable(false);
				this.SetMaxEnergyEffectEnable(false);
				this.SetEnergyUpEffectEnable(false);
			}
		}

		// Token: 0x0603DB6D RID: 252781 RVA: 0x00FB8BAC File Offset: 0x00FB6DAC
		private void LoadMaxAttributeEffect()
		{
			if (!this.ShouldListenUltraAttribute())
			{
				return;
			}
			string maxAttributeEffectPath = this.SkillButtonData.GetMaxAttributeEffectPath();
			if (!string.IsNullOrEmpty(maxAttributeEffectPath))
			{
				this.GetUltraComponent.RefreshUltraEffect(maxAttributeEffectPath, this.SkillButtonData.GetMaxAttributeColor().Value);
			}
			if (ModelBase<BattleLinkModel>.Instance.CheckInDreamLink())
			{
				this.GetUltraComponent.RefreshUltraDynamicEffect("/Game/Aki/Effect/UI/Niagaras/Common/NS_Fx_LGUI_Fight_Link.NS_Fx_LGUI_Fight_Link", null);
				return;
			}
			this.GetUltraComponent.StopUltraDynamicEffect();
		}

		// Token: 0x0603DB6E RID: 252782 RVA: 0x00FB8C28 File Offset: 0x00FB6E28
		private void LoadMaxAttributeBurstEffect()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			if (this.SkillButtonData.GetMaxAttributeBurstEffectId() <= 0)
			{
				return;
			}
			SkillButtonEffect? maxAttributeBurstEffectConfig = this.SkillButtonData.GetMaxAttributeBurstEffectConfig();
			if (maxAttributeBurstEffectConfig == null)
			{
				return;
			}
			string niagaraPath = maxAttributeBurstEffectConfig.Value.NiagaraPath;
			if (string.IsNullOrEmpty(niagaraPath))
			{
				return;
			}
			this.GetUltraComponent.RefreshUltraTipsEffect(niagaraPath);
		}

		// Token: 0x0603DB6F RID: 252783 RVA: 0x00FB8C88 File Offset: 0x00FB6E88
		public void SetLimitUseSkillCount(int remainingUseCount)
		{
			BattleSkillNumItem getNumComponent = this.GetNumComponent;
			if (getNumComponent == null)
			{
				return;
			}
			getNumComponent.SetRemainingCount(remainingUseCount);
		}

		// Token: 0x0603DB70 RID: 252784 RVA: 0x00FB8C9C File Offset: 0x00FB6E9C
		public void RefreshLimitCount(bool refreshVisible = false)
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			int limitUseSkillCount = 0;
			bool flag;
			if (this.SkillButtonData.IsLimitCountCustom)
			{
				flag = true;
				limitUseSkillCount = this.SkillButtonData.RemainingCountCustom;
			}
			else if (this.SkillButtonData.IsLimitCountVehicleSkill)
			{
				flag = true;
				limitUseSkillCount = this.SkillButtonData.RemainingCountVehicleSkill;
			}
			else
			{
				GroupSkillCdInfo groupSkillCdInfo = this.SkillButtonData.GetGroupSkillCdInfo();
				flag = (groupSkillCdInfo != null && groupSkillCdInfo.LimitCount > 1);
				if (flag)
				{
					limitUseSkillCount = groupSkillCdInfo.RemainingCount;
				}
			}
			BattleSkillNumItem numComponent = this.NumComponent;
			if ((numComponent != null && numComponent.TargetActive) != flag || refreshVisible)
			{
				if (this.NumComponent != null)
				{
					BattleSkillNumItem getNumComponent = this.GetNumComponent;
					if (getNumComponent != null)
					{
						getNumComponent.SetComponentActive(flag);
					}
				}
				else if (flag)
				{
					BattleSkillNumItem getNumComponent2 = this.GetNumComponent;
					if (getNumComponent2 != null)
					{
						getNumComponent2.SetComponentActive(flag);
					}
				}
			}
			if (flag)
			{
				this.SetLimitUseSkillCount(limitUseSkillCount);
			}
		}

		// Token: 0x0603DB71 RID: 252785 RVA: 0x00FB8D6C File Offset: 0x00FB6F6C
		public void RefreshSkillButtonLongPress()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			bool flag = this.SkillButtonData.IsShowLongPress();
			if (flag)
			{
				BattleSkillLongPressItem getLongPressComponent = this.GetLongPressComponent;
				getLongPressComponent.SetComponentActive(flag);
				BattleSkillLongPressItem battleSkillLongPressItem = getLongPressComponent;
				CSharpScript.Game.Input.EInputAction actionType = this.SkillButtonData.GetActionType();
				battleSkillLongPressItem.SetAction(actionType);
				this.SkillButtonData.RefreshLongPressDuration();
				getLongPressComponent.SetDuration((float)this.SkillButtonData.GetLongPressDuration());
				if (this.SkillButtonData.GetIsLongPressing())
				{
					getLongPressComponent.StartProgress();
					return;
				}
			}
			else
			{
				BattleSkillLongPressItem longPressComponent = this.LongPressComponent;
				if (longPressComponent == null)
				{
					return;
				}
				longPressComponent.SetComponentActive(false);
			}
		}

		// Token: 0x0603DB72 RID: 252786 RVA: 0x00FB8DF8 File Offset: 0x00FB6FF8
		private void RefreshDotIndicator(bool show = true)
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			bool flag = this.SkillButtonData.IsEnableDotIndicator && show;
			BattleSkillDotIndicatorItem dotIndicatorComponent = this.DotIndicatorComponent;
			bool flag2 = dotIndicatorComponent != null && dotIndicatorComponent.IsComponentActive;
			if (flag != flag2)
			{
				if (this.DotIndicatorComponent != null)
				{
					this.DotIndicatorComponent.SetComponentActive(flag);
				}
				else
				{
					BattleSkillDotIndicatorItem getDotIndicatorComponent = this.GetDotIndicatorComponent;
					if (getDotIndicatorComponent != null)
					{
						getDotIndicatorComponent.SetComponentActive(flag);
					}
				}
			}
			if (flag && this.DotIndicatorComponent != null)
			{
				this.DotIndicatorComponent.SetCount(this.SkillButtonData.DotIndicatorCount, false);
				SkillButtonData skillButtonData = this.SkillButtonData as SkillButtonData;
				string iconPath = ((skillButtonData != null) ? skillButtonData.DotIndicatorIconPath : null) ?? "";
				this.DotIndicatorComponent.SetIconPath(iconPath, false);
			}
		}

		// Token: 0x0603DB73 RID: 252787 RVA: 0x00FB8EAC File Offset: 0x00FB70AC
		public void RefreshCustomHdData(int from = -1, int param = 0)
		{
			if (from > 100)
			{
				if (from == 101)
				{
					this.RefreshConfigLongPress(from, param);
					return;
				}
			}
			else
			{
				switch (from)
				{
				case 5:
					this.RefreshDotIndicator(true);
					return;
				case 6:
				case 7:
					this.RefreshConfigLongPress(from, param);
					return;
				case 8:
					this.RefreshFrameSprite();
					this.LoadMaxAttributeEffect();
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x0603DB74 RID: 252788 RVA: 0x00FB8F04 File Offset: 0x00FB7104
		public void InitVehicleHandle()
		{
			ISkillButtonData skillButtonData = this.SkillButtonData;
			if (skillButtonData == null)
			{
				return;
			}
			skillButtonData.InitVehicleHandle();
		}

		// Token: 0x0603DB75 RID: 252789 RVA: 0x00FB8F18 File Offset: 0x00FB7118
		public void RefreshConfigLongPress(int from = -1, int param = 0)
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			if (this.SkillButtonData.GetIsConfigShowLongPress())
			{
				BattleSkillConfigLongPressItem getConfigLongPressComponent = this.GetConfigLongPressComponent;
				getConfigLongPressComponent.SetComponentActive(true);
				CSharpScript.Game.Input.EInputAction actionType = this.SkillButtonData.GetActionType();
				getConfigLongPressComponent.SetAction(actionType);
				getConfigLongPressComponent.SetDuration((float)this.SkillButtonData.GetLongPressTime());
				getConfigLongPressComponent.SetSharedFxActions(this.SkillButtonData.GetValidSharedHoldRingFxActions());
				getConfigLongPressComponent.SetCustomLogicParam(this.SkillButtonData as SkillButtonData, from, param);
				return;
			}
			BattleSkillConfigLongPressItem configLongPressComponent = this.ConfigLongPressComponent;
			if (configLongPressComponent == null)
			{
				return;
			}
			configLongPressComponent.SetComponentActive(false);
		}

		// Token: 0x0603DB76 RID: 252790 RVA: 0x00FB8FA4 File Offset: 0x00FB71A4
		public void RefreshExtraEffect()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			SkillButtonTypeFormationData formationData = this.SkillButtonData.GetFormationData();
			if (formationData == null || formationData.ExtraEffect == ESkillButtonExtraEffect.None)
			{
				if (this.ExtraEffectComponent != null)
				{
					this.ExtraEffectComponent.SetComponentActive(false);
				}
				return;
			}
			if (this.ExtraEffectComponent != null)
			{
				if (this.ExtraEffectComponent.GetEffectType() == formationData.ExtraEffect)
				{
					this.ExtraEffectComponent.SetComponentActive(true);
					this.ExtraEffectComponent.Refresh(formationData.ExtraEffectDuration);
					return;
				}
				this.ExtraEffectComponent.Destroy(null);
				this.ExtraEffectComponent = null;
			}
			if (formationData.ExtraEffect == ESkillButtonExtraEffect.Rhythm)
			{
				this.ExtraEffectComponent = new BattleSkillExtraEffectRhythmItem();
				this.ExtraEffectComponent.Init(this.GetExtraContainer());
				this.ExtraEffectComponent.SetComponentActive(true);
				this.ExtraEffectComponent.Refresh(formationData.ExtraEffectDuration);
			}
			BattleSkillExtraEffectItem extraEffectComponent = this.ExtraEffectComponent;
			if (extraEffectComponent == null)
			{
				return;
			}
			extraEffectComponent.SetEffectType(formationData.ExtraEffect);
		}

		// Token: 0x0603DB77 RID: 252791 RVA: 0x00FB908A File Offset: 0x00FB728A
		public void RefreshSlideControl()
		{
			if (this.SkillButtonData == null)
			{
				return;
			}
			if (this.SkillButtonData.IsEnableSlideControl)
			{
				ModelBase<BattleUiModel>.Instance.SlideControlData.Preload();
			}
		}

		// Token: 0x0603DB78 RID: 252792 RVA: 0x00FB90B1 File Offset: 0x00FB72B1
		private bool IsInputEnable()
		{
			return this.SkillButtonData != null && this.SkillButtonData.IsEnable();
		}

		// Token: 0x0603DB79 RID: 252793 RVA: 0x00FB90C8 File Offset: 0x00FB72C8
		public virtual bool IsVisible()
		{
			return this.SkillButtonData != null && this.SkillButtonData.IsVisible();
		}

		// Token: 0x0603DB7A RID: 252794 RVA: 0x00FB90DF File Offset: 0x00FB72DF
		public EAttributeType GetAttributeId()
		{
			return this.SkillButtonData.AttributeId;
		}

		// Token: 0x0603DB7B RID: 252795 RVA: 0x00FB90EC File Offset: 0x00FB72EC
		public bool HasListenAttribute()
		{
			return this.SkillButtonData != null && this.SkillButtonData.HasAttribute();
		}

		// Token: 0x0603DB7C RID: 252796 RVA: 0x00FB9103 File Offset: 0x00FB7303
		public bool ShouldListenUltraAttribute()
		{
			return this.SkillButtonData != null && this.SkillButtonData.HasAttribute() && this.SkillButtonData.AttributeUsageMode == ESkillButtonAttributeUsageMode.Ultra;
		}

		// Token: 0x0603DB7D RID: 252797 RVA: 0x00FB912C File Offset: 0x00FB732C
		public SkillButtonData GetSkillButtonData()
		{
			return this.SkillButtonData as SkillButtonData;
		}

		// Token: 0x0603DB7E RID: 252798 RVA: 0x00FB9139 File Offset: 0x00FB7339
		public int GetInputIndex()
		{
			return this.InputIndex;
		}

		// Token: 0x0603DB7F RID: 252799 RVA: 0x00FB9141 File Offset: 0x00FB7341
		public virtual void OnInputAction(bool bForcePlayClickEffect = false)
		{
			if (!bForcePlayClickEffect && (this.SkillButtonData == null || !this.SkillButtonData.IsEnable() || !this.SkillButtonData.IsVisible()))
			{
				return;
			}
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect == null)
			{
				return;
			}
			clickEffect.Play();
		}

		// Token: 0x0603DB80 RID: 252800 RVA: 0x00FB917C File Offset: 0x00FB737C
		public void SetVisibleByExploreMode(bool visible, bool anim = false)
		{
			bool raycastTarget = false;
			if (visible)
			{
				this.TargetAlpha = this.BaseAlpha;
				raycastTarget = true;
			}
			else
			{
				this.TargetAlpha = 0f;
			}
			if (this.RootItem == null)
			{
				return;
			}
			this.RootItem.SetRaycastTarget(raycastTarget);
			base.GetItem(8).SetUIActive(visible);
			if (!anim)
			{
				if (this.AlphaTweenComp != null)
				{
					this.AlphaTweenComp.Stop();
				}
				this.RootItem.SetAlpha(this.TargetAlpha);
				return;
			}
			if (this.AlphaTweenComp == null)
			{
				this.AlphaTweenComp = (this.RootActor.GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			}
			else
			{
				this.AlphaTweenComp.Stop();
			}
			ULGUIPlayTween_Float ulguiplayTween_Float = this.AlphaTweenComp.GetPlayTween() as ULGUIPlayTween_Float;
			ulguiplayTween_Float.from = this.RootItem.GetAlpha();
			ulguiplayTween_Float.to = this.TargetAlpha;
			this.AlphaTweenComp.Play();
		}

		// Token: 0x0603DB81 RID: 252801 RVA: 0x00FB925F File Offset: 0x00FB745F
		protected void OnDeactivate()
		{
		}

		// Token: 0x0603DB82 RID: 252802 RVA: 0x00FB9261 File Offset: 0x00FB7461
		[NullableContext(1)]
		public void SetOnVisibleChangedCallback(Action callback)
		{
			this.OnVisibleChangedCallback = callback;
		}

		// Token: 0x0603DB83 RID: 252803 RVA: 0x00FB926C File Offset: 0x00FB746C
		[NullableContext(1)]
		public void SetSkillItemLayout(SkillItemLayout layout)
		{
			if (this.LayoutIndex == layout.Index)
			{
				return;
			}
			this.LayoutIndex = layout.Index;
			UUIItem rootItem = this.RootItem;
			UUIItem uuiitem = (rootItem != null) ? rootItem.GetParentAsUIItem() : null;
			if (uuiitem != null)
			{
				uuiitem.SetUIParent(layout.Item, false);
			}
			if (layout.Index == 0 && uuiitem != null)
			{
				uuiitem.SetHierarchyIndex(1);
			}
		}

		// Token: 0x0603DB84 RID: 252804 RVA: 0x00FB92C9 File Offset: 0x00FB74C9
		public InputMultiKeyItem GetKeyItem()
		{
			return this.KeyItem;
		}

		// Token: 0x0603DB85 RID: 252805 RVA: 0x00FB92D1 File Offset: 0x00FB74D1
		public bool GetSkillButtonInteractive()
		{
			UUIButtonComponent skillButton = this.SkillButton;
			return skillButton != null && skillButton.IsSelfInteractive;
		}

		// Token: 0x0603DB88 RID: 252808 RVA: 0x00FB9351 File Offset: 0x00FB7551
		[CompilerGenerated]
		private void <PlayHideCd>g__OnHideCdFinish|121_0(float _)
		{
			this.SkillButtonData.RefreshIsEnable();
			this.FinishSkillCoolDown();
		}

		// Token: 0x040229D3 RID: 141779
		private const int SKILL_COOLDOWN_INTERVAL = 100;

		// Token: 0x040229D4 RID: 141780
		private const double SKILL_COOLDOWN_LOOP_INTERVAL = 0.1;

		// Token: 0x040229D5 RID: 141781
		private const int EQUIP_EFFECT_TIME = 500;

		// Token: 0x040229D6 RID: 141782
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat PlaySkillCdStat = Stat.Create("[SkillButton]PlaySkillCd", "", "");

		// Token: 0x040229D7 RID: 141783
		private UUIItem ParentItem;

		// Token: 0x040229D8 RID: 141784
		protected UUIDraggableComponent DraggableComponent;

		// Token: 0x040229D9 RID: 141785
		protected ISkillButtonData SkillButtonData;

		// Token: 0x040229DA RID: 141786
		private UUIButtonComponent SkillButton;

		// Token: 0x040229DB RID: 141787
		private TimerHandle ChangeCoolDownRefreshTimerId;

		// Token: 0x040229DC RID: 141788
		private UUIItem CoolDownUiItem;

		// Token: 0x040229DD RID: 141789
		protected UUIText CoolDownUiText;

		// Token: 0x040229DE RID: 141790
		private UUISprite CoolDownBarUiSprite;

		// Token: 0x040229DF RID: 141791
		private double CurrentCoolDownTime;

		// Token: 0x040229E0 RID: 141792
		private double TotalCoolDownTime;

		// Token: 0x040229E1 RID: 141793
		private double CoolDownStartTime;

		// Token: 0x040229E2 RID: 141794
		protected Action OnCoolDownFinishedCallback;

		// Token: 0x040229E3 RID: 141795
		private bool HasEruptedMaxEffect;

		// Token: 0x040229E4 RID: 141796
		private TimerHandle LongPressTimerId;

		// Token: 0x040229E5 RID: 141797
		protected bool IsLongPress;

		// Token: 0x040229E6 RID: 141798
		private bool IsAddedEvents;

		// Token: 0x040229E7 RID: 141799
		[Nullable(1)]
		private string CdCompletedEffectPath = string.Empty;

		// Token: 0x040229E8 RID: 141800
		private BattleSkillItemDynamicEffect DynamicEffect;

		// Token: 0x040229E9 RID: 141801
		private string SkillIconPath;

		// Token: 0x040229EA RID: 141802
		private int InputIndex;

		// Token: 0x040229EB RID: 141803
		private TimerHandle HideCdTimerId;

		// Token: 0x040229EC RID: 141804
		private TimerHandle EquipEffectTimerId;

		// Token: 0x040229ED RID: 141805
		protected InputMultiKeyItem KeyItem;

		// Token: 0x040229EE RID: 141806
		protected int SetTextureHandleId;

		// Token: 0x040229EF RID: 141807
		private int? LoadCdCompletedNiagaraHandleId = new int?(0);

		// Token: 0x040229F0 RID: 141808
		protected string KeyActionName;

		// Token: 0x040229F1 RID: 141809
		protected EOperationType? KeyOperationType;

		// Token: 0x040229F2 RID: 141810
		protected BattleUiNiagaraItem ClickEffect;

		// Token: 0x040229F3 RID: 141811
		protected UUISprite CombinePressTipSprite;

		// Token: 0x040229F4 RID: 141812
		protected CSharpScript.Game.Input.EInputAction PressActionType = CSharpScript.Game.Input.EInputAction.None;

		// Token: 0x040229F5 RID: 141813
		private int LinkStatus;

		// Token: 0x040229F6 RID: 141814
		private bool HasBattleLinkEvent;

		// Token: 0x040229F7 RID: 141815
		private bool IsPlayingLinkEffect;

		// Token: 0x040229F8 RID: 141816
		private UUITexture SkillTexture;

		// Token: 0x040229F9 RID: 141817
		private UUISprite SkillSprite;

		// Token: 0x040229FA RID: 141818
		private UUITextureTransitionComponent SkillTextureTransitionComp;

		// Token: 0x040229FB RID: 141819
		private UUISpriteTransition SkillSpriteTransitionComp;

		// Token: 0x040229FC RID: 141820
		private UTexture DefaultSkillTextureData;

		// Token: 0x040229FD RID: 141821
		private ULGUISpriteData_BaseObject DefaultSkillSpriteData;

		// Token: 0x040229FE RID: 141822
		private bool IsDefaultSkillTexture;

		// Token: 0x040229FF RID: 141823
		private bool IsDefaultSkillSprite;

		// Token: 0x04022A00 RID: 141824
		private bool IsLoadingSkillIcon;

		// Token: 0x04022A01 RID: 141825
		protected bool HideCdText;

		// Token: 0x04022A02 RID: 141826
		protected int CdFixedPoint = 1;

		// Token: 0x04022A03 RID: 141827
		protected bool IsHideNumComp;

		// Token: 0x04022A04 RID: 141828
		private float TargetAlpha = 1f;

		// Token: 0x04022A05 RID: 141829
		private float BaseAlpha = 1f;

		// Token: 0x04022A06 RID: 141830
		protected UUIText SkillNameText;

		// Token: 0x04022A07 RID: 141831
		protected int UltraComponentVisibleState;

		// Token: 0x04022A08 RID: 141832
		private int LayoutIndex;

		// Token: 0x04022A09 RID: 141833
		private Action OnVisibleChangedCallback;

		// Token: 0x04022A0A RID: 141834
		private bool EnableSlideControl;

		// Token: 0x04022A0B RID: 141835
		protected BattleSkillUltraItem UltraComponent;

		// Token: 0x04022A0C RID: 141836
		protected BattleSkillNumItem NumComponent;

		// Token: 0x04022A0D RID: 141837
		protected BattleSkillDotIndicatorItem DotIndicatorComponent;

		// Token: 0x04022A0E RID: 141838
		protected BattleSkillSwitchComponent SwitchComponent;

		// Token: 0x04022A0F RID: 141839
		protected BattleSkillLongPressItem LongPressComponent;

		// Token: 0x04022A10 RID: 141840
		protected BattleSkillConfigLongPressItem ConfigLongPressComponent;

		// Token: 0x04022A11 RID: 141841
		protected BattleSkillExtraEffectItem ExtraEffectComponent;

		// Token: 0x04022A12 RID: 141842
		protected ULGUIPlayTweenComponent AlphaTweenComp;

		// Token: 0x0200C039 RID: 49209
		[NullableContext(0)]
		private enum EBattleSkillItem
		{
			// Token: 0x0403B2C2 RID: 242370
			CoolDownItem,
			// Token: 0x0403B2C3 RID: 242371
			CoolDownBarSprite,
			// Token: 0x0403B2C4 RID: 242372
			CoolDownText,
			// Token: 0x0403B2C5 RID: 242373
			SkillSprite,
			// Token: 0x0403B2C6 RID: 242374
			SkillTexture,
			// Token: 0x0403B2C7 RID: 242375
			SkillButton,
			// Token: 0x0403B2C8 RID: 242376
			CdCompletedNiagara,
			// Token: 0x0403B2C9 RID: 242377
			DynamicEffectNiagara,
			// Token: 0x0403B2CA RID: 242378
			ExtraContainer,
			// Token: 0x0403B2CB RID: 242379
			ExploreSkillEquip,
			// Token: 0x0403B2CC RID: 242380
			ClickEffectNiagara,
			// Token: 0x0403B2CD RID: 242381
			SkillNameText,
			// Token: 0x0403B2CE RID: 242382
			LinkExplosionNiagara,
			// Token: 0x0403B2CF RID: 242383
			CombinePressTipSprite,
			// Token: 0x0403B2D0 RID: 242384
			KeyItem
		}

		// Token: 0x0200C03A RID: 49210
		[NullableContext(0)]
		private enum EUltraComponentVisibleReason
		{
			// Token: 0x0403B2D2 RID: 242386
			Attribute,
			// Token: 0x0403B2D3 RID: 242387
			Link
		}
	}
}
