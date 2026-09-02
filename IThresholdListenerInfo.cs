using System;
using System.Runtime.CompilerServices;

// Token: 0x02000FBD RID: 4029
[NullableContext(1)]
public interface IThresholdListenerInfo
{
	// Token: 0x1700080C RID: 2060
	// (get) Token: 0x0600671F RID: 26399
	// (set) Token: 0x06006720 RID: 26400
	TThresholdListener Func { get; set; }

	// Token: 0x1700080D RID: 2061
	// (get) Token: 0x06006721 RID: 26401
	// (set) Token: 0x06006722 RID: 26402
	float Max { get; set; }

	// Token: 0x1700080E RID: 2062
	// (get) Token: 0x06006723 RID: 26403
	// (set) Token: 0x06006724 RID: 26404
	float Min { get; set; }

	// Token: 0x1700080F RID: 2063
	// (get) Token: 0x06006725 RID: 26405
	// (set) Token: 0x06006726 RID: 26406
	bool InInterval { get; set; }
}
