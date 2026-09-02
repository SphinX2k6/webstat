using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006AD5 RID: 27349
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemSplineMoveRuntimeData : ISceneItemSplineMoveRuntimeData
	{
		// Token: 0x1700A2C3 RID: 41667
		// (get) Token: 0x060439E5 RID: 276965 RVA: 0x01171A07 File Offset: 0x0116FC07
		// (set) Token: 0x060439E6 RID: 276966 RVA: 0x01171A0F File Offset: 0x0116FC0F
		public float? DistanceAloneSpline { get; set; }

		// Token: 0x1700A2C4 RID: 41668
		// (get) Token: 0x060439E7 RID: 276967 RVA: 0x01171A18 File Offset: 0x0116FC18
		// (set) Token: 0x060439E8 RID: 276968 RVA: 0x01171A20 File Offset: 0x0116FC20
		public Vector CurPos { get; set; }

		// Token: 0x1700A2C5 RID: 41669
		// (get) Token: 0x060439E9 RID: 276969 RVA: 0x01171A29 File Offset: 0x0116FC29
		// (set) Token: 0x060439EA RID: 276970 RVA: 0x01171A31 File Offset: 0x0116FC31
		public Rotator CurRot { get; set; }
	}
}
