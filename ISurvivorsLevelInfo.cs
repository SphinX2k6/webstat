using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002B91 RID: 11153
[NullableContext(1)]
public interface ISurvivorsLevelInfo
{
	// Token: 0x17001CF6 RID: 7414
	// (get) Token: 0x06016374 RID: 90996
	int LevelId { get; }

	// Token: 0x17001CF7 RID: 7415
	// (get) Token: 0x06016375 RID: 90997
	long OpenTime { get; }

	// Token: 0x17001CF8 RID: 7416
	// (get) Token: 0x06016376 RID: 90998
	bool IsEndlessMode { get; }

	// Token: 0x17001CF9 RID: 7417
	// (get) Token: 0x06016377 RID: 90999
	ModeInfo Info { get; }
}
