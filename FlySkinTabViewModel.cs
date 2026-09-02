using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.Skin;
using UnrealEngine;

// Token: 0x02002A5E RID: 10846
[NullableContext(1)]
[Nullable(0)]
public class FlySkinTabViewModel : global::ViewModelBase<EFlySkinViewData>
{
	// Token: 0x06015BA9 RID: 89001 RVA: 0x00607AB0 File Offset: 0x00605CB0
	public FlySkinTabViewModel()
	{
		List<FlySkinGridData> value = new List<FlySkinGridData>();
		this.DataMap.Add(EFlySkinViewData.GridDataList, value);
		this.DataMap.Add(EFlySkinViewData.SelectedTab, null);
		this.DataMap.Add(EFlySkinViewData.SelectedGridIndex, -1);
	}

	// Token: 0x17001C21 RID: 7201
	// (get) Token: 0x06015BAA RID: 89002 RVA: 0x00607B20 File Offset: 0x00605D20
	public int RoleDataId
	{
		get
		{
			return this.RoleDataIdInternal;
		}
	}

	// Token: 0x17001C22 RID: 7202
	// (get) Token: 0x06015BAB RID: 89003 RVA: 0x00607B28 File Offset: 0x00605D28
	public EFlySkinType SelectedFlySkinType
	{
		get
		{
			return this.SelectedFlySkinTypeInternal;
		}
	}

	// Token: 0x17001C23 RID: 7203
	// (get) Token: 0x06015BAC RID: 89004 RVA: 0x00607B30 File Offset: 0x00605D30
	public int SelectedFlySkinId
	{
		get
		{
			return this.SelectedFlySkinIdInternal;
		}
	}

	// Token: 0x17001C24 RID: 7204
	// (get) Token: 0x06015BAD RID: 89005 RVA: 0x00607B38 File Offset: 0x00605D38
	public FlySkinGridData SelectedGridData
	{
		get
		{
			return this.SelectedGridDataInternal;
		}
	}

	// Token: 0x17001C25 RID: 7205
	// (get) Token: 0x06015BAE RID: 89006 RVA: 0x00607B40 File Offset: 0x00605D40
	public List<IFlySkinGetWayData> GetWayDataList
	{
		get
		{
			return this.GetWayDataListInternal;
		}
	}

	// Token: 0x17001C26 RID: 7206
	// (get) Token: 0x06015BAF RID: 89007 RVA: 0x00607B48 File Offset: 0x00605D48
	public string ModelCase
	{
		get
		{
			return this.ModelCaseInternal;
		}
	}

	// Token: 0x06015BB0 RID: 89008 RVA: 0x00607B50 File Offset: 0x00605D50
	public List<FlySkinGridData> GetGridDataList()
	{
		return base.GetData(EFlySkinViewData.GridDataList) as List<FlySkinGridData>;
	}

	// Token: 0x06015BB1 RID: 89009 RVA: 0x00607B5E File Offset: 0x00605D5E
	public void SetSelectedTab(EFlySkinTab? selectedTab, bool? notNotify = false)
	{
		base.SetData(EFlySkinViewData.SelectedTab, selectedTab, notNotify);
	}

	// Token: 0x06015BB2 RID: 89010 RVA: 0x00607B6E File Offset: 0x00605D6E
	public EFlySkinTab? GetSelectedTab()
	{
		return base.GetData(EFlySkinViewData.SelectedTab) as EFlySkinTab?;
	}

	// Token: 0x06015BB3 RID: 89011 RVA: 0x00607B81 File Offset: 0x00605D81
	public void SetSelectedGridIndex(int gridIndex, bool? notNotify = false)
	{
		base.SetData(EFlySkinViewData.SelectedGridIndex, gridIndex, notNotify);
	}

	// Token: 0x06015BB4 RID: 89012 RVA: 0x00607B91 File Offset: 0x00605D91
	public int GetSelectedGridIndex()
	{
		return (int)base.GetData(EFlySkinViewData.SelectedGridIndex);
	}

