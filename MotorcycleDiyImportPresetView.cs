using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.InputView.Controller;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002301 RID: 8961
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiyImportPresetView : UiViewBase
{
	// Token: 0x06010FDC RID: 69596 RVA: 0x004A8F9C File Offset: 0x004A719C
	public MotorcycleDiyImportPresetView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010FDD RID: 69597 RVA: 0x004A9024 File Offset: 0x004A7224
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(30, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIText)),
			new ValueTuple<int, Type>(19, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(20, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(24, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(26, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(23, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(27, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(28, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(29, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(25, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(31, typeof(UUIItem)),
			new ValueTuple<int, Type>(32, typeof(UUIText)),
			new ValueTuple<int, Type>(33, typeof(UUIItem)),
			new ValueTuple<int, Type>(34, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(19, new Action<EToggleState>(this.OnTogCustomPresetClick)),
			new ValueTuple<int, Delegate>(20, new Action<EToggleState>(this.OnTogOfficialPresetClick)),
			new ValueTuple<int, Delegate>(24, new Action<EToggleState>(this.OnTogEyeClick)),
			new ValueTuple<int, Delegate>(23, new Action(this.OnBtnCreatePresetClick)),
			new ValueTuple<int, Delegate>(27, new Action(this.OnBtnDeletePresetClick)),
			new ValueTuple<int, Delegate>(28, new Action(this.OnBtnEditPresetClick)),
			new ValueTuple<int, Delegate>(29, new Action(this.OnBtnSaveToNewPresetClick)),
			new ValueTuple<int, Delegate>(25, new Action(this.OnBtnEditNameClick)),
			new ValueTuple<int, Delegate>(13, new Action(this.OnBtnImportPresetClick))
		};
	}

	// Token: 0x06010FDE RID: 69598 RVA: 0x004A9444 File Offset: 0x004A7644
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleDiyImportPresetView.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleDiyImportPresetView.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010FDF RID: 69599 RVA: 0x004A9487 File Offset: 0x004A7687
	protected override void OnBeforeShow()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.ShowMotor(true);
		this.RefreshLeftPresetInfo(true, this.CustomPresetDataIndex, true, false);
	}

	// Token: 0x06010FE0 RID: 69600 RVA: 0x004A94A3 File Offset: 0x004A76A3
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyFullOutlookUpdate, new Action(this.OnUpdateAllPresetInfo));
	}

	// Token: 0x06010FE1 RID: 69601 RVA: 0x004A94C1 File Offset: 0x004A76C1
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyFullOutlookUpdate, new Action(this.OnUpdateAllPresetInfo));
	}

	// Token: 0x06010FE2 RID: 69602 RVA: 0x004A94DF File Offset: 0x004A76DF
	protected override void OnAfterShow()
	{
		this.CameraInputComponent.Start();
		this.CameraInputComponent.TryActivate();
	}

	// Token: 0x06010FE3 RID: 69603 RVA: 0x004A94F8 File Offset: 0x004A76F8
	protected override void OnBeforeHide()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.ShowMotor(false);
		this.CameraInputComponent.End();
	}

	// Token: 0x06010FE4 RID: 69604 RVA: 0x004A9510 File Offset: 0x004A7710
	protected override void OnHandleReleaseScene()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.DestroyMotor();
	}

	// Token: 0x06010FE5 RID: 69605 RVA: 0x004A951C File Offset: 0x004A771C
	private void OnClickPresetItem(MotorcycleDiyPresetData data, int listIndex, UUIExtendToggle toggle)
	{
		if (this.CurrentSelectToggle != null)
		{
			this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		this.CustomPresetDataIndex = listIndex;
		this.RefreshRightPresetInfo(data);
	}

	// Token: 0x06010FE6 RID: 69606 RVA: 0x004A955B File Offset: 0x004A775B
	private MotorcycleDiyPresetItem InitPresetScrollItem()
	{
		return new MotorcycleDiyPresetItem
		{
			OnClickToggleBack = new Action<MotorcycleDiyPresetData, int, UUIExtendToggle>(this.OnClickPresetItem)
		};
	}

	// Token: 0x06010FE7 RID: 69607 RVA: 0x004A9574 File Offset: 0x004A7774
	private MotorcycleDiyPresetStickerItem InitStickerScrollItem()
	{
		return new MotorcycleDiyPresetStickerItem();
	}

	// Token: 0x06010FE8 RID: 69608 RVA: 0x004A957B File Offset: 0x004A777B
	private MotorcycleDiyPresetDecorationItem InitDecorateScrollItem()
	{
		return new MotorcycleDiyPresetDecorationItem();
	}

	// Token: 0x06010FE9 RID: 69609 RVA: 0x004A9584 File Offset: 0x004A7784
	private void RefreshLeftPresetInfo(bool isCustom, int selectIndex = -1, bool needScroll = true, bool playGridAnim = false)
	{
		List<MotorcycleDiyPresetData> allPresetDataList = ModelBase<MotorcycleDiyModel>.Instance.GetAllPresetDataList(isCustom);
		int count = allPresetDataList.Count;
		bool flag = count >= this.MaxCustomPresetNum;
		base.GetButton(23).RootUIComp.Get().SetUIActive(isCustom);
		base.GetButton(23).SetSelfInteractive(!flag);
		base.GetItem(4).SetUIActive(!isCustom);
		base.GetItem(33).SetUIActive(isCustom);
		base.GetItem(34).SetUIActive(isCustom);
		base.GetItem(22).SetUIActive(count <= 0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(21), "DIYProjectList", new <>z__ReadOnlyArray<object>(new object[]
		{
			count,
			this.MaxCustomPresetNum
		}));
		this.PresetScrollView.SetActive(count > 0);
		this.PresetScrollView.RefreshByData(allPresetDataList, delegate
		{
			this.GetItem(4).SetAsLastHierarchy();
			if (selectIndex < 0)
			{
				MotorcycleDiyPresetItem curPresetItem = this.CurPresetItem;
				if (curPresetItem == null)
				{
					return;
				}
				curPresetItem.OnSelected(true);
				return;
			}
			else
			{
				UUIItem selectItem = this.PresetScrollView.GetItemByIndex(selectIndex);
				if (needScroll && selectItem != null)
				{
					this.PresetScrollView.LateScrollTo(selectItem, delegate
					{
						this.PresetScrollView.SelectGridProxy(selectIndex, false);
						ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(selectItem, false, false, false);
					}, false);
					return;
				}
				this.PresetScrollView.SelectGridProxy(selectIndex, false);
				if (selectItem != null)
				{
					ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(selectItem, false, false, false);
				}
				return;
			}
		}, playGridAnim);
	}

	// Token: 0x06010FEA RID: 69610 RVA: 0x004A969C File Offset: 0x004A789C
	private MotorcycleDiyPresetData BuildCurrentPresetData()
	{
		return new MotorcycleDiyPresetData
		{
			IsCurEquipped = true,
			Name = (ConfigMultiTextLang.GetLocalTextNew("DIYProjectPresent", null) ?? string.Empty),
			FrameId = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedFrameId(),
			StickerIds = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedStickerIdList().ToArray(),
			DecorateIds = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedDecorationIdList().ToArray()
		};
	}

	// Token: 0x06010FEB RID: 69611 RVA: 0x004A970C File Offset: 0x004A790C
	private void RefreshRightPresetInfo(MotorcycleDiyPresetData data)
	{
		this.RefreshFramePresetInfo(data);
		this.RefreshStickerPresetInfo(data);
		this.RefreshDecorationPresetInfo(data);
		bool uiactive = data.CustomId > 0;
		int count = ModelBase<MotorcycleDiyModel>.Instance.GetAllPresetDataList(true).Count;
		bool isCurEquipped = data.IsCurEquipped;
		bool flag = count >= this.MaxCustomPresetNum;
		base.GetItem(30).SetUIActive(isCurEquipped && flag);
		base.GetButton(29).RootUIComp.Get().SetUIActive(isCurEquipped && !flag);
		base.GetButton(27).RootUIComp.Get().SetUIActive(uiactive);
		base.GetButton(25).RootUIComp.Get().SetUIActive(uiactive);
		base.GetButton(28).RootUIComp.Get().SetUIActive(uiactive);
		base.GetButton(13).RootUIComp.Get().SetUIActive(!isCurEquipped);
		base.GetText(32).SetText(data.Name, true);
		if (data.CustomId > 0)
		{
			this.CurCustomPresetData = data;
		}
		bool flag2 = base.GetButton(25).RootUIComp.Get().IsUIActiveSelf();
		UUIItem uuiitem = base.GetHorizontalLayout(26).RootUIComp.Get();
		uuiitem.SetWidth((float)(flag2 ? this.TwoBtnWidthAndOffsetX[0] : this.OneBtnWidthAndOffsetX[0]));
		uuiitem.SetAnchorOffsetX((float)(flag2 ? this.TwoBtnWidthAndOffsetX[1] : this.OneBtnWidthAndOffsetX[1]));
		if (this.IsEyeActiveFromGamepad)
		{
			this.IsEyeActiveFromGamepad = false;
			return;
		}
		MotorcycleUiModelParam param = new MotorcycleUiModelParam
		{
			FrameId = this.PresetFrameId,
			StickerIds = this.PresetStickerIds.ToArray(),
			DecorationIds = this.PresetDecorationIds.ToArray()
		};
		Singleton<MotorcycleUiModelUtil>.Instance.LoadMotorByParam(param, null);
	}

	// Token: 0x06010FEC RID: 69612 RVA: 0x004A98E4 File Offset: 0x004A7AE4
	private void RefreshStickerPresetInfo(MotorcycleDiyPresetData data)
	{
		List<int> list = data.StickerIds.ToList<int>();
		List<MotorcycleDiyEditStickerDecoItemData> list2 = new List<MotorcycleDiyEditStickerDecoItemData>();
		MotorSticker? motorSticker = null;
		for (int i = 0; i < list.Count; i++)
		{
			int num = list[i];
			if (num > 0)
			{
				motorSticker = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(num);
			}
			list2.Add(new MotorcycleDiyEditStickerDecoItemData
			{
				Part = i + 1,
				ItemId = num,
				QualityId = ((motorSticker != null) ? motorSticker.Value.QualityId : 0),
				SortIndex = ((motorSticker != null) ? motorSticker.Value.SortIndex : 0),
				IsSticker = true
			});
		}
		this.StickerScrollView.RefreshByData(list2, null, false);
		this.PresetStickerIds = list;
	}

	// Token: 0x06010FED RID: 69613 RVA: 0x004A99C4 File Offset: 0x004A7BC4
	private void RefreshDecorationPresetInfo(MotorcycleDiyPresetData data)
	{
		List<int> list = data.DecorateIds.ToList<int>();
		List<MotorcycleDiyEditStickerDecoItemData> list2 = new List<MotorcycleDiyEditStickerDecoItemData>();
		MotorDecorations? motorDecorations = null;
		for (int i = 0; i < list.Count; i++)
		{
			int num = list[i];
			if (num > 0)
			{
				motorDecorations = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(num);
			}
			list2.Add(new MotorcycleDiyEditStickerDecoItemData
			{
				Part = i + 1,
				ItemId = num,
				QualityId = ((motorDecorations != null) ? motorDecorations.Value.QualityId : 0),
				SortIndex = ((motorDecorations != null) ? motorDecorations.Value.SortIndex : 0),
				IsSticker = false
			});
		}
		this.DecorateScrollView.RefreshByData(list2, null, false);
		this.PresetDecorationIds = list;
	}

	// Token: 0x06010FEE RID: 69614 RVA: 0x004A9AA4 File Offset: 0x004A7CA4
	private void RefreshFramePresetInfo(MotorcycleDiyPresetData data)
	{
		if (data.FrameId > 0)
		{
			MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(data.FrameId);
			MotorFramePart? motorFramePartConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFramePartConfig();
			if (motorFramePartConfig != null && motorFrameConfig != null)
			{
				base.SetTextureByPath(motorFramePartConfig.Value.Icon, base.GetTexture(5), null, null);
				base.SetTextureByPath(motorFrameConfig.Value.ModelIconPath, base.GetTexture(6), null, null);
			}
		}
		this.PresetFrameId = data.FrameId;
	}

	// Token: 0x06010FEF RID: 69615 RVA: 0x004A9B44 File Offset: 0x004A7D44
	public void InitCameraInputData()
	{
		SUiRoleCameraSetting? roleCameraConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig("摩托车预设界面");
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
			DragComponent = base.GetDraggable(18),
			CameraSettingConfig = roleCameraConfig.Value,
			SourceLocation = fvectorDouble
		};
		this.CameraInputComponent.InitData(data);
	}

	// Token: 0x06010FF0 RID: 69616 RVA: 0x004A9BCC File Offset: 0x004A7DCC
	private void OnUpdateAllPresetInfo()
	{
		MotorcycleDiyPresetData curCustomPresetData = this.CurCustomPresetData;
		if (curCustomPresetData == null)
		{
			return;
		}
		if (curCustomPresetData.OfficialId != 0)
		{
			this.RefreshLeftPresetInfo(false, 0, false, true);
			return;
		}
		this.CustomPresetDataIndex = -1;
		MotorcycleDiyModel instance = ModelBase<MotorcycleDiyModel>.Instance;
		this.RefreshLeftPresetInfo(true, this.CustomPresetDataIndex, false, true);
		MotorcycleDiyPresetData data = this.BuildCurrentPresetData();
		MotorcycleDiyPresetItem curPresetItem = this.CurPresetItem;
		if (curPresetItem != null)
		{
			curPresetItem.RefreshPresetInfo(data);
		}
		MotorcycleDiyPresetItem curPresetItem2 = this.CurPresetItem;
		if (curPresetItem2 == null)
		{
			return;
		}
		curPresetItem2.SetToggleState(EToggleState.ETT_Checked, true);
	}

	// Token: 0x06010FF1 RID: 69617 RVA: 0x004A9C44 File Offset: 0x004A7E44
	private void OnTogCustomPresetClick(EToggleState toggleState)
	{
		UUIExtendToggle officialToggle = this.OfficialToggle;
		if (officialToggle != null)
		{
			officialToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		MotorcycleDiyPresetItem curPresetItem = this.CurPresetItem;
		if (curPresetItem != null)
		{
			curPresetItem.SetToggleState(EToggleState.ETT_Checked, true);
		}
		this.RefreshLeftPresetInfo(true, -1, true, true);
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequencePurely("Switch", false, false);
	}

	// Token: 0x06010FF2 RID: 69618 RVA: 0x004A9C9A File Offset: 0x004A7E9A
	private void OnTogOfficialPresetClick(EToggleState toggleState)
	{
		UUIExtendToggle customToggle = this.CustomToggle;
		if (customToggle != null)
		{
			customToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.RefreshLeftPresetInfo(false, 0, false, true);
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequencePurely("Switch", false, false);
	}

	// Token: 0x06010FF3 RID: 69619 RVA: 0x004A9CD4 File Offset: 0x004A7ED4
	private void OnTogEyeClick(EToggleState toggleState)
	{
		this.IsNotHidingUi = !this.IsNotHidingUi;
		base.GetItem(31).SetUIActive(this.IsNotHidingUi);
		if (this.IsNotHidingUi && Singleton<Info>.Instance.IsInGamepad())
		{
			UUIItem itemByIndex = this.PresetScrollView.GetItemByIndex(this.CustomPresetDataIndex);
			if (itemByIndex != null)
			{
				this.IsEyeActiveFromGamepad = true;
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(itemByIndex, true, true, true);
			}
		}
	}

	// Token: 0x06010FF4 RID: 69620 RVA: 0x004A9D44 File Offset: 0x004A7F44
	private void AutoSetSelectedFromPreset(MotorcycleDiyPresetData presetData)
	{
		MotorcycleDiyModel instance = ModelBase<MotorcycleDiyModel>.Instance;
		for (int i = 0; i < presetData.StickerIds.Length; i++)
		{
			instance.SetSelectStickerInfo(i + 1, presetData.StickerIds[i]);
		}
		for (int j = 0; j < presetData.DecorateIds.Length; j++)
		{
			instance.SetSelectDecorationInfo(j + 1, presetData.DecorateIds[j]);
		}
		instance.SetSelectFrame(presetData.FrameId);
	}

	// Token: 0x06010FF5 RID: 69621 RVA: 0x004A9DAC File Offset: 0x004A7FAC
	private void OnBtnCreatePresetClick()
	{
		if (this.TempCreatePresetData == null)
		{
			return;
		}
		this.AutoSetSelectedFromPreset(this.TempCreatePresetData);
		OpenMotorcycleDiyRootViewData param = new OpenMotorcycleDiyRootViewData
		{
			PartTabIndex = new int?(1),
			IsNeedResetMotor = new bool?(true),
			PresetData = this.TempCreatePresetData,
			CustomMode = new EMotorcycleDiyCustomMode?(EMotorcycleDiyCustomMode.NewCreate),
			OnNewCustomPresetCreated = delegate(int customPresetListIndex)
			{
				this.CustomPresetDataIndex = customPresetListIndex;
			}
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiyEditRootView, param, null);
	}

	// Token: 0x06010FF6 RID: 69622 RVA: 0x004A9E28 File Offset: 0x004A8028
	private void OnBtnDeletePresetClick()
	{
		if (this.CurCustomPresetData == null)
		{
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MotorDiyDeletePresetConfirm);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<MotorcycleDiyController>.Instance.DeleteMotorOutlookPresetRequest(this.CurCustomPresetData.CustomId, delegate
			{
				this.CustomPresetDataIndex--;
				if (ModelBase<MotorcycleDiyModel>.Instance.GetAllPresetDataList(true).Count > 0)
				{
					this.CustomPresetDataIndex = Math.Max(this.CustomPresetDataIndex, 0);
				}
				if (this.CustomPresetDataIndex < 0)
				{
					MotorcycleDiyPresetItem curPresetItem = this.CurPresetItem;
					if (curPresetItem != null)
					{
						curPresetItem.SetToggleState(EToggleState.ETT_Checked, true);
					}
				}
				this.RefreshLeftPresetInfo(true, this.CustomPresetDataIndex, true, false);
			});
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06010FF7 RID: 69623 RVA: 0x004A9E70 File Offset: 0x004A8070
	private void OnBtnEditPresetClick()
	{
		if (this.CurCustomPresetData != null)
		{
			this.AutoSetSelectedFromPreset(this.CurCustomPresetData);
		}
		OpenMotorcycleDiyRootViewData param = new OpenMotorcycleDiyRootViewData
		{
			PartTabIndex = new int?(1),
			IsNeedResetMotor = new bool?(true),
			PresetData = this.CurCustomPresetData,
			CustomMode = new EMotorcycleDiyCustomMode?(EMotorcycleDiyCustomMode.Edit)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiyEditRootView, param, null);
	}

	// Token: 0x06010FF8 RID: 69624 RVA: 0x004A9ED8 File Offset: 0x004A80D8
	private void OnBtnSaveToNewPresetClick()
	{
		ControllerBase<CommonInputViewController>.Instance.OpenMotorcycleDiyNameInputView(new Func<string, UniTask<Aki.Protocol.ErrorCode>>(this.OnConfirmRenameForCreate), this.DefaultCustomPresetName);
	}

	// Token: 0x06010FF9 RID: 69625 RVA: 0x004A9EF6 File Offset: 0x004A80F6
	private void OnBtnEditNameClick()
	{
		CommonInputViewController instance = ControllerBase<CommonInputViewController>.Instance;
		Func<string, UniTask<Aki.Protocol.ErrorCode>> callBack = new Func<string, UniTask<Aki.Protocol.ErrorCode>>(this.OnConfirmRenameForEdit);
		MotorcycleDiyPresetData curCustomPresetData = this.CurCustomPresetData;
		instance.OpenMotorcycleDiyNameInputView(callBack, ((curCustomPresetData != null) ? curCustomPresetData.Name : null) ?? string.Empty);
	}

	// Token: 0x06010FFA RID: 69626 RVA: 0x004A9F2C File Offset: 0x004A812C
	[NullableContext(0)]
	private UniTask<Aki.Protocol.ErrorCode> OnConfirmRenameForCreate([Nullable(1)] string input)
	{
		MotorcycleDiyImportPresetView.<OnConfirmRenameForCreate>d__53 <OnConfirmRenameForCreate>d__;
		<OnConfirmRenameForCreate>d__.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
		<OnConfirmRenameForCreate>d__.<>4__this = this;
		<OnConfirmRenameForCreate>d__.input = input;
		<OnConfirmRenameForCreate>d__.<>1__state = -1;
		<OnConfirmRenameForCreate>d__.<>t__builder.Start<MotorcycleDiyImportPresetView.<OnConfirmRenameForCreate>d__53>(ref <OnConfirmRenameForCreate>d__);
		return <OnConfirmRenameForCreate>d__.<>t__builder.Task;
	}

	// Token: 0x06010FFB RID: 69627 RVA: 0x004A9F78 File Offset: 0x004A8178
	[NullableContext(0)]
	private UniTask<Aki.Protocol.ErrorCode> OnConfirmRenameForEdit([Nullable(1)] string input)
	{
		MotorcycleDiyImportPresetView.<OnConfirmRenameForEdit>d__54 <OnConfirmRenameForEdit>d__;
		<OnConfirmRenameForEdit>d__.<>t__builder = AsyncUniTaskMethodBuilder<Aki.Protocol.ErrorCode>.Create();
		<OnConfirmRenameForEdit>d__.<>4__this = this;
		<OnConfirmRenameForEdit>d__.input = input;
		<OnConfirmRenameForEdit>d__.<>1__state = -1;
		<OnConfirmRenameForEdit>d__.<>t__builder.Start<MotorcycleDiyImportPresetView.<OnConfirmRenameForEdit>d__54>(ref <OnConfirmRenameForEdit>d__);
		return <OnConfirmRenameForEdit>d__.<>t__builder.Task;
	}

	// Token: 0x06010FFC RID: 69628 RVA: 0x004A9FC4 File Offset: 0x004A81C4
	private void OnBtnImportPresetClick()
	{
		bool flag = this.PresetFrameId == ModelBase<MotorcycleDiyModel>.Instance.GetEquippedFrameId();
		if (ModelBase<MotorcycleDiyModel>.Instance.IsEquipFrameLockedByPlayer() && !flag)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorDIYWarning02", Array.Empty<object>());
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.MotorcycleDiyImportConfirm);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<MotorcycleDiyController>.Instance.EquipMotorOutLookRequest(this.PresetStickerIds, this.PresetDecorationIds, this.PresetFrameId, delegate
			{
				this.AutoSetSelectedFromPreset(new MotorcycleDiyPresetData
				{
					FrameId = this.PresetFrameId,
					StickerIds = this.PresetStickerIds.ToArray(),
					DecorateIds = this.PresetDecorationIds.ToArray()
				});
				if (this.CurCustomPresetData != null)
				{
					MotorcycleDiyPresetItem curPresetItem = this.CurPresetItem;
					if (curPresetItem != null)
					{
						curPresetItem.RefreshPresetInfo(this.CurCustomPresetData);
					}
				}
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorDIYTips02", Array.Empty<object>());
				base.CloseMe(null);
			});
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06010FFD RID: 69629 RVA: 0x004AA037 File Offset: 0x004A8237
	private void OnCloseClick()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.LoadEquippedMotor(delegate(UiModelBase _)
		{
			base.CloseMe(null);
		});
	}

	// Token: 0x06010FFE RID: 69630 RVA: 0x004AA050 File Offset: 0x004A8250
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (!(configParams[0] == "Preset"))
		{
			return null;
		}
		int num;
		int id = int.TryParse(configParams[1], out num) ? num : int.MinValue;
		GenericLayout<MotorcycleDiyPresetItem, MotorcycleDiyPresetData> genericLayout = this.PresetScrollView.GetGenericLayout();
		IReadOnlyList<MotorcycleDiyPresetData> readOnlyList = (genericLayout != null) ? genericLayout.GetDatas() : null;
		if (readOnlyList == null)
		{
			return null;
		}
		int displayIndex = readOnlyList.ToList<MotorcycleDiyPresetData>().FindIndex((MotorcycleDiyPresetData data) => data.OfficialId == id);
		GenericLayout<MotorcycleDiyPresetItem, MotorcycleDiyPresetData> genericLayout2 = this.PresetScrollView.GetGenericLayout();
		UUIItem uuiitem = (genericLayout2 != null) ? genericLayout2.GetGridByDisplayIndex(displayIndex) : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x040085B7 RID: 34231
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x040085B8 RID: 34232
	[Nullable(2)]
	private MotorcycleDiyPresetItem CurPresetItem;

	// Token: 0x040085B9 RID: 34233
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<MotorcycleDiyPresetItem, MotorcycleDiyPresetData> PresetScrollView;

	// Token: 0x040085BA RID: 34234
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<MotorcycleDiyPresetStickerItem, MotorcycleDiyEditStickerDecoItemData> StickerScrollView;

	// Token: 0x040085BB RID: 34235
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<MotorcycleDiyPresetDecorationItem, MotorcycleDiyEditStickerDecoItemData> DecorateScrollView;

	// Token: 0x040085BC RID: 34236
	[Nullable(2)]
	private UUIExtendToggle CustomToggle;

	// Token: 0x040085BD RID: 34237
	[Nullable(2)]
	private UUIExtendToggle OfficialToggle;

	// Token: 0x040085BE RID: 34238
	[Nullable(2)]
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x040085BF RID: 34239
	[Nullable(2)]
	private UUIInturnAnimController AnimController;

	// Token: 0x040085C0 RID: 34240
	public UiCameraInputComponent CameraInputComponent = new UiCameraInputComponent();

	// Token: 0x040085C1 RID: 34241
	private List<int> PresetStickerIds = new List<int>();

	// Token: 0x040085C2 RID: 34242
	private List<int> PresetDecorationIds = new List<int>();

	// Token: 0x040085C3 RID: 34243
	private int PresetFrameId;

	// Token: 0x040085C4 RID: 34244
	[Nullable(2)]
	private MotorcycleDiyPresetData CurCustomPresetData;

	// Token: 0x040085C5 RID: 34245
	[Nullable(2)]
	private MotorcycleDiyPresetData TempCreatePresetData;

	// Token: 0x040085C6 RID: 34246
	private int CustomPresetDataIndex = -1;

	// Token: 0x040085C7 RID: 34247
	private string DefaultCustomPresetName = string.Empty;

	// Token: 0x040085C8 RID: 34248
	private int MaxCustomPresetNum;

	// Token: 0x040085C9 RID: 34249
	private bool IsNotHidingUi = true;

	// Token: 0x040085CA RID: 34250
	private bool IsEyeActiveFromGamepad;

	// Token: 0x040085CB RID: 34251
	private readonly int[] TwoBtnWidthAndOffsetX = new int[]
	{
		830,
		-490
	};

	// Token: 0x040085CC RID: 34252
	private readonly int[] OneBtnWidthAndOffsetX = new int[]
	{
		637,
		-390
	};

	// Token: 0x020085F4 RID: 34292
	[NullableContext(0)]
	private class EMotorDiyPresetComponent
	{
		// Token: 0x0402D4F0 RID: 185584
		public const int CurPresetItem = 0;

		// Token: 0x0402D4F1 RID: 185585
		public const int PresetScroll = 1;

		// Token: 0x0402D4F2 RID: 185586
		public const int PresetContent = 2;

		// Token: 0x0402D4F3 RID: 185587
		public const int PresetToggle = 3;

		// Token: 0x0402D4F4 RID: 185588
		public const int PresetTipsItem = 4;

		// Token: 0x0402D4F5 RID: 185589
		public const int TexFramePartIcon = 5;

		// Token: 0x0402D4F6 RID: 185590
		public const int TexFrameIcon = 6;

		// Token: 0x0402D4F7 RID: 185591
		public const int StickerScroll = 7;

		// Token: 0x0402D4F8 RID: 185592
		public const int StickerContent = 8;

		// Token: 0x0402D4F9 RID: 185593
		public const int StickerItem = 9;

		// Token: 0x0402D4FA RID: 185594
		public const int DecorateScroll = 10;

		// Token: 0x0402D4FB RID: 185595
		public const int DecorateContent = 11;

		// Token: 0x0402D4FC RID: 185596
		public const int DecorateItem = 12;

		// Token: 0x0402D4FD RID: 185597
		public const int BtnImportPreset = 13;

		// Token: 0x0402D4FE RID: 185598
		public const int CaptionItem = 14;

		// Token: 0x0402D4FF RID: 185599
		public const int PnlFrame = 15;

		// Token: 0x0402D500 RID: 185600
		public const int PnlSticker = 16;

		// Token: 0x0402D501 RID: 185601
		public const int PnlDecorate = 17;

		// Token: 0x0402D502 RID: 185602
		public const int DragComponent = 18;

		// Token: 0x0402D503 RID: 185603
		public const int TogCustomPreset = 19;

		// Token: 0x0402D504 RID: 185604
		public const int TogOfficialPreset = 20;

		// Token: 0x0402D505 RID: 185605
		public const int TxtPresetCount = 21;

		// Token: 0x0402D506 RID: 185606
		public const int PnlEmpty = 22;

		// Token: 0x0402D507 RID: 185607
		public const int BtnCreatePreset = 23;

		// Token: 0x0402D508 RID: 185608
		public const int TogEye = 24;

		// Token: 0x0402D509 RID: 185609
		public const int BtnEditName = 25;

		// Token: 0x0402D50A RID: 185610
		public const int RightBottomBtnLayout = 26;

		// Token: 0x0402D50B RID: 185611
		public const int BtnDeletePreset = 27;

		// Token: 0x0402D50C RID: 185612
		public const int BtnEditPreset = 28;

		// Token: 0x0402D50D RID: 185613
		public const int BtnSaveNewPreset = 29;

		// Token: 0x0402D50E RID: 185614
		public const int PnlMaxTips = 30;

		// Token: 0x0402D50F RID: 185615
		public const int NotHideUIItem = 31;

		// Token: 0x0402D510 RID: 185616
		public const int CurUsePresetName = 32;

		// Token: 0x0402D511 RID: 185617
		public const int PnlCurPreset = 33;

		// Token: 0x0402D512 RID: 185618
		public const int PnlPresetCount = 34;
	}
}
