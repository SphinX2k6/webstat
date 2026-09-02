using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002CD2 RID: 11474
[NullableContext(2)]
[Nullable(0)]
public class TableTextArgNew
{
	// Token: 0x060171D3 RID: 94675 RVA: 0x0066748E File Offset: 0x0066568E
	public TableTextArgNew(string textKey, [ParamCollection] [Nullable(new byte[]
	{
		1,
		2
	})] IReadOnlyList<object> args)
	{
	}

	// Token: 0x0400B1D4 RID: 45524
	[Nullable(new byte[]
	{
		1,
		2
	})]
	public IReadOnlyList<object> Params = args;

	// Token: 0x0400B1D5 RID: 45525
	public string TextKey = textKey;
}
