using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiModel.Struct;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002306 RID: 8966
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiySkinView : UiViewBase
{
	// Token: 0x0601104B RID: 69707 RVA: 0x004ABE0C File Offset: 0x004AA00C
	public MotorcycleDiySkinView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601104C RID: 69708 RVA: 0x004ABEAF File Offset: 0x004AA0AF
	protected override void OnBeforeCreate()
	{
		this.ModelInputBehavior = new UiBehaviorModelInput();
		base.AddUiBehavior(this.ModelInputBehavior);
	}

	// Token: 0x0601104D RID: 69709 RVA: 0x004ABEC8 File Offset: 0x004AA0C8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(13, new Action(this.OnBtnBackClick))
		};
	}

	// Token: 0x0601104E RID: 69710 RVA: 0x004AC028 File Offset: 0x004AA228
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleDiySkinView.<OnBeforeStartAsync>d__31 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleDiySkinView.<OnBeforeStartAsync>d__31>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601104F RID: 69711 RVA: 0x004AC06B File Offset: 0x004AA26B
	protected override void OnHandleLoadScene()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.CreateMotor(EUiModelUseWay.MotorInMotorView);
	}

	// Token: 0x06011050 RID: 69712 RVA: 0x004AC079 File Offset: 0x004AA279
	protected override void OnBeforeShow()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.SetSoarWingEnabled(true);
		Singleton<MotorcycleUiModelUtil>.Instance.ShowMotor(true);
		this.InitModelInputData();
		Singleton<MotorcycleUiModelUtil>.Instance.LoadMotorBySkinId(this.CurSkinId, delegate(UiModelBase _)
		{
			this.RefreshAutoRotateParam();
		});
		this.RefreshSkinTogItemsFromShop();
	}

	// Token: 0x06011051 RID: 69713 RVA: 0x004AC0BC File Offset: 0x004AA2BC
	protected override void OnAfterShow()
	{
		this.ClearCloseRotationRollbackTimer();
		this.IsClosingWithRotate = false;
		UiModelControlRotateComponent controlRotateComponent = this.ControlRotateComponent;
		if (controlRotateComponent != null)
		{
			controlRotateComponent.Activate();
		}
		this.CaptureInitialMotorRotation();
		UiModelControlRotateComponent controlRotateComponent2 = this.ControlRotateComponent;
		if (controlRotateComponent2 != null)
		{
			controlRotateComponent2.Deactivate();
		}
		this.RefreshAutoRotateParam();
		Singleton<MotorcycleUiModelUtil>.Instance.SetAutoRotate(true);
	}

	// Token: 0x06011052 RID: 69714 RVA: 0x004AC110 File Offset: 0x004AA310
	protected override void OnBeforeHide()
	{
		this.ResetAutoRotateLocation();
		if (this.IsClosingWithRotate)
		{
			return;
		}
		this.ClearCloseRotationRollbackTimer();
		Singleton<MotorcycleUiModelUtil>.Instance.SetAutoRotate(false);
		Singleton<MotorcycleUiModelUtil>.Instance.ShowMotor(false);
		Singleton<MotorcycleUiModelUtil>.Instance.SetSoarWingEnabled(false);
		UiModelControlRotateComponent controlRotateComponent = this.ControlRotateComponent;
		if (controlRotateComponent == null)
		{
			return;
		}
		controlRotateComponent.Deactivate();
	}

	// Token: 0x06011053 RID: 69715 RVA: 0x004AC163 File Offset: 0x004AA363
	protected override void OnHandleReleaseScene()
	{
		this.ClearCloseRotationRollbackTimer();
		this.ResetAutoRotateLocation();
		if (this.IsClosingWithRotate)
		{
			this.IsClosingWithRotate = false;
			UiModelControlRotateComponent controlRotateComponent = this.ControlRotateComponent;
			if (controlRotateComponent != null)
			{
				controlRotateComponent.Deactivate();
			}
		}
		Singleton<MotorcycleUiModelUtil>.Instance.DestroyMotor();
	}

	// Token: 0x06011054 RID: 69716 RVA: 0x004AC19C File Offset: 0x004AA39C
	private void CaptureInitialMotorRotation()
	{
		AActor motorActor = this.GetMotorActor();
		if (motorActor == null)
		{
			return;
		}
		Rotator initialMotorRotator = this.InitialMotorRotator;
		FRotator frotator = motorActor.K2_GetActorRotation();
		initialMotorRotator.FromUeRotator(frotator);
	}

	// Token: 0x06011055 RID: 69717 RVA: 0x004AC1C8 File Offset: 0x004AA3C8
	[NullableContext(2)]
	private AActor GetMotorActor()
	{
		UiModelBase motorModel = Singleton<MotorcycleUiModelUtil>.Instance.GetMotorModel();
		UiModelActorComponent uiModelActorComponent = (motorModel != null) ? motorModel.CheckGetComponent<UiModelActorComponent>() : null;
		if (uiModelActorComponent == null)
		{
			return null;
		}
		return uiModelActorComponent.Actor;
	}

	// Token: 0x06011056 RID: 69718 RVA: 0x004AC1EC File Offset: 0x004AA3EC
	private void InitModelInputData()
	{
		UiModelBase motorModel = Singleton<MotorcycleUiModelUtil>.Instance.GetMotorModel();
		UiModelControlRotateComponent uiModelControlRotateComponent = (motorModel != null) ? motorModel.CheckGetComponent<UiModelControlRotateComponent>() : null;
		if (uiModelControlRotateComponent == null)
		{
			return;
		}
		SUiModelRotateSetting uiModelRotateSettings = ModelUtil.GetUiModelRotateSettings("摩托车皮肤旋转");
		if (uiModelRotateSettings == null)
		{
			return;
		}
		uiModelControlRotateComponent.InitDataByConfig(uiModelRotateSettings);
		UiModelInputData data = new UiModelInputData
		{
			DragComponent = base.GetDraggable(10),
			ModelBase = motorModel
		};
		UiBehaviorModelInput modelInputBehavior = this.ModelInputBehavior;
		if (modelInputBehavior != null)
		{
			modelInputBehavior.InitData(data);
		}
		if (this.ModelInputBehavior != null)
		{
			this.ModelInputBehavior.OnDragBegin = new Action(this.OnMotorModelDragBegin);
			this.ModelInputBehavior.OnDragEnd = new Action(this.OnMotorModelDragEnd);
			this.ModelInputBehavior.OnGamepadInputBegin = new Action(this.OnMotorModelDragBegin);
			this.ModelInputBehavior.OnGamepadInputEnd = new Action(this.OnMotorModelDragEnd);
		}
		this.ControlRotateComponent = uiModelControlRotateComponent;
	}

	// Token: 0x06011057 RID: 69719 RVA: 0x004AC2C9 File Offset: 0x004AA4C9
	private void RefreshAutoRotateParam()
	{
		this.SetAutoRotateCenterCase(this.AutoRotateCenterCase);
		Singleton<MotorcycleUiModelUtil>.Instance.InitAutoRotateParam(this.AutoRotateDuration, ERotateAxis.Yaw, true);
	}

	// Token: 0x06011058 RID: 69720 RVA: 0x004AC2EC File Offset: 0x004AA4EC
	private void SetAutoRotateCenterCase(string centerCase)
	{
		this.ResetAutoRotateLocation();
		UiModelBase motorModel = Singleton<MotorcycleUiModelUtil>.Instance.GetMotorModel();
		UiModelActorComponent uiModelActorComponent = (motorModel != null) ? motorModel.CheckGetComponent<UiModelActorComponent>() : null;
		AActor aactor = (uiModelActorComponent != null) ? uiModelActorComponent.Actor : null;
		USkeletalMeshComponent uskeletalMeshComponent = (uiModelActorComponent != null) ? uiModelActorComponent.MainMeshComponent : null;
		FName? dynamicFName = FNameUtil.GetDynamicFName(centerCase);
		AActor aactor2 = (dynamicFName == null) ? null : UKuroCollectActorComponent.GetActorWithTag(dynamicFName.Value, ECollectActorType.UI);
		if (aactor == null || uskeletalMeshComponent == null || aactor2 == null)
		{
			return;
		}
		global::Vector autoRotateActorLocation = this.AutoRotateActorLocation;
		FVectorDouble fvectorDouble = aactor.D_K2_GetActorLocation();
		autoRotateActorLocation.FromUeVector(fvectorDouble);
		global::Vector autoRotateMeshRelativeLocation = this.AutoRotateMeshRelativeLocation;
		FVector relativeLocation = uskeletalMeshComponent.RelativeLocation;
		autoRotateMeshRelativeLocation.FromUeVector(relativeLocation);
		global::Vector autoRotateCenterLocation = this.AutoRotateCenterLocation;
		fvectorDouble = aactor2.D_K2_GetActorLocation();
		autoRotateCenterLocation.FromUeVector(fvectorDouble);
		this.AutoRotateMeshRelativeLocation.Addition(this.AutoRotateActorLocation, this.AutoRotateMeshOffset);
		this.AutoRotateMeshOffset.Subtraction(this.AutoRotateCenterLocation, this.AutoRotateMeshOffset);
		aactor.D_K2_SetActorLocation(this.AutoRotateCenterLocation.ToUeVector(false), false, ref WorldGlobal.SweepHitResult, false);
		uskeletalMeshComponent.K2_SetRelativeLocation(this.AutoRotateMeshOffset.ToUeVectorOld(), false, ref WorldGlobal.SweepHitResult, false);
		this.HasAutoRotateLocationCache = true;
	}

	// Token: 0x06011059 RID: 69721 RVA: 0x004AC404 File Offset: 0x004AA604
	private void ResetAutoRotateLocation()
	{
		if (!this.HasAutoRotateLocationCache)
		{
			return;
		}
		UiModelBase motorModel = Singleton<MotorcycleUiModelUtil>.Instance.GetMotorModel();
		UiModelActorComponent uiModelActorComponent = (motorModel != null) ? motorModel.CheckGetComponent<UiModelActorComponent>() : null;
		if (uiModelActorComponent != null)
		{
			AActor actor = uiModelActorComponent.Actor;
			if (actor != null)
			{
				actor.D_K2_SetActorLocation(this.AutoRotateActorLocation.ToUeVector(false), false, ref WorldGlobal.SweepHitResult, false);
			}
		}
		if (uiModelActorComponent != null)
		{
			USkeletalMeshComponent mainMeshComponent = uiModelActorComponent.MainMeshComponent;
			if (mainMeshComponent != null)
			{
				mainMeshComponent.K2_SetRelativeLocation(this.MeshDefaultRelativeLocation.ToUeVectorOld(), false, ref WorldGlobal.SweepHitResult, false);
			}
		}
		this.HasAutoRotateLocationCache = false;
	}

	// Token: 0x0601105A RID: 69722 RVA: 0x004AC48A File Offset: 0x004AA68A
	private MotorcycleDiySkinListItem InitListItem()
	{
		return new MotorcycleDiySkinListItem();
	}

	// Token: 0x0601105B RID: 69723 RVA: 0x004AC494 File Offset: 0x004AA694
	private List<MotorcycleDiySkinListItemData> GetCustomizeDataList(bool isBuy)
	{
		List<MotorcycleDiySkinListItemData> list = new List<MotorcycleDiySkinListItemData>();
		int canCustomizeNum = 0;
		int canCustomizeNum2 = 0;
		int canCustomizeNum3 = 0;
		if (!isBuy)
		{
			canCustomizeNum = 1;
			canCustomizeNum2 = MotorcycleDiyDefine.MOTORCYCLE_DIY_STICKER_PART.Length;
			canCustomizeNum3 = MotorcycleDiyDefine.MOTORCYCLE_DIY_DECORATION_PART.Length;
		}
		list.Add(new MotorcycleDiySkinListItemData(EOutlookType.Frame, canCustomizeNum));
		list.Add(new MotorcycleDiySkinListItemData(EOutlookType.Sticker, canCustomizeNum2));
		list.Add(new MotorcycleDiySkinListItemData(EOutlookType.Decoration, canCustomizeNum3));
		return list;
	}

	// Token: 0x0601105C RID: 69724 RVA: 0x004AC4E8 File Offset: 0x004AA6E8
	private void RefreshCurSkinInfo()
	{
		bool flag = ModelBase<MotorcycleDiyModel>.Instance.HasSkin(this.CurSkinId);
		bool flag2 = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedSkinId() == this.CurSkinId;
		MotorSkin? motorSkinConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorSkinConfig(this.CurSkinId);
		base.GetItem(11).SetUIActive(!flag);
		ButtonItem confirmBtnItem = this.ConfirmBtnItem;
		if (confirmBtnItem != null)
		{
			confirmBtnItem.SetUiActive(flag);
		}
		if (motorSkinConfig != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), motorSkinConfig.Value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), motorSkinConfig.Value.BgDescription, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), motorSkinConfig.Value.TypeDescription, Array.Empty<object>());
			if (!flag)
			{
				MotorcycleDiySkinObtainItem obtainItem = this.ObtainItem;
				if (obtainItem != null)
				{
					obtainItem.Refresh(motorSkinConfig.Value.GetItemAccessArray());
				}
			}
		}
		ButtonItem confirmBtnItem2 = this.ConfirmBtnItem;
		if (confirmBtnItem2 != null)
		{
			confirmBtnItem2.SetEnableClick(!flag2);
		}
		ButtonItem confirmBtnItem3 = this.ConfirmBtnItem;
		if (confirmBtnItem3 == null)
		{
			return;
		}
		confirmBtnItem3.SetLocalTextNew(flag2 ? "MotorSkin_OnUse" : "MotorSkin_UseButton", Array.Empty<object>());
	}

	// Token: 0x0601105D RID: 69725 RVA: 0x004AC628 File Offset: 0x004AA828
	private void RefreshSkinTogItems(bool isInit = false)
	{
		MotorcycleDiyModel instance = ModelBase<MotorcycleDiyModel>.Instance;
		int equippedSkinId = instance.GetEquippedSkinId();
		IReadOnlyList<MotorSkin> allMotorSkinList = ConfigBase<MotorDiyConfig>.Instance.GetAllMotorSkinList();
		MotorcycleDiySkinTogItem[] array = new MotorcycleDiySkinTogItem[]
		{
			this.NormalSkinTogItem,
			this.BuySkinTogItem
		};
		int num = 0;
		while (num < allMotorSkinList.Count && num < array.Length)
		{
			MotorcycleDiySkinTogItem motorcycleDiySkinTogItem = array[num];
			if (motorcycleDiySkinTogItem != null)
			{
				MotorSkin motorSkin = allMotorSkinList[num];
				bool flag = instance.HasSkin(motorSkin.Id);
				bool flag2 = equippedSkinId == motorSkin.Id;
				bool redDotVisible = instance.RedDotHasNewItem(motorSkin.Id);
				motorcycleDiySkinTogItem.Refresh(motorSkin.Id);
				motorcycleDiySkinTogItem.SetEquippedStatus(flag2);
				motorcycleDiySkinTogItem.SetLockedStatus(!flag);
				motorcycleDiySkinTogItem.SetRedDotVisible(redDotVisible);
				if (isInit)
				{
					this.CurSkinId = equippedSkinId;
					EToggleState state = flag2 ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
					motorcycleDiySkinTogItem.SetToggleStateForce(state, false);
				}
			}
			num++;
		}
	}

	// Token: 0x0601105E RID: 69726 RVA: 0x004AC710 File Offset: 0x004AA910
	private void RefreshSkinTogItemsFromShop()
	{
		MotorcycleDiyModel instance = ModelBase<MotorcycleDiyModel>.Instance;
		if (this.AcquireJumpSkinId == this.CurSkinId && instance.HasSkin(this.CurSkinId))
		{
			instance.CheckRedDotForAnyItem(this.CurSkinId);
			this.AcquireJumpSkinId = 0;
		}
		this.RefreshSkinTogItems(false);
	}

	// Token: 0x0601105F RID: 69727 RVA: 0x004AC75C File Offset: 0x004AA95C
	private void TryCloseWithRotationRollback()
	{
		if (this.IsClosingWithRotate)
		{
			return;
		}
		this.IsClosingWithRotate = true;
		Singleton<MotorcycleUiModelUtil>.Instance.SetAutoRotate(false);
		Singleton<MotorcycleUiModelUtil>.Instance.SetSoarWingEnabled(false);
		UiModelControlRotateComponent controlRotateComponent = this.ControlRotateComponent;
		if (controlRotateComponent != null)
		{
			controlRotateComponent.Deactivate();
		}
		this.ResetAutoRotateLocation();
		if (!this.StartCloseRotationRollback())
		{
			this.IsClosingWithRotate = false;
		}
		int equippedSkinId = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedSkinId();
		Singleton<MotorcycleUiModelUtil>.Instance.LoadMotorBySkinId(equippedSkinId, delegate(UiModelBase _)
		{
			base.CloseMe(null);
		});
	}

	// Token: 0x06011060 RID: 69728 RVA: 0x004AC7D7 File Offset: 0x004AA9D7
	private void OnCloseRotationRollbackDone()
	{
		this.ClearCloseRotationRollbackTimer();
		this.IsClosingWithRotate = false;
	}

	// Token: 0x06011061 RID: 69729 RVA: 0x004AC7E8 File Offset: 0x004AA9E8
	private bool StartCloseRotationRollback()
	{
		AActor motorActor = this.GetMotorActor();
		if (motorActor == null || this.CloseRotationRollbackDuration <= 0f)
		{
			return false;
		}
		Rotator rollbackStartRotator = this.RollbackStartRotator;
		FRotator frotator = motorActor.K2_GetActorRotation();
		rollbackStartRotator.FromUeRotator(frotator);
		this.RollbackElapsed = 0f;
		this.ClearCloseRotationRollbackTimer();
		this.RollbackTimerHandle = TimerSystem.Instance.Forever(new TTimerAction(this.UpdateCloseRotationRollback), 20f, 1f, null, "MotorcycleDiySkinView.CloseRotationRollback", true);
		return this.RollbackTimerHandle != null;
	}

	// Token: 0x06011062 RID: 69730 RVA: 0x004AC86C File Offset: 0x004AAA6C
	private void UpdateCloseRotationRollback(float delta)
	{
		AActor motorActor = this.GetMotorActor();
		if (motorActor == null)
		{
			this.OnCloseRotationRollbackDone();
			return;
		}
		this.RollbackElapsed += delta / 1000f;
		float num = Singleton<MathUtils>.Instance.Clamp(this.RollbackElapsed / this.CloseRotationRollbackDuration, 0f, 1f);
		Rotator.Lerp(this.RollbackStartRotator, this.InitialMotorRotator, this.EaseOutCubic(num), this.RollbackTempRotator);
		motorActor.K2_SetActorRotation(this.RollbackTempRotator.ToUeRotator(), false);
		if (num >= 1f)
		{
			this.OnCloseRotationRollbackDone();
		}
	}

	// Token: 0x06011063 RID: 69731 RVA: 0x004AC900 File Offset: 0x004AAB00
	private void ClearCloseRotationRollbackTimer()
	{
		TimerHandle rollbackTimerHandle = this.RollbackTimerHandle;
		if (rollbackTimerHandle != null && TimerSystem.Instance.Has(rollbackTimerHandle))
		{
			TimerSystem.Instance.Remove(rollbackTimerHandle);
		}
		this.RollbackTimerHandle = null;
	}

	// Token: 0x06011064 RID: 69732 RVA: 0x004AC938 File Offset: 0x004AAB38
	private float EaseOutCubic(float ratio)
	{
		float num = 1f - ratio;
		return 1f - num * num * num;
	}

	// Token: 0x06011065 RID: 69733 RVA: 0x004AC958 File Offset: 0x004AAB58
	private void OnMotorModelDragBegin()
	{
		if (this.IsClosingWithRotate)
		{
			return;
		}
		Singleton<MotorcycleUiModelUtil>.Instance.SetAutoRotate(false);
		UiModelControlRotateComponent controlRotateComponent = this.ControlRotateComponent;
		if (controlRotateComponent == null)
		{
			return;
		}
		controlRotateComponent.ResumeFromCurrentActorRotation();
	}

	// Token: 0x06011066 RID: 69734 RVA: 0x004AC97E File Offset: 0x004AAB7E
	private void OnMotorModelDragEnd()
	{
		if (this.IsClosingWithRotate)
		{
			return;
		}
		UiModelControlRotateComponent controlRotateComponent = this.ControlRotateComponent;
		if (controlRotateComponent != null)
		{
			controlRotateComponent.Deactivate();
		}
		Singleton<MotorcycleUiModelUtil>.Instance.SetAutoRotate(true);
	}

	// Token: 0x06011067 RID: 69735 RVA: 0x004AC9A5 File Offset: 0x004AABA5
	private void OnClickConfirm()
	{
		if (ModelBase<MotorcycleDiyModel>.Instance.IsEquipFrameLockedByPlayer())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorSkin_Tips03", Array.Empty<object>());
			return;
		}
		ControllerBase<MotorcycleDiyController>.Instance.EquipMotorSkinRequest(this.CurSkinId, delegate
		{
			this.RefreshSkinTogItems(false);
			this.RefreshCurSkinInfo();
			MotorSkin? motorSkinConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorSkinConfig(this.CurSkinId);
			if (motorSkinConfig != null)
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(motorSkinConfig.Value.Name, null);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorSkin_Tips01", new object[]
				{
					localTextNew
				});
			}
		});
	}

	// Token: 0x06011068 RID: 69736 RVA: 0x004AC9E4 File Offset: 0x004AABE4
	private bool OnExecuteChangeSkinToggle(int skinId)
	{
		return skinId != this.CurSkinId;
	}

	// Token: 0x06011069 RID: 69737 RVA: 0x004AC9F2 File Offset: 0x004AABF2
	private void OnClickObtain()
	{
		this.AcquireJumpSkinId = this.CurSkinId;
	}

	// Token: 0x0601106A RID: 69738 RVA: 0x004ACA00 File Offset: 0x004AAC00
	private void OnTogNormalSkinClick(int skinId)
	{
		MotorcycleDiySkinTogItem buySkinTogItem = this.BuySkinTogItem;
		if (buySkinTogItem != null)
		{
			buySkinTogItem.SetToggleStateForce(EToggleState.ETT_UnChecked, false);
		}
		GenericLayout<MotorcycleDiySkinListItem, MotorcycleDiySkinListItemData> customizeLayout = this.CustomizeLayout;
		if (customizeLayout != null)
		{
			customizeLayout.RefreshByData(this.NormalCustomizeDataList, null, false);
		}
		this.CurSkinId = skinId;
		this.ResetAutoRotateLocation();
		Singleton<MotorcycleUiModelUtil>.Instance.LoadMotorBySkinId(skinId, delegate(UiModelBase _)
		{
			this.RefreshAutoRotateParam();
		});
		this.RefreshCurSkinInfo();
	}

	// Token: 0x0601106B RID: 69739 RVA: 0x004ACA64 File Offset: 0x004AAC64
	private void OnTogBuySkinClick(int skinId)
	{
		MotorcycleDiySkinTogItem normalSkinTogItem = this.NormalSkinTogItem;
		if (normalSkinTogItem != null)
		{
			normalSkinTogItem.SetToggleStateForce(EToggleState.ETT_UnChecked, false);
		}
		GenericLayout<MotorcycleDiySkinListItem, MotorcycleDiySkinListItemData> customizeLayout = this.CustomizeLayout;
		if (customizeLayout != null)
		{
			customizeLayout.RefreshByData(this.BuyCustomizeDataList, null, false);
		}
		this.CurSkinId = skinId;
		this.ResetAutoRotateLocation();
		Singleton<MotorcycleUiModelUtil>.Instance.LoadMotorBySkinId(skinId, delegate(UiModelBase _)
		{
			this.RefreshAutoRotateParam();
		});
		this.RefreshCurSkinInfo();
		MotorcycleDiySkinTogItem buySkinTogItem = this.BuySkinTogItem;
		if (buySkinTogItem != null)
		{
			buySkinTogItem.SetRedDotVisible(false);
		}
		ModelBase<MotorcycleDiyModel>.Instance.CheckRedDotForAnyItem(skinId);
	}

	// Token: 0x0601106C RID: 69740 RVA: 0x004ACAE4 File Offset: 0x004AACE4
	private void OnBtnBackClick()
	{
		this.TryCloseWithRotationRollback();
	}

	// Token: 0x040085EA RID: 34282
	[Nullable(2)]
	private MotorcycleDiySkinTogItem NormalSkinTogItem;

	// Token: 0x040085EB RID: 34283
	[Nullable(2)]
	private MotorcycleDiySkinTogItem BuySkinTogItem;

	// Token: 0x040085EC RID: 34284
	[Nullable(2)]
	private MotorcycleDiySkinObtainItem ObtainItem;

	// Token: 0x040085ED RID: 34285
	[Nullable(2)]
	private ButtonItem ConfirmBtnItem;

	// Token: 0x040085EE RID: 34286
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MotorcycleDiySkinListItem, MotorcycleDiySkinListItemData> CustomizeLayout;

	// Token: 0x040085EF RID: 34287
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x040085F0 RID: 34288
	[Nullable(2)]
	private UiBehaviorModelInput ModelInputBehavior;

	// Token: 0x040085F1 RID: 34289
	[Nullable(2)]
	protected UiModelControlRotateComponent ControlRotateComponent;

	// Token: 0x040085F2 RID: 34290
	private int CurSkinId;

	// Token: 0x040085F3 RID: 34291
	private int AcquireJumpSkinId;

	// Token: 0x040085F4 RID: 34292
	private readonly List<MotorcycleDiySkinListItemData> NormalCustomizeDataList = new List<MotorcycleDiySkinListItemData>();

	// Token: 0x040085F5 RID: 34293
	private readonly List<MotorcycleDiySkinListItemData> BuyCustomizeDataList = new List<MotorcycleDiySkinListItemData>();

	// Token: 0x040085F6 RID: 34294
	private float CloseRotationRollbackDuration = 0.6f;

	// Token: 0x040085F7 RID: 34295
	private float AutoRotateDuration = 10f;

	// Token: 0x040085F8 RID: 34296
	private string AutoRotateCenterCase = "FreeCase";

	// Token: 0x040085F9 RID: 34297
	private bool IsClosingWithRotate;

	// Token: 0x040085FA RID: 34298
	private readonly Rotator InitialMotorRotator = Rotator.Create();

	// Token: 0x040085FB RID: 34299
	private readonly Rotator RollbackStartRotator = Rotator.Create();

	// Token: 0x040085FC RID: 34300
	private readonly Rotator RollbackTempRotator = Rotator.Create();

	// Token: 0x040085FD RID: 34301
	private float RollbackElapsed;

	// Token: 0x040085FE RID: 34302
	[Nullable(2)]
	private TimerHandle RollbackTimerHandle;

	// Token: 0x040085FF RID: 34303
	private readonly global::Vector AutoRotateActorLocation = global::Vector.Create();

	// Token: 0x04008600 RID: 34304
	private readonly global::Vector AutoRotateMeshRelativeLocation = global::Vector.Create();

	// Token: 0x04008601 RID: 34305
	private readonly global::Vector AutoRotateCenterLocation = global::Vector.Create();

	// Token: 0x04008602 RID: 34306
	private readonly global::Vector AutoRotateMeshOffset = global::Vector.Create();

	// Token: 0x04008603 RID: 34307
	private readonly global::Vector MeshDefaultRelativeLocation = global::Vector.Create();

	// Token: 0x04008604 RID: 34308
	private bool HasAutoRotateLocationCache;

	// Token: 0x02008608 RID: 34312
	[NullableContext(0)]
	private class EMotorDiySkinComponent
	{
		// Token: 0x0402D564 RID: 185700
		public const int CaptionItem = 0;

		// Token: 0x0402D565 RID: 185701
		public const int DefaultSkinToggle = 1;

		// Token: 0x0402D566 RID: 185702
		public const int BuySkinToggle = 2;

		// Token: 0x0402D567 RID: 185703
		public const int TxtSkinName = 3;

		// Token: 0x0402D568 RID: 185704
		public const int TxtSkinDesc = 4;

		// Token: 0x0402D569 RID: 185705
		public const int CustomizeLayout = 5;

		// Token: 0x0402D56A RID: 185706
		public const int CustomizeItem = 6;

		// Token: 0x0402D56B RID: 185707
		public const int Deprecated = 7;

		// Token: 0x0402D56C RID: 185708
		public const int ObtainItem = 8;

		// Token: 0x0402D56D RID: 185709
		public const int BtnConfirm = 9;

		// Token: 0x0402D56E RID: 185710
		public const int DragComponent = 10;

		// Token: 0x0402D56F RID: 185711
		public const int ObtainParentItem = 11;

		// Token: 0x0402D570 RID: 185712
		public const int TxtSkinTypeDescription = 12;

		// Token: 0x0402D571 RID: 185713
		public const int BtnBack = 13;
	}
}
