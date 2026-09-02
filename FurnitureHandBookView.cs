using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001098 RID: 4248
[NullableContext(1)]
[Nullable(0)]
public class FurnitureHandBookView : UiViewBase
{
	// Token: 0x06006EC2 RID: 28354 RVA: 0x001CD031 File Offset: 0x001CB231
	public FurnitureHandBookView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06006EC3 RID: 28355 RVA: 0x001CD05C File Offset: 0x001CB25C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
	}

	// Token: 0x06006EC4 RID: 28356 RVA: 0x001CD110 File Offset: 0x001CB310
	protected override UniTask OnBeforeStartAsync()
	{
		FurnitureHandBookView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FurnitureHandBookView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006EC5 RID: 28357 RVA: 0x001CD154 File Offset: 0x001CB354
	protected override UniTask OnBeforeShowAsyncImplementImplement()
	{
		FurnitureHandBookView.<OnBeforeShowAsyncImplementImplement>d__12 <OnBeforeShowAsyncImplementImplement>d__;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<FurnitureHandBookView.<OnBeforeShowAsyncImplementImplement>d__12>(ref <OnBeforeShowAsyncImplementImplement>d__);
		return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06006EC6 RID: 28358 RVA: 0x001CD197 File Offset: 0x001CB397
	protected override void OnBeforeHide()
	{
		ControllerBase<FurnitureController>.Instance.SetAllFurnitureHandBookItemRedDotAsRead();
	}

	// Token: 0x06006EC7 RID: 28359 RVA: 0x001CD1A4 File Offset: 0x001CB3A4
	protected virtual void UpdateAllDataList()
	{
		int handleId = ModelBase<FurnitureModel>.Instance.HandleId;
		IEnumerable<Furniture> furnitureConfigListByHandleId = ConfigBase<FurnitureConfig>.Instance.GetFurnitureConfigListByHandleId(handleId);
		this.AllDataList.Clear();
		foreach (Furniture furnitureConfig in furnitureConfigListByHandleId)
		{
			bool isLock = !ModelBase<FurnitureModel>.Instance.GetIsFurnitureUnlockById(furnitureConfig.Id);
			FurnitureHandBookItemData item = new FurnitureHandBookItemData
			{
				FurnitureConfig = furnitureConfig,
				IsLock = isLock,
				RedDotVisible = ModelBase<FurnitureModel>.Instance.CheckFurnitureHandBookItemRedDot(furnitureConfig.Id)
			};
			this.AllDataList.Add(item);
		}
	}

	// Token: 0x06006EC8 RID: 28360 RVA: 0x001CD254 File Offset: 0x001CB454
	private void UpdateCurShowDataList()
	{
		int[] tagList = (this.CurrentFilterConfig != null) ? this.CurrentFilterConfig.GetValueOrDefault().TagList() : null;
		if (tagList == null)
		{
			this.CurShowDataList = this.AllDataList;
		}
		else
		{
			this.CurShowDataList = this.AllDataList.FindAll((IFurnitureHandBookItemData data) => tagList.Contains(data.FurnitureConfig.TagId));
		}
		this.SortCurShowDataList();
	}

	// Token: 0x06006EC9 RID: 28361 RVA: 0x001CD2C5 File Offset: 0x001CB4C5
	private void SortCurShowDataList()
	{
		this.CurShowDataList.Sort(delegate(IFurnitureHandBookItemData a, IFurnitureHandBookItemData b)
		{
			if (a.IsLock != b.IsLock)
			{
				if (!a.IsLock)
				{
					return -1;
				}
				return 1;
			}
			else
			{
				if (a.FurnitureConfig.QualityId != b.FurnitureConfig.QualityId)
				{
					return b.FurnitureConfig.QualityId - a.FurnitureConfig.QualityId;
				}
				if (a.FurnitureConfig.Id != b.FurnitureConfig.Id)
				{
					return a.FurnitureConfig.Id - b.FurnitureConfig.Id;
				}
				return 0;
			}
		});
	}

	// Token: 0x06006ECA RID: 28362 RVA: 0x001CD2F1 File Offset: 0x001CB4F1
	public void RefreshGrid()
	{
		this.ItemLoopScrollView.RefreshByData(this.CurShowDataList, false, null, false);
	}

	// Token: 0x06006ECB RID: 28363 RVA: 0x001CD308 File Offset: 0x001CB508
	public void RefreshDetail()
	{
		if (this.CurSelectedFurnitureData == null)
		{
			return;
		}
		this.DetailItem.RefreshByFurnitureId(this.CurSelectedFurnitureData.FurnitureConfig.Id, true);
	}

	// Token: 0x06006ECC RID: 28364 RVA: 0x001CD340 File Offset: 0x001CB540
	public void RefreshNumText()
	{
		int num = 0;
		int count = this.AllDataList.Count;
		using (List<IFurnitureHandBookItemData>.Enumerator enumerator = this.AllDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.IsLock)
				{
					num++;
				}
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "DIY_FurnitureDic_Process", new <>z__ReadOnlyArray<object>(new object[]
		{
			num,
			count
		}));
	}

	// Token: 0x06006ECD RID: 28365 RVA: 0x001CD3D8 File Offset: 0x001CB5D8
	private void OnClickBack()
	{
		base.CloseMe(null);
	}

	// Token: 0x06006ECE RID: 28366 RVA: 0x001CD3E1 File Offset: 0x001CB5E1
	private void OnDropDownSelect(int index, FurnitureFilterConfig data)
	{
		this.CurrentFilterConfig = new FurnitureFilterConfig?(this.FilterConfigList[index]);
		this.UpdateCurShowDataList();
		this.RefreshGrid();
		this.SelectProxy();
	}

	// Token: 0x06006ECF RID: 28367 RVA: 0x001CD40C File Offset: 0x001CB60C
	private FurnitureHandBookItem CreateItemProxy()
	{
		FurnitureHandBookItem furnitureHandBookItem = new FurnitureHandBookItem();
		furnitureHandBookItem.BindOnExtendToggleStateChanged(delegate(MediumItemGridExtendCallback callbackParameter)
		{
			EToggleState state = callbackParameter.State;
			IFurnitureHandBookItemData data = callbackParameter.Data as IFurnitureHandBookItemData;
			this.OnFurnitureItemToggleChanged(state, data);
		});
		furnitureHandBookItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChangeFunctionForFurniture));
		return furnitureHandBookItem;
	}

	// Token: 0x06006ED0 RID: 28368 RVA: 0x001CD437 File Offset: 0x001CB637
	private void OnFurnitureItemToggleChanged(EToggleState state, IFurnitureHandBookItemData data)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.SelectFurniture(data);
		}
	}

	// Token: 0x06006ED1 RID: 28369 RVA: 0x001CD444 File Offset: 0x001CB644
	private bool CanExecuteChangeFunctionForFurniture(object data, bool isForceSelected, EToggleState state)
	{
		int id = (data as IFurnitureHandBookItemData).FurnitureConfig.Id;
		if (state == EToggleState.ETT_Checked)
		{
			IFurnitureHandBookItemData curSelectedFurnitureData = this.CurSelectedFurnitureData;
			return curSelectedFurnitureData == null || curSelectedFurnitureData.FurnitureConfig.Id != id;
		}
		return true;
	}

	// Token: 0x06006ED2 RID: 28370 RVA: 0x001CD48B File Offset: 0x001CB68B
	public void SelectFurniture(IFurnitureHandBookItemData data)
	{
		this.CurSelectedFurnitureData = data;
		this.SelectProxy();
		this.RefreshDetail();
	}

	// Token: 0x06006ED3 RID: 28371 RVA: 0x001CD4A0 File Offset: 0x001CB6A0
	public void SelectProxy()
	{
		FurnitureHandBookView.<>c__DisplayClass26_0 CS$<>8__locals1 = new FurnitureHandBookView.<>c__DisplayClass26_0();
		FurnitureHandBookView.<>c__DisplayClass26_0 CS$<>8__locals2 = CS$<>8__locals1;
		IFurnitureHandBookItemData curSelectedFurnitureData = this.CurSelectedFurnitureData;
		CS$<>8__locals2.furnitureId = ((curSelectedFurnitureData != null) ? new int?(curSelectedFurnitureData.FurnitureConfig.Id) : null);
		if (CS$<>8__locals1.furnitureId == null)
		{
			return;
		}
		int num = this.CurShowDataList.FindIndex(delegate(IFurnitureHandBookItemData item)
		{
			int id = item.FurnitureConfig.Id;
			int? furnitureId = CS$<>8__locals1.furnitureId;
			return id == furnitureId.GetValueOrDefault() & furnitureId != null;
		});
		if (num == -1)
		{
			return;
		}
		LoopScrollView<FurnitureHandBookItem, IFurnitureHandBookItemData> itemLoopScrollView = this.ItemLoopScrollView;
		if (itemLoopScrollView == null)
		{
			return;
		}
		itemLoopScrollView.SelectGridProxy(num, false);
	}

	// Token: 0x040034D5 RID: 13525
	[Nullable(2)]
	protected IFurnitureHandBookItemData CurSelectedFurnitureData;

	// Token: 0x040034D6 RID: 13526
	private readonly List<IFurnitureHandBookItemData> AllDataList = new List<IFurnitureHandBookItemData>();

	// Token: 0x040034D7 RID: 13527
	protected List<IFurnitureHandBookItemData> CurShowDataList = new List<IFurnitureHandBookItemData>();

	// Token: 0x040034D8 RID: 13528
	private FurnitureFilterConfig? CurrentFilterConfig;

	// Token: 0x040034D9 RID: 13529
	private IReadOnlyList<FurnitureFilterConfig> FilterConfigList = new List<FurnitureFilterConfig>();

	// Token: 0x040034DA RID: 13530
	[Nullable(2)]
	private PopupCaptionItem PopupCaption;

	// Token: 0x040034DB RID: 13531
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CommonDropDown<TableTextArgNew, FurnitureFilterConfig> FilterDropDownList;

	// Token: 0x040034DC RID: 13532
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<FurnitureHandBookItem, IFurnitureHandBookItemData> ItemLoopScrollView;

	// Token: 0x040034DD RID: 13533
	[Nullable(2)]
	private FurnitureDetailTipItem DetailItem;
}