	// Token: 0x06015BB5 RID: 89013 RVA: 0x00607BA0 File Offset: 0x00605DA0
	public void Init(ISkinViewData viewData)
	{
		this.RoleDataIdInternal = viewData.RoleId;
		this.SelectedFlySkinIdInternal = viewData.FlySkinId.GetValueOrDefault(-1);
		EFlySkinTab valueOrDefault = viewData.FlySkinTab.GetValueOrDefault();
		this.SetSelectedTab(new EFlySkinTab?(valueOrDefault), new bool?(false));
	}

	// Token: 0x06015BB6 RID: 89014 RVA: 0x00607BF0 File Offset: 0x00605DF0
	public void SelectTab(EFlySkinTab tab)
	{
		this.SelectedFlySkinTypeInternal = FlySkinDefine.flySkinTabToType[tab];
		this.ModelCaseInternal = FlySkinDefine.flySkinTypeToCase[this.SelectedFlySkinTypeInternal];
		this.SetSelectedGridIndex(-1, new bool?(true));
		this.UpdateGridData();
		this.SetSelectedTab(new EFlySkinTab?(tab), new bool?(false));
	}

	// Token: 0x06015BB7 RID: 89015 RVA: 0x00607C4C File Offset: 0x00605E4C
	public void UpdateGridData()
	{
		List<FlySkinGridData> gridDataList = this.GetGridDataList();
		gridDataList.Clear();
		this.SkinIdToGridIndexMapInternal.Clear();
		EFlySkinType selectedFlySkinTypeInternal = this.SelectedFlySkinTypeInternal;
		gridDataList.Add(new FlySkinGridData(0, this.RoleDataIdInternal, selectedFlySkinTypeInternal, null));
		foreach (FlySkinConfig value in ConfigBase<SkinConfig>.Instance.GetFlySkinConfigListByType(selectedFlySkinTypeInternal))
		{
			FlySkinGridData item = new FlySkinGridData(value.Id, this.RoleDataIdInternal, selectedFlySkinTypeInternal, new FlySkinConfig?(value));
			gridDataList.Add(item);
		}
		gridDataList.Sort(delegate(FlySkinGridData a, FlySkinGridData b)
		{
			if (a.SkinConfig == null)
			{
				return -1;
			}
			if (b.SkinConfig == null)
			{
				return 1;
			}
			if (a.GetIsLock() != b.GetIsLock())
			{
				if (!a.GetIsLock())
				{
					return -1;
				}
				return 1;
			}
			else
			{
				if (a.SkinConfig.Value.SortIndex != b.SkinConfig.Value.SortIndex)
				{
					return b.SkinConfig.Value.SortIndex - a.SkinConfig.Value.SortIndex;
				}
				return b.SkinId - a.SkinId;
			}
		});
		for (int i = 0; i < gridDataList.Count; i++)
		{
			this.SkinIdToGridIndexMapInternal[gridDataList[i].SkinId] = i;
		}
		base.SetData(EFlySkinViewData.GridDataList, gridDataList, new bool?(false));
	}

	// Token: 0x06015BB8 RID: 89016 RVA: 0x00607D5C File Offset: 0x00605F5C
	public int? GetGridIndexBySkinId(int skinId)
	{
		int value;
		if (this.SkinIdToGridIndexMapInternal.TryGetValue(skinId, out value))
		{
			return new int?(value);
		}
		return null;
	}

	// Token: 0x06015BB9 RID: 89017 RVA: 0x00607D8C File Offset: 0x00605F8C
	public void SelectGridByIndex(int index)
	{
		this.SelectedGridDataInternal = this.GetGridDataList()[index];
		this.SelectedFlySkinIdInternal = this.SelectedGridDataInternal.SkinId;
		this.SelectedFlySkinConfigInternal = ((this.SelectedFlySkinIdInternal > 0) ? ConfigBase<SkinConfig>.Instance.GetFlySkinConfig(this.SelectedFlySkinIdInternal) : null);
		this.UpdateGetWayDataList();
		this.SetSelectedGridIndex(index, new bool?(false));
	}

