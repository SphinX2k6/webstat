using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x0200311D RID: 12573
[NullableContext(1)]
[Nullable(0)]
public class BulletDataTableRepository : BaseFightDataTableRepository
{
	// Token: 0x0601A063 RID: 106595 RVA: 0x0079F7E8 File Offset: 0x0079D9E8
	public IEnumerable<long> EnumerateBulletIds(EFightDataTableSourceType tableSourceType)
	{
		BulletDataTableRepository.<EnumerateBulletIds>d__0 <EnumerateBulletIds>d__ = new BulletDataTableRepository.<EnumerateBulletIds>d__0(-2);
		<EnumerateBulletIds>d__.<>4__this = this;
		<EnumerateBulletIds>d__.<>3__tableSourceType = tableSourceType;
		return <EnumerateBulletIds>d__;
	}

	// Token: 0x0601A064 RID: 106596 RVA: 0x0079F800 File Offset: 0x0079DA00
	[return: Nullable(2)]
	public SReBulletDataMain FindBulletDataMain(string rowName)
	{
		if (this.ExtraTables != null)
		{
			foreach (UDataTable table in this.ExtraTables)
			{
				SReBulletDataMain dataTableRow = DataTableUtil.GetDataTableRow<SReBulletDataMain>(table, rowName);
				if (dataTableRow != null)
				{
					return dataTableRow;
				}
			}
		}
		SReBulletDataMain dataTableRow2 = DataTableUtil.GetDataTableRow<SReBulletDataMain>(this.SelfTable, rowName);
		if (dataTableRow2 != null)
		{
			return dataTableRow2;
		}
		return null;
	}

	// Token: 0x0601A065 RID: 106597 RVA: 0x0079F884 File Offset: 0x0079DA84
	private static IEnumerable<long> EnumerateIdsFromTable([Nullable(2)] UDataTable table, HashSet<long> cacheIds)
	{
		BulletDataTableRepository.<EnumerateIdsFromTable>d__2 <EnumerateIdsFromTable>d__ = new BulletDataTableRepository.<EnumerateIdsFromTable>d__2(-2);
		<EnumerateIdsFromTable>d__.<>3__table = table;
		<EnumerateIdsFromTable>d__.<>3__cacheIds = cacheIds;
		return <EnumerateIdsFromTable>d__;
	}
}
