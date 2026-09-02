using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200109E RID: 4254
[NullableContext(1)]
[Nullable(0)]
public class FurniturePresetItem : UiPanelBase
{
	// Token: 0x06006EE7 RID: 28391 RVA: 0x001CD69C File Offset: 0x001CB89C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUITexture)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnShopButtonClick))
		};
	}

	// Token: 0x06006EE8 RID: 28392 RVA: 0x001CD7CC File Offset: 0x001CB9CC
	protected override UniTask OnBeforeStartAsync()
	{
		FurniturePresetItem.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FurniturePresetItem.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006EE9 RID: 28393 RVA: 0x001CD810 File Offset: 0x001CBA10
	public void Refresh(FurnitureAreaData areaData)
	{
		this.AreaData = areaData;
		int areaId = areaData.GetAreaId();
		FurniturePresetConfig? furniturePresetConfig = ConfigBase<FurnitureConfig>.Instance.GetFurniturePresetConfig(areaId);
		this.UpdateGridItemDataList(furniturePresetConfig.Value);
		this.UpdateCostData();
		this.PresetScrollView.RefreshByData(this.GridItemDataList, null, false);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), furniturePresetConfig.Value.Name, Array.Empty<object>());
		base.SetTextureByPath(furniturePresetConfig.Value.Icon, base.GetTexture(1), null, null);
		bool flag = this.LockCount > 0;
		bool flag2 = this.LockCount == this.GridItemDataList.Count;
		bool flag3 = this.LockCount == 0;
		ButtonItem applyButtonItem = this.ApplyButtonItem;
		if (applyButtonItem != null)
		{
			applyButtonItem.SetEnableClick(!flag2);
		}
		ButtonItem applyButtonItem2 = this.ApplyButtonItem;
		if (applyButtonItem2 != null)
		{
			applyButtonItem2.SetLocalTextNew(flag3 ? "DIY_FoolproofWindow_SetAll_Button" : "DIY_FoolproofWindow_SetExist_Button", Array.Empty<object>());
		}
		ButtonItem fillAndApplyButtonItem = this.FillAndApplyButtonItem;
		if (fillAndApplyButtonItem != null)
		{
			fillAndApplyButtonItem.SetUiActive(flag);
		}
		if (flag)
		{
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.CurrencyId, 0);
			base.SetItemIcon(base.GetTexture(8), this.CurrencyId, null, null);
			UUIText text = base.GetText(9);
			text.SetText(this.NeedCostCurrency.ToString(), true);
			UUIItem uuiitem = text;
			bool bUseChangeColor = itemCountByConfigId < this.NeedCostCurrency;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			ButtonItem fillAndApplyButtonItem2 = this.FillAndApplyButtonItem;
			if (fillAndApplyButtonItem2 != null)
			{
				fillAndApplyButtonItem2.SetEnableClick(itemCountByConfigId >= this.NeedCostCurrency);
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "DIY_FoolproofWindow_FurList_Title", new <>z__ReadOnlyArray<object>(new object[]
		{
			this.GridItemDataList.Count - this.LockCount,
			this.GridItemDataList.Count
		}));
	}

	// Token: 0x06006EEA RID: 28394 RVA: 0x001CDA04 File Offset: 0x001CBC04
	private void UpdateGridItemDataList(FurniturePresetConfig furniturePresetConfig)
	{
		this.GridItemDataList.Clear();
		this.LockCount = 0;
		HashSet<int> hashSet = new HashSet<int>();
		foreach (IntArray intArray in furniturePresetConfig.FurniturePlaceInfo().Values)
		{
			foreach (int num in intArray.ArrayIntIter())
			{
				if (!hashSet.Contains(num))
				{
					hashSet.Add(num);
					Furniture? furnitureConfig = ConfigBase<FurnitureConfig>.Instance.GetFurnitureConfig(num);
					bool flag = !ModelBase<FurnitureModel>.Instance.GetIsFurnitureUnlockById(num);
					this.GridItemDataList.Add(new FurniturePresetGridItemData
					{
						FurnitureConfig = furnitureConfig.Value,
						IsLock = flag,
						IsFinished = !flag
					});
					if (flag)
					{
						this.LockCount++;
					}
				}
			}
		}
		this.SortGridItemDataList();
	}

	// Token: 0x06006EEB RID: 28395 RVA: 0x001CDB28 File Offset: 0x001CBD28
	private void SortGridItemDataList()
	{
		this.GridItemDataList.Sort(delegate(IFurniturePresetGridItemData a, IFurniturePresetGridItemData b)
		{
			if (a.IsLock == b.IsLock)
			{
				return a.FurnitureConfig.Id - b.FurnitureConfig.Id;
			}
			if (!a.IsLock)
			{
				return 1;
			}
			return -1;
		});
	}

	// Token: 0x06006EEC RID: 28396 RVA: 0x001CDB54 File Offset: 0x001CBD54
	private void UpdateCostData()
	{
		this.NeedCostCurrency = 0;
		this.GoodsSet.Clear();
		foreach (IFurniturePresetGridItemData furniturePresetGridItemData in this.GridItemDataList)
		{
			if (furniturePresetGridItemData.IsLock)
			{
				Furniture furnitureConfig = furniturePresetGridItemData.FurnitureConfig;
				if (furnitureConfig.SourceType == 1)
				{
					int getWayId = furnitureConfig.GetWayId;
					if (!this.GoodsSet.Contains(getWayId))
					{
						PayShopGoods payShopGoods = ModelBase<PayShopModel>.Instance.GetPayShopGoods(getWayId);
						if (payShopGoods != null && payShopGoods.IfCanBuy())
						{
							IPriceData priceData = (payShopGoods != null) ? payShopGoods.GetPriceData() : null;
							this.NeedCostCurrency += ((priceData != null) ? priceData.NowPrice : 0);
							this.GoodsSet.Add(getWayId);
						}
					}
				}
			}
		}
	}

	// Token: 0x06006EED RID: 28397 RVA: 0x001CDC3C File Offset: 0x001CBE3C
	private void OnShopButtonClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.FurniturePresetView, delegate(bool _)
		{
			ControllerBase<FurnitureController>.Instance.OpenFurnitureShopViewAsync(0);
		});
	}

	// Token: 0x06006EEE RID: 28398 RVA: 0x001CDC6C File Offset: 0x001CBE6C
	private void OnApplyButtonClick(int _)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FurniturePresetApplyConfirm);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		confirmBoxDataNew.FunctionMap.Add(2, new Action(this.ApplyInternal));
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06006EEF RID: 28399 RVA: 0x001CDCAF File Offset: 0x001CBEAF
	private void ApplyInternal()
	{
		if (this.AreaData == null)
		{
			return;
		}
		Action<FurnitureAreaData> onApplyDelegate = this.OnApplyDelegate;
		if (onApplyDelegate == null)
		{
			return;
		}
		onApplyDelegate(this.AreaData);
	}

	// Token: 0x06006EF0 RID: 28400 RVA: 0x001CDCD0 File Offset: 0x001CBED0
	private void OnFillAndApplyButtonClick(int _)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.FurniturePresetFillAndApplyConfirm);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			this.FillAndApplyInternalAsync().Forget();
		});
		confirmBoxDataNew.TextArgs = new string[]
		{
			this.NeedCostCurrency.ToString()
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06006EF1 RID: 28401 RVA: 0x001CDD30 File Offset: 0x001CBF30
	private UniTask FillInternalAsync()
	{
		FurniturePresetItem.<FillInternalAsync>d__22 <FillInternalAsync>d__;
		<FillInternalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FillInternalAsync>d__.<>4__this = this;
		<FillInternalAsync>d__.<>1__state = -1;
		<FillInternalAsync>d__.<>t__builder.Start<FurniturePresetItem.<FillInternalAsync>d__22>(ref <FillInternalAsync>d__);
		return <FillInternalAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006EF2 RID: 28402 RVA: 0x001CDD74 File Offset: 0x001CBF74
	private UniTask FillAndApplyInternalAsync()
	{
		FurniturePresetItem.<FillAndApplyInternalAsync>d__23 <FillAndApplyInternalAsync>d__;
		<FillAndApplyInternalAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<FillAndApplyInternalAsync>d__.<>4__this = this;
		<FillAndApplyInternalAsync>d__.<>1__state = -1;
		<FillAndApplyInternalAsync>d__.<>t__builder.Start<FurniturePresetItem.<FillAndApplyInternalAsync>d__23>(ref <FillAndApplyInternalAsync>d__);
		return <FillAndApplyInternalAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006EF3 RID: 28403 RVA: 0x001CDDB7 File Offset: 0x001CBFB7
	private FurniturePresetGridItem CreatePresetGridItem()
	{
		return new FurniturePresetGridItem();
	}

	// Token: 0x040034F2 RID: 13554
	[Nullable(2)]
	private FurnitureAreaData AreaData;

	// Token: 0x040034F3 RID: 13555
	private int CurrencyId;

	// Token: 0x040034F4 RID: 13556
	private int NeedCostCurrency;

	// Token: 0x040034F5 RID: 13557
	private int LockCount;

	// Token: 0x040034F6 RID: 13558
	private readonly HashSet<int> GoodsSet = new HashSet<int>();

	// Token: 0x040034F7 RID: 13559
	private bool IsDoingFillAndApply;

	// Token: 0x040034F8 RID: 13560
	private readonly List<IFurniturePresetGridItemData> GridItemDataList = new List<IFurniturePresetGridItemData>();

	// Token: 0x040034F9 RID: 13561
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericScrollViewNew<FurniturePresetGridItem, IFurniturePresetGridItemData> PresetScrollView;

	// Token: 0x040034FA RID: 13562
	[Nullable(2)]
	private CommonCurrencyItemListComponent CurrencyListComponent;

	// Token: 0x040034FB RID: 13563
	[Nullable(2)]
	private ButtonItem ApplyButtonItem;

	// Token: 0x040034FC RID: 13564
	[Nullable(2)]
	private ButtonItem FillAndApplyButtonItem;

	// Token: 0x040034FD RID: 13565
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<FurnitureAreaData> OnApplyDelegate;
}
