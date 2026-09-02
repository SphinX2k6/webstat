using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020022FF RID: 8959
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiyEditRootView : UiViewBase
{
	// Token: 0x06010FAE RID: 69550 RVA: 0x004A7E9E File Offset: 0x004A609E
	public MotorcycleDiyEditRootView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010FAF RID: 69551 RVA: 0x004A7ECC File Offset: 0x004A60CC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIDraggableComponent));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnTogChangeCameraPosClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnTogEyeClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnBtnMotorDiySaveClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06010FB0 RID: 69552 RVA: 0x004A8060 File Offset: 0x004A6260
	protected override void OnStart()
	{
		IOpenMotorcycleDiyRootViewData openMotorcycleDiyRootViewData = this.OpenParam as IOpenMotorcycleDiyRootViewData;
		if (openMotorcycleDiyRootViewData != null)
		{
			this.CurSelectTabView = openMotorcycleDiyRootViewData.OpenTabView;
			this.LocalPresetData = openMotorcycleDiyRootViewData.PresetData;
			this.CustomMode = openMotorcycleDiyRootViewData.CustomMode;
		}
		this.InitTabComponent();
		base.GetButton(7).RootUIComp.Get().SetUIActive(true);
		this.AddHomeBtnExtraCallback();
	}

	// Token: 0x06010FB1 RID: 69553 RVA: 0x004A80C8 File Offset: 0x004A62C8
	protected override void OnBeforeShow()
	{
		this.RefreshTabListAsync();
		this.InitCameraInputData();
		Singleton<MotorcycleUiModelUtil>.Instance.ShowMotor(true);
		if (this.TabViewComponent != null)
		{
			IMotorcycleDiyTabViewRegister motorcycleDiyTabViewRegister = this.TabViewComponent.GetCurrentTabView() as IMotorcycleDiyTabViewRegister;
			if (motorcycleDiyTabViewRegister != null)
			{
				motorcycleDiyTabViewRegister.RefreshItemScrollView();
				Action<int> onTabCameraClick = motorcycleDiyTabViewRegister.OnTabCameraClick;
				if (onTabCameraClick != null)
				{
					onTabCameraClick(this.CurSelectPart);
				}
			}
		}
		if (Singleton<MotorcycleUiModelUtil>.Instance.IsMotorCreated())
		{
			int selectedFrameId = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedFrameId();
			List<int> selectedStickerIdList = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedStickerIdList(false);
			List<int> selectedDecorationIdList = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedDecorationIdList(false);
			MotorcycleUiModelParam param = new MotorcycleUiModelParam
			{
				FrameId = selectedFrameId,
				StickerIds = selectedStickerIdList.ToArray(),
				DecorationIds = selectedDecorationIdList.ToArray()
			};
			Singleton<MotorcycleUiModelUtil>.Instance.LoadMotorByParam(param, null);
		}
	}

	// Token: 0x06010FB2 RID: 69554 RVA: 0x004A8188 File Offset: 0x004A6388
	protected override void OnBeforeHide()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.ShowMotor(false);
	}

	// Token: 0x06010FB3 RID: 69555 RVA: 0x004A8195 File Offset: 0x004A6395
	protected override void OnHandleReleaseScene()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.DestroyMotor();
	}

	// Token: 0x06010FB4 RID: 69556 RVA: 0x004A81A1 File Offset: 0x004A63A1
	protected override void OnBeforeDestroy()
	{
		TabComponentWithCaptionItem<MotorcycleEditTabItem> tabComponent = this.TabComponent;
		if (tabComponent != null)
		{
			tabComponent.Destroy(null);
		}
		this.TabComponent = null;
		TabViewComponent<UiDynamicTab> tabViewComponent = this.TabViewComponent;
		if (tabViewComponent != null)
		{
			tabViewComponent.DestroyTabViewComponent();
		}
		this.TabViewComponent = null;
	}

	// Token: 0x06010FB5 RID: 69557 RVA: 0x004A81D4 File Offset: 0x004A63D4
	private void InitTabComponent()
	{
		CommonTabComponentData<MotorcycleEditTabItem> data = new CommonTabComponentData<MotorcycleEditTabItem>(new Func<UUIItem, int?, MotorcycleEditTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
		this.TabComponent = new TabComponentWithCaptionItem<MotorcycleEditTabItem>(base.GetItem(1), data, new Action(this.CloseClick), false);
		this.LastClickTime = null;
		this.TabComponent.SetCanChange(new Func<int, bool?, bool>(this.CanToggleChange));
		this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(2), EKeyMode.Default);
	}

	// Token: 0x06010FB6 RID: 69558 RVA: 0x004A8264 File Offset: 0x004A6464
	private void InitCameraInputData()
	{
		if (this.IsInitCameraInput)
		{
			return;
		}
		SUiRoleCameraSetting? roleCameraConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig("摩托车贴纸界面");
		if (roleCameraConfig == null)
		{
			return;
		}
		AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("RoleCase").Value, ECollectActorType.UI);
		if (actorWithTag == null)
		{
			return;
		}
		UiCameraInputComponentData uiCameraInputComponentData = new UiCameraInputComponentData();
		uiCameraInputComponentData.DragComponent = base.GetDraggable(6);
		uiCameraInputComponentData.CameraSettingConfig = roleCameraConfig.Value;
		FVectorDouble fvectorDouble = actorWithTag.D_K2_GetActorLocation();
		uiCameraInputComponentData.SourceLocation = fvectorDouble;
		UiCameraInputComponentData data = uiCameraInputComponentData;
		this.CameraInputComponent.InitData(data);
		this.IsInitCameraInput = true;
	}

	// Token: 0x06010FB7 RID: 69559 RVA: 0x004A82F9 File Offset: 0x004A64F9
	private MotorcycleEditTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new MotorcycleEditTabItem
		{
			OnRegisterViewCallback = delegate(UiTabViewBase view)
			{
				IMotorcycleDiyEditTabViewRegister motorcycleDiyEditTabViewRegister = view as IMotorcycleDiyEditTabViewRegister;
				if (motorcycleDiyEditTabViewRegister != null)
				{
					motorcycleDiyEditTabViewRegister.OnTabCameraClick = new Action<int>(this.OnTabCameraClick);
					motorcycleDiyEditTabViewRegister.OnSelectItemClick = new Action<EOutlookType, int, int>(this.OnSelectItemClick);
					motorcycleDiyEditTabViewRegister.GetLocalPresetData = new Func<MotorcycleDiyPresetData>(this.GetLocalPresetData);
					motorcycleDiyEditTabViewRegister.OnEditPresetChanged = new Action<EOutlookType, bool>(this.OnEditPresetChanged);
				}
			}
		};
	}

	// Token: 0x06010FB8 RID: 69560 RVA: 0x004A8314 File Offset: 0x004A6514
	private UniTask RefreshTabListAsync()
	{
		MotorcycleDiyEditRootView.<RefreshTabListAsync>d__26 <RefreshTabListAsync>d__;
		<RefreshTabListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabListAsync>d__.<>4__this = this;
		<RefreshTabListAsync>d__.<>1__state = -1;
		<RefreshTabListAsync>d__.<>t__builder.Start<MotorcycleDiyEditRootView.<RefreshTabListAsync>d__26>(ref <RefreshTabListAsync>d__);
		return <RefreshTabListAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010FB9 RID: 69561 RVA: 0x004A8358 File Offset: 0x004A6558
	public void SwitchToTabPart(EUiTabViewName tabViewName, int? partTabIndex = null)
	{
		int num = this.TabDataList.FindIndex((UiDynamicTab data) => (EUiTabViewName)data.ChildViewName == tabViewName);
		if (num == -1)
		{
			return;
		}
		this.CurSelectPart = partTabIndex.GetValueOrDefault();
		this.TabComponent.SelectToggleByIndex(num, false);
	}

	// Token: 0x06010FBA RID: 69562 RVA: 0x004A83AC File Offset: 0x004A65AC
	private bool CanToggleChange(int index, bool? _)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			return true;
		}
		int value = ConfigCommonParamById.GetIntConfig("panel_interval_time").Value;
		return this.LastClickTime == null || Singleton<Time>.Instance.Now - this.LastClickTime.Value >= (double)value;
	}

	// Token: 0x06010FBB RID: 69563 RVA: 0x004A8408 File Offset: 0x004A6608
	private void ToggleCallBack(int index)
	{
		this.LastClickTime = new double?(Singleton<Time>.Instance.Now);
		UiDynamicTab data = this.TabDataList[index];
		EUiTabViewName euiTabViewName = (EUiTabViewName)data.ChildViewName;
		MotorcycleEditTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
		if (this.OriginPartTabIndex > 0)
		{
			this.TabViewComponent.ToggleCallBack(data, euiTabViewName, tabItemByIndex, this.OriginPartTabIndex, null);
			this.OriginPartTabIndex = 0;
		}
		else
		{
			this.TabViewComponent.ToggleCallBack(data, euiTabViewName, tabItemByIndex, null, null);
		}
		this.CurSelectTabView = new EUiTabViewName?(euiTabViewName);
	}

	// Token: 0x06010FBC RID: 69564 RVA: 0x004A84AC File Offset: 0x004A66AC
	private CommonTabData GetCommonData(int index)
	{
		UiDynamicTab uiDynamicTab = this.TabDataList[index];
		return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
	}

	// Token: 0x06010FBD RID: 69565 RVA: 0x004A84E4 File Offset: 0x004A66E4
	private void CheckBtnEnable(EOutlookType itemType, int itemPart, int itemId)
	{
		bool flag = itemType == EOutlookType.Sticker;
		base.GetExtendToggle(3).RootUIComp.Get().SetUIActive(flag && itemPart == 3);
		bool flag2 = this.IsPresetModified();
		EMotorcycleDiyCustomMode? customMode = this.CustomMode;
		EMotorcycleDiyCustomMode emotorcycleDiyCustomMode = EMotorcycleDiyCustomMode.NewCreate;
		bool flag3 = customMode.GetValueOrDefault() == emotorcycleDiyCustomMode & customMode != null;
		base.GetButton(7).SetSelfInteractive(flag2 || flag3);
		this.IsModifyPreset = flag2;
	}

	// Token: 0x06010FBE RID: 69566 RVA: 0x004A8558 File Offset: 0x004A6758
	private bool IsPresetModified()
	{
		if (this.LocalPresetData == null)
		{
			return false;
		}
		MotorcycleDiyModel instance = ModelBase<MotorcycleDiyModel>.Instance;
		List<int> selectedStickerIdList = instance.GetSelectedStickerIdList(false);
		List<int> selectedDecorationIdList = instance.GetSelectedDecorationIdList(false);
		int selectedFrameId = instance.GetSelectedFrameId();
		int[] listB = this.LocalPresetData.StickerIds ?? new int[0];
		int[] listB2 = this.LocalPresetData.DecorateIds ?? new int[0];
		int frameId = this.LocalPresetData.FrameId;
		return !this.IsSameIdList(selectedStickerIdList, listB) || !this.IsSameIdList(selectedDecorationIdList, listB2) || selectedFrameId != frameId;
	}

	// Token: 0x06010FBF RID: 69567 RVA: 0x004A85E8 File Offset: 0x004A67E8
	private bool IsSameIdList(List<int> listA, int[] listB)
	{
		if (listA.Count != listB.Length)
		{
			return false;
		}
		for (int i = 0; i < listA.Count; i++)
		{
			if (listA[i] != listB[i])
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06010FC0 RID: 69568 RVA: 0x004A8624 File Offset: 0x004A6824
	private void CreateOrSaveDiyOutlookRequest()
	{
		EMotorcycleDiyCustomMode? customMode = this.CustomMode;
		EMotorcycleDiyCustomMode emotorcycleDiyCustomMode = EMotorcycleDiyCustomMode.NewCreate;
		if (customMode.GetValueOrDefault() == emotorcycleDiyCustomMode & customMode != null)
		{
			this.CreateDiyOutlookRequestAsync(false).ContinueWith(delegate(bool isSuccess)
			{
				if (!isSuccess)
				{
					return;
				}
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DIYProjectTips02", Array.Empty<object>());
				base.CloseMe(null);
			});
			return;
		}
		this.SaveDiyOutlookRequestAsync().ContinueWith(delegate(bool isSuccess)
		{
			if (!isSuccess)
			{
				return;
			}
			base.GetButton(7).SetSelfInteractive(false);
			this.IsModifyPreset = false;
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DIYProjectTips04", Array.Empty<object>());
			base.CloseMe(null);
		});
	}

	// Token: 0x06010FC1 RID: 69569 RVA: 0x004A8680 File Offset: 0x004A6880
	[NullableContext(0)]
	private UniTask<bool> CreateDiyOutlookRequestAsync(bool isHome = false)
	{
		MotorcycleDiyEditRootView.<CreateDiyOutlookRequestAsync>d__35 <CreateDiyOutlookRequestAsync>d__;
		<CreateDiyOutlookRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<CreateDiyOutlookRequestAsync>d__.<>4__this = this;
		<CreateDiyOutlookRequestAsync>d__.isHome = isHome;
		<CreateDiyOutlookRequestAsync>d__.<>1__state = -1;
		<CreateDiyOutlookRequestAsync>d__.<>t__builder.Start<MotorcycleDiyEditRootView.<CreateDiyOutlookRequestAsync>d__35>(ref <CreateDiyOutlookRequestAsync>d__);
		return <CreateDiyOutlookRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010FC2 RID: 69570 RVA: 0x004A86CC File Offset: 0x004A68CC
	[NullableContext(0)]
	private UniTask<bool> SaveDiyOutlookRequestAsync()
	{
		MotorcycleDiyEditRootView.<SaveDiyOutlookRequestAsync>d__36 <SaveDiyOutlookRequestAsync>d__;
		<SaveDiyOutlookRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SaveDiyOutlookRequestAsync>d__.<>4__this = this;
		<SaveDiyOutlookRequestAsync>d__.<>1__state = -1;
		<SaveDiyOutlookRequestAsync>d__.<>t__builder.Start<MotorcycleDiyEditRootView.<SaveDiyOutlookRequestAsync>d__36>(ref <SaveDiyOutlookRequestAsync>d__);
		return <SaveDiyOutlookRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010FC3 RID: 69571 RVA: 0x004A870F File Offset: 0x004A690F
	private void RemoveMaskTimer()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06010FC4 RID: 69572 RVA: 0x004A8734 File Offset: 0x004A6934
	private void StartMaskTimer()
	{
		this.RemoveMaskTimer();
		float? floatConfig = ConfigCommonParamById.GetFloatConfig("MotorDiyChangeBPartDelay");
		if (floatConfig != null)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer("DiyChangeBPartPos", true);
			this.TimerHandle = TimerSystem.RealTimeInstance.Delay(delegate(float _)
			{
				this.RemoveMaskTimer();
				Singleton<UiLayer>.Instance.SetShowMaskLayer("DiyChangeBPartPos", false);
			}, (float)((int)(floatConfig.Value * 1000f)), null, null, true, 1f);
		}
	}

	// Token: 0x06010FC5 RID: 69573 RVA: 0x004A87A0 File Offset: 0x004A69A0
	private void PushPartCameraHandle(int partTabIndex)
	{
		MotorFramePart? motorFramePart = null;
		MotorStickerPart? motorStickerPart = null;
		MotorDecorationsPart? motorDecorationsPart = null;
		if (this.CurSelectTabView == EUiTabViewName.MotorcycleDiyEditFrameTabView)
		{
			motorFramePart = ConfigBase<MotorDiyConfig>.Instance.GetMotorFramePartConfig();
		}
		else if (this.CurSelectTabView == EUiTabViewName.MotorcycleDiyEditStickerTabView && partTabIndex > 0)
		{
			motorStickerPart = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerPartConfig(partTabIndex);
		}
		else if (this.CurSelectTabView == EUiTabViewName.MotorcycleDiyEditDecorationTabView && partTabIndex > 0)
		{
			motorDecorationsPart = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationPartConfig(partTabIndex);
		}
		string[] array = null;
		string[] array2 = null;
		if (motorFramePart != null)
		{
			array = motorFramePart.Value.CameraIds();
			array2 = motorFramePart.Value.DetailCameraIds();
		}
		else if (motorStickerPart != null)
		{
			array = motorStickerPart.Value.CameraIds();
			array2 = motorStickerPart.Value.DetailCameraIds();
		}
		else if (motorDecorationsPart != null)
		{
			array = motorDecorationsPart.Value.CameraIds();
			array2 = motorDecorationsPart.Value.DetailCameraIds();
		}
		if (array == null || array.Length == 0)
		{
			return;
		}
		string[] array3 = this.IsNotHidingUi ? array : (array2 ?? array);
		string handleName = array3[0];
		if (partTabIndex == 3 && array3.Length > 1)
		{
			handleName = (this.IsPartDefaultCam ? array3[0] : array3[1]);
		}
		this.CameraInputComponent.CanCameraInput = !this.IsNotHidingUi;
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(handleName, true, true, "1001", false, null, null);
	}

	// Token: 0x06010FC6 RID: 69574 RVA: 0x004A8977 File Offset: 0x004A6B77
	private void OnTabCameraClick(int partIndex)
	{
		this.CurSelectPart = partIndex;
		this.PushPartCameraHandle(partIndex);
		this.StartMaskTimer();
	}

	// Token: 0x06010FC7 RID: 69575 RVA: 0x004A898D File Offset: 0x004A6B8D
	private void OnSelectItemClick(EOutlookType itemType, int itemPart, int itemId)
	{
		this.CheckBtnEnable(itemType, itemPart, itemId);
	}

	// Token: 0x06010FC8 RID: 69576 RVA: 0x004A8998 File Offset: 0x004A6B98
	private void OnEditPresetChanged(EOutlookType outlookType, bool isModified)
	{
		if (this.TabComponent == null || this.TabDataList.Count == 0)
		{
			return;
		}
		EUiTabViewName? euiTabViewName;
		switch (outlookType)
		{
		case EOutlookType.Frame:
			euiTabViewName = new EUiTabViewName?(EUiTabViewName.MotorcycleDiyEditFrameTabView);
			break;
		case EOutlookType.Sticker:
			euiTabViewName = new EUiTabViewName?(EUiTabViewName.MotorcycleDiyEditStickerTabView);
			break;
		case EOutlookType.Decoration:
			euiTabViewName = new EUiTabViewName?(EUiTabViewName.MotorcycleDiyEditDecorationTabView);
			break;
		default:
			euiTabViewName = null;
			break;
		}
		EUiTabViewName? euiTabViewName2 = euiTabViewName;
		if (euiTabViewName2 == null)
		{
			return;
		}
		int i = 0;
		while (i < this.TabDataList.Count)
		{
			if ((EUiTabViewName)this.TabDataList[i].ChildViewName == euiTabViewName2)
			{
				MotorcycleEditTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(i);
				if (tabItemByIndex == null)
				{
					return;
				}
				tabItemByIndex.SetSubRedDotVisible(isModified);
				return;
			}
			else
			{
				i++;
			}
		}
	}

	// Token: 0x06010FC9 RID: 69577 RVA: 0x004A8A78 File Offset: 0x004A6C78
	[NullableContext(2)]
	private MotorcycleDiyPresetData GetLocalPresetData()
	{
		EMotorcycleDiyCustomMode? customMode = this.CustomMode;
		EMotorcycleDiyCustomMode emotorcycleDiyCustomMode = EMotorcycleDiyCustomMode.NewCreate;
		if (customMode.GetValueOrDefault() == emotorcycleDiyCustomMode & customMode != null)
		{
			return null;
		}
		return this.LocalPresetData;
	}

	// Token: 0x06010FCA RID: 69578 RVA: 0x004A8AAA File Offset: 0x004A6CAA
	private void OnTogChangeCameraPosClick(EToggleState toggleState)
	{
		this.IsPartDefaultCam = !this.IsPartDefaultCam;
		this.PushPartCameraHandle(3);
		this.StartMaskTimer();
	}

	// Token: 0x06010FCB RID: 69579 RVA: 0x004A8AC8 File Offset: 0x004A6CC8
	private void OnBtnMotorDiySaveClick()
	{
		this.CreateOrSaveDiyOutlookRequest();
	}

	// Token: 0x06010FCC RID: 69580 RVA: 0x004A8AD0 File Offset: 0x004A6CD0
	private void OnTogEyeClick(EToggleState toggleState)
	{
		this.IsNotHidingUi = !this.IsNotHidingUi;
		bool state = this.IsNotHidingUi;
		if (state)
		{
			base.GetItem(0).SetUIActive(state);
			base.PlaySequence("UiIn", delegate
			{
			}, true);
			this.CameraInputComponent.End();
		}
		else
		{
			base.PlaySequence("UiOut", delegate
			{
				this.GetItem(0).SetUIActive(state);
			}, true);
			this.CameraInputComponent.Start();
			this.CameraInputComponent.TryActivate();
		}
		base.GetItem(0).SetUIActive(state);
		this.PushPartCameraHandle(this.CurSelectPart);
	}

	// Token: 0x06010FCD RID: 69581 RVA: 0x004A8BA4 File Offset: 0x004A6DA4
	protected void CloseClick()
	{
		EMotorcycleDiyCustomMode? customMode = this.CustomMode;
		EMotorcycleDiyCustomMode emotorcycleDiyCustomMode = EMotorcycleDiyCustomMode.NewCreate;
		bool flag = customMode.GetValueOrDefault() == emotorcycleDiyCustomMode & customMode != null;
		if (this.IsModifyPreset || flag)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(flag ? EConfirmBoxConfigId.MotorDiyNewPresetConfirm : EConfirmBoxConfigId.MotorDiyChangePresetConfirm);
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				MotorcycleUiModelParam param = new MotorcycleUiModelParam
				{
					FrameId = this.LocalPresetData.FrameId,
					StickerIds = (this.LocalPresetData.StickerIds ?? new int[0]),
					DecorationIds = (this.LocalPresetData.DecorateIds ?? new int[0])
				};
				Singleton<MotorcycleUiModelUtil>.Instance.LoadMotorByParam(param, delegate(UiModelBase _)
				{
					base.CloseMe(null);
				});
			};
			confirmBoxDataNew.FunctionMap[2] = new Action(this.CreateOrSaveDiyOutlookRequest);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x06010FCE RID: 69582 RVA: 0x004A8C37 File Offset: 0x004A6E37
	private void AddHomeBtnExtraCallback()
	{
		UiBehaviourHomeBtn uiBehaviourHomeBtn = this.UiBehaviourHomeBtn;
		if (uiBehaviourHomeBtn == null)
		{
			return;
		}
		uiBehaviourHomeBtn.AddExtraAsyncCallback(delegate
		{
			MotorcycleDiyEditRootView.<<AddHomeBtnExtraCallback>b__48_0>d <<AddHomeBtnExtraCallback>b__48_0>d;
			<<AddHomeBtnExtraCallback>b__48_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<AddHomeBtnExtraCallback>b__48_0>d.<>4__this = this;
			<<AddHomeBtnExtraCallback>b__48_0>d.<>1__state = -1;
			<<AddHomeBtnExtraCallback>b__48_0>d.<>t__builder.Start<MotorcycleDiyEditRootView.<<AddHomeBtnExtraCallback>b__48_0>d>(ref <<AddHomeBtnExtraCallback>b__48_0>d);
			return <<AddHomeBtnExtraCallback>b__48_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x040085A8 RID: 34216
	private List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

	// Token: 0x040085A9 RID: 34217
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponentWithCaptionItem<MotorcycleEditTabItem> TabComponent;

	// Token: 0x040085AA RID: 34218
	[Nullable(2)]
	private TabViewComponent<UiDynamicTab> TabViewComponent;

	// Token: 0x040085AB RID: 34219
	private double? LastClickTime;

	// Token: 0x040085AC RID: 34220
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x040085AD RID: 34221
	public UiCameraInputComponent CameraInputComponent = new UiCameraInputComponent();

	// Token: 0x040085AE RID: 34222
	private bool IsNotHidingUi = true;

	// Token: 0x040085AF RID: 34223
	private bool IsPartDefaultCam = true;

	// Token: 0x040085B0 RID: 34224
	private EUiTabViewName? CurSelectTabView;

	// Token: 0x040085B1 RID: 34225
	private int CurSelectPart;

	// Token: 0x040085B2 RID: 34226
	private int OriginPartTabIndex;

	// Token: 0x040085B3 RID: 34227
	private bool IsInitCameraInput;

	// Token: 0x040085B4 RID: 34228
	private bool IsModifyPreset;

	// Token: 0x040085B5 RID: 34229
	[Nullable(2)]
	private MotorcycleDiyPresetData LocalPresetData;

	// Token: 0x040085B6 RID: 34230
	private EMotorcycleDiyCustomMode? CustomMode;

	// Token: 0x020085EA RID: 34282
	[NullableContext(0)]
	private class EMotorDiyRootComponent
	{
		// Token: 0x0402D4C6 RID: 185542
		public const int NotHideUIItem = 0;

		// Token: 0x0402D4C7 RID: 185543
		public const int CaptainItem = 1;

		// Token: 0x0402D4C8 RID: 185544
		public const int ContentItem = 2;

		// Token: 0x0402D4C9 RID: 185545
		public const int TogMotorDiyChange = 3;

		// Token: 0x0402D4CA RID: 185546
		public const int BtnMotorSaveOld = 4;

		// Token: 0x0402D4CB RID: 185547
		public const int TogEye = 5;

		// Token: 0x0402D4CC RID: 185548
		public const int DragComponent = 6;

		// Token: 0x0402D4CD RID: 185549
		public const int BtnMotorSave = 7;
	}
}
