using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;

// Token: 0x020024BE RID: 9406
[NullableContext(1)]
[Nullable(0)]
public class PhantomInteractEditViewModel
{
	// Token: 0x1700172E RID: 5934
	// (get) Token: 0x0601241A RID: 74778 RVA: 0x00505DA6 File Offset: 0x00503FA6
	// (set) Token: 0x0601241B RID: 74779 RVA: 0x00505DAE File Offset: 0x00503FAE
	public int SelectedItemIndex { get; set; }

	// Token: 0x1700172F RID: 5935
	// (get) Token: 0x0601241C RID: 74780 RVA: 0x00505DB7 File Offset: 0x00503FB7
	// (set) Token: 0x0601241D RID: 74781 RVA: 0x00505DBF File Offset: 0x00503FBF
	public EPhantomInteractEditBtnState BtnState { get; set; } = EPhantomInteractEditBtnState.Equip;

	// Token: 0x17001730 RID: 5936
	// (get) Token: 0x0601241E RID: 74782 RVA: 0x00505DC8 File Offset: 0x00503FC8
	// (set) Token: 0x0601241F RID: 74783 RVA: 0x00505DD0 File Offset: 0x00503FD0
	public bool BtnAvailable { get; set; } = true;

	// Token: 0x17001731 RID: 5937
	// (get) Token: 0x06012420 RID: 74784 RVA: 0x00505DD9 File Offset: 0x00503FD9
	// (set) Token: 0x06012421 RID: 74785 RVA: 0x00505DE1 File Offset: 0x00503FE1
	[Nullable(2)]
	public IPhantomInteractItemData SelectedItemData { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17001732 RID: 5938
	// (get) Token: 0x06012422 RID: 74786 RVA: 0x00505DEA File Offset: 0x00503FEA
	// (set) Token: 0x06012423 RID: 74787 RVA: 0x00505DF2 File Offset: 0x00503FF2
	public PhantomInteractDetailViewModel DetailViewModel { get; set; } = new PhantomInteractDetailViewModel();

	// Token: 0x17001733 RID: 5939
	// (get) Token: 0x06012424 RID: 74788 RVA: 0x00505DFB File Offset: 0x00503FFB
	// (set) Token: 0x06012425 RID: 74789 RVA: 0x00505E03 File Offset: 0x00504003
	public bool ShowDetail { get; set; }

	// Token: 0x17001734 RID: 5940
	// (get) Token: 0x06012426 RID: 74790 RVA: 0x00505E0C File Offset: 0x0050400C
	// (set) Token: 0x06012427 RID: 74791 RVA: 0x00505E14 File Offset: 0x00504014
	public List<IPhantomGridListData> GridsDataList { get; set; } = new List<IPhantomGridListData>();

	// Token: 0x17001735 RID: 5941
	// (get) Token: 0x06012428 RID: 74792 RVA: 0x00505E1D File Offset: 0x0050401D
	// (set) Token: 0x06012429 RID: 74793 RVA: 0x00505E25 File Offset: 0x00504025
	[Nullable(0)]
	public ValueTuple<int, int> SelectedGridItemIndex { [NullableContext(0)] get; [NullableContext(0)] set; } = new ValueTuple<int, int>(-1, -1);

	// Token: 0x17001736 RID: 5942
	// (get) Token: 0x0601242A RID: 74794 RVA: 0x00505E2E File Offset: 0x0050402E
	// (set) Token: 0x0601242B RID: 74795 RVA: 0x00505E36 File Offset: 0x00504036
	public Dictionary<int, PhantomInteractEditGridViewModel> GridViewModelMap { get; set; } = new Dictionary<int, PhantomInteractEditGridViewModel>();

	// Token: 0x17001737 RID: 5943
	// (get) Token: 0x0601242C RID: 74796 RVA: 0x00505E3F File Offset: 0x0050403F
	// (set) Token: 0x0601242D RID: 74797 RVA: 0x00505E47 File Offset: 0x00504047
	private List<int> SortGridViewModelIds { get; set; } = new List<int>();

	// Token: 0x17001738 RID: 5944
	// (get) Token: 0x0601242E RID: 74798 RVA: 0x00505E50 File Offset: 0x00504050
	// (set) Token: 0x0601242F RID: 74799 RVA: 0x00505E58 File Offset: 0x00504058
	[Nullable(2)]
	private PhantomInteractEditGridViewModel SelectedGridDataInternal { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17001739 RID: 5945
	// (get) Token: 0x06012430 RID: 74800 RVA: 0x00505E61 File Offset: 0x00504061
	// (set) Token: 0x06012431 RID: 74801 RVA: 0x00505E69 File Offset: 0x00504069
	private PhantomInteractInfoData InfoData { get; set; } = new PhantomInteractInfoData();

	// Token: 0x1700173A RID: 5946
	// (get) Token: 0x06012432 RID: 74802 RVA: 0x00505E72 File Offset: 0x00504072
	// (set) Token: 0x06012433 RID: 74803 RVA: 0x00505E7A File Offset: 0x0050407A
	private int? FilterCost { get; set; }

	// Token: 0x1700173B RID: 5947
	// (get) Token: 0x06012434 RID: 74804 RVA: 0x00505E83 File Offset: 0x00504083
	// (set) Token: 0x06012435 RID: 74805 RVA: 0x00505E8B File Offset: 0x0050408B
	private bool? FilterIsSpecial { get; set; }

	// Token: 0x1700173C RID: 5948
	// (get) Token: 0x06012436 RID: 74806 RVA: 0x00505E94 File Offset: 0x00504094
	// (set) Token: 0x06012437 RID: 74807 RVA: 0x00505E9C File Offset: 0x0050409C
	private List<int> RecommendedMonsterIds { get; set; } = new List<int>();

	// Token: 0x06012438 RID: 74808 RVA: 0x00505EA5 File Offset: 0x005040A5
	private void LocalLog(string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
	{
		0,
		0,
		1,
		2
	})] ReadOnlySpan<ValueTuple<string, object>> pairs)
	{
	}

