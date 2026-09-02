using System;
using System.Runtime.CompilerServices;

// Token: 0x02002CDB RID: 11483
[NullableContext(1)]
public interface IMultiTemplateGridData
{
	// Token: 0x17001E74 RID: 7796
	// (get) Token: 0x0601724D RID: 94797
	object Data { get; }

	// Token: 0x0601724E RID: 94798
	int GetTemplateIndex();

	// Token: 0x0601724F RID: 94799
	ISyncGridProxy CreateProxy();

	// Token: 0x06017250 RID: 94800 RVA: 0x00669DEC File Offset: 0x00667FEC
	bool IsNavigable()
	{
		return true;
	}
}
