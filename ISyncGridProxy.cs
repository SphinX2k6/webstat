using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002CCE RID: 11470
[NullableContext(1)]
public interface ISyncGridProxy
{
	// Token: 0x17001E6C RID: 7788
	// (get) Token: 0x060171BD RID: 94653
	// (set) Token: 0x060171BE RID: 94654
	int GridIndex { get; set; }

	// Token: 0x060171BF RID: 94655
	void Refresh(object data);

	// Token: 0x060171C0 RID: 94656
	void Clear();

	// Token: 0x060171C1 RID: 94657
	void CreateByActor(AActor actor);

	// Token: 0x060171C2 RID: 94658
	void CreateThenShowByActor(AActor actor);
}
