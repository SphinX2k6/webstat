using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002BE4 RID: 11236
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class TowerDetailModel : ModelBase<TowerDetailModel>
{
	// Token: 0x0601669B RID: 91803 RVA: 0x00639468 File Offset: 0x00637668
	public void AddSwitchData(int index, string name)
	{
		TowerSwitchData towerSwitchData = new TowerSwitchData();
		towerSwitchData.Index = index;
		towerSwitchData.Name = name;
		this.BuffMap[towerSwitchData] = new List<TowerDetailBuffData>();
		this.MonsterMap[towerSwitchData] = new List<TowerDetailMonsterData>();
		this.SwitchData.Add(towerSwitchData);
	}

	// Token: 0x0601669C RID: 91804 RVA: 0x006394B8 File Offset: 0x006376B8
	public void AddBuff(int index, List<TowerDetailBuff> buffs, string title, int priority)
	{
		TowerDetailBuffData towerDetailBuffData = new TowerDetailBuffData();
		towerDetailBuffData.Buffs = buffs;
		towerDetailBuffData.Title = title;
		towerDetailBuffData.Priority = priority;
		for (int i = 0; i < this.SwitchData.Count; i++)
		{
			TowerSwitchData towerSwitchData = this.SwitchData[i];
			List<TowerDetailBuffData> list;
			if (towerSwitchData.Index == index && this.BuffMap.TryGetValue(towerSwitchData, out list))
			{
				list.Add(towerDetailBuffData);
			}
		}
	}

	// Token: 0x0601669D RID: 91805 RVA: 0x00639524 File Offset: 0x00637724
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<TowerDetailBuffData> GetBuffs(TowerSwitchData switchData)
	{
		List<TowerDetailBuffData> result;
		if (this.BuffMap.TryGetValue(switchData, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0601669E RID: 91806 RVA: 0x00639544 File Offset: 0x00637744
	public void AddMonster(int index, List<TowerDetailMonster> towerDetailMonster, string title, int priority)
	{
		TowerDetailMonsterData towerDetailMonsterData = new TowerDetailMonsterData();
		towerDetailMonsterData.Title = title;
		towerDetailMonsterData.MonsterInfos = towerDetailMonster;
		towerDetailMonsterData.Priority = priority;
		for (int i = 0; i < this.SwitchData.Count; i++)
		{
			TowerSwitchData towerSwitchData = this.SwitchData[i];
			List<TowerDetailMonsterData> list;
			if (towerSwitchData.Index == index && this.MonsterMap.TryGetValue(towerSwitchData, out list))
			{
				list.Add(towerDetailMonsterData);
			}
		}
	}

	// Token: 0x0601669F RID: 91807 RVA: 0x006395B0 File Offset: 0x006377B0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<TowerDetailMonsterData> GetMonsters(TowerSwitchData switchData)
	{
		List<TowerDetailMonsterData> result;
		if (this.MonsterMap.TryGetValue(switchData, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x060166A0 RID: 91808 RVA: 0x006395D0 File Offset: 0x006377D0
	public void Reset()
	{
		this.BuffMap = new Dictionary<TowerSwitchData, List<TowerDetailBuffData>>();
		this.MonsterMap = new Dictionary<TowerSwitchData, List<TowerDetailMonsterData>>();
		this.SwitchData = new List<TowerSwitchData>();
	}

	// Token: 0x0400AD8C RID: 44428
	public int CurrentSelectDetailId;

	// Token: 0x0400AD8D RID: 44429
	public string TowerTitle = string.Empty;

	// Token: 0x0400AD8E RID: 44430
	public int SwitchButtonIndex;

	// Token: 0x0400AD8F RID: 44431
	public List<TowerSwitchData> SwitchData = new List<TowerSwitchData>();

	// Token: 0x0400AD90 RID: 44432
	private Dictionary<TowerSwitchData, List<TowerDetailBuffData>> BuffMap = new Dictionary<TowerSwitchData, List<TowerDetailBuffData>>();

	// Token: 0x0400AD91 RID: 44433
	private Dictionary<TowerSwitchData, List<TowerDetailMonsterData>> MonsterMap = new Dictionary<TowerSwitchData, List<TowerDetailMonsterData>>();
}
