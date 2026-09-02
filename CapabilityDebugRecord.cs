using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Capability;

// Token: 0x02000E44 RID: 3652
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class CapabilityDebugRecord : ICapabilityDebugRecord
{
	// Token: 0x170005D9 RID: 1497
	// (get) Token: 0x0600577D RID: 22397 RVA: 0x001054CD File Offset: 0x001036CD
	// (set) Token: 0x0600577E RID: 22398 RVA: 0x001054D5 File Offset: 0x001036D5
	[RequiredMember]
	public int Seq { get; set; }

	// Token: 0x170005DA RID: 1498
	// (get) Token: 0x0600577F RID: 22399 RVA: 0x001054DE File Offset: 0x001036DE
	// (set) Token: 0x06005780 RID: 22400 RVA: 0x001054E6 File Offset: 0x001036E6
	[RequiredMember]
	public double Time { get; set; }

	// Token: 0x170005DB RID: 1499
	// (get) Token: 0x06005781 RID: 22401 RVA: 0x001054EF File Offset: 0x001036EF
	// (set) Token: 0x06005782 RID: 22402 RVA: 0x001054F7 File Offset: 0x001036F7
	[RequiredMember]
	public CapabilityCommonDefine.ECapabilityDebugEvent Event { get; set; }

	// Token: 0x170005DC RID: 1500
	// (get) Token: 0x06005783 RID: 22403 RVA: 0x00105500 File Offset: 0x00103700
	// (set) Token: 0x06005784 RID: 22404 RVA: 0x00105508 File Offset: 0x00103708
	[RequiredMember]
	public string CapabilityId { get; set; }

	// Token: 0x170005DD RID: 1501
	// (get) Token: 0x06005785 RID: 22405 RVA: 0x00105511 File Offset: 0x00103711
	// (set) Token: 0x06005786 RID: 22406 RVA: 0x00105519 File Offset: 0x00103719
	[RequiredMember]
	public string GameObjectId { get; set; }

	// Token: 0x170005DE RID: 1502
	// (get) Token: 0x06005787 RID: 22407 RVA: 0x00105522 File Offset: 0x00103722
	// (set) Token: 0x06005788 RID: 22408 RVA: 0x0010552A File Offset: 0x0010372A
	[RequiredMember]
	public string ClassName { get; set; }

	// Token: 0x170005DF RID: 1503
	// (get) Token: 0x06005789 RID: 22409 RVA: 0x00105533 File Offset: 0x00103733
	// (set) Token: 0x0600578A RID: 22410 RVA: 0x0010553B File Offset: 0x0010373B
	[Nullable(2)]
	public string Detail { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170005E0 RID: 1504
	// (get) Token: 0x0600578B RID: 22411 RVA: 0x00105544 File Offset: 0x00103744
	// (set) Token: 0x0600578C RID: 22412 RVA: 0x0010554C File Offset: 0x0010374C
	public double? DurationMs { get; set; }

	// Token: 0x0600578D RID: 22413 RVA: 0x00105555 File Offset: 0x00103755
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public CapabilityDebugRecord()
	{
	}
}
