using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BlackScreen;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Menu;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D04 RID: 7428
[NullableContext(1)]
[Nullable(0)]
public class GachaResultView : GachaSceneView
{
	// Token: 0x0600DA0E RID: 55822 RVA: 0x003A815C File Offset: 0x003A635C
	public GachaResultView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600DA0F RID: 55823 RVA: 0x003A81BC File Offset: 0x003A63BC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, this.NextBtn),
			new ValueTuple<int, Delegate>(6, this.OnClickShare)
		};
	}

	// Token: 0x0600DA10 RID: 55824 RVA: 0x003A82CC File Offset: 0x003A64CC
	protected override void OnAfterInitComponentsData()
	{
		IGachaViewOpenData gachaViewOpenData = this.OpenParam as IGachaViewOpenData;
		this.HideExtraReward = (gachaViewOpenData != null && gachaViewOpenData.ResultViewHideExtraReward);
	}

	// Token: 0x0600DA11 RID: 55825 RVA: 0x003A82F8 File Offset: 0x003A64F8
	protected override UniTask OnBeforeStartAsync()
	{
		GachaResultView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GachaResultView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DA12 RID: 55826 RVA: 0x003A833B File Offset: 0x003A653B
	protected override void OnBeforeShow()
	{
		ControllerBase<BlackScreenController>.Instance.RemoveBlackScreen("Close", "GachaSkip");
		this.RefreshShare();
	}

	// Token: 0x0600DA13 RID: 55827 RVA: 0x003A8357 File Offset: 0x003A6557
	protected override void OnAfterShow()
	{
		ControllerBase<KuroSdkController>.Instance.TryOpenReview();
	}

	// Token: 0x0600DA14 RID: 55828 RVA: 0x003A8364 File Offset: 0x003A6564
	protected override void OnBeforeDestroy()
	{
		CameraController instance = ControllerBase<CameraController>.Instance;
		UiCamera uiCamera = Singleton<UiCameraAnimationManager>.Instance.UiCamera;
		instance.SetViewTarget((uiCamera != null) ? uiCamera.GetCameraActor() : null, "GachaResultView.OnBeforeDestroy", 0f, EViewTargetBlendFunction.VTBlend_Linear, 0f, null, null, "MainCamera", null, null);
		ControllerBase<MenuController>.Instance.OpenAllFilter();
	}

	// Token: 0x0600DA15 RID: 55829 RVA: 0x003A83C4 File Offset: 0x003A65C4
	protected override void AfterAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnFirstShare, new Action(this.RefreshShare));
	}

	// Token: 0x0600DA16 RID: 55830 RVA: 0x003A83E2 File Offset: 0x003A65E2
	protected override void AfterRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFirstShare, new Action(this.RefreshShare));
	}

	// Token: 0x0600DA17 RID: 55831 RVA: 0x003A8400 File Offset: 0x003A6600
	private void RefreshShare()
	{
		if (!ControllerBase<ChannelController>.Instance.CouldShare())
		{
			return;
		}
		global::GachaResult[] curGachaResult = ModelBase<GachaModel>.Instance.CurGachaResult;
		int num;
		if (curGachaResult.Length == 1)
		{
			if (this.GetItemQuality(curGachaResult[0].Proto_GachaReward.ItemId) < 5)
			{
				return;
			}
			num = ((ConfigBase<GachaConfig>.Instance.GetItemIdType(curGachaResult[0].Proto_GachaReward.ItemId) == InventoryDefine.EItemDataType.WeaponItem) ? 4 : 3);
		}
		else
		{
			num = 5;
		}
		base.GetButton(6).RootUIComp.Get().SetUIActive(true);
		ShareReward? config = ConfigShareRewardById.GetConfig(num, true);
		if (config == null)
		{
			return;
		}
		bool flag = ModelBase<ChannelModel>.Instance.CouldGetShareReward((EShareActionId)num);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Gacha;
		ELogAuthor author = ELogAuthor.YZY;
		string message = "刷新分享按钮";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("showShareReward", flag);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		base.GetItem(7).SetUIActive(flag);
		if (flag)
		{
			List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
			foreach (KeyValuePair<int, int> keyValuePair in config.Value.Reward())
			{
				list.Add(new ValueTuple<int, int>(keyValuePair.Key, keyValuePair.Value));
			}
			ValueTuple<int, int> valueTuple2 = list[0];
			ShareRewardInfo shareRewardInfo = this.ShareRewardInfo;
			if (shareRewardInfo == null)
			{
				return;
			}
			shareRewardInfo.SetItemInfo(valueTuple2.Item1, valueTuple2.Item2);
		}
	}

	// Token: 0x0600DA18 RID: 55832 RVA: 0x003A8578 File Offset: 0x003A6778
	private int RewardItemSort(TItem a, TItem b)
	{
		int itemId = a.ItemData.ItemId;
		int itemId2 = b.ItemData.ItemId;
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
		int? num = (itemConfigData != null) ? new int?(itemConfigData.QualityId) : null;
		ItemConfig itemConfigData2 = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId2);
		int? num2 = (itemConfigData2 != null) ? new int?(itemConfigData2.QualityId) : null;
		int? num3 = num;
		int? num4 = num2;
		if (num3.GetValueOrDefault() == num4.GetValueOrDefault() & num3 != null == (num4 != null))
		{
			return itemId - itemId2;
		}
		return num2.Value - num.Value;
	}

	// Token: 0x0600DA19 RID: 55833 RVA: 0x003A8628 File Offset: 0x003A6828
	[NullableContext(2)]
	private void RefreshExtraReward(List<TItem> rewardArray)
	{
		if (rewardArray != null && rewardArray.Count > 0 && !this.HideExtraReward)
		{
			base.GetItem(0).SetUIActive(true);
			this.ExtraRewardLayout.RefreshByData(rewardArray.ToList<TItem>(), null, false);
			return;
		}
		base.GetItem(0).SetUIActive(false);
	}

	// Token: 0x0600DA1A RID: 55834 RVA: 0x003A8678 File Offset: 0x003A6878
	[NullableContext(2)]
	private void RefreshAdditionalReward(List<TItem> rewardArray)
	{
		if (rewardArray != null && rewardArray.Count > 0 && !this.HideExtraReward)
		{
			base.GetItem(2).SetUIActive(true);
			this.AdditionalRewardLayout.RefreshByData(rewardArray.ToList<TItem>(), null, false);
			return;
		}
		base.GetItem(2).SetUIActive(false);
	}

	// Token: 0x0600DA1B RID: 55835 RVA: 0x003A86C8 File Offset: 0x003A68C8
	public UniTask HandleMultiGacha(global::GachaResult[] dataList)
	{
		GachaResultView.<HandleMultiGacha>d__22 <HandleMultiGacha>d__;
		<HandleMultiGacha>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HandleMultiGacha>d__.<>4__this = this;
		<HandleMultiGacha>d__.dataList = dataList;
		<HandleMultiGacha>d__.<>1__state = -1;
		<HandleMultiGacha>d__.<>t__builder.Start<GachaResultView.<HandleMultiGacha>d__22>(ref <HandleMultiGacha>d__);
		return <HandleMultiGacha>d__.<>t__builder.Task;
	}

	// Token: 0x0600DA1C RID: 55836 RVA: 0x003A8714 File Offset: 0x003A6914
	private UniTask HandleSingleGacha(global::GachaResult data)
	{
		GachaResultView.<HandleSingleGacha>d__23 <HandleSingleGacha>d__;
		<HandleSingleGacha>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<HandleSingleGacha>d__.<>4__this = this;
		<HandleSingleGacha>d__.data = data;
		<HandleSingleGacha>d__.<>1__state = -1;
		<HandleSingleGacha>d__.<>t__builder.Start<GachaResultView.<HandleSingleGacha>d__23>(ref <HandleSingleGacha>d__);
		return <HandleSingleGacha>d__.<>t__builder.Task;
	}

	// Token: 0x0600DA1D RID: 55837 RVA: 0x003A8760 File Offset: 0x003A6960
	private void CoverRewardListToMap(IReadOnlyList<GachaReward> rewardList, Dictionary<int, int> rewardMap)
	{
		foreach (GachaReward reward in rewardList)
		{
			this.CoverRewardToMap(reward, rewardMap);
		}
	}

	// Token: 0x0600DA1E RID: 55838 RVA: 0x003A87AC File Offset: 0x003A69AC
	private void CoverRewardToMap(GachaReward reward, Dictionary<int, int> rewardMap)
	{
		int num2;
		int num = rewardMap.TryGetValue(reward.ItemId, out num2) ? num2 : 0;
		int value = reward.ItemCount + num;
		if (rewardMap.ContainsKey(reward.ItemId))
		{
			rewardMap[reward.ItemId] = value;
			return;
		}
		rewardMap.Add(reward.ItemId, value);
	}

	// Token: 0x0600DA1F RID: 55839 RVA: 0x003A8800 File Offset: 0x003A6A00
	[return: Nullable(2)]
	private List<TItem> CoverRewardMapToItemList(Dictionary<int, int> rewardMap)
	{
		if (rewardMap == null || rewardMap.Count == 0)
		{
			return null;
		}
		List<TItem> list = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in rewardMap)
		{
			TItem item = new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value);
			list.Add(item);
		}
		list.Sort(new Comparison<TItem>(this.RewardItemSort));
		return list;
	}

	// Token: 0x0600DA20 RID: 55840 RVA: 0x003A8890 File Offset: 0x003A6A90
	public int GetItemQuality(int itemId)
	{
		int result = 0;
		InventoryDefine.EItemDataType itemIdType = ConfigBase<GachaConfig>.Instance.GetItemIdType(itemId);
		if (itemIdType != InventoryDefine.EItemDataType.RoleItem)
		{
			if (itemIdType == InventoryDefine.EItemDataType.WeaponItem)
			{
				WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(itemId);
				if (weaponConfigByItemId != null)
				{
					result = weaponConfigByItemId.Value.QualityId;
				}
			}
		}
		else
		{
			RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(itemId);
			if (roleInfoById != null)
			{
				result = roleInfoById.Value.QualityId;
			}
		}
		return result;
	}

	// Token: 0x0600DA21 RID: 55841 RVA: 0x003A8904 File Offset: 0x003A6B04
	private GachaResultItemNew InitGachaResultItem()
	{
		return new GachaResultItemNew();
	}

	// Token: 0x0600DA22 RID: 55842 RVA: 0x003A890B File Offset: 0x003A6B0B
	private CommonItemSmallItemGrid InitRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600DA23 RID: 55843 RVA: 0x003A8912 File Offset: 0x003A6B12
	[CompilerGenerated]
	internal static int <HandleMultiGacha>g__RevertType|22_0(InventoryDefine.EItemDataType type)
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

	// Token: 0x0400680F RID: 26639
	private bool HideExtraReward;

	// Token: 0x04006810 RID: 26640
	[Nullable(2)]
	private GachaResultItemNew SingleGachaResultItem;

	// Token: 0x04006811 RID: 26641
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<GachaResultItemNew, global::GachaResult> GachaResultLayout;

	// Token: 0x04006812 RID: 26642
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> ExtraRewardLayout;

	// Token: 0x04006813 RID: 26643
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> AdditionalRewardLayout;

	// Token: 0x04006814 RID: 26644
	[Nullable(2)]
	private ShareRewardInfo ShareRewardInfo;

	// Token: 0x04006815 RID: 26645
	private readonly Action NextBtn = delegate()
	{
		if (Singleton<UiManager>.Instance.IsViewHide(EUiViewName.GachaScanView) || Singleton<UiManager>.Instance.IsViewHide(EUiViewName.DrawMainView))
		{
			Singleton<Log>.Instance.Info(ELogModule.Gacha, ELogAuthor.LPH, "点击过快，之前界面仍未关闭", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.CloseGachaSceneView);
	};

	// Token: 0x04006816 RID: 26646
	private readonly Action OnClickShare = delegate()
	{
		ControllerBase<ChannelController>.Instance.ShareGacha(ModelBase<GachaModel>.Instance.CurGachaResult);
	};

	// Token: 0x02008070 RID: 32880
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402BB03 RID: 178947
		ExtraRewardRootItem,
		// Token: 0x0402BB04 RID: 178948
		ExtraRewardGridLayout,
		// Token: 0x0402BB05 RID: 178949
		AdditionalRewardRootItem,
		// Token: 0x0402BB06 RID: 178950
		AdditionalRewardGridLayout,
		// Token: 0x0402BB07 RID: 178951
		NextBtn,
		// Token: 0x0402BB08 RID: 178952
		ContentRootItem,
		// Token: 0x0402BB09 RID: 178953
		ShareBtn,
		// Token: 0x0402BB0A RID: 178954
		ShareReward,
		// Token: 0x0402BB0B RID: 178955
		ShareRewardTip
	}
}
