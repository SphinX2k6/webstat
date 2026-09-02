using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200348D RID: 13453
[NullableContext(1)]
[Nullable(0)]
public class CreatureDensityContainer
{
	// Token: 0x0601C61C RID: 116252 RVA: 0x008817E2 File Offset: 0x0087F9E2
	public Dictionary<long, CreatureDensityItem> GetLevel(int level)
	{
		while (this.DensityArray.Count <= level)
		{
			this.DensityArray.Add(new Dictionary<long, CreatureDensityItem>());
		}
		return this.DensityArray[level];
	}

	// Token: 0x0601C61D RID: 116253 RVA: 0x00881810 File Offset: 0x0087FA10
	[NullableContext(2)]
	public CreatureDensityItem GetItem(long creatureDataId)
	{
		return this.CreatureDensityMap.GetValueOrDefault(creatureDataId);
	}

	// Token: 0x0601C61E RID: 116254 RVA: 0x00881820 File Offset: 0x0087FA20
	public CreatureDensityItem GetItemByPbDataId(int pbDataId)
	{
		CreatureDensityItem result;
		if (!this.PbDataDensityMap.TryGetValue(pbDataId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0601C61F RID: 116255 RVA: 0x00881840 File Offset: 0x0087FA40
	public CreatureDensityItem AddItem(long creatureDataId, int densityLevel, EntityPb entityData)
	{
		CreatureDensityItem creatureDensityItem = new CreatureDensityItem(creatureDataId, densityLevel, entityData);
		this.CreatureDensityMap[creatureDataId] = creatureDensityItem;
		this.PbDataDensityMap[entityData.ConfigId] = creatureDensityItem;
		while (this.DensityArray.Count <= creatureDensityItem.DensityLevel)
		{
			this.DensityArray.Add(new Dictionary<long, CreatureDensityItem>());
		}
		this.DensityArray[creatureDensityItem.DensityLevel][creatureDataId] = creatureDensityItem;
		return creatureDensityItem;
	}

	// Token: 0x0601C620 RID: 116256 RVA: 0x008818B4 File Offset: 0x0087FAB4
	[NullableContext(2)]
	public CreatureDensityItem RemoveItem(long creatureDataId)
	{
		CreatureDensityItem creatureDensityItem;
		if (!this.CreatureDensityMap.TryGetValue(creatureDataId, out creatureDensityItem))
		{
			return null;
		}
		this.CreatureDensityMap.Remove(creatureDataId);
		this.PbDataDensityMap.Remove(creatureDensityItem.EntityData.ConfigId);
		this.DensityArray[creatureDensityItem.DensityLevel].Remove(creatureDataId);
		return creatureDensityItem;
	}

	// Token: 0x0601C621 RID: 116257 RVA: 0x00881910 File Offset: 0x0087FB10
	public void Clear()
	{
		this.CreatureDensityMap.Clear();
		this.PbDataDensityMap.Clear();
		foreach (Dictionary<long, CreatureDensityItem> dictionary in this.DensityArray)
		{
			dictionary.Clear();
		}
	}

	// Token: 0x0400E455 RID: 58453
	protected readonly List<Dictionary<long, CreatureDensityItem>> DensityArray = new List<Dictionary<long, CreatureDensityItem>>();

	// Token: 0x0400E456 RID: 58454
	protected readonly Dictionary<long, CreatureDensityItem> CreatureDensityMap = new Dictionary<long, CreatureDensityItem>();

	// Token: 0x0400E457 RID: 58455
	protected readonly Dictionary<int, CreatureDensityItem> PbDataDensityMap = new Dictionary<int, CreatureDensityItem>();
}