	// Token: 0x06012439 RID: 74809 RVA: 0x00505EA7 File Offset: 0x005040A7
	public void ConfirmEquipHandler()
	{
		if (this.ConfirmEquipHandlerInternal == null)
		{
			return;
		}
		this.ConfirmEquipHandlerInternal(this);
	}

	// Token: 0x0601243A RID: 74810 RVA: 0x00505EBE File Offset: 0x005040BE
	public void SetConfirmEquipHandler([Nullable(new byte[]
	{
		2,
		1
	})] Action<PhantomInteractEditViewModel> handler)
	{
		this.ConfirmEquipHandlerInternal = handler;
	}

	// Token: 0x0601243B RID: 74811 RVA: 0x00505EC7 File Offset: 0x005040C7
	public void EquipRecommendHandler()
	{
		if (this.EquipRecommendHandlerInternal == null)
		{
			return;
		}
		this.EquipRecommendHandlerInternal(this);
	}

	// Token: 0x0601243C RID: 74812 RVA: 0x00505EDE File Offset: 0x005040DE
	public void SetEquipRecommendHandler([Nullable(new byte[]
	{
		2,
		1
	})] Action<PhantomInteractEditViewModel> handler)
	{
		this.EquipRecommendHandlerInternal = handler;
	}

	// Token: 0x0601243D RID: 74813 RVA: 0x00505EE7 File Offset: 0x005040E7
	public void EquipRecommendCallback()
	{
		if (this.EquipRecommendCallbackInternal != null)
		{
			this.EquipRecommendCallbackInternal();
			this.EquipRecommendCallbackInternal = null;
		}
	}

	// Token: 0x0601243E RID: 74814 RVA: 0x00505F03 File Offset: 0x00504103
	[NullableContext(2)]
	public void SetEquipRecommendCallback(Action callback)
	{
		this.EquipRecommendCallbackInternal = callback;
	}

