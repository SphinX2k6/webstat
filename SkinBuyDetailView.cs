using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002A3A RID: 10810
[NullableContext(2)]
[Nullable(0)]
public class SkinBuyDetailView : UiTickViewBase
{
	// Token: 0x06015A17 RID: 88599 RVA: 0x00600605 File Offset: 0x005FE805
	[NullableContext(1)]
	public SkinBuyDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015A18 RID: 88600 RVA: 0x00600610 File Offset: 0x005FE810
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUITexture)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(17, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIText)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIText)),
			new ValueTuple<int, Type>(22, typeof(UUITexture)),
			new ValueTuple<int, Type>(23, typeof(UUITexture)),
			new ValueTuple<int, Type>(24, typeof(UUITexture)),
			new ValueTuple<int, Type>(25, typeof(UUIItem)),
			new ValueTuple<int, Type>(26, typeof(UUITexture)),
			new ValueTuple<int, Type>(27, typeof(UUIItem)),
			new ValueTuple<int, Type>(28, typeof(UUIItem)),
			new ValueTuple<int, Type>(29, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(30, typeof(UUITexture)),
			new ValueTuple<int, Type>(31, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(32, typeof(UUIItem)),
			new ValueTuple<int, Type>(33, typeof(UUIItem)),
			new ValueTuple<int, Type>(34, typeof(UUITexture)),
			new ValueTuple<int, Type>(35, typeof(UUIText)),
			new ValueTuple<int, Type>(36, typeof(UUITexture)),
			new ValueTuple<int, Type>(37, typeof(UUIText)),
			new ValueTuple<int, Type>(38, typeof(UUIItem)),
			new ValueTuple<int, Type>(39, typeof(UUIItem)),
			new ValueTuple<int, Type>(40, typeof(UUIText)),
			new ValueTuple<int, Type>(41, typeof(UUITexture)),
			new ValueTuple<int, Type>(42, typeof(UUIText)),
			new ValueTuple<int, Type>(43, typeof(UUITexture)),
			new ValueTuple<int, Type>(44, typeof(UUIText)),
			new ValueTuple<int, Type>(45, typeof(UUIItem)),
			new ValueTuple<int, Type>(46, typeof(UUIItem)),
			new ValueTuple<int, Type>(47, typeof(UUIItem)),
			new ValueTuple<int, Type>(48, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(49, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(50, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickDetailIconButton)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickLeftButton)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickRightButton)),
			new ValueTuple<int, Delegate>(17, new Action(this.OnClickBuyButton)),
			new ValueTuple<int, Delegate>(8, new Action<EToggleState>(this.OnClickToggleLeft)),
			new ValueTuple<int, Delegate>(31, new Action<EToggleState>(this.OnClickToggleRight)),
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickOnlyUiToggle)),
			new ValueTuple<int, Delegate>(48, new Action<EToggleState>(this.OnClickToggleMale)),
			new ValueTuple<int, Delegate>(49, new Action<EToggleState>(this.OnClickToggleFemale))
		};
	}

	// Token: 0x06015A19 RID: 88601 RVA: 0x00600B9C File Offset: 0x005FED9C
	protected override void OnAddEventListener()
	{
		UUIDraggableComponent draggable = base.GetDraggable(29);
		draggable.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginDragCallBack));
		draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDragCallBack));
		draggable.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEndDragCallBack));
		draggable.OnPointerScrollCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerScrollCallBack));
		Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerRoleLookUp, new Action<float>(this.OnInputUiLookUp));
		Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerRoleTurn, new Action<float>(this.OnInputUiTurn));
		Singleton<EventSystem>.Instance.Add<string, float>(EEventName.NavigationTriggerRoleZoom, new Action<string, float>(this.OnInputUiZoom));
		Singleton<EventSystem>.Instance.Add(EEventName.NavigationTriggerRoleReset, new Action(this.OnRightStickPress));
		ControllerBase<InputDistributeController>.Instance.BindTouches(new int[]
		{
			0,
			1
		}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		Singleton<EventSystem>.Instance.Add<UiCameraHandleData, UiCameraHandleData, string>(EEventName.OnPlayCameraAnimationStart, new Action<UiCameraHandleData, UiCameraHandleData, string>(this.OnPlayCameraAnimationStart));
		Singleton<EventSystem>.Instance.Add<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Add<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06015A1A RID: 88602 RVA: 0x00600D0C File Offset: 0x005FEF0C
	protected void RemoveCameraEventListener()
	{
		UUIDraggableComponent draggable = base.GetDraggable(29);
		draggable.OnPointerBeginDragCallBack.Unbind();
		draggable.OnPointerDragCallBack.Unbind();
		draggable.OnPointerEndDragCallBack.Unbind();
		draggable.OnPointerScrollCallBack.Unbind();
		Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerRoleLookUp, new Action<float>(this.OnInputUiLookUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerRoleTurn, new Action<float>(this.OnInputUiTurn));
		Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerRoleZoom, new Action<string, float>(this.OnInputUiZoom));
		Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerRoleReset, new Action(this.OnRightStickPress));
		ControllerBase<InputDistributeController>.Instance.UnBindTouches(new <>z__ReadOnlyArray<int>(new int[]
		{
			0,
			1
		}), new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayCameraAnimationStart, new Action<UiCameraHandleData, UiCameraHandleData, string>(this.OnPlayCameraAnimationStart));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06015A1B RID: 88603 RVA: 0x00600E51 File Offset: 0x005FF051
	[NullableContext(1)]
	private void OnPayItemSuccess(PayItemSuccess notify)
	{
		this.RefreshView();
	}

	// Token: 0x06015A1C RID: 88604 RVA: 0x00600E5C File Offset: 0x005FF05C
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
	{
		ShopSkinData currentGoodsData = this.ViewData.GetCurrentGoodsData();
		int? num = (currentGoodsData != null) ? new int?(currentGoodsData.GetCurrentGoodsData().GetGoodsId()) : null;
		if (!(goodsId == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		this.RefreshView();
	}

	// Token: 0x06015A1D RID: 88605 RVA: 0x00600EAE File Offset: 0x005FF0AE
	protected override void OnHandleLoadScene()
	{
		TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
		object obj;
		if (tsUiSceneRoleActor == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = tsUiSceneRoleActor.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return;
		}
		obj2.SetTransformByTag("RoleCase");
	}

	// Token: 0x06015A1E RID: 88606 RVA: 0x00600EDD File Offset: 0x005FF0DD
	[NullableContext(1)]
	private void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification _)
	{
		if (touchData.TouchType == InputDistributeDefine.ETouchType.TouchMove)
		{
			this.TouchMoved();
		}
	}

	// Token: 0x06015A1F RID: 88607 RVA: 0x00600EF0 File Offset: 0x005FF0F0
	private void TouchMoved()
	{
		if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1)
		{
			float fingerExpandCloseValue = Singleton<TouchFingerManager>.Instance.GetFingerExpandCloseValue(EFingerIndex.One, EFingerIndex.Two);
			this.UiCameraControlRotationComponent.AddZoomInput(-fingerExpandCloseValue);
		}
	}

	// Token: 0x06015A20 RID: 88608 RVA: 0x00600F24 File Offset: 0x005FF124
	private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
	{
		this.CurrentDragPosition = new FVector?(eventData.GetLocalPointInPlane());
	}

	// Token: 0x06015A21 RID: 88609 RVA: 0x00600F38 File Offset: 0x005FF138
	private void OnPointerDragCallBack(ULGUIPointerEventData eventData)
	{
		if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1 || Singleton<InputSettings>.Instance.IsInputKeyDown("RightMouseButton"))
		{
			this.CurrentDragPosition = null;
			return;
		}
		FVector? currentDragPosition = this.CurrentDragPosition;
		this.CurrentDragPosition = new FVector?(eventData.GetLocalPointInPlane());
		if (currentDragPosition == null)
		{
			return;
		}
		float num = this.CurrentDragPosition.Value.X - currentDragPosition.Value.X;
		float num2 = this.CurrentDragPosition.Value.Y - currentDragPosition.Value.Y;
		if (num != 0f)
		{
			this.UiCameraControlRotationComponent.AddYawInput(num);
		}
		if (num2 != 0f)
		{
			this.UiCameraControlRotationComponent.AddPitchInput(num2);
		}
	}

	// Token: 0x06015A22 RID: 88610 RVA: 0x00600FF6 File Offset: 0x005FF1F6
	private void OnPointerEndDragCallBack(ULGUIPointerEventData eventData)
	{
		this.CurrentDragPosition = null;
	}

	// Token: 0x06015A23 RID: 88611 RVA: 0x00601004 File Offset: 0x005FF204
	private void OnPointerScrollCallBack(ULGUIPointerEventData eventData)
	{
		if (eventData.scrollAxisValue != 0f)
		{
			this.UiCameraControlRotationComponent.AddZoomInput(-eventData.scrollAxisValue);
		}
	}

	// Token: 0x06015A24 RID: 88612 RVA: 0x00601028 File Offset: 0x005FF228
	protected override void OnBeforeShow()
	{
		TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
		UiModelBase uiModelBase = (tsUiSceneRoleActor != null) ? tsUiSceneRoleActor.Model : null;
		if (uiModelBase != null)
		{
			Singleton<UiModelUtil>.Instance.SetVisible(uiModelBase, true);
		}
		string stringConfig = ConfigCommonParamById.GetStringConfig("ShopPreviewCharacterSkinIcon");
		string stringConfig2 = ConfigCommonParamById.GetStringConfig("ShopPreviewCharacterSkinPackIcon");
		base.SetTextureByPath(stringConfig, base.GetTexture(34), null, null);
		base.SetTextureByPath(stringConfig2, base.GetTexture(36), null, null);
		string stringConfig3 = ConfigCommonParamById.GetStringConfig("ShopPreviewCharacterSkinText");
		string stringConfig4 = ConfigCommonParamById.GetStringConfig("ShopPreviewCharacterSkinPackText");
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(35), stringConfig3, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(37), stringConfig4, Array.Empty<object>());
		UUIItem item = base.GetItem(45);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIItem item2 = base.GetItem(46);
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
		this.RefreshView();
	}

	// Token: 0x06015A25 RID: 88613 RVA: 0x00601118 File Offset: 0x005FF318
	protected override void OnAfterShow()
	{
		this.RefreshCameraRotationComponentByViewType();
	}

	// Token: 0x06015A26 RID: 88614 RVA: 0x00601120 File Offset: 0x005FF320
	protected override void OnAfterHide()
	{
		TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
		UiModelBase uiModelBase = (tsUiSceneRoleActor != null) ? tsUiSceneRoleActor.Model : null;
		if (uiModelBase != null)
		{
			Singleton<UiModelUtil>.Instance.SetVisible(uiModelBase, false);
		}
	}

	// Token: 0x06015A27 RID: 88615 RVA: 0x00601150 File Offset: 0x005FF350
	private void RefreshCameraRotationComponentByViewType()
	{
		if (Singleton<UiCameraAnimationManager>.Instance.IsPlayingAnimation())
		{
			return;
		}
		string configId = (this.CurrentSkinTypeIndex == 0) ? ConfigBase<PayShopConfig>.Instance.GetBuySkinDetailRoleCameraConfigId() : ConfigBase<PayShopConfig>.Instance.GetBuySkinDetailWeaponCameraConfigId();
		this.RefreshCameraRotationComponent(configId);
	}

	// Token: 0x06015A28 RID: 88616 RVA: 0x00601190 File Offset: 0x005FF390
	[NullableContext(1)]
	private void RefreshCameraRotationComponent(string configId)
	{
		UiCamera uiCamera = UiCameraManager.Get();
		this.UiCameraControlRotationComponent = (uiCamera.AddUiCameraComponent(typeof(UiCameraControlRotationComponent), false) as UiCameraControlRotationComponent);
		SUiRoleCameraSetting? roleCameraConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig(configId);
		if (roleCameraConfig == null)
		{
			return;
		}
		this.UiCameraControlRotationComponent.InitDataByConfig(roleCameraConfig.Value);
		this.UiCameraControlRotationComponent.SetNeedFloorReflection(true);
		FVectorDouble sourceLocation = this.TsUiSceneRoleActor.D_K2_GetActorLocation();
		int roleId = this.ViewData.GetCurrentSkinData().GetRoleId();
		if (roleId == 0)
		{
			return;
		}
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		if (roleConfig == null)
		{
			return;
		}
		string roleBody = roleConfig.Value.RoleBody;
		SUiRoleCameraOffsetSetting? roleCameraOffsetConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraOffsetConfig(roleBody);
		if (roleCameraOffsetConfig == null)
		{
			return;
		}
		this.UiCameraControlRotationComponent.UpdateData(sourceLocation, roleCameraOffsetConfig.Value.镜头浮动最大高度, roleCameraOffsetConfig.Value.镜头浮动最低高度, roleCameraOffsetConfig.Value.镜头浮动最长臂长, roleCameraOffsetConfig.Value.镜头浮动最短臂长);
		this.UiCameraControlRotationComponent.Activate();
		this.UiCameraControlRotationComponent.ResumeTick();
	}

	// Token: 0x06015A29 RID: 88617 RVA: 0x006012A7 File Offset: 0x005FF4A7
	private void OnInputUiLookUp(float value)
	{
		if (value == 0f || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.UiCameraControlRotationComponent.AddPitchInput(-value);
	}

	// Token: 0x06015A2A RID: 88618 RVA: 0x006012CB File Offset: 0x005FF4CB
	private void OnInputUiTurn(float value)
	{
		if (value == 0f || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.UiCameraControlRotationComponent.AddYawInput(value);
	}

	// Token: 0x06015A2B RID: 88619 RVA: 0x006012EE File Offset: 0x005FF4EE
	[NullableContext(1)]
	private void OnInputUiZoom(string axisName, float value)
	{
		if (value == 0f || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.UiCameraControlRotationComponent.AddZoomInput(value);
	}

	// Token: 0x06015A2C RID: 88620 RVA: 0x00601314 File Offset: 0x005FF514
	private void OnRightStickPress()
	{
		UiCameraHandleData lastHandleData = Singleton<UiCameraAnimationManager>.Instance.GetLastHandleData();
		if (lastHandleData != null)
		{
			Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(lastHandleData.HandleName, true, true, "1001", false, null, null);
		}
	}

	// Token: 0x06015A2D RID: 88621 RVA: 0x00601354 File Offset: 0x005FF554
	protected override void OnStart()
	{
		this.TsUiSceneRoleActor = Singleton<UiSceneManager>.Instance.InitRoleSystemRoleActor(EUiModelUseWay.RoleInSkinView);
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.CloseView));
		this.ViewData = (this.OpenParam as SkinBuyDetailViewData);
		this.CaptionItem.SetTitleLocalText(this.ViewData.GetPreviewTitle());
		this.CaptionItem.SetTitleIconByResourceId("RoleSkinShopTitle_Icon");
		this.CaptionItem.SetHelpBtnActive(true);
		this.CaptionItem.SetHelpCallBack(new Action(this.OnClickedHelpButton));
		this.ItemLayout = new GenericLayout<SkinRewardItemGrid, SkinRewardData>(base.GetHorizontalLayout(10), new Func<SkinRewardItemGrid>(this.InitGridItem), null, false, true);
		base.GetExtendToggle(8).CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
		base.GetExtendToggle(31).CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
		this.ResetCurrentSkinTypeIndex();
	}

	// Token: 0x06015A2E RID: 88622 RVA: 0x0060145A File Offset: 0x005FF65A
	private bool CanToggleExecuteChange()
	{
		return Singleton<TimeUtil>.Instance.GetServerTimeStamp() - this.LastSwitchTime >= (double)ConfigBase<SkinConfig>.Instance.GetSkinDetailButtonSwitchGap();
	}

	// Token: 0x06015A2F RID: 88623 RVA: 0x0060147D File Offset: 0x005FF67D
	[NullableContext(1)]
	private SkinRewardItemGrid InitGridItem()
	{
		return new SkinRewardItemGrid();
	}

	// Token: 0x06015A30 RID: 88624 RVA: 0x00601484 File Offset: 0x005FF684
	protected override void OnBeforeHide()
	{
		this.RemoveCameraEventListener();
		this.UiCameraControlRotationComponent.PauseTick();
	}

	// Token: 0x06015A31 RID: 88625 RVA: 0x00601497 File Offset: 0x005FF697
	protected override void OnBeforeDestroy()
	{
		UiCameraManager.Get().DestroyUiCameraComponent(typeof(UiCameraControlRotationComponent));
		Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.TsUiSceneRoleActor);
		this.TsUiSceneRoleActor = null;
	}

	// Token: 0x06015A32 RID: 88626 RVA: 0x006014C8 File Offset: 0x005FF6C8
	private void RefreshRolePerformance()
	{
		int roleId = this.ViewData.GetCurrentSkinData().GetRoleId();
		if (roleId == 0)
		{
			return;
		}
		ControllerBase<RoleController>.Instance.RefreshUiSceneRoleActorByConfigId(roleId, this.ViewData.GetCurrentSkinData().GetItemId(), new Action(this.RefreshWeaponMesh));
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSelectedRoleChanged);
	}

	// Token: 0x06015A33 RID: 88627 RVA: 0x00601524 File Offset: 0x005FF724
	private void RefreshMontageByCurrentSkinType()
	{
		EPerformanceRoleState roleState = (this.CurrentSkinTypeIndex == 0) ? EPerformanceRoleState.Attribute_Perform : EPerformanceRoleState.Weapon;
		TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
		object obj;
		if (tsUiSceneRoleActor == null)
		{
			obj = null;
		}
		else
		{
			UiModelBase model = tsUiSceneRoleActor.Model;
			obj = ((model != null) ? model.CheckGetComponent<UiRoleStateMachineComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return;
		}
		obj2.SetState(roleState, false, false, false);
	}

	// Token: 0x06015A34 RID: 88628 RVA: 0x0060156C File Offset: 0x005FF76C
	private void RefreshWeaponMesh()
	{
		SkinBuyDetailView.<>c__DisplayClass41_0 CS$<>8__locals1 = new SkinBuyDetailView.<>c__DisplayClass41_0();
		SkinBuyDetailViewData viewData = this.ViewData;
		WeaponSkin? weaponSkin = (viewData != null) ? viewData.GetCurrentSkinData().GetSuitWeaponSkinConfig() : null;
		if (weaponSkin == null)
		{
			return;
		}
		SkinBuyDetailView.<>c__DisplayClass41_0 CS$<>8__locals2 = CS$<>8__locals1;
		TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
		UiRoleWeaponComponent component;
		if (tsUiSceneRoleActor == null)
		{
			component = null;
		}
		else
		{
			UiModelBase model = tsUiSceneRoleActor.Model;
			component = ((model != null) ? model.CheckGetComponent<UiRoleWeaponComponent>() : null);
		}
		CS$<>8__locals2.component = component;
		if (CS$<>8__locals1.component == null)
		{
			return;
		}
		CS$<>8__locals1.component.ReplaceWeaponModel(weaponSkin.Value.Models(), delegate
		{
			UiRoleWeaponComponent component2 = CS$<>8__locals1.component;
			if (component2 != null)
			{
				component2.RefreshWeaponCase();
			}
			UiRoleWeaponComponent component3 = CS$<>8__locals1.component;
			if (component3 == null)
			{
				return;
			}
			component3.AttachWeaponToRole();
		});
	}

	// Token: 0x06015A35 RID: 88629 RVA: 0x006015FC File Offset: 0x005FF7FC
	private void CloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x06015A36 RID: 88630 RVA: 0x00601605 File Offset: 0x005FF805
	protected override void OnHandleReleaseScene()
	{
		this.HandleReleaseScene();
	}

	// Token: 0x06015A37 RID: 88631 RVA: 0x0060160D File Offset: 0x005FF80D
	private void HandleReleaseScene()
	{
	}

	// Token: 0x06015A38 RID: 88632 RVA: 0x00601610 File Offset: 0x005FF810
	private void OnClickToggleRight(EToggleState toggleState)
	{
		this.CurrentSkinTypeIndex = 1;
		this.RefreshMontageByCurrentSkinType();
		this.RefreshCameraBySkinType();
		this.LastSwitchTime = 0.0;
		base.GetExtendToggle(8).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.LastSwitchTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
	}

	// Token: 0x06015A39 RID: 88633 RVA: 0x00601660 File Offset: 0x005FF860
	private void OnClickToggleLeft(EToggleState toggleState)
	{
		this.CurrentSkinTypeIndex = 0;
		this.RefreshMontageByCurrentSkinType();
		this.RefreshCameraBySkinType();
		this.LastSwitchTime = 0.0;
		base.GetExtendToggle(31).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.LastSwitchTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
	}

	// Token: 0x06015A3A RID: 88634 RVA: 0x006016B1 File Offset: 0x005FF8B1
	[NullableContext(1)]
	private void OnPlayCameraAnimationStart(UiCameraHandleData uiCameraHandleData, UiCameraHandleData cameraHandleData, string arg3)
	{
		UiCameraControlRotationComponent uiCameraControlRotationComponent = this.UiCameraControlRotationComponent;
		if (uiCameraControlRotationComponent == null)
		{
			return;
		}
		uiCameraControlRotationComponent.PauseTick();
	}

	// Token: 0x06015A3B RID: 88635 RVA: 0x006016C3 File Offset: 0x005FF8C3
	[NullableContext(1)]
	private void OnActivateUiCameraAnimationHandle(UiCameraHandleData handleData)
	{
		this.RefreshCameraRotationComponentByViewType();
	}

	// Token: 0x06015A3C RID: 88636 RVA: 0x006016CC File Offset: 0x005FF8CC
	private void RefreshCameraBySkinType()
	{
		if (this.CurrentSkinTypeIndex == 0)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer("SkinBuyDetailView", true);
			UiCameraHandleData lastHandleData = Singleton<UiCameraAnimationManager>.Instance.GetLastHandleData();
			if (lastHandleData != null)
			{
				Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(lastHandleData.HandleName, true, true, "1001", true, delegate(UiCameraAnimationDefine.IFinishData _)
				{
					Singleton<UiLayer>.Instance.SetShowMaskLayer("SkinBuyDetailView", false);
				}, null);
				return;
			}
		}
		else
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer("SkinBuyDetailView", true);
			UiCameraHandleData lastHandleData2 = Singleton<UiCameraAnimationManager>.Instance.GetLastHandleData();
			if (lastHandleData2 != null)
			{
				Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(lastHandleData2.HandleName, true, true, "1001", true, delegate(UiCameraAnimationDefine.IFinishData _)
				{
					Singleton<UiLayer>.Instance.SetShowMaskLayer("SkinBuyDetailView", false);
				}, null);
			}
		}
	}

	// Token: 0x06015A3D RID: 88637 RVA: 0x006017A3 File Offset: 0x005FF9A3
	private void OnClickToggleMale(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		if (this.ViewData != null)
		{
			this.ViewData.SwitchToNextSkinData();
			this.ResetCurrentSkinTypeIndex();
			this.RefreshView();
			this.RefreshCameraBySkinType();
		}
		base.PlaySequence("Switch", null, true);
	}

	// Token: 0x06015A3E RID: 88638 RVA: 0x006017DC File Offset: 0x005FF9DC
	private void OnClickToggleFemale(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		if (this.ViewData != null)
		{
			this.ViewData.SwitchToNextSkinData();
			this.ResetCurrentSkinTypeIndex();
			this.RefreshView();
			this.RefreshCameraBySkinType();
		}
		base.PlaySequence("Switch", null, true);
	}

	// Token: 0x06015A3F RID: 88639 RVA: 0x00601818 File Offset: 0x005FFA18
	private void OnClickOnlyUiToggle(EToggleState toggleState)
	{
		bool state = base.GetItem(28).bIsUIActive;
		if (!state)
		{
			base.GetItem(28).SetUIActive(!state);
			base.GetButton(2).RootUIComp.Get().SetUIActive(!state);
			base.PlaySequence("UiIn", delegate
			{
			}, true);
			return;
		}
		base.PlaySequence("UiOut", delegate
		{
			this.GetItem(28).SetUIActive(!state);
			this.GetButton(2).RootUIComp.Get().SetUIActive(!state);
		}, true);
	}

	// Token: 0x06015A40 RID: 88640 RVA: 0x006018CC File Offset: 0x005FFACC
	private void OnClickBuyButton()
	{
		if (!this.ViewData.GetCurrentSkinData().GetIfHaveRole())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.NoRoleBuySkin);
			confirmBoxDataNew.FunctionMap[2] = new Action(this.StartBuyProcess);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		this.StartBuyProcess();
	}

	// Token: 0x06015A41 RID: 88641 RVA: 0x00601921 File Offset: 0x005FFB21
	private void StartBuyProcess()
	{
		ControllerBase<PayShopController>.Instance.OpenBuySkinDetailView(this.ViewData.GetCurrentGoodsData().GetCurrentGoodsData());
	}

	// Token: 0x06015A42 RID: 88642 RVA: 0x00601940 File Offset: 0x005FFB40
	private void OnClickRightButton()
	{
		if (Singleton<TimeUtil>.Instance.GetServerTimeStamp() - this.LastClickButtonTime < (double)ConfigBase<SkinConfig>.Instance.GetSkinDetailButtonGap())
		{
			return;
		}
		this.LastClickButtonTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		if (this.ViewData != null)
		{
			this.ViewData.SwitchToNextGoods();
			this.ResetCurrentSkinTypeIndex();
			this.RefreshView();
			this.RefreshCameraBySkinType();
		}
		base.PlaySequence("Switch", null, true);
	}

	// Token: 0x06015A43 RID: 88643 RVA: 0x006019B0 File Offset: 0x005FFBB0
	private void OnClickLeftButton()
	{
		if (Singleton<TimeUtil>.Instance.GetServerTimeStamp() - this.LastClickButtonTime < (double)ConfigBase<SkinConfig>.Instance.GetSkinDetailButtonGap())
		{
			return;
		}
		this.LastClickButtonTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		if (this.ViewData != null)
		{
			this.ViewData.SwitchToPreGoods();
			this.ResetCurrentSkinTypeIndex();
			this.RefreshView();
			this.RefreshCameraBySkinType();
		}
		base.PlaySequence("Switch", null, true);
	}

	// Token: 0x06015A44 RID: 88644 RVA: 0x00601A1E File Offset: 0x005FFC1E
	private void ResetCurrentSkinTypeIndex()
	{
		this.CurrentSkinTypeIndex = 0;
	}

	// Token: 0x06015A45 RID: 88645 RVA: 0x00601A27 File Offset: 0x005FFC27
	private void OnClickDetailIconButton()
	{
		ControllerBase<SkinController>.Instance.OpenSkinShowView(this.ViewData.GetCurrentSkinData().GetItemId());
	}

	// Token: 0x06015A46 RID: 88646 RVA: 0x00601A44 File Offset: 0x005FFC44
	private void RefreshView()
	{
		SkinBuyDetailViewData viewData = this.ViewData;
		if (viewData != null)
		{
			ShopSkinData currentGoodsData = viewData.GetCurrentGoodsData();
			if (currentGoodsData != null)
			{
				currentGoodsData.GetCurrentGoodsData().SaveRemindState((long)Singleton<TimeUtil>.Instance.GetServerTime());
			}
		}
		this.RefreshLeftButton(this.ViewData);
		this.RefreshRightButton(this.ViewData);
		this.RefreshSexPanel(this.ViewData);
		this.RefreshTitleText(this.ViewData);
		this.RefreshSubTitleText(this.ViewData);
		this.RefreshDescText(this.ViewData);
		this.RefreshSwitchItem(this.ViewData);
		this.RefreshRoleTexture(this.ViewData);
		this.RefreshWeaponTexture(this.ViewData);
		this.RefreshWeaponQualityTexture(this.ViewData);
		this.RefreshRoleQualityTexture(this.ViewData);
		this.RefreshDiscountText(this.ViewData);
		this.RefreshDiscountTime(this.ViewData);
		this.RefreshBuyItemIcon(this.ViewData);
		this.RefreshNowPriceText(this.ViewData);
		this.RefreshSourcePriceText(this.ViewData);
		this.RefreshPriceTextShowState(this.ViewData);
		this.RefreshBuyButtonState(this.ViewData);
		this.RefreshHaveItem(this.ViewData);
		this.RefreshNotHaveRoleItem(this.ViewData);
		this.RefreshExtraReward(this.ViewData);
		this.RefreshSwitchToggleByIndex();
		this.RefreshMontageByCurrentSkinType();
		this.RefreshRolePerformance();
		this.RefreshExtraRewardItem(this.ViewData);
		this.RefreshEffectItem(this.ViewData);
		this.RefreshCouponPrice(this.ViewData);
	}

	// Token: 0x06015A47 RID: 88647 RVA: 0x00601BB0 File Offset: 0x005FFDB0
	private void RefreshSwitchToggleByIndex()
	{
		base.GetExtendToggle(8).SetToggleState((this.CurrentSkinTypeIndex == 0) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		base.GetExtendToggle(31).SetToggleState((this.CurrentSkinTypeIndex == 1) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		this.RefreshMontageByCurrentSkinType();
	}

	// Token: 0x06015A48 RID: 88648 RVA: 0x00601C00 File Offset: 0x005FFE00
	private void RefreshDescText(SkinBuyDetailViewData data)
	{
		if (data == null)
		{
			base.GetText(12).SetText("", true);
			return;
		}
		string desc = data.GetCurrentSkinData().GetDesc();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), desc, Array.Empty<object>());
	}

	// Token: 0x06015A49 RID: 88649 RVA: 0x00601C48 File Offset: 0x005FFE48
	private void RefreshTitleText(SkinBuyDetailViewData data)
	{
		if (data == null)
		{
			base.GetText(5).SetText("", true);
			return;
		}
		string titleName = data.GetCurrentSkinData().GetTitleName();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), titleName, Array.Empty<object>());
	}

	// Token: 0x06015A4A RID: 88650 RVA: 0x00601C90 File Offset: 0x005FFE90
	private void RefreshSubTitleText(SkinBuyDetailViewData data)
	{
		if (data == null)
		{
			base.GetText(6).SetText("", true);
			return;
		}
		string subTitle = data.GetCurrentSkinData().GetSubTitle();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), subTitle, Array.Empty<object>());
	}

	// Token: 0x06015A4B RID: 88651 RVA: 0x00601CD8 File Offset: 0x005FFED8
	private void RefreshRightButton(SkinBuyDetailViewData data)
	{
		bool uiactive = data != null && data.CheckIfHaveMutiGood();
		base.GetButton(4).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x06015A4C RID: 88652 RVA: 0x00601D0C File Offset: 0x005FFF0C
	private void RefreshLeftButton(SkinBuyDetailViewData data)
	{
		bool uiactive = data != null && data.CheckIfHaveMutiGood();
		base.GetButton(3).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x06015A4D RID: 88653 RVA: 0x00601D40 File Offset: 0x005FFF40
	private void RefreshSwitchItem(SkinBuyDetailViewData data)
	{
		if (data == null)
		{
			return;
		}
		bool ifNeedShowSwitchItem = data.GetIfNeedShowSwitchItem();
		base.GetItem(7).SetUIActive(ifNeedShowSwitchItem);
	}

	// Token: 0x06015A4E RID: 88654 RVA: 0x00601D68 File Offset: 0x005FFF68
	private void RefreshRoleTexture(SkinBuyDetailViewData data)
	{
		if (data == null)
		{
			return;
		}
		string buyPreviewRoleCardPath = data.GetCurrentSkinData().GetBuyPreviewRoleCardPath();
		base.SetTextureByPath(buyPreviewRoleCardPath, base.GetTexture(23), null, null);
	}

	// Token: 0x06015A4F RID: 88655 RVA: 0x00601DA0 File Offset: 0x005FFFA0
	private void RefreshRoleQualityTexture(SkinBuyDetailViewData data)
	{
		if (data == null)
		{
			return;
		}
		string buyPreviewRoleQualityBgPath = data.GetCurrentSkinData().GetBuyPreviewRoleQualityBgPath();
		base.SetTextureByPath(buyPreviewRoleQualityBgPath, base.GetTexture(22), null, null);
	}

	// Token: 0x06015A50 RID: 88656 RVA: 0x00601DD8 File Offset: 0x005FFFD8
	private void RefreshWeaponTexture(SkinBuyDetailViewData data)
	{
		if (data == null)
		{
			base.GetTexture(26).SetUIActive(false);
			return;
		}
		if (data.GetCurrentSkinData().GetSuitWeaponSkinId() > 0)
		{
			string suitWeaponPreviewTexturePath = data.GetCurrentSkinData().GetSuitWeaponPreviewTexturePath();
			base.SetTextureByPath(suitWeaponPreviewTexturePath, base.GetTexture(26), null, null);
			base.GetTexture(26).SetUIActive(true);
			return;
		}
		base.GetTexture(26).SetUIActive(false);
	}

	// Token: 0x06015A51 RID: 88657 RVA: 0x00601E4C File Offset: 0x0060004C
	private void RefreshWeaponQualityTexture(SkinBuyDetailViewData data)
	{
		if (data == null)
		{
			base.GetItem(25).SetUIActive(false);
			return;
		}
		if (data.GetCurrentSkinData().GetSuitWeaponSkinId() > 0)
		{
			FColor color = FColor.FromHex(data.GetCurrentSkinData().GetRoleSkinConfig().SuitWeaponSkinColor);
			base.GetTexture(30).SetColor(color);
			base.GetItem(25).SetUIActive(true);
			return;
		}
		base.GetItem(25).SetUIActive(false);
	}

	// Token: 0x06015A52 RID: 88658 RVA: 0x00601EC0 File Offset: 0x006000C0
	private void RefreshDiscountText(SkinBuyDetailViewData data)
	{
		if (data == null)
		{
			base.GetItem(18).SetUIActive(false);
			return;
		}
		string discountText = data.GetDiscountText();
		base.GetItem(18).SetUIActive(discountText != "");
		base.GetText(19).SetText(discountText, true);
	}

	// Token: 0x06015A53 RID: 88659 RVA: 0x00601F10 File Offset: 0x00600110
	private void RefreshDiscountTime(SkinBuyDetailViewData data)
	{
		if (data == null)
		{
			base.GetItem(20).SetUIActive(false);
			return;
		}
		object discountTimeData = data.GetDiscountTimeData();
		if (discountTimeData == null)
		{
			base.GetItem(20).SetUIActive(false);
			return;
		}
		base.GetItem(20).SetUIActive(true);
		UUIText text = base.GetText(21);
		CommonDefine.PayShowCountDownRemainTime<string> payShowCountDownRemainTime = discountTimeData as CommonDefine.PayShowCountDownRemainTime<string>;
		if (payShowCountDownRemainTime != null)
		{
			text.SetText(payShowCountDownRemainTime.Value, true);
			return;
		}
		CommonDefine.PayShowCountDownRemainTime<CommonDefine.IRemainTime> payShowCountDownRemainTime2 = discountTimeData as CommonDefine.PayShowCountDownRemainTime<CommonDefine.IRemainTime>;
		if (payShowCountDownRemainTime2 != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, payShowCountDownRemainTime2.Value.TextId, new <>z__ReadOnlySingleElementList<object>(payShowCountDownRemainTime2.Value.TimeValue));
		}
	}

	// Token: 0x06015A54 RID: 88660 RVA: 0x00601FAC File Offset: 0x006001AC
	private void RefreshBuyItemIcon(SkinBuyDetailViewData data)
	{
		if (data == null || data.GetCurrentGoodsData() == null)
		{
			base.GetTexture(14).SetUIActive(false);
			return;
		}
		bool ifDirect = data.GetIfDirect();
		base.GetTexture(14).SetUIActive(!ifDirect);
		if (!ifDirect)
		{
			IPriceData priceData = data.GetPriceData();
			if (priceData != null)
			{
				base.SetItemIcon(base.GetTexture(14), priceData.CurrencyId, null, null);
			}
		}
	}

	// Token: 0x06015A55 RID: 88661 RVA: 0x00602018 File Offset: 0x00600218
	private void RefreshSourcePriceText(SkinBuyDetailViewData data)
	{
		if (data == null || data.GetCurrentGoodsData() == null || !data.GetCurrentGoodsData().GetIfCanBuy())
		{
			base.GetText(16).SetText("", true);
			return;
		}
		if (data.GetIfDirect())
		{
			base.GetText(16).SetText("", true);
			return;
		}
		IPriceData priceData = data.GetPriceData();
		if (priceData == null)
		{
			return;
		}
		int? originalPrice = priceData.OriginalPrice;
		if (originalPrice == null)
		{
			base.GetText(16).SetUIActive(false);
			return;
		}
		base.GetText(16).SetUIActive(true);
		base.GetText(16).SetText("<s>" + originalPrice.Value.ToString() + "</s>", true);
	}

	// Token: 0x06015A56 RID: 88662 RVA: 0x006020D4 File Offset: 0x006002D4
	private void RefreshNowPriceText(SkinBuyDetailViewData data)
	{
		if (data == null || data.GetCurrentGoodsData() == null)
		{
			base.GetText(15).SetText("", true);
			return;
		}
		if (data.GetIfDirect())
		{
			string directPriceText = data.GetDirectPriceText();
			base.GetText(15).SetText(directPriceText, true);
			return;
		}
		IPriceData priceData = data.GetPriceData();
		if (priceData != null)
		{
			int nowPrice = priceData.NowPrice;
			base.GetText(15).SetText(nowPrice.ToString(), true);
		}
	}

	// Token: 0x06015A57 RID: 88663 RVA: 0x00602148 File Offset: 0x00600348
	private void RefreshPriceTextShowState(SkinBuyDetailViewData data)
	{
		if (data == null || data.GetCurrentGoodsData() == null)
		{
			base.GetText(15).SetUIActive(false);
			return;
		}
		bool ifCanBuy = data.GetCurrentGoodsData().GetIfCanBuy();
		CommonItemData availableCouponItem = data.GetCurrentGoodsData().GetCurrentGoodsData().GetAvailableCouponItem();
		base.GetItem(38).SetUIActive(ifCanBuy && availableCouponItem == null);
		base.GetItem(39).SetUIActive(ifCanBuy && availableCouponItem != null);
	}

	// Token: 0x06015A58 RID: 88664 RVA: 0x006021BC File Offset: 0x006003BC
	private void RefreshBuyButtonState(SkinBuyDetailViewData data)
	{
		if (data == null || data.GetCurrentGoodsData() == null)
		{
			base.GetButton(17).RootUIComp.Get().SetUIActive(false);
			return;
		}
		bool ifCanBuy = data.GetCurrentGoodsData().GetIfCanBuy();
		base.GetButton(17).RootUIComp.Get().SetUIActive(ifCanBuy);
	}

	// Token: 0x06015A59 RID: 88665 RVA: 0x00602218 File Offset: 0x00600418
	private void RefreshHaveItem(SkinBuyDetailViewData data)
	{
		if (data == null || data.GetCurrentGoodsData() == null)
		{
			base.GetItem(27).SetUIActive(false);
			return;
		}
		bool ifCanBuy = data.GetCurrentGoodsData().GetIfCanBuy();
		base.GetItem(27).SetUIActive(!ifCanBuy);
	}

	// Token: 0x06015A5A RID: 88666 RVA: 0x0060225C File Offset: 0x0060045C
	private void RefreshNotHaveRoleItem(SkinBuyDetailViewData data)
	{
		if (data == null || data.GetCurrentGoodsData() == null)
		{
			base.GetItem(13).SetUIActive(false);
			return;
		}
		bool ifHaveSkinNeedRole = data.GetIfHaveSkinNeedRole();
		base.GetItem(13).SetUIActive(!ifHaveSkinNeedRole);
	}

	// Token: 0x06015A5B RID: 88667 RVA: 0x0060229C File Offset: 0x0060049C
	private void RefreshExtraReward(SkinBuyDetailViewData data)
	{
		if (data == null)
		{
			return;
		}
		if (data.GetIsActivityReward())
		{
			TItem[] connectOtherReward = data.GetConnectOtherReward();
			List<SkinRewardData> list = new List<SkinRewardData>();
			foreach (TItem value in connectOtherReward)
			{
				list.Add(new SkinRewardData
				{
					ItemData = new TItem?(value),
					FinishState = (data.GetCurrentSkinData().GetItemCount() >= 1)
				});
			}
			GenericLayout<SkinRewardItemGrid, SkinRewardData> itemLayout = this.ItemLayout;
			if (itemLayout != null)
			{
				itemLayout.SetActive(list.Count != 0);
			}
			GenericLayout<SkinRewardItemGrid, SkinRewardData> itemLayout2 = this.ItemLayout;
			if (itemLayout2 == null)
			{
				return;
			}
			itemLayout2.RefreshByData(list, null, false);
			return;
		}
		else if (data.GetCurrentGoodsData() == null)
		{
			GenericLayout<SkinRewardItemGrid, SkinRewardData> itemLayout3 = this.ItemLayout;
			if (itemLayout3 == null)
			{
				return;
			}
			itemLayout3.SetActive(false);
			return;
		}
		else
		{
			TItem[] otherReward = data.GetCurrentGoodsData().GetOtherReward();
			List<SkinRewardData> list2 = new List<SkinRewardData>();
			foreach (TItem value2 in otherReward)
			{
				list2.Add(new SkinRewardData
				{
					ItemData = new TItem?(value2),
					FinishState = !data.GetCurrentGoodsData().GetIfCanBuy()
				});
			}
			GenericLayout<SkinRewardItemGrid, SkinRewardData> itemLayout4 = this.ItemLayout;
			if (itemLayout4 != null)
			{
				itemLayout4.SetActive(list2.Count != 0);
			}
			GenericLayout<SkinRewardItemGrid, SkinRewardData> itemLayout5 = this.ItemLayout;
			if (itemLayout5 == null)
			{
				return;
			}
			itemLayout5.RefreshByData(list2, null, false);
			return;
		}
	}

	// Token: 0x06015A5C RID: 88668 RVA: 0x006023E4 File Offset: 0x006005E4
	private void RefreshExtraRewardItem(SkinBuyDetailViewData data)
	{
		if (data == null)
		{
			return;
		}
		if (data.GetIsActivityReward())
		{
			base.GetItem(9).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(50), "RoverSkinEvent_ExtraReward", Array.Empty<object>());
			return;
		}
		if (data.GetCurrentGoodsData() == null)
		{
			base.GetItem(9).SetUIActive(false);
			return;
		}
		base.GetItem(9).SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(50), "PrefabTextitem_RoleSkinExtraAcquisition_Text", Array.Empty<object>());
	}

	// Token: 0x06015A5D RID: 88669 RVA: 0x0060246C File Offset: 0x0060066C
	private void RefreshEffectItem(SkinBuyDetailViewData data)
	{
		if (data == null || data.GetCurrentGoodsData() == null)
		{
			base.GetItem(33).SetUIActive(false);
			base.GetItem(32).SetUIActive(false);
			return;
		}
		bool uiactive = data.GetCurrentSkinData().GetSuitWeaponSkinId() > 0;
		base.GetItem(33).SetUIActive(uiactive);
		base.GetItem(32).SetUIActive(uiactive);
	}

	// Token: 0x06015A5E RID: 88670 RVA: 0x006024CC File Offset: 0x006006CC
	private void RefreshCouponPrice(SkinBuyDetailViewData data)
	{
		if (data == null || data.GetCurrentGoodsData() == null)
		{
			return;
		}
		if (data.GetIfDirect())
		{
			return;
		}
		CommonItemData availableCouponItem = data.GetCurrentGoodsData().GetCurrentGoodsData().GetAvailableCouponItem();
		if (availableCouponItem == null)
		{
			return;
		}
		IPriceData priceData = data.GetPriceData();
		if (priceData == null)
		{
			return;
		}
		int valueOrDefault = priceData.OriginalPrice.GetValueOrDefault();
		int availableCouponDiscount = data.GetCurrentGoodsData().GetCurrentGoodsData().GetAvailableCouponDiscount();
		int nowPrice = priceData.NowPrice;
		UUIText text = base.GetText(40);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("-");
		defaultInterpolatedStringHandler.AppendFormatted<int>(availableCouponDiscount);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		UUIText text2 = base.GetText(42);
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
		defaultInterpolatedStringHandler.AppendLiteral("<s>");
		defaultInterpolatedStringHandler.AppendFormatted<int>(valueOrDefault);
		defaultInterpolatedStringHandler.AppendLiteral("</s>");
		text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		base.GetText(44).SetText(nowPrice.ToString(), true);
		base.SetItemIcon(base.GetTexture(41), availableCouponItem.GetConfigId(), null, null);
		base.SetItemIcon(base.GetTexture(43), priceData.CurrencyId, null, null);
	}

	// Token: 0x06015A5F RID: 88671 RVA: 0x006025FC File Offset: 0x006007FC
	private void RefreshSexPanel(SkinBuyDetailViewData data)
	{
		if (data == null)
		{
			UUIItem item = base.GetItem(47);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else
		{
			bool isActivityReward = data.GetIsActivityReward();
			UUIItem item2 = base.GetItem(47);
			if (item2 != null)
			{
				item2.SetUIActive(isActivityReward);
			}
			this.CaptionItem.SetHelpBtnActive(!isActivityReward);
			UUIExtendToggle extendToggle = base.GetExtendToggle(48);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState((data.GetIndex() == 0) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(49);
			if (extendToggle2 == null)
			{
				return;
			}
			extendToggle2.SetToggleStateForce((data.GetIndex() == 1) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			return;
		}
	}

	// Token: 0x06015A60 RID: 88672 RVA: 0x00602690 File Offset: 0x00600890
	protected override void OnTick(float delta)
	{
		SkinBuyDetailViewData viewData = this.ViewData;
		PayShopGoods payShopGoods;
		if (viewData == null)
		{
			payShopGoods = null;
		}
		else
		{
			ShopSkinData currentGoodsData = viewData.GetCurrentGoodsData();
			payShopGoods = ((currentGoodsData != null) ? currentGoodsData.GetCurrentGoodsData() : null);
		}
		PayShopGoods payShopGoods2 = payShopGoods;
		if (payShopGoods2 == null)
		{
			return;
		}
		int currentPayItemId = this.CurrentPayItemId;
		PayShopGoodsData goodsData = payShopGoods2.GetGoodsData();
		int? num = (goodsData != null) ? new int?(goodsData.Id) : null;
		if (!(currentPayItemId == num.GetValueOrDefault() & num != null))
		{
			this.CurrentPayItemId = payShopGoods2.GetGoodsData().Id;
			this.CurrentDiscountState = payShopGoods2.HasDiscount();
			return;
		}
		bool flag = payShopGoods2.HasDiscount();
		if (this.CurrentDiscountState != flag)
		{
			int currentPayItemId2 = this.CurrentPayItemId;
			PayShopGoodsData goodsData2 = payShopGoods2.GetGoodsData();
			num = ((goodsData2 != null) ? new int?(goodsData2.Id) : null);
			if (currentPayItemId2 == num.GetValueOrDefault() & num != null)
			{
				this.CurrentDiscountState = flag;
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PayShopRefresh);
				confirmBoxDataNew.FunctionMap[2] = new Action(this.RefreshView);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			}
		}
	}

	// Token: 0x06015A61 RID: 88673 RVA: 0x00602799 File Offset: 0x00600999
	private void OnClickedHelpButton()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(169);
	}

	// Token: 0x0400A648 RID: 42568
	private SkinBuyDetailViewData ViewData;

	// Token: 0x0400A649 RID: 42569
	private int CurrentSkinTypeIndex;

	// Token: 0x0400A64A RID: 42570
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400A64B RID: 42571
	private TsUiSceneRoleActor TsUiSceneRoleActor;

	// Token: 0x0400A64C RID: 42572
	private FVector? CurrentDragPosition;

	// Token: 0x0400A64D RID: 42573
	private UiCameraControlRotationComponent UiCameraControlRotationComponent;

	// Token: 0x0400A64E RID: 42574
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SkinRewardItemGrid, SkinRewardData> ItemLayout;

	// Token: 0x0400A64F RID: 42575
	private double LastClickButtonTime;

	// Token: 0x0400A650 RID: 42576
	private double LastSwitchTime;

	// Token: 0x0400A651 RID: 42577
	private bool CurrentDiscountState;

	// Token: 0x0400A652 RID: 42578
	private int CurrentPayItemId;

	// Token: 0x02008DBE RID: 36286
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402FB24 RID: 195364
		CaptionItem,
		// Token: 0x0402FB25 RID: 195365
		OnlyUiToggle,
		// Token: 0x0402FB26 RID: 195366
		DetailIconButton,
		// Token: 0x0402FB27 RID: 195367
		ButtonLeft,
		// Token: 0x0402FB28 RID: 195368
		ButtonRight,
		// Token: 0x0402FB29 RID: 195369
		TitleText,
		// Token: 0x0402FB2A RID: 195370
		SubTitleText,
		// Token: 0x0402FB2B RID: 195371
		SwitchItem,
		// Token: 0x0402FB2C RID: 195372
		ToggleLeft,
		// Token: 0x0402FB2D RID: 195373
		ExtraRewardItem,
		// Token: 0x0402FB2E RID: 195374
		ExtraRewardContentHorizontalLayout,
		// Token: 0x0402FB2F RID: 195375
		RewardItem,
		// Token: 0x0402FB30 RID: 195376
		DescText,
		// Token: 0x0402FB31 RID: 195377
		NotHaveRoleItem,
		// Token: 0x0402FB32 RID: 195378
		BuyItemIcon,
		// Token: 0x0402FB33 RID: 195379
		NowPrice,
		// Token: 0x0402FB34 RID: 195380
		BeforePrice,
		// Token: 0x0402FB35 RID: 195381
		BuyButton,
		// Token: 0x0402FB36 RID: 195382
		DiscountItem,
		// Token: 0x0402FB37 RID: 195383
		DiscountText,
		// Token: 0x0402FB38 RID: 195384
		LeftTimeItem,
		// Token: 0x0402FB39 RID: 195385
		LeftTimeText,
		// Token: 0x0402FB3A RID: 195386
		QualityTexture,
		// Token: 0x0402FB3B RID: 195387
		RoleTexture,
		// Token: 0x0402FB3C RID: 195388
		FrameTexture,
		// Token: 0x0402FB3D RID: 195389
		WeaponRootItem,
		// Token: 0x0402FB3E RID: 195390
		WeaponTexture,
		// Token: 0x0402FB3F RID: 195391
		HaveItem,
		// Token: 0x0402FB40 RID: 195392
		HideUiParentItem,
		// Token: 0x0402FB41 RID: 195393
		DragComponent,
		// Token: 0x0402FB42 RID: 195394
		WeaponQualityTexture,
		// Token: 0x0402FB43 RID: 195395
		ToggleRight,
		// Token: 0x0402FB44 RID: 195396
		EffectItemB,
		// Token: 0x0402FB45 RID: 195397
		EffectItemA,
		// Token: 0x0402FB46 RID: 195398
		TextureToggleLeft,
		// Token: 0x0402FB47 RID: 195399
		TextToggleLeft,
		// Token: 0x0402FB48 RID: 195400
		TextureToggleRight,
		// Token: 0x0402FB49 RID: 195401
		TextToggleRight,
		// Token: 0x0402FB4A RID: 195402
		ItemNonCouponPrice,
		// Token: 0x0402FB4B RID: 195403
		ItemCouponPrice,
		// Token: 0x0402FB4C RID: 195404
		TextCouponPrice,
		// Token: 0x0402FB4D RID: 195405
		TextureCouponIcon,
		// Token: 0x0402FB4E RID: 195406
		TextOriginPrice,
		// Token: 0x0402FB4F RID: 195407
		TexturePriceIcon,
		// Token: 0x0402FB50 RID: 195408
		TextCurPrice,
		// Token: 0x0402FB51 RID: 195409
		ItemGamePadKeyTipA,
		// Token: 0x0402FB52 RID: 195410
		ItemGamePadKeyTipB,
		// Token: 0x0402FB53 RID: 195411
		ToggleLayout,
		// Token: 0x0402FB54 RID: 195412
		ToggleMale,
		// Token: 0x0402FB55 RID: 195413
		ToggleFemale,
		// Token: 0x0402FB56 RID: 195414
		ExtraRewardText
	}
}
