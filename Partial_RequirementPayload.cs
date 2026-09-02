using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;

// Token: 0x02002F11 RID: 12049
[NullableContext(2)]
[Nullable(0)]
public class Partial_RequirementPayload
{
	// Token: 0x0400C012 RID: 49170
	public const int DEFAULT_WEAPON_TYPE_NOT_PASS = -2;

	// Token: 0x0400C013 RID: 49171
	public int? SkillId;

	// Token: 0x0400C014 RID: 49172
	public int? SkillGenre;

	// Token: 0x0400C015 RID: 49173
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IReadOnlyList<string> BattleFlags;

	// Token: 0x0400C016 RID: 49174
	public int? CalculateType;

	// Token: 0x0400C017 RID: 49175
	public int? DamageType;

	// Token: 0x0400C018 RID: 49176
	public IReadOnlyList<int> DamageSubTypes;

	// Token: 0x0400C019 RID: 49177
	public int? SmashType;

	// Token: 0x0400C01A RID: 49178
	public long? BulletId;

	// Token: 0x0400C01B RID: 49179
	public long? DamageId;

	// Token: 0x0400C01C RID: 49180
	public long? BuffId;

	// Token: 0x0400C01D RID: 49181
	public bool? IsCritical;

	// Token: 0x0400C01E RID: 49182
	public bool? IsImmune;

	// Token: 0x0400C01F RID: 49183
	public bool? IsTargetKilled;

	// Token: 0x0400C020 RID: 49184
	public EElementType? ElementType;

	// Token: 0x0400C021 RID: 49185
	public int? WeaponType;

	// Token: 0x0400C022 RID: 49186
	public int? PartId;

	// Token: 0x0400C023 RID: 49187
	public int? PartTag;

	// Token: 0x0400C024 RID: 49188
	public IReadOnlyList<int> BulletTags;

	// Token: 0x0400C025 RID: 49189
	public int? SkillDamageCount;

	// Token: 0x0400C026 RID: 49190
	public int? SkillDamageCountByVictim;

	// Token: 0x0400C027 RID: 49191
	public int? BulletDamageCount;

	// Token: 0x0400C028 RID: 49192
	public long? BulletMessageId;

	// Token: 0x0400C029 RID: 49193
	public long? SkillMessageId;

	// Token: 0x0400C02A RID: 49194
	public ECounterAttackType? CounterType;

	// Token: 0x0400C02B RID: 49195
	public DamageSourceType? SourceType;

	// Token: 0x0400C02C RID: 49196
	public EChangeWeaknessType? ChangeWeaknessType;
}
