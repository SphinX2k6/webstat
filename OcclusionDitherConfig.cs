using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Struct;
using UnrealEngine;

// Token: 0x02003020 RID: 12320
public class OcclusionDitherConfig
{
	// Token: 0x06019215 RID: 102933 RVA: 0x007268DC File Offset: 0x00724ADC
	[NullableContext(1)]
	public OcclusionDitherConfig(SOcclusionDitherConfig config)
	{
		this.IsEnableOcclusionDither = config.bEnableOcclusionDither;
		this.OcclusionDitherValue = config.OcclusionDitherValue;
		this.OcclusionDitherInterpSpeed = config.OcclusionDitherInterpSpeed;
		this.IgnoreOcclusionDitherTag = ((config.IgnoreOcclusionDitherTag.TagName == "None") ? null : new FGameplayTag?(config.IgnoreOcclusionDitherTag));
	}

	// Token: 0x0400C539 RID: 50489
	public bool IsEnableOcclusionDither;

	// Token: 0x0400C53A RID: 50490
	public float OcclusionDitherValue;

	// Token: 0x0400C53B RID: 50491
	public float OcclusionDitherInterpSpeed;

	// Token: 0x0400C53C RID: 50492
	public FGameplayTag? IgnoreOcclusionDitherTag;
}
