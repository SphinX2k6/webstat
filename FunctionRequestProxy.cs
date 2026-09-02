using System;
using System.Runtime.CompilerServices;

// Token: 0x02002FF1 RID: 12273
[NullableContext(1)]
[Nullable(0)]
public class FunctionRequestProxy<T> where T : class, IFunctionRequestHandle<T>
{
	// Token: 0x06019033 RID: 102451 RVA: 0x0071969C File Offset: 0x0071789C
	public bool DecideCall(T request)
	{
		if (this.RequestLastTime == Singleton<Time>.Instance.Frame && this.PreFunctionRequestCache != null && this.PreFunctionRequestCache.CompareRequest(request))
		{
			return false;
		}
		this.PreFunctionRequestCache = request;
		this.RequestLastTime = Singleton<Time>.Instance.Frame;
		return true;
	}

	// Token: 0x0400C3B3 RID: 50099
	public int RequestLastTime;

	// Token: 0x0400C3B4 RID: 50100
	[Nullable(2)]
	public T PreFunctionRequestCache;
}
