using System;

// Token: 0x02002A7C RID: 10876
public class TeleportStateConditionImpl : ISkipTeleportStateCondition, ISkipCondition<ESkipConditionType>
{
	// Token: 0x17001C3C RID: 7228
	// (get) Token: 0x06015C6F RID: 89199 RVA: 0x0060A950 File Offset: 0x00608B50
	// (set) Token: 0x06015C70 RID: 89200 RVA: 0x0060A958 File Offset: 0x00608B58
	public ESkipConditionType ConditionType { get; set; }

	// Token: 0x17001C3D RID: 7229
	// (get) Token: 0x06015C71 RID: 89201 RVA: 0x0060A961 File Offset: 0x00608B61
	// (set) Token: 0x06015C72 RID: 89202 RVA: 0x0060A969 File Offset: 0x00608B69
	public int MarkId { get; set; }

	// Token: 0x17001C3E RID: 7230
	// (get) Token: 0x06015C73 RID: 89203 RVA: 0x0060A972 File Offset: 0x00608B72
	// (set) Token: 0x06015C74 RID: 89204 RVA: 0x0060A97A File Offset: 0x00608B7A
	public ETeleportState CheckTeleportState { get; set; }
}
