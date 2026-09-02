using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SplineMoveTask
{
	// Token: 0x02006ACF RID: 27343
	[NullableContext(2)]
	public interface ISceneItemSplineMoveRuntimeData
	{
		// Token: 0x1700A2A8 RID: 41640
		// (get) Token: 0x06043998 RID: 276888
		// (set) Token: 0x06043999 RID: 276889
		float? DistanceAloneSpline { get; set; }

		// Token: 0x1700A2A9 RID: 41641
		// (get) Token: 0x0604399A RID: 276890
		// (set) Token: 0x0604399B RID: 276891
		Vector CurPos { get; set; }

		// Token: 0x1700A2AA RID: 41642
		// (get) Token: 0x0604399C RID: 276892
		// (set) Token: 0x0604399D RID: 276893
		Rotator CurRot { get; set; }
	}
}
