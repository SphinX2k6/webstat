using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002302 RID: 8962
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleDiyMainView : UiTabViewBase
{
	// Token: 0x06011007 RID: 69639 RVA: 0x004AA26C File Offset: 0x004A846C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(16, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnTogEyeClick)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnBtnSkinClick)),
			new ValueTuple<int, Delegate>(11, new Action(this.OnBtnImportPresetClick)),
			new ValueTuple<int, Delegate>(15, new Action<EToggleState>(this.OnToggleSceneClick))
		};
	}

	// Token: 0x06011008 RID: 69640 RVA: 0x004AA45C File Offset: 0x004A865C
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleDiyMainView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleDiyMainView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06011009 RID: 69641 RVA: 0x004AA4A0 File Offset: 0x004A86A0
	protected override void OnBeforeShow()
	{
		int equippedSkinId = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedSkinId();
		MotorSkin? motorSkinConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorSkinConfig(equippedSkinId);
		if (motorSkinConfig == null)
		{
			return;
		}
		this.IsDiyEditable = motorSkinConfig.Value.Editable;
		base.SetTextureByPath(motorSkinConfig.Value.MainIcon, base.GetTexture(3), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), motorSkinConfig.Value.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), motorSkinConfig.Value.BgDescription, Array.Empty<object>());
		this.FramePanel.Refresh(ModelBase<MotorcycleDiyModel>.Instance.GetEquippedFrameId());
		this.FramePanel.SetEditable(this.IsDiyEditable);
		this.StickerPanel.Refresh(ModelBase<MotorcycleDiyModel>.Instance.GetEquippedStickerIdList());
		this.StickerPanel.SetEditable(this.IsDiyEditable);
		base.GetButton(11).RootUIComp.Get().SetUIActive(this.IsDiyEditable);
		base.GetDraggable(13).RootUIComp.Get().SetUIActive(this.IsObserving);
		this.CameraInputComponent.CanCameraInput = this.IsObserving;
		this.DecoratePanel.Refresh(ModelBase<MotorcycleDiyModel>.Instance.GetEquippedDecorationIdList());
		this.DecoratePanel.SetEditable(this.IsDiyEditable);
		ModelBase<MotorcycleDevelopModel>.Instance.UpdateSelectedTreeType(0);
		base.GetItem(14).SetUIActive(ModelBase<MotorcycleDiyModel>.Instance.RedDotHasNewSkin());
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.MotorcycleSceneButtonRedDot, base.GetItem(16), null, 0);
	}

	// Token: 0x0601100A RID: 69642 RVA: 0x004AA653 File Offset: 0x004A8853
	protected override void OnAfterShow()
	{
		this.CameraInputComponent.Start();
		this.CameraInputComponent.TryActivate();
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "MotorDiyViewShow");
	}

	// Token: 0x0601100B RID: 69643 RVA: 0x004AA681 File Offset: 0x004A8881
	protected override void OnBeforeHide()
	{
		this.CameraInputComponent.End();
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.MotorcycleSceneButtonRedDot);
	}

	// Token: 0x0601100C RID: 69644 RVA: 0x004AA6A0 File Offset: 0x004A88A0
	public void InitCameraInputData()
	{
		SUiRoleCameraSetting? roleCameraConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig("摩托车自定义界面");
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
			DragComponent = base.GetDraggable(13),
			CameraSettingConfig = roleCameraConfig.Value,
			SourceLocation = fvectorDouble
		};
		this.CameraInputComponent.InitData(data);
	}

	// Token: 0x0601100D RID: 69645 RVA: 0x004AA728 File Offset: 0x004A8928
	private void OnTogEyeClick(EToggleState toggleState)
	{
		this.IsObserving = !this.IsObserving;
		bool state = this.IsObserving;
		if (!state)
		{
			base.GetItem(12).SetUIActive(!state);
			this.UiViewSequence.StopSequenceByKey("UiIn", false, false);
			this.UiViewSequence.PlaySequencePurely("UiIn", false, false);
		}
		else
		{
			this.UiViewSequence.AddSequenceFinishEvent("UiOut", delegate(string _)
			{
				this.GetItem(12).SetUIActive(!state);
			}, false);
			this.UiViewSequence.StopSequenceByKey("UiOut", false, false);
			this.UiViewSequence.PlaySequencePurely("UiOut", false, false);
		}
		base.GetExtendToggle(15).RootUIComp.Get().SetUIActive(!state);
		MotorDevelopRootData p = new MotorDevelopRootData
		{
			IsObserving = new bool?(this.IsObserving)
		};
		Singleton<EventSystem>.Instance.Emit<MotorDevelopRootData>(EEventName.MotorDevelopRootUpdate, p);
		base.GetDraggable(13).RootUIComp.Get().SetUIActive(this.IsObserving);
		this.CameraInputComponent.CanCameraInput = this.IsObserving;
		string handleName = ConfigCommonParamById.GetStringConfig(this.IsObserving ? "MotorDiyMainCameraIdIn" : "MotorDiyMainCameraIdOut") ?? "";
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(handleName, true, true, "1001", false, null, null);
	}

	// Token: 0x0601100E RID: 69646 RVA: 0x004AA8A0 File Offset: 0x004A8AA0
	private void OnBtnSkinClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiySkinView, null, null);
	}

	// Token: 0x0601100F RID: 69647 RVA: 0x004AA8B3 File Offset: 0x004A8AB3
	private void OnBtnImportPresetClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiyImportPresetView, null, null);
	}

	// Token: 0x06011010 RID: 69648 RVA: 0x004AA8C6 File Offset: 0x004A8AC6
	private void OnToggleSceneClick(EToggleState toggleState)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleScenePopupView, null, null);
	}

	// Token: 0x040085CD RID: 34253
	private MotorcycleDiyFramePanel FramePanel;

	// Token: 0x040085CE RID: 34254
	private MotorcycleDiyStickerPanel StickerPanel;

	// Token: 0x040085CF RID: 34255
	private MotorcycleDiyDecoratePanel DecoratePanel;

	// Token: 0x040085D0 RID: 34256
	[Nullable(1)]
	public UiCameraInputComponent CameraInputComponent = new UiCameraInputComponent();

	// Token: 0x040085D1 RID: 34257
	private bool IsObserving;

	// Token: 0x040085D2 RID: 34258
	private bool IsDiyEditable;

	// Token: 0x020085FB RID: 34299
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402D528 RID: 185640
		public const int TogEye = 0;

		// Token: 0x0402D529 RID: 185641
		public const int PanelSkinTitle = 1;

		// Token: 0x0402D52A RID: 185642
		public const int BtnSkin = 2;

		// Token: 0x0402D52B RID: 185643
		public const int TexSkinIcon = 3;

		// Token: 0x0402D52C RID: 185644
		public const int TxtSkinTitle = 4;

		// Token: 0x0402D52D RID: 185645
		public const int PanelTitle = 5;

		// Token: 0x0402D52E RID: 185646
		public const int TxtTitle = 6;

		// Token: 0x0402D52F RID: 185647
		public const int TxtDesc = 7;

		// Token: 0x0402D530 RID: 185648
		public const int PanelMotorFrame = 8;

		// Token: 0x0402D531 RID: 185649
		public const int PanelMotorSticker = 9;

		// Token: 0x0402D532 RID: 185650
		public const int PanelMotorDecoration = 10;

		// Token: 0x0402D533 RID: 185651
		public const int BtnImportPreset = 11;

		// Token: 0x0402D534 RID: 185652
		public const int PanelHideUI = 12;

		// Token: 0x0402D535 RID: 185653
		public const int DragComponent = 13;

		// Token: 0x0402D536 RID: 185654
		public const int RedDotItem = 14;

		// Token: 0x0402D537 RID: 185655
		public const int ToggleScene = 15;

		// Token: 0x0402D538 RID: 185656
		public const int ToggleSceneRedDot = 16;
	}
}
