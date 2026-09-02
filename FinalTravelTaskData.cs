using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001389 RID: 5001
[NullableContext(1)]
[Nullable(0)]
public class FinalTravelTaskData
{
	// Token: 0x17000BB5 RID: 2997
	// (get) Token: 0x0600897A RID: 35194 RVA: 0x00242F31 File Offset: 0x00241131
	public int Current
	{
		get
		{
			return this.FinishedIdSet.Count;
		}
	}

	// Token: 0x17000BB6 RID: 2998
	// (get) Token: 0x0600897B RID: 35195 RVA: 0x00242F3E File Offset: 0x0024113E
	// (set) Token: 0x0600897C RID: 35196 RVA: 0x00242F46 File Offset: 0x00241146
	public int Target { get; set; } = 1;

	// Token: 0x17000BB7 RID: 2999
	// (get) Token: 0x0600897D RID: 35197 RVA: 0x00242F4F File Offset: 0x0024114F
	public HashSet<int> FinishedIdSet { get; } = new HashSet<int>();

	// Token: 0x17000BB8 RID: 3000
	// (get) Token: 0x0600897E RID: 35198 RVA: 0x00242F57 File Offset: 0x00241157
	// (set) Token: 0x0600897F RID: 35199 RVA: 0x00242F5F File Offset: 0x0024115F
	public bool IsReceived { get; set; }

	// Token: 0x06008980 RID: 35200 RVA: 0x00242F68 File Offset: 0x00241168
	public bool CanReceive()
	{
		return !this.IsReceived && this.Current == this.Target;
	}
}