	// Token: 0x0601243F RID: 74815 RVA: 0x00505F0C File Offset: 0x0050410C
	public void MoveNextSkinHandler()
	{
		if (this.MoveNextSkinHandlerInternal == null)
		{
			return;
		}
		this.MoveNextSkinHandlerInternal(this);
		this.RefreshDetail();
	}

	// Token: 0x06012440 RID: 74816 RVA: 0x00505F29 File Offset: 0x00504129
	public void SetMoveNextSkinHandler([Nullable(new byte[]
	{
		2,
		1
	})] Action<PhantomInteractEditViewModel> handler)
	{
		this.MoveNextSkinHandlerInternal = handler;
	}

	// Token: 0x1700173D RID: 5949
	// (get) Token: 0x06012441 RID: 74817 RVA: 0x00505F32 File Offset: 0x00504132
	[Nullable(2)]
	public PhantomInteractEditGridViewModel SelectedGridData
	{
		[NullableContext(2)]
		get
		{
			return this.SelectedGridDataInternal;
		}
	}

	// Token: 0x06012442 RID: 74818 RVA: 0x00505F3A File Offset: 0x0050413A
	public List<int> GetFilteredRecommendedIdList()
	{
		return this.FilteredRecommendedMonsterIds;
	}

	// Token: 0x06012443 RID: 74819 RVA: 0x00505F44 File Offset: 0x00504144
	public void InitData(PhantomInteractInfoData infoData, int selectedItemIndex)
	{
		this.InfoData = infoData;
		int currentAreaId = ModelBase<AreaModel>.Instance.GetCurrentAreaId(null);
		this.RecommendedMonsterIds = this.LoadAreaRelativeData(currentAreaId);
		this.InitGridViewModels(infoData.GridItemDataList);
		this.RefreshFilterGridViewData();
		this.SelectItem(selectedItemIndex);
		IPhantomInteractItemData selectedItemData = this.SelectedItemData;
		if (selectedItemData != null && selectedItemData.MonsterId == 0)
		{
			int num = 0;
			if (this.GridsDataList.Count > 0)
			{
				IPhantomGridListData phantomGridListData = this.GridsDataList[0];
				if (phantomGridListData != null && phantomGridListData.MonsterIds.Count > 0)
				{
					num = phantomGridListData.MonsterIds[0];
				}
			}
			if (num > 0)
			{
				this.SelectGrid(num);
			}
		}
	}

	// Token: 0x06012444 RID: 74820 RVA: 0x00505FF0 File Offset: 0x005041F0
	public void SelectItem(int index)
	{
		this.SelectedItemIndex = index;
		this.SelectedItemData = this.InfoData.EquippedVisionData[index];
		if (this.SelectedItemData.MonsterId == 0)
		{
			this.RefreshDetail();
		}
		else
		{
			this.SelectGrid(this.SelectedItemData.MonsterId);
		}
		this.RefreshBtnState();
	}

	// Token: 0x06012445 RID: 74821 RVA: 0x00506048 File Offset: 0x00504248
	public void SelectGrid(int monsterId)
	{
		this.SelectedGridItemIndex = this.SelectGridViewModel(monsterId);
		IPhantomInteractItemData selectedItemData = this.SelectedItemData;
		if (selectedItemData != null && selectedItemData.MonsterId == 0)
		{
			this.BtnState = EPhantomInteractEditBtnState.Equip;
		}
		else
		{
			this.BtnState = EPhantomInteractEditBtnState.Swap;
		}
		this.RefreshDetail();
		this.RefreshBtnState();
	}

	// Token: 0x06012446 RID: 74822 RVA: 0x00506098 File Offset: 0x00504298
	public int FindGridIndexInMultiTemplate(int monsterId)
	{
		if (this.FilteredRecommendedMonsterIds.Count <= 0)
		{
			return this.FilteredElseMonsterIds.FindIndex((int id) => id == monsterId);
		}
		int num = this.FilteredRecommendedMonsterIds.FindIndex((int id) => id == monsterId);
		if (num >= 0)
		{
			return num + 1;
		}
		int num2 = this.FilteredElseMonsterIds.FindIndex((int id) => id == monsterId);
		if (num2 >= 0)
		{
			return num2 + this.FilteredRecommendedMonsterIds.Count + 2;
		}
		return -1;
	}

