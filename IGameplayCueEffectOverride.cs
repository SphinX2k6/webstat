using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002F9C RID: 12188
[NullableContext(2)]
public interface IGameplayCueEffectOverride
{
	// Token: 0x17002189 RID: 8585
	// (get) Token: 0x06018D98 RID: 101784
	// (set) Token: 0x06018D99 RID: 101785
	string SocketName { get; set; }

	// Token: 0x1700218A RID: 8586
	// (get) Token: 0x06018D9A RID: 101786
	// (set) Token: 0x06018D9B RID: 101787
	FVector? RelativePosition { get; set; }

	// Token: 0x1700218B RID: 8587
	// (get) Token: 0x06018D9C RID: 101788
	// (set) Token: 0x06018D9D RID: 101789
	FVector? RelativeRotation { get; set; }

	// Token: 0x1700218C RID: 8588
	// (get) Token: 0x06018D9E RID: 101790
	// (set) Token: 0x06018D9F RID: 101791
	FVector? Scale { get; set; }
}
