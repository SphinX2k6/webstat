using System;
using System.Runtime.CompilerServices;

// Token: 0x02001766 RID: 5990
[NullableContext(1)]
[Nullable(0)]
public class PeriodicityChallengeTypeData : IPeriodicityChallengeTypeData
{
	// Token: 0x17000DDE RID: 3550
	// (get) Token: 0x0600A853 RID: 43091 RVA: 0x002CCEE0 File Offset: 0x002CB0E0
	// (set) Token: 0x0600A854 RID: 43092 RVA: 0x002CCEE8 File Offset: 0x002CB0E8
	public float LeftTime { get; set; }

	// Token: 0x17000DDF RID: 3551
	// (get) Token: 0x0600A855 RID: 43093 RVA: 0x002CCEF1 File Offset: 0x002CB0F1
	// (set) Token: 0x0600A856 RID: 43094 RVA: 0x002CCEF9 File Offset: 0x002CB0F9
	public int CurrentNum { get; set; }

	// Token: 0x17000DE0 RID: 3552
	// (get) Token: 0x0600A857 RID: 43095 RVA: 0x002CCF02 File Offset: 0x002CB102
	// (set) Token: 0x0600A858 RID: 43096 RVA: 0x002CCF0A File Offset: 0x002CB10A
	public int TotalNum { get; set; }

	// Token: 0x17000DE1 RID: 3553
	// (get) Token: 0x0600A859 RID: 43097 RVA: 0x002CCF13 File Offset: 0x002CB113
	// (set) Token: 0x0600A85A RID: 43098 RVA: 0x002CCF1B File Offset: 0x002CB11B
	public bool IsFinish { get; set; }

	// Token: 0x17000DE2 RID: 3554
	// (get) Token: 0x0600A85B RID: 43099 RVA: 0x002CCF24 File Offset: 0x002CB124
	// (set) Token: 0x0600A85C RID: 43100 RVA: 0x002CCF2C File Offset: 0x002CB12C
	public bool RedPoint { get; set; }

	// Token: 0x17000DE3 RID: 3555
	// (get) Token: 0x0600A85D RID: 43101 RVA: 0x002CCF35 File Offset: 0x002CB135
	// (set) Token: 0x0600A85E RID: 43102 RVA: 0x002CCF3D File Offset: 0x002CB13D
	public string SubText { get; set; }
}
