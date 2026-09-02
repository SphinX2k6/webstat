using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp;

// Token: 0x020017C6 RID: 6086
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class BuffItemModel : ModelBase<BuffItemModel>
{
	// Token: 0x0600AC6C RID: 44140 RVA: 0x002DFCCE File Offset: 0x002DDECE
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0600AC6D RID: 44141 RVA: 0x002DFCD1 File Offset: 0x002DDED1
	protected override bool OnClear()
	{
		this.ClearAllUseBuffItemRoleData();
		this.ClearAllBuffItemData();
		return true;
	}

	// Token: 0x0600AC6E RID: 44142 RVA: 0x002DFCE0 File Offset: 0x002DDEE0
	protected override bool OnLeaveLevel()
	{
		this.ClearAllUseBuffItemRoleData();
		return true;
	}

	// Token: 0x0600AC6F RID: 44143 RVA: 0x002DFCEC File Offset: 0x002DDEEC
	public void NewBuffItemData(int itemConfigId, long endCdTimeStamp, int totalCdTime)
	{
		BuffItemData value = new BuffItemData(itemConfigId, (double)endCdTimeStamp, (double)totalCdTime);
		this.BuffItemMap[itemConfigId] = value;
	}

	// Token: 0x0600AC70 RID: 44144 RVA: 0x002DFD11 File Offset: 0x002DDF11
	[NullableContext(2)]
	public BuffItemData GetBuffItemData(int itemConfigId)
	{
		if (!this.BuffItemMap.ContainsKey(itemConfigId))
		{
			return null;
		}
		return this.BuffItemMap[itemConfigId];
	}

	// Token: 0x0600AC71 RID: 44145 RVA: 0x002DFD2F File Offset: 0x002DDF2F
	public IReadOnlyDictionary<int, BuffItemData> GetBuffItemMap()
	{
		return this.BuffItemMap;
	}

	// Token: 0x0600AC72 RID: 44146 RVA: 0x002DFD38 File Offset: 0x002DDF38
	public void GetInCdBuffItemMap(Dictionary<int, BuffItemData> buffItemDataMap)
	{
		foreach (BuffItemData buffItemData in this.BuffItemMap.Values)
		{
			if (buffItemData.GetBuffItemRemainCdTime() > 0.0)
			{
				int itemConfigId = buffItemData.ItemConfigId;
				buffItemDataMap[itemConfigId] = buffItemData;
			}
		}
	}

	// Token: 0x0600AC73 RID: 44147 RVA: 0x002DFDAC File Offset: 0x002DDFAC
	public void ClearAllBuffItemData()
	{
		this.UseBuffItemRoleMap.Clear();
		this.BuffItemMap.Clear();
	}

	// Token: 0x0600AC74 RID: 44148 RVA: 0x002DFDC4 File Offset: 0x002DDFC4
	public void NewUseBuffItemRoleData(string roleName, int position, int roleConfigId, int roleLevel, int currentAttribute, int maxAttribute, int useItemConfigId, Entity entity)
	{
		UseBuffItemRoleData value = new UseBuffItemRoleData(roleName, position, roleConfigId, roleLevel, (float)currentAttribute, (float)maxAttribute, useItemConfigId, entity);
		this.UseBuffItemRoleMap[position] = value;
	}

	// Token: 0x0600AC75 RID: 44149 RVA: 0x002DFDF3 File Offset: 0x002DDFF3
	public void SetCurrentUseBuffItemId(int itemConfigId)
	{
		this.CurrentUseBuffItemId = itemConfigId;
	}

	// Token: 0x0600AC76 RID: 44150 RVA: 0x002DFDFC File Offset: 0x002DDFFC
	public int GetCurrentUseBuffItemId()
	{
		return this.CurrentUseBuffItemId;
	}

	// Token: 0x0600AC77 RID: 44151 RVA: 0x002DFE04 File Offset: 0x002DE004
	public IReadOnlyDictionary<int, UseBuffItemRoleData> GetAllUseBuffItemRole()
	{
		return this.UseBuffItemRoleMap;
	}

	// Token: 0x0600AC78 RID: 44152 RVA: 0x002DFE0C File Offset: 0x002DE00C
	[NullableContext(2)]
	public UseBuffItemRoleData GetUseBuffItemRole(int position)
	{
		if (!this.UseBuffItemRoleMap.ContainsKey(position))
		{
			return null;
		}
		return this.UseBuffItemRoleMap[position];
	}

	// Token: 0x0600AC79 RID: 44153 RVA: 0x002DFE2C File Offset: 0x002DE02C
	[NullableContext(2)]
	public UseBuffItemRoleData GetUseItemRoleByRoleConfigId(int roleConfigId)
	{
		foreach (UseBuffItemRoleData useBuffItemRoleData in this.UseBuffItemRoleMap.Values)
		{
			if (useBuffItemRoleData.RoleConfigId == roleConfigId)
			{
				return useBuffItemRoleData;
			}
		}
		return null;
	}

	// Token: 0x0600AC7A RID: 44154 RVA: 0x002DFE90 File Offset: 0x002DE090
	public void ClearAllUseBuffItemRoleData()
	{
		this.UseBuffItemRoleMap.Clear();
	}

	// Token: 0x0600AC7B RID: 44155 RVA: 0x002DFEA0 File Offset: 0x002DE0A0
	public double GetBuffItemRemainCdTime(int itemConfigId)
	{
		BuffItemData buffItemData = this.GetBuffItemData(itemConfigId);
		if (buffItemData == null)
		{
			return 0.0;
		}
		return buffItemData.GetBuffItemRemainCdTime();
	}

	// Token: 0x0600AC7C RID: 44156 RVA: 0x002DFEC8 File Offset: 0x002DE0C8
	public double GetBuffItemTotalCdTime(int itemConfigId)
	{
		BuffItemData buffItemData = this.GetBuffItemData(itemConfigId);
		if (buffItemData == null)
		{
			return 0.0;
		}
		return buffItemData.GetBuffItemTotalCdTime();
	}

	// Token: 0x0600AC7D RID: 44157 RVA: 0x002DFEF0 File Offset: 0x002DE0F0
	public void SetBuffItemCdTimeStamp(int itemConfigId, long endCdTimeStamp, int totalCdTime)
	{
		BuffItemData buffItemData = this.GetBuffItemData(itemConfigId);
		if (buffItemData != null)
		{
			buffItemData.SetEndCdTimeStamp((double)endCdTimeStamp);
			buffItemData.SetTotalCdTime((double)totalCdTime);
			return;
		}
		this.NewBuffItemData(itemConfigId, endCdTimeStamp, totalCdTime);
	}

	// Token: 0x0600AC7E RID: 44158 RVA: 0x002DFF24 File Offset: 0x002DE124
	public void SetBuffItemCdEndCallback(int itemConfigId, Action callback)
	{
		if (this.GetBuffItemData(itemConfigId) == null)
		{
			return;
		}
		this.BuffCdRefreshItemId = itemConfigId;
		this.BuffCdRefreshEndCallback = callback;
		this.BuffCdRefreshTimerId = TimerSystem.Instance.Forever(new TTimerAction(this.OnBuffCdRefresh), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
	}

	// Token: 0x0600AC7F RID: 44159 RVA: 0x002DFF78 File Offset: 0x002DE178
	private void OnBuffCdRefresh(float delta)
	{
		if (this.GetBuffItemRemainCdTime(this.BuffCdRefreshItemId) <= 0.0)
		{
			Action buffCdRefreshEndCallback = this.BuffCdRefreshEndCallback;
			if (buffCdRefreshEndCallback != null)
			{
				buffCdRefreshEndCallback();
			}
			this.ResetBuffCdTimer();
		}
	}

	// Token: 0x0600AC80 RID: 44160 RVA: 0x002DFFA8 File Offset: 0x002DE1A8
	private void ResetBuffCdTimer()
	{
		if (this.BuffCdRefreshTimerId != null && TimerSystem.Instance.Has(this.BuffCdRefreshTimerId))
		{
			TimerSystem.Instance.Remove(this.BuffCdRefreshTimerId);
		}
		this.BuffCdRefreshItemId = 0;
		this.BuffCdRefreshEndCallback = null;
		this.BuffCdRefreshTimerId = null;
	}

	// Token: 0x0600AC81 RID: 44161 RVA: 0x002DFFF8 File Offset: 0x002DE1F8
	public void SetBuffEquipItem(int itemConfigId, bool isEquipped)
	{
		this.BuffEquipItemMap[itemConfigId] = isEquipped;
		int buffEquipItemCategory = ConfigBase<BuffItemConfig>.Instance.GetBuffEquipItemCategory(itemConfigId);
		if (buffEquipItemCategory != 0)
		{
			if (isEquipped)
			{
				this.BuffEquipCategoryMap.TryAdd((EBuffItemEquipCategory)buffEquipItemCategory, itemConfigId);
				return;
			}
			this.BuffEquipCategoryMap.Remove((EBuffItemEquipCategory)buffEquipItemCategory);
		}
	}

	// Token: 0x0600AC82 RID: 44162 RVA: 0x002E0040 File Offset: 0x002DE240
	public bool IsEquippedBuffCategory(EBuffItemEquipCategory equipCategory)
	{
		return this.BuffEquipCategoryMap.ContainsKey(equipCategory);
	}

	// Token: 0x0600AC83 RID: 44163 RVA: 0x002E0050 File Offset: 0x002DE250
	public int? GetEquippedBuffItemId(EBuffItemEquipCategory equipCategory)
	{
		int value;
		if (this.BuffEquipCategoryMap.TryGetValue(equipCategory, out value))
		{
			return new int?(value);
		}
		return null;
	}

	// Token: 0x0600AC84 RID: 44164 RVA: 0x002E007D File Offset: 0x002DE27D
	public bool IsEquippedBuffItem(int itemConfigId)
	{
		return this.BuffEquipItemMap.ContainsKey(itemConfigId) && this.BuffEquipItemMap[itemConfigId];
	}

	// Token: 0x0600AC85 RID: 44165 RVA: 0x002E009C File Offset: 0x002DE29C
	public List<long> GetEquippedBuffsByRoleId(int roleId, bool checkEnableInUi = false)
	{
		List<long> list = new List<long>();
		foreach (BuffEquipItem buffEquipItem in ConfigBase<BuffItemConfig>.Instance.GetBuffEquipItemByRoleId(roleId))
		{
			if (this.IsEquippedBuffItem(buffEquipItem.ItemId) && (!checkEnableInUi || buffEquipItem.EnableInUI))
			{
				for (int i = 0; i < buffEquipItem.BuffsLength; i++)
				{
					List<long> list2 = list;
					long num = buffEquipItem.Buffs(i);
					list2.AddRange(new ReadOnlySpan<long>(ref num));
				}
			}
		}
		return list;
	}

	// Token: 0x0600AC86 RID: 44166 RVA: 0x002E0138 File Offset: 0x002DE338
	public BuffEquipItem[] GetEquippedBuffItemConfigByRoleId(int roleId)
	{
		List<BuffEquipItem> list = new List<BuffEquipItem>();
		foreach (BuffEquipItem item in ConfigBase<BuffItemConfig>.Instance.GetBuffEquipItemByRoleId(roleId))
		{
			if (this.IsEquippedBuffItem(item.ItemId))
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600AC87 RID: 44167 RVA: 0x002E01A8 File Offset: 0x002DE3A8
	public unsafe void SetCurrentPreviewItemData(int itemId, int roleId)
	{
		this.PreviewBuffIdList = new List<long>();
		IReadOnlyList<BuffEquipItem> buffEquipItemByItemId = ConfigBase<BuffItemConfig>.Instance.GetBuffEquipItemByItemId(itemId);
		if (buffEquipItemByItemId == null || buffEquipItemByItemId.Count == 0)
		{
			return;
		}
		foreach (BuffEquipItem buffEquipItem in buffEquipItemByItemId)
		{
			if (buffEquipItem.RoleId == roleId)
			{
				string message = "填充Buff";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RoleId", buffEquipItem.RoleId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Buffs", buffEquipItem.GetBuffsArray());
				TotalTopUpUtil.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.PreviewBuffIdList = new List<long>();
				for (int i = 0; i < buffEquipItem.BuffsLength; i++)
				{
					this.PreviewBuffIdList.Add(buffEquipItem.Buffs(i));
				}
				break;
			}
		}
	}

	// Token: 0x0600AC88 RID: 44168 RVA: 0x002E02B4 File Offset: 0x002DE4B4
	public List<long> GetCurrentPreviewItemBuffList()
	{
		return this.PreviewBuffIdList;
	}

	// Token: 0x040051B1 RID: 20913
	private readonly Dictionary<int, UseBuffItemRoleData> UseBuffItemRoleMap = new Dictionary<int, UseBuffItemRoleData>();

	// Token: 0x040051B2 RID: 20914
	private readonly Dictionary<int, BuffItemData> BuffItemMap = new Dictionary<int, BuffItemData>();

	// Token: 0x040051B3 RID: 20915
	private readonly Dictionary<int, bool> BuffEquipItemMap = new Dictionary<int, bool>();

	// Token: 0x040051B4 RID: 20916
	private readonly Dictionary<EBuffItemEquipCategory, int> BuffEquipCategoryMap = new Dictionary<EBuffItemEquipCategory, int>();

	// Token: 0x040051B5 RID: 20917
	private int CurrentUseBuffItemId;

	// Token: 0x040051B6 RID: 20918
	[Nullable(2)]
	private TimerHandle BuffCdRefreshTimerId;

	// Token: 0x040051B7 RID: 20919
	[Nullable(2)]
	private Action BuffCdRefreshEndCallback;

	// Token: 0x040051B8 RID: 20920
	private int BuffCdRefreshItemId;

	// Token: 0x040051B9 RID: 20921
	private List<long> PreviewBuffIdList = new List<long>();
}
