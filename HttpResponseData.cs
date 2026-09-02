using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BC7 RID: 3015
[NullableContext(1)]
[Nullable(0)]
public class HttpResponseData
{
	// Token: 0x0600313C RID: 12604 RVA: 0x0001BC8D File Offset: 0x00019E8D
	public HttpResponseData(bool Success, int Code, string Data)
	{
		this.Success = Success;
		this.Code = Code;
		this.Data = Data;
	}

	// Token: 0x04000456 RID: 1110
	public readonly bool Success;

	// Token: 0x04000457 RID: 1111
	public readonly int Code;

	// Token: 0x04000458 RID: 1112
	public readonly string Data;
}
