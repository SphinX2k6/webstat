using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A54 RID: 6740
[NullableContext(1)]
public interface ISpineAnimationQueueParam
{
	// Token: 0x17000FCE RID: 4046
	// (get) Token: 0x0600C0AB RID: 49323
	// (set) Token: 0x0600C0AC RID: 49324
	int LayerIndex { get; set; }

	// Token: 0x17000FCF RID: 4047
	// (get) Token: 0x0600C0AD RID: 49325
	// (set) Token: 0x0600C0AE RID: 49326
	string AnimationName { get; set; }

	// Token: 0x17000FD0 RID: 4048
	// (get) Token: 0x0600C0AF RID: 49327
	// (set) Token: 0x0600C0B0 RID: 49328
	bool Loop { get; set; }
}
