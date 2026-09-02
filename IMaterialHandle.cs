using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002C8E RID: 11406
[NullableContext(2)]
public interface IMaterialHandle
{
	// Token: 0x17001E1D RID: 7709
	// (get) Token: 0x06016E38 RID: 93752
	// (set) Token: 0x06016E39 RID: 93753
	string EffectId { get; set; }

	// Token: 0x17001E1E RID: 7710
	// (get) Token: 0x06016E3A RID: 93754
	// (set) Token: 0x06016E3B RID: 93755
	string EffectPath { get; set; }

	// Token: 0x17001E1F RID: 7711
	// (get) Token: 0x06016E3C RID: 93756
	// (set) Token: 0x06016E3D RID: 93757
	int HandleId { get; set; }

	// Token: 0x17001E20 RID: 7712
	// (get) Token: 0x06016E3E RID: 93758
	// (set) Token: 0x06016E3F RID: 93759
	int RenderingId { get; set; }

	// Token: 0x17001E21 RID: 7713
	// (get) Token: 0x06016E40 RID: 93760
	// (set) Token: 0x06016E41 RID: 93761
	UObject MaterialAssetData { get; set; }

	// Token: 0x17001E22 RID: 7714
	// (get) Token: 0x06016E42 RID: 93762
	// (set) Token: 0x06016E43 RID: 93763
	bool? WithAnimObject { get; set; }

	// Token: 0x17001E23 RID: 7715
	// (get) Token: 0x06016E44 RID: 93764
	// (set) Token: 0x06016E45 RID: 93765
	USkeletalMeshComponent AnimMeshComp { get; set; }

	// Token: 0x17001E24 RID: 7716
	// (get) Token: 0x06016E46 RID: 93766
	// (set) Token: 0x06016E47 RID: 93767
	bool? IsGroup { get; set; }
}
