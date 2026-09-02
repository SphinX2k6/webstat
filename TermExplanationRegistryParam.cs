using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002BAD RID: 11181
[NullableContext(2)]
[Nullable(0)]
public class TermExplanationRegistryParam : ITermExplanationRegistryParam
{
	// Token: 0x17001D58 RID: 7512
	// (get) Token: 0x0601643A RID: 91194 RVA: 0x0062B06C File Offset: 0x0062926C
	// (set) Token: 0x0601643B RID: 91195 RVA: 0x0062B074 File Offset: 0x00629274
	[Nullable(1)]
	public UUIText UiText { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17001D59 RID: 7513
	// (get) Token: 0x0601643C RID: 91196 RVA: 0x0062B07D File Offset: 0x0062927D
	// (set) Token: 0x0601643D RID: 91197 RVA: 0x0062B085 File Offset: 0x00629285
	public ETermExplanationViewType ViewType { get; set; }

	// Token: 0x17001D5A RID: 7514
	// (get) Token: 0x0601643E RID: 91198 RVA: 0x0062B08E File Offset: 0x0062928E
	// (set) Token: 0x0601643F RID: 91199 RVA: 0x0062B096 File Offset: 0x00629296
	public ETermExplanationReportType ReportType { get; set; }

	// Token: 0x17001D5B RID: 7515
	// (get) Token: 0x06016440 RID: 91200 RVA: 0x0062B09F File Offset: 0x0062929F
	// (set) Token: 0x06016441 RID: 91201 RVA: 0x0062B0A7 File Offset: 0x006292A7
	public ETermExplanationViewAttachDirection? AttachDirection { get; set; }

	// Token: 0x17001D5C RID: 7516
	// (get) Token: 0x06016442 RID: 91202 RVA: 0x0062B0B0 File Offset: 0x006292B0
	// (set) Token: 0x06016443 RID: 91203 RVA: 0x0062B0B8 File Offset: 0x006292B8
	public UUIItem AttachItem { get; set; }

	// Token: 0x17001D5D RID: 7517
	// (get) Token: 0x06016444 RID: 91204 RVA: 0x0062B0C1 File Offset: 0x006292C1
	// (set) Token: 0x06016445 RID: 91205 RVA: 0x0062B0C9 File Offset: 0x006292C9
	public Action OnDisableClick { get; set; }

	// Token: 0x17001D5E RID: 7518
	// (get) Token: 0x06016446 RID: 91206 RVA: 0x0062B0D2 File Offset: 0x006292D2
	// (set) Token: 0x06016447 RID: 91207 RVA: 0x0062B0DA File Offset: 0x006292DA
	[Nullable(0)]
	public ValueTuple<float, float>? CustomOffset { [NullableContext(0)] get; [NullableContext(0)] set; }

	// Token: 0x17001D5F RID: 7519
	// (get) Token: 0x06016448 RID: 91208 RVA: 0x0062B0E3 File Offset: 0x006292E3
	// (set) Token: 0x06016449 RID: 91209 RVA: 0x0062B0EB File Offset: 0x006292EB
	public ETermExplanationGroup? Group { get; set; }

	// Token: 0x17001D60 RID: 7520
	// (get) Token: 0x0601644A RID: 91210 RVA: 0x0062B0F4 File Offset: 0x006292F4
	// (set) Token: 0x0601644B RID: 91211 RVA: 0x0062B0FC File Offset: 0x006292FC
	public int? Priority { get; set; }

	// Token: 0x17001D61 RID: 7521
	// (get) Token: 0x0601644C RID: 91212 RVA: 0x0062B105 File Offset: 0x00629305
	// (set) Token: 0x0601644D RID: 91213 RVA: 0x0062B10D File Offset: 0x0062930D
	public ETermExplanationViewStyle? Style { get; set; }
}
