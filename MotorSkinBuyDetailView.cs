using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A35 RID: 10805
[NullableContext(1)]
[Nullable(0)]
public class MotorSkinBuyDetailView : UiTickViewBase
{
	// Token: 0x060159C6 RID: 88518 RVA: 0x005FDF92 File Offset: 0x005FC192
	public MotorSkinBuyDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060159C7 RID: 88519 RVA: 0x005FDFA6 File Offset: 0x005FC1A6
	[NullableContext(2)]
	public MotorSkinBuyDetailViewData GetViewData()
	{
		return this.ViewData;
	}

	// Token: 0x060159C8 RID: 88520 RVA: 0x005FDFB0 File Offset: 0x005FC1B0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 19;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIDraggableComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnClickOnlyUiToggle));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnClickBtnConfirmB));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060159C9 RID: 88521 RVA: 0x005FE2B8 File Offset: 0x005FC4B8
	protected override UniTask OnBeforeStartAsync()
	{
		MotorSkinBuyDetailView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorSkinBuyDetailView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060159CA RID: 88522 RVA: 0x005FE2FC File Offset: 0x005FC4FC
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Add<PayItemSuccess>(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x060159CB RID: 88523 RVA: 0x005FE360 File Offset: 0x005FC560
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPayItemSuccess, new Action<PayItemSuccess>(this.OnPayItemSuccess));
	}

