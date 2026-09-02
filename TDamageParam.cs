using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;

// Token: 0x02002E60 RID: 11872
[NullableContext(1)]
[Nullable(0)]
public class TDamageParam : DamageEventInfo
{
	// Token: 0x170020B6 RID: 8374
	// (get) Token: 0x06018610 RID: 99856 RVA: 0x006D2DE1 File Offset: 0x006D0FE1
	// (set) Token: 0x06018611 RID: 99857 RVA: 0x006D2DE9 File Offset: 0x006D0FE9
	public Damage DamageData { get; set; }

	// Token: 0x170020B7 RID: 8375
	// (get) Token: 0x06018612 RID: 99858 RVA: 0x006D2DF2 File Offset: 0x006D0FF2
	// (set) Token: 0x06018613 RID: 99859 RVA: 0x006D2DFA File Offset: 0x006D0FFA
	public Entity DirectTarget { get; set; }

	// Token: 0x170020B8 RID: 8376
	// (get) Token: 0x06018614 RID: 99860 RVA: 0x006D2E03 File Offset: 0x006D1003
	// (set) Token: 0x06018615 RID: 99861 RVA: 0x006D2E0B File Offset: 0x006D100B
	public int SkillLevel { get; set; }

	// Token: 0x170020B9 RID: 8377
	// (get) Token: 0x06018616 RID: 99862 RVA: 0x006D2E14 File Offset: 0x006D1014
	// (set) Token: 0x06018617 RID: 99863 RVA: 0x006D2E1C File Offset: 0x006D101C
	public bool IsAddEnergy { get; set; }

	// Token: 0x170020BA RID: 8378
	// (get) Token: 0x06018618 RID: 99864 RVA: 0x006D2E25 File Offset: 0x006D1025
	// (set) Token: 0x06018619 RID: 99865 RVA: 0x006D2E2D File Offset: 0x006D102D
	public bool IsCounterAttack { get; set; }

	// Token: 0x170020BB RID: 8379
	// (get) Token: 0x0601861A RID: 99866 RVA: 0x006D2E36 File Offset: 0x006D1036
	// (set) Token: 0x0601861B RID: 99867 RVA: 0x006D2E3E File Offset: 0x006D103E
	public bool ForceCritical { get; set; }

	// Token: 0x170020BC RID: 8380
	// (get) Token: 0x0601861C RID: 99868 RVA: 0x006D2E47 File Offset: 0x006D1047
	// (set) Token: 0x0601861D RID: 99869 RVA: 0x006D2E4F File Offset: 0x006D104F
	public bool IsBlocked { get; set; }

	// Token: 0x170020BD RID: 8381
	// (get) Token: 0x0601861E RID: 99870 RVA: 0x006D2E58 File Offset: 0x006D1058
	// (set) Token: 0x0601861F RID: 99871 RVA: 0x006D2E60 File Offset: 0x006D1060
	public int PartId { get; set; }

	// Token: 0x170020BE RID: 8382
	// (get) Token: 0x06018620 RID: 99872 RVA: 0x006D2E69 File Offset: 0x006D1069
	// (set) Token: 0x06018621 RID: 99873 RVA: 0x006D2E71 File Offset: 0x006D1071
	public float ExtraRate { get; set; }

	// Token: 0x170020BF RID: 8383
	// (get) Token: 0x06018622 RID: 99874 RVA: 0x006D2E7A File Offset: 0x006D107A
	// (set) Token: 0x06018623 RID: 99875 RVA: 0x006D2E82 File Offset: 0x006D1082
	public DamageSourceType SourceType { get; set; }

	// Token: 0x170020C0 RID: 8384
	// (get) Token: 0x06018624 RID: 99876 RVA: 0x006D2E8B File Offset: 0x006D108B
	// (set) Token: 0x06018625 RID: 99877 RVA: 0x006D2E93 File Offset: 0x006D1093
	public float Accumulation { get; set; }

	// Token: 0x170020C1 RID: 8385
	// (get) Token: 0x06018626 RID: 99878 RVA: 0x006D2E9C File Offset: 0x006D109C
	// (set) Token: 0x06018627 RID: 99879 RVA: 0x006D2EA4 File Offset: 0x006D10A4
	public EElementType Element { get; set; }

	// Token: 0x170020C2 RID: 8386
	// (get) Token: 0x06018628 RID: 99880 RVA: 0x006D2EAD File Offset: 0x006D10AD
	// (set) Token: 0x06018629 RID: 99881 RVA: 0x006D2EB5 File Offset: 0x006D10B5
	public int RandomSeed { get; set; }

	// Token: 0x170020C3 RID: 8387
	// (get) Token: 0x0601862A RID: 99882 RVA: 0x006D2EBE File Offset: 0x006D10BE
	// (set) Token: 0x0601862B RID: 99883 RVA: 0x006D2EC6 File Offset: 0x006D10C6
	public long ContextId { get; set; }

	// Token: 0x170020C4 RID: 8388
	// (get) Token: 0x0601862C RID: 99884 RVA: 0x006D2ECF File Offset: 0x006D10CF
	// (set) Token: 0x0601862D RID: 99885 RVA: 0x006D2ED7 File Offset: 0x006D10D7
	public long? SkillContextId { get; set; }

	// Token: 0x170020C5 RID: 8389
	// (get) Token: 0x0601862E RID: 99886 RVA: 0x006D2EE0 File Offset: 0x006D10E0
	// (set) Token: 0x0601862F RID: 99887 RVA: 0x006D2EE8 File Offset: 0x006D10E8
	public long? CounterSkillMessageId { get; set; }
}
