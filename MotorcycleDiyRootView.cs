using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002305 RID: 8965
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiyRootView : UiViewBase
{
	// Token: 0x0601102A RID: 69674 RVA: 0x004AB2BA File Offset: 0x004A94BA
	public MotorcycleDiyRootView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601102B RID: 69675 RVA: 0x004AB2E8 File Offset: 0x004A94E8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(6, typeof(UUIDraggableComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnTogChangeCameraPosClick)),
			new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.OnTogEyeClick))
		};
	}

	// Token: 0x0601102C RID: 69676 RVA: 0x004AB3D8 File Offset: 0x004A95D8
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleDiyRootView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleDiyRootView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601102D RID: 69677 RVA: 0x004AB41C File Offset: 0x004A961C
	protected override void OnHandleLoadScene()
	{
		int selectedFrameId = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedFrameId();
		List<int> selectedStickerIdList = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedStickerIdList(false);
		List<int> selectedDecorationIdList = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedDecorationIdList(false);
		Singleton<MotorcycleUiModelUtil>.Instance.CreateMotor(EUiModelUseWay.MotorInMotorView);
		MotorcycleUiModelParam param = new MotorcycleUiModelParam
		{
			FrameId = selectedFrameId,
			StickerIds = selectedStickerIdList.ToArray(),
			DecorationIds = selectedDecorationIdList.ToArray()
		};
		Singleton<MotorcycleUiModelUtil>.Instance.LoadMotorByParam(param, null);
	}

	// Token: 0x0601102E RID: 69678 RVA: 0x004AB48C File Offset: 0x004A968C
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

	// Token: 0x0601102F RID: 69679 RVA: 0x004AB54C File Offset: 0x004A974C
	protected override void OnBeforeHide()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.ClearMotorBuff();
		Singleton<MotorcycleUiModelUtil>.Instance.ShowMotor(false);
	}

	// Token: 0x06011030 RID: 69680 RVA: 0x004AB563 File Offset: 0x004A9763
	protected override void OnHandleReleaseScene()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.DestroyMotor();
	}

	// Token: 0x06011031 RID: 69681 RVA: 0x004AB56F File Offset: 0x004A976F
	protected override void OnBeforeDestroy()
	{
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
		if (this.TabViewComponent != null)
		{
			this.TabViewComponent.DestroyTabViewComponent();
			this.TabViewComponent = null;
		}
	}

	// Token: 0x06011032 RID: 69682 RVA: 0x004AB5A6 File Offset: 0x004A97A6
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoUpdate, new Action(this.OnRootUpdate));
	}

	// Token: 0x06011033 RID: 69683 RVA: 0x004AB5C4 File Offset: 0x004A97C4
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoUpdate, new Action(this.OnRootUpdate));
	}

	// Token: 0x06011034 RID: 69684 RVA: 0x004AB5E4 File Offset: 0x004A97E4
	protected void InitTabComponent()
	{
		CommonTabComponentData<MotorcycleTabItem> data = new CommonTabComponentData<MotorcycleTabItem>(new Func<UUIItem, int?, MotorcycleTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
		this.TabComponent = new TabComponentWithCaptionItem<MotorcycleTabItem>(base.GetItem(1), data, new Action(this.CloseClick), false);
		this.LastClickTime = null;
		this.TabComponent.SetCanChange(new Func<int, bool?, bool>(this.CanToggleChange));
		this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(2), EKeyMode.Default);
	}

	// Token: 0x06011035 RID: 69685 RVA: 0x004AB674 File Offset: 0x004A9874
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
		FVectorDouble fvectorDouble = actorWithTag.D_K2_GetActorLocation();
		UiCameraInputComponentData data = new UiCameraInputComponentData
		{
			DragComponent = base.GetDraggable(6),
			CameraSettingConfig = roleCameraConfig.Value,
			SourceLocation = fvectorDouble
		};
		this.CameraInputComponent.InitData(data);
		this.IsInitCameraInput = true;
	}

	// Token: 0x06011036 RID: 69686 RVA: 0x004AB709 File Offset: 0x004A9909
	private MotorcycleTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new MotorcycleTabItem
		{
			OnRegisterViewCallback = delegate(UiTabViewBase view)
			{
				IMotorcycleDiyTabViewRegister motorcycleDiyTabViewRegister = view as IMotorcycleDiyTabViewRegister;
				if (motorcycleDiyTabViewRegister != null)
				{
					motorcycleDiyTabViewRegister.OnTabCameraClick = new Action<int>(this.OnTabCameraClick);
					motorcycleDiyTabViewRegister.OnSelectItemClick = new Action<EOutlookType, int, int>(this.OnSelectItemClick);
				}
			}
		};
	}

	// Token: 0x06011037 RID: 69687 RVA: 0x004AB722 File Offset: 0x004A9922
	private void OnTabCameraClick(int partIndex)
	{
		this.CurSelectPart = partIndex;
		this.PushPartCameraHandle(partIndex);
		this.StartMaskTimer();
	}

	// Token: 0x06011038 RID: 69688 RVA: 0x004AB738 File Offset: 0x004A9938
	protected UniTask RefreshTabListAsync()
	{
		MotorcycleDiyRootView.<RefreshTabListAsync>d__29 <RefreshTabListAsync>d__;
		<RefreshTabListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabListAsync>d__.<>4__this = this;
		<RefreshTabListAsync>d__.<>1__state = -1;
		<RefreshTabListAsync>d__.<>t__builder.Start<MotorcycleDiyRootView.<RefreshTabListAsync>d__29>(ref <RefreshTabListAsync>d__);
		return <RefreshTabListAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011039 RID: 69689 RVA: 0x004AB77C File Offset: 0x004A997C
	private bool CanToggleChange(int index, bool? _)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			return true;
		}
		int value = ConfigCommonParamById.GetIntConfig("panel_interval_time").Value;
		return this.LastClickTime == null || Singleton<Time>.Instance.Now - this.LastClickTime.Value >= (double)value;
	}

	// Token: 0x0601103A RID: 69690 RVA: 0x004AB7D4 File Offset: 0x004A99D4
	private void ToggleCallBack(int index)
	{
		this.LastClickTime = new double?(Singleton<Time>.Instance.Now);
		UiDynamicTab data = this.TabDataList[index];
		EUiTabViewName euiTabViewName = (EUiTabViewName)data.ChildViewName;
		MotorcycleTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
		this.CurSelectTabView = new EUiTabViewName?(euiTabViewName);
		if (this.OriginPartTabIndex > 0)
		{
			this.TabViewComponent.ToggleCallBack(data, euiTabViewName, tabItemByIndex, this.OriginPartTabIndex, null);
			this.OriginPartTabIndex = 0;
			return;
		}
		this.TabViewComponent.ToggleCallBack(data, euiTabViewName, tabItemByIndex, null, null);
	}

	// Token: 0x0601103B RID: 69691 RVA: 0x004AB874 File Offset: 0x004A9A74
	private CommonTabData GetCommonData(int index)
	{
		UiDynamicTab uiDynamicTab = this.TabDataList[index];
		return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
	}

	// Token: 0x0601103C RID: 69692 RVA: 0x004AB8AC File Offset: 0x004A9AAC
	protected ERedDotName? GetRedDotName(EUiTabViewName tabViewName)
	{
		if (tabViewName == EUiTabViewName.MotorcycleDiyFrameTabView)
		{
			return new ERedDotName?(ERedDotName.MotorcycleDiyFrameTab);
		}
		if (tabViewName == EUiTabViewName.MotorcycleDiyStickerTabView)
		{
			return new ERedDotName?(ERedDotName.MotorcycleDiyStickerTab);
		}
		if (tabViewName == EUiTabViewName.MotorcycleDiyDecorationTabView)
		{
			return new ERedDotName?(ERedDotName.MotorcycleDiyDecorationTab);
		}
		return null;
	}

	// Token: 0x0601103D RID: 69693 RVA: 0x004AB90C File Offset: 0x004A9B0C
	protected ERedDotName? GetPreviewRedDotName(EUiTabViewName tabViewName)
	{
		if (tabViewName == EUiTabViewName.MotorcycleDiyFrameTabView)
		{
			return new ERedDotName?(ERedDotName.MotorcycleDiyFramePreTab);
		}
		if (tabViewName == EUiTabViewName.MotorcycleDiyStickerTabView)
		{
			return new ERedDotName?(ERedDotName.MotorcycleDiyStickerPreTab);
		}
		if (tabViewName == EUiTabViewName.MotorcycleDiyDecorationTabView)
		{
			return new ERedDotName?(ERedDotName.MotorcycleDiyDecorationPreTab);
		}
		return null;
	}

	// Token: 0x0601103E RID: 69694 RVA: 0x004AB96C File Offset: 0x004A9B6C
	private void CheckBtnEnable(EOutlookType itemType, int itemPart, int itemId)
	{
		if (itemType == EOutlookType.Decoration || itemType == EOutlookType.Frame)
		{
			base.GetExtendToggle(3).RootUIComp.Get().SetUIActive(false);
			return;
		}
		base.GetExtendToggle(3).RootUIComp.Get().SetUIActive(itemPart == 3);
	}

	// Token: 0x0601103F RID: 69695 RVA: 0x004AB9B9 File Offset: 0x004A9BB9
	private void RemoveMaskTimer()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06011040 RID: 69696 RVA: 0x004AB9DC File Offset: 0x004A9BDC
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

	// Token: 0x06011041 RID: 69697 RVA: 0x004ABA48 File Offset: 0x004A9C48
	private void PushPartCameraHandle(int partTabIndex)
	{
		MotorFramePart? motorFramePart = null;
		MotorStickerPart? motorStickerPart = null;
		MotorDecorationsPart? motorDecorationsPart = null;
		if (this.CurSelectTabView == EUiTabViewName.MotorcycleDiyFrameTabView)
		{
			motorFramePart = ConfigBase<MotorDiyConfig>.Instance.GetMotorFramePartConfig();
		}
		else if (this.CurSelectTabView == EUiTabViewName.MotorcycleDiyStickerTabView)
		{
			if (partTabIndex > 0)
			{
				motorStickerPart = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerPartConfig(partTabIndex);
			}
		}
		else if (this.CurSelectTabView == EUiTabViewName.MotorcycleDiyDecorationTabView && partTabIndex > 0)
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
		List<string> list = new List<string>();
		foreach (string item in this.IsNotHidingUi ? array : (array2 ?? array))
		{
			list.Add(item);
		}
		string handleName = list[0];
		if (partTabIndex == 3 && list.Count > 1)
		{
			handleName = (this.IsPartDefaultCam ? list[0] : list[1]);
		}
		this.CameraInputComponent.CanCameraInput = !this.IsNotHidingUi;
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(handleName, true, true, "1001", false, null, null);
	}

	// Token: 0x06011042 RID: 69698 RVA: 0x004ABC58 File Offset: 0x004A9E58
	private void OnRootUpdate()
	{
		ButtonItem btnSave = this.BtnSave;
		if (btnSave == null)
		{
			return;
		}
		btnSave.SetEnableClick(false);
	}

	// Token: 0x06011043 RID: 69699 RVA: 0x004ABC6B File Offset: 0x004A9E6B
	private void OnSelectItemClick(EOutlookType itemType, int itemPart, int itemId)
	{
		this.CheckBtnEnable(itemType, itemPart, itemId);
	}

	// Token: 0x06011044 RID: 69700 RVA: 0x004ABC76 File Offset: 0x004A9E76
	private void OnTogChangeCameraPosClick(EToggleState toggleState)
	{
		this.IsPartDefaultCam = !this.IsPartDefaultCam;
		this.PushPartCameraHandle(3);
		this.StartMaskTimer();
	}

	// Token: 0x06011045 RID: 69701 RVA: 0x004ABC94 File Offset: 0x004A9E94
	private void OnBtnMotorDiySaveClick(int _)
	{
		List<int> selectedStickerIdList = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedStickerIdList(false);
		ControllerBase<MotorcycleDiyController>.Instance.EquipMotorStickerRequest(selectedStickerIdList, null);
	}

	// Token: 0x06011046 RID: 69702 RVA: 0x004ABCBC File Offset: 0x004A9EBC
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
		this.PushPartCameraHandle(this.CurSelectPart);
	}

	// Token: 0x06011047 RID: 69703 RVA: 0x004ABD7E File Offset: 0x004A9F7E
	protected void CloseClick()
	{
		if (!this.IsNeedResetMotor)
		{
			base.CloseMe(null);
			return;
		}
		ModelBase<MotorcycleDiyModel>.Instance.ResetSelectedItemInfo();
		Singleton<MotorcycleUiModelUtil>.Instance.LoadEquippedMotor(delegate(UiModelBase _)
		{
			base.CloseMe(null);
		});
	}

	// Token: 0x040085DC RID: 34268
	private List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

	// Token: 0x040085DD RID: 34269
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponentWithCaptionItem<MotorcycleTabItem> TabComponent;

	// Token: 0x040085DE RID: 34270
	[Nullable(2)]
	private TabViewComponent<UiDynamicTab> TabViewComponent;

	// Token: 0x040085DF RID: 34271
	private double? LastClickTime;

	// Token: 0x040085E0 RID: 34272
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x040085E1 RID: 34273
	[Nullable(2)]
	private ButtonItem BtnSave;

	// Token: 0x040085E2 RID: 34274
	public UiCameraInputComponent CameraInputComponent = new UiCameraInputComponent();

	// Token: 0x040085E3 RID: 34275
	private bool IsNotHidingUi = true;

	// Token: 0x040085E4 RID: 34276
	private bool IsPartDefaultCam = true;

	// Token: 0x040085E5 RID: 34277
	private EUiTabViewName? CurSelectTabView;

	// Token: 0x040085E6 RID: 34278
	private int CurSelectPart;

	// Token: 0x040085E7 RID: 34279
	private int OriginPartTabIndex;

	// Token: 0x040085E8 RID: 34280
	private bool IsNeedResetMotor;

	// Token: 0x040085E9 RID: 34281
	private bool IsInitCameraInput;

	// Token: 0x02008602 RID: 34306
	[NullableContext(0)]
	private class EMotorDiyRootComponent
	{
		// Token: 0x0402D54F RID: 185679
		public const int NotHideUIItem = 0;

		// Token: 0x0402D550 RID: 185680
		public const int CaptainItem = 1;

		// Token: 0x0402D551 RID: 185681
		public const int ContentItem = 2;

		// Token: 0x0402D552 RID: 185682
		public const int TogMotorDiyChange = 3;

		// Token: 0x0402D553 RID: 185683
		public const int BtnMotorSave = 4;

		// Token: 0x0402D554 RID: 185684
		public const int TogEye = 5;

		// Token: 0x0402D555 RID: 185685
		public const int DragComponent = 6;
	}
}
