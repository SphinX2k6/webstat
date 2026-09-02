using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Ornament;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A37 RID: 10807
[NullableContext(1)]
[Nullable(0)]
public class RoleOrnamentShowView : UiTickViewBase
{
	// Token: 0x17001C07 RID: 7175
	// (get) Token: 0x060159E4 RID: 88548 RVA: 0x005FEE07 File Offset: 0x005FD007
	private bool IsBuyPreview
	{
		get
		{
			return this.ShopRoleOrnamentData != null;
		}
	}

	// Token: 0x060159E5 RID: 88549 RVA: 0x005FEE12 File Offset: 0x005FD012
	public RoleOrnamentShowView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060159E6 RID: 88550 RVA: 0x005FEE28 File Offset: 0x005FD028
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
			new ValueTuple<int, Type>(45, typeof(UUIItem)),
			new ValueTuple<int, Type>(46, typeof(UUIItem)),
			new ValueTuple<int, Type>(51, typeof(UUIItem)),
			new ValueTuple<int, Type>(52, typeof(UUIItem)),
			new ValueTuple<int, Type>(53, typeof(UUIItem)),
			new ValueTuple<int, Type>(54, typeof(UUIItem)),
			new ValueTuple<int, Type>(55, typeof(UUITexture)),
			new ValueTuple<int, Type>(56, typeof(UUIItem)),
			new ValueTuple<int, Type>(57, typeof(UUIText)),
			new ValueTuple<int, Type>(58, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickOnlyUiToggle)),
			new ValueTuple<int, Delegate>(17, new Action(this.OnClickBuyButton))
		};
	}

	// Token: 0x060159E7 RID: 88551 RVA: 0x005FF2C4 File Offset: 0x005FD4C4
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Add(EEventName.PayShopGoodsBuy, new Action(this.OnPayShopGoodsBuy));
		Singleton<EventSystem>.Instance.Add(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x060159E8 RID: 88552 RVA: 0x005FF328 File Offset: 0x005FD528
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Remove(EEventName.PayShopGoodsBuy, new Action(this.OnPayShopGoodsBuy));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x060159E9 RID: 88553 RVA: 0x005FF38C File Offset: 0x005FD58C
	protected override UniTask OnHandlePostLoadSceneAsync(bool isSceneLoad)
	{
		RoleOrnamentShowView.<OnHandlePostLoadSceneAsync>d__19 <OnHandlePostLoadSceneAsync>d__;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnHandlePostLoadSceneAsync>d__.<>4__this = this;
		<OnHandlePostLoadSceneAsync>d__.<>1__state = -1;
		<OnHandlePostLoadSceneAsync>d__.<>t__builder.Start<RoleOrnamentShowView.<OnHandlePostLoadSceneAsync>d__19>(ref <OnHandlePostLoadSceneAsync>d__);
		return <OnHandlePostLoadSceneAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060159EA RID: 88554 RVA: 0x005FF3D0 File Offset: 0x005FD5D0
	protected override void OnStart()
	{
		this.InitData();
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnCloseView));
		this.CaptionItem.SetTitleLocalText("UiDynamicTab_222_TabName");
		this.CaptionItem.SetTitleIcon("/Game/Aki/UI/UIResources/Common/Atlas/TabIcon/SP_IconRoleAccessoriesSkin.SP_IconRoleAccessoriesSkin");
		bool isBuyPreview = this.IsBuyPreview;
		this.CaptionItem.SetHelpBtnActive(isBuyPreview);
		this.CaptionItem.SetHomeBtnShowState(isBuyPreview);
		if (isBuyPreview)
		{
			this.CaptionItem.SetHelpCallBack(new Action(this.OnClickedHelpButton));
		}
		base.GetItem(7).SetUIActive(false);
		base.GetItem(25).SetUIActive(false);
		base.GetItem(13).SetUIActive(false);
		base.GetButton(2).RootUIComp.Get().SetUIActive(false);
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
		UUIItem item3 = base.GetItem(54);
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		UUIButtonComponent button = base.GetButton(3);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		UUIButtonComponent button2 = base.GetButton(4);
		if (button2 != null)
		{
			button2.RootUIComp.Get().SetUIActive(false);
		}
		UUIItem item4 = base.GetItem(51);
		if (item4 != null)
		{
			item4.SetUIActive(false);
		}
		base.GetItem(9).SetUIActive(false);
		base.GetTexture(55).SetUIActive(true);
		base.GetItem(56).SetUIActive(false);
		base.GetText(16).SetUIActive(false);
		base.GetItem(27).SetUIActive(false);
		base.GetButton(17).RootUIComp.Get().SetUIActive(false);
		this.ExtraRewardLayout = new GenericLayout<SkinRewardItemGrid, SkinRewardData>(base.GetHorizontalLayout(10), new Func<SkinRewardItemGrid>(this.InitExtraRewardGridItem), null, false, true);
	}

	// Token: 0x060159EB RID: 88555 RVA: 0x005FF5BB File Offset: 0x005FD7BB
	private SkinRewardItemGrid InitExtraRewardGridItem()
	{
		return new SkinRewardItemGrid();
	}

	// Token: 0x060159EC RID: 88556 RVA: 0x005FF5C4 File Offset: 0x005FD7C4
	protected override void OnBeforeDestroy()
	{
		if (this.TsUiSceneRoleActor != null)
		{
			UiModelBase model = this.TsUiSceneRoleActor.Model;
			if (model != null)
			{
				UiModelUtil.RefreshRoleOrnaments(model, null, true);
			}
			Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.TsUiSceneRoleActor);
		}
		this.TsUiSceneRoleActor = null;
	}

	// Token: 0x060159ED RID: 88557 RVA: 0x005FF608 File Offset: 0x005FD808
	protected override void OnHandleReleaseScene()
	{
		UiCameraManager.Get().DestroyUiCameraComponent(typeof(UiCameraControlRotationComponent));
	}

	// Token: 0x060159EE RID: 88558 RVA: 0x005FF620 File Offset: 0x005FD820
	protected override void OnBeforeShow()
	{
		TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
		if (((tsUiSceneRoleActor != null) ? tsUiSceneRoleActor.Model : null) != null)
		{
			Singleton<UiModelUtil>.Instance.SetVisible(this.TsUiSceneRoleActor.Model, true);
		}
		this.TryPushCamera(false);
		this.RefreshView();
		this.CameraInputComponent.Start();
		this.CameraInputComponent.TryActivate();
		this.TryPlayRoleMontage();
	}

	// Token: 0x060159EF RID: 88559 RVA: 0x005FF682 File Offset: 0x005FD882
	protected override void OnAfterHide()
	{
		TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
		if (((tsUiSceneRoleActor != null) ? tsUiSceneRoleActor.Model : null) != null)
		{
			Singleton<UiModelUtil>.Instance.SetVisible(this.TsUiSceneRoleActor.Model, false);
		}
	}

	// Token: 0x060159F0 RID: 88560 RVA: 0x005FF6AF File Offset: 0x005FD8AF
	protected override void OnBeforeHide()
	{
		this.CameraInputComponent.End();
	}

	// Token: 0x060159F1 RID: 88561 RVA: 0x005FF6BC File Offset: 0x005FD8BC
	private void InitData()
	{
		RoleOrnamentShowViewParams roleOrnamentShowViewParams = (RoleOrnamentShowViewParams)this.OpenParam;
		this.OrnamentId = roleOrnamentShowViewParams.OrnamentId;
		this.ShopRoleOrnamentData = roleOrnamentShowViewParams.BuyDetailData;
		int? skinId = roleOrnamentShowViewParams.SkinId;
		if (skinId != null)
		{
			this.SkinId = skinId.Value;
		}
		else
		{
			foreach (int num in ModelBase<RoleOrnamentModel>.Instance.GetRoleOrnamentData(this.OrnamentId).GetRoleSkinIds())
			{
				int roleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(num).GetRoleId();
				if (!ModelBase<RoleModel>.Instance.IsMainRole(roleId))
				{
					skinId = new int?(num);
					break;
				}
				int num2 = roleId;
				int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
				if (num2 == curSelectMainRoleId.GetValueOrDefault() & curSelectMainRoleId != null)
				{
					skinId = new int?(num);
					break;
				}
			}
			int[] roleSkinIds;
			this.SkinId = (skinId ?? roleSkinIds[0]);
		}
		this.ResolvedRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(this.SkinId).GetRoleId();
		if (roleOrnamentShowViewParams.SkinId == null && Singleton<UiSceneManager>.Instance.HasRoleSystemRoleActor())
		{
			TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
			UiRoleDataComponent uiRoleDataComponent;
			if (roleSystemRoleActor == null)
			{
				uiRoleDataComponent = null;
			}
			else
			{
				UiModelBase model = roleSystemRoleActor.Model;
				uiRoleDataComponent = ((model != null) ? model.CheckGetComponent<UiRoleDataComponent>() : null);
			}
			UiRoleDataComponent uiRoleDataComponent2 = uiRoleDataComponent;
			if (uiRoleDataComponent2 != null && uiRoleDataComponent2.RoleConfigId == this.ResolvedRoleId)
			{
				this.SkinId = uiRoleDataComponent2.RoleSkinId;
			}
		}
	}

	// Token: 0x060159F2 RID: 88562 RVA: 0x005FF828 File Offset: 0x005FDA28
	private void TryPushCamera(bool useBlend = true)
	{
		Ornament? ornamentConfig = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(this.OrnamentId);
		if (ornamentConfig == null)
		{
			return;
		}
		Ornament value = ornamentConfig.Value;
		RoleSkin? roleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(this.SkinId);
		if (roleSkinConfig == null)
		{
			return;
		}
		RoleSkin value2 = roleSkinConfig.Value;
		string text;
		if (this.IsHidingUi())
		{
			if (!ModelBase<RoleModel>.Instance.IsMainRole(value2.RoleId))
			{
				text = (value.HideUiCamera(0) ?? string.Empty);
			}
			else
			{
				text = ((ConfigBase<RoleConfig>.Instance.GetMainRoleById(value2.RoleId).Value.Gender == 1) ? (value.HideUiCamera(0) ?? string.Empty) : (value.HideUiCamera(1) ?? string.Empty));
			}
		}
		else if (!ModelBase<RoleModel>.Instance.IsMainRole(value2.RoleId))
		{
			text = (value.UiCamera(0) ?? string.Empty);
		}
		else
		{
			text = ((ConfigBase<RoleConfig>.Instance.GetMainRoleById(value2.RoleId).Value.Gender == 1) ? (value.UiCamera(0) ?? string.Empty) : (value.UiCamera(1) ?? string.Empty));
		}
		string viewName = "RoleOrnamentShowView";
		UiCameraHandleData uiCameraHandleData = UiCameraHandleData.NewByHandleName(text, null);
		uiCameraHandleData.ViewName = text;
		uiCameraHandleData.OwnerViewName = viewName;
		if (useBlend)
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer(viewName, true);
			Singleton<UiCameraAnimationManager>.Instance.PushCameraHandle(uiCameraHandleData, true, true, "1001", true, delegate(UiCameraAnimationDefine.IFinishData _)
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer(viewName, false);
			});
			return;
		}
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandle(uiCameraHandleData, false, false, null, false, null);
	}

	// Token: 0x060159F3 RID: 88563 RVA: 0x005FF9F4 File Offset: 0x005FDBF4
	private IUiCameraInputComponentData GetCameraInputData()
	{
		Ornament value = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(this.OrnamentId).Value;
		string text = this.IsHidingUi() ? value.HideUiCameraConfig : value.UiCameraConfig;
		if (string.IsNullOrEmpty(text))
		{
			text = ConfigBase<PayShopConfig>.Instance.GetBuySkinDetailRoleCameraConfigId();
		}
		string text2 = this.IsHidingUi() ? value.HideUiCameraOffsetConfig : value.UiCameraOffsetConfig;
		SUiRoleCameraSetting value2 = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig(text).Value;
		SUiRoleCameraOffsetSetting? cameraOffsetConfig = null;
		if (!string.IsNullOrEmpty(text2))
		{
			SUiRoleCameraOffsetSetting? roleCameraOffsetConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraOffsetConfig(text2);
			if (roleCameraOffsetConfig != null)
			{
				cameraOffsetConfig = new SUiRoleCameraOffsetSetting?(roleCameraOffsetConfig.Value);
			}
		}
		FVectorDouble fvectorDouble = this.TsUiSceneRoleActor.D_K2_GetActorLocation();
		return new UiCameraInputComponentData
		{
			DragComponent = base.GetDraggable(29),
			CameraSettingConfig = value2,
			CameraOffsetConfig = cameraOffsetConfig,
			SourceLocation = fvectorDouble
		};
	}

	// Token: 0x060159F4 RID: 88564 RVA: 0x005FFAE8 File Offset: 0x005FDCE8
	private void InitCameraInputData()
	{
		IUiCameraInputComponentData cameraInputData = this.GetCameraInputData();
		this.CameraInputComponent.InitData(cameraInputData);
		this.CameraInputComponent.CanCameraInput = this.IsAllowCameraRotate();
	}

	// Token: 0x060159F5 RID: 88565 RVA: 0x005FFB1C File Offset: 0x005FDD1C
	private void UpdateCameraInputData()
	{
		IUiCameraInputComponentData cameraInputData = this.GetCameraInputData();
		this.CameraInputComponent.UpdateData(cameraInputData);
		this.CameraInputComponent.CanCameraInput = this.IsAllowCameraRotate();
	}

	// Token: 0x060159F6 RID: 88566 RVA: 0x005FFB50 File Offset: 0x005FDD50
	private void RefreshView()
	{
		if (this.OrnamentId == 0)
		{
			return;
		}
		ShopRoleOrnamentData shopRoleOrnamentData = this.ShopRoleOrnamentData;
		if (shopRoleOrnamentData != null)
		{
			PayShopGoods payShopGoods = shopRoleOrnamentData.GetPayShopGoods();
			if (payShopGoods != null)
			{
				payShopGoods.SaveRemindState((long)Singleton<TimeUtil>.Instance.GetServerTime());
			}
		}
		RoleOrnamentData roleOrnamentData = ModelBase<RoleOrnamentModel>.Instance.GetRoleOrnamentData(this.OrnamentId);
		base.GetItem(33).SetUIActive(false);
		base.GetItem(32).SetUIActive(false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), roleOrnamentData.GetName(), Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), roleOrnamentData.GetSubTitle(), Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), roleOrnamentData.GetBgDescription(), Array.Empty<object>());
		base.SetTextureByPath(roleOrnamentData.GetPreviewTextureInBuyView(), base.GetTexture(23), null, null);
		base.SetTextureByPath(roleOrnamentData.GetBuyPreviewQualityBgPath(), base.GetTexture(22), null, null);
		base.GetItem(18).SetUIActive(false);
		base.GetItem(20).SetUIActive(false);
		this.RefreshBuyPart();
		this.RefreshExtraReward();
		this.RefreshSellCountDown();
	}

	// Token: 0x060159F7 RID: 88567 RVA: 0x005FFC7C File Offset: 0x005FDE7C
	private void RefreshExtraReward()
	{
		ShopRoleOrnamentData shopRoleOrnamentData = this.ShopRoleOrnamentData;
		List<ValueTuple<int, int>> list = (shopRoleOrnamentData != null) ? shopRoleOrnamentData.GetOtherRewardSimple() : null;
		List<SkinRewardData> list2 = new List<SkinRewardData>();
		if (list != null)
		{
			foreach (ValueTuple<int, int> valueTuple in list)
			{
				list2.Add(new SkinRewardData
				{
					ItemData = new TItem?(new TItem(new InventoryDefine.GetItemData(valueTuple.Item1, 0), valueTuple.Item2)),
					FinishState = (shopRoleOrnamentData != null && !shopRoleOrnamentData.GetIfCanBuy())
				});
			}
		}
		bool flag = list2.Count != 0;
		GenericLayout<SkinRewardItemGrid, SkinRewardData> extraRewardLayout = this.ExtraRewardLayout;
		if (extraRewardLayout != null)
		{
			extraRewardLayout.SetActive(flag);
		}
		base.GetItem(9).SetUIActive(flag);
		if (!flag)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(50), "PrefabTextitem_RoleSkinExtraAcquisition_Text", Array.Empty<object>());
		GenericLayout<SkinRewardItemGrid, SkinRewardData> extraRewardLayout2 = this.ExtraRewardLayout;
		if (extraRewardLayout2 == null)
		{
			return;
		}
		extraRewardLayout2.RefreshByData(list2, null, false);
	}

	// Token: 0x060159F8 RID: 88568 RVA: 0x005FFD8C File Offset: 0x005FDF8C
	private void RefreshSellCountDown()
	{
		UUIItem item = base.GetItem(56);
		UUIText text = base.GetText(57);
		ShopRoleOrnamentData shopRoleOrnamentData = this.ShopRoleOrnamentData;
		if (shopRoleOrnamentData == null)
		{
			item.SetUIActive(false);
			return;
		}
		PayShopGoods currentGoodsData = shopRoleOrnamentData.GetCurrentGoodsData();
		if (currentGoodsData.HasDiscount() || !currentGoodsData.InUnPermanentSellTime())
		{
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		text.SetUIActive(true);
		CommonDefine.IPayShowCountDownRemainTime endTimeRemainData = currentGoodsData.GetEndTimeRemainData();
		CommonDefine.PayShowCountDownRemainTime<string> payShowCountDownRemainTime = endTimeRemainData as CommonDefine.PayShowCountDownRemainTime<string>;
		if (payShowCountDownRemainTime != null)
		{
			text.SetText(payShowCountDownRemainTime.Value, true);
			return;
		}
		CommonDefine.IRemainTime remainTime = endTimeRemainData as CommonDefine.IRemainTime;
		if (remainTime != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(text, remainTime.TextId, new <>z__ReadOnlySingleElementList<object>(remainTime.TimeValue));
		}
	}

	// Token: 0x060159F9 RID: 88569 RVA: 0x005FFE40 File Offset: 0x005FE040
	private void RefreshOrnamentModel()
	{
		if (base.IsDestroyOrDestroying || this.TsUiSceneRoleActor == null)
		{
			return;
		}
		OrnamentModelContext[] contexts = new OrnamentModelContext[]
		{
			UiModelUtil.BuildOrnamentModelContext(this.SkinId, this.OrnamentId)
		};
		UiModelBase model = this.TsUiSceneRoleActor.Model;
		if (model == null)
		{
			return;
		}
		UiRoleOrnamentComponent uiRoleOrnamentComponent = model.CheckGetComponent<UiRoleOrnamentComponent>();
		if (uiRoleOrnamentComponent == null)
		{
			return;
		}
		uiRoleOrnamentComponent.RefreshModels(contexts, false);
	}

	// Token: 0x060159FA RID: 88570 RVA: 0x005FFE9C File Offset: 0x005FE09C
	private bool IsAllowCameraRotate()
	{
		Ornament value = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(this.OrnamentId).Value;
		if (!this.IsHidingUi())
		{
			return value.AllowUiCameraRotate;
		}
		return value.AllowHideUiCameraRotate;
	}

	// Token: 0x060159FB RID: 88571 RVA: 0x005FFED9 File Offset: 0x005FE0D9
	private bool IsHidingUi()
	{
		return base.GetExtendToggle(1).GetToggleState() == EToggleState.ETT_Checked;
	}

	// Token: 0x060159FC RID: 88572 RVA: 0x005FFEEC File Offset: 0x005FE0EC
	private void TryPlayRoleMontage()
	{
		if (ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(this.OrnamentId).Value.UiRoleState == 0)
		{
			return;
		}
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Favor, false, false, false);
	}

	// Token: 0x060159FD RID: 88573 RVA: 0x005FFF2B File Offset: 0x005FE12B
	private void OnCloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x060159FE RID: 88574 RVA: 0x005FFF34 File Offset: 0x005FE134
	protected override void OnTick(float delta)
	{
		if (!this.IsBuyPreview)
		{
			return;
		}
		ShopRoleOrnamentData shopRoleOrnamentData = this.ShopRoleOrnamentData;
		PayShopGoods payShopGoods = (shopRoleOrnamentData != null) ? shopRoleOrnamentData.GetCurrentGoodsData() : null;
		if (payShopGoods == null)
		{
			return;
		}
		PayShopGoodsData goodsData = payShopGoods.GetGoodsData();
		int num = (goodsData != null) ? goodsData.Id : 0;
		bool flag = payShopGoods.HasDiscount();
		bool flag2 = payShopGoods.InSellTime();
		if (this.CurrentPayItemId != num)
		{
			this.CurrentPayItemId = num;
			this.CurrentDiscountState = flag;
			this.CurrentInSellTime = flag2;
		}
		if (this.CurrentDiscountState == flag && this.CurrentInSellTime == flag2)
		{
			return;
		}
		this.CurrentDiscountState = flag;
		this.CurrentInSellTime = flag2;
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PayShopRefresh);
		confirmBoxDataNew.FunctionMap[1] = delegate()
		{
			base.CloseMe(null);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x060159FF RID: 88575 RVA: 0x005FFFF4 File Offset: 0x005FE1F4
	private void OnClickOnlyUiToggle(EToggleState toggleState)
	{
		bool state = base.GetItem(28).bIsUIActive;
		if (!state)
		{
			base.GetItem(28).SetUIActive(!state);
			base.PlaySequence("UiIn", delegate
			{
			}, true);
		}
		else
		{
			base.PlaySequence("UiOut", delegate
			{
				if (this.IsDestroyOrDestroying)
				{
					return;
				}
				this.GetItem(28).SetUIActive(!state);
			}, true);
		}
		UUIItem item = base.GetItem(54);
		if (item != null)
		{
			item.SetUIActive(state);
		}
		this.TryPushCamera(true);
		this.UpdateCameraInputData();
	}

	// Token: 0x06015A00 RID: 88576 RVA: 0x006000AC File Offset: 0x005FE2AC
	private bool GetIfHaveRoleForCurrentOrnament()
	{
		RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(this.SkinId);
		int? num = (roleSkinData != null) ? new int?(roleSkinData.GetRoleId()) : null;
		return num == null || ModelBase<RoleModel>.Instance.GetRoleInstanceById(num.Value) != null;
	}

	// Token: 0x06015A01 RID: 88577 RVA: 0x00600102 File Offset: 0x005FE302
	private void StartBuyProcess(PayShopGoods goods)
	{
		if (goods.IfPayGift())
		{
			ControllerBase<PayGiftController>.Instance.SdkPay(goods.GetGoodsId());
			return;
		}
		ControllerBase<PayShopController>.Instance.OpenBuyViewByGoodsId(goods, null);
	}

	// Token: 0x06015A02 RID: 88578 RVA: 0x0060012C File Offset: 0x005FE32C
	[NullableContext(2)]
	private void RefreshBuyButtonState(ShopRoleOrnamentData data)
	{
		if (data == null)
		{
			base.GetButton(17).RootUIComp.Get().SetUIActive(false);
			return;
		}
		bool ifCanBuy = data.GetIfCanBuy();
		base.GetButton(17).RootUIComp.Get().SetUIActive(ifCanBuy);
	}

	// Token: 0x06015A03 RID: 88579 RVA: 0x0060017C File Offset: 0x005FE37C
	[NullableContext(2)]
	private void RefreshHaveItem(ShopRoleOrnamentData data)
	{
		if (data == null)
		{
			base.GetItem(27).SetUIActive(false);
			return;
		}
		bool ifCanBuy = data.GetIfCanBuy();
		base.GetItem(27).SetUIActive(!ifCanBuy);
	}

	// Token: 0x06015A04 RID: 88580 RVA: 0x006001B4 File Offset: 0x005FE3B4
	[NullableContext(2)]
	private void RefreshNotHaveRoleItem(ShopRoleOrnamentData data)
	{
		if (data == null)
		{
			base.GetItem(13).SetUIActive(false);
			return;
		}
		bool ifHaveRoleForCurrentOrnament = this.GetIfHaveRoleForCurrentOrnament();
		base.GetItem(13).SetUIActive(!ifHaveRoleForCurrentOrnament);
	}

	// Token: 0x06015A05 RID: 88581 RVA: 0x006001EC File Offset: 0x005FE3EC
	private void RefreshBuyItemIcon()
	{
		UUITexture texture = base.GetTexture(14);
		if (texture == null || this.ShopRoleOrnamentData == null)
		{
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
			return;
		}
		bool ifDirect = this.ShopRoleOrnamentData.GetIfDirect();
		texture.SetUIActive(!ifDirect);
		if (!ifDirect)
		{
			IPriceData priceData = this.ShopRoleOrnamentData.GetPriceData();
			base.SetItemIcon(texture, priceData.CurrencyId, null, null);
		}
	}

	// Token: 0x06015A06 RID: 88582 RVA: 0x00600254 File Offset: 0x005FE454
	private void RefreshBuyPart()
	{
		if (this.ShopRoleOrnamentData == null)
		{
			base.GetItem(51).SetUIActive(false);
			return;
		}
		bool ifCanBuy = this.ShopRoleOrnamentData.GetIfCanBuy();
		base.GetItem(51).SetUIActive(ifCanBuy);
		this.RefreshBuyItemIcon();
		bool ifDirect = this.ShopRoleOrnamentData.GetIfDirect();
		base.GetText(58).SetUIActive(ifDirect);
		base.GetText(15).SetUIActive(true);
		if (ifDirect)
		{
			string directPriceText = this.ShopRoleOrnamentData.GetDirectPriceText();
			base.GetText(15).SetText(directPriceText, true);
		}
		else
		{
			IPriceData priceData = this.ShopRoleOrnamentData.GetPriceData();
			base.GetText(15).SetText(priceData.NowPrice.ToString(), true);
		}
		this.RefreshBuyButtonState(this.ShopRoleOrnamentData);
		this.RefreshHaveItem(this.ShopRoleOrnamentData);
		this.RefreshNotHaveRoleItem(this.ShopRoleOrnamentData);
	}

	// Token: 0x06015A07 RID: 88583 RVA: 0x00600330 File Offset: 0x005FE530
	private void OnClickBuyButton()
	{
		ShopRoleOrnamentData shopRoleOrnamentData = this.ShopRoleOrnamentData;
		if (shopRoleOrnamentData == null || !shopRoleOrnamentData.GetIfCanBuy())
		{
			return;
		}
		PayShopGoods goods = shopRoleOrnamentData.GetPayShopGoods();
		goods.SaveRemindState((long)Singleton<TimeUtil>.Instance.GetServerTime());
		if (!this.GetIfHaveRoleForCurrentOrnament())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.NoRoleBuySkin);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.StartBuyProcess(goods);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		this.StartBuyProcess(goods);
	}

	// Token: 0x06015A08 RID: 88584 RVA: 0x006003C3 File Offset: 0x005FE5C3
	private void OnPayItemSuccess(PayItemSuccess notify)
	{
		this.RefreshView();
	}

	// Token: 0x06015A09 RID: 88585 RVA: 0x006003CB File Offset: 0x005FE5CB
	private void OnPayShopGoodsBuy()
	{
		this.RefreshView();
	}

	// Token: 0x06015A0A RID: 88586 RVA: 0x006003D4 File Offset: 0x005FE5D4
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
	{
		ShopRoleOrnamentData shopRoleOrnamentData = this.ShopRoleOrnamentData;
		int? num;
		if (shopRoleOrnamentData == null)
		{
			num = null;
		}
		else
		{
			PayShopGoods payShopGoods = shopRoleOrnamentData.GetPayShopGoods();
			num = ((payShopGoods != null) ? new int?(payShopGoods.GetGoodsId()) : null);
		}
		int? num2 = num;
		if (num2 != null)
		{
			int? num3 = num2;
			if (goodsId == num3.GetValueOrDefault() & num3 != null)
			{
				this.RefreshView();
				return;
			}
		}
	}

	// Token: 0x06015A0B RID: 88587 RVA: 0x0060043B File Offset: 0x005FE63B
	private void OnClickedHelpButton()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(627);
	}

	// Token: 0x0400A63B RID: 42555
	private const int SHOP_HELP_ID = 627;

	// Token: 0x0400A63C RID: 42556
	private int SkinId;

	// Token: 0x0400A63D RID: 42557
	private int OrnamentId;

	// Token: 0x0400A63E RID: 42558
	private int ResolvedRoleId;

	// Token: 0x0400A63F RID: 42559
	public UiCameraInputComponent CameraInputComponent = new UiCameraInputComponent();

	// Token: 0x0400A640 RID: 42560
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400A641 RID: 42561
	[Nullable(2)]
	private TsUiSceneRoleActor TsUiSceneRoleActor;

	// Token: 0x0400A642 RID: 42562
	[Nullable(2)]
	private ShopRoleOrnamentData ShopRoleOrnamentData;

	// Token: 0x0400A643 RID: 42563
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SkinRewardItemGrid, SkinRewardData> ExtraRewardLayout;

	// Token: 0x0400A644 RID: 42564
	private int CurrentPayItemId;

	// Token: 0x0400A645 RID: 42565
	private bool CurrentDiscountState;

	// Token: 0x0400A646 RID: 42566
	private bool CurrentInSellTime;

	// Token: 0x02008DB7 RID: 36279
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402FAE0 RID: 195296
		CaptionItem,
		// Token: 0x0402FAE1 RID: 195297
		OnlyUiToggle,
		// Token: 0x0402FAE2 RID: 195298
		DetailIconButton,
		// Token: 0x0402FAE3 RID: 195299
		ButtonLeft,
		// Token: 0x0402FAE4 RID: 195300
		ButtonRight,
		// Token: 0x0402FAE5 RID: 195301
		TitleText,
		// Token: 0x0402FAE6 RID: 195302
		SubTitleText,
		// Token: 0x0402FAE7 RID: 195303
		SwitchItem,
		// Token: 0x0402FAE8 RID: 195304
		ToggleLeft,
		// Token: 0x0402FAE9 RID: 195305
		ExtraRewardItem,
		// Token: 0x0402FAEA RID: 195306
		ExtraRewardContentHorizontalLayout,
		// Token: 0x0402FAEB RID: 195307
		RewardItem,
		// Token: 0x0402FAEC RID: 195308
		DescText,
		// Token: 0x0402FAED RID: 195309
		NotHaveRoleItem,
		// Token: 0x0402FAEE RID: 195310
		BuyItemIcon,
		// Token: 0x0402FAEF RID: 195311
		NowPrice,
		// Token: 0x0402FAF0 RID: 195312
		BeforePrice,
		// Token: 0x0402FAF1 RID: 195313
		BuyButton,
		// Token: 0x0402FAF2 RID: 195314
		DiscountItem,
		// Token: 0x0402FAF3 RID: 195315
		DiscountText,
		// Token: 0x0402FAF4 RID: 195316
		LeftTimeItem,
		// Token: 0x0402FAF5 RID: 195317
		LeftTimeText,
		// Token: 0x0402FAF6 RID: 195318
		QualityTexture,
		// Token: 0x0402FAF7 RID: 195319
		ItemTexture,
		// Token: 0x0402FAF8 RID: 195320
		FrameTexture,
		// Token: 0x0402FAF9 RID: 195321
		WeaponRootItem,
		// Token: 0x0402FAFA RID: 195322
		WeaponTexture,
		// Token: 0x0402FAFB RID: 195323
		HaveItem,
		// Token: 0x0402FAFC RID: 195324
		HideUiParentItem,
		// Token: 0x0402FAFD RID: 195325
		DragComponent,
		// Token: 0x0402FAFE RID: 195326
		WeaponQualityTexture,
		// Token: 0x0402FAFF RID: 195327
		ToggleRight,
		// Token: 0x0402FB00 RID: 195328
		EffectItemB,
		// Token: 0x0402FB01 RID: 195329
		EffectItemA,
		// Token: 0x0402FB02 RID: 195330
		TextureToggleLeft,
		// Token: 0x0402FB03 RID: 195331
		TextToggleLeft,
		// Token: 0x0402FB04 RID: 195332
		TextureToggleRight,
		// Token: 0x0402FB05 RID: 195333
		TextToggleRight,
		// Token: 0x0402FB06 RID: 195334
		ItemGamePadKeyTipA = 45,
		// Token: 0x0402FB07 RID: 195335
		ItemGamePadKeyTipB,
		// Token: 0x0402FB08 RID: 195336
		ToggleLayout,
		// Token: 0x0402FB09 RID: 195337
		ToggleMale,
		// Token: 0x0402FB0A RID: 195338
		ToggleFemale,
		// Token: 0x0402FB0B RID: 195339
		ExtraRewardText,
		// Token: 0x0402FB0C RID: 195340
		ItemBuyPanel,
		// Token: 0x0402FB0D RID: 195341
		ItemRolePanel,
		// Token: 0x0402FB0E RID: 195342
		ItemBottomLeftPanel,
		// Token: 0x0402FB0F RID: 195343
		ItemGamePadKeyTipC,
		// Token: 0x0402FB10 RID: 195344
		SpecialBgTexture,
		// Token: 0x0402FB11 RID: 195345
		ItemCountDownPanel,
		// Token: 0x0402FB12 RID: 195346
		TextCountDown,
		// Token: 0x0402FB13 RID: 195347
		TextDirectTips
	}
}
