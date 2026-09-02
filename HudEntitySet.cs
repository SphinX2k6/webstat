using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001F88 RID: 8072
[NullableContext(1)]
[Nullable(0)]
public class HudEntitySet
{
	// Token: 0x0600F1D1 RID: 61905 RVA: 0x00420B0E File Offset: 0x0041ED0E
	public void Initialize()
	{
	}

	// Token: 0x0600F1D2 RID: 61906 RVA: 0x00420B10 File Offset: 0x0041ED10
	public void Clear()
	{
		this.HudUnitEntityList.Clear();
		this.HudUnitEntityMap.Clear();
	}

	// Token: 0x0600F1D3 RID: 61907 RVA: 0x00420B28 File Offset: 0x0041ED28
	public HudEntityData Add(Entity entity)
	{
		HudEntityData hudEntityData = new HudEntityData();
		hudEntityData.Initialize(entity);
		this.HudUnitEntityMap[(long)entity.Id] = hudEntityData;
		this.HudUnitEntityList.Add(hudEntityData);
		return hudEntityData;
	}

	// Token: 0x0600F1D4 RID: 61908 RVA: 0x00420B64 File Offset: 0x0041ED64
	public void Remove(Entity entity)
	{
		HudEntityData byEntity = this.GetByEntity(entity);
		if (byEntity == null)
		{
			return;
		}
		byEntity.Destroy();
		this.HudUnitEntityList.Remove(byEntity);
		this.HudUnitEntityMap.Remove((long)entity.Id);
	}

	// Token: 0x0600F1D5 RID: 61909 RVA: 0x00420BA3 File Offset: 0x0041EDA3
	public int Num()
	{
		return this.HudUnitEntityList.Count;
	}

	// Token: 0x0600F1D6 RID: 61910 RVA: 0x00420BB0 File Offset: 0x0041EDB0
	[return: Nullable(2)]
	public HudEntityData GetByEntity(Entity entity)
	{
		HudEntityData result;
		this.HudUnitEntityMap.TryGetValue((long)entity.Id, out result);
		return result;
	}

	// Token: 0x0600F1D7 RID: 61911 RVA: 0x00420BD4 File Offset: 0x0041EDD4
	[NullableContext(2)]
	public HudEntityData GetByEntityId(long entityId)
	{
		HudEntityData result;
		this.HudUnitEntityMap.TryGetValue(entityId, out result);
		return result;
	}

	// Token: 0x0600F1D8 RID: 61912 RVA: 0x00420BF1 File Offset: 0x0041EDF1
	public List<HudEntityData> GetAll()
	{
		return this.HudUnitEntityList;
	}

	// Token: 0x04007421 RID: 29729
	private List<HudEntityData> HudUnitEntityList = new List<HudEntityData>();

	// Token: 0x04007422 RID: 29730
	private Dictionary<long, HudEntityData> HudUnitEntityMap = new Dictionary<long, HudEntityData>();
}
