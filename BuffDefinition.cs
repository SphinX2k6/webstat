using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002E84 RID: 11908
[NullableContext(2)]
[Nullable(0)]
public class BuffDefinition
{
	// Token: 0x0400BC66 RID: 48230
	public long? Id;

	// Token: 0x0400BC67 RID: 48231
	[Nullable(1)]
	public string Desc = "";

	// Token: 0x0400BC68 RID: 48232
	public EBuffFormationPolicy FormationPolicy;

	// Token: 0x0400BC69 RID: 48233
	public int Probability = 10000;

	// Token: 0x0400BC6A RID: 48234
	public long[] PrematureExpirationEffects;

	// Token: 0x0400BC6B RID: 48235
	public long[] RoutineExpirationEffects;

	// Token: 0x0400BC6C RID: 48236
	public long[] OverflowEffects;

	// Token: 0x0400BC6D RID: 48237
	[Nullable(1)]
	public IBuffModifierData[] Modifiers = Array.Empty<IBuffModifierData>();

	// Token: 0x0400BC6E RID: 48238
	public int StackLimitCount = 1;

	// Token: 0x0400BC6F RID: 48239
	public EBuffStackingType StackingType;

	// Token: 0x0400BC70 RID: 48240
	public int DefaultStackCount = 1;

	// Token: 0x0400BC71 RID: 48241
	public int StackAppendCount;

	// Token: 0x0400BC72 RID: 48242
	public bool DenyOverflowAdd;

	// Token: 0x0400BC73 RID: 48243
	public bool ClearStackOnOverflow;

	// Token: 0x0400BC74 RID: 48244
	public EBuffDurationType DurationPolicy;

	// Token: 0x0400BC75 RID: 48245
	public float[] DurationMagnitude;

	// Token: 0x0400BC76 RID: 48246
	public float[] DurationMagnitude2;

	// Token: 0x0400BC77 RID: 48247
	public int[] DurationCalculationPolicy;

	// Token: 0x0400BC78 RID: 48248
	public long[] GameplayCueIds;

	// Token: 0x0400BC79 RID: 48249
	public float Period;

	// Token: 0x0400BC7A RID: 48250
	public bool ExecutePeriodicOnAdd;

	// Token: 0x0400BC7B RID: 48251
	public EBuffPeriodicInhibitionPolicy PeriodicInhibitionPolicy;

	// Token: 0x0400BC7C RID: 48252
	public EBuffStackDurationRefreshPolicy StackDurationRefreshPolicy = EBuffStackDurationRefreshPolicy.None;

	// Token: 0x0400BC7D RID: 48253
	public EBuffStackPeriodResetPolicy StackPeriodResetPolicy = EBuffStackPeriodResetPolicy.None;

	// Token: 0x0400BC7E RID: 48254
	public int StackExpirationRemoveNumber;

	// Token: 0x0400BC7F RID: 48255
	public bool DurationAffectedByBulletTime;

	// Token: 0x0400BC80 RID: 48256
	public int[] RemoveBuffWithTags;

	// Token: 0x0400BC81 RID: 48257
	public int[] GrantedTags;

	// Token: 0x0400BC82 RID: 48258
	public int[] AddInstigatorTagRequirements;

	// Token: 0x0400BC83 RID: 48259
	public int[] AddInstigatorTagIgnores;

	// Token: 0x0400BC84 RID: 48260
	public int[] AddTagRequirements;

	// Token: 0x0400BC85 RID: 48261
	public int[] AddTagIgnores;

	// Token: 0x0400BC86 RID: 48262
	public int[] ActivateTagRequirements;

	// Token: 0x0400BC87 RID: 48263
	public int[] ActivateTagIgnores;

	// Token: 0x0400BC88 RID: 48264
	public int[] RemoveTagExistAll;

	// Token: 0x0400BC89 RID: 48265
	public int[] RemoveTagIgnores;

	// Token: 0x0400BC8A RID: 48266
	public int[] ImmuneTags;

	// Token: 0x0400BC8B RID: 48267
	public int[] ImmuneTagIgnores;

	// Token: 0x0400BC8C RID: 48268
	public int[] RemoveTagExistAny;

	// Token: 0x0400BC8D RID: 48269
	public long[] BuffsAddedByStackCountOnRemoved;

	// Token: 0x0400BC8E RID: 48270
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public TBuffAction[] BuffAction;

	// Token: 0x0400BC8F RID: 48271
	public bool HasBuffEffect;

	// Token: 0x0400BC90 RID: 48272
	public bool HasBuffPeriodExecution;

	// Token: 0x0400BC91 RID: 48273
	[Nullable(1)]
	public readonly List<ExtraEffectParameters> EffectInfos = new List<ExtraEffectParameters>();

	// Token: 0x0400BC92 RID: 48274
	public bool DeadRemove = true;

	// Token: 0x0400BC93 RID: 48275
	public bool OnlyLocalAdd;

	// Token: 0x0400BC94 RID: 48276
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IConfigOverrideRule[] ConfigOverrides;
}
