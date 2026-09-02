using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x0200311B RID: 12571
[NullableContext(2)]
[Nullable(0)]
public abstract class BaseFightDataTableRepository
{
	// Token: 0x0601A052 RID: 106578 RVA: 0x0079F41C File Offset: 0x0079D61C
	public virtual UDataTable GetTable(EFightDataTableSourceType tableSourceType, EEntityType? entityType = null)
	{
		if ((tableSourceType & EFightDataTableSourceType.Extra) != (EFightDataTableSourceType)0)
		{
			List<UDataTable> extraTables = this.ExtraTables;
			if (extraTables != null && extraTables.Count > 0)
			{
				return this.ExtraTables[0];
			}
		}
		if ((tableSourceType & EFightDataTableSourceType.Self) != (EFightDataTableSourceType)0)
		{
			return this.SelfTable;
		}
		return null;
	}

	// Token: 0x0601A053 RID: 106579 RVA: 0x0079F45B File Offset: 0x0079D65B
	public void ClearExtraTables()
	{
		this.ExtraTables = null;
		this.ExtraTableRefCounts = null;
	}

	// Token: 0x0601A054 RID: 106580 RVA: 0x0079F46C File Offset: 0x0079D66C
	public void AddExtraTable(UDataTable data)
	{
		if (data == null)
		{
			return;
		}
		if (this.ExtraTableRefCounts == null)
		{
			this.ExtraTableRefCounts = new Dictionary<UDataTable, int>();
		}
		int valueOrDefault = this.ExtraTableRefCounts.GetValueOrDefault(data, 0);
		if (valueOrDefault <= 0)
		{
			if (this.ExtraTables == null)
			{
				this.ExtraTables = new List<UDataTable>();
			}
			this.ExtraTables.Add(data);
		}
		this.ExtraTableRefCounts[data] = valueOrDefault + 1;
	}

	// Token: 0x0601A055 RID: 106581 RVA: 0x0079F4D0 File Offset: 0x0079D6D0
	public void RemoveExtraTable(UDataTable data)
	{
		if (data == null || this.ExtraTableRefCounts == null)
		{
			return;
		}
		int num;
		if (!this.ExtraTableRefCounts.TryGetValue(data, out num) || num <= 0)
		{
			return;
		}
		if (num == 1)
		{
			this.ExtraTableRefCounts.Remove(data);
			List<UDataTable> extraTables = this.ExtraTables;
			if (extraTables != null && extraTables.Count > 0)
			{
				this.ExtraTables.Remove(data);
				if (this.ExtraTables.Count <= 0)
				{
					this.ExtraTables = null;
				}
			}
			if (this.ExtraTableRefCounts.Count <= 0)
			{
				this.ExtraTableRefCounts = null;
			}
			return;
		}
		this.ExtraTableRefCounts[data] = num - 1;
	}

	// Token: 0x0601A056 RID: 106582 RVA: 0x0079F569 File Offset: 0x0079D769
	[NullableContext(1)]
	public virtual FightDataTableSnapshot CreateSnapshot(EEntityType entityType)
	{
		return new FightDataTableSnapshot
		{
			SelfTable = this.SelfTable,
			ExtraTables = ((this.ExtraTables == null) ? null : new List<UDataTable>(this.ExtraTables))
		};
	}

	// Token: 0x0400D0C1 RID: 53441
	public UDataTable SelfTable;

	// Token: 0x0400D0C2 RID: 53442
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<UDataTable> ExtraTables;

	// Token: 0x0400D0C3 RID: 53443
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<UDataTable, int> ExtraTableRefCounts;
}
