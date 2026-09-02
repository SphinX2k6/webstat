using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002308 RID: 8968
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiyStickerPreviewView : UiViewBase
{
	// Token: 0x0601107A RID: 69754 RVA: 0x004ACD6E File Offset: 0x004AAF6E
	public MotorcycleDiyStickerPreviewView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601107B RID: 69755 RVA: 0x004ACD8C File Offset: 0x004AAF8C
	private List<SkinRewardData> GetPreviewReward(List<int> itemIdList)
	{
		List<SkinRewardData> list = new List<SkinRewardData>();
		int count = 1;
		foreach (int itemId in itemIdList)
		{
			InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(itemId, 0);
			SkinRewardData item = new SkinRewardData
			{
				ItemData = new TItem?(new TItem(itemData, count)),
				FinishState = false
			};
			list.Add(item);
		}
		list.Sort(delegate(SkinRewardData a, SkinRewardData b)
		{
			int num = (a.ItemData != null) ? a.ItemData.GetValueOrDefault().ItemData.ItemId : 0;
			int num2 = (b.ItemData != null) ? b.ItemData.GetValueOrDefault().ItemData.ItemId : 0;
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(num);
			ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(num2);
			int num3 = (itemConfigData != null) ? itemConfigData.QualityId : 0;
			int num4 = (itemConfigData2 != null) ? itemConfigData2.QualityId : 0;
			if (num3 != num4)
			{
				return num4 - num3;
			}
			return num - num2;
		});
		return list;
	}

	// Token: 0x0601107C RID: 69756 RVA: 0x004ACE30 File Offset: 0x004AB030
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnTogEyeClick))
		};
	}

	// Token: 0x0601107D RID: 69757 RVA: 0x004ACF34 File Offset: 0x004AB134
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(2));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnBackBtnClick));
		this.CaptionItem.SetHelpBtnActive(false);
		this.CaptionItem.SetTitleTextActive(false);
		this.CaptionItem.SetTitleIconVisible(false);
		int valueOrDefault = (this.OpenParam as int?).GetValueOrDefault();
		MotorGeneralPreview? motorGeneralPreviewConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorGeneralPreviewConfig(valueOrDefault);
		if (motorGeneralPreviewConfig == null)
		{
			return;
		}
		this.PreviewConfig = new MotorGeneralPreview?(motorGeneralPreviewConfig.Value);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), motorGeneralPreviewConfig.Value.IconTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), motorGeneralPreviewConfig.Value.Title, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), motorGeneralPreviewConfig.Value.SubTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), motorGeneralPreviewConfig.Value.Describe, Array.Empty<object>());
		this.ItemRewardLayout = new GenericLayout<SkinRewardItemGrid, SkinRewardData>(base.GetHorizontalLayout(6), new Func<SkinRewardItemGrid>(this.InitGridItem), null, false, true);
		List<SkinRewardData> previewReward = this.GetPreviewReward(motorGeneralPreviewConfig.Value.GetStickerArray().ToList<int>());
		this.ItemRewardLayout.RefreshByData(previewReward, null, false);
	}

	// Token: 0x0601107E RID: 69758 RVA: 0x004AD0B3 File Offset: 0x004AB2B3
	protected override void OnHandleLoadScene()
	{
		this.InitMotorModel();
	}

	// Token: 0x0601107F RID: 69759 RVA: 0x004AD0BC File Offset: 0x004AB2BC
	protected override void OnBeforeShow()
	{
		if (this.PreviewConfig == null)
		{
			return;
		}
		this.InitCameraInputData(this.PreviewConfig.Value.FreeCameraConfig);
		Singleton<MotorcycleUiModelUtil>.Instance.ShowMotor(true);
	}

	// Token: 0x06011080 RID: 69760 RVA: 0x004AD0FB File Offset: 0x004AB2FB
	protected override void OnHandleReleaseScene()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.DestroyMotor();
	}

	// Token: 0x06011081 RID: 69761 RVA: 0x004AD107 File Offset: 0x004AB307
	protected override void OnAfterShow()
	{
		this.CameraInputComponent.Start();
		this.CameraInputComponent.TryActivate();
	}

	// Token: 0x06011082 RID: 69762 RVA: 0x004AD120 File Offset: 0x004AB320
	protected override void OnBeforeHide()
	{
		this.CameraInputComponent.End();
		Singleton<MotorcycleUiModelUtil>.Instance.ShowMotor(false);
	}

	// Token: 0x06011083 RID: 69763 RVA: 0x004AD138 File Offset: 0x004AB338
	private SkinRewardItemGrid InitGridItem()
	{
		return new SkinRewardItemGrid();
	}

	// Token: 0x06011084 RID: 69764 RVA: 0x004AD140 File Offset: 0x004AB340
	private void InitMotorModel()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.CreateMotor(EUiModelUseWay.MotorInMotorView);
		if (this.PreviewConfig == null)
		{
			return;
		}
		int frame = this.PreviewConfig.Value.Frame;
		int[] stickerArray = this.PreviewConfig.Value.GetStickerArray();
		MotorcycleUiModelParam param = new MotorcycleUiModelParam
		{
			FrameId = frame,
			StickerIds = stickerArray
		};
		Singleton<MotorcycleUiModelUtil>.Instance.LoadMotorByParam(param, null);
	}

	// Token: 0x06011085 RID: 69765 RVA: 0x004AD1B0 File Offset: 0x004AB3B0
	private void InitCameraInputData(string cameraRotateConfig)
	{
		SUiRoleCameraSetting? roleCameraConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig(cameraRotateConfig);
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
			DragComponent = base.GetDraggable(0),
			CameraSettingConfig = roleCameraConfig.Value,
			SourceLocation = fvectorDouble
		};
		this.CameraInputComponent.InitData(data);
		if (this.PreviewConfig != null)
		{
			this.CameraInputComponent.CanCameraInput = this.PreviewConfig.Value.IsFree;
		}
	}

	// Token: 0x06011086 RID: 69766 RVA: 0x004AD260 File Offset: 0x004AB460
	private void PushExCameraHandle()
	{
		if (this.PreviewConfig == null)
		{
			return;
		}
		string handleName = this.IsNotHidingUi ? this.PreviewConfig.Value.CameraId : this.PreviewConfig.Value.FreeCamera;
		if (!this.PreviewConfig.Value.IsFree)
		{
			this.CameraInputComponent.CanCameraInput = !this.IsNotHidingUi;
		}
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(handleName, true, true, "1001", false, null, null);
	}

	// Token: 0x06011087 RID: 69767 RVA: 0x004AD2F3 File Offset: 0x004AB4F3
	private void OnBackBtnClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.MotorcycleDiyStickerPreviewView, null);
	}

	// Token: 0x06011088 RID: 69768 RVA: 0x004AD308 File Offset: 0x004AB508
	private void OnTogEyeClick(EToggleState toggleState)
	{
		this.IsNotHidingUi = !this.IsNotHidingUi;
		base.GetItem(3).SetUIActive(!this.IsNotHidingUi);
		bool state = this.IsNotHidingUi;
		if (state)
		{
			base.GetItem(3).SetUIActive(state);
			base.PlaySequence("UiIn", delegate
			{
			}, true);
		}
		else
		{
			base.PlaySequence("UiOut", delegate
			{
				this.GetItem(3).SetUIActive(state);
			}, true);
		}
		this.PushExCameraHandle();
	}

	// Token: 0x04008606 RID: 34310
	private bool IsNotHidingUi = true;

	// Token: 0x04008607 RID: 34311
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04008608 RID: 34312
	private MotorGeneralPreview? PreviewConfig;

	// Token: 0x04008609 RID: 34313
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SkinRewardItemGrid, SkinRewardData> ItemRewardLayout;

	// Token: 0x0400860A RID: 34314
	protected UiCameraInputComponent CameraInputComponent = new UiCameraInputComponent();

	// Token: 0x0200860C RID: 34316
	[NullableContext(0)]
	private class EMotorDecorationPreviewComponent
	{
		// Token: 0x0402D57F RID: 185727
		public const int DragComponent = 0;

		// Token: 0x0402D580 RID: 185728
		public const int TogEye = 1;

		// Token: 0x0402D581 RID: 185729
		public const int CaptionItem = 2;

		// Token: 0x0402D582 RID: 185730
		public const int NotHideUIItem = 3;

		// Token: 0x0402D583 RID: 185731
		public const int TxtTitle = 4;

		// Token: 0x0402D584 RID: 185732
		public const int TxtSubTitle = 5;

		// Token: 0x0402D585 RID: 185733
		public const int ItemRewardLayout = 6;

		// Token: 0x0402D586 RID: 185734
		public const int RewardItem = 7;

		// Token: 0x0402D587 RID: 185735
		public const int TxtDescription = 8;

		// Token: 0x0402D588 RID: 185736
		public const int TxtItemRewardTitle = 9;
	}
}
