using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Spring25;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Platform;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x020025E7 RID: 9703
[NullableContext(1)]
[Nullable(0)]
public class PhotoSaveView : UiViewBase
{
	// Token: 0x06012FF9 RID: 77817 RVA: 0x00542498 File Offset: 0x00540698
	public PhotoSaveView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012FFA RID: 77818 RVA: 0x005424BC File Offset: 0x005406BC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUISprite)),
			new ValueTuple<int, Type>(9, typeof(UUISprite)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIText)),
			new ValueTuple<int, Type>(17, typeof(UUIText)),
			new ValueTuple<int, Type>(18, typeof(UUIText)),
			new ValueTuple<int, Type>(19, typeof(UUITexture)),
			new ValueTuple<int, Type>(20, typeof(UUIText)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIItem)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIText)),
			new ValueTuple<int, Type>(26, typeof(UUIText)),
			new ValueTuple<int, Type>(27, typeof(UUIItem)),
			new ValueTuple<int, Type>(28, typeof(UUIItem)),
			new ValueTuple<int, Type>(29, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(30, typeof(UUIItem)),
			new ValueTuple<int, Type>(31, typeof(UUIItem)),
			new ValueTuple<int, Type>(32, typeof(UUITexture)),
			new ValueTuple<int, Type>(33, typeof(UUITexture)),
			new ValueTuple<int, Type>(34, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(35, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(36, typeof(UUIItem)),
			new ValueTuple<int, Type>(37, typeof(UUITexture)),
			new ValueTuple<int, Type>(38, typeof(UUIVerticalLayout))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickedConfirmButton)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickedCloseButton)),
			new ValueTuple<int, Delegate>(29, new Action(this.OnClickRetake)),
			new ValueTuple<int, Delegate>(34, new Action<EToggleState>(this.OnClickPersonalInfoShow)),
			new ValueTuple<int, Delegate>(35, new Action<EToggleState>(this.OnClickPersonalInfoShow))
		};
	}

	// Token: 0x06012FFB RID: 77819 RVA: 0x005428D4 File Offset: 0x00540AD4
	protected override UniTask OnBeforeStartAsync()
	{
		PhotoSaveView.<OnBeforeStartAsync>d__31 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhotoSaveView.<OnBeforeStartAsync>d__31>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012FFC RID: 77820 RVA: 0x00542917 File Offset: 0x00540B17
	private PhotoShareBtnItem InitShareBtn()
	{
		PhotoShareBtnItem photoShareBtnItem = new PhotoShareBtnItem();
		photoShareBtnItem.SetClickCallBack(new Action<EChannelShare, int>(this.OnClickShareBtn));
		return photoShareBtnItem;
	}

	// Token: 0x06012FFD RID: 77821 RVA: 0x00542930 File Offset: 0x00540B30
	private GachaShareSwitchItem InitGachaShareSwitchItem()
	{
		GachaShareSwitchItem gachaShareSwitchItem = new GachaShareSwitchItem();
		gachaShareSwitchItem.SetToggleClickCallback(new Action<GachaShareSwitchData, int>(this.OnClickGachaSwitchItem));
		return gachaShareSwitchItem;
	}

	// Token: 0x06012FFE RID: 77822 RVA: 0x0054294C File Offset: 0x00540B4C
	private void OnClickGachaSwitchItem(GachaShareSwitchData switchData, int gridIndex)
	{
		GenericLayout<GachaShareSwitchItem, GachaShareSwitchData> gachaSwitchLayout = this.GachaSwitchLayout;
		if (gachaSwitchLayout != null && gachaSwitchLayout.GetSelectedGridIndex() == gridIndex)
		{
			return;
		}
		GachaShareTenPanel gachaViewTen = this.GachaViewTen;
		if (gachaViewTen != null)
		{
			gachaViewTen.SetUiActive(switchData.TenGachaInfo != null);
		}
		GachaShareOnePanel gachaView = this.GachaView;
		if (gachaView != null)
		{
			gachaView.SetUiActive(switchData.GachaInfo != null);
		}
		if (switchData.GachaInfo != null)
		{
			GachaShareOnePanel gachaView2 = this.GachaView;
			if (gachaView2 != null)
			{
				gachaView2.Refresh(switchData.GachaInfo);
			}
		}
		GenericLayout<GachaShareSwitchItem, GachaShareSwitchData> gachaSwitchLayout2 = this.GachaSwitchLayout;
		if (gachaSwitchLayout2 != null)
		{
			gachaSwitchLayout2.SelectGridProxy(gridIndex, false);
		}
		bool flag = switchData.GachaInfo != null;
		GachaResult gachaInfo = flag ? switchData.GachaInfo : switchData.TenGachaInfo[0];
		this.SetGachaExtraType(flag, gachaInfo);
	}

	// Token: 0x06012FFF RID: 77823 RVA: 0x00542A04 File Offset: 0x00540C04
	private void SetGachaExtraType(bool isSingle, GachaResult gachaInfo)
	{
		InventoryDefine.EItemDataType itemIdType = ConfigBase<GachaConfig>.Instance.GetItemIdType(gachaInfo.Proto_GachaReward.ItemId);
		EShareReportExtraType shareReportExtraType = EShareReportExtraType.None;
		if (itemIdType == InventoryDefine.EItemDataType.RoleItem)
		{
			shareReportExtraType = (isSingle ? EShareReportExtraType.CharacterGachaOne : EShareReportExtraType.CharacterGachaTen);
		}
		else if (itemIdType == InventoryDefine.EItemDataType.WeaponItem)
		{
			shareReportExtraType = (isSingle ? EShareReportExtraType.WeaponGachaOne : EShareReportExtraType.WeaponGachaTen);
		}
		this.ShareReportExtraType = shareReportExtraType;
	}

	// Token: 0x06013000 RID: 77824 RVA: 0x00542A4C File Offset: 0x00540C4C
	private UniTask RefreshGachaView(IReadOnlyList<GachaResult> gachaInfos)
	{
		PhotoSaveView.<RefreshGachaView>d__36 <RefreshGachaView>d__;
		<RefreshGachaView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshGachaView>d__.<>4__this = this;
		<RefreshGachaView>d__.gachaInfos = gachaInfos;
		<RefreshGachaView>d__.<>1__state = -1;
		<RefreshGachaView>d__.<>t__builder.Start<PhotoSaveView.<RefreshGachaView>d__36>(ref <RefreshGachaView>d__);
		return <RefreshGachaView>d__.<>t__builder.Task;
	}

	// Token: 0x06013001 RID: 77825 RVA: 0x00542A98 File Offset: 0x00540C98
	[NullableContext(2)]
	private UniTask RefreshOneGachaView(GachaResult gachaInfo)
	{
		PhotoSaveView.<RefreshOneGachaView>d__37 <RefreshOneGachaView>d__;
		<RefreshOneGachaView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshOneGachaView>d__.<>4__this = this;
		<RefreshOneGachaView>d__.gachaInfo = gachaInfo;
		<RefreshOneGachaView>d__.<>1__state = -1;
		<RefreshOneGachaView>d__.<>t__builder.Start<PhotoSaveView.<RefreshOneGachaView>d__37>(ref <RefreshOneGachaView>d__);
		return <RefreshOneGachaView>d__.<>t__builder.Task;
	}

	// Token: 0x06013002 RID: 77826 RVA: 0x00542AE4 File Offset: 0x00540CE4
	private UniTask RefreshTenGachaView(IReadOnlyList<GachaResult> gachaInfos)
	{
		PhotoSaveView.<RefreshTenGachaView>d__38 <RefreshTenGachaView>d__;
		<RefreshTenGachaView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTenGachaView>d__.<>4__this = this;
		<RefreshTenGachaView>d__.gachaInfos = gachaInfos;
		<RefreshTenGachaView>d__.<>1__state = -1;
		<RefreshTenGachaView>d__.<>t__builder.Start<PhotoSaveView.<RefreshTenGachaView>d__38>(ref <RefreshTenGachaView>d__);
		return <RefreshTenGachaView>d__.<>t__builder.Task;
	}

	// Token: 0x06013003 RID: 77827 RVA: 0x00542B2F File Offset: 0x00540D2F
	private IReadOnlyList<GachaResult> GetSortTenGachaInfos(IReadOnlyList<GachaResult> gachaInfos)
	{
		List<GachaResult> list = new List<GachaResult>(gachaInfos);
		list.Sort(delegate(GachaResult a, GachaResult b)
		{
			if (a.Proto_GachaReward == null || b.Proto_GachaReward == null)
			{
				return 0;
			}
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(a.Proto_GachaReward.ItemId);
			ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(b.Proto_GachaReward.ItemId);
			int num = (itemConfigData != null) ? itemConfigData.QualityId : 0;
			int num2 = (itemConfigData2 != null) ? itemConfigData2.QualityId : 0;
			if (num == num2)
			{
				int num3 = PhotoSaveView.<GetSortTenGachaInfos>g__RevertType|39_0(ConfigBase<GachaConfig>.Instance.GetItemIdType(a.Proto_GachaReward.ItemId));
				return PhotoSaveView.<GetSortTenGachaInfos>g__RevertType|39_0(ConfigBase<GachaConfig>.Instance.GetItemIdType(b.Proto_GachaReward.ItemId)) - num3;
			}
			return num2 - num;
		});
		return list;
	}

	// Token: 0x06013004 RID: 77828 RVA: 0x00542B5C File Offset: 0x00540D5C
	private UniTask InitFragmentMemorySubView(FragmentMemoryCollectData data)
	{
		PhotoSaveView.<InitFragmentMemorySubView>d__40 <InitFragmentMemorySubView>d__;
		<InitFragmentMemorySubView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitFragmentMemorySubView>d__.<>4__this = this;
		<InitFragmentMemorySubView>d__.data = data;
		<InitFragmentMemorySubView>d__.<>1__state = -1;
		<InitFragmentMemorySubView>d__.<>t__builder.Start<PhotoSaveView.<InitFragmentMemorySubView>d__40>(ref <InitFragmentMemorySubView>d__);
		return <InitFragmentMemorySubView>d__.<>t__builder.Task;
	}

	// Token: 0x06013005 RID: 77829 RVA: 0x00542BA8 File Offset: 0x00540DA8
	private UniTask InitRoleSkinSubView(RoleSkinData data)
	{
		PhotoSaveView.<InitRoleSkinSubView>d__41 <InitRoleSkinSubView>d__;
		<InitRoleSkinSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitRoleSkinSubView>d__.<>4__this = this;
		<InitRoleSkinSubView>d__.data = data;
		<InitRoleSkinSubView>d__.<>1__state = -1;
		<InitRoleSkinSubView>d__.<>t__builder.Start<PhotoSaveView.<InitRoleSkinSubView>d__41>(ref <InitRoleSkinSubView>d__);
		return <InitRoleSkinSubView>d__.<>t__builder.Task;
	}

	// Token: 0x06013006 RID: 77830 RVA: 0x00542BF4 File Offset: 0x00540DF4
	private UniTask InitWheelTowerSettlementShareView(IWheelTowerSettlementViewData data)
	{
		PhotoSaveView.<InitWheelTowerSettlementShareView>d__42 <InitWheelTowerSettlementShareView>d__;
		<InitWheelTowerSettlementShareView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitWheelTowerSettlementShareView>d__.<>4__this = this;
		<InitWheelTowerSettlementShareView>d__.data = data;
		<InitWheelTowerSettlementShareView>d__.<>1__state = -1;
		<InitWheelTowerSettlementShareView>d__.<>t__builder.Start<PhotoSaveView.<InitWheelTowerSettlementShareView>d__42>(ref <InitWheelTowerSettlementShareView>d__);
		return <InitWheelTowerSettlementShareView>d__.<>t__builder.Task;
	}

	// Token: 0x06013007 RID: 77831 RVA: 0x00542C40 File Offset: 0x00540E40
	private UniTask InitWheelTowerTotalScoreView()
	{
		PhotoSaveView.<InitWheelTowerTotalScoreView>d__43 <InitWheelTowerTotalScoreView>d__;
		<InitWheelTowerTotalScoreView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitWheelTowerTotalScoreView>d__.<>4__this = this;
		<InitWheelTowerTotalScoreView>d__.<>1__state = -1;
		<InitWheelTowerTotalScoreView>d__.<>t__builder.Start<PhotoSaveView.<InitWheelTowerTotalScoreView>d__43>(ref <InitWheelTowerTotalScoreView>d__);
		return <InitWheelTowerTotalScoreView>d__.<>t__builder.Task;
	}

	// Token: 0x06013008 RID: 77832 RVA: 0x00542C84 File Offset: 0x00540E84
	private UniTask InitChallengeRecordShareView(ShipTowerRecordShareData data)
	{
		PhotoSaveView.<InitChallengeRecordShareView>d__44 <InitChallengeRecordShareView>d__;
		<InitChallengeRecordShareView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitChallengeRecordShareView>d__.<>4__this = this;
		<InitChallengeRecordShareView>d__.data = data;
		<InitChallengeRecordShareView>d__.<>1__state = -1;
		<InitChallengeRecordShareView>d__.<>t__builder.Start<PhotoSaveView.<InitChallengeRecordShareView>d__44>(ref <InitChallengeRecordShareView>d__);
		return <InitChallengeRecordShareView>d__.<>t__builder.Task;
	}

	// Token: 0x06013009 RID: 77833 RVA: 0x00542CD0 File Offset: 0x00540ED0
	private UniTask InitHandBookPhotoShareView(HandBookPhotoData data)
	{
		PhotoSaveView.<InitHandBookPhotoShareView>d__45 <InitHandBookPhotoShareView>d__;
		<InitHandBookPhotoShareView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitHandBookPhotoShareView>d__.<>4__this = this;
		<InitHandBookPhotoShareView>d__.data = data;
		<InitHandBookPhotoShareView>d__.<>1__state = -1;
		<InitHandBookPhotoShareView>d__.<>t__builder.Start<PhotoSaveView.<InitHandBookPhotoShareView>d__45>(ref <InitHandBookPhotoShareView>d__);
		return <InitHandBookPhotoShareView>d__.<>t__builder.Task;
	}

	// Token: 0x0601300A RID: 77834 RVA: 0x00542D1C File Offset: 0x00540F1C
	private UniTask InitTowerVariationShareView()
	{
		PhotoSaveView.<InitTowerVariationShareView>d__46 <InitTowerVariationShareView>d__;
		<InitTowerVariationShareView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTowerVariationShareView>d__.<>4__this = this;
		<InitTowerVariationShareView>d__.<>1__state = -1;
		<InitTowerVariationShareView>d__.<>t__builder.Start<PhotoSaveView.<InitTowerVariationShareView>d__46>(ref <InitTowerVariationShareView>d__);
		return <InitTowerVariationShareView>d__.<>t__builder.Task;
	}

	// Token: 0x0601300B RID: 77835 RVA: 0x00542D60 File Offset: 0x00540F60
	private UniTask InitVersionPreheatSubView(VersionPreheatShareData data)
	{
		PhotoSaveView.<InitVersionPreheatSubView>d__47 <InitVersionPreheatSubView>d__;
		<InitVersionPreheatSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitVersionPreheatSubView>d__.<>4__this = this;
		<InitVersionPreheatSubView>d__.data = data;
		<InitVersionPreheatSubView>d__.<>1__state = -1;
		<InitVersionPreheatSubView>d__.<>t__builder.Start<PhotoSaveView.<InitVersionPreheatSubView>d__47>(ref <InitVersionPreheatSubView>d__);
		return <InitVersionPreheatSubView>d__.<>t__builder.Task;
	}

	// Token: 0x0601300C RID: 77836 RVA: 0x00542DAC File Offset: 0x00540FAC
	private UniTask InitSpring25SubView(Spring25ShareData data)
	{
		PhotoSaveView.<InitSpring25SubView>d__48 <InitSpring25SubView>d__;
		<InitSpring25SubView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSpring25SubView>d__.<>4__this = this;
		<InitSpring25SubView>d__.data = data;
		<InitSpring25SubView>d__.<>1__state = -1;
		<InitSpring25SubView>d__.<>t__builder.Start<PhotoSaveView.<InitSpring25SubView>d__48>(ref <InitSpring25SubView>d__);
		return <InitSpring25SubView>d__.<>t__builder.Task;
	}

	// Token: 0x0601300D RID: 77837 RVA: 0x00542DF8 File Offset: 0x00540FF8
	private void RefreshPhotoPanel()
	{
		base.GetItem(14).SetUIActive(true);
		base.GetItem(15).SetUIActive(false);
		UUIItem item = base.GetItem(13);
		UUIItem item2 = base.GetItem(7);
		UUIText text = base.GetText(10);
		FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
		float viewportScale = UWidgetLayoutLibrary.GetViewportScale(GlobalData.World);
		if (this.ShareActionId == EShareActionId.Photo || this.ShareActionId == EShareActionId.Birthday)
		{
			item.SetWidth(viewportSize.X / (viewportScale * 1.5f));
			item.SetHeight(viewportSize.Y / (viewportScale * 1.5f));
		}
		else
		{
			item.SetWidth(1750f);
			item.SetHeight(986f);
		}
		if (ControllerBase<PhotographController>.Instance.CheckIfInNormalCamera())
		{
			text.SetUIActive(false);
			item2.SetUIActive(false);
			this.RefreshShareBtn();
		}
		else if (ControllerBase<PhotographController>.Instance.CheckIfInEntityCamera())
		{
			text.SetUIActive(true);
			item2.SetUIActive(true);
			this.RefreshBtnEmpty();
		}
		else if (ControllerBase<PhotographController>.Instance.CheckIfInTogetherCamera())
		{
			text.SetUIActive(false);
			item2.SetUIActive(false);
			this.RefreshShareBtn();
		}
		this.RefreshSaveBtn();
	}

	// Token: 0x0601300E RID: 77838 RVA: 0x00542F10 File Offset: 0x00541110
	private void RefreshLandscapePanel(HandBookPhotoData data)
	{
		base.GetItem(14).SetUIActive(false);
		base.GetItem(15).SetUIActive(true);
		base.GetItem(7).SetUIActive(false);
		this.RefreshShareBtn();
		this.RefreshSaveBtn();
		int index = data.Index;
		base.GetText(18).SetUIActive(data.DateText != null);
		if (data.DateText != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(18), "DateOfAcquisition", new <>z__ReadOnlySingleElementList<object>(data.DateText[index]));
		}
		base.GetText(17).SetUIActive(data.NameText != null);
		if (data.NameText != null)
		{
			base.GetText(17).SetText(data.NameText[index], true);
		}
		base.GetText(16).SetUIActive(data.TypeText != null);
		if (data.TypeText != null)
		{
			base.GetText(16).SetText(data.TypeText[index], true);
		}
		base.GetText(20).SetUIActive(data.DescrtptionText != null);
		if (data.DescrtptionText != null)
		{
			base.GetText(20).SetText(data.DescrtptionText[index], true);
		}
		base.GetTexture(19).SetUIActive(data.TextureList != null);
		if (data.TextureList != null)
		{
			base.SetTextureByPath(data.TextureList[index], base.GetTexture(19), null, null);
		}
	}

	// Token: 0x0601300F RID: 77839 RVA: 0x0054308C File Offset: 0x0054128C
	private void RefreshFullScreenPhotoPanel(bool isProcess)
	{
		UUIItem item = base.GetItem(14);
		item.SetUIActive(true);
		base.GetItem(15).SetUIActive(false);
		UUIItem item2 = base.GetItem(13);
		FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
		float viewportScale = UWidgetLayoutLibrary.GetViewportScale(GlobalData.World);
		if (isProcess)
		{
			item2.SetWidth(viewportSize.X / viewportScale);
			item2.SetHeight(viewportSize.Y / viewportScale);
			this.PanelItemOriginalScale = new FVector?(item.K2_GetComponentScale());
			FVector uiitemScale = new FVector(1f, 1f, 1f);
			item.SetUIItemScale(uiitemScale);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPreparePhotoScreenShot, false);
			return;
		}
		item2.SetWidth(viewportSize.X / (viewportScale * 1.5f));
		item2.SetHeight(viewportSize.Y / (viewportScale * 1.5f));
		item.SetUIItemScale(this.PanelItemOriginalScale.Value);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPreparePhotoScreenShot, true);
	}

	// Token: 0x06013010 RID: 77840 RVA: 0x00543180 File Offset: 0x00541380
	private void RefreshMarkItem(bool isProcess)
	{
		if (isProcess)
		{
			PhotoSaveMarkItem markItem = this.MarkItem;
			if (markItem == null)
			{
				return;
			}
			markItem.SetUiActive(!this.IsShowPlayerName);
			return;
		}
		else
		{
			PhotoSaveMarkItem markItem2 = this.MarkItem;
			if (markItem2 == null)
			{
				return;
			}
			markItem2.SetUiActive(this.IsShowPlayerName);
			return;
		}
	}

	// Token: 0x06013011 RID: 77841 RVA: 0x005431B8 File Offset: 0x005413B8
	private void RefreshPhotoPanelByUiDirectly()
	{
		base.GetItem(14).SetUIActive(true);
		base.GetItem(15).SetUIActive(false);
		UUIItem item = base.GetItem(13);
		UUIItem item2 = base.GetItem(7);
		UUIItem text = base.GetText(10);
		FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
		float viewportScale = UWidgetLayoutLibrary.GetViewportScale(GlobalData.World);
		if (this.ShareActionId == EShareActionId.Photo)
		{
			item.SetWidth(viewportSize.X / (viewportScale * 1.5f));
			item.SetHeight(viewportSize.Y / (viewportScale * 1.5f));
		}
		else
		{
			item.SetWidth(1750f);
			item.SetHeight(986f);
		}
		text.SetUIActive(false);
		item2.SetUIActive(false);
		this.RefreshShareBtn();
		this.RefreshSaveBtn();
	}

	// Token: 0x06013012 RID: 77842 RVA: 0x00543270 File Offset: 0x00541470
	private bool GetIfShareBtnCanShow()
	{
		return !Singleton<BaseConfigController>.Instance.GetIosAuditFirstDownloadTip();
	}

	// Token: 0x06013013 RID: 77843 RVA: 0x00543284 File Offset: 0x00541484
	private void RefreshSaveBtn()
	{
		bool flag = ControllerBase<PhotographController>.Instance.CheckHasSpecifiedFeatureForSave();
		bool flag2 = Singleton<Info>.Instance.IsXSXPlatform();
		UUIButtonComponent button = base.GetButton(6);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(!flag2 && !flag);
	}

	// Token: 0x06013014 RID: 77844 RVA: 0x005432D0 File Offset: 0x005414D0
	private void RefreshShareBtn()
	{
		base.GetItem(31).SetUIActive(true);
		base.GetButton(29).RootUIComp.Get().SetUIActive(false);
		base.GetHorizontalLayout(5).RootUIComp.Get().SetUIActive(this.GetIfShareBtnCanShow());
		List<EChannelShare> openedShareIds = ControllerBase<ChannelController>.Instance.GetOpenedShareIds();
		this.ShareBtnLayout = new GenericLayout<PhotoShareBtnItem, EChannelShare>(base.GetHorizontalLayout(5), new Func<PhotoShareBtnItem>(this.InitShareBtn), null, false, true);
		this.ShareBtnLayout.RefreshByData(openedShareIds, null, false);
		base.GetItem(30).SetUIActive(openedShareIds.Count > 0);
	}

	// Token: 0x06013015 RID: 77845 RVA: 0x00543378 File Offset: 0x00541578
	private void RefreshRetakeBtn()
	{
		base.GetItem(31).SetUIActive(false);
		base.GetItem(30).SetUIActive(true);
		base.GetButton(29).RootUIComp.Get().SetUIActive(true);
		base.GetHorizontalLayout(5).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x06013016 RID: 77846 RVA: 0x005433D8 File Offset: 0x005415D8
	private void RefreshBtnEmpty()
	{
		base.GetItem(30).SetUIActive(false);
		base.GetButton(29).RootUIComp.Get().SetUIActive(false);
		base.GetHorizontalLayout(5).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x06013017 RID: 77847 RVA: 0x00543428 File Offset: 0x00541628
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnEntityCameraFinished, new Action<bool>(this.EntityCameraFinished));
		Singleton<EventSystem>.Instance.Add(EEventName.OnFirstShare, new Action(this.RefreshFirstShare));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
	}

	// Token: 0x06013018 RID: 77848 RVA: 0x00543488 File Offset: 0x00541688
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnEntityCameraFinished, new Action<bool>(this.EntityCameraFinished));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFirstShare, new Action(this.RefreshFirstShare));
		Singleton<EventSystem>.Instance.Remove(EEventName.OpenView, new Action<EUiViewName, int>(this.OnOpenView));
	}

	// Token: 0x06013019 RID: 77849 RVA: 0x005434E5 File Offset: 0x005416E5
	protected override void OnAfterShow()
	{
		if (this.CaptureFullScene)
		{
			this.PlayScreenShotSequence();
			return;
		}
		if (this.PrepareFullScreenShot)
		{
			this.RefreshFullScreenPhotoPanel(true);
			this.RefreshMarkItem(true);
			this.OnAfterShowPrepareFullScreenAsync().Forget();
			return;
		}
		this.PlayScreenShotSequence();
	}

	// Token: 0x0601301A RID: 77850 RVA: 0x00543520 File Offset: 0x00541720
	private UniTask OnAfterShowPrepareFullScreenAsync()
	{
		PhotoSaveView.<OnAfterShowPrepareFullScreenAsync>d__62 <OnAfterShowPrepareFullScreenAsync>d__;
		<OnAfterShowPrepareFullScreenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnAfterShowPrepareFullScreenAsync>d__.<>4__this = this;
		<OnAfterShowPrepareFullScreenAsync>d__.<>1__state = -1;
		<OnAfterShowPrepareFullScreenAsync>d__.<>t__builder.Start<PhotoSaveView.<OnAfterShowPrepareFullScreenAsync>d__62>(ref <OnAfterShowPrepareFullScreenAsync>d__);
		return <OnAfterShowPrepareFullScreenAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601301B RID: 77851 RVA: 0x00543563 File Offset: 0x00541763
	protected override void OnBeforeDestroy()
	{
		UKuroRenderingRuntimeBPPluginBPLibrary.ReleaseGetSceneColorShotBefore();
		GenericLayout<PhotoShareBtnItem, EChannelShare> shareBtnLayout = this.ShareBtnLayout;
		if (shareBtnLayout != null)
		{
			shareBtnLayout.ClearChildren();
		}
		this.ShareBtnLayout = null;
		this.Reset();
	}

	// Token: 0x0601301C RID: 77852 RVA: 0x00543588 File Offset: 0x00541788
	private float[] GetCaptureRange()
	{
		UUIItem item = base.GetItem(this.IsPhoto ? 11 : 23);
		UUIItem item2 = base.GetItem(this.IsPhoto ? 12 : 24);
		FVector2D positionInViewPort = item.GetPositionInViewPort(true);
		FVector2D positionInViewPort2 = item2.GetPositionInViewPort(true);
		FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
		float num = (positionInViewPort.X < 0f) ? 0f : positionInViewPort.X;
		float num2 = (positionInViewPort.Y < 0f) ? 0f : positionInViewPort.Y;
		float num3 = (positionInViewPort2.X < viewportSize.X) ? positionInViewPort2.X : viewportSize.X;
		float num4 = (positionInViewPort2.Y < viewportSize.Y) ? positionInViewPort2.Y : viewportSize.Y;
		return new float[]
		{
			num,
			num2,
			num3,
			num4
		};
	}

	// Token: 0x0601301D RID: 77853 RVA: 0x00543668 File Offset: 0x00541868
	private void PlayScreenShotSequence()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("ScreenShot", false, null);
	}

	// Token: 0x0601301E RID: 77854 RVA: 0x00543694 File Offset: 0x00541894
	private unsafe void OnClickShareBtn(EChannelShare channel, int shareConfigId)
	{
		Singleton<Log>.Instance.Info(ELogModule.Photo, ELogAuthor.BB, "点击分享截图按钮", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.TakeScreenshot(false, delegate(int width, int height, TArray<FColor> colors)
		{
			TArray<byte> tarray = new TArray<byte>();
			UKuroGameScreenshotBPLibrary.CompressConvertColorsToBitmap(width, height, colors, ref tarray);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Photo;
			ELogAuthor author = ELogAuthor.BB;
			string message = "截图完成，压缩截图结果进行分享";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("width", width);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("height", height);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ColorSize", (colors != null) ? new int?(colors.Num()) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("bitMapSize", (tarray != null) ? new int?(tarray.Num()) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			ControllerBase<ChannelController>.Instance.ShareChannel(channel, tarray, this.ShareActionId, shareConfigId, this.ShareReportExtraType);
		}, null, null);
	}

	// Token: 0x0601301F RID: 77855 RVA: 0x005436F0 File Offset: 0x005418F0
	private void OnClickedConfirmButton()
	{
		Singleton<Log>.Instance.Info(ELogModule.Photo, ELogAuthor.BB, "点击保存截图按钮", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ControllerBase<KuroSdkController>.Instance.CheckPhotoPermission())
		{
			this.TakeScreenshot(true, new Action<int, int, TArray<FColor>>(this.OnTakePhoto), new Action<bool>(this.OnIOSPhotoLibraryAuthorizationCompleted), new FOnTakeScreenshotCompressed.FOnTakeScreenshotCompressed_ScriptDelegate(this.OnPhotoCompressed));
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhotoPermissionRequest);
		Action value = delegate()
		{
			if (base.IsDestroyOrDestroying || base.IsHideOrHiding)
			{
				Singleton<Log>.Instance.Error(ELogModule.Photo, ELogAuthor.BB, "相册权限确认回调时PhotoSaveView已失效，取消请求权限", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (ControllerBase<PhotographController>.Instance.CouldRequestPhotoPermission())
			{
				LocalStorage.SetGlobal<double>(ELocalStorageGlobalKey.RequestPhotoPermissionMinTime, Singleton<TimeUtil>.Instance.GetServerTime() + (double)ConfigCommonParamById.GetIntConfig("PermissionRequestsTimeId").Value);
				ControllerBase<KuroSdkController>.Instance.RequestPhotoPermission(new Action<bool>(this.OnRequestPermissionCallback));
				return;
			}
			this.OnPhotoPermissionDenied();
		};
		confirmBoxDataNew.FunctionMap[1] = new Action(this.OnPhotoPermissionDenied);
		confirmBoxDataNew.FunctionMap[2] = value;
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06013020 RID: 77856 RVA: 0x0054379D File Offset: 0x0054199D
	private void OnRequestPermissionCallback(bool isAllowed)
	{
		if (isAllowed)
		{
			this.TakeScreenshot(true, new Action<int, int, TArray<FColor>>(this.OnTakePhoto), new Action<bool>(this.OnIOSPhotoLibraryAuthorizationCompleted), null);
			return;
		}
		this.OnPhotoPermissionDenied();
	}

	// Token: 0x06013021 RID: 77857 RVA: 0x005437CC File Offset: 0x005419CC
	private void OnPhotoPermissionDenied()
	{
		ESourcePlatformType platformType = Singleton<Info>.Instance.PlatformType;
		if (platformType == ESourcePlatformType.IOS)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("Privilege_album_IOS", Array.Empty<object>());
			return;
		}
		if (platformType == ESourcePlatformType.Android)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("Privilege_album_Android", Array.Empty<object>());
			return;
		}
		if (platformType != ESourcePlatformType.OpenHarmony)
		{
			return;
		}
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("Privilege_album_Android", Array.Empty<object>());
	}

	// Token: 0x06013022 RID: 77858 RVA: 0x00543830 File Offset: 0x00541A30
	private string GetPhotoName()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		return Singleton<TimeUtil>.Instance.DateFormatString2(serverTime) + ".png";
	}

	// Token: 0x06013023 RID: 77859 RVA: 0x00543860 File Offset: 0x00541A60
	private void PrepareScreenShot(bool isFirst, Action onPrepareFinish)
	{
		float[] captureRange = this.GetCaptureRange();
		FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
		UGameScreenshotTask ugameScreenshotTask = ScreenShotManager.PrepareTakeScreenshot("", (float)((int)captureRange[0]), (float)((int)captureRange[1]), (float)((int)captureRange[2]), (float)((int)captureRange[3]), false, viewportSize.X, viewportSize.Y, 1);
		if (ugameScreenshotTask == null)
		{
			return;
		}
		ugameScreenshotTask.OnTakeScreenshotCapturedDelegate.Clear();
		ugameScreenshotTask.OnTakeScreenshotCapturedDelegate.Add(delegate(int width, int height, in TArray<FColor> colors)
		{
			if ((this.IsShowPlayerName & isFirst) || (!this.IsShowPlayerName && !isFirst))
			{
				this.CurrentTakeColors = colors;
				this.CurrentTakeWidth = width;
				this.CurrentTakeHeight = height;
			}
			else
			{
				this.CurrentWatermarkTakeColors = colors;
				this.CurrentWatermarkTakeWidth = width;
				this.CurrentWatermarkTakeHeight = height;
			}
			onPrepareFinish();
		});
		ugameScreenshotTask.TakeScreenshot();
	}

	// Token: 0x06013024 RID: 77860 RVA: 0x005438F4 File Offset: 0x00541AF4
	[NullableContext(2)]
	private void TakeScreenshot(bool isSaveFile, [Nullable(new byte[]
	{
		1,
		2
	})] Action<int, int, TArray<FColor>> onTakeScreenShotCallback, Action<bool> onIOSPhotoLibraryAuthorizationCompleted = null, FOnTakeScreenshotCompressed.FOnTakeScreenshotCompressed_ScriptDelegate onPhotoCompressed = null)
	{
		string photoName = this.GetPhotoName();
		this.RelativeShotPath = this.GetRelativeShotPath(photoName);
		string storagePath = UBlueprintPathsLibrary.ProjectUserDir() + this.RelativeShotPath;
		FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
		int multiplierScale = this.GetSafeMultiplierScale(viewportSize);
		if (this.CaptureFullScene & isSaveFile)
		{
			UUIItem rootItem = base.GetRootItem();
			if (rootItem != null)
			{
				rootItem.SetUIActive(false);
			}
			ULGUIBPLibrary.ResetGlobalBlurUIItem(GlobalData.GameInstance.GetWorld());
			Singleton<EventSystem>.Instance.Emit<bool, bool>(EEventName.OnPhotographViewCaptureMode, true, this.IsShowPlayerName);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPreparePhotoScreenShot, false);
			Action restorePhotographUi = delegate()
			{
				Singleton<EventSystem>.Instance.Emit<bool, bool>(EEventName.OnPhotographViewCaptureMode, false, false);
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPreparePhotoScreenShot, true);
			};
			Action<int, int, TArray<FColor>> <>9__2;
			TimerSystem.GameplayTimeInstance.Next(delegate(float _)
			{
				PhotoSaveView <>4__this = this;
				string storagePath = storagePath;
				int minX = 0;
				int minY = 0;
				FVector2D viewportSize;
				int maxX = (int)viewportSize.X;
				int maxY = (int)viewportSize.Y;
				bool isSaveFile2 = isSaveFile;
				viewportSize = viewportSize;
				int multiplierScale = multiplierScale;
				bool isHighRes = true;
				Action<int, int, TArray<FColor>> onCaptured;
				if ((onCaptured = <>9__2) == null)
				{
					onCaptured = (<>9__2 = delegate(int w, int h, TArray<FColor> c)
					{
						restorePhotographUi();
						onTakeScreenShotCallback(w, h, c);
					});
				}
				if (!<>4__this.RunScreenShot(storagePath, minX, minY, maxX, maxY, isSaveFile2, viewportSize, multiplierScale, isHighRes, onCaptured, onIOSPhotoLibraryAuthorizationCompleted, onPhotoCompressed))
				{
					Singleton<Log>.Instance.Error(ELogModule.Photo, ELogAuthor.CXJ, "延迟场景截图：PrepareTakeScreenshot 返回 undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
					restorePhotographUi();
					UUIItem rootItem2 = this.GetRootItem();
					if (rootItem2 != null)
					{
						rootItem2.SetUIActive(true);
					}
					Singleton<UiBlurLogic>.Instance.SetNormalUiRenderAfterBlur(this);
				}
			}, null, null);
			return;
		}
		float[] captureRange = this.GetCaptureRange();
		this.RunScreenShot(storagePath, (int)captureRange[0], (int)captureRange[1], (int)captureRange[2], (int)captureRange[3], isSaveFile, viewportSize, multiplierScale, false, onTakeScreenShotCallback, onIOSPhotoLibraryAuthorizationCompleted, onPhotoCompressed);
	}

	// Token: 0x06013025 RID: 77861 RVA: 0x00543A5C File Offset: 0x00541C5C
	[NullableContext(2)]
	private bool RunScreenShot([Nullable(1)] string storagePath, int minX, int minY, int maxX, int maxY, bool isSaveFile, FVector2D viewportSize, int multiplierScale, bool isHighRes, [Nullable(new byte[]
	{
		1,
		2
	})] Action<int, int, TArray<FColor>> onCaptured, Action<bool> onIOSPhotoLibraryAuthorizationCompleted = null, FOnTakeScreenshotCompressed.FOnTakeScreenshotCompressed_ScriptDelegate onPhotoCompressed = null)
	{
		UGameScreenshotTask ugameScreenshotTask = ScreenShotManager.PrepareTakeScreenshot(storagePath, (float)minX, (float)minY, (float)maxX, (float)maxY, isSaveFile, viewportSize.X, viewportSize.Y, multiplierScale);
		if (ugameScreenshotTask == null)
		{
			return false;
		}
		ugameScreenshotTask.OnTakeScreenshotCapturedDelegate.Add(delegate(int w, int h, in TArray<FColor> c)
		{
			onCaptured(w, h, c);
		});
		if (onIOSPhotoLibraryAuthorizationCompleted != null)
		{
			ugameScreenshotTask.OnIOSPhotoLibraryAuthorizationCompletedDelegate.Add(onIOSPhotoLibraryAuthorizationCompleted);
		}
		if (onPhotoCompressed != null)
		{
			ugameScreenshotTask.OnTakeScreenshotCompressedDelegate.Add(onPhotoCompressed);
		}
		if (isHighRes)
		{
			ugameScreenshotTask.TakeScreenshotHighRes(multiplierScale);
		}
		else
		{
			ugameScreenshotTask.TakeScreenshot();
		}
		return true;
	}

	// Token: 0x06013026 RID: 77862 RVA: 0x00543AF0 File Offset: 0x00541CF0
	private int GetSafeMultiplierScale(FVector2D viewportSize)
	{
		Dictionary<int, int> dictionary = LocalStorage.GetGlobal<Dictionary<int, int>>(ELocalStorageGlobalKey.PhotographSetupOption, null) ?? new Dictionary<int, int>();
		int? num = dictionary.ContainsKey(8) ? new int?(dictionary[8]) : null;
		PhotoDropDown? photoDropDown = (num != null) ? ConfigPhotoDropDownById.GetConfig(num.Value, true) : null;
		int num2 = (photoDropDown != null) ? int.Parse(photoDropDown.Value.Param()[0]) : 1;
		int? intConfig = ConfigCommonParamById.GetIntConfig("PhotoMaxAllowedResolution");
		int? num3 = intConfig;
		int num4 = 0;
		if (num3.GetValueOrDefault() > num4 & num3 != null)
		{
			float num5 = Math.Max(viewportSize.X, viewportSize.Y) * (float)num2;
			num3 = intConfig;
			float? num6 = (num3 != null) ? new float?((float)num3.GetValueOrDefault()) : null;
			if (num5 > num6.GetValueOrDefault() & num6 != null)
			{
				num2 = 1;
			}
		}
		return num2;
	}

	// Token: 0x06013027 RID: 77863 RVA: 0x00543BF8 File Offset: 0x00541DF8
	[NullableContext(2)]
	private unsafe void OnTakePhoto(int width, int height, TArray<FColor> colors)
	{
		if (this.CurrentTakeColors == null || width > this.CurrentTakeWidth)
		{
			this.CurrentTakeWidth = width;
			this.CurrentTakeHeight = height;
			this.CurrentTakeColors = colors;
		}
		else if (this.IsShowPlayerName)
		{
			this.CurrentTakeColors = this.CurrentWatermarkTakeColors;
			this.CurrentTakeWidth = this.CurrentWatermarkTakeWidth;
			this.CurrentTakeHeight = this.CurrentWatermarkTakeHeight;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Photo;
		ELogAuthor author = ELogAuthor.BB;
		string message = "截图完成，截图结果进行保存";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("width", width);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("height", height);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ColorSize", (colors != null) ? new int?(colors.Num()) : null);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		ESourcePlatformType platformType = Singleton<Info>.Instance.PlatformType;
		if (platformType <= ESourcePlatformType.Android)
		{
			if (platformType != ESourcePlatformType.IOS)
			{
				if (platformType == ESourcePlatformType.Android)
				{
					TArray<byte> tarray = new TArray<byte>();
					UKuroGameScreenshotBPLibrary.ConvertColorsToBitmap(this.CurrentTakeWidth, this.CurrentTakeHeight, this.CurrentTakeColors, ref tarray);
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Photo;
					ELogAuthor author2 = ELogAuthor.BB;
					string message2 = "截图保存至Android相册";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bitmapSize", (tarray != null) ? new int?(tarray.Num()) : null);
					instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					UKuroGameScreenshotBPLibrary.SaveColorArrayToAndroidAlbum(this.CurrentTakeWidth, this.CurrentTakeHeight, tarray);
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("SaveGalleryPathTips", Array.Empty<object>());
					goto IL_3C2;
				}
			}
			else
			{
				if (!UKuroGameScreenshotBPLibrary.IsPhotoLibraryAuthorized())
				{
					Singleton<Log>.Instance.Info(ELogModule.Photo, ELogAuthor.BB, "没有获得IOS相册权限，请求权限，请求完成后再次尝试截图", default(ReadOnlySpan<ValueTuple<string, object>>));
					ScreenShotManager.RequestIOSPhotoLibraryAuthorization();
					return;
				}
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Photo;
				ELogAuthor author3 = ELogAuthor.BB;
				string message3 = "截图保存IOS相册";
				string item = "colors";
				TArray<FColor> currentTakeColors = this.CurrentTakeColors;
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>(item, (currentTakeColors != null) ? new int?(currentTakeColors.Num()) : null);
				instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				UKuroGameScreenshotBPLibrary.SaveColorArrayToIosAlbum(this.CurrentTakeWidth, this.CurrentTakeHeight, this.CurrentTakeColors);
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("SaveGalleryPathTips", Array.Empty<object>());
				goto IL_3C2;
			}
		}
		else
		{
			if (platformType == ESourcePlatformType.PS5)
			{
				goto IL_3C2;
			}
			if (platformType == ESourcePlatformType.OpenHarmony)
			{
				TArray<byte> tarray2 = new TArray<byte>();
				UKuroGameScreenshotBPLibrary.CompressConvertColorsToBitmap(this.CurrentTakeWidth, this.CurrentTakeHeight, this.CurrentTakeColors, ref tarray2);
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.Photo;
				ELogAuthor author4 = ELogAuthor.BB;
				string message4 = "截图保存至鸿蒙相册";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("bitmapSize", (tarray2 != null) ? new int?(tarray2.Num()) : null);
				instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				UKuroGameScreenshotBPLibrary.SaveColorArrayToOpenHarmonyAlbum(this.CurrentTakeWidth, this.CurrentTakeHeight, tarray2);
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("SaveGalleryPathTips", Array.Empty<object>());
				goto IL_3C2;
			}
		}
		string photoName = this.GetPhotoName();
		this.RelativeShotPath = this.GetRelativeShotPath(photoName);
		string filePath = UBlueprintPathsLibrary.ProjectUserDir() + this.RelativeShotPath;
		bool flag = this.CurrentTakeColors != null && this.CurrentTakeWidth >= width;
		int width2 = flag ? this.CurrentTakeWidth : width;
		int height2 = flag ? this.CurrentTakeHeight : height;
		TArray<FColor> tarray3 = flag ? this.CurrentTakeColors : colors;
		UKuroGameScreenshotBPLibrary.SaveScreenshot(filePath, width2, height2, tarray3);
		Log instance5 = Singleton<Log>.Instance;
		ELogModule module5 = ELogModule.Photo;
		ELogAuthor author5 = ELogAuthor.BB;
		string message5 = "截图保存至游戏安装文件夹";
		ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("path", this.RelativeShotPath);
		instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
		if (!Singleton<Platform>.Instance.IsCloudGame())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("SavePathTips", new object[]
			{
				this.RelativeShotPath
			});
		}
		IL_3C2:
		this.ClosePhotoSaveView();
	}

	// Token: 0x06013028 RID: 77864 RVA: 0x00543FD0 File Offset: 0x005421D0
	[NullableContext(2)]
	private void OnPhotoCompressed(in TArray<byte> compressedBitmap)
	{
		Singleton<Log>.Instance.Info(ELogModule.Photo, ELogAuthor.BB, "PS Test OnPhotoCompressed", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.PS5)
		{
			string photoName = this.GetPhotoName();
			UGameplayStatics.ExportPngPhotoFromData(compressedBitmap, photoName);
		}
	}

	// Token: 0x06013029 RID: 77865 RVA: 0x00544018 File Offset: 0x00542218
	private unsafe void OnIOSPhotoLibraryAuthorizationCompleted(bool isGranted)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Photo;
		ELogAuthor author = ELogAuthor.BB;
		string message = "允许权限后重新截图";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("isGranted", isGranted);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("width", this.CurrentTakeWidth);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("height", this.CurrentTakeHeight);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
		string item = "colorsSize";
		TArray<FColor> currentTakeColors = this.CurrentTakeColors;
		ptr = new ValueTuple<string, object>(item, (currentTakeColors != null) ? new int?(currentTakeColors.Num()) : null);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		if (!isGranted)
		{
			this.ClosePhotoSaveView();
			return;
		}
		if (this.CurrentTakeWidth <= 0 || this.CurrentTakeHeight <= 0 || this.CurrentTakeColors == null)
		{
			this.ClosePhotoSaveView();
			return;
		}
		UKuroGameScreenshotBPLibrary.SaveColorArrayToIosAlbum(this.CurrentTakeWidth, this.CurrentTakeHeight, this.CurrentTakeColors);
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("SaveGalleryPathTips", Array.Empty<object>());
		this.ClosePhotoSaveView();
	}

	// Token: 0x0601302A RID: 77866 RVA: 0x00544143 File Offset: 0x00542343
	private void ClosePhotoSaveView()
	{
		if (ControllerBase<PhotographController>.Instance.CheckIfInEntityCamera())
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.PhotoSaveView, null);
			ControllerBase<PhotographController>.Instance.ClosePhotograph(true);
			return;
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.PhotoSaveView, null);
	}

	// Token: 0x0601302B RID: 77867 RVA: 0x0054417E File Offset: 0x0054237E
	private string GetRelativeShotPath(string photoName)
	{
		return ModelBase<PhotographModel>.Instance.SavePath + photoName;
	}

	// Token: 0x0601302C RID: 77868 RVA: 0x00544190 File Offset: 0x00542390
	private void OnClickedCloseButton()
	{
		if (!this.IsPhoto)
		{
			base.CloseMe(null);
			return;
		}
		this.ClosePhotoSaveView();
	}

	// Token: 0x0601302D RID: 77869 RVA: 0x005441A8 File Offset: 0x005423A8
	private void OnClickRetake()
	{
		ControllerBase<PhotographController>.Instance.ResetShotStateForRetake();
		ControllerBase<PhotographController>.Instance.UpdateMissionOptionToFinished(false);
		base.CloseMe(null);
	}

	// Token: 0x0601302E RID: 77870 RVA: 0x005441C6 File Offset: 0x005423C6
	private void OnClickPersonalInfoShow(EToggleState toggleState)
	{
		LocalStorage.SetGlobal<bool>(ELocalStorageGlobalKey.PhotoAndShareShowPlayerName, toggleState == EToggleState.ETT_Checked);
		this.IsShowPlayerName = (toggleState == EToggleState.ETT_Checked);
		PhotoSaveMarkItem markItem = this.MarkItem;
		if (markItem != null)
		{
			markItem.SetUiActive(toggleState == EToggleState.ETT_Checked);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnPhotoSaveViewPersonalInfoShowRefresh);
	}

	// Token: 0x0601302F RID: 77871 RVA: 0x00544204 File Offset: 0x00542404
	private void EntityCameraFinished(bool judgement)
	{
		if (!ControllerBase<PhotographController>.Instance.CheckIfInMission())
		{
			base.GetItem(7).SetUIActive(false);
			base.GetSprite(9).SetUIActive(false);
			base.GetSprite(8).SetUIActive(false);
			return;
		}
		if (judgement)
		{
			base.GetItem(7).SetUIActive(true);
			base.GetSprite(9).SetUIActive(true);
			base.GetSprite(8).SetUIActive(false);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(10), "FindAllConditionsTrue", Array.Empty<object>());
			this.RefreshBtnEmpty();
			return;
		}
		base.GetItem(7).SetUIActive(true);
		base.GetSprite(9).SetUIActive(false);
		base.GetSprite(8).SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(10), "FindAllConditionsFalse", Array.Empty<object>());
		this.RefreshRetakeBtn();
	}

	// Token: 0x06013030 RID: 77872 RVA: 0x005442E0 File Offset: 0x005424E0
	private void RefreshFirstShare()
	{
		bool flag = !ControllerBase<PhotographController>.Instance.CheckIfInEntityCamera() && ModelBase<ChannelModel>.Instance.CouldGetShareReward(this.ShareActionId);
		base.GetItem(this.IsPhoto ? 27 : 28).SetUIActive(flag);
		if (flag)
		{
			ShareReward? config = ConfigShareRewardById.GetConfig((int)this.ShareActionId, true);
			if (config == null)
			{
				return;
			}
			Dictionary<int, int> dictionary = config.Value.Reward();
			int itemConfigId = 0;
			int num = 0;
			using (Dictionary<int, int>.Enumerator enumerator = dictionary.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<int, int> keyValuePair = enumerator.Current;
					itemConfigId = keyValuePair.Key;
					num = keyValuePair.Value;
				}
			}
			string iconSmall = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemConfigId).Value.IconSmall;
			UUITexture texture = base.GetTexture(this.IsPhoto ? 32 : 33);
			texture.SetUIActive(false);
			base.SetTextureByPath(iconSmall, texture, null, delegate(bool _)
			{
				texture.SetUIActive(true);
			});
			base.GetText(this.IsPhoto ? 25 : 26).SetText(num.ToString(), true);
		}
	}

	// Token: 0x06013031 RID: 77873 RVA: 0x00544438 File Offset: 0x00542638
	private void OnOpenView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.PhotoSaveView || viewName == EUiViewName.NetWorkMaskView || viewName == EUiViewName.ConfirmBoxView)
		{
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x06013032 RID: 77874 RVA: 0x0054446C File Offset: 0x0054266C
	private void Reset()
	{
		this.CurrentTakeWidth = 0;
		this.CurrentTakeHeight = 0;
		this.CurrentTakeColors = null;
		Singleton<UiLayer>.Instance.SetLayerActive(ELayerType.Float, true);
		Singleton<UiLayer>.Instance.SetLayerActive(ELayerType.Pop, true);
		ControllerBase<LoadingController>.Instance.UpdateUidViewShow();
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.PhotographView))
		{
			Singleton<UiLayer>.Instance.SetLayerActive(ELayerType.HUD, true);
		}
		ScreenShotManager.ResetScreenShot();
	}

	// Token: 0x06013033 RID: 77875 RVA: 0x005444D8 File Offset: 0x005426D8
	private UniTask WaitForNextTick()
	{
		PhotoSaveView.<WaitForNextTick>d__87 <WaitForNextTick>d__;
		<WaitForNextTick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<WaitForNextTick>d__.<>1__state = -1;
		<WaitForNextTick>d__.<>t__builder.Start<PhotoSaveView.<WaitForNextTick>d__87>(ref <WaitForNextTick>d__);
		return <WaitForNextTick>d__.<>t__builder.Task;
	}

	// Token: 0x06013034 RID: 77876 RVA: 0x00544514 File Offset: 0x00542714
	private UniTask PrepareScreenShotAsync(bool isFirst)
	{
		PhotoSaveView.<PrepareScreenShotAsync>d__88 <PrepareScreenShotAsync>d__;
		<PrepareScreenShotAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PrepareScreenShotAsync>d__.<>4__this = this;
		<PrepareScreenShotAsync>d__.isFirst = isFirst;
		<PrepareScreenShotAsync>d__.<>1__state = -1;
		<PrepareScreenShotAsync>d__.<>t__builder.Start<PhotoSaveView.<PrepareScreenShotAsync>d__88>(ref <PrepareScreenShotAsync>d__);
		return <PrepareScreenShotAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013035 RID: 77877 RVA: 0x0054455F File Offset: 0x0054275F
	[CompilerGenerated]
	internal static int <GetSortTenGachaInfos>g__RevertType|39_0(InventoryDefine.EItemDataType type)
	{
		switch (type)
		{
		case InventoryDefine.EItemDataType.RoleItem:
			return 2;
		case InventoryDefine.EItemDataType.WeaponItem:
			return 1;
		}
		return 0;
	}

	// Token: 0x04009429 RID: 37929
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<PhotoShareBtnItem, EChannelShare> ShareBtnLayout;

	// Token: 0x0400942A RID: 37930
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<GachaShareSwitchItem, GachaShareSwitchData> GachaSwitchLayout;

	// Token: 0x0400942B RID: 37931
	private bool IsPhoto = true;

	// Token: 0x0400942C RID: 37932
	private bool PrepareFullScreenShot;

	// Token: 0x0400942D RID: 37933
	private bool CaptureFullScene;

	// Token: 0x0400942E RID: 37934
	private string RelativeShotPath = "";

	// Token: 0x0400942F RID: 37935
	[Nullable(2)]
	private PhotoSaveMarkItem MarkItem;

	// Token: 0x04009430 RID: 37936
	[Nullable(2)]
	private GachaShareOnePanel GachaView;

	// Token: 0x04009431 RID: 37937
	[Nullable(2)]
	private GachaShareTenPanel GachaViewTen;

	// Token: 0x04009432 RID: 37938
	[Nullable(2)]
	private FragmentMemoryShareView FragmentMemoryShareViewRef;

	// Token: 0x04009433 RID: 37939
	[Nullable(2)]
	private RoleSkinShareView RoleSkinShareView;

	// Token: 0x04009434 RID: 37940
	[Nullable(2)]
	private VersionPreheatSharePanel VersionPreheatView;

	// Token: 0x04009435 RID: 37941
	[Nullable(2)]
	private Spring25SharePanel Spring25View;

	// Token: 0x04009436 RID: 37942
	[Nullable(2)]
	private HandBookPhotoShareView HandBookPhotoShareView;

	// Token: 0x04009437 RID: 37943
	[Nullable(2)]
	private TowerVariationShareView TowerVariationShareView;

	// Token: 0x04009438 RID: 37944
	private WheelTowerTotalScoreSharePanel WheelTowerTotalScoreView;

	// Token: 0x04009439 RID: 37945
	private WheelTowerSettlementShareView WheelTowerSettlementShareView;

	// Token: 0x0400943A RID: 37946
	private ShipTowerSharePanel ChallengeRecordShareView;

	// Token: 0x0400943B RID: 37947
	private EShareActionId ShareActionId = EShareActionId.Photo;

	// Token: 0x0400943C RID: 37948
	private EShareReportExtraType ShareReportExtraType;

	// Token: 0x0400943D RID: 37949
	private int CurrentTakeWidth;

	// Token: 0x0400943E RID: 37950
	private int CurrentTakeHeight;

	// Token: 0x0400943F RID: 37951
	[Nullable(2)]
	private TArray<FColor> CurrentTakeColors;

	// Token: 0x04009440 RID: 37952
	private int CurrentWatermarkTakeWidth;

	// Token: 0x04009441 RID: 37953
	private int CurrentWatermarkTakeHeight;

	// Token: 0x04009442 RID: 37954
	[Nullable(2)]
	private TArray<FColor> CurrentWatermarkTakeColors;

	// Token: 0x04009443 RID: 37955
	private FVector? PanelItemOriginalScale;

	// Token: 0x04009444 RID: 37956
	private bool IsShowPlayerName;

	// Token: 0x02008961 RID: 35169
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E5A9 RID: 189865
		PhotoTexture,
		// Token: 0x0402E5AA RID: 189866
		PhotoFrameItem,
		// Token: 0x0402E5AB RID: 189867
		CloseButton,
		// Token: 0x0402E5AC RID: 189868
		BlackBgSprite,
		// Token: 0x0402E5AD RID: 189869
		BtnParent,
		// Token: 0x0402E5AE RID: 189870
		ShareBtnLayout,
		// Token: 0x0402E5AF RID: 189871
		SaveButton,
		// Token: 0x0402E5B0 RID: 189872
		PnlTips,
		// Token: 0x0402E5B1 RID: 189873
		SprCross,
		// Token: 0x0402E5B2 RID: 189874
		SprTick,
		// Token: 0x0402E5B3 RID: 189875
		TxtConditions,
		// Token: 0x0402E5B4 RID: 189876
		MinItemPhoto,
		// Token: 0x0402E5B5 RID: 189877
		MaxItemPhoto,
		// Token: 0x0402E5B6 RID: 189878
		PhotoItem,
		// Token: 0x0402E5B7 RID: 189879
		PhotoPanel,
		// Token: 0x0402E5B8 RID: 189880
		LandscapePanel,
		// Token: 0x0402E5B9 RID: 189881
		TypeText,
		// Token: 0x0402E5BA RID: 189882
		NameText,
		// Token: 0x0402E5BB RID: 189883
		DateText,
		// Token: 0x0402E5BC RID: 189884
		LandscapeTexture,
		// Token: 0x0402E5BD RID: 189885
		DescriptionText,
		// Token: 0x0402E5BE RID: 189886
		MarkItemPhoto,
		// Token: 0x0402E5BF RID: 189887
		MarkItemLandscape,
		// Token: 0x0402E5C0 RID: 189888
		MinItemLandscape,
		// Token: 0x0402E5C1 RID: 189889
		MaxItemLandscape,
		// Token: 0x0402E5C2 RID: 189890
		TxtCostPhoto,
		// Token: 0x0402E5C3 RID: 189891
		TxtCostLandscape,
		// Token: 0x0402E5C4 RID: 189892
		FirstPhoto,
		// Token: 0x0402E5C5 RID: 189893
		FirstLandscape,
		// Token: 0x0402E5C6 RID: 189894
		RetakeButton,
		// Token: 0x0402E5C7 RID: 189895
		LineParent,
		// Token: 0x0402E5C8 RID: 189896
		LineItem,
		// Token: 0x0402E5C9 RID: 189897
		TextureCostPhoto,
		// Token: 0x0402E5CA RID: 189898
		TextureCostLandscape,
		// Token: 0x0402E5CB RID: 189899
		PersonalInfoTogglePhoto,
		// Token: 0x0402E5CC RID: 189900
		PersonalInfoToggleLandscape,
		// Token: 0x0402E5CD RID: 189901
		SubViewRoot,
		// Token: 0x0402E5CE RID: 189902
		ExternalTexture,
		// Token: 0x0402E5CF RID: 189903
		GachaSwitchLayout,
		// Token: 0x0402E5D0 RID: 189904
		GachaSwitchItem
	}
}
