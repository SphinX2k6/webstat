using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x0200311C RID: 12572
[NullableContext(1)]
[Nullable(0)]
public class SkillDataTableRepository : BaseFightDataTableRepository
{
	// Token: 0x0601A058 RID: 106584 RVA: 0x0079F5A0 File Offset: 0x0079D7A0
	[NullableContext(2)]
	public void SetDebugTable(ECharacterLoadType loadType, UDataTable data)
	{
		if (data == null)
		{
			this.DebugTables.Remove(loadType);
			return;
		}
		this.DebugTables[loadType] = data;
	}

	// Token: 0x0601A059 RID: 106585 RVA: 0x0079F5C0 File Offset: 0x0079D7C0
	[NullableContext(2)]
	public SSkillInfo FindSkillInfo(long skillId, EEntityType entityType)
	{
		if (this.SelfTable == null)
		{
			return null;
		}
		string rowName = skillId.ToString();
		UDataTable table;
		if (this.DebugTables.TryGetValue(FightDebugUtil.DtSkillTypeForDebug, out table))
		{
			SSkillInfo dataTableRow = DataTableUtil.GetDataTableRow<SSkillInfo>(table, rowName);
			if (dataTableRow != null)
			{
				return dataTableRow;
			}
		}
		if (this.ExtraTables != null)
		{
			foreach (UDataTable table2 in this.ExtraTables)
			{
				SSkillInfo dataTableRow2 = DataTableUtil.GetDataTableRow<SSkillInfo>(table2, rowName);
				if (dataTableRow2 != null)
				{
					return dataTableRow2;
				}
			}
		}
		SSkillInfo dataTableRow3 = DataTableUtil.GetDataTableRow<SSkillInfo>(this.SelfTable, rowName);
		if (dataTableRow3 != null)
		{
			return dataTableRow3;
		}
		return DataTableUtil.GetDataTableRow<SSkillInfo>(SkillDataTableRepository.GetCommonSkillInfoTable(entityType), rowName);
	}

	// Token: 0x0601A05A RID: 106586 RVA: 0x0079F68C File Offset: 0x0079D88C
	[NullableContext(2)]
	public override UDataTable GetTable(EFightDataTableSourceType tableSourceType, EEntityType? entityType = null)
	{
		UDataTable table = base.GetTable(tableSourceType, entityType);
		if (table != null)
		{
			return table;
		}
		if ((tableSourceType & EFightDataTableSourceType.Common) != (EFightDataTableSourceType)0 && entityType != null)
		{
			return SkillDataTableRepository.GetCommonSkillInfoTable(entityType.Value);
		}
		return null;
	}

	// Token: 0x0601A05B RID: 106587 RVA: 0x0079F6C3 File Offset: 0x0079D8C3
	public IEnumerable<int> EnumerateSkillIds(EFightDataTableSourceType tableSourceType, EEntityType entityType)
	{
		SkillDataTableRepository.<EnumerateSkillIds>d__4 <EnumerateSkillIds>d__ = new SkillDataTableRepository.<EnumerateSkillIds>d__4(-2);
		<EnumerateSkillIds>d__.<>4__this = this;
		<EnumerateSkillIds>d__.<>3__tableSourceType = tableSourceType;
		<EnumerateSkillIds>d__.<>3__entityType = entityType;
		return <EnumerateSkillIds>d__;
	}

	// Token: 0x0601A05C RID: 106588 RVA: 0x0079F6E1 File Offset: 0x0079D8E1
	public IEnumerable<DataTableKeyRow<SSkillInfo>> EnumerateSkillInfoRows(EFightDataTableSourceType tableSourceType, EEntityType entityType)
	{
		SkillDataTableRepository.<EnumerateSkillInfoRows>d__5 <EnumerateSkillInfoRows>d__ = new SkillDataTableRepository.<EnumerateSkillInfoRows>d__5(-2);
		<EnumerateSkillInfoRows>d__.<>4__this = this;
		<EnumerateSkillInfoRows>d__.<>3__tableSourceType = tableSourceType;
		<EnumerateSkillInfoRows>d__.<>3__entityType = entityType;
		return <EnumerateSkillInfoRows>d__;
	}

