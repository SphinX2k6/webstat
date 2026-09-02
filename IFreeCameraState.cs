using System;
using System.Runtime.CompilerServices;

// Token: 0x0200113D RID: 4413
[NullableContext(2)]
internal interface IFreeCameraState
{
	// Token: 0x17000994 RID: 2452
	// (get) Token: 0x060073D8 RID: 29656
	// (set) Token: 0x060073D9 RID: 29657
	[Nullable(1)]
	IFreeCameraConfig Config { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000995 RID: 2453
	// (get) Token: 0x060073DA RID: 29658
	// (set) Token: 0x060073DB RID: 29659
	float Timer { get; set; }

	// Token: 0x17000996 RID: 2454
	// (get) Token: 0x060073DC RID: 29660
	// (set) Token: 0x060073DD RID: 29661
	int LastDirection { get; set; }

	// Token: 0x17000997 RID: 2455
	// (get) Token: 0x060073DE RID: 29662
	// (set) Token: 0x060073DF RID: 29663
	bool IsInterpolating { get; set; }

	// Token: 0x17000998 RID: 2456
	// (get) Token: 0x060073E0 RID: 29664
	// (set) Token: 0x060073E1 RID: 29665
	float InterpolationElapsedTime { get; set; }

	// Token: 0x17000999 RID: 2457
	// (get) Token: 0x060073E2 RID: 29666
	// (set) Token: 0x060073E3 RID: 29667
	int StartDirection { get; set; }

	// Token: 0x1700099A RID: 2458
	// (get) Token: 0x060073E4 RID: 29668
	// (set) Token: 0x060073E5 RID: 29669
	int TargetDirection { get; set; }

	// Token: 0x1700099B RID: 2459
	// (get) Token: 0x060073E6 RID: 29670
	// (set) Token: 0x060073E7 RID: 29671
	bool? IsExiting { get; set; }

	// Token: 0x1700099C RID: 2460
	// (get) Token: 0x060073E8 RID: 29672
	// (set) Token: 0x060073E9 RID: 29673
	Vector ExitRelativePos { get; set; }

	// Token: 0x1700099D RID: 2461
	// (get) Token: 0x060073EA RID: 29674
	// (set) Token: 0x060073EB RID: 29675
	Rotator ExitRelativeRot { get; set; }

	// Token: 0x1700099E RID: 2462
	// (get) Token: 0x060073EC RID: 29676
	// (set) Token: 0x060073ED RID: 29677
	int? ExitFollowConfigIndex { get; set; }
}
