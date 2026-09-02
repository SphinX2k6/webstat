using System;
using Aki.Protocol;

// Token: 0x02002D28 RID: 11560
public class WeeklyPlayData
{
	// Token: 0x17001EB2 RID: 7858
	// (get) Token: 0x06017542 RID: 95554 RVA: 0x00677F74 File Offset: 0x00676174
	// (set) Token: 0x06017543 RID: 95555 RVA: 0x00677F7C File Offset: 0x0067617C
	public int PlayId { get; set; }

	// Token: 0x17001EB3 RID: 7859
	// (get) Token: 0x06017544 RID: 95556 RVA: 0x00677F85 File Offset: 0x00676185
	// (set) Token: 0x06017545 RID: 95557 RVA: 0x00677F8D File Offset: 0x0067618D
	public ActivityType Type { get; set; }

	// Token: 0x17001EB4 RID: 7860
	// (get) Token: 0x06017546 RID: 95558 RVA: 0x00677F96 File Offset: 0x00676196
	// (set) Token: 0x06017547 RID: 95559 RVA: 0x00677F9E File Offset: 0x0067619E
	public bool HasRecord { get; set; }
}
