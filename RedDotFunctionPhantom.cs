using System;

// Token: 0x02003340 RID: 13120
public class RedDotFunctionPhantom : RedDotBase
{
	// Token: 0x0601B69D RID: 112285 RVA: 0x00836C51 File Offset: 0x00834E51
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<FunctionModel>.Instance.RedDotFunctionPhantomCondition();
	}
}
