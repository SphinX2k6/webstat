using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020029E8 RID: 10728
[NullableContext(1)]
public interface IParallaxItem
{
	// Token: 0x17001BE4 RID: 7140
	// (get) Token: 0x06015628 RID: 87592
	UUIItem Item { get; }

	// Token: 0x17001BE5 RID: 7141
	// (get) Token: 0x06015629 RID: 87593
	float InitPosY { get; }

	// Token: 0x17001BE6 RID: 7142
	// (get) Token: 0x0601562A RID: 87594
	float ParallaxSub { get; }
}
