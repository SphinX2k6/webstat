using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006AD0 RID: 27344
	[NullableContext(1)]
	public interface ISceneItemSplineMoveTaskParam
	{
		// Token: 0x1700A2AB RID: 41643
		// (get) Token: 0x0604399E RID: 276894
		// (set) Token: 0x0604399F RID: 276895
		int SplineId { get; set; }

		// Token: 0x1700A2AC RID: 41644
		// (get) Token: 0x060439A0 RID: 276896
		// (set) Token: 0x060439A1 RID: 276897
		ISceneItemSplineMoveConfig SplineMoveConfig { get; set; }

		// Token: 0x1700A2AD RID: 41645
		// (get) Token: 0x060439A2 RID: 276898
		// (set) Token: 0x060439A3 RID: 276899
		bool EnableSplineMoveSync { get; set; }

		// Token: 0x1700A2AE RID: 41646
		// (get) Token: 0x060439A4 RID: 276900
		// (set) Token: 0x060439A5 RID: 276901
		bool EnableMovementSync { get; set; }

		// Token: 0x1700A2AF RID: 41647
		// (get) Token: 0x060439A6 RID: 276902
		// (set) Token: 0x060439A7 RID: 276903
		bool NeedMoveToStartPoint { get; set; }

		// Token: 0x1700A2B0 RID: 41648
		// (get) Token: 0x060439A8 RID: 276904
		// (set) Token: 0x060439A9 RID: 276905
		ISceneItemSplineMoveRuntimeData SplineMoveRuntimeData { get; set; }

		// Token: 0x1700A2B1 RID: 41649
		// (get) Token: 0x060439AA RID: 276906
		// (set) Token: 0x060439AB RID: 276907
		[Nullable(2)]
		Action<bool> Callback { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700A2B2 RID: 41650
		// (get) Token: 0x060439AC RID: 276908
		// (set) Token: 0x060439AD RID: 276909
		[Nullable(2)]
		GeneralContext Context { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700A2B3 RID: 41651
		// (get) Token: 0x060439AE RID: 276910
		// (set) Token: 0x060439AF RID: 276911
		bool? UseSplineMoveSyncSwitchOnStart { get; set; }
	}
}