	// Token: 0x0601A05D RID: 106589 RVA: 0x0079F6FF File Offset: 0x0079D8FF
	public override FightDataTableSnapshot CreateSnapshot(EEntityType entityType)
	{
		return new FightDataTableSnapshot
		{
			SelfTable = this.SelfTable,
			CommonTable = SkillDataTableRepository.GetCommonSkillInfoTable(entityType),
			ExtraTables = ((this.ExtraTables == null) ? null : new List<UDataTable>(this.ExtraTables))
		};
	}

	// Token: 0x0601A05E RID: 106590 RVA: 0x0079F73A File Offset: 0x0079D93A
	[NullableContext(2)]
	private static UDataTable GetCommonSkillInfoTable(EEntityType entityType)
	{
		if (entityType == EEntityType.Player)
		{
			return ConfigBase<WorldConfig>.Instance.GetRoleCommonSkillInfo();
		}
		if (entityType == EEntityType.Monster)
		{
			return ConfigBase<WorldConfig>.Instance.GetMonsterCommonSkillInfo();
		}
		if (entityType != EEntityType.Vision)
		{
			return null;
		}
		return ConfigBase<WorldConfig>.Instance.GetVisionCommonSkillInfo();
	}

	// Token: 0x0601A05F RID: 106591 RVA: 0x0079F76B File Offset: 0x0079D96B
	private static List<string> GetCommonSkillRowNames(EEntityType entityType)
	{
		if (entityType == EEntityType.Player)
		{
			return ConfigBase<WorldConfig>.Instance.GetRoleCommonSkillRowNames();
		}
		if (entityType == EEntityType.Monster)
		{
			return ConfigBase<WorldConfig>.Instance.GetMonsterCommonSkillRowNames();
		}
		if (entityType != EEntityType.Vision)
		{
			return new List<string>();
		}
		return ConfigBase<WorldConfig>.Instance.GetVisionCommonSkillRowNames();
	}

	// Token: 0x0601A060 RID: 106592 RVA: 0x0079F7A0 File Offset: 0x0079D9A0
	private static IEnumerable<T> EnumerateIdsFromTable<[Nullable(2)] T>([Nullable(2)] UDataTable table, HashSet<T> cacheIds, Func<string, T> convert)
	{
		SkillDataTableRepository.<EnumerateIdsFromTable>d__9<T> <EnumerateIdsFromTable>d__ = new SkillDataTableRepository.<EnumerateIdsFromTable>d__9<T>(-2);
		<EnumerateIdsFromTable>d__.<>3__table = table;
		<EnumerateIdsFromTable>d__.<>3__cacheIds = cacheIds;
		<EnumerateIdsFromTable>d__.<>3__convert = convert;
		return <EnumerateIdsFromTable>d__;
	}

	// Token: 0x0601A061 RID: 106593 RVA: 0x0079F7BE File Offset: 0x0079D9BE
	private static IEnumerable<DataTableKeyRow<T>> EnumerateRowsFromTable<[Nullable(0)] T>([Nullable(2)] UDataTable table, HashSet<string> cacheRowNames) where T : UnrealScriptStructProxy
	{
		SkillDataTableRepository.<EnumerateRowsFromTable>d__10<T> <EnumerateRowsFromTable>d__ = new SkillDataTableRepository.<EnumerateRowsFromTable>d__10<T>(-2);
		<EnumerateRowsFromTable>d__.<>3__table = table;
		<EnumerateRowsFromTable>d__.<>3__cacheRowNames = cacheRowNames;
		return <EnumerateRowsFromTable>d__;
	}

	// Token: 0x0400D0C4 RID: 53444
	public readonly Dictionary<ECharacterLoadType, UDataTable> DebugTables = new Dictionary<ECharacterLoadType, UDataTable>();

	// Token: 0x020093BA RID: 37818
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0403120C RID: 201228
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<string, int> <0>__Parse;
	}
}
