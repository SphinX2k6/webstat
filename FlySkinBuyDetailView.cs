using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02002A30 RID: 10800
[NullableContext(1)]
[Nullable(0)]
public class FlySkinBuyDetailView : UiTickViewBase
{
	// Token: 0x06015975 RID: 88437 RVA: 0x005FB58D File Offset: 0x005F978D
	public FlySkinBuyDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015976 RID: 88438 RVA: 0x005FB5A8 File Offset: 0x005F97A8
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
			new ValueTuple<int, Type>(46, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickLeftButton)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickRightButton)),
			new ValueTuple<int, Delegate>(17, new Action(this.OnClickBuyButton)),
			new ValueTuple<int, Delegate>(8, new Action<EToggleState>(this.OnClickToggleLeft)),
			new ValueTuple<int, Delegate>(31, new Action<EToggleState>(this.OnClickToggleRight)),
			new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickOnlyUiToggle))
		};
	}

	// Token: 0x06015977 RID: 88439 RVA: 0x005FB9EC File Offset: 0x005F9BEC
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Add<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06015978 RID: 88440 RVA: 0x005FBA50 File Offset: 0x005F9C50
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x06015979 RID: 88441 RVA: 0x005FBAB4 File Offset: 0x005F9CB4
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnCloseView));
		this.ViewData = (this.OpenParam as FlySkinBuyDetailViewData);
		this.CaptionItem.SetTitleLocalText(this.ViewData.GetPreviewTitle());
		this.CaptionItem.SetTitleIconByResourceId("FlySkinShopTitle_Icon");
		this.CaptionItem.SetHelpBtnActive(true);
		this.CaptionItem.SetHelpCallBack(new Action(this.OnClickedHelpButton));
		this.ItemLayout = new GenericLayout<SkinRewardItemGrid, SkinRewardData>(base.GetHorizontalLayout(10), new Func<SkinRewardItemGrid>(this.InitGridItem), null, false, true);
		base.GetExtendToggle(8).CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
		base.GetExtendToggle(31).CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
		this.ResetCurrentFlySkinType();
		string stringConfig = ConfigCommonParamById.GetStringConfig("ShopPreviewGliderSkinIcon");
		string stringConfig2 = ConfigCommonParamById.GetStringConfig("ShopPreviewSoarWingSkinIcon");
		base.SetTextureByPath(stringConfig, base.GetTexture(34), null, null);
		base.SetTextureByPath(stringConfig2, base.GetTexture(36), null, null);
		string stringConfig3 = ConfigCommonParamById.GetStringConfig("ShopPreviewGliderSkinText");
		string stringConfig4 = ConfigCommonParamById.GetStringConfig("ShopPreviewSoarWingSkinText");
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(35), stringConfig3, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(37), stringConfig4, Array.Empty<object>());
		base.GetItem(7).SetUIActive(true);
		base.GetItem(25).SetUIActive(false);
		base.GetItem(13).SetUIActive(false);
		base.GetButton(2).RootUIComp.Get().SetUIActive(false);
		UUIItem item = base.GetItem(45);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(46);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0601597A RID: 88442 RVA: 0x005FBCA3 File Offset: 0x005F9EA3
	private SkinRewardItemGrid InitGridItem()
	{
		return new SkinRewardItemGrid();
	}

	// Token: 0x0601597B RID: 88443 RVA: 0x005FBCAA File Offset: 0x005F9EAA
	protected override void OnHandleLoadScene()
	{
		this.InitGliderObserver();
		this.InitCameraInputData();
	}

	// Token: 0x0601597C RID: 88444 RVA: 0x005FBCB8 File Offset: 0x005F9EB8
	private void InitGliderObserver()
	{
		Singleton<UiSceneManager>.Instance.InitGliderSkeletalHandle();
		SkeletalObserverHandle gliderSkeletalHandle = Singleton<UiSceneManager>.Instance.GetGliderSkeletalHandle();
		if (gliderSkeletalHandle == null)
		{
			return;
		}
		UiModelBase model = gliderSkeletalHandle.Model;
		UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		if (uiModelActorComponent != null)
		{
			uiModelActorComponent.SetTransformByTag(FlySkinDefine.DEFAULT_FLY_SKIN_CASE);
		}
		this.GliderObserver = gliderSkeletalHandle;
	}

	// Token: 0x0601597D RID: 88445 RVA: 0x005FBD08 File Offset: 0x005F9F08
	public void InitCameraInputData()
	{
		string rowName = "翱翔滑翔皮肤旋转查看";
		SUiRoleCameraSetting? roleCameraConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig(rowName);
		if (roleCameraConfig == null)
		{
			return;
		}
		SkeletalObserverHandle gliderObserver = this.GliderObserver;
		if (((gliderObserver != null) ? gliderObserver.Model : null) == null)
		{
			return;
		}
		AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName(FlySkinDefine.flySkinTypeToCase[this.CurrentFlySkinType]).Value, ECollectActorType.UI);
		if (actorWithTag == null)
		{
			return;
		}
		FVectorDouble fvectorDouble = actorWithTag.D_K2_GetActorLocation();
		UiCameraInputComponentData data = new UiCameraInputComponentData
		{
			DragComponent = base.GetDraggable(29),
			CameraSettingConfig = roleCameraConfig.Value,
			SourceLocation = fvectorDouble
		};
		this.CameraInputComponent.InitData(data);
		this.CameraInputComponent.CanCameraInput = false;
	}

	// Token: 0x0601597E RID: 88446 RVA: 0x005FBDBE File Offset: 0x005F9FBE
	protected override void OnBeforeShow()
	{
		this.CanPushCamera = true;
		this.TryPushCamera();
		this.TryLoadModel();
		this.RefreshView();
	}

	// Token: 0x0601597F RID: 88447 RVA: 0x005FBDDC File Offset: 0x005F9FDC
	private void RefreshView()
	{
		FlySkinBuyDetailViewData viewData = this.ViewData;
		ShopFlySkinData shopFlySkinData = (viewData != null) ? viewData.GetCurrentGoodsData() : null;
		FlySkinData flySkinData = (viewData != null) ? viewData.GetCurrentSkinData(this.CurrentFlySkinType) : null;
		if (viewData == null || shopFlySkinData == null || flySkinData == null)
		{
			return;
		}
		shopFlySkinData.GetCurrentGoodsData().SaveRemindState((long)Singleton<TimeUtil>.Instance.GetServerTime());
		bool uiactive = viewData != null && viewData.CheckIfHaveMutiGood();
		base.GetButton(4).RootUIComp.Get().SetUIActive(uiactive);
		base.GetButton(3).RootUIComp.Get().SetUIActive(uiactive);
		bool ifCanBuy = shopFlySkinData.GetIfCanBuy();
		base.GetText(15).SetUIActive(ifCanBuy);
		base.GetButton(17).RootUIComp.Get().SetUIActive(ifCanBuy);
		base.GetItem(27).SetUIActive(!ifCanBuy);
		bool uiactive2 = viewData.GetCurrentSkinData(this.CurrentFlySkinType).GetSkinGrade() == 1;
		base.GetItem(33).SetUIActive(uiactive2);
		base.GetItem(32).SetUIActive(uiactive2);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), flySkinData.GetTitleName(), Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), flySkinData.GetSubTitle(), Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), flySkinData.GetDesc(), Array.Empty<object>());
		base.SetTextureByPath(flySkinData.GetPreviewTextureInBuyView(), base.GetTexture(23), null, null);
		base.SetTextureByPath(flySkinData.GetBuyPreviewQualityBgPath(), base.GetTexture(22), null, null);
		string discountText = viewData.GetDiscountText();
		base.GetItem(18).SetUIActive(discountText != "");
		base.GetText(19).SetText(discountText, true);
		object discountTimeData = viewData.GetDiscountTimeData();
		if (discountTimeData == null)
		{
			base.GetItem(20).SetUIActive(false);
		}
		else
		{
			base.GetItem(20).SetUIActive(true);
			string text = discountTimeData as string;
			if (text != null)
			{
				UUIText text2 = base.GetText(21);
				if (text2 != null)
				{
					text2.SetText(text, true);
				}
			}
			else
			{
				CommonDefine.IRemainTime remainTime = discountTimeData as CommonDefine.IRemainTime;
				if (remainTime != null)
				{
					Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(21), remainTime.TextId, new <>z__ReadOnlySingleElementList<object>(remainTime.TimeValue));
				}
			}
		}
		bool ifDirect = viewData.GetIfDirect();
		IPriceData priceData = viewData.GetPriceData();
		base.GetTexture(14).SetUIActive(!ifDirect);
		if (ifDirect)
		{
			base.GetText(15).SetText(viewData.GetDirectPriceText(), true);
		}
		else if (priceData != null)
		{
			base.SetItemIcon(base.GetTexture(14), priceData.CurrencyId, null, null);
			base.GetText(15).SetText(priceData.NowPrice.ToString(), true);
		}
		int? num = (priceData != null) ? priceData.OriginalPrice : null;
		if (num == null || num.Value == 0)
		{
			base.GetText(16).SetUIActive(false);
		}
		else
		{
			base.GetText(16).SetUIActive(true);
			base.GetText(16).SetText("<s>" + num.Value.ToString() + "</s>", true);
		}
		base.GetExtendToggle(8).SetToggleState((this.CurrentFlySkinType == EFlySkinType.Paragliding) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		base.GetExtendToggle(31).SetToggleState((this.CurrentFlySkinType == EFlySkinType.SoarWing) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		this.RefreshExtraReward(this.ViewData);
	}

	// Token: 0x06015980 RID: 88448 RVA: 0x005FC174 File Offset: 0x005FA374
	[NullableContext(2)]
	private void RefreshExtraReward(FlySkinBuyDetailViewData data)
	{
		if (data == null)
		{
			return;
		}
		List<TItem> otherReward = data.GetCurrentGoodsData().GetOtherReward();
		List<SkinRewardData> list = new List<SkinRewardData>();
		foreach (TItem value in otherReward)
		{
			list.Add(new SkinRewardData
			{
				ItemData = new TItem?(value),
				FinishState = !data.GetCurrentGoodsData().GetIfCanBuy()
			});
		}
		GenericLayout<SkinRewardItemGrid, SkinRewardData> itemLayout = this.ItemLayout;
		if (itemLayout != null)
		{
			itemLayout.SetActive(list.Count != 0);
		}
		base.GetItem(9).SetUIActive(list.Count != 0);
		GenericLayout<SkinRewardItemGrid, SkinRewardData> itemLayout2 = this.ItemLayout;
		if (itemLayout2 == null)
		{
			return;
		}
		itemLayout2.RefreshByData(list, null, false);
	}

	// Token: 0x06015981 RID: 88449 RVA: 0x005FC240 File Offset: 0x005FA440
	protected override void OnAfterShow()
	{
		this.InitGliderObserver();
		this.CanPushCamera = true;
		this.TryPushCamera();
		this.TryLoadModel();
		this.CameraInputComponent.Start();
		this.CameraInputComponent.TryActivate();
	}

	// Token: 0x06015982 RID: 88450 RVA: 0x005FC274 File Offset: 0x005FA474
	private void TryPushCamera()
	{
		if (!this.CanPushCamera)
		{
			return;
		}
		string flySkinModelCameraId = ConfigBase<SkinConfig>.Instance.GetFlySkinModelCameraId(this.CurrentFlySkinType);
		this.WaitCameraId = flySkinModelCameraId;
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(flySkinModelCameraId, true, true, "10010", false, null, null);
	}

	// Token: 0x06015983 RID: 88451 RVA: 0x005FC2C0 File Offset: 0x005FA4C0
	public void TryLoadModel()
	{
		SkeletalObserverHandle gliderObserver = this.GliderObserver;
		UiModelBase uiModelBase = (gliderObserver != null) ? gliderObserver.Model : null;
		if (uiModelBase == null)
		{
			return;
		}
		string transformByTag = FlySkinDefine.flySkinTypeToCase[this.CurrentFlySkinType];
		if (!this.CanLoadModel)
		{
			Singleton<UiModelUtil>.Instance.SetVisible(uiModelBase, false);
			UiModelActorComponent uiModelActorComponent = uiModelBase.CheckGetComponent<UiModelActorComponent>();
			if (uiModelActorComponent == null)
			{
				return;
			}
			uiModelActorComponent.SetTransformByTag(transformByTag);
			return;
		}
		else
		{
			SkinConfig instance = ConfigBase<SkinConfig>.Instance;
			EFlySkinType currentFlySkinType = this.CurrentFlySkinType;
			FlySkinConfig flySkinConfig = this.ViewData.GetCurrentSkinData(currentFlySkinType).GetFlySkinConfig();
			string standAnimPath = flySkinConfig.StandAnim;
			string flySkinSpawnEffectId = instance.GetFlySkinSpawnEffectId(currentFlySkinType);
			string flySkinSpawnMaterialController = instance.GetFlySkinSpawnMaterialController(currentFlySkinType);
			string effectPath = EffectUtil.GetEffectPath(flySkinSpawnEffectId);
			string changeMaterialControllerPath = EffectUtil.GetEffectPath(flySkinSpawnMaterialController);
			List<string> extraResourceList = new List<string>
			{
				standAnimPath,
				effectPath,
				changeMaterialControllerPath
			};
			UiModelLoadComponent loadComponent = uiModelBase.CheckGetComponent<UiModelLoadComponent>();
			if (loadComponent == null)
			{
				return;
			}
			UiModelActorComponent uiModelActorComponent2 = uiModelBase.CheckGetComponent<UiModelActorComponent>();
			if (uiModelActorComponent2 != null)
			{
				uiModelActorComponent2.SetTransformByTag(transformByTag);
			}
			Action loadFinishCallBack = delegate()
			{
				SkeletalObserverHandle gliderObserver2 = this.GliderObserver;
				UiModelBase uiModelBase2 = (gliderObserver2 != null) ? gliderObserver2.Model : null;
				if (uiModelBase2 == null)
				{
					return;
				}
				Singleton<UiModelUtil>.Instance.SetVisible(uiModelBase2, true);
				UiModelLoadComponent loadComponent = loadComponent;
				UAnimationAsset uanimationAsset = ((loadComponent != null) ? loadComponent.GetLoadedResource(standAnimPath) : null) as UAnimationAsset;
				if (uanimationAsset == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.UiCommon, ELogAuthor.CXJ, "[FlySkin] 商城飞行皮肤待机动画预加载失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				UiModelAnimationComponent uiModelAnimationComponent = uiModelBase2.CheckGetComponent<UiModelAnimationComponent>();
				if (uanimationAsset != null && uiModelAnimationComponent != null)
				{
					uiModelAnimationComponent.PlayAnimation(uanimationAsset, true);
				}
				UiModelRenderingMaterialComponent uiModelRenderingMaterialComponent = uiModelBase2.CheckGetComponent<UiModelRenderingMaterialComponent>();
				PD_CharacterControllerData_C pd_CharacterControllerData_C = loadComponent.GetLoadedResource(changeMaterialControllerPath) as PD_CharacterControllerData_C;
				if (pd_CharacterControllerData_C != null && uiModelRenderingMaterialComponent != null)
				{
					uiModelRenderingMaterialComponent.AddRenderingMaterialByData(pd_CharacterControllerData_C);
				}
				Singleton<UiModelUtil>.Instance.PlayEffectOnRoot(uiModelBase2, "GliderEffect");
			};
			loadComponent.LoadModelByModelId(flySkinConfig.ModelId, true, loadFinishCallBack, extraResourceList);
			return;
		}
	}

	// Token: 0x06015984 RID: 88452 RVA: 0x005FC3F0 File Offset: 0x005FA5F0
	protected override void OnTick(float delta)
	{
		FlySkinBuyDetailViewData viewData = this.ViewData;
		PayShopGoods payShopGoods;
		if (viewData == null)
		{
			payShopGoods = null;
		}
		else
		{
			ShopFlySkinData currentGoodsData = viewData.GetCurrentGoodsData();
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

	// Token: 0x06015985 RID: 88453 RVA: 0x005FC4F9 File Offset: 0x005FA6F9
	protected override void OnBeforeHide()
	{
		UiCameraInputComponent cameraInputComponent = this.CameraInputComponent;
		if (cameraInputComponent == null)
		{
			return;
		}
		cameraInputComponent.End();
	}

	// Token: 0x06015986 RID: 88454 RVA: 0x005FC50B File Offset: 0x005FA70B
	protected override void OnBeforeDestroy()
	{
		UiCameraManager.Get().DestroyUiCameraComponent(typeof(UiCameraControlRotationComponent));
		this.DestroyGliderObserver();
	}

	// Token: 0x06015987 RID: 88455 RVA: 0x005FC527 File Offset: 0x005FA727
	private void DestroyGliderObserver()
	{
		Singleton<UiSceneManager>.Instance.DestroyGliderSkeletalHandle();
		this.GliderObserver = null;
	}

	// Token: 0x06015988 RID: 88456 RVA: 0x005FC53A File Offset: 0x005FA73A
	private void OnCloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x06015989 RID: 88457 RVA: 0x005FC543 File Offset: 0x005FA743
	private void OnClickToggleRight(EToggleState toggleState)
	{
		this.CurrentFlySkinType = EFlySkinType.SoarWing;
		base.GetExtendToggle(8).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.SwitchFlySkinType();
	}

	// Token: 0x0601598A RID: 88458 RVA: 0x005FC563 File Offset: 0x005FA763
	private void OnClickToggleLeft(EToggleState toggleState)
	{
		this.CurrentFlySkinType = EFlySkinType.Paragliding;
		base.GetExtendToggle(31).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.SwitchFlySkinType();
	}

	// Token: 0x0601598B RID: 88459 RVA: 0x005FC584 File Offset: 0x005FA784
	private void SwitchFlySkinType()
	{
		this.LastSwitchTime = 0.0;
		this.RefreshView();
		this.TryPushCamera();
		this.TryLoadModel();
		this.LastSwitchTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
	}

	// Token: 0x0601598C RID: 88460 RVA: 0x005FC5B8 File Offset: 0x005FA7B8
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
		UUIItem item = base.GetItem(46);
		if (item != null)
		{
			item.SetUIActive(state);
		}
		this.CameraInputComponent.CanCameraInput = state;
		this.TryPushCamera();
	}

	// Token: 0x0601598D RID: 88461 RVA: 0x005FC678 File Offset: 0x005FA878
	private void OnClickBuyButton()
	{
		ControllerBase<PayShopController>.Instance.OpenBuySkinDetailView(this.ViewData.GetCurrentGoodsData().GetCurrentGoodsData());
	}

	// Token: 0x0601598E RID: 88462 RVA: 0x005FC694 File Offset: 0x005FA894
	private void OnClickRightButton()
	{
		if (Singleton<TimeUtil>.Instance.GetServerTimeStamp() - this.LastClickButtonTime < (double)ConfigBase<SkinConfig>.Instance.GetSkinDetailButtonGap())
		{
			return;
		}
		this.ViewData.SwitchToNextGoods();
		this.SwitchFlySkin();
	}

	// Token: 0x0601598F RID: 88463 RVA: 0x005FC6C6 File Offset: 0x005FA8C6
	private void OnClickLeftButton()
	{
		if (Singleton<TimeUtil>.Instance.GetServerTimeStamp() - this.LastClickButtonTime < (double)ConfigBase<SkinConfig>.Instance.GetSkinDetailButtonGap())
		{
			return;
		}
		this.ViewData.SwitchToPreGoods();
		this.SwitchFlySkin();
	}

	// Token: 0x06015990 RID: 88464 RVA: 0x005FC6F8 File Offset: 0x005FA8F8
	private void SwitchFlySkin()
	{
		this.LastClickButtonTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		this.ResetCurrentFlySkinType();
		this.RefreshView();
		this.TryPushCamera();
		this.TryLoadModel();
		base.PlaySequence("Switch", null, true);
	}

	// Token: 0x06015991 RID: 88465 RVA: 0x005FC72F File Offset: 0x005FA92F
	private void ResetCurrentFlySkinType()
	{
		this.CurrentFlySkinType = EFlySkinType.Paragliding;
	}

	// Token: 0x06015992 RID: 88466 RVA: 0x005FC738 File Offset: 0x005FA938
	private void OnActivateUiCameraAnimationHandle(UiCameraHandleData handleData)
	{
		if (handleData.HandleName == this.WaitCameraId)
		{
			this.WaitCameraId = null;
			if (!this.CanLoadModel)
			{
				this.CanLoadModel = true;
				this.TryLoadModel();
			}
		}
	}

	// Token: 0x06015993 RID: 88467 RVA: 0x005FC769 File Offset: 0x005FA969
	private void OnClickedHelpButton()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(318);
	}

	// Token: 0x06015994 RID: 88468 RVA: 0x005FC77A File Offset: 0x005FA97A
	private void OnPayItemSuccess(PayItemSuccess notify)
	{
		this.RefreshView();
	}

	// Token: 0x06015995 RID: 88469 RVA: 0x005FC784 File Offset: 0x005FA984
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
	{
		ShopFlySkinData currentGoodsData = this.ViewData.GetCurrentGoodsData();
		int? num = (currentGoodsData != null) ? new int?(currentGoodsData.GetCurrentGoodsData().GetGoodsId()) : null;
		if (!(goodsId == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		this.RefreshView();
	}

	// Token: 0x06015996 RID: 88470 RVA: 0x005FC7D6 File Offset: 0x005FA9D6
	private bool CanToggleExecuteChange()
	{
		return Singleton<TimeUtil>.Instance.GetServerTimeStamp() - this.LastSwitchTime >= (double)ConfigBase<SkinConfig>.Instance.GetSkinDetailButtonSwitchGap();
	}

	// Token: 0x0400A60C RID: 42508
	[Nullable(2)]
	private FlySkinBuyDetailViewData ViewData;

	// Token: 0x0400A60D RID: 42509
	private EFlySkinType CurrentFlySkinType = EFlySkinType.Paragliding;

	// Token: 0x0400A60E RID: 42510
	private int CurrentPayItemId;

	// Token: 0x0400A60F RID: 42511
	[Nullable(2)]
	private SkeletalObserverHandle GliderObserver;

	// Token: 0x0400A610 RID: 42512
	public UiCameraInputComponent CameraInputComponent = new UiCameraInputComponent();

	// Token: 0x0400A611 RID: 42513
	[Nullable(2)]
	private string WaitCameraId;

	// Token: 0x0400A612 RID: 42514
	private bool CanPushCamera;

	// Token: 0x0400A613 RID: 42515
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400A614 RID: 42516
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SkinRewardItemGrid, SkinRewardData> ItemLayout;

	// Token: 0x0400A615 RID: 42517
	private double LastClickButtonTime;

	// Token: 0x0400A616 RID: 42518
	private double LastSwitchTime;

	// Token: 0x0400A617 RID: 42519
	private bool CurrentDiscountState;

	// Token: 0x0400A618 RID: 42520
	private bool CanLoadModel;

	// Token: 0x02008DA8 RID: 36264
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402FA4A RID: 195146
		CaptionItem,
		// Token: 0x0402FA4B RID: 195147
		OnlyUiToggle,
		// Token: 0x0402FA4C RID: 195148
		DetailIconButton,
		// Token: 0x0402FA4D RID: 195149
		ButtonLeft,
		// Token: 0x0402FA4E RID: 195150
		ButtonRight,
		// Token: 0x0402FA4F RID: 195151
		TitleText,
		// Token: 0x0402FA50 RID: 195152
		SubTitleText,
		// Token: 0x0402FA51 RID: 195153
		SwitchItem,
		// Token: 0x0402FA52 RID: 195154
		ToggleLeft,
		// Token: 0x0402FA53 RID: 195155
		ExtraRewardItem,
		// Token: 0x0402FA54 RID: 195156
		ExtraRewardContentHorizontalLayout,
		// Token: 0x0402FA55 RID: 195157
		RewardItem,
		// Token: 0x0402FA56 RID: 195158
		DescText,
		// Token: 0x0402FA57 RID: 195159
		NotHaveRoleItem,
		// Token: 0x0402FA58 RID: 195160
		BuyItemIcon,
		// Token: 0x0402FA59 RID: 195161
		NowPrice,
		// Token: 0x0402FA5A RID: 195162
		BeforePrice,
		// Token: 0x0402FA5B RID: 195163
		BuyButton,
		// Token: 0x0402FA5C RID: 195164
		DiscountItem,
		// Token: 0x0402FA5D RID: 195165
		DiscountText,
		// Token: 0x0402FA5E RID: 195166
		LeftTimeItem,
		// Token: 0x0402FA5F RID: 195167
		LeftTimeText,
		// Token: 0x0402FA60 RID: 195168
		QualityTexture,
		// Token: 0x0402FA61 RID: 195169
		ItemTexture,
		// Token: 0x0402FA62 RID: 195170
		FrameTexture,
		// Token: 0x0402FA63 RID: 195171
		WeaponRootItem,
		// Token: 0x0402FA64 RID: 195172
		WeaponTexture,
		// Token: 0x0402FA65 RID: 195173
		HaveItem,
		// Token: 0x0402FA66 RID: 195174
		HideUiParentItem,
		// Token: 0x0402FA67 RID: 195175
		DragComponent,
		// Token: 0x0402FA68 RID: 195176
		WeaponQualityTexture,
		// Token: 0x0402FA69 RID: 195177
		ToggleRight,
		// Token: 0x0402FA6A RID: 195178
		EffectItemB,
		// Token: 0x0402FA6B RID: 195179
		EffectItemA,
		// Token: 0x0402FA6C RID: 195180
		TextureToggleLeft,
		// Token: 0x0402FA6D RID: 195181
		TextToggleLeft,
		// Token: 0x0402FA6E RID: 195182
		TextureToggleRight,
		// Token: 0x0402FA6F RID: 195183
		TextToggleRight,
		// Token: 0x0402FA70 RID: 195184
		ItemGamePadKeyTipA = 45,
		// Token: 0x0402FA71 RID: 195185
		ItemGamePadKeyTipB
	}
}
