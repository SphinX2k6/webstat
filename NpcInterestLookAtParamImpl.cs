using System;
using System.Runtime.CompilerServices;

// Token: 0x0200319C RID: 12700
[NullableContext(1)]
[Nullable(0)]
public class NpcInterestLookAtParamImpl : INpcInterestLookAtParam
{
	// Token: 0x170023D0 RID: 9168
	// (get) Token: 0x0601A589 RID: 107913 RVA: 0x007C37C5 File Offset: 0x007C19C5
	// (set) Token: 0x0601A58A RID: 107914 RVA: 0x007C37CD File Offset: 0x007C19CD
	public int TargetPbDataId { get; set; }

	// Token: 0x170023D1 RID: 9169
	// (get) Token: 0x0601A58B RID: 107915 RVA: 0x007C37D6 File Offset: 0x007C19D6
	// (set) Token: 0x0601A58C RID: 107916 RVA: 0x007C37DE File Offset: 0x007C19DE
	public Vector TargetPosition { get; set; }

	// Token: 0x170023D2 RID: 9170
	// (get) Token: 0x0601A58D RID: 107917 RVA: 0x007C37E7 File Offset: 0x007C19E7
	// (set) Token: 0x0601A58E RID: 107918 RVA: 0x007C37EF File Offset: 0x007C19EF
	public float MaxAngle { get; set; }

	// Token: 0x170023D3 RID: 9171
	// (get) Token: 0x0601A58F RID: 107919 RVA: 0x007C37F8 File Offset: 0x007C19F8
	// (set) Token: 0x0601A590 RID: 107920 RVA: 0x007C3800 File Offset: 0x007C1A00
	public float MaxDistance { get; set; }
}
