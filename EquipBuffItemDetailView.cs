using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002A2F RID: 10799
[NullableContext(2)]
[Nullable(0)]
public class EquipBuffItemDetailView : UiViewBase
{
	// Token: 0x06015953 RID: 88403 RVA: 0x005FA688 File Offset: 0x005F8888
	[NullableContext(1)]
	public EquipBuffItemDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015954 RID: 88404 RVA: 0x005FA70C File Offset: 0x005F890C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
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
			new ValueTuple<int, Type>(43, typeof(UUITexture)),
			new ValueTuple<int, Type>(42, typeof(UUIText)),
			new ValueTuple<int, Type>(41, typeof(UUITexture)),
			new ValueTuple<int, Type>(44, typeof(UUIText)),
			new ValueTuple<int, Type>(45, typeof(UUIItem)),
			new ValueTuple<int, Type>(46, typeof(UUIItem)),
			new ValueTuple<int, Type>(47, typeof(UUIItem)),
			new ValueTuple<int, Type>(48, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(49, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(50, typeof(UUIText)),
			new ValueTuple<int, Type>(51, typeof(UUIItem)),
			new ValueTuple<int, Type>(52, typeof(UUIItem)),
			new ValueTuple<int, Type>(53, typeof(UUIItem))
		};
	}

