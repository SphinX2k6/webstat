using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x0200311F RID: 12575
[NullableContext(1)]
[Nullable(0)]
public class FightDataTableCollection
{
	// Token: 0x0601A069 RID: 106601 RVA: 0x0079F924 File Offset: 0x0079DB24
	[NullableContext(2)]
	public void SetTable(EFightDataTableKind kind, UDataTable data, EFightDataTableSourceType tableSourceType)
	{
		if (tableSourceType == EFightDataTableSourceType.Self)
		{
			this.GetRepository(kind).SelfTable = data;
		}
	}

	// Token: 0x0601A06A RID: 106602 RVA: 0x0079F937 File Offset: 0x0079DB37
	public void ClearTables(EFightDataTableKind kind, EFightDataTableSourceType tableSourceType)
	{
		if (tableSourceType == EFightDataTableSourceType.Extra)
		{
			this.GetRepository(kind).ClearExtraTables();
		}
	}

	// Token: 0x0601A06B RID: 106603 RVA: 0x0079F949 File Offset: 0x0079DB49
	[NullableContext(2)]
	public void AddTable(EFightDataTableKind kind, UDataTable data, EFightDataTableSourceType tableSourceType = EFightDataTableSourceType.Extra)
	{
		if (tableSourceType == EFightDataTableSourceType.Extra)
		{
			this.GetRepository(kind).AddExtraTable(data);
		}
	}

	// Token: 0x0601A06C RID: 106604 RVA: 0x0079F95C File Offset: 0x0079DB5C
	[NullableContext(2)]
	public void RemoveTable(EFightDataTableKind kind, UDataTable data, EFightDataTableSourceType tableSourceType)
	{
		if (tableSourceType == EFightDataTableSourceType.Extra)
		{
			this.GetRepository(kind).RemoveExtraTable(data);
		}
	}

	// Token: 0x0601A06D RID: 106605 RVA: 0x0079F970 File Offset: 0x0079DB70
	[NullableContext(2)]
	public UDataTable GetTable(EFightDataTableKind kind, EFightDataTableSourceType tableSourceType, EEntityType entityType)
	{
		switch (kind)
		{
		case EFightDataTableKind.Skill:
			return this.SkillRepository.GetTable(tableSourceType, new EEntityType?(entityType));
		case EFightDataTableKind.Bullet:
			return this.BulletRepository.GetTable(tableSourceType, null);
		case EFightDataTableKind.HitEffect:
			return this.HitEffectRepository.GetTable(tableSourceType, null);
		default:
			return null;
		}
	}

	// Token: 0x0601A06E RID: 106606 RVA: 0x0079F9D1 File Offset: 0x0079DBD1
	[NullableContext(2)]
	public void SetDebugTable(EFightDataTableKind kind, ECharacterLoadType loadType, UDataTable data)
	{
		if (kind == EFightDataTableKind.Skill)
		{
			this.SkillRepository.SetDebugTable(loadType, data);
		}
	}

	// Token: 0x0601A06F RID: 106607 RVA: 0x0079F9E3 File Offset: 0x0079DBE3
	public Dictionary<ECharacterLoadType, UDataTable> GetDebugTables(EFightDataTableKind kind)
	{
		if (kind == EFightDataTableKind.Skill)
		{
			return this.SkillRepository.DebugTables;
		}
		return FightDataTableCollection.EmptyDebugTables;
	}

	// Token: 0x0601A070 RID: 106608 RVA: 0x0079F9F9 File Offset: 0x0079DBF9
	public IEnumerable<DataTableKeyRow<SSkillInfo>> EnumerateSkillInfoRows(EFightDataTableSourceType tableSourceType, EEntityType entityType)
	{
		return this.SkillRepository.EnumerateSkillInfoRows(tableSourceType, entityType);
	}

	// Token: 0x0601A071 RID: 106609 RVA: 0x0079FA08 File Offset: 0x0079DC08
	public IEnumerable<int> EnumerateSkillIds(EFightDataTableSourceType tableSourceType, EEntityType entityType)
	{
		return this.SkillRepository.EnumerateSkillIds(tableSourceType, entityType);
	}

	// Token: 0x0601A072 RID: 106610 RVA: 0x0079FA17 File Offset: 0x0079DC17
	[NullableContext(2)]
	public SSkillInfo FindSkillInfo(long skillId, EEntityType entityType)
	{
		return this.SkillRepository.FindSkillInfo(skillId, entityType);
	}

	// Token: 0x0601A073 RID: 106611 RVA: 0x0079FA26 File Offset: 0x0079DC26
	[return: Nullable(2)]
	public SReBulletDataMain FindBulletDataMain(string rowName)
	{
		return this.BulletRepository.FindBulletDataMain(rowName);
	}

	// Token: 0x0601A074 RID: 106612 RVA: 0x0079FA34 File Offset: 0x0079DC34
	public IEnumerable<long> EnumerateBulletIds(EFightDataTableSourceType tableSourceType)
	{
		return this.BulletRepository.EnumerateBulletIds(tableSourceType);
	}

	// Token: 0x0601A075 RID: 106613 RVA: 0x0079FA42 File Offset: 0x0079DC42
	[return: Nullable(2)]
	public SHitEffect FindHitEffect(string rowName)
	{
		return this.HitEffectRepository.FindHitEffect(rowName);
	}

	// Token: 0x0601A076 RID: 106614 RVA: 0x0079FA50 File Offset: 0x0079DC50
	public FightDataTableSnapshot CreateSnapshot(EFightDataTableKind kind, EEntityType entityType)
	{
		switch (kind)
		{
		case EFightDataTableKind.Skill:
			return this.SkillRepository.CreateSnapshot(entityType);
		case EFightDataTableKind.Bullet:
			return this.BulletRepository.CreateSnapshot(entityType);
		case EFightDataTableKind.HitEffect:
			return this.HitEffectRepository.CreateSnapshot(entityType);
		default:
			return new FightDataTableSnapshot();
		}
	}

	// Token: 0x0601A077 RID: 106615 RVA: 0x0079FA9D File Offset: 0x0079DC9D
	private BaseFightDataTableRepository GetRepository(EFightDataTableKind kind)
	{
		switch (kind)
		{
		case EFightDataTableKind.Skill:
			return this.SkillRepository;
		case EFightDataTableKind.Bullet:
			return this.BulletRepository;
		case EFightDataTableKind.HitEffect:
			return this.HitEffectRepository;
		default:
			return this.SkillRepository;
		}
	}

	// Token: 0x0400D0C5 RID: 53445
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<ECharacterLoadType, UDataTable> EmptyDebugTables = new Dictionary<ECharacterLoadType, UDataTable>();

	// Token: 0x0400D0C6 RID: 53446
	private readonly SkillDataTableRepository SkillRepository = new SkillDataTableRepository();

	// Token: 0x0400D0C7 RID: 53447
	private readonly BulletDataTableRepository BulletRepository = new BulletDataTableRepository();

	// Token: 0x0400D0C8 RID: 53448
	private readonly HitEffectDataTableRepository HitEffectRepository = new HitEffectDataTableRepository();
}
