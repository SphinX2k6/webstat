using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002BAC RID: 11180
[NullableContext(2)]
public interface ITermExplanationRegistryParam
{
	// Token: 0x17001D4E RID: 7502
	// (get) Token: 0x06016426 RID: 91174
	// (set) Token: 0x06016427 RID: 91175
	[Nullable(1)]
	UUIText UiText { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17001D4F RID: 7503
	// (get) Token: 0x06016428 RID: 91176
	// (set) Token: 0x06016429 RID: 91177
	ETermExplanationViewType ViewType { get; set; }

	// Token: 0x17001D50 RID: 7504
	// (get) Token: 0x0601642A RID: 91178
	// (set) Token: 0x0601642B RID: 91179
	ETermExplanationReportType ReportType { get; set; }

	// Token: 0x17001D51 RID: 7505
	// (get) Token: 0x0601642C RID: 91180
	// (set) Token: 0x0601642D RID: 91181
	ETermExplanationViewAttachDirection? AttachDirection { get; set; }

	// Token: 0x17001D52 RID: 7506
	// (get) Token: 0x0601642E RID: 91182
	// (set) Token: 0x0601642F RID: 91183
	UUIItem AttachItem { get; set; }

	// Token: 0x17001D53 RID: 7507
	// (get) Token: 0x06016430 RID: 91184
	// (set) Token: 0x06016431 RID: 91185
	Action OnDisableClick { get; set; }

	// Token: 0x17001D54 RID: 7508
	// (get) Token: 0x06016432 RID: 91186
	// (set) Token: 0x06016433 RID: 91187
	[Nullable(0)]
	ValueTuple<float, float>? CustomOffset { [NullableContext(0)] get; [NullableContext(0)] set; }

	// Token: 0x17001D55 RID: 7509
	// (get) Token: 0x06016434 RID: 91188
	// (set) Token: 0x06016435 RID: 91189
	ETermExplanationGroup? Group { get; set; }

	// Token: 0x17001D56 RID: 7510
	// (get) Token: 0x06016436 RID: 91190
	// (set) Token: 0x06016437 RID: 91191
	int? Priority { get; set; }

	// Token: 0x17001D57 RID: 7511
	// (get) Token: 0x06016438 RID: 91192
	// (set) Token: 0x06016439 RID: 91193
	ETermExplanationViewStyle? Style { get; set; }
}
