using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02003491 RID: 13457
[NullableContext(1)]
[Nullable(0)]
public class EntityContainer
{
	// Token: 0x0601C630 RID: 116272 RVA: 0x00881CBF File Offset: 0x0087FEBF
	public bool AddEntity(long creatureDataId, EntityHandle handle)
	{
		if (this.EntityMap.Contains(creatureDataId))
		{
			return false;
		}
		this.EntityMap.Set(creatureDataId, handle);
		this.EntityIdMap.Add(handle.Id, creatureDataId);
		return true;
	}

	// Token: 0x0601C631 RID: 116273 RVA: 0x00881CF4 File Offset: 0x0087FEF4
	public bool RemoveEntity(long creatureDataId)
	{
		EntityHandle entityHandle = this.EntityMap.Get(creatureDataId);
		if (entityHandle == null)
		{
			return false;
		}
		this.EntityMap.Remove(creatureDataId);
		this.EntityIdMap.Remove(entityHandle.Id);
		if (entityHandle.ConfigType == EntityConfigType.Level)
		{
			this.PbDataIdMap.Remove(entityHandle.PbDataId);
		}
		return true;
	}

	// Token: 0x0601C632 RID: 116274 RVA: 0x00881D4E File Offset: 0x0087FF4E
	[NullableContext(2)]
	public EntityHandle GetEntity(long creatureDataId)
	{
		return this.EntityMap.Get(creatureDataId);
	}

	// Token: 0x0601C633 RID: 116275 RVA: 0x00881D5C File Offset: 0x0087FF5C
	public bool ExistEntity(long creatureDataId)
	{
		return this.EntityMap.Contains(creatureDataId);
	}

	// Token: 0x0601C634 RID: 116276 RVA: 0x00881D6C File Offset: 0x0087FF6C
	[NullableContext(2)]
	public EntityHandle GetEntityById(int entityId)
	{
		long key;
		if (!this.EntityIdMap.TryGetValue(entityId, out key))
		{
			return null;
		}
		return this.EntityMap.Get(key);
	}

	// Token: 0x0601C635 RID: 116277 RVA: 0x00881D98 File Offset: 0x0087FF98
	[NullableContext(2)]
	public EntityHandle GetEntityByPbDataId(int pbDataId)
	{
		long key;
		if (!this.PbDataIdMap.TryGetValue(pbDataId, out key))
		{
			return null;
		}
		return this.EntityMap.Get(key);
	}

	// Token: 0x0601C636 RID: 116278 RVA: 0x00881DC4 File Offset: 0x0087FFC4
	public void CheckSetPrefabEntity(EntityHandle handle)
	{
		CreatureDataComponent component = handle.Entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return;
		}
		if (component.GetEntityConfigType() != EntityConfigType.Level)
		{
			return;
		}
		this.PbDataIdMap[component.GetPbDataId()] = component.GetCreatureDataId();
	}

	// Token: 0x0601C637 RID: 116279 RVA: 0x00881E02 File Offset: 0x00880002
	public long GetCreatureDataIdByPbDataId(int pbDataId)
	{
		return this.PbDataIdMap.GetValueOrDefault(pbDataId, 0L);
	}

	// Token: 0x0601C638 RID: 116280 RVA: 0x00881E14 File Offset: 0x00880014
	public EntityHandle PopEntity()
	{
		EntityHandle byIndex = this.EntityMap.GetByIndex(0);
		if (byIndex == null)
		{
			return null;
		}
		this.RemoveEntity(byIndex.CreatureDataId);
		return byIndex;
	}

	// Token: 0x0601C639 RID: 116281 RVA: 0x00881E41 File Offset: 0x00880041
	[NullableContext(2)]
	public EntityHandle PeekEntity()
	{
		return this.EntityMap.GetByIndex(0);
	}

	// Token: 0x0601C63A RID: 116282 RVA: 0x00881E4F File Offset: 0x0088004F
	public IReadOnlyList<EntityHandle> GetAllEntities()
	{
		return this.EntityMap.GetItems();
	}

	// Token: 0x0601C63B RID: 116283 RVA: 0x00881E5C File Offset: 0x0088005C
	public int Size()
	{
		return this.EntityMap.Size();
	}

	// Token: 0x0601C63C RID: 116284 RVA: 0x00881E69 File Offset: 0x00880069
	public void Clear()
	{
		this.EntityMap.Clear();
		this.EntityIdMap.Clear();
		this.PbDataIdMap.Clear();
	}

	// Token: 0x0400E47C RID: 58492
	[Nullable(new byte[]
	{
		1,
		2
	})]
	public readonly CustomMap<long, EntityHandle> EntityMap = new CustomMap<long, EntityHandle>();

	// Token: 0x0400E47D RID: 58493
	public readonly Dictionary<int, long> EntityIdMap = new Dictionary<int, long>();

	// Token: 0x0400E47E RID: 58494
	public readonly Dictionary<int, long> PbDataIdMap = new Dictionary<int, long>();
}
