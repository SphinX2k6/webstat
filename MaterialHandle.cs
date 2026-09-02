using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002C8F RID: 11407
[NullableContext(2)]
[Nullable(0)]
public class MaterialHandle : IMaterialHandle
{
	// Token: 0x17001E25 RID: 7717
	// (get) Token: 0x06016E48 RID: 93768 RVA: 0x00659580 File Offset: 0x00657780
	// (set) Token: 0x06016E49 RID: 93769 RVA: 0x00659588 File Offset: 0x00657788
	public string EffectId { get; set; }

	// Token: 0x17001E26 RID: 7718
	// (get) Token: 0x06016E4A RID: 93770 RVA: 0x00659591 File Offset: 0x00657791
	// (set) Token: 0x06016E4B RID: 93771 RVA: 0x00659599 File Offset: 0x00657799
	public string EffectPath { get; set; }

	// Token: 0x17001E27 RID: 7719
	// (get) Token: 0x06016E4C RID: 93772 RVA: 0x006595A2 File Offset: 0x006577A2
	// (set) Token: 0x06016E4D RID: 93773 RVA: 0x006595AA File Offset: 0x006577AA
	public int HandleId { get; set; }

	// Token: 0x17001E28 RID: 7720
	// (get) Token: 0x06016E4E RID: 93774 RVA: 0x006595B3 File Offset: 0x006577B3
	// (set) Token: 0x06016E4F RID: 93775 RVA: 0x006595BB File Offset: 0x006577BB
	public int RenderingId { get; set; }

	// Token: 0x17001E29 RID: 7721
	// (get) Token: 0x06016E50 RID: 93776 RVA: 0x006595C4 File Offset: 0x006577C4
	// (set) Token: 0x06016E51 RID: 93777 RVA: 0x006595CC File Offset: 0x006577CC
	public UObject MaterialAssetData { get; set; }

	// Token: 0x17001E2A RID: 7722
	// (get) Token: 0x06016E52 RID: 93778 RVA: 0x006595D5 File Offset: 0x006577D5
	// (set) Token: 0x06016E53 RID: 93779 RVA: 0x006595DD File Offset: 0x006577DD
	public bool? WithAnimObject { get; set; }

	// Token: 0x17001E2B RID: 7723
	// (get) Token: 0x06016E54 RID: 93780 RVA: 0x006595E6 File Offset: 0x006577E6
	// (set) Token: 0x06016E55 RID: 93781 RVA: 0x006595EE File Offset: 0x006577EE
	public USkeletalMeshComponent AnimMeshComp { get; set; }

	// Token: 0x17001E2C RID: 7724
	// (get) Token: 0x06016E56 RID: 93782 RVA: 0x006595F7 File Offset: 0x006577F7
	// (set) Token: 0x06016E57 RID: 93783 RVA: 0x006595FF File Offset: 0x006577FF
	public bool? IsGroup { get; set; }
}
