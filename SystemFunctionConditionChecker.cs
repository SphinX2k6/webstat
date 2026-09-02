using System;
using System.Runtime.CompilerServices;

// Token: 0x02002A77 RID: 10871
public class SystemFunctionConditionChecker : ISkipConditionChecker
{
	// Token: 0x06015C5A RID: 89178 RVA: 0x0060A7C9 File Offset: 0x006089C9
	[NullableContext(1)]
	public ISkipCondition<ESkipConditionType> Parse(int[] @params)
	{
		return new SystemFunctionConditionImpl
		{
			ConditionType = ESkipConditionType.SystemFunction,
			FunctionType = (EFunctionType)@params[0]
		};
	}

	// Token: 0x06015C5B RID: 89179 RVA: 0x0060A7E0 File Offset: 0x006089E0
	[NullableContext(1)]
	public bool Check(int[] @params)
	{
		SystemFunctionConditionImpl systemFunctionConditionImpl = this.Parse(@params) as SystemFunctionConditionImpl;
		if (systemFunctionConditionImpl == null)
		{
			return false;
		}
		EFunctionType functionType = systemFunctionConditionImpl.FunctionType;
		return ModelBase<FunctionModel>.Instance.IsOpen((int)functionType);
	}
}
