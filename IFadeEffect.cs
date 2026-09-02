using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x02002A8C RID: 10892
[NullableContext(2)]
public interface IFadeEffect
{
	// Token: 0x17001C53 RID: 7251
	// (get) Token: 0x06015CDD RID: 89309
	// (set) Token: 0x06015CDE RID: 89310
	EFadeInScreenShowType? FadeColor { get; set; }

	// Token: 0x17001C54 RID: 7252
	// (get) Token: 0x06015CDF RID: 89311
	// (set) Token: 0x06015CE0 RID: 89312
	float? FadeInTime { get; set; }

	// Token: 0x17001C55 RID: 7253
	// (get) Token: 0x06015CE1 RID: 89313
	// (set) Token: 0x06015CE2 RID: 89314
	float? FadeOutTime { get; set; }

	// Token: 0x17001C56 RID: 7254
	// (get) Token: 0x06015CE3 RID: 89315
	// (set) Token: 0x06015CE4 RID: 89316
	string ScreenEffect { get; set; }
}
