using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002C6C RID: 11372
[NullableContext(1)]
public interface IOrnamentModelContext
{
	// Token: 0x17001DDD RID: 7645
	// (get) Token: 0x06016CF8 RID: 93432
	// (set) Token: 0x06016CF9 RID: 93433
	int ModelId { get; set; }

	// Token: 0x17001DDE RID: 7646
	// (get) Token: 0x06016CFA RID: 93434
	// (set) Token: 0x06016CFB RID: 93435
	bool HideInUi { get; set; }

	// Token: 0x17001DDF RID: 7647
	// (get) Token: 0x06016CFC RID: 93436
	// (set) Token: 0x06016CFD RID: 93437
	List<long> OrnamentUiBuff { get; set; }
}
