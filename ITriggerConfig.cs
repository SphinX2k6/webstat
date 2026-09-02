using System;
using System.Runtime.CompilerServices;

// Token: 0x02002FE7 RID: 12263
[NullableContext(1)]
public interface ITriggerConfig
{
	// Token: 0x17002196 RID: 8598
	// (get) Token: 0x06018FCF RID: 102351
	// (set) Token: 0x06018FD0 RID: 102352
	string Type { get; set; }

	// Token: 0x17002197 RID: 8599
	// (get) Token: 0x06018FD1 RID: 102353
	// (set) Token: 0x06018FD2 RID: 102354
	string[] Preset { get; set; }

	// Token: 0x17002198 RID: 8600
	// (get) Token: 0x06018FD3 RID: 102355
	// (set) Token: 0x06018FD4 RID: 102356
	string Params { get; set; }

	// Token: 0x17002199 RID: 8601
	// (get) Token: 0x06018FD5 RID: 102357
	// (set) Token: 0x06018FD6 RID: 102358
	string Formula { get; set; }

	// Token: 0x1700219A RID: 8602
	// (get) Token: 0x06018FD7 RID: 102359
	// (set) Token: 0x06018FD8 RID: 102360
	EExecuteType ExecuteType { get; set; }
}