	// Token: 0x06015955 RID: 88405 RVA: 0x005FABF8 File Offset: 0x005F8DF8
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
	}

	// Token: 0x06015956 RID: 88406 RVA: 0x005FAD30 File Offset: 0x005F8F30
	private void RemoveCameraEventListener()
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
	}

	// Token: 0x06015957 RID: 88407 RVA: 0x005FAE3D File Offset: 0x005F903D
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

	// Token: 0x06015958 RID: 88408 RVA: 0x005FAE6C File Offset: 0x005F906C
	[NullableContext(1)]
	private void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification _)
	{
		if (touchData.TouchType == InputDistributeDefine.ETouchType.TouchMove)
		{
			this.TouchMoved();
		}
	}

	// Token: 0x06015959 RID: 88409 RVA: 0x005FAE80 File Offset: 0x005F9080
	private void TouchMoved()
	{
		if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1)
		{
			float fingerExpandCloseValue = Singleton<TouchFingerManager>.Instance.GetFingerExpandCloseValue(EFingerIndex.One, EFingerIndex.Two);
			this.UiCameraControlRotationComponent.AddZoomInput(-fingerExpandCloseValue);
		}
	}

	// Token: 0x0601595A RID: 88410 RVA: 0x005FAEB4 File Offset: 0x005F90B4
	private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
	{
		this.CurrentDragPosition = new FVector?(eventData.GetLocalPointInPlane());
	}

	// Token: 0x0601595B RID: 88411 RVA: 0x005FAEC8 File Offset: 0x005F90C8
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

	// Token: 0x0601595C RID: 88412 RVA: 0x005FAF86 File Offset: 0x005F9186
	private void OnPointerEndDragCallBack(ULGUIPointerEventData eventData)
	{
		this.CurrentDragPosition = null;
	}

	// Token: 0x0601595D RID: 88413 RVA: 0x005FAF94 File Offset: 0x005F9194
	private void OnPointerScrollCallBack(ULGUIPointerEventData eventData)
	{
		if (eventData.scrollAxisValue != 0f)
		{
			this.UiCameraControlRotationComponent.AddZoomInput(-eventData.scrollAxisValue);
		}
	}

	// Token: 0x0601595E RID: 88414 RVA: 0x005FAFB8 File Offset: 0x005F91B8
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
		foreach (int name in this.disableNodeList)
		{
			UUIItem item3 = base.GetItem(name);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
		}
	}

	// Token: 0x0601595F RID: 88415 RVA: 0x005FB100 File Offset: 0x005F9300
	protected override void OnAfterShow()
	{
		this.RefreshCameraRotationComponentByViewType();
	}

	// Token: 0x06015960 RID: 88416 RVA: 0x005FB108 File Offset: 0x005F9308
	protected override void OnAfterHide()
	{
		TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
		UiModelBase uiModelBase = (tsUiSceneRoleActor != null) ? tsUiSceneRoleActor.Model : null;
		if (uiModelBase != null)
		{
			Singleton<UiModelUtil>.Instance.SetVisible(uiModelBase, false);
		}
	}

	// Token: 0x06015961 RID: 88417 RVA: 0x005FB138 File Offset: 0x005F9338
	private void RefreshCameraRotationComponentByViewType()
	{
		if (Singleton<UiCameraAnimationManager>.Instance.IsPlayingAnimation())
		{
			return;
		}
		string configId = (this.CurrentSkinTypeIndex == 0) ? ConfigBase<PayShopConfig>.Instance.GetBuySkinDetailRoleCameraConfigId() : ConfigBase<PayShopConfig>.Instance.GetBuySkinDetailWeaponCameraConfigId();
		this.RefreshCameraRotationComponent(configId);
	}

	// Token: 0x06015962 RID: 88418 RVA: 0x005FB178 File Offset: 0x005F9378
	[NullableContext(1)]
	private void RefreshCameraRotationComponent(string configId)
	{
		UiCamera uiCamera = UiCameraManager.Get();
		this.UiCameraControlRotationComponent = (uiCamera.AddUiCameraComponent(typeof(UiCameraControlRotationComponent), false) as UiCameraControlRotationComponent);
		SUiRoleCameraSetting? roleCameraConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig(configId);
		this.UiCameraControlRotationComponent.InitDataByConfig(roleCameraConfig.Value);
		this.UiCameraControlRotationComponent.SetNeedFloorReflection(true);
		FVectorDouble sourceLocation = this.TsUiSceneRoleActor.D_K2_GetActorLocation();
		int roleId = this.ViewData.RoleSkinData.GetRoleId();
		string roleBody = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value.RoleBody;
		SUiRoleCameraOffsetSetting? roleCameraOffsetConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraOffsetConfig(roleBody);
		this.UiCameraControlRotationComponent.UpdateData(sourceLocation, roleCameraOffsetConfig.Value.镜头浮动最大高度, roleCameraOffsetConfig.Value.镜头浮动最低高度, roleCameraOffsetConfig.Value.镜头浮动最长臂长, roleCameraOffsetConfig.Value.镜头浮动最短臂长);
		this.UiCameraControlRotationComponent.Activate();
		this.UiCameraControlRotationComponent.ResumeTick();
	}

	// Token: 0x06015963 RID: 88419 RVA: 0x005FB26D File Offset: 0x005F946D
	private void OnInputUiLookUp(float value)
	{
		if (value == 0f || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.UiCameraControlRotationComponent.AddPitchInput(-value);
	}

	// Token: 0x06015964 RID: 88420 RVA: 0x005FB291 File Offset: 0x005F9491
	private void OnInputUiTurn(float value)
	{
		if (value == 0f || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.UiCameraControlRotationComponent.AddYawInput(value);
	}

	// Token: 0x06015965 RID: 88421 RVA: 0x005FB2B4 File Offset: 0x005F94B4
	[NullableContext(1)]
	private void OnInputUiZoom(string axisName, float value)
	{
		if (value == 0f || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.UiCameraControlRotationComponent.AddZoomInput(value);
	}

	// Token: 0x06015966 RID: 88422 RVA: 0x005FB2D8 File Offset: 0x005F94D8
	private void OnRightStickPress()
	{
		UiCameraHandleData lastHandleData = Singleton<UiCameraAnimationManager>.Instance.GetLastHandleData();
		if (lastHandleData != null)
		{
			Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(lastHandleData.HandleName, true, true, "1001", false, null, null);
		}
	}

	// Token: 0x06015967 RID: 88423 RVA: 0x005FB318 File Offset: 0x005F9518
	protected override void OnStart()
	{
		this.TsUiSceneRoleActor = Singleton<UiSceneManager>.Instance.InitRoleSystemRoleActor(EUiModelUseWay.RoleInEquipBuffItemPreview);
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.CloseView));
		this.ViewData = (this.OpenParam as EquipBuffItemDetailViewData);
		this.CaptionItem.SetTitleLocalText("TotalTopUp_1003");
		this.CaptionItem.SetTitleIconByResourceId("EquipBuffItemDetailTitle_Icon");
		this.CaptionItem.SetHelpBtnActive(false);
		base.GetExtendToggle(8).CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
		base.GetExtendToggle(31).CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
		this.ResetCurrentSkinTypeIndex();
	}

	// Token: 0x06015968 RID: 88424 RVA: 0x005FB3DF File Offset: 0x005F95DF
	private bool CanToggleExecuteChange()
	{
		return Singleton<TimeUtil>.Instance.GetServerTimeStamp() - (double)this.LastSwitchTime >= (double)ConfigBase<SkinConfig>.Instance.GetSkinDetailButtonSwitchGap();
	}

	// Token: 0x06015969 RID: 88425 RVA: 0x005FB403 File Offset: 0x005F9603
	protected override void OnBeforeHide()
	{
		this.RemoveCameraEventListener();
		this.UiCameraControlRotationComponent.PauseTick();
	}

	// Token: 0x0601596A RID: 88426 RVA: 0x005FB416 File Offset: 0x005F9616
	protected override void OnBeforeDestroy()
	{
		UiCameraManager.Get().DestroyUiCameraComponent(typeof(UiCameraControlRotationComponent));
		Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.TsUiSceneRoleActor);
		this.TsUiSceneRoleActor = null;
	}

	// Token: 0x0601596B RID: 88427 RVA: 0x005FB444 File Offset: 0x005F9644
	private void RefreshRolePerformance()
	{
		int roleId = this.ViewData.RoleSkinData.GetRoleId();
		if (roleId > 0)
		{
			ControllerBase<RoleController>.Instance.RefreshUiSceneRoleActorByConfigId(roleId, this.ViewData.RoleSkinData.GetItemId(), delegate
			{
			});
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSelectedRoleChanged);
	}

	// Token: 0x0601596C RID: 88428 RVA: 0x005FB4B0 File Offset: 0x005F96B0
	private void CloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x0601596D RID: 88429 RVA: 0x005FB4B9 File Offset: 0x005F96B9
	protected override void OnHandleReleaseScene()
	{
		this.HandleReleaseScene();
	}

	// Token: 0x0601596E RID: 88430 RVA: 0x005FB4C1 File Offset: 0x005F96C1
	private void HandleReleaseScene()
	{
	}

	// Token: 0x0601596F RID: 88431 RVA: 0x005FB4C3 File Offset: 0x005F96C3
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

	// Token: 0x06015970 RID: 88432 RVA: 0x005FB4D5 File Offset: 0x005F96D5
	[NullableContext(1)]
	private void OnActivateUiCameraAnimationHandle(UiCameraHandleData handleData)
	{
		this.RefreshCameraRotationComponentByViewType();
	}

	// Token: 0x06015971 RID: 88433 RVA: 0x005FB4DD File Offset: 0x005F96DD
	private void ResetCurrentSkinTypeIndex()
	{
		this.CurrentSkinTypeIndex = 0;
	}

	// Token: 0x06015972 RID: 88434 RVA: 0x005FB4E6 File Offset: 0x005F96E6
	private void RefreshView()
	{
		this.RefreshTitleText(this.ViewData);
		this.RefreshDescText(this.ViewData);
		this.RefreshRolePerformance();
	}

	// Token: 0x06015973 RID: 88435 RVA: 0x005FB508 File Offset: 0x005F9708
	private void RefreshDescText(EquipBuffItemDetailViewData data)
	{
		if (data == null)
		{
			base.GetText(12).SetText("", true);
			return;
		}
		string description = data.Description;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), description, Array.Empty<object>());
	}

	// Token: 0x06015974 RID: 88436 RVA: 0x005FB54C File Offset: 0x005F974C
	private void RefreshTitleText(EquipBuffItemDetailViewData data)
	{
		if (data == null)
		{
			base.GetText(5).SetText("", true);
			return;
		}
		string titleName = data.TitleName;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), titleName, Array.Empty<object>());
	}

	// Token: 0x0400A604 RID: 42500
	private EquipBuffItemDetailViewData ViewData;

	// Token: 0x0400A605 RID: 42501
	private int CurrentSkinTypeIndex;

	// Token: 0x0400A606 RID: 42502
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400A607 RID: 42503
	private TsUiSceneRoleActor TsUiSceneRoleActor;

	// Token: 0x0400A608 RID: 42504
	private FVector? CurrentDragPosition;

	// Token: 0x0400A609 RID: 42505
	private UiCameraControlRotationComponent UiCameraControlRotationComponent;

	// Token: 0x0400A60A RID: 42506
	private float LastSwitchTime;

	// Token: 0x0400A60B RID: 42507
	[Nullable(1)]
	private readonly List<int> disableNodeList = new List<int>
	{
		6,
		7,
		9,
		50,
		13,
		47,
		51,
		52,
		53,
		8,
		31,
		3,
		4
	};

	// Token: 0x02008DA6 RID: 36262
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402FA11 RID: 195089
		CaptionItem,
		// Token: 0x0402FA12 RID: 195090
		OnlyUiToggle,
		// Token: 0x0402FA13 RID: 195091
		DetailIconButton,
		// Token: 0x0402FA14 RID: 195092
		ButtonLeft,
		// Token: 0x0402FA15 RID: 195093
		ButtonRight,
		// Token: 0x0402FA16 RID: 195094
		TitleText,
		// Token: 0x0402FA17 RID: 195095
		SubTitleText,
		// Token: 0x0402FA18 RID: 195096
		SwitchItem,
		// Token: 0x0402FA19 RID: 195097
		ToggleLeft,
		// Token: 0x0402FA1A RID: 195098
		ExtraRewardItem,
		// Token: 0x0402FA1B RID: 195099
		ExtraRewardContentHorizontalLayout,
		// Token: 0x0402FA1C RID: 195100
		RewardItem,
		// Token: 0x0402FA1D RID: 195101
		DescText,
		// Token: 0x0402FA1E RID: 195102
		NotHaveRoleItem,
		// Token: 0x0402FA1F RID: 195103
		BuyItemIcon,
		// Token: 0x0402FA20 RID: 195104
		NowPrice,
		// Token: 0x0402FA21 RID: 195105
		BeforePrice,
		// Token: 0x0402FA22 RID: 195106
		BuyButton,
		// Token: 0x0402FA23 RID: 195107
		DiscountItem,
		// Token: 0x0402FA24 RID: 195108
		DiscountText,
		// Token: 0x0402FA25 RID: 195109
		LeftTimeItem,
		// Token: 0x0402FA26 RID: 195110
		LeftTimeText,
		// Token: 0x0402FA27 RID: 195111
		QualityTexture,
		// Token: 0x0402FA28 RID: 195112
		RoleTexture,
		// Token: 0x0402FA29 RID: 195113
		FrameTexture,
		// Token: 0x0402FA2A RID: 195114
		WeaponRootItem,
		// Token: 0x0402FA2B RID: 195115
		WeaponTexture,
		// Token: 0x0402FA2C RID: 195116
		HaveItem,
		// Token: 0x0402FA2D RID: 195117
		HideUiParentItem,
		// Token: 0x0402FA2E RID: 195118
		DragComponent,
		// Token: 0x0402FA2F RID: 195119
		WeaponQualityTexture,
		// Token: 0x0402FA30 RID: 195120
		ToggleRight,
		// Token: 0x0402FA31 RID: 195121
		EffectItemB,
		// Token: 0x0402FA32 RID: 195122
		EffectItemA,
		// Token: 0x0402FA33 RID: 195123
		TextureToggleLeft,
		// Token: 0x0402FA34 RID: 195124
		TextToggleLeft,
		// Token: 0x0402FA35 RID: 195125
		TextureToggleRight,
		// Token: 0x0402FA36 RID: 195126
		TextToggleRight,
		// Token: 0x0402FA37 RID: 195127
		ItemNonCouponPrice,
		// Token: 0x0402FA38 RID: 195128
		ItemCouponPrice,
		// Token: 0x0402FA39 RID: 195129
		TextCouponPrice,
		// Token: 0x0402FA3A RID: 195130
		TextureCouponIcon,
		// Token: 0x0402FA3B RID: 195131
		TextOriginPrice,
		// Token: 0x0402FA3C RID: 195132
		TexturePriceIcon,
		// Token: 0x0402FA3D RID: 195133
		TextCurPrice,
		// Token: 0x0402FA3E RID: 195134
		ItemGamePadKeyTipA,
		// Token: 0x0402FA3F RID: 195135
		ItemGamePadKeyTipB,
		// Token: 0x0402FA40 RID: 195136
		ToggleLayout,
		// Token: 0x0402FA41 RID: 195137
		ToggleMale,
		// Token: 0x0402FA42 RID: 195138
		ToggleFemale,
		// Token: 0x0402FA43 RID: 195139
		ExtraRewardText,
		// Token: 0x0402FA44 RID: 195140
		ItemPanelBuy,
		// Token: 0x0402FA45 RID: 195141
		ItemPanelRole,
		// Token: 0x0402FA46 RID: 195142
		ItemPanelLeftDownBtn
	}
}
