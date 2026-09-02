using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Capability;

// Token: 0x02000E43 RID: 3651
[NullableContext(1)]
public interface ICapabilityDebugRecord
{
	// Token: 0x170005D1 RID: 1489
	// (get) Token: 0x0600576D RID: 22381
	// (set) Token: 0x0600576E RID: 22382
	int Seq { get; set; }

	// Token: 0x170005D2 RID: 1490
	// (get) Token: 0x0600576F RID: 22383
	// (set) Token: 0x06005770 RID: 22384
	double Time { get; set; }

	// Token: 0x170005D3 RID: 1491
	// (get) Token: 0x06005771 RID: 22385
	// (set) Token: 0x06005772 RID: 22386
	CapabilityCommonDefine.ECapabilityDebugEvent Event { get; set; }

	// Token: 0x170005D4 RID: 1492
	// (get) Token: 0x06005773 RID: 22387
	// (set) Token: 0x06005774 RID: 22388
	string CapabilityId { get; set; }

	// Token: 0x170005D5 RID: 1493
	// (get) Token: 0x06005775 RID: 22389
	// (set) Token: 0x06005776 RID: 22390
	string GameObjectId { get; set; }

	// Token: 0x170005D6 RID: 1494
	// (get) Token: 0x06005777 RID: 22391
	// (set) Token: 0x06005778 RID: 22392
	string ClassName { get; set; }

	// Token: 0x170005D7 RID: 1495
	// (get) Token: 0x06005779 RID: 22393
	// (set) Token: 0x0600577A RID: 22394
	[Nullable(2)]
	string Detail { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170005D8 RID: 1496
	// (get) Token: 0x0600577B RID: 22395
	// (set) Token: 0x0600577C RID: 22396
	double? DurationMs { get; set; }
}