	// Token: 0x06012447 RID: 74823 RVA: 0x00506128 File Offset: 0x00504328
	private void RefreshBtnState()
	{
		if (this.SelectedGridData == null)
		{
			this.BtnState = EPhantomInteractEditBtnState.Invisible;
			this.BtnAvailable = false;
			return;
		}
		this.BtnAvailable = this.SelectedGridData.IsUnlocked;
		IPhantomInteractItemData selectedItemData = this.SelectedItemData;
		if (selectedItemData != null && selectedItemData.MonsterId == 0)
		{
			this.BtnState = EPhantomInteractEditBtnState.Equip;
			return;
		}
		IPhantomInteractItemData selectedItemData2 = this.SelectedItemData;
		int? num = (selectedItemData2 != null) ? new int?(selectedItemData2.MonsterId) : null;
		PhantomInteractEditGridViewModel selectedGridData = this.SelectedGridData;
		int? num2 = (selectedGridData != null) ? new int?(selectedGridData.MonsterId) : null;
		this.BtnState = ((num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null)) ? EPhantomInteractEditBtnState.UnEquip : EPhantomInteractEditBtnState.Swap);
	}

	// Token: 0x06012448 RID: 74824 RVA: 0x005061EC File Offset: 0x005043EC
	private void InitGridViewModels(List<IPhantomInteractGridData> gridDataList)
	{
		this.GridViewModelMap.Clear();
		foreach (IPhantomInteractGridData phantomInteractGridData in gridDataList)
		{
			PhantomInteractEditGridViewModel phantomInteractEditGridViewModel = new PhantomInteractEditGridViewModel(phantomInteractGridData);
			phantomInteractEditGridViewModel.IsInArea = this.CheckInteractAreaListInRecommendArea(phantomInteractGridData.InteractAreaList);
			this.GridViewModelMap[phantomInteractGridData.MonsterId] = phantomInteractEditGridViewModel;
		}
		foreach (int num in this.RecommendedMonsterIds)
		{
			if (!this.GridViewModelMap.ContainsKey(num))
			{
				PhantomInteractGridData phantomInteractGridData2 = new PhantomInteractGridData();
				phantomInteractGridData2.LoadLockData(num);
				PhantomInteractEditGridViewModel phantomInteractEditGridViewModel2 = new PhantomInteractEditGridViewModel(phantomInteractGridData2);
				phantomInteractEditGridViewModel2.IsInArea = true;
				this.GridViewModelMap[phantomInteractGridData2.MonsterId] = phantomInteractEditGridViewModel2;
			}
		}
		this.SortGridViewModelIds = (from a in this.GridViewModelMap.Values
		orderby a.SortId
		select a into vm
		select vm.MonsterId).ToList<int>();
	}

	// Token: 0x06012449 RID: 74825 RVA: 0x00506348 File Offset: 0x00504548
	[NullableContext(0)]
	private ValueTuple<int, int> SelectGridViewModel(int monsterId)
	{
		if (this.GridsDataList == null)
		{
			return new ValueTuple<int, int>(-1, -1);
		}
		ValueTuple<int, int>? valueTuple = null;
		for (int i = 0; i < this.GridsDataList.Count; i++)
		{
			IPhantomGridListData phantomGridListData = this.GridsDataList[i];
			for (int j = 0; j < phantomGridListData.MonsterIds.Count; j++)
			{
				int num = phantomGridListData.MonsterIds[j];
				PhantomInteractEditGridViewModel phantomInteractEditGridViewModel;
				if (this.GridViewModelMap.TryGetValue(num, out phantomInteractEditGridViewModel) && phantomInteractEditGridViewModel != null)
				{
					phantomInteractEditGridViewModel.IsSelected = (num == monsterId);
					if (valueTuple == null && phantomInteractEditGridViewModel.IsSelected)
					{
						valueTuple = new ValueTuple<int, int>?(new ValueTuple<int, int>(i, j));
						this.SelectedGridDataInternal = phantomInteractEditGridViewModel;
					}
				}
			}
		}
		ValueTuple<int, int>? valueTuple2 = valueTuple;
		if (valueTuple2 == null)
		{
			return new ValueTuple<int, int>(-1, -1);
		}
		return valueTuple2.GetValueOrDefault();
	}

	// Token: 0x0601244A RID: 74826 RVA: 0x0050641C File Offset: 0x0050461C
	private void RefreshDetail()
	{
		int? num = null;
		if (this.SelectedGridData != null)
		{
			num = new int?(this.SelectedGridData.MonsterId);
		}
		else if (this.SelectedItemData != null)
		{
			num = new int?(this.SelectedItemData.MonsterId);
		}
		if (num != null)
		{
			int? num2 = num;
			int num3 = 0;
			if (!(num2.GetValueOrDefault() == num3 & num2 != null))
			{
				this.ShowDetail = true;
				this.DetailViewModel.RefreshData(this.SelectedGridData);
				return;
			}
		}
		this.ShowDetail = false;
	}

	// Token: 0x0601244B RID: 74827 RVA: 0x005064A8 File Offset: 0x005046A8
	public void SetFilterCost(int cost)
	{
		this.FilterCost = ((cost > 0) ? new int?(cost) : null);
	}

	// Token: 0x0601244C RID: 74828 RVA: 0x005064D0 File Offset: 0x005046D0
	public void SetFilterIsSpecial(EFilterIsSpecialOption option)
	{
		bool? filterIsSpecial = null;
		if (option == EFilterIsSpecialOption.Special)
		{
			filterIsSpecial = new bool?(true);
		}
		else if (option == EFilterIsSpecialOption.NonSpecial)
		{
			filterIsSpecial = new bool?(false);
		}
		this.FilterIsSpecial = filterIsSpecial;
	}

	// Token: 0x0601244D RID: 74829 RVA: 0x00506508 File Offset: 0x00504708
	public void RefreshFilterGridViewData()
	{
		this.FilteredGridMonsterIds.Clear();
		this.FilteredRecommendedMonsterIds.Clear();
		this.FilteredElseMonsterIds.Clear();
		int num = 0;
		foreach (int key in this.SortGridViewModelIds)
		{
			PhantomInteractEditGridViewModel phantomInteractEditGridViewModel;
			if (this.GridViewModelMap.TryGetValue(key, out phantomInteractEditGridViewModel) && phantomInteractEditGridViewModel != null && this.FilterOnItem(phantomInteractEditGridViewModel))
			{
				this.FilteredGridMonsterIds.Add(phantomInteractEditGridViewModel.MonsterId);
				if (this.CheckInteractAreaListInRecommendArea(phantomInteractEditGridViewModel.InteractAreaList))
				{
					this.FilteredRecommendedMonsterIds.Add(phantomInteractEditGridViewModel.MonsterId);
					if (phantomInteractEditGridViewModel.IsUnlocked)
					{
						num++;
					}
				}
				else
				{
					this.FilteredElseMonsterIds.Add(phantomInteractEditGridViewModel.MonsterId);
				}
			}
		}
		if (this.FilteredRecommendedMonsterIds.Count == 0)
		{
			this.GridsDataList = new List<IPhantomGridListData>
			{
				new PhantomGridListData
				{
					TitleType = EGridTitleType.Hide,
					MonsterIds = this.FilteredElseMonsterIds
				}
			};
		}
		else
		{
			this.GridsDataList = new List<IPhantomGridListData>
			{
				new PhantomGridListData
				{
					TitleType = ((num > 0) ? EGridTitleType.Recommend : EGridTitleType.RecommendEmpty),
					MonsterIds = this.FilteredRecommendedMonsterIds
				}
			};
			if (this.FilteredElseMonsterIds.Count > 0)
			{
				this.GridsDataList.Add(new PhantomGridListData
				{
					TitleType = EGridTitleType.Else,
					MonsterIds = this.FilteredElseMonsterIds
				});
			}
		}
		int num2 = 0;
		if (this.GridsDataList.Count > 0)
		{
			IPhantomGridListData phantomGridListData = this.GridsDataList[0];
			if (phantomGridListData != null && phantomGridListData.MonsterIds.Count > 0)
			{
				num2 = phantomGridListData.MonsterIds[0];
			}
		}
		if (num2 > 0)
		{
			this.SelectGrid(num2);
		}
	}

	// Token: 0x0601244E RID: 74830 RVA: 0x005066D0 File Offset: 0x005048D0
	private bool FilterOnItem(IPhantomInteractGridData data)
	{
		return (this.FilterCost == null || data.Cost == this.FilterCost.Value) && (this.FilterIsSpecial == null || data.IsSpecial == this.FilterIsSpecial.Value);
	}

	// Token: 0x0601244F RID: 74831 RVA: 0x00506730 File Offset: 0x00504930
	private unsafe List<int> LoadAreaRelativeData(int currentAreaId)
	{
		this.AreaSet.Clear();
		List<int> allAreaIdInheritableById = ModelBase<AreaModel>.Instance.GetAllAreaIdInheritableById(currentAreaId);
		foreach (int item in allAreaIdInheritableById)
		{
			this.AreaSet.Add(item);
		}
		List<int> list = new List<int>();
		IReadOnlyList<CalabashDevelopReward> calabashDevelopList = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopList();
		if (calabashDevelopList != null)
		{
			foreach (CalabashDevelopReward config in calabashDevelopList)
			{
				if (this.CheckInteractAreaListInRecommendArea(config))
				{
					list.Add(config.MonsterId);
				}
			}
		}
		string message = "[声骸显像]加载当前地区推荐声骸";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("当前所属的所有区域", allAreaIdInheritableById);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("推荐声骸列表", list);
		this.LocalLog(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return list;
	}

	// Token: 0x06012450 RID: 74832 RVA: 0x0050684C File Offset: 0x00504A4C
	private bool CheckInteractAreaListInRecommendArea(IReadOnlyList<int> interactAreaIds)
	{
		for (int i = 0; i < interactAreaIds.Count; i++)
		{
			if (this.AreaSet.Contains(interactAreaIds[i]))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06012451 RID: 74833 RVA: 0x00506884 File Offset: 0x00504A84
	private bool CheckInteractAreaListInRecommendArea(CalabashDevelopReward config)
	{
		int[] interactAreaListArray = config.GetInteractAreaListArray();
		if (interactAreaListArray == null)
		{
			return false;
		}
		foreach (int item in interactAreaListArray)
		{
			if (this.AreaSet.Contains(item))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04008E7A RID: 36474
	private readonly List<int> FilteredGridMonsterIds = new List<int>();

	// Token: 0x04008E7C RID: 36476
	private readonly List<int> FilteredRecommendedMonsterIds = new List<int>();

	// Token: 0x04008E7D RID: 36477
	private readonly List<int> FilteredElseMonsterIds = new List<int>();

	// Token: 0x04008E7E RID: 36478
	private readonly HashSet<int> AreaSet = new HashSet<int>();

	// Token: 0x04008E7F RID: 36479
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<PhantomInteractEditViewModel> ConfirmEquipHandlerInternal;

	// Token: 0x04008E80 RID: 36480
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<PhantomInteractEditViewModel> EquipRecommendHandlerInternal;

	// Token: 0x04008E81 RID: 36481
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<PhantomInteractEditViewModel> MoveNextSkinHandlerInternal;

	// Token: 0x04008E82 RID: 36482
	[Nullable(2)]
	private Action EquipRecommendCallbackInternal;
}
