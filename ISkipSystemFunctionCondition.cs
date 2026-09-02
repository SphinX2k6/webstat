using System;

// Token: 0x02002A73 RID: 10867
public interface ISkipSystemFunctionCondition : ISkipCondition<ESkipConditionType>
{
	// Token: 0x17001C32 RID: 7218
	// (get) Token: 0x06015C4E RID: 89166
	// (set) Token: 0x06015C4F RID: 89167
	EFunctionType FunctionType { get; set; }
}
