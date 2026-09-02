using System;

// Token: 0x02002A78 RID: 10872
public class SystemFunctionConditionImpl : ISkipSystemFunctionCondition, ISkipCondition<ESkipConditionType>
{
	// Token: 0x17001C37 RID: 7223
	// (get) Token: 0x06015C5D RID: 89181 RVA: 0x0060A819 File Offset: 0x00608A19
	// (set) Token: 0x06015C5E RID: 89182 RVA: 0x0060A821 File Offset: 0x00608A21
	public ESkipConditionType ConditionType { get; set; }

	// Token: 0x17001C38 RID: 7224
	// (get) Token: 0x06015C5F RID: 89183 RVA: 0x0060A82A File Offset: 0x00608A2A
	// (set) Token: 0x06015C60 RID: 89184 RVA: 0x0060A832 File Offset: 0x00608A32
	public EFunctionType FunctionType { get; set; }
}