	// Token: 0x06015BBA RID: 89018 RVA: 0x00607DFC File Offset: 0x00605FFC
	public void UpdateGetWayDataList()
	{
		this.GetWayDataListInternal = new List<IFlySkinGetWayData>();
		if (this.SelectedFlySkinConfigInternal == null)
		{
			return;
		}
		int itemAccessLength = this.SelectedFlySkinConfigInternal.Value.ItemAccessLength;
		for (int i = 0; i < itemAccessLength; i++)
		{
			int num = this.SelectedFlySkinConfigInternal.Value.ItemAccess(i);
			AccessPath? configById = ConfigBase<GetWayConfig>.Instance.GetConfigById(num);
			if (configById != null)
			{
				FlySkinGetWayData item = new FlySkinGetWayData
				{
					Id = num,
					ConfigId = this.SelectedFlySkinId,
					Type = (EFlySkinGetWayType)configById.Value.Type,
					Text = configById.Value.Description,
					SortIndex = configById.Value.SortIndex
				};
				this.GetWayDataListInternal.Add(item);
			}
		}
		this.GetWayDataListInternal.Sort(delegate(IFlySkinGetWayData aData, IFlySkinGetWayData bData)
		{
			int sortIndex = aData.SortIndex;
			int sortIndex2 = bData.SortIndex;
			if (sortIndex == sortIndex2)
			{
				return bData.Id - aData.Id;
			}
			return sortIndex2 - sortIndex;
		});
	}

	// Token: 0x06015BBB RID: 89019 RVA: 0x00607F06 File Offset: 0x00606106
	public void SetUiShowState(bool state)
	{
		this.UiShowState = state;
	}

	// Token: 0x06015BBC RID: 89020 RVA: 0x00607F0F File Offset: 0x0060610F
	public void SetIsApplyToAll(bool value)
	{
		this.IsApplyToAll = value;
	}

	// Token: 0x06015BBD RID: 89021 RVA: 0x00607F18 File Offset: 0x00606118
	public void ResetSelectedTab()
	{
		this.SetSelectedTab(null, new bool?(false));
		this.SetSelectedGridIndex(-1, new bool?(false));
	}

	// Token: 0x06015BBE RID: 89022 RVA: 0x00607F48 File Offset: 0x00606148
	public IUiCameraInputComponentData GetFlySkinTabCameraInputData(UUIDraggableComponent dragItem)
	{
		string rowName = "翱翔滑翔皮肤旋转查看";
		SUiRoleCameraSetting value = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig(rowName).Value;
		FVectorDouble fvectorDouble = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName(this.ModelCaseInternal).Value, ECollectActorType.UI).D_K2_GetActorLocation();
		return new UiCameraInputComponentData
		{
			DragComponent = dragItem,
			CameraSettingConfig = value,
			SourceLocation = fvectorDouble
		};
	}

	// Token: 0x0400A6BF RID: 42687
	private int RoleDataIdInternal;

	// Token: 0x0400A6C0 RID: 42688
	private EFlySkinType SelectedFlySkinTypeInternal = EFlySkinType.Paragliding;

	// Token: 0x0400A6C1 RID: 42689
	private int SelectedFlySkinIdInternal = -1;

	// Token: 0x0400A6C2 RID: 42690
	private FlySkinConfig? SelectedFlySkinConfigInternal;

	// Token: 0x0400A6C3 RID: 42691
	private FlySkinGridData SelectedGridDataInternal;

	// Token: 0x0400A6C4 RID: 42692
	private readonly Dictionary<int, int> SkinIdToGridIndexMapInternal = new Dictionary<int, int>();

	// Token: 0x0400A6C5 RID: 42693
	private List<IFlySkinGetWayData> GetWayDataListInternal;

	// Token: 0x0400A6C6 RID: 42694
	private string ModelCaseInternal = "";

	// Token: 0x0400A6C7 RID: 42695
	public bool UiShowState = true;

	// Token: 0x0400A6C8 RID: 42696
	public bool IsApplyToAll;
}
