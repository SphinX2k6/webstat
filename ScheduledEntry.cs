using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Capability;
using UnrealEngine;

// Token: 0x02000E48 RID: 3656
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class ScheduledEntry : IScheduledEntry
{
	// Token: 0x170005EE RID: 1518
	// (get) Token: 0x060057A9 RID: 22441 RVA: 0x001055BA File Offset: 0x001037BA
	// (set) Token: 0x060057AA RID: 22442 RVA: 0x001055C2 File Offset: 0x001037C2
	[RequiredMember]
	public Capability Cap { get; set; }

	// Token: 0x170005EF RID: 1519
	// (get) Token: 0x060057AB RID: 22443 RVA: 0x001055CB File Offset: 0x001037CB
	// (set) Token: 0x060057AC RID: 22444 RVA: 0x001055D3 File Offset: 0x001037D3
	public ETickingGroup? EffectiveGroup { get; set; }

	// Token: 0x170005F0 RID: 1520
	// (get) Token: 0x060057AD RID: 22445 RVA: 0x001055DC File Offset: 0x001037DC
	// (set) Token: 0x060057AE RID: 22446 RVA: 0x001055E4 File Offset: 0x001037E4
	[RequiredMember]
	public int EffectiveOrder { get; set; }

	// Token: 0x060057AF RID: 22447 RVA: 0x001055ED File Offset: 0x001037ED
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public ScheduledEntry()
	{
	}
}