	// Token: 0x060159CC RID: 88524 RVA: 0x005FE3C4 File Offset: 0x005FC5C4
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(2));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnCloseView));
		this.ViewData = (this.OpenParam as MotorSkinBuyDetailViewData);
		this.CaptionItem.SetHelpBtnActive(true);
		this.CaptionItem.SetHelpCallBack(new Action(this.OnClickedHelpButton));
		UUIExtendToggle extendToggle = base.GetExtendToggle(1);
		if (extendToggle != null)
		{
			extendToggle.RootUIComp.Get().SetUIActive(true);
		}
		this.MainRewardLayout = new GenericLayout<SkinRewardItemGrid, SkinRewardData>(base.GetHorizontalLayout(8), new Func<SkinRewardItemGrid>(this.InitGridItem), null, false, true);
		this.ExRewardLayout = new GenericLayout<SkinRewardItemGrid, SkinRewardData>(base.GetHorizontalLayout(10), new Func<SkinRewardItemGrid>(this.InitGridItem), null, false, true);
		ShopMotorSkinData currentGoodsData = this.ViewData.GetCurrentGoodsData();
		int? num;
		if (currentGoodsData == null)
		{
			num = null;
		}
		else
		{
			PayShopGoods currentGoodsData2 = currentGoodsData.GetCurrentGoodsData();
			num = ((currentGoodsData2 != null) ? new int?(currentGoodsData2.GetGoodsId()) : null);
		}
		int? num2 = num;
		this.CurrentGoodsId = num2.GetValueOrDefault();
		TotalTopUpPayAdditiveTagItem totalTopUpTagItem = this.TotalTopUpTagItem;
		if (totalTopUpTagItem == null)
		{
			return;
		}
		totalTopUpTagItem.RefreshByGoodsId(this.CurrentGoodsId);
	}

	// Token: 0x060159CD RID: 88525 RVA: 0x005FE4ED File Offset: 0x005FC6ED
	private SkinRewardItemGrid InitGridItem()
	{
		return new SkinRewardItemGrid();
	}

	// Token: 0x060159CE RID: 88526 RVA: 0x005FE4F4 File Offset: 0x005FC6F4
	protected override void OnHandleLoadScene()
	{
		this.InitMotorModel();
		this.InitCameraInputData();
	}

	// Token: 0x060159CF RID: 88527 RVA: 0x005FE502 File Offset: 0x005FC702
	private void InitMotorModel()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.CreateMotor(EUiModelUseWay.MotorInMotorView);
		this.HandleMotorShowByRewardList();
	}

	// Token: 0x060159D0 RID: 88528 RVA: 0x005FE518 File Offset: 0x005FC718
	private void HandleMotorShowByRewardList()
	{
		MotorSkinBuyDetailViewData motorSkinBuyDetailViewData = this.OpenParam as MotorSkinBuyDetailViewData;
		List<TItem> list;
		if (motorSkinBuyDetailViewData == null)
		{
			list = null;
		}
		else
		{
			ShopMotorSkinData currentGoodsData = motorSkinBuyDetailViewData.GetCurrentGoodsData();
			list = ((currentGoodsData != null) ? currentGoodsData.GetMainReward() : null);
		}
		List<TItem> list2 = list ?? new List<TItem>();
		int num = 0;
		int frameId = 89400001;
		List<int> list3 = new List<int>();
		List<int> list4 = new List<int>();
		foreach (TItem titem in list2)
		{
			int itemId = titem.ItemData.ItemId;
			InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemId));
			if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.MotorSkinItem)
			{
				num = itemId;
			}
			else if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.MotorFrameItem)
			{
				frameId = itemId;
			}
			else if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.MotorStickerItem)
			{
				list3.Add(itemId);
			}
			else if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.MotorDecorationItem)
			{
				list4.Add(itemId);
			}
		}
		if (num != 0)
		{
			Singleton<MotorcycleUiModelUtil>.Instance.LoadMotorBySkinId(num, null);
			return;
		}
		MotorcycleUiModelParam param = new MotorcycleUiModelParam
		{
			FrameId = frameId,
			StickerIds = list3.ToArray(),
			DecorationIds = list4.ToArray()
		};
		Singleton<MotorcycleUiModelUtil>.Instance.LoadMotorByParam(param, null);
	}

	// Token: 0x060159D1 RID: 88529 RVA: 0x005FE634 File Offset: 0x005FC834
	public void InitCameraInputData()
	{
		SUiRoleCameraSetting? roleCameraConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig("摩托车贴纸商城");
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

	// Token: 0x060159D2 RID: 88530 RVA: 0x005FE6B9 File Offset: 0x005FC8B9
	protected override void OnBeforeShow()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.SetSoarWingEnabled(true);
		Singleton<MotorcycleUiModelUtil>.Instance.ShowMotor(true);
		this.HandleMotorShowByRewardList();
		this.RefreshView();
	}

	// Token: 0x060159D3 RID: 88531 RVA: 0x005FE6E0 File Offset: 0x005FC8E0
	private void RefreshView()
	{
		MotorSkinBuyDetailViewData viewData = this.ViewData;
		ShopMotorSkinData shopMotorSkinData = (viewData != null) ? viewData.GetCurrentGoodsData() : null;
		MotorSkinData motorSkinData = (shopMotorSkinData != null) ? shopMotorSkinData.GetMotorSkinData() : null;
		if (viewData == null || shopMotorSkinData == null || motorSkinData == null)
		{
			return;
		}
		MotorSkinShow? motorSkinShow = motorSkinData.GetMotorSkinShow();
		if (motorSkinShow == null)
		{
			return;
		}
		shopMotorSkinData.GetCurrentGoodsData().SaveRemindState((long)Singleton<TimeUtil>.Instance.GetServerTime());
		bool ifCanBuy = shopMotorSkinData.GetIfCanBuy();
		base.GetText(15).SetUIActive(ifCanBuy);
		base.GetButton(13).RootUIComp.Get().SetUIActive(ifCanBuy);
		base.GetItem(17).SetUIActive(!ifCanBuy);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), motorSkinShow.Value.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), motorSkinShow.Value.TypeDescription, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), motorSkinShow.Value.Desc ?? "", Array.Empty<object>());
		string discountText = viewData.GetDiscountText();
		base.GetText(16).SetUIActive(discountText != "");
		base.GetText(16).SetText(discountText, true);
		this.RefreshLeftTime(viewData);
		bool ifDirect = viewData.GetIfDirect();
		IPriceData priceData = viewData.GetPriceData();
		if (ifDirect)
		{
			base.GetText(15).SetText(viewData.GetDirectPriceText(), true);
		}
		else if (priceData != null)
		{
			base.GetText(15).SetText(priceData.NowPrice.ToString(), true);
		}
		int? num = (priceData != null) ? priceData.OriginalPrice : null;
		if (num != null)
		{
			base.GetText(15).SetText("<s>" + num.Value.ToString() + "</s>", true);
		}
		this.RefreshMainReward(this.ViewData);
		this.RefreshExtraReward(this.ViewData);
		if (ifCanBuy)
		{
			TotalTopUpPayAdditiveTagItem totalTopUpTagItem = this.TotalTopUpTagItem;
			if (totalTopUpTagItem == null)
			{
				return;
			}
			totalTopUpTagItem.RefreshByGoodsId(this.CurrentGoodsId);
			return;
		}
		else
		{
			TotalTopUpPayAdditiveTagItem totalTopUpTagItem2 = this.TotalTopUpTagItem;
			if (totalTopUpTagItem2 == null)
			{
				return;
			}
			totalTopUpTagItem2.SetUiActive(false);
			return;
		}
	}

	// Token: 0x060159D4 RID: 88532 RVA: 0x005FE914 File Offset: 0x005FCB14
	private void RefreshLeftTime(MotorSkinBuyDetailViewData data)
	{
		ShopMotorSkinData currentGoodsData = data.GetCurrentGoodsData();
		ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double>? valueTuple = (currentGoodsData != null) ? new ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double>?(currentGoodsData.GetCurrentGoodsData().GetCountDownData()) : null;
		if (valueTuple == null)
		{
			return;
		}
		ValueTuple<EPayCountTimeType, CommonDefine.IPayShowCountDownRemainTime, double> value = valueTuple.Value;
		if (value.Item3 == 0.0)
		{
			base.GetItem(6).SetUIActive(false);
			return;
		}
		CommonDefine.IPayShowCountDownRemainTime item = value.Item2;
		base.GetItem(6).SetUIActive(true);
		CommonDefine.PayShowCountDownRemainTime<string> payShowCountDownRemainTime = item as CommonDefine.PayShowCountDownRemainTime<string>;
		if (payShowCountDownRemainTime == null)
		{
			CommonDefine.IRemainTime remainTime = item as CommonDefine.IRemainTime;
			if (remainTime != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(7), remainTime.TextId, new <>z__ReadOnlySingleElementList<object>(remainTime.TimeValue));
			}
			return;
		}
		UUIText text = base.GetText(7);
		if (text == null)
		{
			return;
		}
		text.SetText(payShowCountDownRemainTime.Value, true);
	}

	// Token: 0x060159D5 RID: 88533 RVA: 0x005FE9E8 File Offset: 0x005FCBE8
	[NullableContext(2)]
	private void RefreshMainReward(MotorSkinBuyDetailViewData data)
	{
		if (data == null || data.GetCurrentGoodsData() == null)
		{
			return;
		}
		List<TItem> mainReward = data.GetCurrentGoodsData().GetMainReward();
		List<SkinRewardData> list = new List<SkinRewardData>();
		foreach (TItem value in mainReward)
		{
			list.Add(new SkinRewardData
			{
				ItemData = new TItem?(value),
				FinishState = !data.GetCurrentGoodsData().GetIfCanBuy()
			});
		}
		GenericLayout<SkinRewardItemGrid, SkinRewardData> mainRewardLayout = this.MainRewardLayout;
		if (mainRewardLayout == null)
		{
			return;
		}
		mainRewardLayout.RefreshByData(list, null, false);
	}

	// Token: 0x060159D6 RID: 88534 RVA: 0x005FEA8C File Offset: 0x005FCC8C
	[NullableContext(2)]
	private void RefreshExtraReward(MotorSkinBuyDetailViewData data)
	{
		if (data == null || data.GetCurrentGoodsData() == null)
		{
			return;
		}
		TItem? otherReward = data.GetCurrentGoodsData().GetOtherReward();
		if (otherReward == null)
		{
			return;
		}
		SkinRewardData skinRewardData = new SkinRewardData();
		skinRewardData.ItemData = new TItem?(otherReward.Value);
		skinRewardData.FinishState = !data.GetCurrentGoodsData().GetIfCanBuy();
		GenericLayout<SkinRewardItemGrid, SkinRewardData> exRewardLayout = this.ExRewardLayout;
		if (exRewardLayout == null)
		{
			return;
		}
		exRewardLayout.RefreshByData(new List<SkinRewardData>
		{
			skinRewardData
		}, null, false);
	}

	// Token: 0x060159D7 RID: 88535 RVA: 0x005FEB05 File Offset: 0x005FCD05
	protected override void OnAfterShow()
	{
		this.CameraInputComponent.Start();
		this.CameraInputComponent.TryActivate();
	}

	// Token: 0x060159D8 RID: 88536 RVA: 0x005FEB20 File Offset: 0x005FCD20
	protected override void OnTick(float delta)
	{
		MotorSkinBuyDetailViewData viewData = this.ViewData;
		PayShopGoods payShopGoods;
		if (viewData == null)
		{
			payShopGoods = null;
		}
		else
		{
			ShopMotorSkinData currentGoodsData = viewData.GetCurrentGoodsData();
			payShopGoods = ((currentGoodsData != null) ? currentGoodsData.GetCurrentGoodsData() : null);
		}
		PayShopGoods payShopGoods2 = payShopGoods;
		if (payShopGoods2 == null)
		{
			return;
		}
		if (payShopGoods2.NeedDown())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PayShopRefresh);
			Action value = delegate()
			{
				base.CloseMe(null);
			};
			confirmBoxDataNew.FunctionMap[1] = value;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
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
				ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.PayShopRefresh);
				confirmBoxDataNew2.FunctionMap[2] = new Action(this.RefreshView);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
			}
		}
	}

	// Token: 0x060159D9 RID: 88537 RVA: 0x005FEC67 File Offset: 0x005FCE67
	protected override void OnBeforeHide()
	{
		this.CameraInputComponent.End();
		Singleton<MotorcycleUiModelUtil>.Instance.SetSoarWingEnabled(false);
		Singleton<MotorcycleUiModelUtil>.Instance.ClearMotorBuff();
		Singleton<MotorcycleUiModelUtil>.Instance.ShowMotor(false);
	}

	// Token: 0x060159DA RID: 88538 RVA: 0x005FEC94 File Offset: 0x005FCE94
	protected override void OnHandleReleaseScene()
	{
		Singleton<MotorcycleUiModelUtil>.Instance.DestroyMotor();
	}

	// Token: 0x060159DB RID: 88539 RVA: 0x005FECA0 File Offset: 0x005FCEA0
	private void OnCloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x060159DC RID: 88540 RVA: 0x005FECA9 File Offset: 0x005FCEA9
	private void OnClickBtnConfirmB()
	{
		ControllerBase<PayShopController>.Instance.OpenBuySkinDetailView(this.ViewData.GetCurrentGoodsData().GetCurrentGoodsData());
	}

	// Token: 0x060159DD RID: 88541 RVA: 0x005FECC8 File Offset: 0x005FCEC8
	private void OnClickOnlyUiToggle(EToggleState toggleState)
	{
		this.IsObserving = !this.IsObserving;
		bool state = this.IsObserving;
		if (!state)
		{
			base.GetItem(3).SetUIActive(!state);
			base.PlaySequence("UiIn", delegate
			{
			}, true);
			return;
		}
		base.PlaySequence("UiOut", delegate
		{
			if (this.IsDestroyOrDestroying)
			{
				return;
			}
			this.GetItem(3).SetUIActive(!state);
		}, true);
	}

	// Token: 0x060159DE RID: 88542 RVA: 0x005FED5E File Offset: 0x005FCF5E
	private void OnActivateUiCameraAnimationHandle(UiCameraHandleData handleData)
	{
		if (handleData.HandleName == this.WaitCameraId)
		{
			this.WaitCameraId = null;
			if (!this.CanLoadModel)
			{
				this.CanLoadModel = true;
			}
		}
	}

	// Token: 0x060159DF RID: 88543 RVA: 0x005FED89 File Offset: 0x005FCF89
	private void OnClickedHelpButton()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(478);
	}

	// Token: 0x060159E0 RID: 88544 RVA: 0x005FED9A File Offset: 0x005FCF9A
	private void OnPayItemSuccess(PayItemSuccess notify)
	{
		this.RefreshView();
	}

	// Token: 0x060159E1 RID: 88545 RVA: 0x005FEDA4 File Offset: 0x005FCFA4
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType shopId, int tabId)
	{
		ShopMotorSkinData currentGoodsData = this.ViewData.GetCurrentGoodsData();
		int? num = (currentGoodsData != null) ? new int?(currentGoodsData.GetCurrentGoodsData().GetGoodsId()) : null;
		if (!(goodsId == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		this.RefreshView();
	}

	// Token: 0x0400A628 RID: 42536
	private const int DEFAULT_MOTOR_SKIN_ID = 89200000;

	// Token: 0x0400A629 RID: 42537
	private const string MOTORCYCLE_SHOP_ROOT_VIEW_CAMERA_CONFIG_ID = "摩托车贴纸商城";

	// Token: 0x0400A62A RID: 42538
	[Nullable(2)]
	private MotorSkinBuyDetailViewData ViewData;

	// Token: 0x0400A62B RID: 42539
	private int CurrentPayItemId;

	// Token: 0x0400A62C RID: 42540
	public UiCameraInputComponent CameraInputComponent = new UiCameraInputComponent();

	// Token: 0x0400A62D RID: 42541
	[Nullable(2)]
	private string WaitCameraId;

	// Token: 0x0400A62E RID: 42542
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400A62F RID: 42543
	private bool CurrentDiscountState;

	// Token: 0x0400A630 RID: 42544
	private bool CanLoadModel;

	// Token: 0x0400A631 RID: 42545
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SkinRewardItemGrid, SkinRewardData> MainRewardLayout;

	// Token: 0x0400A632 RID: 42546
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<SkinRewardItemGrid, SkinRewardData> ExRewardLayout;

	// Token: 0x0400A633 RID: 42547
	private bool IsObserving;

	// Token: 0x0400A634 RID: 42548
	[Nullable(2)]
	private TotalTopUpPayAdditiveTagItem TotalTopUpTagItem;

	// Token: 0x0400A635 RID: 42549
	private int CurrentGoodsId;

	// Token: 0x0400A636 RID: 42550
	private const int MOTOR_SHOP_HELP_ID = 478;

	// Token: 0x0400A637 RID: 42551
	private const int MOTOR_FIXED_FRAME_ID = 89400001;

	// Token: 0x02008DB3 RID: 36275
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402FAC4 RID: 195268
		BtnMask,
		// Token: 0x0402FAC5 RID: 195269
		OnlyUiToggle,
		// Token: 0x0402FAC6 RID: 195270
		UiItemCaption,
		// Token: 0x0402FAC7 RID: 195271
		PanelHide,
		// Token: 0x0402FAC8 RID: 195272
		TxtTitle,
		// Token: 0x0402FAC9 RID: 195273
		TxtType,
		// Token: 0x0402FACA RID: 195274
		LeftTimeItem,
		// Token: 0x0402FACB RID: 195275
		LeftTimeText,
		// Token: 0x0402FACC RID: 195276
		MainRewardLayout,
		// Token: 0x0402FACD RID: 195277
		UiItemItemBaseB3,
		// Token: 0x0402FACE RID: 195278
		ExRewardLayout,
		// Token: 0x0402FACF RID: 195279
		UiItemItemBaseB4,
		// Token: 0x0402FAD0 RID: 195280
		TxtContent,
		// Token: 0x0402FAD1 RID: 195281
		BtnConfirmB,
		// Token: 0x0402FAD2 RID: 195282
		PanelHorizontalLayout,
		// Token: 0x0402FAD3 RID: 195283
		TxtPrice,
		// Token: 0x0402FAD4 RID: 195284
		DiscountText,
		// Token: 0x0402FAD5 RID: 195285
		PanelGot,
		// Token: 0x0402FAD6 RID: 195286
		PanelTagRoot
	}
}
