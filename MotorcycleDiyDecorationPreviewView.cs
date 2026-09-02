using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020022FD RID: 8957
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiyDecorationPreviewView : UiViewBase
{
	// Token: 0x06010F94 RID: 69524 RVA: 0x004A7422 File Offset: 0x004A5622
	public MotorcycleDiyDecorationPreviewView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010F95 RID: 69525 RVA: 0x004A7440 File Offset: 0x004A5640
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnTogEyeClick))
		};
	}

	// Token: 0x06010F96 RID: 69526 RVA: 0x004A7500 File Offset: 0x004A5700
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(1));
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
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), motorGeneralPreviewConfig.Value.Title, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), motorGeneralPreviewConfig.Value.SubTitle, Array.Empty<object>());
	}

	// Token: 0x06010F97 RID: 69527 RVA: 0x004A75E5 File Offset: 0x004A57E5
	protected override void OnHandleLoadScene()
	{
		this.InitMotorModel();
	}

	// Token: 0x06010F98 RID: 69528 RVA: 0x004A75F0 File Offset: 0x004A57F0
	protected override void OnBeforeShow()
	{
		if (this.PreviewConfig == null)
		{
			return;
		}
		this.InitCameraInputData(this.PreviewConfig.Value.FreeCameraConfig);
		Singleton<MotorcycleUiModelUtil>.Instance.ShowMotor(true);
		this.PushExCameraHandle();
	}

	// Token: 0x06010F99 RID: 69529 RVA: 0x004A7635 File Offset: 0x004A5835
	protected override void OnHandleReleaseScene()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.DestroyMotor();
	}

	// Token: 0x06010F9A RID: 69530 RVA: 0x004A7644 File Offset: 0x004A5844
	private void InitMotorModel()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.CreateMotor(EUiModelUseWay.MotorInMotorView);
		if (this.PreviewConfig == null)
		{
			return;
		}
		MotorGeneralPreview value = this.PreviewConfig.Value;
		int frame = value.Frame;
		int[] decorationsArray = value.GetDecorationsArray();
		MotorcycleUiModelParam param = new MotorcycleUiModelParam
		{
			FrameId = frame,
			DecorationIds = decorationsArray
		};
		Singleton<MotorcycleUiModelUtil>.Instance.LoadMotorByParam(param, null);
	}

	// Token: 0x06010F9B RID: 69531 RVA: 0x004A76A8 File Offset: 0x004A58A8
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
	}

	// Token: 0x06010F9C RID: 69532 RVA: 0x004A772C File Offset: 0x004A592C
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

	// Token: 0x06010F9D RID: 69533 RVA: 0x004A77BF File Offset: 0x004A59BF
	private void OnBackBtnClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.MotorcycleDiyDecorationPreviewView, null);
	}

	// Token: 0x06010F9E RID: 69534 RVA: 0x004A77D4 File Offset: 0x004A59D4
	private void OnTogEyeClick(EToggleState toggleState)
	{
		this.IsNotHidingUi = !this.IsNotHidingUi;
		base.GetItem(5).SetUIActive(!this.IsNotHidingUi);
		bool state = this.IsNotHidingUi;
		if (state)
		{
			base.GetItem(5).SetUIActive(state);
			base.PlaySequence("UiIn", delegate
			{
			}, true);
			this.CameraInputComponent.End();
		}
		else
		{
			base.PlaySequence("UiOut", delegate
			{
				this.GetItem(5).SetUIActive(state);
			}, true);
			this.CameraInputComponent.Start();
			this.CameraInputComponent.TryActivate();
		}
		this.PushExCameraHandle();
	}

	// Token: 0x0400859B RID: 34203
	private bool IsNotHidingUi = true;

	// Token: 0x0400859C RID: 34204
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400859D RID: 34205
	private MotorGeneralPreview? PreviewConfig;

	// Token: 0x0400859E RID: 34206
	protected UiCameraInputComponent CameraInputComponent = new UiCameraInputComponent();

	// Token: 0x020085E3 RID: 34275
	[NullableContext(0)]
	private class EMotorDecorationPreviewComponent
	{
		// Token: 0x0402D4AE RID: 185518
		public const int DragComponent = 0;

		// Token: 0x0402D4AF RID: 185519
		public const int CaptionItem = 1;

		// Token: 0x0402D4B0 RID: 185520
		public const int TogEye = 2;

		// Token: 0x0402D4B1 RID: 185521
		public const int TxtTitle = 3;

		// Token: 0x0402D4B2 RID: 185522
		public const int TxtSubTitle = 4;

		// Token: 0x0402D4B3 RID: 185523
		public const int NotHideUIItem = 5;
	}
}
