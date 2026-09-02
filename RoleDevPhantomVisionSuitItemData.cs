using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002811 RID: 10257
[NullableContext(1)]
[Nullable(0)]
public class RoleDevPhantomVisionSuitItemData
{
	// Token: 0x17001A19 RID: 6681
	// (get) Token: 0x060143D1 RID: 82897 RVA: 0x005A26F2 File Offset: 0x005A08F2
	public int Id
	{
		get
		{
			return this.IdInternal;
		}
	}

	// Token: 0x17001A1A RID: 6682
	// (get) Token: 0x060143D2 RID: 82898 RVA: 0x005A26FA File Offset: 0x005A08FA
	public string Name
	{
		get
		{
			return this.NameInternal;
		}
	}

	// Token: 0x17001A1B RID: 6683
	// (get) Token: 0x060143D3 RID: 82899 RVA: 0x005A2702 File Offset: 0x005A0902
	public int Cost
	{
		get
		{
			return this.CostInternal;
		}
	}

	// Token: 0x17001A1C RID: 6684
	// (get) Token: 0x060143D4 RID: 82900 RVA: 0x005A270A File Offset: 0x005A090A
	public string ButtonName
	{
		get
		{
			return this.ButtonNameInternal;
		}
	}

	// Token: 0x17001A1D RID: 6685
	// (get) Token: 0x060143D5 RID: 82901 RVA: 0x005A2712 File Offset: 0x005A0912
	public List<IPhantomMonsterItemData> MonsterDataList
	{
		get
		{
			return this.MonsterDataListInternal;
		}
	}

	// Token: 0x17001A1E RID: 6686
	// (get) Token: 0x060143D6 RID: 82902 RVA: 0x005A271A File Offset: 0x005A091A
	public List<IDropRewardItemData> RewardDataList
	{
		get
		{
			return this.RewardDataListInternal;
		}
	}

	// Token: 0x17001A1F RID: 6687
	// (get) Token: 0x060143D7 RID: 82903 RVA: 0x005A2722 File Offset: 0x005A0922
	public int DungeonId
	{
		get
		{
			return this.DungeonIdInternal;
		}
	}

	// Token: 0x17001A20 RID: 6688
	// (get) Token: 0x060143D8 RID: 82904 RVA: 0x005A272A File Offset: 0x005A092A
	public int FetterGroupId
	{
		get
		{
			return this.FetterGroupIdInternal;
		}
	}

	// Token: 0x17001A21 RID: 6689
	// (get) Token: 0x060143D9 RID: 82905 RVA: 0x005A2732 File Offset: 0x005A0932
	public int RoleId
	{
		get
		{
			return this.RoleIdInternal;
		}
	}

	// Token: 0x17001A22 RID: 6690
	// (get) Token: 0x060143DA RID: 82906 RVA: 0x005A273A File Offset: 0x005A093A
	public List<int> RecommendGroupIds
	{
		get
		{
			return this.RecommendGroupIdsInternal;
		}
	}

	// Token: 0x17001A23 RID: 6691
	// (get) Token: 0x060143DB RID: 82907 RVA: 0x005A2742 File Offset: 0x005A0942
	public EVisionSuitItemType ItemType
	{
		get
		{
			return this.ItemTypeInternal;
		}
	}

	// Token: 0x17001A24 RID: 6692
	// (get) Token: 0x060143DC RID: 82908 RVA: 0x005A274A File Offset: 0x005A094A
	public string TypeIcon
	{
		get
		{
			return this.TypeIconInternal;
		}
	}

	// Token: 0x060143DD RID: 82909 RVA: 0x005A2752 File Offset: 0x005A0952
	public void InitByBaseData(int id, EVisionSuitItemType itemType, string name, int cost, string buttonName, string typeIcon)
	{
		this.IdInternal = id;
		this.ItemTypeInternal = itemType;
		this.NameInternal = name;
		this.CostInternal = cost;
		this.ButtonNameInternal = buttonName;
		this.TypeIconInternal = typeIcon;
	}

	// Token: 0x060143DE RID: 82910 RVA: 0x005A2781 File Offset: 0x005A0981
	public void SetItemType(EVisionSuitItemType itemType)
	{
		this.ItemTypeInternal = itemType;
	}

	// Token: 0x060143DF RID: 82911 RVA: 0x005A278A File Offset: 0x005A098A
	public void SetMonsterDataList(List<IPhantomMonsterItemData> dataList)
	{
		this.MonsterDataListInternal = new List<IPhantomMonsterItemData>(dataList);
	}

	// Token: 0x060143E0 RID: 82912 RVA: 0x005A2798 File Offset: 0x005A0998
	public void SetRewardDataList(List<IDropRewardItemData> dataList)
	{
		this.RewardDataListInternal = new List<IDropRewardItemData>(dataList);
	}

	// Token: 0x060143E1 RID: 82913 RVA: 0x005A27A6 File Offset: 0x005A09A6
	public void AddMonsterDataItem(IPhantomMonsterItemData dataItem)
	{
		this.MonsterDataListInternal.Add(dataItem);
	}

	// Token: 0x060143E2 RID: 82914 RVA: 0x005A27B4 File Offset: 0x005A09B4
	public void AddRewardDataItem(IDropRewardItemData dataItem)
	{
		this.RewardDataListInternal.Add(dataItem);
	}

	// Token: 0x060143E3 RID: 82915 RVA: 0x005A27C2 File Offset: 0x005A09C2
	public void SetDungeonId(int dungeonId)
	{
		this.DungeonIdInternal = dungeonId;
	}

	// Token: 0x060143E4 RID: 82916 RVA: 0x005A27CB File Offset: 0x005A09CB
	[NullableContext(2)]
	public void SetFetterGroupInfo(int fetterGroupId, int roleId, List<int> recommendGroupIds = null)
	{
		this.FetterGroupIdInternal = fetterGroupId;
		this.RoleIdInternal = roleId;
		this.RecommendGroupIdsInternal = (recommendGroupIds ?? new List<int>());
	}

	// Token: 0x04009D77 RID: 40311
	private int IdInternal;

	// Token: 0x04009D78 RID: 40312
	private string NameInternal = "";

	// Token: 0x04009D79 RID: 40313
	private int CostInternal;

	// Token: 0x04009D7A RID: 40314
	private string ButtonNameInternal = "";

	// Token: 0x04009D7B RID: 40315
	private List<IPhantomMonsterItemData> MonsterDataListInternal = new List<IPhantomMonsterItemData>();

	// Token: 0x04009D7C RID: 40316
	private List<IDropRewardItemData> RewardDataListInternal = new List<IDropRewardItemData>();

	// Token: 0x04009D7D RID: 40317
	private int DungeonIdInternal;

	// Token: 0x04009D7E RID: 40318
	private int FetterGroupIdInternal;

	// Token: 0x04009D7F RID: 40319
	private int RoleIdInternal;

	// Token: 0x04009D80 RID: 40320
	private List<int> RecommendGroupIdsInternal = new List<int>();

	// Token: 0x04009D81 RID: 40321
	private EVisionSuitItemType ItemTypeInternal;

	// Token: 0x04009D82 RID: 40322
	private string TypeIconInternal = "";
}
