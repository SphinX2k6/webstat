using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Capability;
using UnrealEngine;

// Token: 0x02000E47 RID: 3655
[NullableContext(1)]
public interface IScheduledEntry
{
	// Token: 0x170005EB RID: 1515
	// (get) Token: 0x060057A3 RID: 22435
	// (set) Token: 0x060057A4 RID: 22436
	Capability Cap { get; set; }

	// Token: 0x170005EC RID: 1516
	// (get) Token: 0x060057A5 RID: 22437
	// (set) Token: 0x060057A6 RID: 22438
	ETickingGroup? EffectiveGroup { get; set; }

	// Token: 0x170005ED RID: 1517
	// (get) Token: 0x060057A7 RID: 22439
	// (set) Token: 0x060057A8 RID: 22440
	int EffectiveOrder { get; set; }
}
